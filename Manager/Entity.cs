using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Manager
{
    public abstract class Entity
    {
        private int id;
        private bool busy = false;
        private String name;
        private int row;
        private int column;

        /// <summary>
        /// Generates an object of entity.
        /// //Be careful! The classist abstract!
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="busy"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        protected Entity(int id, String name, bool busy, int row, int column)
        {
            setID(id);
            setName(name);
            setBusy(busy);
            setRow(row);
            setColumn(column);
        }

        private void setID(int id)
        {
            if (id < 0)
            {
                throw new WrongNumberException("Please insert an number bigger than 0!");
            }
            this.id = id;
        }

        /// <summary>
        /// Returns the id.
        /// </summary>
        /// <returns></returns>
        public int getID()
        {
            return id;
        }

        /// <summary>
        /// Sets if the entity is busy or not.
        /// </summary>
        /// <param name="busy"></param>
        private void setBusy(bool busy)
        {
            this.busy = busy;
        }

        /// <summary>
        /// Returns if the entity is busy or not.
        /// </summary>
        /// <returns></returns>
        public bool isBusy()
        {
            return busy;
        }

        /// <summary>
        /// Sets the name of the entity.
        /// </summary>
        /// <param name="name"></param>
        private void setName(String name)
        {
            if (name == null)
            {
                throw new NullReferenceException("There is no name!");
            }
            else if (name.Length < 3)
            {
                throw new NoValidMessageExcecption("Please insert at least 3 chars for a name!");
            }
            else
            {
                this.name = name;
            }
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <returns></returns>
        public String getName()
        {
            return name;
        }

        /// <summary>
        /// Sets the row of the entity
        /// </summary>
        /// <param name="row"></param>
        private void setRow(int row)
        {
            if (row < 0)
            {
                throw new WrongWidthOrHeigthException("Please insert a number bigger or equals 0!");
            }
            else
            {
                this.row = row;
            }
        }

        /// <summary>
        /// Returns the rowof the entity.
        /// </summary>
        /// <returns></returns>
        public int getRow()
        {
            return row;
        }

        /// <summary>
        /// Sets the column of the entity.
        /// </summary>
        /// <param name="column"></param>
        private void setColumn(int column)
        {
            if (column < 0)
            {
                throw new WrongWidthOrHeigthException("Please insert a number bigger than 0!");
            }
            this.column = column;
        }

        /// <summary>
        /// Returns the column of the entity.
        /// </summary>
        /// <returns></returns>
        public int getColumn()
        {
            return column;
        }

        /// <summary>
        /// Method to update the entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busy"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void update(int id, String name, bool busy, int row, int column)
        {
            if (this.id == id)
            {
                setName(name);
                setBusy(busy);
                setRow(row);
                setColumn(column);
            }
        }

        /// <summary>
        /// Method to update the status of the entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busy"></param>
        public void update(int id, bool busy)
        {
            if(this.id == id)
            {
                setBusy(busy);
            }
        }
    }
}
