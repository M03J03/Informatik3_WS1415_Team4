using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
    [Serializable]
    public class WrongWidthOrHeigthException : System.Exception
    {
        /// <summary>
        /// Generates an Exception Object.
        /// </summary>
        public  WrongWidthOrHeigthException()
        {
        }

        /// <summary>
        /// Generates an Exception Object withe the commited parameter
        /// </summary>
        /// <param name="message"></param>
        public WrongWidthOrHeigthException(String message)
            : base(message)
        {
        }
    }
}
