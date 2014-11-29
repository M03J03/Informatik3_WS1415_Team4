using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
    [Serializable]
    public class WrongNumberException : System.Exception
    {
        /// <summary>
        /// Generates an Exception Object.
        /// </summary>
        public WrongNumberException()
        {
        }

        /// <summary>
        /// Generates an Exception Object withe the commited parameter
        /// </summary>
        /// <param name="message"></param>
        public WrongNumberException(String message)
            : base(message)
        {
        }
    }
}
