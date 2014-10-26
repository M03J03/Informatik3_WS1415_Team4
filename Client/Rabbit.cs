using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace DragonsAndRabbits.Client {
    public class Rabbit {
        private static int rabbitNumber = 0;
        private int id;
        private string name;      
        private Player player1;
        private Player player2;
        private int xCoordinate;
        private int yCoordinate;

        //Generates an object of rabit. Id counts ++ for each instance. The Name ob the Rabit is also set by the name Rabbit and the actuel istance number of the object.
        public Rabbit() {
            setID(++rabbitNumber);
            setName();
        }

        //This method sets the id of the rabbit.
        private void setID(int id) {
            if (id <= 0)
            {
                throw new Exception("Please insert a number larger than 0!");
            }
            else
            {
                this.id = id;
            }                                            
        }

        //This method gets the actual number of the rabbit.
        public int getID() 
        {
            return id;
        }

        //This method sets the name of the rabbit. The name consists of the name Rabbit and the actual instance number of the rabit
        private void setName() 
        {            
            string n = "Rabbit" + getID();
            this.name = n;
        }

        //This Method get the name of the rabbit
        public string getName() {
            if (name == null || name.Length < 1)
            {
                throw new Exception("There is no name existing or the name length is smaller than 1!");
            }

            return name;            
        }

        //This method set the palyer1
        private void setPlayer1(Player player) {                        
            if (player == null)
            {
                throw new Exception("No Player!");
            }
            else
            {
                this.player1 = player;
            }
        }

        //This method gets the Player1.
        public Player getPlayer1() {
            if (this.player1 == null)
            {
                throw new Exception("Player 1 is null");
            }
            else
            {
                return player1;
            }            
        }

        //Set the player2
        private void setPlayer2(Player player) {            
            if (player == null)
            {
                throw new Exception("Player 2 is null!");
            }
            else
            {
                this.player2 = player;
            }
        }

        //Get the player2
        public Player getPlayer2() {
            if (player2 == null)
            {
                throw new Exception("Player 2 is null!");
            }
            else
            {
                return player2;
            }
        }

        //Sets the xCoordinate
        private void setXCoordinate(int i) {
            if (i < 0)
            {
                throw new Exception("The number of i is smaller than 0!");
            }
            else
            {
                this.xCoordinate = i;
            }                        
        }

        //Get the xCoordinate
        public int getXCoordinate() {            
            return xCoordinate;
        }

        //Sets the xCoordinate
        private void setYCoordinate(int i) {
            if (i < 0)
            {
                throw new Exception("The number of i is smaller than 0!");
            }
            else
            {
                this.yCoordinate = i;
            } 
        }

        //Gets the y-Coordinate
        public int getYCoordinate() {            
            return xCoordinate;
        }


        //This method starts the stagHuntGame. The method neds
        public void stagHunt(Player player1, Player player2) {
            if (player1 == null || player2 == null)
            {
                throw new Exception("Player 1 or 2 is null!");
            }
            else
            {
                if (!(getPlayer1().isBusy()) && (!(getPlayer2().isBusy())))
                {
                    //bin zu müde zum coden ich mach den scheiß morgen
                }
                
                setPlayer1(player1);
                setPlayer2(player2);
            }

            Contract.Requires(player1 != null && player2 != null);
            Contract.Requires((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer1().getYCoordinate() == this.getYCoordinate()));
            Contract.Requires((getPlayer2().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate()));
            Contract.Requires(player1.isBusy() && player2.isBusy());
            Contract.Ensures(player1.isBusy() && player2.isBusy());
            Contract.Ensures((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer1().getYCoordinate() == this.getYCoordinate()));
            Contract.Ensures((getPlayer2().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate()));
            setPlayer1(player1);
            setPlayer2(player2);           
        }
    }
}
