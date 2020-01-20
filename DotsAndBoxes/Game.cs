using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace etf.dotsandboxes.bm170614d
{
    class Game 
    {

        Player player1;
        Player player2;

        GameState gameState;

        public Game(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            player1.setColor(Color.Blue);
            player2.setColor(Color.DarkRed);
            player1.setMyTurn(true);
            gameState = new GameState();
        }

        public void loadState(StreamReader sr)
        {
            gameState.readState(sr);

        }

        public string map(Move m)
        {
            string s = GameState.map(m);
            return s;
        }

        public void checkExists(Move m)
        {
            gameState.exists(m);
        }

        public bool makesSquare(int r, int c)
        {
            return gameState.makesSquare(r, c);
        }

        public void addMove(Move m)
        {
            gameState.addMove(m);
        }
        
        public Player getPlayer1() { return player1; }
        public Player getPlayer2() { return player2; }
       
    }
}
