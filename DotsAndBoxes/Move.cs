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
        public enum SIDE
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        public static SIDE convertSide(int s)
        {
            switch (s)
            {
                case 0: return SIDE.UP;
                case 1: return SIDE.DOWN;
                case 2: return SIDE.LEFT;
                default: return SIDE.RIGHT;
            }
        }
        public Move(int row, int col, SIDE s)
        {
            switch (s)
            {
                case SIDE.UP:
                    this.row = row;
                    this.column = col;
                    this.direction = DIRECTION.HORIZONTAL;
                    break;
                case SIDE.DOWN:
                    this.row = row + 1;
                    this.column = col;
                    this.direction = DIRECTION.HORIZONTAL;
                    break;
                case SIDE.LEFT:
                    this.row = row;
                    this.column = col;
                    this.direction = DIRECTION.VERTICAL;
                    break;
                case SIDE.RIGHT:
                    this.row = row;
                    this.column = col + 1;
                    this.direction = DIRECTION.VERTICAL;
                    break;
            }
        }

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
