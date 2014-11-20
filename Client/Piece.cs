﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Client
{
    public abstract class Piece
    {
        private int id;
        private bool busy = false;
        private String name;
        private int xCoordinate, yCoordinate;

        public Piece(int id, String name, bool busy, int xCoordinate, int yCoordinate)
        {
            setID(id);
            setName(name);
            setBusy(busy);
            setXCoordinate(xCoordinate);
            setYCoordinate(yCoordinate);

        }

        //Setter and Getter


        /// <summary>
        /// Method to set ID of the Dragon or Player 
        /// </summary>
        /// <paramname="id"></param>
        protected void setID(int id)
        {
            Contract.Requires(id > 0);

            if (id < 0)
            {
                throw new NullReferenceException("ID may not < 0 be");
            }

            this.id = id;
        }


        /// <summary>
        /// Method to get actual Number of the Dragon or Player 
        /// </summary>
        /// <returns></returns>
        public int getID()
        {

            Contract.Ensures(id > 0);
            return id;
        }


        /// <summary>
        /// Method to set actual status of the Dragon or Player 
        /// </summary>
        protected void setBusy(bool busy)
        {
            this.busy = busy;
        }

        /// <summary>
        /// Method to get actual status of the Dragon or Player 
        /// </summary>
        /// <returns></returns>
        public bool isBusy()
        {
            return this.busy;
        }

        /// <summary>
        /// Method to set name of the Dragon or Player 
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
        /// Method to get the name of the Dragon or Player 
        /// </summary>
        /// <returns></returns>
        public String getName()
        {

            Contract.Ensures(name != null && name.Length >= 3);

            return this.name;
        }


        /// <summary>
        /// Method to set X-Coordinate of the Dragon or Player 
        /// </summary>
        /// <paramname="x"></param>
        protected void setXCoordinate(int x)
        {
            Contract.Requires(x >= 0);

            if (x < 0)
            {
                throw new Exception("X-Coordinatemay not smaller 0 be!");
            }
            this.xCoordinate = x;
        }


        /// <summary>
        /// Method to get X-Coordinate of the Dragon or Player 
        /// </summary>
        /// <returns></returns>
        public int getXCoordinate()
        {
            Contract.Ensures(xCoordinate >= 0);

            return xCoordinate;
        }


        /// <summary>
        /// Method to set Y-Coordinate of the Dragon or Player 
        /// </summary>
        /// <paramname="y"></param>
        protected void setYCoordinate(int y)
        {
            Contract.Requires(y >= 0);

            if (y < 0)
            {
                throw new Exception("X-Coordinate may not smaller 0 be!");
            }

            this.yCoordinate = y;
        }

        /// <summary>
        /// Method to get Y-Coordinate of the Dragon or Player 
        /// </summary>
        /// <returns></returns>
        public int getYCoordinate()
        {
            Contract.Ensures(yCoordinate >= 0);

            return yCoordinate;
        }

        /// <summary>
        /// This Method to update attribute of the Dragon or Player 
        /// </summary>
        /// <paramname="id"></param>
        /// <paramname="busy"></param>
        /// <paramname="xCoordinate"></param>
        /// <paramname="yCoordinate"></param>
        /// <returns></returns>
        public void update(int id, bool busy, int xCoordinate, int yCoordinate)
        {
            if (getID() == id)
            {
                setBusy(busy);
                setXCoordinate(xCoordinate);
                setYCoordinate(yCoordinate);
            }
        }

        /// <summary>
        /// This Method to update attribute of the Dragon or Player 
        /// </summary>
        /// <paramname="id"></param>
        /// <paramname="busy"></param>
        public void update(int id, Boolean busy)
        {
            if (getID() == id)
            {
                setBusy(busy);
            }
        }
    }
}
