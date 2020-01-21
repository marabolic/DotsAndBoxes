using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etf.dotsandboxes.bm170614d
{
    class Human : Player
    {
        public Human()
        {
            
        }

        public override Move makeMove(GameState gameState) {
            Move temp = currentMove;
            currentMove = null;
            return temp;
        }

        public override bool isHuman() { return true; }
    }
}
 