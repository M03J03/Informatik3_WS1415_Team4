using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDragonsAndRabbits
{
    [TestClass]
    public class UnitTestPlayer
    {
        [TestMethod]
        public void TestInitPlayer()
        {

            Player p1 = new Player();

            Assert.IsTrue(p1.getName != null);
            Assert.IsTrue(p1.getId() > 0);

        }
    }
}