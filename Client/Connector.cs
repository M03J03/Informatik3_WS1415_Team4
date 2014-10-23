using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.Sockets;


namespace DragonsAndRabbits.Client
{
   public class Connector
    {
        private Socket s = null;
        private Buffer b = null;
        private string ip = null;
        private int port = 0;

        //This method make the connection to the server.
        public void login(String ip, int port)
        {
            Contract.Requires(ip != null && (ip.Length <= 16 && ip.Length >= 7));
            Contract.Requires(port > 0 && port <= 65535);
            Contract.Ensures(ip != null && (port > 0 && port <= 65535));

            if (ip == null || (ip.Length < 7 || ip.Length > 16))
            {
                throw new Exception("The ip is null");
            }
            else
            {
                this.ip = ip;
            }

            if (port <= 0 || port > 65535)
            {
                throw new Exception("Wrong Portnumber please insert a number between 1 and 65535");
            }
            else 
            {
                this.port = port;
            }
        }

       //Gets the ip
        public string getIP()
        {
            Contract.Ensures(ip != null && (ip.Length <= 16 && ip.Length >= 7)); //<-- only != null when method login is activated
            return ip;
        }

       //gets the porNumber
        public int getPort()
        {
            Contract.Ensures(port > 0 && port <= 65535); //<-- only not 0 when method login is activated
            return port;
        }

        //Method to recieve messages from the server
        public void recieveFromServer(String message)
        {
            Contract.Requires(message.Length >= 9); //length of message consists of the length of the word begin + blank + the length of the word end
            Contract.Ensures(message.Length >= 9);
        }

        //Method to send the recieved message into the buffer class. This method is running in a thread
        public void sendToBuffer(String message, Buffer buff)
        {
            Contract.Requires(message.Length >= 9);
            Contract.Requires(buff != null);
            Contract.Ensures(buff != null && message.Length >= 9);
        }

        //this method send the message to the server. This method gets the parsed message from the parser and sneds it to server.
        public void sendToServer(String message)
        {
            Contract.Requires(message.Length >= 9);
            Contract.Ensures(message.Length != 9);
        }
    }
}
