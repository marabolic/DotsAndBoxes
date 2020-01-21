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

        public static Dictionary<Move, Color> moves = new Dictionary<Move, Color>();
      
        static int numRows;
        static int numColumns;
        Player currPlayer;
        Game game;

        public GameState(Game game)
        {
            this.game = game;
            currPlayer = game.getPlayer1();
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
                moves.Add(m,color);
                if (game.getGameState().makesSquare(r, c, out color))
                {
                    game.getGameState().changePlayer();
                    color = currPlayer.getColor();
                }
            }
        }

        public StreamWriter writeState()
        {
            StreamWriter sw = new StreamWriter("output.txt");
            //TODO
            return sw;
        }



        //SET GET

        public void setRowsAndColumns(int r, int c) {
            numRows = r; numColumns = c;
        }

        public Player getCurrentPlayer() { return currPlayer; }

        void changePlayer()
        {
            if (currPlayer == game.getPlayer1()) currPlayer = game.getPlayer2();
            else currPlayer = game.getPlayer1();
        }


        // MOVES HASH OPERATIONS

        public void addMove(Move m, Color color)
        {
            moves.Add(m, color);
        }



        //CHECKING MOVES

        public bool gameOver()
        {
            //TODO
            return false;
        }

        public bool exists(Move m, out Color color)
        {
            return moves.TryGetValue(m, out color);
        }

        public bool makesSquare(int r, int c, out Color color) {
            if (getUp(r,c, out color) && getDown(r, c, out color) && getLeft(r, c, out color) && getRight(r, c, out color)) {
                return true;
            }
            return false;
        }

        public bool getUp(int r, int c, out Color color) {
            Move m = new Move(r, c, Move.DIRECTION.HORIZONTAL);
            return exists(m, out color);
        }

        public bool getDown(int r, int c, out Color color) {
            Move m = new Move(r+1, c, Move.DIRECTION.HORIZONTAL);
            return exists(m, out color);
        }

        public bool getLeft(int r, int c, out Color color) {
            Move m = new Move(r, c, Move.DIRECTION.VERTICAL);
            return exists(m, out color);
        }

        public bool getRight(int r, int c, out Color color) {
            Move m = new Move(r, c+1, Move.DIRECTION.VERTICAL);
            return exists(m, out color);
        }
    }

}

