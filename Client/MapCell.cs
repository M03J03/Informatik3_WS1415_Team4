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
        enum fieldType { walkable, wall, forest, water, huntable };

        public MapCell(int row, int column, List<String> props)
        {

        }
    }
}
