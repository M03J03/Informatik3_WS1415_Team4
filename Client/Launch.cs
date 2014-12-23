using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DragonsAndRabbits.Client;
using DragonsAndRabbits.GUI;
using DragonsAndRabbits.Manager;

namespace DragonsAndRabbits.Client
{
    static class Launch
    {

        /// <summary>
        /// Main entrypoint for the application
        /// </summary>
        [STAThread]
        static void Main()
        {


            Manager.Manager mgr = new Manager.Manager();

            Console.WriteLine("app started!");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //initialize Connector
            Connector.Connector c = new Connector.Connector();
            //starting Connectorthread
            c.start();

            Application.Run(new GUI.GUI());
        }
    
    }

}

