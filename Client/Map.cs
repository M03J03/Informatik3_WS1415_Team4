using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Client
{
    public class Map
    {

        private int height;
        private int width;
        private List<MapCell> mapCell;
        private Properties[,] map;

        

        public Map(int width, int height, List<MapCell> mapCell)
        {
            
        }

        /// <summary>
        /// gets the heigth of the map
        /// </summary>
        /// <returns></returns>
        public int getHeight()
        {
            return height;
        }

        /// <summary>
        /// sets the heigth of the map
        /// </summary>
        /// <param name="height"></param>
        private void setHeight(int height)
        {
            if (height <= 0)
            {
                throw new WrongWidthOrHeigthException("The heigth is smaller or equals 0!");
            }
            else
            {
                this.height = height;
            }
        }

        /// <summary>
        /// get the width
        /// </summary>
        /// <returns></returns>
        public int getWidth()
        {
            return width;
        }

        /// <summary>
        /// sets the width
        /// </summary>
        /// <param name="width"></param>
        private void setWidth(int width)
        {
            if (width <= 0)
            {
                throw new WrongWidthOrHeigthException("The width is smaller or equals 0!");
            }
            else
            {
                this.width = width;
            }
        }

        /// <summary>
        /// generates the map
        /// </summary>
        /// <param name="width"></param>
        /// <param name="heigth"></param>
        /// /// <param name="mapCell"></param>
        private void generateMap(int width, int heigth, List<MapCell> mapCell)
        {
            //List<MapCell> have to talk about it
            setWidth(width);
            setHeight(heigth);
            map = new int[width, heigth];
        }

        /// <summary>
        /// return the map in a twodimensional int array
        /// </summary>
        /// <returns></returns>
        public int[,] getMap()
        {
            return map;
        }

        /// <summary>
        /// shows the map. Yet its only the created map. not the content of the specific mapcell
        /// </summary>
        public void showMap()
        {
            for (int i = 0; i < getHeight(); i++)
            {
                for (int j = 0; j < getWidth() - 1; j++)
                {
                    Console.Write("[content of one mapcell]");
                }
                Console.WriteLine("[content of one mapcell]");
            }
        }
    }
}
