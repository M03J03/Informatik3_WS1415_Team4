using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
    [Serializable]
    public class BufferException : System.Exception
    {
        /// <summary>
        /// Generates an Exception Object.
        /// </summary>
        public BufferException()
        {
        }

        /// <summary>
        /// Generates an Exception Object with an inner Exception.
        /// </summary>
        public BufferException(String message, Exception e) 
            :base(message, e)
        {

        }
        /// <summary>
        /// Generates an Exception Object withe the commited parameter
        /// </summary>
        /// <param name="message"></param>
        public BufferException(String message)
            : base(message)
        {
        }
    }
}
