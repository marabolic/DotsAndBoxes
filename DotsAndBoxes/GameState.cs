using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace etf.dotsandboxes.bm170614d
{
    public class GameState {
        
        public class Elem
        {
            public Move move = null;
            public Color color = Color.Gray;
            public Elem(Move m, Color c) { move = m; color = c; }

            public override bool Equals(object obj)
            {
                Elem e = (Elem)obj;
                if (e.color.Equals(this.color) && e.move.Equals(this.move))
                    return true;
                return false;
            }
        }

        public static List<Elem> moves = new List<Elem>();

        public int[,] boxes = new int[10,10];
        
        static int numRows;
        static int numColumns;
        Player currPlayer;
        Game game;
        int numMoves;


        public GameState(Game game)
        {
            this.game = game;
            currPlayer = game.getPlayer1();
            numMoves = 0;
        }

        public GameState(GameState gs)
        {
            for (int i = 0; i < gs.getMoves().Count; i++)
            {
                moves.Add(gs.getMoves()[i]);
            }
            currPlayer = gs.currPlayer;
            game = gs.game;

        }

        //MAPPING

        public static string map(Move m)
        {
            char let;
            int num;
            string s;
            if (m.getDirection() == Move.DIRECTION.HORIZONTAL)
            { //first - integer, second - letter
                num = m.getRow();
                let = Convert.ToChar(m.getColumn() + 'A');
                s = num.ToString() + let;
            }
            else
            { //first - letter, second - integer
                let = Convert.ToChar(m.getRow() + 'A');
                num = m.getColumn();
                s = let + num.ToString();
            }

            return s;
        }

        public static Move map(string s)
        {
            char first = s[0];
            char second = s[1];
            int row, col;
            Move m;
            if (Char.IsLetter(first))
            {
                row = Convert.ToInt32(first - 'A');
                col = Convert.ToInt32(second);
                m = new Move(row, col, Move.DIRECTION.VERTICAL);
            }
            else
            {
                row = Convert.ToInt32(first);
                col = Convert.ToInt32(second - 'A');
                m = new Move(row, col, Move.DIRECTION.VERTICAL);
            }
            return m;
        }


        //READ WRITE

        public void readState(StreamReader sr) { //read from file 
            string dimensions = sr.ReadLine();
            string[] splitted = dimensions.Split(' ');
            int r = Convert.ToInt32(splitted[0]);
            int c = Convert.ToInt32(splitted[1]);
            setRowsAndColumns(r, c);
            Color color = game.getPlayer1().getColor();
            while (!sr.EndOfStream)  {
                string value = sr.ReadLine();
                Move m = map(value);
                moves.Add(new Elem(m,color));
                color = currPlayer.getColor();
                
            }
        }

        public StreamWriter writeState()
        {
            StreamWriter sw = new StreamWriter("output.txt");
            //TODO
            return sw;
        }

        //SET GET

        public List<Elem> getMoves()
        {
            return moves;
        }

        public int movesSize() { return numMoves; }

        public void setRowsAndColumns(int r, int c) {
            numRows = r; numColumns = c;
        }

        public Player getCurrentPlayer() { return currPlayer; }

        void changePlayer()
        {
            if (currPlayer == game.getPlayer1()) currPlayer = game.getPlayer2();
            else currPlayer = game.getPlayer1();
        }

        public int score(Player p)
        {
            //todo
            return 1;
        }


        // MOVES HASH OPERATIONS


        public void addBox(int i, int j)
        {
            if (getCurrentPlayer() == game.getPlayer1())
                boxes[i, j] = 1;
            else boxes[i, j] = 2;
        }

        public void addMove(Move m, Color color)
        {
            Color colo;
            if (!exists(m, out colo))
            {
                moves.Add(new Elem(m, color));
                int dir = (int)m.getDirection();
                int row = m.getRow();
                int col = m.getColumn();
                bool dontChange = false;
                if (dir == 0)
                {
                    if (row < Form2.NumRows())
                    {
                        if (countEdges(row, col, color) == 4) {
                            addBox(row, col);
                            dontChange = true;
                        }
                        
                    }
                    if (row > 0)
                    {
                        if (countEdges(row - 1, col, color) == 4)
                        {
                            addBox(row-1, col);
                            dontChange = true;
                        }
                    }

                }
                else
                {
                    if (col < Form2.NumCols())
                    {
                        if (countEdges(row, col, color) == 4)
                        {
                            addBox(row, col);
                            dontChange = true;
                        }
                    }
                    if (col > 0)
                    {
                        if (countEdges(row, col - 1, color) == 4)
                        {
                            addBox(row, col - 1);
                            dontChange = true;

                        }
                    }
                }

                if (!dontChange)
                {
                    changePlayer();
                }

            }
        }



        //CHECKING MOVES

        public bool gameOver()
        {
            
            return false;
        }

        public bool exists(Move m, out Color color)
        {
            for (int i = 0; i < moves.Count; i++) {
                if (m.Equals(moves[i].move))
                {
                    color = moves[i].color;
                    return true;
                }
            }
            color = Color.Gray;
            return false;
        }

        public bool get(int r, int c, int direction, Color color)
        {
            switch (direction)
            {
                case 0:
                    return getUp(r, c, out color);
                    break;
                case 1:
                    return getRight(r, c, out color);
                    break;
                case 2:
                    return getDown(r, c,out color);
                    break;
                case 3:
                    return getLeft(r, c, out color);
                    break;
                default:
                    return false;
            }
        }

        public Move fourthEdge(int r, int c, Color col)
        {
            int ret = 0;
            Move m;
            for (int i = 0; i < 4; i++) {
                if (!get(r, c, i, col)) ret = i;
            }
            switch (ret)
            {
                case 0: m = new Move(r, c, Move.DIRECTION.HORIZONTAL); break;
                case 1: m = new Move(r, c + 1, Move.DIRECTION.VERTICAL); break;
                case 2: m = new Move(r + 1, c, Move.DIRECTION.HORIZONTAL); break;
                case 3: m = new Move(r, c, Move.DIRECTION.VERTICAL); break;
                default: return null;

            }
            return m;
        }

        public int countEdges(int r, int c, Color col)
        {
            int cnt = 0;
            for (int i = 0; i < 4; i++)
            {
                if (get(r, c, i, col)) cnt++;
            }
            return cnt;
        }

        public bool makesSquare(int r, int c, Color color) {
            if (getUp(r,c,out color) && getDown(r, c, out color) && getLeft(r, c, out color) && getRight(r, c, out color)) {
                return true;
            }
            return false;
        }

        public bool getUp(int r, int c, out Color color) {
            Move m = new Move(r, c, Move.SIDE.UP);
            return exists(m, out color);
        }

        public bool getDown(int r, int c, out Color color) {
            Move m = new Move(r, c, Move.SIDE.DOWN);
            return exists(m, out color);
        }

        public bool getLeft(int r, int c, out Color color) {
            Move m = new Move(r, c, Move.SIDE.LEFT);
            return exists(m, out color);
        }

        public bool getRight(int r, int c, out Color color) {
            Move m = new Move(r, c, Move.SIDE.RIGHT);
            return exists(m, out color);
        }
    }

}

