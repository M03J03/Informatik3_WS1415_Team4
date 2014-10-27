using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using DragonsAndRabbits.Exceptions

namespace DragonsAndRabbits.Client {
    public class Rabbit {
        private static int rabbitNumber = 0;
        private int id;
        private string name;      
        private Player player1;
        private Player player2;
        private int xCoordinate;
        private int yCoordinate;
        private Staghunt sH;

        /// <summary>
        /// Generates an object of rabit. Id counts ++ for each instance. The Name ob the Rabit is also set by the name Rabbit and the actuel istance number of the object.
        /// </summary>
        public Rabbit() {
            setID(++rabbitNumber);
            setName();
        }

        /// <summary>
        /// This method sets the id of the rabbit.
        /// </summary>
        /// <param name="id"></param>
        private void setID(int id) {
            if (id <= 0)
            {
                throw new NullReferenceException("Please insert a number larger than 0!");
            }
            else
            {
                this.id = id;
            }                                            
        }

        /// <summary>
        /// This method gets the actual number of the rabbit.
        /// </summary>
        /// <returns></returns>
        public int getID() 
        {
            return id;
        }

        /// <summary>
        /// This method sets the name of the rabbit. The name consists of the name Rabbit and the actual instance number of the rabit
        /// </summary>
        private void setName() 
        {            
            string n = "Rabbit" + getID();
            this.name = n;
        }

        /// <summary>
        /// This Method get the name of the rabbit
        /// </summary>
        /// <returns></returns>
        public string getName() {
            if (name == null || name.Length < 1)
            {
                throw new NullReferenceException("There is no name existing or the name length is smaller than 1!");
            }

            return name;            
        }

        /// <summary>
        /// This method set the palyer1
        /// </summary>
        /// <param name="player"></param>
        private void setPlayer1(Player player) {                        
            if (player == null)
            {
                throw new NullReferenceException("No Player!");
            }
            else
            {
                this.player1 = player;
            }
        }

        /// <summary>
        /// This method gets the Player1.
        /// </summary>
        /// <returns></returns>
        public Player getPlayer1() {
            if (this.player1 == null)
            {
                throw new NullReferenceException("Player 1 is null");
            }
            else
            {
                return player1;
            }            
        }

        /// <summary>
        /// Set the player2
        /// </summary>
        /// <param name="player"></param>
        private void setPlayer2(Player player) {            
            if (player == null)
            {
                throw new NullReferenceException("Player 2 is null!");
            }
            else
            {
                this.player2 = player;
            }
        }

        /// <summary>
        /// Get the player2
        /// </summary>
        /// <returns></returns>
        public Player getPlayer2() {
            if (player2 == null)
            {
                throw new NullReferenceException("Player 2 is null!");
            }
            else
            {
                return player2;
            }
        }

        /// <summary>
        /// Sets the xCoordinate
        /// </summary>
        /// <param name="i"></param>
        private void setXCoordinate(int i) {
            if (i < 0)
            {
                throw new NullReferenceException("The number of i is smaller than 0!");
            }
            else
            {
                this.xCoordinate = i;
            }                        
        }

        /// <summary>
        /// Get the xCoordinate
        /// </summary>
        /// <returns></returns>
        public int getXCoordinate() {            
            return xCoordinate;
        }

        /// <summary>
        /// Sets the xCoordinate
        /// </summary>
        /// <param name="i"></param>
        private void setYCoordinate(int i) {
            if (i < 0)
            {
                throw new NullReferenceException("The number of i is smaller than 0!");
            }
            else
            {
                this.yCoordinate = i;
            } 
        }

        /// <summary>
        /// Gets the y-Coordinate
        /// </summary>
        /// <returns></returns>
        public int getYCoordinate() {            
            return xCoordinate;
        }


        /// <summary>
        /// This method starts the stagHuntGame. The method neds two player objects
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public void stagHunt(Player player1, Player player2) {
            Contract.Requires(player1 != null && player2 != null);
            Contract.Requires((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer1().getYCoordinate() == this.getYCoordinate()));
            Contract.Requires((getPlayer2().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate()));
            Contract.Requires(player1.isBusy() && player2.isBusy());
            Contract.Ensures(player1.isBusy() && player2.isBusy());
        
            if (player1 == null || player2 == null)
            {
                throw new NullReferenceException("Player 1 or 2 is null!");
            }
            else
            {
                try 
                    {
                        if ((!((getPlayer1().isBusy())) && (!(getPlayer2().isBusy()))) && ((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate())))
                        {
                            setPlayer1(player1);
                            setPlayer2(player2);

                            if(this.sH.isSelected()) {
                                startStagHunt();
                            }
                        }
                        else
                        {
                            throw new PlayerIsBusyException("One of the both players is busy!");
                        }
                }
                catch(PlayerIsBusyException ex) 
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
            Contract.Ensures((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer1().getYCoordinate() == this.getYCoordinate()));
            Contract.Ensures((getPlayer2().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate()));                   
        }

        private void startStagHung() 
        {
            //do something
        }
    }
}
