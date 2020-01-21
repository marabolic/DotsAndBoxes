using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etf.dotsandboxes.bm170614d
{
    class Easy : Strategy
    {
        public override Move playMove(GameState gameState)
        {
            for (int i = 0; i < Form2.NumRows(); i++)
                for (int j = 0; j < Form2.NumCols(); j++)
                    if(gameState.countEdges(i,j,gameState.getCurrentPlayer().getColor()) == 3) {
                        return gameState.fourthEdge(i, j, gameState.getCurrentPlayer().getColor());
                    }

            Random r = new Random();



            return null;
        }
    }
}
