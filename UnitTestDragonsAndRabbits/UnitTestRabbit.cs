using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonsAndRabbits.Client;
namespace UnitTestDragonsAndRabbits
{
    [TestClass]
    public class UnitTestRabbit
    {
        [TestMethod]
        public void TestMethodStagHunt()
        {
            Player p1 = new Player();
            Player p2 = new Player();
            Rabbit r = new Rabbit();

            Assert.IsTrue(p1.isBusy());
            Assert.IsTrue(p2.isBusy());
            Assert.IsTrue(p1.getXCoordinate() == p2.getXCoordinate());
            Assert.IsTrue(p1.getYCoordinate() == p2.getYCoordinate());
        }
    }
}
