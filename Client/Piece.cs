using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Client
{
    public class Piece
    {
        private int id;
        private Boolean busy = false;
        private String name;
        private int xCoordinate, yCoordinate;


        //Setter and Getter


        /// <summary>
        /// Method to set ID of the dragon
        /// </summary>
        /// <param name="id"></param>
        protected void setID(int id)
        {
            Contract.Requires(id > 0);
            Contract.Ensures(id > 0);

            if (id < 0)
            {
                throw new NullReferenceException("ID may not < 0 be");
            }

            this.id = id;
        }


        /// <summary>
        /// Method to get actual Number of the Dragon
        /// </summary>
        /// <returns></returns>
        public int getID()
        {

            Contract.Ensures(id > 0);
            return id;
        }


        /// <summary>
        /// Method to set actual status of the Dragon
        /// </summary>
        protected void setBusy(Boolean busy)
        {
            this.busy = busy;
        }

        /// <summary>
        /// Method to get actual status of the Dragon
        /// </summary>
        /// <returns></returns>
        public Boolean isBusy()
        {
            return this.busy;
        }

        /// <summary>
        /// Method to set name of the dragon
        /// </summary>
        protected void setName(String name)
        {
            Contract.Requires(name != null);
            Contract.Requires(name.Length >= 3);

            if (name == null || name.Length < 3)
            {
                throw new NullReferenceException("There is no name existing or the name length is smaller than 3!");
            }

            this.name = name;
        }


        /// <summary>
        /// Method to get the name of the Dragon
        /// </summary>
        /// <returns></returns>
        public String getName()
        {

            Contract.Ensures(name != null && name.Length >= 3);

            return this.name;
        }


        /// <summary>
        /// Method to set X-Coordinate
        /// </summary>
        /// <param name="x"></param>
        protected void setXCoordinate(int x)
        {
            Contract.Requires(x >= 0);
            Contract.Ensures(x >= 0);

            if (x < 0)
            {
                throw new Exception("X-Coordinate may not smaller 0 be!");
            }
            this.xCoordinate = x;
        }


        /// <summary>
        /// Method to get X-Coordinate
        /// </summary>
        /// <returns></returns>
        public int getXCoordinate()
        {
            Contract.Ensures(xCoordinate >= 0);

            return xCoordinate;
        }


        /// <summary>
        /// Method to set Y-Coordinate
        /// </summary>
        /// <param name="y"></param>
        protected void setYCoordinate(int y)
        {
            Contract.Requires(y >= 0);
            Contract.Ensures(y >= 0);

            if (y < 0)
            {
                throw new Exception("X-Coordinate may not smaller 0 be!");
            }

            this.yCoordinate = y;
        }


        /// <summary>
        /// Method to get Y-Coordinate
        /// </summary>
        /// <returns></returns>
        public int getYCoordinate()
        {
            Contract.Ensures(yCoordinate >= 0);

            return yCoordinate;
        }
    }


}
