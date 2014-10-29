using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
    [Serializable]
    public class NoMessageException : System.Exception
    {
        /// <summary>
        /// Generates an Exception Object.
        /// </summary>
        public NoMessageException()
        {
        }

        /// <summary>
        /// Generates an Exception Object withe the commited parameter
        /// </summary>
        /// <param name="message"></param>
        public NoMessageException(String message)
            : base(message)
        {
        }
    }
}