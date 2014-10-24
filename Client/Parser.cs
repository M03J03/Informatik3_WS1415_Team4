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

            validPrompts[0] = "upd";            //
            validPrompts[1] = "del";            //
            validPrompts[2] = "map";            //
            validPrompts[3] = "mes";            //
            validPrompts[4] = "result";         //
            validPrompts[5] = "challenge";      //
            validPrompts[6] = "players";         //
            validPrompts[7] = "yourid";         //
            validPrompts[8] = "time";           //
            validPrompts[9] = "online";        //
            validPrompts[10] = "ents";          //
            validPrompts[11] = "player";       //
            validPrompts[12] = "server";        //
            validPrompts[13] = "";              //  
            validPrompts[14] = "opponent";      //
            validPrompts[15] = "dragon";        //
            validPrompts[16] = "cell";          //
            validPrompts[17] = "ok";            //
            validPrompts[18] = "unknown";       //
            validPrompts[19] = "no";            //
            validPrompts[20] = "invalid";       //


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

        public void checkMsg(String [] msgs)
        {
            Contract.Requires(msgs.Length >= 0);
            Contract.Ensures(msgs.Length >= 0);

            bool goOn = true;
            int Counter = 0;
            for (int i = 0; i < msgs.Length; i++)
            {

                // while there is no match && there are valid prompts left to compare with
                while (goOn && (Counter < validPrompts.Length))
                {
                    if (msgs[i].Contains(validPrompts[Counter]))
                    {
                        goOn = false;

                        // Call one method listed below and parse this MESSAGE to the corresponding Class
                    }
                    else
                    {
                        Counter++;
                    }

                } // end while
            }
        }

        public void sendMsgToListener(String Msg, bool isValid){
               Contract.Ensures(Msg.Length > 0);
               Contract.Ensures(isValid);
        }

        //Message begin:upd
        public void sendMsgToUpdater(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:del
        public void sendMsgToBackend(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        //Message begin:map
        public void sendMsgToMap(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        //Message begin:mes
        public void sendMsgToMessenger(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        //Message begin:result
        public void sendMsgToResulter(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        //Message begin:challenge
        public void sendMsgToChallenger(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:players
        public void sendMsgToPlayers(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:yourid
        public void sendMsgToPlayer(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:time
        public void sendMsgToBackend(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:online
        public void sendMsgToBackend(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:ents
        public void sendMsgToBackend(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:player
        public void sendMsgToPlayer(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:server
        public void sendMsgToUNKNOWN(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:<empty>
        public void sendMsgToIGNORE(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:opponent
        public void sendMsgToChallenger(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:dragon
        public void sendMsgToDragon(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:cell
        public void sendMsgToMap(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:ok
        public void sendMsgToMessenger(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:unknown
        public void sendMsgToUNKNOWN(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:no
        public void sendMsgToMessenger(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

        // Message begin:invalid
        public void sendMsgToBackend(String Msg, bool isValid)
        {
            Contract.Ensures(Msg.Length > 0);
            Contract.Ensures(isValid);
        }

    }
}
