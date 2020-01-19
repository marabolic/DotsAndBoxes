using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxes
{
   
    class Computer : Player
    {
        public enum STRATEGY
        {
            EASY = 0,
            MEDIUM = 1,
            HARD = 2
        }
        Strategy strategy;
        public Computer(STRATEGY s)
        {
            switch (s)
            {
                case STRATEGY.EASY:
                    strategy = new Easy();
                    break;
                case STRATEGY.MEDIUM:
                    strategy = new Medium();
                    break;
                case STRATEGY.HARD:
                    strategy = new Hard();
                    break;
            }
        }

        public override void makeMove(Move move)
        {
            throw new NotImplementedException();
        }
    }
}
