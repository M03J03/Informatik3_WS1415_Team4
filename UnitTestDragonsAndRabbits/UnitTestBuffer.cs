using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDragonsAndRabbits
{
    [TestClass]
    public class UnitTestBuffer
    {
        Buffer buffer;
        String Message;

        [TestMethod]

        //this test ensures that there IS a buffer #1Test 
        public void TestInitBuffer()
        {
            Buffer buffer = new Buffer();
            Assert.IsTrue(buffer != null);

        }

        //this method ensures, that the transfer from Connector to Buffer works.
        public void TestBufferAddMethod()
        {
            Assert.IsTrue(message!=null);
            //init
             this.buffer = new ArrayList();

            
                     
        }

        public void TestBufferGetMethod()
        {

        }

        public void TestBufferFlushMethod()
        {

        }
    }
}
