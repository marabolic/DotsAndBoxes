using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DotsAndBoxes
{
    abstract class Player
    {
        Color color; //red second, blue first player
        bool myMove = false;

        public void setColor(Color color) { this.color = color; }

        public bool isMyMove() { return myMove; }

        public void setMyMove(bool myMove) { this.myMove = myMove; }

        public abstract void makeMove(Move move);
    }
}
