using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace etf.dotsandboxes.bm170614d
{
    abstract class Player
    {
        Color color; //red second, blue first player
        bool myTurn = false;

        public void setColor(Color color) { this.color = color; }

        public bool isMyMove() { return myTurn; }

        public void setMyTurn(bool myTurn) { this.myTurn = myTurn; }

        public abstract void makeMove(Move move);

       
    }
}
