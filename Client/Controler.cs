using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DragonsAndRabbits.Client;
using System.Diagnostics.Contracts;

namespace DragonsAndRabbits.Client {
    public class Controler {

        private ClientGUI gui = null;
        private Player player = null;
        private string message;

        //Constructor get a static v
        public Controler(ClientGUI gui) {
            this.gui = gui;
        }

        public Controler()
        {
            // TODO: Complete member initialization
        }

        //Gets the message
        public string getMessage() {
            return message;
        }

        //This method is responsible to let the player move left.
        public void moveLeft() {
            Contract.Ensures(player != null);
        }

        //This method is responsible to let the player move rigth
        public void moveRigth() {
            Contract.Ensures(player != null);
        }

        // this method is responsible to let the player move up
        public void moveUp() {
            Contract.Ensures(player != null);
        }

        // this method is responsible to let the player move down
        public void moveDown() {
            Contract.Ensures(player != null);
        }

        //this method let attack a player
        public void attack() {
            Contract.Ensures(player != null);
        }

        // this Method sends the written message in the chat box to the server.
        public void sendMessage(string message) {
            Contract.Requires(message.Length > 0);
            Contract.Ensures(message.Length > 0);
            this.message = message;
        }

        // this method gets the written messages from other player to show the on the chatbox. This methos is running in a Thread.
        public void revieveMessage() {
        
        }
    }
}
