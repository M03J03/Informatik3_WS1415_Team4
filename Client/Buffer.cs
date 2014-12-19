using DragonsAndRabbits.Exceptions;
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
        private readonly int bufferLimit = 200;
        private List<String> bufferList = null;
        private List<String> queueList = null;
        private static readonly Object logObj = new Object();
        static int buffercounter = 0;
        //   bool locked = false;

        /// <summary>
        /// This constructor only initializes a single (singleton) instance of Buffer. Called from the Singleton procedure -'Instance'
        /// </summary>

        private Buffer()
        {
            Console.WriteLine("Buffer Instance set up!");
            bufferList = new List<String>();
            queueList = new List<string>();
            queueList.Add("");

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
                    // The lock-keyword calls Monitor.Enter at the beginning and Monitor.Exit at the end of the block. ThreadInterruptedException can be thrown.
                    //double checked thread savety. NOT only one Thread can get here.
                    //try
                    //{
                    lock (logObj)
                    {
                        if (instance == null)
                        {
                            //only ONE Thread can get here.
                            instance = new Buffer();
                        }
                    }
                    //}
                    //catch (ThreadInterruptedException te)
                    //{
                    //    throw new BufferException("No Instance of Buffer created! - Thread terminated too early", te);
                    //}
                    //catch (ArgumentNullException e)
                    //{
                    //    throw new Exception("Exception in Buffer");
                    //}
                }

                Console.WriteLine("Buffer requested!");
                return instance;
            }
        }


        /// <summary>
        /// this method saves recieved packets from the connector to the RECIEVELIST    .
        /// </summary>
        /// <param name="messagetoBuffer"></param>
        public void addMessage(String messagetoBuffer)
        {
            Contract.Requires(queueList != null); //is met, because this method is called via the getter of the instance which initiates a queueList

            //         Console.WriteLine("queueList count before add: " + queueList.Count);
            //         Console.WriteLine("GOT THIS: ->" + messagetoBuffer);


            //this.queueList.Add(messagetoBuffer);
            this.queueList[0] += messagetoBuffer;

            handleQueue();

            //       Console.WriteLine("queueList count after add: " + queueList.Count);



            Contract.Ensures(queueList.Count > 0, "nothing sent to the recieveList");
            Contract.Ensures(queueList.Count == Contract.OldValue(queueList.Count) + 1);
        }




        /// <summary>
        /// this method extracts one message (at index 0) of the buffer. Calls the removeMessage()- method. 
        /// </summary>
        /// <returns>String from buffer at index [0] OR null</returns>
        public string getMessage()
        {

            Contract.Requires(bufferList.Count > 0);
            String tmp = null;
            bool locked = false;

            try
            {
                //locks the bufferList exclusively for the following task(s)
                Monitor.Enter(bufferList, ref locked);

                if (!isEmpty())
                {
                    tmp = (String)bufferList[0];
                    removeMessage();
                }
                else
                {
                    //  Console.WriteLine("Buffer needs to be refilled!");
                    //  refillBuffer();
                    //  tmp = (String)bufferList[0];
                    //  removeMessage();
                }




            }

          /*  catch(Exception e)
            {
                throw new BufferException("could not lock the bufferList", e);
            }
            */
            finally
            {
                if (locked)
                {
                    Monitor.Exit(bufferList);

                }
                // Monitor.Pulse(bufferList);
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
        /// refills the whole buffer at once as long as the queueList contains elements. - is called by getMessage()-Method
        /// </summary>
        private void refillBuffer()
        {
            while (!hasLimitReached() && queueList.Count > 0)
            {
                Console.WriteLine("buffer refill capacity: " + bufferList.Count);
                Console.WriteLine("queue delete capacity: " + queueList.Count);

                handleQueue();

                //  bufferList.Add(queueList[0]);
                //  queueList.RemoveAt(0);
            }

        }

        private void handleQueue()
        {
            string firstIncome = queueList[0].ToString();
            string getMessageCode;
            string endMessageCode;


            int beginIndex = 0;
            int newLineIndexOfBegin = 0;

            // Enter after end:<number>
            int newLineIndexOfEnd = 0;
            // the position where end:number is
            int endIndex = 0;
            String result;

            // Analyze string and get the Messagenumber, to search for the corresponding "end:<MessageNumber>";
            beginIndex = firstIncome.IndexOf("begin:", 0);
            newLineIndexOfBegin = firstIncome.IndexOf(Environment.NewLine, beginIndex);
            if (newLineIndexOfBegin == 0 && firstIncome.Length > 2)
            {
                firstIncome.Substring(Environment.NewLine.Length, firstIncome.Length - Environment.NewLine.Length);
            }

            getMessageCode = firstIncome.Substring((beginIndex + 6), newLineIndexOfBegin - (beginIndex + 6)).Trim();
            //Console.WriteLine("MOEBegin at:" + beginIndex);
            //  Console.WriteLine("MOEMessageCode: " + getMessageCode);
            endMessageCode = "end:" + getMessageCode;
            endIndex = firstIncome.IndexOf(endMessageCode);

            if (endIndex > 0)
            {
                // Valid message is now between "beginIndex" and "newLineIndexOfEnd"
                // newLineIndexOfEnd = firstIncome.IndexOf(Environment.NewLine, endIndex);
                result = firstIncome.Substring(beginIndex, (endIndex + (endMessageCode.Length)));
                bufferList.Add(result);
                // Console.WriteLine("MOE-RESULT:" + result);
                this.queueList[0] = this.queueList[0].Substring(endIndex + (endMessageCode.Length));
                // Console.WriteLine("MOE -> REST OF QUEUE: " + this.queueList[0]);
                Parser Pars = new Parser();

                /*           if (this.queueList[0].Length > 2)
                           {
                               handleQueue();
                           }
                 */

            }
            
        }

    }
}