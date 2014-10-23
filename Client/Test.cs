using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DragonsAndRabbits.Client
{
    class Test
    {

        static void Main(string[] args)
        {
            Connector c = new Connector();
            c.login("0.0.0.0", 5);
            System.Diagnostics.Debug.WriteLine(c.getIP());
            System.Diagnostics.Debug.WriteLine(c.getPort());
        }
    }
}
