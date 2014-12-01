using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonsAndRabbits.Client;
using DragonsAndRabbits.Manager;
using System.Diagnostics.Contracts;
using DragonsAndRabbits.Exceptions;
//using DragonsAndRabbits.Client;

namespace DragonsAndRabbits.Client
{
    public class Controler
    {

        //private GUI gui = null;
        private Map map;
        private Manager.Player player = null;
        private string message;

        /// <summary>
        /// Default-constructor
        /// </summary>
        public Controler()
        {
            
        }
        
        /// <summary>
        /// Creating an object with the commited parameter.
        /// </summary>
        /// <param name="gui"></param>
        public Controler(/*GUI gui*/ Map map)
        {
            //setGUI(gui);
            setMap(map);            
        }
        
        /*
        /// <summary>
        /// Sets the gui,
        /// </summary>
        /// <param name="gui"></param>
        private void setGUI(GUI gui)
        {
            if (gui == null)
            {
                throw new NullReferenceException("There is no GUI!");
            }
            else
            {
                this.gui = gui;
            }
        }
         * */
        /*
        /// <summary>
        /// gets the Client gui Object.
        /// </summary>
        /// <returns></returns>
        public GUI getGUI()
        {
            return gui;
        }
         * */

        /// <summary>
        /// sets the map.
        /// </summary>
        /// <param name="map">the required parameter</param>
        private void setMap(Map map)
        {
            if (map == null)
            {
                throw new NullReferenceException("There is no Map");
            }
            else
            {
                this.map = map;
            }
        }

        /// <summary>
        /// returns the map
        /// </summary>
        /// <returns>the map objects</returns>
        private Map getMap()
        {
            return map;
        }

        /// <summary>
        /// Returns the commited message.
        /// </summary>
        /// <returns>the commited message</returns>
        public string getMessage()
        {
            return message;
        }

        /// <summary>
        /// sets the playder object
        /// </summary>
        /// <param name="player"></param>
        private void setPlayer(Player player)
        {
            if (player == null)
            {
                throw new NullReferenceException("There is no player");
            }
            else
            {
                this.player = player;
            }
        }

        /// <summary>
        /// Returns the player object.
        /// </summary>
        /// <returns></returns>
        public Player getPlayer()
        {
            return player;
        }

        /// <summary>
        /// This method move the Player one step left
        /// </summary>
        public void moveLeft()
        {
            try
            {
                if (getPlayer() != null)
                {
                    //I need a method like this. This method should go with the player one step left.
                    //getMap().moveLeft();
                }
                else
                {
                    throw new NoPlayerException("There is no player!");
                }
            }
            catch (NoPlayerException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Contract.Ensures(player != null);
        }

        /// <summary>
        /// This method move the Player one step rigth
        /// </summary>
        public void moveRigth()
        {
            try
            {
                if (getPlayer() != null)
                {
                    //I need a method like this. Thismethod should go withthe player one step rigth.
                    //getMap().moveRigth();
                }
                else
                {
                    throw new NoPlayerException("There is no player!");
                }
            }
            catch (NoPlayerException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Contract.Ensures(player != null);
        }

        /// <summary>
        /// This method move the player one step up.
        /// </summary>
        public void moveUp()
        {
            try
            {
                if (getPlayer() != null)
                {
                    //I need a method like this. This method should go with the player one step up.
                    //getMap().moveUp();
                }
                else
                {
                    throw new NoPlayerException("There is no player!");
                }
            }
            catch (NoPlayerException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Contract.Ensures(player != null);
        }

        /// <summary>
        /// this method is responsible to let the player move down
        /// </summary>
        public void moveDown()
        {
            try
            {
                if (getPlayer() != null)
                {
                    //I need a method like this. This method should go with the player one step down.
                    //getMap().moveDown();
                }
                else
                {
                    throw new NoPlayerException("There is no player!");
                }
            }
            catch (NoPlayerException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Contract.Ensures(player != null);
        }

        /// <summary>
        /// this method let attack a player
        /// </summary>
        public void attack()
        {
            try
            {
                if (getPlayer() != null)
                {
                    //I need a method like this. This method should the player attack.
                    //getMap().attack();
                }
                else
                {
                    throw new NoPlayerException("There is no player!");
                }
            }
            catch (NoPlayerException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Contract.Ensures(player != null);
        }

        /// <summary>
        ///  This Method sends the written message in the chat box to the server.
        /// </summary>
        /// <param name="message"></param>
        public void sendMessage(string message)
        {
            Contract.Requires(message.Length > 0);

            try
            {
                if (message != null && message.Length > 0)
                {
                    this.message = message;
                    //do something
                }
                else
                {
                    throw new NoMessageException("There is no Message!");
                }
            }
            catch (NoMessageException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            Contract.Ensures(message.Length > 0);
        }

        /// <summary>
        /// this method gets the written messages from other player to show the on the chatbox. This methos is running in a Thread. The method is also connected to the Manager
        /// </summary>
        /// <param name="p"></param>
        public void revieveMessage(int sourceID, String source, String text)
        {
            //Manager m = Manager.getManager();

            //i need the specification for the gui. i dont know which components exists and whats the name of them
        }
    }
}
