using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonsAndRabbits.Client;

namespace UnitTestDragonsAndRabbits
{
    [TestClass]
    public class UnitTestConnector
    {
        [TestMethod]
        public void TestMethodLogin()
        {
            Connector c = new Connector();
            c.login("0.0.0.0", 5);
            System.Diagnostics.Debug.WriteLine(c.getIP());
            System.Diagnostics.Debug.WriteLine(c.getPort());
            Assert.IsTrue(c.getIP() != null);
            Assert.IsTrue(c.getPort() > 0 && c.getPort() <= 65535);
        }
    }
}
