using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using System.Threading;
using DragonsAndRabbits.Exceptions;
using DragonsAndRabbits.Client;

namespace DragonsAndRabbits.Client
{
    public class Parser
    {
        private Buffer refToBuffer;
        private Thread fred;
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

        public Parser(Buffer buffer)
        {
            refToBuffer = buffer;
            fred = new Thread(new ThreadStart(getInputFromBuffer));
            fred.IsBackground = true;
            fred.Start();
        }


        
        private void getInputFromBuffer()
        {

           // Contract.Requires(refToBuffer->Length > 0);

            analyzeBuffer(refToBuffer.getMessage());
            
          //  Contract.Ensures(inputFromBuffer.Length > 0);
        }

        public void analyzeBuffer(String bufferInput)
        {
            //OLD PRE / POST BUFFER

            Contract.Requires(bufferInput.Contains("begin:"));
            Contract.Requires(bufferInput.Contains("end:"));
            // Contract.Requires(bufferInput.LastIndexOf("begin:") < bufferInput.IndexOf("end:")); INCORRECT because begin:foo begin:fuu end:fuu begin:test end:test would be incorrect

            // get the first begins to filter messagenumber

            // get the first begins to filter messagenumber
            int foundBegin = 0;
            int foundEnd = 0;
            int found = 0;
            int totFinds = 0;
            int[] allIndexOfBegin = new int[100];
            int[] allIndexOfEnd = new int[100];
            int indexOfEnd = 0;
            String checkForEnd = "end:";
            String message;

            // get all "begin:"
            for (int i = 0; i < bufferInput.Length; i++)
            {
                foundBegin = bufferInput.IndexOf("begin:", i);

                if (foundBegin >= 0)
                {
                    allIndexOfBegin[totFinds] = foundBegin;
                    totFinds++;
                    i = foundBegin;
                }
                else
                {
                    break;
                }
            }
            totFinds = 0;

            //get all "end:"
            for (int i = 0; i < bufferInput.Length; i++)
            {
                foundEnd = bufferInput.IndexOf("end:", i);

                if (foundEnd >= 0)
                {
                    allIndexOfEnd[totFinds] = foundEnd;
                    totFinds++;
                    i = foundEnd;
                }
                else
                {
                    break;
                }
            }

            // Contains the Messagnumber
            String messagenumber = (bufferInput.Substring(allIndexOfBegin[0] + 6, allIndexOfBegin[1] - 6));

            checkForEnd = string.Concat(checkForEnd, messagenumber).Trim();
            found = 0;

            for (int i = 6; i < bufferInput.Length; i++)
            {
                found = bufferInput.IndexOf(checkForEnd, i);

                if (found >= 0)
                {
                    indexOfEnd = found;
                    i = found;
                }
                else
                {
                    break;
                }
            }

            // Contains the remaining Message after filtering messageID
            message = bufferInput.Substring(((allIndexOfBegin[1])), indexOfEnd - (allIndexOfBegin[1]));

            //check if there is another "begin:" in the remaining message
            if (message.Contains("begin:"))
            {




            }


            Contract.Ensures(bufferInput.LastIndexOf("begin:") < bufferInput.IndexOf("end:"));
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

        //***************************CONTROL*MANAGEMENT********************

        /// <summary>
        /// this method sends the extracted information
        /// </summary>
        public void opponentInfo(String type, String oppInfo)
        {
            Manager.Instance.opponentInfo(type, oppInfo);
        }

        /// <summary>
        /// this method sends the extracted information
        /// </summary>

        public void sendChallengeInfo(String type, String chInfo)
        {
            Manager.Instance.challengeInfo(type, chInfo);
        }

        /// <summary>
        /// this method sends the extracted information
        /// </summary>

        public void sendDragonInfo(String type, String dragonInfo)
        {
            Manager.Instance.dragonInfo(type, dragonInfo);
        }

        /// <summary>
        /// this method sends the extracted information
        /// </summary>

        public void sendPlayerInfo(String type, String playerInf)
        {
            Manager.Instance.playerInfo(type, playerInf);
        }

        /// <summary>
        /// this method sends the extracted entity
        /// </summary>

        public void sendEntitys(String type, String entity)
        {
            Manager.Instance.dragon(type, entity);

        }

        /// <summary>
        /// this method sends the extracted information
        /// </summary>

        public void sendMapCell(String type, String mapcells)
        {
            Manager.Instance.mapCellInfo(type, mapcells);
        }

        /// <summary>
        /// this method sends the extracted information
        /// </summary>

        public void sendMap(String type, String map)
        {
            Manager.Instance.mapInfo(type, map);
        }

        /// <summary>
        /// this method sends the extracted information
        /// </summary>

        public void sendMsg(String type, String message)
        {
            //Manager.Instance.msg(type, message);
        }

        /// <summary>
        /// this method sends the extracted information
        /// </summary>

        public void sendUpdate(String type, String update)
        {
            Manager.Instance.update(type, update);
        }

        /// <summary>
        /// this method sends the extracted information
        /// </summary>

        public void sendDelete(String type, Object o)
        {
            if (!(o is Dragon) || !(o is Player))
            {
                throw new NoValidMessageException("invalid object type for this method");
            }
            else
            {
                Manager.Instance.deleteInfo(d);
            }
        }

        /// <summary>
        /// this method sends the extracted information
        /// </summary>

        public void sendAnswer(String ans, String info)
        {
            Manager.Instance.anwerInfo(ans, info);
        }

        

        //public void sendMsgToListener(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        ////Message begin:upd
        //public void sendMsgToUpdater(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:del
        //public void sendMsgToBackend(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        ////Message begin:map
        //public void sendMsgToMap(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        ////Message begin:mes
        //public void sendMsgToMessenger(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        ////Message begin:result
        //public void sendMsgToResulter(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        ////Message begin:challenge
        //public void sendMsgToChallenger(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:players
        //public void sendMsgToPlayers(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:yourid
        //public void sendMsgToPlayer(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:time
        //public void sendMsgToBackend(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:online
        //public void sendMsgToBackend(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:ents
        //public void sendMsgToBackend(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:player
        //public void sendMsgToPlayer(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:server
        //public void sendMsgToUNKNOWN(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:<empty>
        //public void sendMsgToIGNORE(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:opponent
        //public void sendMsgToChallenger(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:dragon
        //public void sendMsgToDragon(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:cell
        //public void sendMsgToMap(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:ok
        //public void sendMsgToMessenger(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:unknown
        //public void sendMsgToUNKNOWN(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:no
        //public void sendMsgToMessenger(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

        //// Message begin:invalid
        //public void sendMsgToBackend(String Msg, bool isValid)
        //{
        //    Contract.Ensures(Msg.Length > 0);
        //    Contract.Ensures(isValid);
        //}

    }
}
