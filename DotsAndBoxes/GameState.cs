using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DotsAndBoxes
{
    class GameState {

        public static Dictionary<Move, bool> moves = new Dictionary<Move, bool>();
        public static Dictionary<Move, string> moveString = new Dictionary<Move, string>();

        static int numRows;
        static int numColumns;

        public GameState() {

        }

        public string map(Move m)
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

        public Move map(string s)
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

        public string exists(Move m) {
            string str;
            moveString.TryGetValue(m, out str);
            return str;
        }


        public void readState(StreamReader sr) { //read from file 
            string dimensions = sr.ReadLine();
            string[] splitted = dimensions.Split(' ');
            int r = Convert.ToInt32(splitted[0]);
            int c = Convert.ToInt32(splitted[1]);
            setRowsAndColumns(r, c);

            while (!sr.EndOfStream)  {
                string value = sr.ReadLine();
                Move m = map(value);
                moves.Add(m,true);
            }
        }

        public void setRowsAndColumns(int r, int c) {
            numRows = r; numColumns = c;
        }


        public StreamWriter writeState() {
            StreamWriter sw = new StreamWriter("output.txt");
            //TODO
            return sw;
        }

        public void addMove(Move m)
        {
            moveString.Add(m, map(m));
            moves.Add(m, true);
        }

        public bool makesSquare(int r, int c) {
            if (getUp(r,c) && getDown(r, c) && getLeft(r, c) && getRight(r, c)) {
                return true;
            }
            return false;
        }

        public bool getUp(int r, int c) {
            Move m = new Move(r, c, Move.DIRECTION.HORIZONTAL);
            bool val;
            moves.TryGetValue(m, out val);
            return val;
        }
        public bool getDown(int r, int c) {
            Move m = new Move(r+1, c, Move.DIRECTION.HORIZONTAL);
            bool val;
            moves.TryGetValue(m, out val);
            return val;
        }
        public bool getLeft(int r, int c) {
            Move m = new Move(r, c, Move.DIRECTION.VERTICAL);
            bool val;
            moves.TryGetValue(m, out val);
            return val;
        }
        public bool getRight(int r, int c) {
            Move m = new Move(r, c+1, Move.DIRECTION.VERTICAL);
            bool val;
            moves.TryGetValue(m, out val);
            return val;
        }
    }

}

