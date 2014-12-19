using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Manager
{
    public class Player : Entity
    {
        public event EventHandler<EventArgs> playerGenerated;
        public event EventHandler<EventArgs> playerDecision;
        public event EventHandler<EventArgs> playerPoints;
        public event EventHandler<EventArgs> playerDelete;

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
        ///  players.Add(new Player(id, busy, desc, x, y, points));
        public Player(int id, bool busy,String name, int row, int column, int points)
            : base(id, name, busy, row, column)
        {

            if (playerGenerated != null)
            {   
                playerGenerated(this, new EventArgs());
                setPoints(points);
                setDecision(Decision.UNDEFINED);
                setPlayer(this);
                
            }
        }


        public Player() : base()
        {
            if (playerGenerated != null)
            {
                setPoints(points);
                setDecision(Decision.UNDEFINED);
                setPlayer(this);
                playerGenerated(this, new EventArgs());
            }
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
                if (playerDecision != null)
                {
                    this.decision = decision;
                    playerDecision(this, new EventArgs());
                }
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
        public void setPoints(int points)
        {
            if (playerPoints != null)
            {
                this.points = points;
                playerPoints(this, new EventArgs());
                Console.WriteLine("Im in Points!!!!!!!!!!!");
            }
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

        //int id, String type, bool busy, String name, int x, int y, int points
        public void updatePlayer(int id, String type, bool busy, String name, int x, int y)
        {
            update(id, name, busy, x, y);
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
        public Player getPlayer()
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
                if (playerDelete != null)
                {
                    setPlayer(null);
                    playerDelete(this, new EventArgs());
                }
            }
        }
    }
}
