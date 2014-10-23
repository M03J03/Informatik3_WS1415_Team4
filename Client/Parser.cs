using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace DragonsAndRabbits.Client
{
    public class Parser
    {

        String inputFromBuffer;
        String[] stringArrayOfValidMsg;
        String[] validPrompts;
         enum state  {update, delete};
         String input;




        public Parser()
        {

           
            
         /*   validPrompts[0] = "update";
            validPrompts[1] = "delete";
            validPrompts[2] = "map";
            validPrompts[3] = "message";
            validPrompts[4] = "answer";
            validPrompts[5] = "result";
            validPrompts[6] = "challenge";
            validPrompts[7] = "player";
            validPrompts[8] = "yourid";
            validPrompts[9] = "time";
            validPrompts[10] = "online";
            validPrompts[11] = "entities";
            validPrompts[12] = "players";
            validPrompts[13] = "server";
        */



        }

        public String getInput()
        {
            return input;
        }

        public void getInputFromBuffer(String inputFromBuffer)
        {
            
            Contract.Requires(inputFromBuffer.Length > 0);
            Contract.Ensures(inputFromBuffer.Length > 0);
            analyzeBuffer(inputFromBuffer);
            this.input = inputFromBuffer;
        }

        public void analyzeBuffer(String bufferInput)
        {

            Contract.Requires(bufferInput.Contains("begin:"));
            Contract.Requires(bufferInput.Contains("end:"));
            Contract.Requires(bufferInput.LastIndexOf("begin:") < bufferInput.IndexOf("end:"));

            Contract.Ensures(bufferInput.LastIndexOf("begin:") < bufferInput.IndexOf("end:"));
            int counter = 0;
            while (bufferInput.Length != 0)
            {

                String validMsg = bufferInput.Substring(bufferInput.LastIndexOf("begin:"), (bufferInput.IndexOf("end:") - bufferInput.LastIndexOf("begin:")));
                bufferInput = bufferInput.Remove(bufferInput.LastIndexOf("begin:"), (bufferInput.IndexOf("end:") - bufferInput.LastIndexOf("begin:")));
                counter++;
                stringArrayOfValidMsg[counter] = validMsg;
            }

                checkMsg(stringArrayOfValidMsg);
        }

        private void checkMsg(String [] msgs)
        {
            Contract.Requires(msgs.Length > 0);
            Contract.Ensures(msgs.Length > 0);

            bool goOn = true;
            int Counter = 0;
            for (int i = msgs.Length; i >= 0; i--)
            {
                    
                // MSGS at Position[i] contains a Rule to resolve the receiver of the message;
                // Send valid MSG to Receiver with validationOfMessage = true;
                



            }


        }

        private void sendMsgToListener(String Msg, bool isValid){
               Contract.Ensures(Msg.Length > 0);
               Contract.Ensures(isValid);
        }

        private void sendMsgToSomeObject(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

    }
}
