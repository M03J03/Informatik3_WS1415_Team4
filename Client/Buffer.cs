using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Client {
    class Buffer {

        ArrayList bufferArrayList;
    


        Buffer(){
           ArrayList bufferArrayList =new ArrayList();
        }

        private void addMessage(String messagetoBuffer)
        {
            Contract.Assume(messagetoBuffer is String, "ERROR: WRONG TYPE - the addMessage Method got a wrong Object to save to Buffer!");
            Contract.Requires(bufferArrayList!=null);

            Contract.Ensures(bufferArrayList.Capacity > 0, "nothing sent to the bufferArrayList");
            Contract.Ensures();
        }

        public void getMessage(){

        }

        private void removeMessage(){
        
        }

        public void flushBuffer(){

        }

    }
}
