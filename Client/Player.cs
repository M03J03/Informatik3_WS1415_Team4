using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Client
{
    public class Player:Piece
    {

        private int score;


        /// <summary>
        /// Generates an object of Player
        /// </summary>
        public Player(int id,String name,int xCoordinate,int yCoordinate):base(id,name,xCoordinate,yCoordinate)
        {

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
        /// This method starts the fight
        /// </summary>
        public void figth()
        {

        }

        public void rest()
        {

        }

        /// <summary>
        /// this method to update Score of the object Player
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bysu"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="xCoordinate"></param>
        /// <returns></returns>
        public void update(int id, int score)
        {
            if (getID() == id)
            {
                this.setScore(score);

            }
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