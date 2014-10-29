using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
    [Serializable]
    public class NoPlayerException : System.Exception
    {
        /// <summary>
        /// Generates an Exception Object.
        /// </summary>
        public NoPlayerException()
        {
        }

        /// <summary>
        /// Generates an Exception Object withe the commited parameter
        /// </summary>
        /// <param name="message"></param>
        public NoPlayerException(String message)
            : base(message)
        {
        }
    }
}