using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonsAndRabbits.Client;
namespace UnitTestDragonsAndRabbits
{
    [TestClass]
    public class UnitTestController
    {
        [TestMethod]
        public void TestMethodSendMessage()
        {
            Controler c = new Controler();
            c.sendMessage("Something");
            Assert.IsTrue(c.getMessage() != null);
        }
    }
}
