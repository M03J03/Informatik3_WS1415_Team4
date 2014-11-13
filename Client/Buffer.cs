﻿using System;
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
        private static bool bufferlocked = false; //default
        private readonly int bufferLimit = 200;
        List<String> bufferList = null;


        /// <summary>
        /// This constructor only initializes a single (singleton) instance of Buffer. Called from the Singleton procedure -'Instance'
        /// </summary>

        private Buffer()
        {
            bufferList = new List<String>();
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
        /// this method saves recieved packets from the connector to the buffer.
        /// </summary>
        /// <param name="messagetoBuffer"></param>
        public void addMessage(String messagetoBuffer)
        {
            Contract.Requires(bufferList != null);



            try
            {
                Monitor.TryEnter(bufferList, 25 , ref bufferlocked); //waits 25ms to get the list

                if (bufferList == null)
                {
                    Buffer b = DragonsAndRabbits.Client.Buffer.Instance;
                }

                if (bufferlocked)
                {
                    this.bufferList.Add(messagetoBuffer);
                }

                ////at this point, if maximum is reached - one element gets killed at index 0
                //if (hasLimitReached())
                //{
                //    bufferList.RemoveAt(0);
                //}

                else //if bufferlist isn't locked
                {

                }
            }
            finally
            {
                if (bufferlocked)
                {
                    Monitor.Exit(bufferList);
                }

                Monitor.PulseAll(bufferList);
               
            }



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
            String tmp = null;




            try
            {
                Monitor.TryEnter(bufferList, 25, ref bufferlocked); //tries for 25ms to get access to the List
                
                if (bufferlocked)
                {
                    if (!isEmpty())
                    {
                        tmp = (String)bufferList[0];
                        removeMessage();
                    }
                 }

                else // if bufferlist isn't locked ************************dangling ELSE????????????????????
                {
                  
                }

            }
            finally
            {
                if (bufferlocked)
                {
                    Monitor.Exit(bufferList);
                }

                Monitor.PulseAll(bufferList);
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


    }
}