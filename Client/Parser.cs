using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using System.Threading;
using DragonsAndRabbits.Exceptions;
using DragonsAndRabbits.Client;
using DragonsAndRabbits.Manager;
using System.Text.RegularExpressions;

namespace DragonsAndRabbits.Client
{
    public class Parser
    {
        private Manager.Manager mgr = Manager.Manager.getManger();
        private Buffer refToBuffer;
        private Thread fred;
        private List<MapCell> cells;
        private List<Player> players;
      
        public Parser()
        {
            refToBuffer = Buffer.Instance;
            Console.WriteLine("PARSER INIT");
            fred = new Thread(new ThreadStart(getInputFromBuffer));
           // fred.IsBackground = true;
            fred.Start();
          //  getInputFromBuffer();
        }


        
        private void getInputFromBuffer()
        {

           // Contract.Requires(refToBuffer->Length > 0);
            Console.WriteLine("PARSER TAKES MESSAGE");
            if (!refToBuffer.isEmpty())
            {
                analyzeBuffer(refToBuffer.getMessage());

            }
            else
            {   Console.WriteLine("BUFFER EMPTY - PARSER SLEEPS");
            Thread.CurrentThread.Abort();
                
                
            }
          //  Contract.Ensures(inputFromBuffer.Length > 0);
        }
        /// <summary>
        /// Filter begin:<int> CONTENT> end:<int>
        /// </summary>
        /// <param name="bufferInput"></param>
        public void analyzeBuffer(String bufferInput)
        {
            Contract.Requires(bufferInput.Contains("begin:"));
            Contract.Requires(bufferInput.Contains("end:"));
            // Contract.Requires(bufferInput.LastIndexOf("begin:") < bufferInput.IndexOf("end:")); INCORRECT because begin:foo begin:fuu end:fuu begin:test end:test would be incorrect

         //   Console.WriteLine("DA MESSAGE -----> " + bufferInput);
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
            beginIndex = bufferInput.IndexOf("begin:", 0);
            newLineIndexOfBegin = bufferInput.IndexOf(Environment.NewLine, beginIndex);
            getMessageCode = bufferInput.Substring((beginIndex + 6), newLineIndexOfBegin - (beginIndex + 6)).Trim();
            //Console.WriteLine("MOEBegin at:" + beginIndex);
            //  Console.WriteLine("MOEMessageCode: " + getMessageCode);
            endMessageCode = "end:" + getMessageCode;
            endIndex = bufferInput.IndexOf(endMessageCode);
            newLineIndexOfEnd = bufferInput.IndexOf(Environment.NewLine, endIndex);

            result = bufferInput.Substring(newLineIndexOfBegin + Environment.NewLine.Length, (bufferInput.Length - (newLineIndexOfBegin + Environment.NewLine.Length) - (endMessageCode.Length+Environment.NewLine.Length)));
            //result = bufferInput.Substring(newLineIndexOfBegin + Environment.NewLine.Length,(bufferInput.Length - newLineIndexOfBegin + Environment.NewLine.Length - (endMessageCode.Length) - (Environment.NewLine.Length)));

            //Console.WriteLine("FILTERED MESSAGE -----> " + result);

            checkMsg(result);


            

            Contract.Ensures(bufferInput.LastIndexOf("begin:") < bufferInput.IndexOf("end:"));
        }

        public void checkMsg(String msgs)
        {
            Contract.Requires(msgs.Length >= 0);
            Contract.Ensures(msgs.Length >= 0);
            /*
           begin:upd
            begin:dragon
            id:2
            type:Dragon
            busy:false
            desc:Dragon
            x:3
            y:16
            end:dragon
            end:upd
            */
          
              switchTheBegins(msgs);

        }


