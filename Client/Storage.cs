using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DragonsAndRabbits.Client
{
    class Storage
    {
        private Dragon dragon;
        private Player player;
        private Rabbit rabbit;
        private Parser parser;
        private ArrayList listDragon;
        private ArrayList listPlayer;
        private ArrayList listRabbit;

        /// <summary>
        /// Generates an object of Storage.
        /// </summary>
        public Storage(Parser p)
        {
            try
            {
                if (p == null)
                {
                    throw new NullReferenceException("The parser object is null!");
                }
                else
                {
                    listDragon = new ArrayList();
                    listPlayer = new ArrayList();
                    listRabbit = new ArrayList();
                    setParser(p);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// get a player object.
        /// </summary>
        /// <returns></returns>
        public Player getPlayer()
        {
            return player;
        }

        /// <summary>
        /// sets the player object
        /// </summary>
        /// <param name="player"></param>
        private void setPlayer(Player player)
        {
            if (player == null)
            {
                throw new NullReferenceException("There is no player object!");
            }
            else
            {
                this.player = player;
            }
        }

        /// <summary>
        /// get the dragon object
        /// </summary>
        /// <returns></returns>
        public Dragon getDragon()
        {
            return dragon;
        }

        /// <summary>
        /// sets the object of the dragon
        /// </summary>
        /// <param name="d"></param>
        private void setDragon(Dragon d)
        {
            if (d == null)
            {
                throw new NullReferenceException("No object of dragon!");
            }
            else 
            {
                this.dragon = d;    
            }
        }

        /// <summary>
        /// get the object of the rabbit
        /// </summary>
        /// <returns></returns>
        public Rabbit getRabbit()
        {
            return rabbit;
        }

        /// <summary>
        /// sets the object if the rabbit
        /// </summary>
        /// <param name="r"></param>
        private void setRabbit(Rabbit r)
        {
            if (r == null)
            {
                throw new NullReferenceException("No object of rabbit");
            }
            else
            {
                this.rabbit = r;
            }
        }

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
        private void setParser(Parser p) 
        {
            if (p == null)
            {
                throw new NullReferenceException("The Parser Object is null!");
            }
            else
            {
                this.parser = p;
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
                listDragon.Add(d);
                listRabbit.Add(r);
                listRabbit.Add(pl);
            }
        }
    }
}
