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
        Manager.Manager mgr;
        public SplashScreen()
        {
            mgr = Manager.Manager.getManger();
            InitializeComponent();
            timer1.Interval = 5000;
            timer1.Start();
            timer2.Interval = 500;
            timer2.Start();
            Console.WriteLine("SPLASH started");
            this.ShowDialog();
                       
        }

        /// <summary>
        /// ticks the splashscreen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("tick1");
            if (mgr != null)
            {
            
            timer1.Stop();
            timer2.Stop();

            this.Invalidate();
            this.Hide();
            this.Close();
            Console.WriteLine("form closed");

            GUI gui = new GUI();
           
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
       /// <summary>
       /// ticks the progressbar
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            progressBar1.Increment(11);
        }

        /*
        static void Main(String[] args)
        {
            SplashScreen splash = new SplashScreen();
        }
         * */
       
    }

}
