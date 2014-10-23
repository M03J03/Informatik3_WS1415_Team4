using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.Sockets;


namespace DragonsAndRabbits.Client {
    class Connector {
        Socket s;
        Buffer b;

        //This method make the connection to the server.
        public void login(String ip, int port) {
            Contract.Requires(ip != null && ip.Length <= 16);
            Contract.Requires(port > 0 && port <= 65535); 
        }


        public void recieveFromServer(String message) { 
        
        }

        public void sendToBuffer(String message, Buffer buff) { 
        
        }


        public void sendToServer(String message) { 
        
        }

    }
}
