using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace etf.dotsandboxes.bm170614d
{
    public abstract class Player
    {
        Color color; //red second, blue first player
        bool myTurn = false;
        Move currentMove;

        public Player() { currentMove = null; }

        public void setColor(Color color) { this.color = color; }

        public Color getColor() { return color; }

        public void setCurrentMove(Move currMove) { currentMove = currMove; }

        public Move getCurrentMove() { return currentMove; }

        public bool isMyMove() { return myTurn; }

        public abstract bool isHuman();

        public void setMyTurn(bool myTurn) { this.myTurn = myTurn; }

        public abstract void makeMove(Move move);

       
    }
}
