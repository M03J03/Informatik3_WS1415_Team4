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
        String[] validPrompts = {   "upd",
                                    "del",
                                    "map",
                                    "mes",
                                    "result",
                                    "challenge",
                                    "players",
                                    "yourid",
                                    "time",
                                    "online",
                                    "ents",
                                    "player",
                                    "server",
                                    "",
                                    "opponent",
                                    "dragon",
                                    "cell",
                                    "ok",
                                    "unknown",
                                    "no",
                                    "invalid" };

        String input;

        public Parser()
        {

        }

        public String getInput()
        {
            return input;
        }

        //without param
        public void getInputFromBuffer(String inputFromBuffer)
        {

            Contract.Requires(inputFromBuffer.Length > 0);
            analyzeBuffer(inputFromBuffer);
            this.input = inputFromBuffer;
            Contract.Ensures(inputFromBuffer.Length > 0);
        }

        public void analyzeBuffer(String bufferInput)
        {
            //OLD PRE / POST BUFFER

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

        public void checkMsg(String[] msgs)
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

        public void sendMsgToListener(String Msg, bool isValid)
        {
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
