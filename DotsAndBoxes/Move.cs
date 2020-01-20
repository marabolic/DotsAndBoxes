using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxes
{
    class Move
    {
        public enum DIRECTION {
            HORIZONTAL = 0,
            VERTICAL = 1
        }
        int row, column;
        DIRECTION direction;

        public Move(int row, int col, DIRECTION dir) {
            direction = dir;
            this.row = row;
            this.column = col;
            
        }

        public DIRECTION getDirection() { return direction; }
        public int getRow() { return row; }
        public int getColumn() { return column; }
    }
}
