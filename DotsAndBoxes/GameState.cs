using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DotsAndBoxes
{
    class GameState
    {
        
        public static Dictionary<string, Move> stringMove = new Dictionary<string, Move>();
        public static Dictionary<Move, string> moveString = new Dictionary<Move, string>();


        static int numRows;
        static int numColumns;
        int[,] stateMatrix = new int[numRows, numColumns];


        public GameState() {
            for (int i = 0; i < numRows; i++)
                for (int j = 0; j < numColumns; j++)
                    stateMatrix[i, j] = 0;  
        }

        public void readState(StreamReader sr){ //read from file 
            string dimensions = sr.ReadLine();
            string [] splitted = dimensions.Split(' ');
            int r = Convert.ToInt32(splitted[0]);
            int c = Convert.ToInt32(splitted[1]);
            setRowsAndColumns(r, c);

            while (!sr.EndOfStream) {
                int row, col;
                string value = sr.ReadLine();
                char first =  value[0];
                char second = value[1];

                if (Char.IsLetter(first))
                {
                    row = Convert.ToInt32(first - 'A');
                    col = Convert.ToInt32(second);
                    //makeMove(row, col, Move.DIRECTION.VERTICAL);
                }
                else
                {
                    row = Convert.ToInt32(first);
                    col = Convert.ToInt32(second - 'A');
                    //makeMove(row, col, Move.DIRECTION.HORIZONTAL);
                }
                

            }

        }
        public void setRowsAndColumns(int r, int c) {
            numRows = r; numColumns = c;
        }


        public StreamWriter writeState() {
            StreamWriter sw = new StreamWriter("output.txt");

            return sw;
        }

        public void add(int i, int j) {
            stateMatrix[i, j] = 1;
        }
    }
}
