using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.Sockets;
using DragonsAndRabbits.Exceptions;


namespace DragonsAndRabbits.Client
{
   public class Connector
    {
        private Socket s = null;
        private Buffer b = null;
        private string ip = null;
        private int port = 0;
        private bool connected = false;
        private string message;

       /// <summary>
       /// Generates aconnector object mit the commited parameters.
       /// </summary>
       /// <param name="ip"></param>
       /// <param name="port"></param>
        public Connector(String ip, int port)
        {
            login(ip, port);
        }

        /// <summary>
        /// gets the message
        /// </summary>
        /// <returns></returns>
        public String getMessage()
        {
            return message;
        }

        /// <summary>
        /// sets the message
        /// </summary>
        /// <param name="message"></param>
        private void setMessage(String message)
        {
            this.message = message;
        }
              
        /// <summary>
        /// return if the client is connected or not
        /// </summary>
        /// <returns></returns>
        public bool isConnected()
        {
            return connected;
        }

        /// <summary>
        /// sets the parameter ture or false
        /// </summary>
        /// <param name="connected"></param>
        private void setConnected(bool connected)
        {
            this.connected = connected;
        }

        //This method make the connection to the server.
        public void login(String ip, int port)
        {
            Contract.Requires(ip != null && (ip.Length <= 16 && ip.Length >= 7));
            Contract.Requires(port > 0 && port <= 65535);

            if ((ip == null || (ip.Length < 7 || ip.Length > 16)) && (port <= 0 || port > 65535))
            {
                throw new Exception("The ip is null or not long enough or the portnumber is smaller than 0 or bigger than 65535");
            }
            else
            {
                this.ip = ip;
                this.port = port;
                setConnected(true);
            }

            Contract.Ensures(ip != null && (port > 0 && port <= 65535));
        }

        /// <summary>
        /// gets the ip
        /// </summary>
        /// <returns></returns>
        public string getIP()
        {
            if (!(isConnected()))
            {
                throw new NotConnectedException("The client is not connected with the server!");
            }
            return ip;
            Contract.Ensures(ip != null && (ip.Length <= 16 && ip.Length >= 7)); //<-- only != null when method login is activated
        }

        /// <summary>
        /// gets the portNumber.
        /// </summary>
        /// <returns></returns>
        public int getPort()
        {
            if (!(isConnected()))
            {
                throw new NotConnectedException("The client is not connected with the server!");
            }

            return port;
            Contract.Ensures(port > 0 && port <= 65535); //<-- only not 0 when method login is activated
        }

        /// <summary>
        /// Method recieve messages from the server
        /// </summary>
        /// <param name="message"></param>
        public void recieveFromServer(String message)
        {
            Contract.Requires(message.Length >= 9); //length of message consists of the length of the word begin + blank + the length of the word end

            if (message.Length < 9)
            {
                throw new NoValidMessageExcecption("The recieved message have to be at least 9 signs long");
            }
            else
            {
                setMessage(message);
            }
            Contract.Ensures(message.Length >= 9);
        }

        /// <summary>
        /// Method to send the recieved message into the buffer class. This method is running in a thread
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buff"></param>
        public void sendToBuffer(String message, Buffer buff)
        {
            Contract.Requires(message.Length >= 9);
            Contract.Requires(buff != null);

            if (message.Length < 9)
            {
                throw new NoMessageException("The recieved message have to be at least 9 signs long");
            }
            else
            {
                this.b = buff;
                if (b.isEmpty())
                {
                    //do some stuff
                }
            }
            Contract.Ensures(buff != null && message.Length >= 9);
        }

        /// <summary>
        /// this method send the message to the server. This method gets the parsed message from the parser and sneds it to server.
        /// </summary>
        /// <param name="message"></param>
        public void sendToServer(String message)
        {
            Contract.Requires(message.Length >= 9);
            if (message.Length < 9)
            {
                throw new NoMessageException("The recieved message have to be at least 9 signs long");
            }
            else
            { 
                //do some stuff
            }
            Contract.Ensures(message.Length != 9);
        }
    }
}
