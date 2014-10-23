using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonsAndRabbits.Client;

namespace UnitTestDragonsAndRabbits
{
    [TestClass]
    class UnitTestDragon
    {
        [TestMethod]
        public void TestMethodsDragon()
        {
            Dragon dragon = new Dragon();

            Player p1 = new Player();
            Player p2 = new Player();

            dragon.stagHunt(p1, p2);

            Assert.IsTrue(dragon.getFirstPlayer() != null);
            Assert.IsTrue(dragon.getSecondPlayer() != null);
            Assert.IsTrue(p1.getId() > 0);
            Assert.IsTrue(p2.getName().Length > 3);
        }
    }
}
