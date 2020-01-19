using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace DotsAndBoxes
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
            player1.setMyMove(true);
            gameState = new GameState();
        }

        public void loadState(StreamReader sr)
        {
            gameState.readState(sr);

        }

        public Player getPlayer1() { return player1; }
        public Player getPlayer2() { return player2; }
       
    }
}
