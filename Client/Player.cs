using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace DragonsAndRabbits.Client
{
     public class Player
    {
        private int id;
        private String name;
        private int score;
        private Boolean busy = false;
        private int xCoordinate;
        private int yCoordinate;
        private static int playerNumber = 0;

        //Generates an object of Player.
        public Player()
        {
            setID(++playerNumber);
            setName(name);
        }

        //This method sets the id of the Player.
        private void setID(int id)
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            this.id = id;
        }

        //This method gets the number of the Player.
        public int getId()
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            return id;
        }

        //This method sets the name of the Player.
        private void setName(String name)
        {
            Contract.Requires(name != null);
            Contract.Requires(name.Length > 0);
            Contract.Ensures(name != null && name.Length > 0);
            this.name = name;
        }

        //This Method get the name of the Player
        public String getName()
        {
            return name;
        }

        private void setScore(int score)
        {
            Contract.Ensures(score >= 0);
            this.score = score;
        }

        public int getScore()
        {
            return score;
        }

        //Sets the xCoordinate
        private void setXCoordinate(int i)
        {
            Contract.Requires(i >= 0);
            Contract.Ensures(i >= 0);
            this.xCoordinate = i;
        }

        //Get the xCoordinate
        public int getXCoordinate()
        {
            Contract.Ensures(xCoordinate >= 0);
            return xCoordinate;
        }

        //Sets the xCoordinate
        private void setYCoordinate(int i)
        {
            Contract.Requires(i >= 0);
            Contract.Ensures(i >= 0);
            this.yCoordinate = i;
        }

        //Gets the y-Coordinate
        public int getYCoordinate()
        {
            Contract.Ensures(xCoordinate >= 0);
            return xCoordinate;
        }

        //Method to set actual status of the Player.
        private void setBusy()
        {
            this.busy = true;
        }

        //Method to get actual status of the Player.
        public Boolean isBusy()
        {
            return busy;
        }

        //This method starts the fight.
        public void figth()
        {

        }

        public void rest()
        {

        }



    }
}
