using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Client {
    public class Buffer {

        ArrayList bufferArrayList = new ArrayList();
        int lockCount = 0;
        int bufferSize = 0;


        //this method initializes an ArrayList only ONCE!
        Buffer()
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
   
    


        //this method sends recieved packets from the server to the buffer.
        private void addMessage(String messagetoBuffer)
        {
            Contract.Assume(messagetoBuffer is String, "ERROR: WRONG TYPE - the addMessage Method in class 'Buffer' got a wrong Input Type!");
            Contract.Requires(bufferArrayList!=null);

            bufferSize++;


            Contract.Ensures(bufferArrayList.Capacity > 0, "nothing sent to the bufferArrayList");
        }

        //this method pulles out one messages from the buffer. Always the first element of the arraylist
        public string getMessage(){
            Contract.Requires(bufferArrayList.Capacity!=0);

            String tmp = (String)bufferArrayList[0];
            removeMessage();
            return tmp;
            

            Contract.ValueAtReturn<string> (bufferArrayList[0]);
            Contract.Ensures(bufferArrayList.RemoveAt(0));

        }

        //this method enables to delete one message. -> automatically called from getMessage()
        private void removeMessage(){
            bufferArrayList.RemoveAt(0);
        }

        //this method provides the possibility to delete the whole buffer in case of errors.
        public void flushBuffer()
        {
            bufferArrayList.Clear();

            Contract.Ensures(bufferArrayList.Capacity == 0);

        }

    }
}
