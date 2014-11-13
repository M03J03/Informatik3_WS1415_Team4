using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;

namespace DragonsAndRabbits.Client
{
    public class Buffer
    {

        private static Buffer instance = null;
        private static readonly Object bufferInitLock = new Object();
        private readonly int bufferLimit = 200;
        List<String> bufferList = null;
        List<String> recieveList = null;


        /// <summary>
        /// This constructor only initializes a single (singleton) instance of Buffer. Called from the Singleton procedure -'Instance'
        /// </summary>

        private Buffer()
        {
            bufferList = new List<String>();
            recieveList = new List<string>();
        }

        /// <summary>
        /// procedure to get only one global accessible instance of Buffer - threadsave initialisation guaranteed.
        //// </summary>
        /// <return> Buffer - instance</return>
        public static Buffer Instance
        {
            get
            {
                if (instance == null)
                {
                    //double checked thread savety. NOT only one Thread can get here.
                    lock (bufferInitLock)
                    {
                        if (instance == null)
                        {
                            //only ONE Thread can get here.
                            instance = new Buffer();
                        }
                    }
                }
                return instance;
            }
        }


        /// <summary>
        /// this method saves recieved packets from the connector to the RECIEVELIST    .
        /// </summary>
        /// <param name="messagetoBuffer"></param>
        public void addMessage(String messagetoBuffer)
        {
            Contract.Requires(recieveList != null);



                if (bufferList == null)
                {
                    Buffer b = DragonsAndRabbits.Client.Buffer.Instance;
                }
                if (recieveList == null)
                {
                    Buffer b = DragonsAndRabbits.Client.Buffer.Instance;
                }

                this.recieveList.Add(messagetoBuffer);


                //unnecessary, because of the guideline to make a Thread wait while bufferlimit is reached.
                ////at this point, if maximum is reached - one element gets killed at index 0
                //if (hasLimitReached())
                //{
                //    bufferList.RemoveAt(0);
                //}

            

            Contract.Ensures(recieveList.Count > 0, "nothing sent to the recieveList");
            Contract.Ensures(recieveList.Count == Contract.OldValue(recieveList.Count) + 1);
        }

        /// <summary>
        /// this method pulls out one message (at index 0) from the buffer. Calls the removeMessage(). 
        /// </summary>
        /// <returns>String from buffer at index [0] OR null</returns>
        public string getMessage()
        {
            Contract.Requires(bufferList.Count > 0);
            String tmp = null;

           
            if (!isEmpty())
            {
                tmp = (String)bufferList[0];
                removeMessage();
            }
         
            Contract.Ensures(bufferList.Count == Contract.OldValue(bufferList.Count) - 1);
            return tmp;


        }



        /// <summary>
        /// this method deletes one message at index [0] of the buffer. -> called from getMessage()
        /// </summary> 
        private void removeMessage()
        {
            //The following Contract is met by calling this method
            Contract.Requires(bufferList.Count > 0);

            bufferList.RemoveAt(0);

            Contract.Ensures(bufferList.Count == Contract.OldValue(bufferList.Count) - 1);


        }

        /// <summary>
        /// this method provides the possibility to delete the whole buffer in case of errors. hopefully this method is never needed.
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


        public static Buffer getBuffer()
        {

            return instance;

        }

        //method for comparing and for analytics

        /// <summary>
        /// this method is to compare, to test and to analyze the state of the buffer - returns true if there is nothing in the buffer at all.
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

        /// <summary>
        /// this method is to compare, to test and to analyze the state of the buffer - returns true if the bufferLimit is reached
        /// </summary>
        /// <returns>bool condition</returns>
        public bool hasLimitReached()
        {
            bool condition = false; //default

            if (bufferList.Count == bufferLimit)
            {
                condition = true;
            }


            return condition;
        }

        /// <summary>
        /// refills the whole buffer at once.
        /// </summary>
        public void refillBuffer()
        {

            if (isEmpty() && recieveList != null)
            {
                while ( !hasLimitReached() && recieveList.Count > 0)
                {

                    bufferList.Add(recieveList[0]);
                    recieveList.RemoveAt(0);

                }

            }
            else
            {
                return;
            }
        }


    }
}