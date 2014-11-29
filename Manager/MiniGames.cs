using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Manager
{
    class MiniGames
    {
        /// <summary>
        /// Generates a mini games object.
        /// </summary>
        protected MiniGames()
        {

        }

        /// <summary>
        /// This method starts the stagHuntGame
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        protected void stagHunt(Player p1, Player p2)
        {
            if (!(p1.Equals(p2)))
            {
                if (!(p1.isBusy()) && !(p2.isBusy()))
                {
                    startStagHunt(p1, p2);
                }
                else 
                {
                    throw new PlayerIsBusyException("One of the both player is busy!");
                }
            }
        }

           
        /// <summary>
        /// This method contains the gui for the stagHunt.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void startStagHunt(Player p1, Player p2)
        { 
            //Here we need a new GUI for the staghunt. Fabian do your thing
        }

        /// <summary>
        /// This method starts the dragonFigth game
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        protected void dragonFigth(Player p1, Player p2)
        {
            if (!(p1.Equals(p2)))
            {
                if (!(p1.isBusy()) && !(p2.isBusy()))
                {
                    startDragonFigth(p1, p2);
                }
                else
                {
                    throw new PlayerIsBusyException("One of the both player is busy!");
                }
            }
        }

        /// <summary>
        /// Method contains the GUI for the dragonFigth
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void startDragonFigth(Player p1, Player p2)
        {
            //Here we need a new GUI for the staghunt. Fabian do your thing
        }

        /// <summary>
        /// This method starts the skirmish game
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        protected void skirmish(Player p1, Player p2)
        {
            if (!(p1.Equals(p2)))
            {
                if (!(p1.isBusy()) && !(p2.isBusy()))
                {
                    startSkirmish(p1, p2);
                }
                else
                {
                    throw new PlayerIsBusyException("One of the both player is busy!");
                }
            }
        }

        /// <summary>
        /// Method contains the GUI for the skirmish
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        private void startSkirmish(Player p1, Player p2)
        {
            //Here we need a new GUI for the skirmish. Fabian do your thing
        }
    }
}
