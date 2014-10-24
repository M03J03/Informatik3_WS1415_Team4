using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonsAndRabbits.Client;

namespace UnitTestDragonsAndRabbits
{
    [TestClass]
    public class UnitTestParser
    {
        [TestMethod]
        public void TestMethodGetInputFromBuffer()
        {
            Parser p = new Parser();
            p.getInputFromBuffer("Something");
            Assert.IsTrue(p.getInput() != null);
        }

        [TestMethod]
        public void TestMethodAnalyzeBuffer()
        {
            Parser p = new Parser();
            p.analyzeBuffer("begins: end:");
            Assert.IsTrue(p.getInput().Equals("begins:"));
            Assert.IsTrue(p.getInput().Equals("ends:"));
            
        }

        [TestMethod]
        public void TestMethodAnalyzeBuffer()
        {
            Parser p = new Parser();
            p.analyzeBuffer("Bullshit");
            Assert.IsFalse(p.getInput().Equals("begins:"));
            Assert.IsFalse(p.getInput().Equals("ends:"));

        }


        [TestMethod]
        public void TestMethodCheckMsg()
        {
            Parser p = new Parser();
            String[] testString = { "begin: begin:server ver:5 end:server", "begin: begin:server ver:5 end:server", "begin: begin:server ver:5 end:server" };
            
            Assert.IsTrue((p.checkMsg(testString).Length >= 0);
            Assert.IsFalse(p.getInput().Equals("ends:"));

        }

         [TestMethod]
        public void TestMethodSendMsgToListener()
        {

        }

         //Message begin:upd
        [TestMethod]
        public void TestMethodSendMsgToUpdater()
        {

        }

        // Message begin:del
        [TestMethod]
        public void TestMethodSendMsgToBackend()
        {

        }

        //Message begin:map
        [TestMethod]
        public void TestMethodSendMsgToMap()
        {

        }

        //Message begin:mes
        [TestMethod]
        public void TestMethodSendMsgToMessenger()
        {
            
        }

        //Message begin:result
        [TestMethod]
        public void TestMethodsendMsgToResulter()
        {
          
        }

        //Message begin:challenge
        [TestMethod]
        public void TestMethodSendMsgToChallenger()
        {

        }

        // Message begin:players
        [TestMethod]
        public void TestMethodSendMsgToPlayers()
        {

        }

        // Message begin:yourid
        [TestMethod]
        public void TestMethodSendMsgToPlayer()
        {
      
        }

        // Message begin:time
        [TestMethod]
        public void TestMethodSendMsgToBackend()
        {

        }

        // Message begin:online
        [TestMethod]
        public void TestMethodSendMsgToBackend()
        {

        }

        // Message begin:ents
        [TestMethod]
        public void TestMethodSendMsgToBackend()
        {

        }

        // Message begin:player
        [TestMethod]
        public void TestMethodsendMsgToPlayer()
        {
   
        }

        // Message begin:server
        [TestMethod]
        public void TestMethodSendMsgToUNKNOWN()
        {

        }

        // Message begin:<empty>
        [TestMethod]
        public void TestMethodSendMsgToIGNORE()
        {

        }

        // Message begin:opponent
        [TestMethod]
        public void TestMethodSendMsgToChallenger()
        {

        }

        // Message begin:dragon
        [TestMethod]
        public void TestMethodSendMsgToDragon()
        {

        }

        // Message begin:cell
        [TestMethod]
        public void TestMethodSendMsgToMap()
        {

        }

        // Message begin:ok
        [TestMethod]
        public void TestMethodSendMsgToMessenger()
        {

        }

        // Message begin:unknown
        [TestMethod]
        public void TestMethodSendMsgToUNKNOWN()
        {

        }

        // Message begin:no
        [TestMethod]
        public void TestMethodSendMsgToMessenger()
        {

        }

        // Message begin:invalid
        [TestMethod]
        public void TestMethodsendMsgToBackend()
        {

        }

    }
}
