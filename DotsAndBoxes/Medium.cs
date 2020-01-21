using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace etf.dotsandboxes.bm170614d
{
    class Medium : Strategy
    {
        public override Move playMove(GameState gameState)
        {
            for (int i = 0; i < Form2.NumRows(); i++)
                for (int j = 0; j < Form2.NumCols(); j++)
                    if (gameState.countEdges(i, j, gameState.getCurrentPlayer().getColor()) == 3)
                    {
                        return gameState.fourthEdge(i, j, gameState.getCurrentPlayer().getColor());
                    }

            Tuple<int, Move> ret = minimax(gameState, Form2.depth, Int32.MinValue, Int32.MaxValue);

            return ret.Item2;
        }



        public Tuple<int, Move> minimax(GameState gameState, int depth, int alpha, int beta)
        {
            if (gameState.gameOver() || depth == 0)
            {
                return new Tuple<int, Move>(gameState.score(gameState.getCurrentPlayer()), null);
            }

            Move bestMove = null;
            int bestScore;
            if (gameState.getCurrentPlayer() == myPlayer)
            {
                bestScore = Int32.MinValue;
            }
            else { bestScore = Int32.MaxValue; }

            List<Move> lastMoves = new List<Move>();

            bool found = false;

            for (int row = 0;  row < Form2.NumRows() + 1;  row++)
            {
                for (int col = 0; col < Form2.NumCols() + 1; col++)
                {
                    for (int dir = 0; dir < 2; dir++)
                    {
                        if (dir == 0 && row == Form2.NumRows()) break; 
                        if (dir == 1 && col == Form2.NumCols()) break;
                        Color c;
                        if (gameState.exists(new Move(row,col, (Move.DIRECTION)dir), out c)) continue;

                        if (dir == 0) {
                            if (row < Form2.NumRows()) {
                                if (gameState.countEdges(row, col, c) == 2)  {
                                    lastMoves.Add(new Move(row, col, (Move.DIRECTION)dir));
                                    continue;
                                }
                            }
                            if (row > 0)  {
                                if (gameState.countEdges(row - 1, col, c) == 2) {
                                    if (row >= Form2.NumRows())
                                        lastMoves.Add(new Move(row, col, (Move.DIRECTION)dir));
                                    continue;
                                }
                            }

                        }
                        else {
                            if (col < Form2.NumCols()) {
                                if (gameState.countEdges(row, col, c) == 2) {
                                    lastMoves.Add(new Move(row, col, (Move.DIRECTION)dir));
                                    continue;
                                }
                            }
                            if (col > 0) {
                                if (gameState.countEdges(row, col - 1, c) == 2) {
                                    if (col >= Form2.NumCols())
                                        lastMoves.Add(new Move(row, col, (Move.DIRECTION)dir));
                                    continue;
                                }
                            }
                        }

                        GameState newState = new GameState(gameState);
                        Move m = new Move(row, col, (Move.DIRECTION) dir);
                        newState.addMove(m, c);
                        
                        int currScore;
                        Move currMove;
                        Tuple<int, Move> curr = minimax(newState, depth - 1, alpha, beta);
                        found = true;


                        if (gameState.getCurrentPlayer() == myPlayer)
                        {
                            if (curr.Item1 > bestScore)
                            {
                                bestScore = curr.Item1;
                                bestMove = m;

                                if (bestScore > beta) return new Tuple<int, Move>(bestScore, bestMove);
                                alpha = Math.Max(alpha, bestScore);
                            }
                        }
                        else
                        {
                            if (curr.Item1 < bestScore)
                            {
                                bestScore = curr.Item1;
                                bestMove = m;

                                if (bestScore <= alpha) return new Tuple<int, Move>(bestScore, bestMove);
                                beta = Math.Min(beta, bestScore);
                            }
                        }
                    }
                }
            }

            if (!found)
            {
                foreach(Move m in lastMoves)
                {
                    GameState newState = new GameState(gameState);
                    
                    newState.addMove(m, Color.Aqua);
                    int currScore;
                    Move currMove;
                    Tuple<int, Move> curr = minimax(newState, depth - 1, alpha, beta);
                    found = true;


                    if (gameState.getCurrentPlayer() == myPlayer)
                    {
                        if (curr.Item1 > bestScore)
                        {
                            bestScore = curr.Item1;
                            bestMove = m;

                            if (bestScore > beta) return new Tuple<int, Move>(bestScore, bestMove);
                            alpha = Math.Max(alpha, bestScore);
                        }
                    }
                    else
                    {
                        if (curr.Item1 < bestScore)
                        {
                            bestScore = curr.Item1;
                            bestMove = m;

                            if (bestScore <= alpha) return new Tuple<int, Move>(bestScore, bestMove);
                            beta = Math.Min(beta, bestScore);
                        }
                    }
                }
            }

            return new Tuple<int, Move>(bestScore, bestMove);
        }
    }
}
