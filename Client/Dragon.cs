using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace DragonsAndRabbits.Client
{
    public class Dragon
    {
        private static int dragonNumber = 0;
        private int id;
        private Player firstPlayer, secondPlayer;
        private Boolean busy;
        private String name;
        private int x, y;



        public Dragon()
        {
            setID(++dragonNumber);
            setName();
        }

        //Setter and Getter

        //Method to set ID of the dragon
        private void setID(int id)
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);

            if (id < 0)
            {
                throw new Exception("ID may not < 0 be");
            }

            this.id = id;
        }

        //Method to get actual Number of the Dragon
        public int getID()
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            return id;
        }

        //Method sets a first Player in game
        private void setFirstPlayer(Player firstPlayer)
        {
            Contract.Assume(firstPlayer is Player, "Type is not Player!");
            Contract.Requires(firstPlayer == null);

            if (firstPlayer == null)
            {
                throw new Exception("First Player is null");
            }

            this.firstPlayer = firstPlayer;
        }

        //Method to get First Player
        public Player getFirstPlayer()
        {
            Contract.Requires(firstPlayer != null);
            Contract.Ensures(firstPlayer != null);

            return firstPlayer;
        }

        //Methode to set a cecond Player in game,it checks - is first player same the second Player

        private void setSecondPlayer(Player secondPlayer)
        {
            Contract.Assume(firstPlayer is Player, "Type must Player be!");
            Contract.Requires(!secondPlayer.Equals(firstPlayer));
            Contract.Requires(secondPlayer != null);
            this.secondPlayer = secondPlayer;

            if (secondPlayer == null)
            {
                throw new Exception("Second Player is null");
            }

            if (firstPlayer.Equals(secondPlayer))
            {
                throw new Exception("Second Player is same First Player");
            }
        }

        //Method to get Second Player
        public Player getSecondPlayer()
        {
            Contract.Requires(secondPlayer != null);
            Contract.Ensures(secondPlayer != null);

            return secondPlayer;
        }

        //Method to set name of the dragon
        private void setName()
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            this.name = "Dragon" + getID();
        }

        //Method to get the name of the Dragon
        public String getName()
        {
            Contract.Requires(name != null && name.Length > 3);
            Contract.Ensures(name != null && name.Length > 3);
            return this.name;
        }

        //Method to set actual status of the Dragon. If two Player in the game - is status Busy
        private void setBusy()
        {
            if (firstPlayer != null && secondPlayer != null)
            {
                this.busy = true;
            }

        }

        //Method to get actual status of the Dragon
        public Boolean isBusy()
        {
            return busy;
        }

        //Method to set X-Coordinate
        private void setX(int x)
        {
            Contract.Requires(x >= 0);
            Contract.Ensures(x >= 0);
            this.x = x;
        }

        //Method to get X-Coordinate
        public int getX()
        {
            Contract.Ensures(x >= 0);

            return x;
        }

        //Method to set Y-Coordinate
        private void setY(int y)
        {
            Contract.Requires(y >= 0);
            Contract.Ensures(y >= 0);

            this.y = y;
        }

        //Method to get Y-Coordinate
        public int getY()
        {
            Contract.Ensures(y >= 0);

            return y;
        }

        //Method starts the stagHunt game
        public void stagHunt(Player firstPlayer, Player secondPlayer)
        {

            Contract.Requires(firstPlayer != null && secondPlayer == null);
            Contract.Requires((getFirstPlayer().getX() == this.getX()) && (getFirstPlayer().getY() == this.getY()));
            Contract.Requires((getSecondPlayer().getX() == this.getX()) && (getSecondPlayer().getY() == this.getY()));
            Contract.Requires(firstPlayer.isBusy() && secondPlayer.isBusy());
            Contract.Ensures(firstPlayer.isBusy() && secondPlayer.isBusy());
            Contract.Ensures((getFirstPlayer().getX() == this.getX()) && (getFirstPlayer().getY() == this.getY()));
            Contract.Ensures((getSecondPlayer().getX() == this.getX()) && (getSecondPlayer().getY() == this.getY()));
            setFirstPlayer(firstPlayer);
            setSecondPlayer(secondPlayer);
        }
    }
}
