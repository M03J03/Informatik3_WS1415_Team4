using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonsAndRabbits.Client;

namespace UnitTestDragonsAndRabbits
{
    [TestClass]
    public class UnitTestBuffer
    {


        [TestMethod]

        //this test ensures that there IS a buffer #1Test 
        public void TestInitBuffer()
        {
            DragonsAndRabbits.Client.Buffer buffer = new DragonsAndRabbits.Client.Buffer();
            Assert.IsTrue(buffer != null && buffer is DragonsAndRabbits.Client.Buffer);

        }

        //this method ensures, that the transfer from Connector to Buffer works...
        public void TestBufferAddMethod()
        {
            DragonsAndRabbits.Client.Buffer buffer = new DragonsAndRabbits.Client.Buffer();
            buffer.addMessage("hello");
            Assert.IsFalse(buffer.isEmpty());


        }

        public void TestBufferGetMethod()
        {
            DragonsAndRabbits.Client.Buffer buffer = new DragonsAndRabbits.Client.Buffer();
            buffer.addMessage("hello");

            String local = buffer.getMessage();
            Assert.Equals(local, "hello");
            Assert.IsTrue(buffer.isEmpty());
           

        }

        public void TestBufferFlushMethod()
        {
            DragonsAndRabbits.Client.Buffer buffer = new DragonsAndRabbits.Client.Buffer();
            buffer.addMessage("hello");

            buffer.flushBuffer();
            Assert.IsTrue(buffer.isEmpty());
        }
    }
}
