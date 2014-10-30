using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Client
{
    public class Dragon
    {
        private static int dragonNumber = 0;
        private int id;
        private Player firstPlayer, secondPlayer;
        private String name;
        private int xCoordinate, yCoordinate;


        /// <summary>
        ///  Generates an object of Dragon.
        /// </summary>
        public Dragon()
        {
            setID(++dragonNumber);
            setName();
        }

        //Setter and Getter


        /// <summary>
        /// Method to set ID of the dragon
        /// </summary>
        /// <param name="id"></param>
        private void setID(int id)
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);

            if (id < 0)
            {
                throw new NullReferenceException("ID may not < 0 be");
            }

            this.id = id;
        }


        /// <summary>
        /// Method to get actual Number of the Dragon
        /// </summary>
        /// <returns></returns>
        public int getID()
        {

            Contract.Ensures(id > 0);
            return id;
        }


        /// <summary>
        /// Method sets a first Player
        /// </summary>
        /// <param name="firstPlayer"></param>
        private void setFirstPlayer(Player firstPlayer)
        {
            Contract.Assume(firstPlayer is Player, "Type is not Player!");
            Contract.Requires(firstPlayer == null);

            if (firstPlayer == null)
            {
                throw new NullReferenceException("First Player is null");
            }

            this.firstPlayer = firstPlayer;
        }


        /// <summary>
        /// Method to get First Player
        /// </summary>
        /// <returns></returns>
        public Player getFirstPlayer()
        {

            Contract.Ensures(firstPlayer != null);

            return firstPlayer;
        }


        /// <summary>
        /// Methode to set a cecond Player in game,it checks - is first player same the second Player
        /// </summary>
        /// <param name="secondPlayer"></param>
        private void setSecondPlayer(Player secondPlayer)
        {
            Contract.Assume(firstPlayer is Player, "Type must Player be!");
            Contract.Requires(!secondPlayer.Equals(firstPlayer));
            Contract.Requires(secondPlayer != null);
            this.secondPlayer = secondPlayer;

            if (secondPlayer == null)
            {
                throw new NullReferenceException("Second Player is null");
            }

            if (firstPlayer.Equals(secondPlayer))
            {
                throw new Exception("Second Player is same First Player");
            }
        }


        /// <summary>
        /// Method to get Second Player
        /// </summary>
        /// <returns></returns>
        public Player getSecondPlayer()
        {

            Contract.Ensures(secondPlayer != null);

            return secondPlayer;
        }


        /// <summary>
        /// Method to set name of the dragon
        /// </summary>
        private void setName()
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            this.name = "Dragon" + getID();
        }


        /// <summary>
        /// Method to get the name of the Dragon
        /// </summary>
        /// <returns></returns>
        public String getName()
        {

            Contract.Ensures(name != null && name.Length > 3);
            if (name == null || name.Length < 3)
            {
                throw new NullReferenceException("There is no name existing or the name length is smaller than 3!");
            }
            return this.name;
        }


        /// <summary>
        /// Method to set X-Coordinate
        /// </summary>
        /// <param name="x"></param>
        private void setXCoordinate(int x)
        {
            Contract.Requires(x >= 0);
            Contract.Ensures(x >= 0);
            this.xCoordinate = x;
        }


        /// <summary>
        /// Method to get X-Coordinate
        /// </summary>
        /// <returns></returns>
        public int getXCoordinate()
        {
            Contract.Ensures(xCoordinate >= 0);

            return xCoordinate;
        }


        /// <summary>
        /// Method to set Y-Coordinate
        /// </summary>
        /// <param name="y"></param>
        private void setYCoordinate(int y)
        {
            Contract.Requires(y >= 0);
            Contract.Ensures(y >= 0);

            this.yCoordinate = y;
        }


        /// <summary>
        /// Method to get Y-Coordinate
        /// </summary>
        /// <returns></returns>
        public int getYCoordinate()
        {
            Contract.Ensures(yCoordinate >= 0);

            return yCoordinate;
        }


        /// <summary>
        /// Method starts the stagHunt game with two Players
        /// </summary>
        /// <param name="firstPlayer"></param>
        /// <param name="secondPlayer"></param>
        public void dragonFight(Player firstPlayer, Player secondPlayer)
        {

            Contract.Requires(firstPlayer != null && secondPlayer == null);
            Contract.Requires((getFirstPlayer().getXCoordinate() == this.getXCoordinate()) && (getFirstPlayer().getYCoordinate() == this.getYCoordinate()));
            Contract.Requires((getSecondPlayer().getXCoordinate() == this.getXCoordinate()) && (getSecondPlayer().getYCoordinate() == this.getYCoordinate()));
            Contract.Requires(firstPlayer.isBusy() && secondPlayer.isBusy());

            if (player1 == null || player2 == null)
            {
                throw new NullReferenceException("First Player or Second Player is null!");
            }
            else
            {
                try
                {
                    if ((!((getFirstPlayer().isBusy())) && (!(getSecondPlayer().isBusy()))) && ((getFirstPlayer().getXCoordinate() == this.getXCoordinate()) && (getSecondPlayer().getYCoordinate() == this.getYCoordinate())))
                    {
                        setPlayer1(player1);
                        setPlayer2(player2);

                        if (this.sH.isSelected())
                        {
                            startDragonFight();
                        }
                    }
                    else
                    {
                        throw new PlayerIsBusyException("One of the both players is busy!");
                    }
                }
                catch (PlayerIsBusyException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }

            Contract.Ensures(firstPlayer.isBusy() && secondPlayer.isBusy());
            Contract.Ensures((getFirstPlayer().getXCoordinate() == this.getXCoordinate()) && (getFirstPlayer().getYCoordinate() == this.getYCoordinate()));
            Contract.Ensures((getSecondPlayer().getXCoordinate() == this.getXCoordinate()) && (getSecondPlayer().getYCoordinate() == this.getYCoordinate()));



            setFirstPlayer(firstPlayer);
            setSecondPlayer(secondPlayer);
        }

        private void startDragonFight()
        {

        }
    }
}
