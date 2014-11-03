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
        public Dragon(int id, String name, int xCoordinate, int yCoordinate)
        {
            setID(id);
            setName(name);
            setXCoordinate(xCoordinate);
            setYCoordinate(yCoordinate);
        }



        /// <summary>
        /// This Methos to update attribute of the Object Dragon
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busy"></param>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <returns></returns>
        public void update(int id, Boolean busy, int xCoordinate, int yCoordinate)
        {
            if (getID() == id)
            {
                setBusy(busy);
                setXCoordinate(xCoordinate);
                setYCoordinate(yCoordinate);
            }

        }

        /// <summary>
        /// This Methos to update attribute of the Object Dragon
        /// </summary>
        /// <param name="id"></param>
        /// <param name="busy"></param>
        public void update(int id, Boolean busy)
        {
            if (getID() == id)
            {
                setBusy(busy);

            }

        }

    }
}
