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
        private int x, y;
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

        //This Method get the X-Coordinate
        private void setX(int x)
        {
            Contract.Requires(x >= 0);
            Contract.Ensures(x >= 0);
            this.x = x;
        }

        //This Method get the X-Coordinate
        public int getX()
        {
            Contract.Ensures(x >= 0);
            return x;
        }

        //This Method set the Y-Coordinate
        private void setY(int y)
        {
            Contract.Requires(y >= 0);
            Contract.Ensures(y >= 0);
            this.y = y;
        }

        //This Method get the Y-Coordinate
        public int getY()
        {
            Contract.Ensures(y >= 0);
            return y;
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
