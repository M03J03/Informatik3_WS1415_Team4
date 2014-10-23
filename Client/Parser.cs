using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace DragonsAndRabbits.Client
{
    class Parser
    {

        String inputFromBuffer;





        public Parser()
        {


        }



        public void getInputFromBuffer(String inputFromBuffer)
        {

            Contract.Requires(inputFromBuffer.Length > 0);
            Contract.Ensures(inputFromBuffer.Length > 0);
            AnalyzeBuffer(inputFromBuffer);

        }

        private void AnalyzeBuffer(String bufferInput)
        {



        }



    }
}
