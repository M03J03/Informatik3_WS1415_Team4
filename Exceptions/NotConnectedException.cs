﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
    [Serializable]
    public class NotConnectedException : System.Exception
    {
        /// <summary>
        /// Generates an Exception Object.
        /// </summary>
        public NotConnectedException()
        {
        }

        /// <summary>
        /// Generates an Exception Object withe the commited parameter
        /// </summary>
        /// <param name="message"></param>
        public NotConnectedException(String message)
            : base(message)
        {
        }
    }
}
