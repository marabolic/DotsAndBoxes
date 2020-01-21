using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
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

            Move m;
            while (true)
            {
                Random r = new Random();
                int row = r.Next(0, Form2.NumRows());
                int column = r.Next(0, Form2.NumCols());
                int side = r.Next(0, 4);
                m = new Move(row, column, Move.convertSide(side));
                Color c;
                if (gameState.exists(m,out  c) ) break;
            }
            return m;
        }
    }
}
