using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using DragonsAndRabbits.Exceptions;

namespace DragonsAndRabbits.Client
{
    public class Dragon : Piece
    {

        /// <summary>
        ///  Generates an object of Dragon.
        /// </summary>
        public Dragon(int id, String name, bool busy, int xCoordinate, int yCoordinate)
            : base(id, name, busy, xCoordinate, yCoordinate)
        {

        }


    }
}
