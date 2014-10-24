using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Client {
    public class Buffer {

        ArrayList bufferArrayList = null;
        static int lockCount = 0;
      


        //this method initializes an ArrayList only ONCE!
      public  Buffer()
        {
            if (lockCount != 0)
            {
                return;
            }
            else
            {
                ArrayList bufferArrayList = new ArrayList();
                lockCount++;
            }
        }
   
    


        //this method sends recieved packets from the connector to the buffer.
        public void addMessage(String messagetoBuffer)
        {
            Contract.Assume(messagetoBuffer is String, "ERROR: WRONG TYPE - the addMessage Method in class 'Buffer' got a wrong Input Type!");
            Contract.Requires(bufferArrayList!=null);

            int count = bufferArrayList.Count;

            bufferArrayList.Add(messagetoBuffer);

            Contract.Ensures(bufferArrayList.Count > 0, "nothing sent to the bufferArrayList");
            Contract.Ensures(bufferArrayList.Count > count);
        }

        /// <summary>
        /// this method pulls out one message (at index 0) from the buffer. Returnes that String
        /// </summary>
        /// <returns>String</returns>
        public string getMessage(){
            Contract.Requires(bufferArrayList.Count > 0);

            int count = bufferArrayList.Count;

            String tmp = (String)bufferArrayList[0];
            removeMessage();
    
            Contract.Ensures(bufferArrayList.Count < count);
            return tmp;
        }

        //this method enables to delete one message. -> called from getMessage()
        private void removeMessage(){
            Contract.Requires(bufferArrayList.Count > 0);
            int count = bufferArrayList.Count;
           
            bufferArrayList.RemoveAt(0);

            Contract.Ensures(bufferArrayList.Count < count);

        }

        //this method provides the possibility to delete the whole buffer in case of errors.
        public void flushBuffer()
        {
            Contract.Requires(bufferArrayList != null);

            bufferArrayList.Clear();

            Contract.Ensures(isEmpty());

        }

        //method for comparing and for analytics
        public bool isEmpty()
        {
            if (bufferArrayList.Count > 0)
            {
                return false;
            }
            else { return true; }
        }
    }
}
