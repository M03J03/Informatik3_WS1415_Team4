using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using DragonsAndRabbits.GUI;
using DragonsAndRabbits.Client;
using DragonsAndRabbits.Exceptions;

namespace Connector
{
    public class Connector
    {

        private static readonly string server = "127.0.0.1";
        private static readonly Int32 port = 666;


        //private DragonsAndRabbits.Client.Buffer buffer = DragonsAndRabbits.Client.Buffer.Instance;
        private static TcpClient client = null;

        private Receiever rec;
        private Sender sender;

        private static bool connected = false;


        /// <summary>
        /// Generates a Connector - Objekt and the two objects of Reciever and Sender, too.
        /// </summary>
        public Connector()
        {           
            rec = new Receiever();
            sender = new Sender();
            connected = true;
        }

        /// <summary>
        /// Set if the client is connected or not
        /// </summary>
        /// <param name="connected"></param>


        /// <summary>
        /// Get if client is connected or not.
        /// </summary>
        /// <returns></returns>
        private static bool isConnected()
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
        private void sendToServer()
        {
            sender.send("get:map");
        }

        /// <summary>
        /// This method starts the interaction with the server.
        /// </summary>
        public void start()
        {
            Thread recieveThread;
            Thread sendThread;
            try
            {
                sendThread = new Thread(new ThreadStart(sendToServer));
                sendThread.Start();
                recieveThread = new Thread(new ThreadStart(recieveFromServer));
                recieveThread.Start();
            }
            catch (ArgumentNullException er)
            {
                Console.WriteLine("Thread ist tod");
            }

            //Console.WriteLine("RecieveThread is Running");
            //Thread.Sleep(100);
            //Console.WriteLine("Thread is slepping");
            //Thread sendThread = new Thread(new ThreadStart(sendToServer));
            //sendThread.Start();
            //Thread.Sleep(100);
            //Console.WriteLine("Thread is slepping");

        }


        /// <summary>
        /// Close the connection to the server
        /// </summary>
        public void closeConnection()
        {
            client.Close();
            connected = false;
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
                    if (message == null)
                    {
                        throw new System.ArgumentNullException("parameter cannot be null");
                    }
                    else if (message.Length < 1)
                    {
                        throw new System.ArgumentException("parameter length cannot be < 1");
                    }
                    else
                    {
                        Byte[] data = Encoding.UTF8.GetBytes(message + "\r\n");
                        client.GetStream().Write(data, 0, data.Length);
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
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
                try
                {
                    client = new TcpClient(server, port);
                }
                catch (SocketException er)
                {
                    System.Console.WriteLine("Could not establish the connection. It may be offline!" + er.Message);
                }
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
                while (isConnected())
                {
                    Console.WriteLine("method recieve is running");
                    try
                    {
                        // Receive the TcpServer.response. 
                        // Buffer to store the response bytes.
                        Byte[] data = new Byte[256];

                        // Get a client stream for writing. 
                        NetworkStream stream = client.GetStream();

                        // String to store the response UTF8 representation.
                        responseData = String.Empty;

                        // Read the first batch of the TcpServer response bytes.
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes);

                        responseData = responseData.Trim();


                        Console.WriteLine("Received: {0}", responseData);

                        DragonsAndRabbits.Client.Buffer.Instance.addMessage(responseData);
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
            GUI gui = new GUI();
            System.Console.ReadLine();

        }
         
    }
}
