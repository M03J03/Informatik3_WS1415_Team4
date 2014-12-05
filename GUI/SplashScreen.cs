using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragonsAndRabbits.GUI
{
    public partial class SplashScreen : Form
    {
        
        public SplashScreen()
        {
            InitializeComponent();
            timer1.Interval = 5000;
            timer1.Start();
            timer2.Interval = 500;
            timer2.Start();
            Console.WriteLine("SPLASH started");
            this.ShowDialog();
                       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("tick1");
            if (Manager.Manager.getManger() != null)
            {
            timer1.Stop();
            timer2.Stop();
            Manager.Manager mgr = Manager.Manager.getManger();
            mgr.setGUI();
            this.Close();
            Console.WriteLine("Splash timer ended");
            }
                //makes the tick go faster.
            else
            {
                Console.WriteLine("else");
                timer1.Interval = 500;
                this.Close();
            }
            
            //initialize GUI
            //mgr.setGUI();
            
        }
       
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            progressBar1.Increment(11);
        }

        static void Main(String[] args)
        {
            SplashScreen splash = new SplashScreen();
        }
    }

}
