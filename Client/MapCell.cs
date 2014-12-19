using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Client
{
    public class MapCell
    {
        private int rowY;
        private int columnX;
        private List<Manager.Properties> propsList;

        /// <summary>
        /// Generates an object of the mapcell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="props"></param>
        public MapCell(int row, int column, List<String> props)
        {
            propsList = new List<Manager.Properties>();
            setRow(row);
            setColumn(column);
            foreach (String s in props)
            {
                setProps(s);
            }
        }

        /// <summary>
        /// Sets the row of the mapcell
        /// </summary>
        /// <param name="row"></param>
        private void setRow(int row)
        {
            this.rowY = row;
        }

        /// <summary>
        /// Sets the row of the map cell
        /// </summary>
        /// <returns></returns>
        public int getRow()
        {
            return rowY;
        }

        /// <summary>
        /// Sets the column of the mapcell
        /// </summary>
        /// <param name="column"></param>
        private void setColumn(int column)
        {
            this.columnX = column;
        }

        /// <summary>
        /// Return the column of the mapcell
        /// </summary>
        /// <returns></returns>
        public int getColumn()
        {
            return columnX;
        }

        /// <summary>
        /// Sets the properties of the mapcell
        /// </summary>
        /// <param name="prop"></param>
        private void setProps(String prop)
        {
            
            switch (prop) { 
                case"walkable":
                case"WALKABLE":
                    propsList.Add(Manager.Properties.walkable);
                    break;
                case "wall":
                case "WALL":
                    propsList.Add(Manager.Properties.wall);
                    break;
                case "forest":
                case "FOREST":
                    propsList.Add(Manager.Properties.forest);
                    break;
                case "water":
                case "WATER":
                    propsList.Add(Manager.Properties.water);
                    break;
                case "huntable":
                case "HUNTABLE":
                    propsList.Add(Manager.Properties.huntable);
                    break;
            }

        }

        /// <summary>
        /// Returns tge list of the properties of one mapcell
        /// </summary>
        /// <returns></returns>
        public List<Manager.Properties> propList()
        {
            return propsList;
        }
    }
}
