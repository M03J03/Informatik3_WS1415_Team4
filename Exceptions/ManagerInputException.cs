using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Exceptions
{
   
        [Serializable]
        public class ManagerInputException : System.Exception
        {
            /// <summary>
            /// Generates an Exception Object.
            /// </summary>
            public ManagerInputException()
            {
            }

            /// <summary>
            /// Generates an Exception Object withe the commited parameter
            /// </summary>
            /// <param name="message"></param>
            public ManagerInputException(String message)
                : base(message)
            {
            }
        }

   }
