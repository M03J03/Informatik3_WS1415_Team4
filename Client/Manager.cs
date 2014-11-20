using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DragonsAndRabbits.GUI;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Client
{
    class Manager
    {
        private static Manager instance = null;
        private static readonly Object key = new Object();
            //only for test reasons vv
            private Dragon dragon = null;
            private Player player = null;
            private Rabbit rabbit = null;
            private Parser parser = null;
             //only for test reasons ^^

            private GUI.GUI gui;
        private List<Dragon> listDragon = null;
        private List<Player> listPlayer = null;
        private List<Rabbit> listRabbit = null;
        private List<MapCell> listMapCell =null;


        /// <summary>
        /// private default-constructor. Generates one Instance of Manager. (Singleton)
        /// </summary>
        private Manager()
        {
            //Buffer buffer = Buffer.Instance;
            //setDragon();
            //setPlayer();
            //setRabbit();
            //setParser(buffer);
            gui = GUI.GUI.getGUI();
        }




        /// <summary>
        /// procedure to get only one global accessible instance of Manager
        /// </summary>
        /// <return> Manager - instance</return>
        /// 
        public static Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(key)
                    {
                        if (instance == null)
                        {
                            instance = new Manager();
                        }
                    }
                    
                }
                return instance;
            }
        }


        //***************************CONTROL*MANAGEMENT********************

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="decission"></param>
        /// <param name="points"></param>
        /// <param name="total"></param>
        public void opponentInfo(int pID, String decission, int points, int total)
        {

        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="challengeID"></param>
        /// <param name="type"></param>
        /// <param name="accepted"></param>
        public void challengeInfo(int challengeID, String type, bool accepted)
        {

        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="busy"></param>
        /// <param name="decission"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void dragonInfo(int id, String type, bool busy, String decission, int x, int y)
        {

        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="busy"></param>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="points"></param>
        public void playerInfo(int id, String type, bool busy, String name, int x, int y, int points)
        {

        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="o"></param>
        public void entitysInfo(Object o)
        {
            if (o is Dragon)
            {
            }
            else if (o is Player)
            {
            }
            else
            {
                throw new NotSupportedException("the entity given to the manager is invalid.");
            }
        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="props"></param>
        public void mapCellInfo(int row, int col, List<String> props)
        {
            if (props.Count < (row * col))
            {
                throw new ManagerInputException("mapcell information is corrupt! ");
            }
            else
            {

                  foreach (String s in props){
                //PROPERTY: "WALKABLE"|"WALL"|"FOREST"|"WATER"|"HUNTABLE"

                if(s.Equals ("WALKABLE")|| s.Equals("walkable")){
                   // gui.transformTile(); //only a possibility to draw the map.
                }
                 if(s.Equals ("WALL")|| s.Equals("wall")){
                     
                }
                 if(s.Equals ("FOREST")|| s.Equals("forest")){
                   
                }
                 if(s.Equals ("WATER")|| s.Equals("water")){
                   
                }
                 if(s.Equals ("HUNTABLE")|| s.Equals("huntable")){
                    
                }

                

            }

            }
        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="breite"></param>
        /// <param name="höhe"></param>
        /// <param name="mcList"></param>
        public void mapInfo(int breite, int höhe, List<MapCell> mcList)
        {

        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="sourceid"></param>
        /// <param name="src"></param>
        /// <param name="text"></param>
        public void Msg(int sourceid, String src, String text)
        {

        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        /// <param name="mc"></param>
        public void update(Dragon d, Player p, MapCell mc)
        {

        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="p"></param>
        public void deleteInfo(Dragon d, Player p)
        {

        }

        /// <summary>
        /// this method recieves information from the parser and delegates it to the concerning backend-methods.
        /// </summary>
        /// <param name="ans"></param>
        /// <param name="info"></param>
        public void answerInfo(String ans, String info)
        {

        }




        //*****************************player*****************************

        /// <summary>
        /// get a player object.
        /// </summary>
        /// <returns></returns>
        public Player getPlayer()
        {
            return this.player;
        }

        /// <summary>
        /// sets the player object
        /// </summary>
        /// <param name="player"></param>
        private void setPlayer()
        {
            if (player == null)
            {
                this.player = new Player(22,"playersName",1,1);
            }
            else
            {
                throw new PlayerException("Player already exists!");
            }
        }



        //******************************dragon********************************

        /// <summary>
        /// get the dragon object
        /// </summary>
        /// <returns></returns>
        public List<Dragon> getDragonList()
        {
            return this.listDragon;
        }

        /// <summary>
        /// sets the object of the dragon
        /// </summary>
        /// <param name="d"></param>
        private void setDragon(Dragon d)
        {
            if (listDragon == null)
            {
                //this.dragon = new Dragon();
                
            }
           
            //listdragon.add(Dragon d);
               
            

        }



        //*********************************rabbit****************************


        /// <summary>
        /// get the object of the rabbit
        /// </summary>
        /// <returns></returns>
        public List<Rabbit> getRabbitList()
        {
            return this.listRabbit;
        }



        /// <summary>
        /// sets the object if the rabbit
        /// </summary>
        /// <param name="r"></param>
        private void setRabbit(Rabbit r)
        {
            if (rabbit == null)
            {
                this.rabbit = new Rabbit();
            }
            else
            {
                throw new ManagerInputException("Rabbit already exists!");
            }
         
        }


        /// <summary>
        /// this method commits the extracted information from the EBNF to the rabbit object.
        /// </summary>
        /// </summary>
        private void rabbitAttributes()
        {
            throw new NotImplementedException();
        }


        //********************************parser***************************

        /// <summary>
        /// gets the Parser Object.
        /// </summary>
        /// <returns></returns>
        public Parser getParser() 
        {
            return parser;
        }

        /// <summary>
        /// sets the aprser object
        /// </summary>
        /// <param name="p"></param>
        private void setParser(Buffer buffer) 
        {
            if (parser == null)
            {
                parser = new Parser(buffer);

            }
        }

        /// <summary>
        /// saves the objects of layer dragon and rabbit in a seperate ArrayList.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="r"></param>
        /// <param name="pl"></param>
        public void saveObjectsFromParser(Dragon d, Rabbit r, Player pl)
        {
            if (d == null || r == null || pl == null)
            {
                throw new NullReferenceException("Either the dragon or the rabbit or the player object is null!");
            }
            else
            {
               

            }
        }


        //*****************************MapCell***************



        //*****************************GUI*********************

              

        /// <summary>
        /// this method sends a new Chatmessage to the server - called from the send-Event of the GUI
        /// </summary>
        /// <param name="message"></param>
        internal void chatUpdateToServer(String message)
        {
            //called from Send-Event out of the GUI
        }


        /// <summary>
        /// this method renews the chatrun in the GUI
        /// </summary>
        /// <param name="message"></param>
        internal void chatUpdateToClient(String message)
        {
            try
            {
                gui.setChatUpdate(message);
            }
            catch(NullReferenceException ne){

            }
        }


        /// <summary>
        /// this method is to send a movemend of Player with IDxy to the server and replaces him on the new tile -GUI-
        /// </summary>
   
        /// <param name="direction"></param>
        internal void movePlayer( String direction)
        {
            //display on the gui - only for test purposes
                chatUpdateToClient(direction);

            //send movement to server:
            //........insert here.........

            //then replace/move Player icon on the GUI
                updatePlayer(direction);
            
        }

        /// <summary>
        /// draws the complete map according to the list<String> of Attributes
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="attributes"></param>
        internal void updateFullMap(int row, int column, List<String> attributes )
        {
            try
            {
                gui.drawMap(row, column, attributes);
            }
            catch (Exception)
            {
              
            }
        }

        /// <summary>
        /// this method places the player to a new tile and removes him from the previous tile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="direction"></param>
        internal void updatePlayer(String direction)
        {
             
        }


        /// <summary>
        /// this method places the dragon to a new tile and removes him from the previous tile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        internal void updateDragon( int rowOld, int colOld, int rowNew, int colNew)
        {

            gui.drawDragon(rowOld, colOld, rowNew, colNew);

        }


       

        //********************************************MAIN******************************************
        /*
        static void Main(String[] args)
        {
           Manager mgr = Manager.Instance;
        }
        
        */


    }
}
