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
        //only for test reasons vv
        private Dragon dragon = null;
        private Player player = null;
        private Rabbit rabbit = null;
        private Parser parser = null;
         //only for test reasons ^^
        private GUI.GUI gui = null;
        private List<Dragon> listDragon = null;
        private List<Player> listPlayer = null;
        private List<Rabbit> listRabbit = null;
        private List<MapCell> listMapCell =null;


        /// <summary>
        /// private default-constructor. Generates one Instance of Manager. (Singleton)
        /// </summary>
        private Manager()
        {
            Buffer buffer = Buffer.Instance;
            setParser(buffer);
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
        private void setPlayer(Player p)
        {
            if (p is Player && p != null)
            {
                listPlayer.Add(p);
            }
            else
            {
                throw new ManagerInputException("Player setting missmatch!");
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
        private void setDragon(Dragon d)
        {
            if (d is Dragon && d !=null)
            {
                listDragon.Add(d);
            }
            else
            {
                throw new ManagerInputException("Dragon setting mismatch");
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
        private void setRabbit(Rabbit r)
        {
            if (r is Rabbit && r != null)
            {
                listRabbit.Add(r);
            }
            else
            {
                throw new ManagerInputException("Rabbit setting missmatch");
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

        private void setGUI()
        {
 	        this.gui=new GUI.GUI();
        }



    }
}
