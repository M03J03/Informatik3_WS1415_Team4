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
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            this.id = id;                        
        }

        //This method gets the actual number of the rabbit.
        public int getID() {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            return id;
        }

        //This method sets the name of the rabbit. The name consists of the name Rabbit and the actual instance number of the rabit
        private void setName() {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            string n = "Rabbit" + getID();
            this.name = n;
        }

        //This Method get the name of the rabbit
        public string getName() {
            Contract.Requires(name != null);
            Contract.Requires(name.Length > 0);
            Contract.Ensures(name != null && name.Length > 0);
            return name;
        }

        //This method set the palyer1
        private void setPlayer1(Player player) {
            Contract.Requires(player != null);
            Contract.Ensures(this.player1.Equals(player));
            
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
            Contract.Requires(player1 != null);
            Contract.Ensures(player1 != null); // <-- What if player 1 is not set? In this case player1 is null! 
            return player1;
        }

        //Set the player2
        private void setPlayer2(Player player) {
            Contract.Requires(player != null);
            Contract.Ensures(this.player2.Equals(player));

            if (player == null)
            {
                throw new Exception("No Player!");
            }
            else
            {
                this.player2 = player;
            }
        }

        //Get the player2
        public Player getPlayer2() {
            Contract.Requires(player2 != null);
            Contract.Ensures(player2 != null);  //<-- What if player 2 is not set? In this case player2 is null! 
            return player2;
        }

        //Sets the xCoordinate
        private void setXCoordinate(int i) {
            Contract.Requires(i >= 0);
            Contract.Ensures(i >= 0);
            this.xCoordinate = i;
        }

        //Get the xCoordinate
        public int getXCoordinate() {
            Contract.Ensures(xCoordinate >= 0);
            return xCoordinate;
        }

        //Sets the xCoordinate
        private void setYCoordinate(int i) {
            Contract.Requires(i >= 0);
            Contract.Ensures(i >= 0);
            this.yCoordinate = i;
        }

        //Gets the y-Coordinate
        public int getYCoordinate() {
            Contract.Ensures(xCoordinate >= 0);
            return xCoordinate;
        }


        //This method starts the stagHuntGame. The method neds
        public void stagHunt(Player player1, Player player2) {
            Contract.Requires(player1 != null && player2 != null);
           // Contract.Requires((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer1().getYCoordinate() == this.getYCoordinate()));
           // Contract.Requires((getPlayer2().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate()));
           // Contract.Requires(player1.isBusy() == true && player2,isBusy() == true);
           // Contract.Ensures(player1.isBusy() == true && player2, isBusy() == true);
           // Contract.Ensures((getPlayer1().getXCoordinate() == this.getXCoordinate()) && (getPlayer1().getYCoordinate() == this.getYCoordinate()));
           // Contract.Ensures((getPlayer2().getXCoordinate() == this.getXCoordinate()) && (getPlayer2().getYCoordinate() == this.getYCoordinate()));
            setPlayer1(player1);
            setPlayer2(player2);
        }
    }
}
