using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Client
{
    class DragonFight
    {
        private int dragonFightNummer;
        private Player player1 = null;
        private Player player2 = null;
        private Dragon dragon = null;

        public DragonFight(Player player1, Player player2, Dragon dragon)
        {
            setPlayer1(player1);
            setPlayer2(player2);
            setDragon(dragon);

        }

        /// <summary>
        /// Method sets a first Player
        /// </summary>
        /// <param name="firstPlayer"></param>
        protected void setPlayer1(Player player1)
        {
            Contract.Assume(player1 is Player, "Type is not Player!");
            Contract.Requires(player1 != null);

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
        protected void setPlayer2(Player player2)
        {
            Contract.Assume(player2 is Player, "Type must Player be!");
            Contract.Requires(!player2.Equals(player1));
            Contract.Requires(player2 != null);


            if (player2 == null)
            {
                throw new NullReferenceException("Second Player is null");
            }

            if (player2.Equals(player2))
            {
                throw new Exception("Second Player is same First Player");
            }

            this.player2 = player2;
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
        /// Method sets a Dragon
        /// </summary>
        /// <param name="dragon"></param>
        protected void setDragon(Dragon dragon)
        {
            Contract.Assume(dragon is Dragon, "Type is not Dragon!");
            Contract.Requires(dragon != null);

            if (dragon == null)
            {
                throw new NullReferenceException("Dragon is null");
            }

            this.dragon = dragon;
        }

        /// <summary>
        /// Method to get Dragon
        /// </summary>
        /// <returns></returns>
        public Dragon getDragon()
        {

            Contract.Ensures(dragon != null);

            return dragon;
        }

        /// <summary>
        ///This Method starts DragonFight with two Player and one Dragon
        /// </summary>
        private void startDragonFight()
        {

            Contract.Requires((getPlayer1().getXCoordinate() == getDragon().getXCoordinate()) && (getPlayer1().getYCoordinate() == getDragon().getYCoordinate()));
            Contract.Requires((getPlayer2().getXCoordinate() == getDragon().getXCoordinate()) && (getPlayer2().getYCoordinate() == getDragon().getYCoordinate()));
            Contract.Requires(player1.isBusy() && player2.isBusy());



            Contract.Ensures(player1.isBusy() && player2.isBusy());
            Contract.Ensures((getPlayer1().getXCoordinate() == getDragon().getXCoordinate()) && (getPlayer1().getYCoordinate() == getDragon().getYCoordinate()));
            Contract.Ensures((getPlayer2().getXCoordinate() == getDragon().getXCoordinate()) && (getPlayer2().getYCoordinate() == getDragon().getYCoordinate()));



        }

    }
}