        public void switchTheBegins(String msgs)
        {
            string tmp = GetInstanceVar(msgs);

             switch(tmp){
                case "server": {  doServer(msgs.Substring(6+tmp.Length+Environment.NewLine.Length,msgs.Length-(6+tmp.Length+Environment.NewLine.Length))); break; }
                case "result": { doResult(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "opponent": {  doOpponent(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "challenge": { doChallenge(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "dragon": {  doDragon(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "player": { doPlayer(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "players": { doPlayers(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "ents": { doEntities(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }  
                case "cell": { doCell(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "map": {  doMap(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }        
                case "mes": {  doMessage(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "upd": {  doUpdate(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "del": {  doUpdate(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "yourid": {  doYourId(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "time": {  doTime(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "online": {  doOnline(msgs.Substring(6 + tmp.Length + Environment.NewLine.Length, msgs.Length - (6 + tmp.Length + Environment.NewLine.Length))); break; }
                case "failure": { Console.WriteLine("ATTENTION - Something went wrong");break; }
            }

        }


        public String GetInstanceVar(String msg)
        {
            int beginIndex = 0;
            int newLineIndexOfBegin;
            String getInstanceVar;

            // get the First MessageCode
            beginIndex = msg.IndexOf("begin:", 0);

            if (beginIndex >= 0)
            {

                newLineIndexOfBegin = msg.IndexOf(Environment.NewLine, beginIndex);

                getInstanceVar = msg.Substring(beginIndex + 6, newLineIndexOfBegin - (beginIndex + 6));
            }
            else
            {
                getInstanceVar = "failure";
            }

            return getInstanceVar;

        }

        private void doServer(String msg)
        {
            Console.WriteLine("I AM IN SERVER");
            Console.WriteLine("GOT FOLLOWING MESSAGE: " + msg);
            int theVerIndex = 0;
            int theVerNewLineIndex = 0;
            theVerIndex = msg.IndexOf("ver:")+4;
            theVerNewLineIndex = msg.IndexOf(Environment.NewLine,theVerIndex);

                // Call the equivalent Method from Manager
           // Manager.getManger().server(Convert.ToInt32(msg.Substring(theVerIndex,theVerNewLineIndex - theVerIndex)));

       
        }

        private void doResult(String msg)
        {
            Console.WriteLine("I AM IN RESULT");
            // RESULT: "begin:result","round:",INT,"running:",BOOLEAN,"delay:",INT,"begin:opponents",OPPONENT,OPPONENT","end:opponents","end:result"
            int round = 0;
            bool running = false;
            int delay = 0;

            int myVarIndex;
            int myNewLineIndex;


            myVarIndex = msg.IndexOf("round:") + "round:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            round = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("running:",myNewLineIndex) + "running:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            running = Convert.ToBoolean(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("delay:") + "delay:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            delay = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            //INIT  2 OPPONENTS



        }

        private void doOpponent(String msg)
        {
            Console.WriteLine("I AM IN OPPONENT");
            int id = 0;
            string decision = "";
            int points = 0;
            int total = 0;

            int myVarIndex;
            int myNewLineIndex;


            myVarIndex = msg.IndexOf("id:") + "id:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            id = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("decision:", myNewLineIndex) + "decision:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            decision = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            myVarIndex = msg.IndexOf("points:", myNewLineIndex) + "points:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            points = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("total:", myNewLineIndex) + "total:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            total = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            // Call the equivalent Method from Manager
            //Manager.getManager().opponent(id, decision, points, total)

        }

        private void doChallenge(String msg)
        {
            Console.WriteLine("I AM IN CHALLENGE");

            int id = 0;
            String type = "";
            bool accepted = false;

            int myVarIndex;
            int myNewLineIndex;


            myVarIndex = msg.IndexOf("id:") + "id:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            id = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("type:", myNewLineIndex) + "type:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            type = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            myVarIndex = msg.IndexOf("accepted:", myNewLineIndex) + "accepted:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            accepted = Convert.ToBoolean(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));


            // Call the equivalent Method from Manager
            //Manager.getManager().challenge(id, type, accepted)

        }

        private void doDragon(String msg)
        {
            Console.WriteLine("I AM IN DRAGON");

            // begin:dragon", "id:",INT,"type:Dragon","busy:"BOOLEAN,"desc:"STRING,"x:",INT,"y:",INT,"end:dragon"
            int id = 0;
            String type = "";
            bool busy = false;
            String desc = "";
            int x = 0;
            int y = 0;

            int myVarIndex;
            int myNewLineIndex;

            myVarIndex = msg.IndexOf("id:") + "id:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            id = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("type:", myNewLineIndex) + "type:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            type = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            myVarIndex = msg.IndexOf("busy:", myNewLineIndex) + "busy:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            busy = Convert.ToBoolean(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("desc:", myNewLineIndex) + "desc:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            desc = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            myVarIndex = msg.IndexOf("x:", myNewLineIndex) + "x:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            x = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("y:", myNewLineIndex) + "y:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            y = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));


            // Call the equivalent Method from Manager
            //Manager.getManager().dragon(id,  type, busy, desc, x, y)

            Console.WriteLine("Creating Dragon with id:" + id + " type:" + type + " busy:" + busy.ToString() + " desc:" + desc + " X:" + x + " Y:" + y );

       
        }

        private void doPlayer(String msg)
        {
            //"begin:player","id:",INT,"type:Player","busy:"BOOLEAN,"desc:"STRING,"x:",INT,"y:",INT,"points:",INT"end:player"
            Console.WriteLine("I AM IN PLAYER");
            int id = 0;
            String type = "";
            Boolean busy = false;
            String desc = "";
            int x = 0;
            int y = 0;
            int points = 0;

            int myVarIndex;
            int myNewLineIndex;



            myVarIndex = msg.IndexOf("id:") + "id:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            id = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("type:", myNewLineIndex) + "type:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            type = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            myVarIndex = msg.IndexOf("busy:", myNewLineIndex) + "busy:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            busy = Convert.ToBoolean(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("desc:", myNewLineIndex) + "desc:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            desc = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            myVarIndex = msg.IndexOf("x:", myNewLineIndex) + "x:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            x = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("y:",myNewLineIndex) + "y:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            y = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("points:", myNewLineIndex) + "points:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            points = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            // Call the equivalent Method from Manager
            //Manager.getManager().player(id, type, busy, desc, x, y, points);

            Console.WriteLine("Creatin Player with id:" + id + " type:" + type + " busy:" + busy.ToString() + " desc:" + desc + " X:" + x + " Y:" + y + " Points: " + points);

    
        }

        private void doPlayers(String msg)
        {
            Console.WriteLine("I AM IN PLAYERS");

            players = new List<Player>();
            while (msg.Length > 0)
            {

                doPlayerInPlayers(msg);
                //msg.Remove() The send message to doPlayerInPlayers
            }
            // Call the equivalent Method from Manager
            //Manager.getManager().players(players);

    
        }

        private void doEntities(String msg)
        {
            Console.WriteLine("I AM IN ENTITIES");
            switchTheBegins(msg);
          
        }

        private void doCell(String msg)
        {
            Console.WriteLine("I AM IN CELL");
            // MAPCELL: "begin:cell","row:",INT,"col:",INT,"begin:props",{PROPERTY},"end:props","end:cell"

            int row = 0;
            int col = 0;
            List<String> props;

            int myVarIndex;
            int myNewLineIndex;

            myVarIndex = msg.IndexOf("row:") + "row:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            row = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("col:") + "col:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            col = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            Console.WriteLine("DOCELL ->  " + msg);
            // Sends all properties to the property handler so we get a List of properties returned
           props = doProperties(msg.Substring(msg.IndexOf("begin:props"+"begin:props".Length+Environment.NewLine.Length),msg.IndexOf("end:props",msg.IndexOf("begin:props"))-("begin:props".Length+Environment.NewLine.Length+"col:".Length+col.ToString().Length+Environment.NewLine.Length+"row:".Length+row.ToString().Length+Environment.NewLine.Length))) ;

           // Call the equivalent Method from Manager
          mgr.getMapCell(row, col, props);    // !!! WARNING THIS IS A LIST AND NOT CONFORM WITH MANAGER CLASS, GOTTA BE CHANGED IN MANAGER

       
        }

        private void doMap(String msg)
        {
            Console.WriteLine("I AM IN MAP");
            // MAP: "begin:map","width:"INT,"height:",INT,"begin:cells",{MAPCELL},"end:cells","end:map"
            int width = 0;
            int height = 0;
            cells = new List<MapCell>();

            int myVarIndex;
            int myNewLineIndex;

            myVarIndex = msg.IndexOf("width:") + "width:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            width = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("height:",myNewLineIndex) + "height:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            height = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            doCellInMap(msg);

            // Call the equivalent Method from Manager
            //Manager.getManager().map( width, heigth, cells)

        
        }

        private void doMessage(String msg)
        {
            Console.WriteLine("I AM IN MESSAGE");
            // "begin:mes","srcid:",INT,"src:",STRING,"txt:",STRING,"end:mes"

            int srcId = 0;
            string src = "";
            string txt = "";


            int myVarIndex;
            int myNewLineIndex;

            myVarIndex = msg.IndexOf("srcid:") + "srcid:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            srcId = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("src:", myNewLineIndex) + "src:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            src = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            myVarIndex = msg.IndexOf("txt:", myNewLineIndex) + "txt:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            txt = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            // Call the equivalent Method from Manager
            //Manager.getManager().message(srcId, src , txt)    // !!! WARNING THIS IS NOT CONFORM WITH MANAGER CLASS, GOTTA BE CHANGED IN MANAGER -> 3 PARAMS!

        }

        private void doUpdate(String msg)
        {
            Console.WriteLine("I AM IN UPDATE");
            switchTheBegins(msg);

          

            // GOTTA CHECK WHY THIS WONT WORK
  //int endUpdIndex = msg.IndexOf("end:upd")+ "end:upd".Length;
   //         int newLineAtEnd = 0;
           // if ((msg.IndexOf(Environment.NewLine, endUpdIndex-1)) >= 0)
           // {
           //     newLineAtEnd = Environment.NewLine.Length;
           // }

        //    return msg.Remove(0, (msg.IndexOf("end:upd") + "end:upd".Length + newLineAtEnd ));
        }

        private void doDelete(String msg)
        {
            Console.WriteLine("I AM IN DELETE");
           //switchTheBegins(msg);
          
        }

        private void doYourId(String msg)
        {
            Console.WriteLine("I AM IN YOURID");
            // "begin:yourid",INT,"end:yourid"
            int yourId = 0;

            int myVarIndex;
            int myNewLineIndex;

            myVarIndex = msg.IndexOf("yourid:") + "yourid:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            yourId = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            // Call the equivalent Method from Manager
            //Manager.getManager().yourID(yourid);

          
        }

        private void doTime(String msg)
        {
            Console.WriteLine("I AM IN TIME");
            // TIME: "begin:time",LONG,"end:time"
            long time;
            int myVarIndex;
            int myNewLineIndex;

            myVarIndex = msg.IndexOf("time:") + "time:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            time = Convert.ToInt64(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            // Call the equivalent Method from Manager
            //Manager.getManager().time(time);
   
        }

        private void doOnline(String msg)
        {
            Console.WriteLine("I AM IN ONLINE");
            // ONLINE: "begin:online",INT,"end:online"
            int online = 0;
            int myVarIndex;
            int myNewLineIndex;

            myVarIndex = msg.IndexOf("online:") + "online:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            online= Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            // Call the equivalent Method from Manager
            //Manager.getManager().online (online);
        }

        private List<String> doProperties(String msg)
        {
            Console.WriteLine("I AM IN PROPS");
            
            int myVarIndex;
            int myNewLineIndex;
            List <String> propList = new List<string>();

            string message = msg;
           
            myVarIndex = 0;
            Console.WriteLine("PROPS MSG  " + msg);
            do
            {
                myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
                propList.Add(msg.Substring(myVarIndex, myNewLineIndex));

                message = msg.Remove(myVarIndex, myNewLineIndex+Environment.NewLine.Length);
            } while (message.Length > 0);

            return propList; 
        }


        private void doCellInMap(String msg)
        {
            Console.WriteLine("I AM IN CELL");
            // MAPCELL: "begin:cell","row:",INT,"col:",INT,"begin:props",{PROPERTY},"end:props","end:cell"

            int row = 0;
            int col = 0;
            List<String> props;

            int myVarIndex = 0 ;
            int myNewLineIndex = 0;

            while (msg.IndexOf("row:",myVarIndex) >= 0) {
            myVarIndex = msg.IndexOf("row:") + "row:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            row = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("col:") + "col:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            col = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            // Sends all properties to the property handler so we get a List of properties returned
            props = doProperties(msg.Substring(msg.IndexOf("begin:props" + "begin:props".Length + Environment.NewLine.Length), msg.IndexOf("end:props", msg.IndexOf("begin:props")) - ("begin:props".Length + Environment.NewLine.Length)));

            cells.Add(new MapCell(row,col,props));
            }

        }

        private void doPlayerInPlayers(String msg)
        {
            Console.WriteLine("I AM IN PLAYER");
            int id = 0;
            String type = "";
            Boolean busy = false;
            String desc = "";
            int x = 0;
            int y = 0;
            int points = 0;

            int myVarIndex;
            int myNewLineIndex;



            myVarIndex = msg.IndexOf("id:") + "id:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            id = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("type:", myNewLineIndex) + "type:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            type = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            myVarIndex = msg.IndexOf("busy:", myNewLineIndex) + "busy:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            busy = Convert.ToBoolean(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("desc:", myNewLineIndex) + "desc:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            desc = msg.Substring(myVarIndex, myNewLineIndex - myVarIndex);

            myVarIndex = msg.IndexOf("x:", myNewLineIndex) + "x:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            x = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("y:", myNewLineIndex) + "y:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            y = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            myVarIndex = msg.IndexOf("points:", myNewLineIndex) + "points:".Length;
            myNewLineIndex = msg.IndexOf(Environment.NewLine, myVarIndex);
            points = Convert.ToInt32(msg.Substring(myVarIndex, myNewLineIndex - myVarIndex));

            //Player: int id, String name, bool busy, int row, int column
           // players.Add(new Manager.Player(id,type,busy,x,y,points));

        }


    }
}
