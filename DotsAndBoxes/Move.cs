using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etf.dotsandboxes.bm170614d
{
    public class Move
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

        public override bool Equals(object obj)
        {
            Move m = (Move)obj;
            return m.row == row && m.column == column && direction == m.direction;
        }

        public override int GetHashCode()
        {
            return row * 100 + column * 10 + (int)direction;
        }

        public DIRECTION getDirection() { return direction; }
        public int getRow() { return row; }
        public int getColumn() { return column; }
    }
}
