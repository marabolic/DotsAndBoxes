using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etf.dotsandboxes.bm170614d
{
    abstract class Strategy
    {
        public Player myPlayer;
        public abstract Move playMove(GameState gameState);
    }
}
