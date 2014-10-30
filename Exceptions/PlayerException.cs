using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
    [Serializable]
    public class PlayerException : System.Exception
    {
        /// <summary>
        /// Generates an Exception Object.
        /// </summary>
        public PlayerException()
        {
        }

        /// <summary>
        /// Generates an Exception Object withe the commited parameter
        /// </summary>
        /// <param name="message"></param>
        public PlayerException(String message)
            : base(message)
        {
        }
    }
}
