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
        List<String> queueList = null;


        /// <summary>
        /// This constructor only initializes a single (singleton) instance of Buffer. Called from the Singleton procedure -'Instance'
        /// </summary>

        private Buffer()
        {
            Console.WriteLine("Buffer Instanz erstellt");
            bufferList = new List<String>();
            queueList = new List<string>();
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
                Console.WriteLine("Buffer angefragt!");
                return instance;
            }
        }


        /// <summary>
        /// this method saves recieved packets from the connector to the RECIEVELIST    .
        /// </summary>
        /// <param name="messagetoBuffer"></param>
        public void addMessage(String messagetoBuffer)
        {
            Contract.Requires(queueList != null); //met because this method is called via the getter of the instance of buffer

                Console.WriteLine("queueList count before add: " + queueList.Count);
                Console.WriteLine("GOT THIS: ->" + messagetoBuffer);
                this.queueList.Add(messagetoBuffer);

                Console.WriteLine("queueList count after add: " + queueList.Count);

                //unnecessary, because of the guideline to make a Thread wait while bufferlimit is reached.
                ////at this point, if maximum is reached - one element gets killed at index 0
                //if (hasLimitReached())
                //{
                //    bufferList.RemoveAt(0);
                //}

            

            Contract.Ensures(queueList.Count > 0, "nothing sent to the recieveList");
            Contract.Ensures(queueList.Count == Contract.OldValue(queueList.Count) + 1);
        }

        /// <summary>
        /// this method pulls out one message (at index 0) from the buffer. Calls the removeMessage(). 
        /// </summary>
        /// <returns>String from buffer at index [0] OR null</returns>
        public string getMessage()
        {

            Contract.Requires(bufferList.Count > 0);
            String tmp = null;


            //possible lock here instead of in refillbuffer()
           
            if (!isEmpty())
            {
                tmp = (String)bufferList[0];
                removeMessage();
            }
            else
            {
                Console.WriteLine("Buffer needs to be refilled!");
                refillBuffer();
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
            
            try
            {
                Monitor.Enter(bufferList);
                while (!hasLimitReached() && queueList.Count > 0)
                {
                    Console.WriteLine("buffer refill capacity: " + bufferList.Count);
                    Console.WriteLine("queue delete capacity: " + queueList.Count);
                    bufferList.Add(queueList[0]);
                    queueList.RemoveAt(0);
               }
            }
            finally
            {
                Console.WriteLine("buffer REFILLED SIZE: " + bufferList.Count);
                Monitor.Exit(bufferList);
                Monitor.Pulse(bufferList);

            }

        }


    }
}