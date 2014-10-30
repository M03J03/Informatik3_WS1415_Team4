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

        private Dragon dragon = null;
        private Player player = null;
        private Rabbit rabbit = null;
        private Parser parser = null;
        private GUI.GUI gui = null;
        private List<Dragon> listDragon = null;
        private List<Player> listPlayer = null;
        private List<Rabbit> listRabbit = null;
        private List<MapCell> listMapCell =null;


        /// <summary>
        /// default-constructor. Generates one Instance of Manager. (Singleton)
        /// </summary>
        private Manager()
        {
            setDragon();
            setPlayer();
            setRabbit();
            setParser();
            setGUI();
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
                    instance = new Manager();
                }
                return instance;
            }
        }


        //***************************CONTROL*MANAGEMENT********************


        public void opponentInfo(int pID, String decission, int points, int total)
        {

        }

        public void challengeInfo(int challengeID, String type, bool accepted)
        {

        }

        public void dragonInfo(int id, String type,bool busy, String decission, int x, int y)
        {

        }

        public void playerInfo(int id, String type, bool busy, String name, int x, int y, int points)
        {

        }

        public void entitysInfo(Object o)
        {
            if (o is Dragon)
            {
            }
            else if(o is Player){
            }
            else{
                throw new NotSupportedException("the entity given to the manager is invalid.");
            }
        }

        public void mapCellInfo(int row, int col, List<String> props)
        {
            if (props.Count < (row * col))
            {
                throw new ManagerInputException("mapcell information is corrupt! ");
            }
            else
            {

            }
        }

        public void mapInfo (int breite, int höhe, List<MapCell> mcList)
        {

        }

        public void Msg (int sourceid, String src, String text)
        {

        }

        public void update(Dragon d, Player p, MapCell mc)
        {

        }

        public void deleteInfo(Dragon d, Player p)
        {

        }

        public void anwerInfo(String ans, String info)
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
                this.player = new Player();
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
        public Dragon getDragon()
        {
            return this.dragon;
        }

        /// <summary>
        /// sets the object of the dragon
        /// </summary>
        /// <param name="d"></param>
        private void setDragon()
        {
            if (dragon == null)
            {
                this.dragon = new Dragon();
            }
            else
            {
                throw new ManagerInputException("Dragon already exists!");
            }

        }



        //*********************************rabbit****************************


        /// <summary>
        /// get the object of the rabbit
        /// </summary>
        /// <returns></returns>
        public Rabbit getRabbit()
        {
            return this.rabbit;
        }



        /// <summary>
        /// sets the object if the rabbit
        /// </summary>
        /// <param name="r"></param>
        private void setRabbit()
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
        private void setParser() 
        {
            if (parser == null)
            {
                parser = new Parser.Instance(); //assuming that the Parser is a Singleton too.
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

        private void setGUI()
        {
 	        this.gui=new GUI.GUI();
        }



    }
}
