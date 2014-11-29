using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonsAndRabbits.Client;

namespace DragonsAndRabbits.Manager
{
    public class Manager
    {
        private static Manager manager;
        private GUI.GUI gui;
        private Entity enity;
        private MapCell mapCell;
        private List<MapCell> mapCells;

        /// <summary>
        /// Generates an manager object.
        /// </summary>
        public Manager()
        {
            setManager(this);
        }

        /// <summary>
        /// Returns the manager instance.
        /// </summary>
        /// <returns></returns>
        public static Manager getManger()
        {
            return manager;
        }

        /// <summary>
        /// Sets the manager instance
        /// </summary>
        /// <param name="manager"></param>
        private void setManager(Manager manager)
        {
            Manager.manager = manager;
        }

        /// <summary>
        /// A method to show if there is an opponent?
        /// </summary>
        /// <param name="id"></param>
        /// <param name="decision"></param>
        /// <param name="points"></param>
        /// <param name="total"></param>
        public void opponent(int id, String decision, int points, int total)
        {
            //Need some time to make an idea what to do.
        }

        public void dragon(int id, bool busy, String description, int x, int y)
        {
            Entity dragon = new Dragon(id, description, busy, x, y);
        }
    }
}