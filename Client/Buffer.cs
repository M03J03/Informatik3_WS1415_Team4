using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Client
{
    public class Buffer
    {

        private static Buffer instance = null;
        List<String> bufferList = null;




        /// <summary>
        /// This constructor only initializes a single (singleton) instance of Buffer. Called from the Singleton procedure -'Instance'
        /// </summary>

        private Buffer()
        {
            bufferList = new List<String>();
        }

        /// <summary>
        /// procedure to get only one global accessible instance of Buffer
        /// </summary>
        /// <return> Buffer - instance</return>
        public static Buffer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Buffer();
                }
                return instance;
            }
        }


        /// <summary>
        /// this method saves recieved packets from the connector to the buffer.
        /// </summary>
        /// <param name="messagetoBuffer"></param>
        public void addMessage(String messagetoBuffer)
        {
            Contract.Requires(bufferList != null);

            //sichert eine angelegte bufferArrayList zu. 
            if (bufferList == null)
            {
                Buffer b = DragonsAndRabbits.Client.Buffer.Instance;
            }

            this.bufferList.Add(messagetoBuffer);

            Contract.Ensures(bufferList.Count > 0, "nothing sent to the bufferArrayList");
            Contract.Ensures(bufferList.Count == Contract.OldValue(bufferList.Count) + 1);
        }

        /// <summary>
        /// this method pulls out one message (at index 0) from the buffer. Calls the removeMessage(). 
        /// </summary>
        /// <returns>String from buffer at index [0] OR null</returns>
        public string getMessage()
        {
            Contract.Requires(bufferList.Count > 0);
            String tmp;

            if (bufferList.Count > 0)
            {
                tmp = (String)bufferList[0];
                removeMessage();
            }
            else
            {
                tmp = null;
            }

            Contract.Ensures(bufferList.Count == Contract.OldValue(bufferList.Count) - 1);
            return tmp;


        }



        /// <summary>
        /// this method deletes one message at index [0] of the buffer. -> called from getMessage()
        /// </summary> 
        private void removeMessage()
        {
            Contract.Requires(bufferList.Count > 0);

            bufferList.RemoveAt(0);

            Contract.Ensures(bufferList.Count == Contract.OldValue(bufferList.Count) - 1);


        }

        /// <summary>
        /// this method provides the possibility to delete the whole buffer in case of errors.
        /// </summary>
        public void flushBuffer()
        {
            Contract.Requires(bufferList != null);

            if (bufferList != null)
            {
                bufferList.Clear();
            }

            Contract.Ensures(isEmpty());

        }

        //method for comparing and for analytics

        /// <summary>
        /// this method is to compare, to test and to analyze the state of the buffer
        /// </summary>
        /// <returns>bool condition</returns>
        public bool isEmpty()
        {
            bool condition = true; //default

            if (bufferList.Count > 0)
            {
                condition = false;
            }


            return condition;
        }
    }
}
