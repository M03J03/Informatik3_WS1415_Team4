using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonsAndRabbits.Client;

namespace UnitTestDragonsAndRabbits
{
    [TestClass]
    public class UnitTestParser
    {
        [TestMethod]
        public void TestMethod1()
        {
            Parser p = new Parser();
            p.getInputFromBuffer("Something");
            Assert.IsTrue(p.getInput() != null);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Parser p = new Parser();
            p.analyzeBuffer("begins: end:");
            Assert.IsTrue(p.getInput().Equals("begins:"));
            Assert.IsTrue(p.getInput().Equals("ends:"));
            
        }

        [TestMethod]
        public void TestMethod3()
        {
            Parser p = new Parser();
            p.analyzeBuffer("Bullshit");
            Assert.IsFalse(p.getInput().Equals("begins:"));
            Assert.IsFalse(p.getInput().Equals("ends:"));

        }


        [TestMethod]
        public void TestMethod4()
        {
            Parser p = new Parser();
            p.analyzeBuffer("Bullshit");
            Assert.IsFalse(p.getInput().Equals("begins:"));
            Assert.IsFalse(p.getInput().Equals("ends:"));

        }
    }
}
