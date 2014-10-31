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
        private Boolean busy = false;
        private Player player1, player2;
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
        /// Method to set actual status of the Dragon
        /// </summary>
        private void setBusy(Boolean busy)
        {
            this.busy = busy;
        }

        /// <summary>
        /// Method to get actual status of the Dragon
        /// </summary>
        /// <returns></returns>
        public Boolean isBusy()
        {
            return this.busy;
        }

        /// <summary>
        /// Method sets a first Player
        /// </summary>
        /// <param name="firstPlayer"></param>
        private void setPlayer1(Player player1)
        {
            Contract.Assume(player1 is Player, "Type is not Player!");
            Contract.Requires(player1 == null);

            if (player1 == null)
            {
                throw new NullReferenceException("First Player is null");
            }

            this.player1 = player1;
        }


        /// <summary>
        /// Method to get First Player
        /// </summary>
        /// <returns></returns>
        public Player getPlayer1()
        {

            Contract.Ensures(player1 != null);

            return player1;
        }


        /// <summary>
        /// Methode to set a cecond Player in game,it checks - is first player same the second Player
        /// </summary>
        /// <param name="secondPlayer"></param>
        private void setPlayer2(Player player2)
        {
            Contract.Assume(player2 is Player, "Type must Player be!");
            Contract.Requires(!player2.Equals(player1));
            Contract.Requires(player2 != null);
            this.player2 = player2;

            if (player2 == null)
            {
                throw new NullReferenceException("Second Player is null");
            }

            if (player2.Equals(player2))
            {
                throw new Exception("Second Player is same First Player");
            }
        }


        /// <summary>
        /// Method to get Second Player
        /// </summary>
        /// <returns></returns>
        public Player getPlayer2()
        {

            Contract.Ensures(player2 != null);

            return player2;
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
        /// This Methos to update attribute of the Object Dragon
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busy"></param>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <returns></returns>
        public Boolean update(int id, Boolean busy, int xCoordinate, int yCoordinate)
        {
            if (this.id == id)
            {
                this.setBusy(busy);
                this.setXCoordinate(xCoordinate);
                this.setYCoordinate(yCoordinate);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method starts the dragonFight game with two Players
        /// </summary>
        /// <param name="firstPlayer"></param>
        /// <param name="secondPlayer"></param>
        public void dragonFight(Player player1, Player player2)
        {

            Contract.Requires(player1 != null && player2 == null);
            Contract.Requires((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer1().getYCoordinate() == this.getYCoordinate()));
            Contract.Requires((getPlayer2().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate()));
            Contract.Requires(player1.isBusy() && player2.isBusy());

            if (player1 == null || player2 == null)
            {
                throw new NullReferenceException("First Player or Second Player is null!");
            }
            else
            {
                try
                {
                    if ((!((getPlayer1().isBusy())) && (!(getPlayer2().isBusy()))) && ((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate())))
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

            Contract.Ensures(player1.isBusy() && player2.isBusy());
            Contract.Ensures((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer1().getYCoordinate() == this.getYCoordinate()));
            Contract.Ensures((getPlayer2().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate()));



            setPlayer1(player1);
            setPlayer2(player2);
        }

        private void startDragonFight()
        {

        }
    }
}
