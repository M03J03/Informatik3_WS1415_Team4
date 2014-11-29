using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Manager
{
    class Player : Entity
    {
        private int points = 0;
        private Decision decision;
        private Player player;

        /// <summary>
        /// generates a player object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="busy"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        protected Player(int id, String name, bool busy, int row, int column)
            : base(id, name, busy, row, column)
        { 
            setPoints(0);
            setDecision(Decision.UNDEFINED);
            setPlayer(this);
        }

        /// <summary>
        /// Sets the decision.
        /// </summary>
        /// <param name="decision"></param>
        private void setDecision(Decision decision)
        {
            if (decision == null)
            {
                throw new NullReferenceException("There is no decision!");
            }
            else
            {
                this.decision = decision;
            }
        }

        /// <summary>
        /// Return ths decision of the player.
        /// </summary>
        /// <returns></returns>
        protected Decision getDecision()
        {
            return decision;
        }

        /// <summary>
        /// Sets the points
        /// </summary>
        /// <param name="points"></param>
        private void setPoints(int points)
        {
            this.points = points;
        }

        /// <summary>
        /// returns the points.
        /// </summary>
        /// <returns></returns>
        protected int getPoints()
        {
            return points;
        }

        /// <summary>
        /// This method update the points ofthe player.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="points"></param>
        public void updatePoints(int id, int points)
        {
            int tmpPoints = getPoints();

            if (getID() == id)
            {
                if (points >= 0)
                {
                    tmpPoints += points;
                    setPoints(tmpPoints);
                }
                else 
                {
                    tmpPoints -= points;
                    setPoints(tmpPoints);
                }
            }
        }

        /// <summary>
        /// Sets the player
        /// </summary>
        /// <param name="palyer"></param>
        private void setPlayer(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Returns the player
        /// </summary>
        /// <returns></returns>
        protected Player getPlayer()
        {
            return player;
        }

        /// <summary>
        /// Deletesthe player object.
        /// </summary>
        /// <param name="player"></param>
        public void deletePlayer(Player player)
        {
            if (player == null)
            {
                throw new NullReferenceException("There are no player!");
            }
            else
            {
                setPlayer(null);
            }
        }
    }
}
