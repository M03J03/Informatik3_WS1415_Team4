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
        internal List<Dragon> dragons = new List<Dragon>();
        internal List<Player> players;
        private int width;
        private int height;
        private int id;
        private long time;
        private bool online;
        private int server;

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

        /// <summary>
        /// This method updates the player.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busy"></param>
        /// <param name="description"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="points"></param>
        public void player(int id, bool busy, String description, int x, int y, int points)
        {
            bool exists = false;

            foreach (Player p in players)
            {
                if (p.getID() == id)
                {
                    exists = true;
                    p.update(id, description, busy, x, y);
                    p.updatePoints(id, points);
                }
            }

            if (!exists)
            {           
                Player player = new Player(id, description,busy,  x, y);
                players.Add(player);
            }
        }

        /// <summary>
        /// This method is for the challange.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeOfFigth"></param>
        /// <param name="accepted"></param>
        public void challenge(int id, String typeOfFigth, bool accepted)
        {

        }

        /// <summary>
        /// Thsi method genrates and returns the new MapCell
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="status"></param>
        public MapCell mapCell(int x, int y, List<String> status)
        {
            MapCell mp = new MapCell(x, y, status);
            return mp;
        }

        /// <summary>
        /// This method sets the width, height and the list of the mapcells
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mapCell"></param>
        public void map(int width, int height, List<MapCell> mapCell)
        {
            setWidth(width);
            setHeight(height);
            setMapCell(mapCell);
        }

        /// <summary>
        /// Sets the width of the map.
        /// </summary>
        /// <param name="width"></param>
        private void setWidth(int width)
        {
            this.width = width;
        }

        /// <summary>
        /// Sets the heigth of the map.
        /// </summary>
        /// <param name="height"></param>
        private void setHeight(int height)
        {
            this.height = height;
        }

        /// <summary>
        /// Sets the list of mapcells of the map.
        /// </summary>
        /// <param name="mapCells"></param>
        private void setMapCell(List<MapCell> mapCells)
        {
            this.mapCells = mapCells;
        }

        /**********************************************providing information to GUI*********************************************************/
        public List<MapCell> getMapCells(){
            return mapCells;
        }
     
        internal List<Player> getPlayers(){
            return this.players;
        }

        internal List<Dragon> getDragons()
        {
            return this.dragons;
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



        /// <summary>
        /// this method recieves the changed direction of the player and sends it towards the server
        /// </summary>
        /// <param name="direction"></param>
        public void movePlayer(Direction direction)
        {
            //send movement towards the server
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the heigth of the map.
        /// </summary>
        /// <returns></returns>
        public int getHeight()
        {
            return height;
        }

        /// <summary>
        /// Returns the width of the map
        /// </summary>
        /// <returns></returns>
        public int getWidth()
        {
            return width;
        }

        /// <summary>
        /// Still no idea what to do
        /// </summary>
        /// <param name="dragonOrPlayer"></param>
        /// <param name="mapCell"></param>
        public void update(String dragonOrPlayer, MapCell mapCell)
        {
            
        }

        /// <summary>
        /// Deletes the dragon or the player objects wich commited id is the same
        /// </summary>
        /// <param name="dragonOrPlayer"></param>
        /// <param name="id"></param>
        public void delete(String dragonOrPlayer, int id)
        {
            if (dragonOrPlayer.Equals("Player"))
            {
                foreach (Player p in players)
                {
                    if (p.getID() == id)
                    {
                        players.Remove(p);
                    }
                }
            }
            else
            {
                foreach (Dragon d in dragons)
                {
                    if (d.getID() == id)
                    {
                        dragons.Remove(d);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the id of the player
        /// </summary>
        /// <param name="id"></param>
        public void yourID(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Setsthe time of the server
        /// </summary>
        /// <param name="time"></param>
        public void setTime(long time)
        {
            this.time = time;
        }

        /// <summary>
        /// Sets if the client is online or not
        /// </summary>
        /// <param name="id"></param>
        public void isOnline(int id)
        {
            if (id == 0)
            {
                online = false;
            }
            else if (id == 1)
            {
                online = true;
            }
        }

        /// <summary>
        /// returns the id of the client
        /// </summary>
        /// <returns></returns>
        public int getYourID()
        {
            return id;
        }

        /// <summary>
        /// Return the time
        /// </summary>
        /// <returns></returns>
        public long getTime()
        {
            return time;
        }

        /// <summary>
        /// Returns weather the client is online or not
        /// </summary>
        /// <returns></returns>
        public bool idOnline()
        {
            return online;
        }

        /// <summary>
        /// Sets the server number
        /// </summary>
        /// <param name="server"></param>
        public void setServer(int server)
        {
            this.server = server;
        }

        /// <summary>
        /// Gets the server number
        /// </summary>
        /// <returns></returns>
        public int getServer()
        {
            return server;
        }

        /// <summary>
        /// Well....no idea
        /// </summary>
        /// <param name="round"></param>
        /// <param name="running"></param>
        /// <param name="delay"></param>
        /// <param name="opponent"></param>
        public void result(int round, bool running, int delay, String opponent)
        {

        }

        /// <summary>
        /// Sets the player list
        /// </summary>
        /// <param name="p"></param>
        public void setPlayers(List<Player> p)
        {
            this.players = p;
        }
    }
}