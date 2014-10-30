using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
    [Serializable]
    public class  NoValidMessageExcecption : System.Exception
    {
        /// <summary>
        /// Generates an Exception Object.
        /// </summary>
        public  NoValidMessageExcecption()
        {
        }

        /// <summary>
        /// Generates an Exception Object withe the commited parameter
        /// </summary>
        /// <param name="message"></param>
        public  NoValidMessageExcecption(String message)
            : base(message)
        {
        }
    }
}