using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonsAndRabbits.Client;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Manager
{
    public class Manager
    {
        private static Manager manager;
        private GUI.GUI gui;
        private Entity enity;
        private MapCell mapCell;
        private List<MapCell> mapCells;
        private List<Dragon> dragons = new List<Dragon>();

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

        /// <summary>
        /// This method updates an existing dragon or creates a new one.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busy"></param>
        /// <param name="description"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void dragon(int id, bool busy, String description, int x, int y)
        {
            bool exists = false;
            foreach (Dragon d in dragons)
            {
                if (d.getID() == id)
                {
                    exists = true;
                    d.update(id, description, busy, x, y);
                }
            }

            if (!exists)
            {
                Dragon drag = new Dragon(id, description, busy, x, y);
                dragons.Add(drag);
                
            }                  
        }

        /**********************************************GUI-Server-Communication*************************************************************/

        /// <summary>
        /// this method sends a chatmessage towards the server
        /// </summary>
        /// <param name="chatMessage"></param>
        /// <returns></returns>
        public String sendChatUpdateToServer(String chatMessage)
        {
            if (chatMessage.Length == 0 || chatMessage == null)
            {
                throw new NoMessageException("No valid chatmessage in Manager!");
            }

            //send to parser (void method) - not yet implemented....
            return chatMessage;
        }

        //internal


        
    }
}