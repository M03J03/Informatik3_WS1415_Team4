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
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// this method displays the players ID in the GUI.
        /// </summary>
        /// <param name="id"></param>
        public void yourId(int id)
        {
            this.playerIdLabel.Text = (String)("your id: #" + id);
        }

        /// <summary>
        /// this method shows up the current time in the GUI.
        /// </summary>
        /// <param name="time"></param>
        public void time(long time)
        {
            //if necessary, a calculation from seconds to the format HH:MM:SS can be inserted here
            this.timeLabel.Text = "current time:" + time;
        }


        /// <summary>
        /// this method displays the number of players online in the GUI.
        /// </summary>
        /// <param name="iOnline"></param>
        public void oninePlayers(int iOnline)
        {
            this.onlinePlayersLabel.Text = "players online: " + iOnline;
        }







    }
}
