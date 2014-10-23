using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace DragonsAndRabbits.Client
{
    class Dragon
    {
        private int id;
        private Player firstPlayer, secondPlayer;
        private Boolean busy;
        private String name;
        private int x, y;


        //Setter and Getter


        private void setID(int id)
        {
            this.id = id;
        }
        public int getID()
        {
            return id;
        }

        //methode set a first Player in game

        private void setFirstPlayer(Player firstPlayer)
        {
            Contract.Assume(firstPlayer is Player, "Type must Player be!");
            Contract.Requires(firstPlayer == null);
            this.firstPlayer = firstPlayer;
        }
        public Player getFirstPlayer()
        {
            return firstPlayer;
        }

        //methode set a cecond Player in game,it checks - is first player same the second Player

        private void setSecondPlayer(Player secondPlayer)
        {
            Contract.Assume(firstPlayer is Player, "Type must Player be!");
            Contract.Requires(secondPlayer.Equals(firstPlayer));
            Contract.Requires(secondPlayer == null);
            this.secondPlayer = secondPlayer;
        }

        public Player getSecondPlayer()
        {
            return secondPlayer;
        }

        private void setBusy()
        {
            if (firstPlayer != null && secondPlayer != null)
            {
                this.busy = true;
            }

        }

        public Boolean isBusy()
        {
            return busy;
        }

        private void setX(int x)
        {
            this.x = x;
        }

        public int getX()
        {
            return x;
        }
        private void setY(int y)
        {
            this.y = y;
        }
        public int getY()
        {
            return y;
        }

        public void startDragpnHunt(Player firstPlayer, Player secondPlayer)
        {
            //Preconditions
            Contract.Requires(firstPlayer == null);
            Contract.Requires(secondPlayer == null);
        }
    }
}
