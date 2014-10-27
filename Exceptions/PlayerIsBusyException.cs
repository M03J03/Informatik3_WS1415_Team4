using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
    [Serializable]
    public class PlayerIsBusyException : System.Exception
    {
        /// <summary>
        /// Generates an Exception Object.
        /// </summary>
        public PlayerIsBusyException()
        {
        }

        /// <summary>
        /// Generates an Exception Object withe the commited parameter
        /// </summary>
        /// <param name="message"></param>
        public PlayerIsBusyException(String message)
            : base(message)
        {
        }
    }
}