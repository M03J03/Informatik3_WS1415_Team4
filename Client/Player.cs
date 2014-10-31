using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using DragonsAndRabbits.Exceptions;

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

        /// <summary>
        /// Generates an object of Player
        /// </summary>
        public Player()
        {
            setID(++playerNumber);
            setName(name);
        }

        /// <summary>
        /// This method sets the id of the Player
        /// </summary>
        /// <param name="id"></param>
        private void setID(int id)
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            this.id = id;
        }

        /// <summary>
        /// This method gets the number of the Player
        /// </summary>
        /// <returns>id</returns>
        public int getId()
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);
            return id;
        }

        /// <summary>
        /// This method sets the name of the Player
        /// </summary>
        /// <param name="name"></param>
        private void setName(String name)
        {
            Contract.Requires(name != null);
            Contract.Requires(name.Length > 0);
            if (name == null)
                throw new NullReferenceException("The field <Name> must not be empty!");
            Contract.Ensures(name != null && name.Length > 0);
            this.name = name;
        }

        /// <summary>
        /// This Method get the name of the Player
        /// </summary>
        /// <returns>name of the Player</returns>
        public String getName()
        {
            return name;
        }

        /// <summary>
        /// This Method set the Score
        /// </summary>
        /// <param name="score"></param>
        private void setScore(int score)
        {
            this.score = score;
        }

        /// <summary>
        /// This Method get the actual Score
        /// </summary>
        /// <returns>the actual Score</returns>
        public int getScore()
        {
            return score;
        }

        /// <summary>
        /// This Method set the x-Coordinate
        /// </summary>
        /// <param name="i"></param>
        private void setXCoordinate(int i)
        {
            Contract.Requires(i >= 0);
            Contract.Ensures(i >= 0);
            this.xCoordinate = i;
        }

        /// <summary>
        /// This Method get the x-Coordinate
        /// </summary>
        /// <returns>xCoordinate</returns>
        public int getXCoordinate()
        {
            Contract.Ensures(xCoordinate >= 0);
            return xCoordinate;
        }

        /// <summary>
        /// This Method set the y-Coordinate
        /// </summary>
        /// <param name="i"></param>
        private void setYCoordinate(int i)
        {
            Contract.Requires(i >= 0);
            Contract.Ensures(i >= 0);
            this.yCoordinate = i;
        }

        /// <summary>
        /// This Method get the y-Coordinate
        /// </summary>
        /// <returns>y-Coordinate</returns>
        public int getYCoordinate()
        {
            Contract.Ensures(xCoordinate >= 0);
            return xCoordinate;
        }

        /// <summary>
        /// Method to set actual status of the Player
        /// </summary>
        private void setBusy(Boolean busy)
        {
            this.busy = busy;
        }

        /// <summary>
        /// Method to get actual status of the Player
        /// </summary>
        /// <returns>Is the Player busy or not busy</returns>
        public Boolean isBusy()
        {
            return busy;
        }

        /// <summary>
        /// This method starts the fight
        /// </summary>
        public void figth()
        {

        }

        public void rest()
        {

        }

        /// <summary>
        /// this method to update attribyte of the object Player
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bysu"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="xCoordinate"></param>
        /// <returns></returns>
        public Boolean update(int id, Boolean bysu, int yCoordinate, int xCoordinate)
        {
            if (this.id == id)
            {
                this.setBusy(busy);
                this.setYCoordinate(yCoordinate);
                this.setXCoordinate(xCoordinate);
                return true;
            }
            return false;
        }

        /// <summary>
        /// this method distributes the revieved information
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        public void deleteInfo(Dragon d, Player p)
        {

        }

        /// <summary>
        /// This method starts the skirMishGame. The method neds two player objects
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public void skirMish(Player player1, Player player2)
        {

        }

        private void startSkirmish()
        {

        }
    }
}