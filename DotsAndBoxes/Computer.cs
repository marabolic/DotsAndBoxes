﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etf.dotsandboxes.bm170614d
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

        public override Move makeMove(GameState gameState)
        {
           return strategy.playMove(gameState);
        }

        public override bool isHuman()
        {
            return false;
        }
    }
}
