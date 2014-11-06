using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;

namespace Connector
{
    class Connector
    {

        private static readonly string server = "127.0.0.1";
        private static readonly Int32 port = 666;

        //private Buffer buffer = new Buffer();
        private static TcpClient client = null;

        private Receiever rec;
        private Sender sender;

        private bool connected = false;


        /// <summary>
        /// Generates a Connector - Objekt and the two objects of Reciever and Sender, too.
        /// </summary>
        public Connector()
        {
            rec = new Receiever();
            sender = new Sender();
            setIsConnected(true);
        }

        /// <summary>
        /// Set if the client is connected or not
        /// </summary>
        /// <param name="connected"></param>
        private void setIsConnected(bool connected)
        {
            this.connected = connected;
        }

        /// <summary>
        /// Get if client is connected or not.
        /// </summary>
        /// <returns></returns>
        private bool isConnected()
        {
            return connected;
        }

        /// <summary>
        /// interaction with server
        /// </summary>
        private void recieveFromServer()
        {
            rec.recieve();
        }

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        private void sendToServer(/* Buffer b*/)
        {
            sender.send("Somebody there????");
        }

        /// <summary>
        /// This method starts the interaction with the server.
        /// </summary>
        public void start()
        {
            while (isConnected())
            {
                Thread recieveThread = new Thread(new ThreadStart(recieveFromServer));
                recieveThread.Start();
                Console.WriteLine("RecieveThread is Running");
                Thread.Sleep(1000);
                Console.WriteLine("Thread is slepping");
                Thread sendThread = new Thread(new ThreadStart(sendToServer));
                Console.WriteLine("SendThread is Running");
                Thread.Sleep(1000);
                Console.WriteLine("Thread is slepping");
            }
        }


        /// <summary>
        /// Close the connection to the server
        /// </summary>
        public void closeConnection()
        {
            client.Close();
            setIsConnected(false);
            System.Console.WriteLine("I am death");
        }


        /// <summary>
        /// This class sends to the Server via a TCP connection
        /// </summary>
        class Sender
        {
            private TcpClient client;

            /// <summary>
            /// Generates a sender object.
            /// </summary>
            public Sender()
            {
                setTcpClient(server, port);
            }

            /// <summary>
            /// Sends a message to the server.
            /// </summary>
            /// <param name="message"></param>
            public void send(string message)
            {
                try
                {
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Sends: {0}", message);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("ArgumentNullException: {0}", e);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
            }

            /// <summary>
            /// Sets the TcpClient - Object
            /// </summary>
            /// <param name="server"></param>
            /// <param name="port"></param>
            private void setTcpClient(String server, Int32 port)
            {
                client = new TcpClient(server, port);
            }

            /// <summary>
            /// Gets the TcpClient
            /// </summary>
            /// <returns></returns>
            public TcpClient getTcpClient()
            {
                return client;
            }
        }

        /// <summary>
        /// Recieves the response from the server
        /// </summary>
        class Receiever
        {
            private TcpClient client;

            public Receiever()
            {
                setTcpClient(server, port);
            }

            /// <summary>
            /// Sets the TcpClient - Object
            /// </summary>
            /// <param name="server"></param>
            /// <param name="port"></param>
            private void setTcpClient(String server, Int32 port)
            {
                client = new TcpClient(server, port);
            }

            /// <summary>
            /// Gets the TcpClient
            /// </summary>
            /// <returns></returns>
            public TcpClient getTcpClient()
            {
                return client;
            }

            /// <summary>
            /// Recieve the respone of the server
            /// </summary>
            /// <returns></returns>
            public string recieve()
            {
                String responseData = null;

                try
                {
                    // Receive the TcpServer.response. 
                    // Buffer to store the response bytes.
                    Byte[] data = new Byte[256];

                    // Get a client stream for writing. 
                    NetworkStream stream = client.GetStream();

                    // String to store the response ASCII representation.
                    responseData = String.Empty;

                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("ArgumentNullException: {0}", e);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
                return responseData;
            }
        }


        /// <summary>
        /// Main - Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(String[] args)
        {
            Connector con = new Connector();
            con.start();
            System.Console.ReadLine();
        }
    }
}
