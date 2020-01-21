using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace etf.dotsandboxes.bm170614d
{
    public class Game 
    {

        Player player1;
        Player player2;

        GameState gameState;

        public Game() {
            
        }

        public Game(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            player1.setColor(Color.Blue);
            player2.setColor(Color.DarkRed);
            player1.setMyTurn(true);
            gameState = new GameState(this);
        }

        public void setPlayer1(Player p) { player1 = p; player1.setColor(Color.Blue); player1.setMyTurn(true); }
        public void setPlayer2(Player p) { player2 = p; player2.setColor(Color.DarkRed); }
        public void setGameState() { gameState = new GameState(this); }

        public void loadState(StreamReader sr) {
            gameState.readState(sr);
        }

        public GameState getGameState() { return gameState; }

        public string map(Move m) {
            string s = GameState.map(m);
            return s; 
        }

   
        
        
        public Player getPlayer1() { return player1; }
        public Player getPlayer2() { return player2; }
       
    }
}
