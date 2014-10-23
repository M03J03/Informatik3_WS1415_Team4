using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Client {
    class Buffer {

        ArrayList bufferArrayList =new ArrayList();
    


        //this method sends recieved packets from the server to the buffer.
        private void addMessage(String messagetoBuffer)
        {
            Contract.Assume(messagetoBuffer is String, "ERROR: WRONG TYPE - the addMessage Method got a wrong Object to save to Buffer!");
            Contract.Requires(bufferArrayList!=null);

            Contract.Ensures(bufferArrayList.Capacity > 0, "nothing sent to the bufferArrayList");
        }

        //this method pulles out one messages from the buffer. Always the first element of the arraylist
        public void getMessage(){
            Contract.Requires(bufferArrayList.Capacity!=0);
            Contract.Requires(bufferArrayList.);
            Contract.Ensures(return !=null);
            Contract.Ensures(bufferArrayList.RemoveAt(0));

        }

        //this method enables to delete one message. -> automatically called from getMessage()
        private void removeMessage(){
        
        }

        //this method provides the possibility to delete the whole buffer in case of errors.
        public void flushBuffer()
        {

        }

    }
}
