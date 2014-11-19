using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DragonsAndRabbits.Client;


namespace DragonsAndRabbits.GUI
{
    public partial class GUI : Form
    {
        private Manager mgr = Manager.Instance;



        public GUI()
        {
            Console.WriteLine("GUI activated!");
            InitializeComponent();
            this.ShowDialog();
        }

        private void InitializeComponent()
        {
            this.sendButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.chatRun = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.mapViewPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.sendButton.Location = new System.Drawing.Point(908, 601);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "send...";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // chatTextBox
            // 
            this.chatTextBox.AcceptsReturn = true;
            this.chatTextBox.Location = new System.Drawing.Point(708, 603);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(184, 20);
            this.chatTextBox.TabIndex = 1;
            this.chatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatTextBox_on_return);
            // 
            // chatRun
            // 
            this.chatRun.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.chatRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatRun.Location = new System.Drawing.Point(708, 289);
            this.chatRun.Multiline = true;
            this.chatRun.Name = "chatRun";
            this.chatRun.ReadOnly = true;
            this.chatRun.Size = new System.Drawing.Size(240, 295);
            this.chatRun.TabIndex = 2;
            this.chatRun.WordWrap = false;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.Color.Maroon;
            this.idLabel.Location = new System.Drawing.Point(703, 245);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(90, 25);
            this.idLabel.TabIndex = 3;
            this.idLabel.Text = "Your ID:";
            // 
            // mapViewPanel
            // 
            this.mapViewPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mapViewPanel.BackColor = System.Drawing.Color.Silver;
            this.mapViewPanel.Cursor = System.Windows.Forms.Cursors.No;
            this.mapViewPanel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mapViewPanel.Location = new System.Drawing.Point(46, 32);
            this.mapViewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mapViewPanel.MaximumSize = new System.Drawing.Size(600, 600);
            this.mapViewPanel.MinimumSize = new System.Drawing.Size(600, 600);
            this.mapViewPanel.Name = "mapViewPanel";
            this.mapViewPanel.Size = new System.Drawing.Size(600, 600);
            this.mapViewPanel.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.pictureBox1.Image = global::DragonsAndRabbits.Properties.Resources.dragon;
            this.pictureBox1.Location = new System.Drawing.Point(708, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // GUI
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(995, 672);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mapViewPanel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.chatRun);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.sendButton);
            this.KeyPreview = true;
            this.Name = "GUI";
            this.Text = "DragonsAndRabbits";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_keys);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        


        /// <summary>
        /// this method is to dynamically draw the different tiles to the GUI
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="attributes"></param>
        public void drawMap(int row, int column, List<String> attributes)
        {
           
            int nrOfTiles = row*column;
            Console.WriteLine("No of tiles: "+ nrOfTiles);
            int height = 600/row; //pixel available per tile (600 absolute)
            int width = 600/column;
            Console.WriteLine("height/width: "+ height + ", " + width);

            
            for (int i = 0; i < nrOfTiles; i++ )
            {
                idLabel.Text = "HEY! button has been pressed!";
                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Size = new System.Drawing.Size(height, width);
                pb.Margin = new System.Windows.Forms.Padding(0);
                  // pb.Location = new System.Drawing.Point(width * i); //starting point
                pb.BorderStyle = System.Windows.Forms.BorderStyle.None;

                pb.Image = global::DragonsAndRabbits.Properties.Resources.forest;
                mapViewPanel.Controls.Add(pb);
                
            }
            
            


        }
        /// <summary>
        /// this method lists the recieved message in the chatrun of the Client-GUI.
        /// </summary>
        /// <param name="message"></param>
        internal void setChatUpdate(string message)
        {
            if (message != null && message != "")
            {
                chatRun.AppendText(message + "\r\n");
            }
            
        }



    
        //**************************************vv******EVENTS*****vv***************************************



        /// <summary>
        /// Button-Click-Event. This method adds a message to the chatrun and sends an update towards the manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendButton_Click(object sender, EventArgs e)
        {

            //for testing purposes only
            drawMap(10,10,null);


            if (sender == null)
            {
                throw new ArgumentNullException("GUI ButtonClick argument is null");
            }

            if (chatTextBox.TextLength > 0)
                {
                    //showText on Chatrun:
                    chatRun.AppendText (chatTextBox.Text + "\r\n");
                    //then sendText to Server:
                    mgr.chatUpdateToServer(chatTextBox.Text);
                }

            chatTextBox.ResetText();
             
        }

        /// <summary>
        /// Key-Event. on 'return'-Key - the sendbutton_Click is activated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chatTextBox_on_return(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //MessageBox.Show("Enter");
                if (chatTextBox.TextLength>0)
                {
                   this.sendButton_Click(sender, e);
                }
               
            }
         
        }

        private void control_keys(object sender, KeyEventArgs e)
        {

            List<Keys> keyCodes = new List<Keys> { Keys.Left,Keys.Right, Keys.Up, Keys.Down };

            Console.WriteLine("controlkeys entered");


            if (keyCodes.Contains(e.KeyCode))
            {
                switch (e.KeyCode)
                {
                    case (Keys.Left):
                        {
                            chatRun.AppendText("left \r\n");
                            //mgr.movePlayer("left");
                            break;
                        }
                    case (Keys.Right):
                        {
                            chatRun.AppendText("right \r\n");
                           // mgr.movePlayer("right");
                            break;
                        }
                    case (Keys.Up):
                        {
                            chatRun.AppendText("up \r\n");
                            //mgr.movePlayer("up");
                            break;
                        }
                    case (Keys.Down):
                        {
                            chatRun.AppendText("down \r\n");
                           // mgr.movePlayer("down");
                            break;
                        }
                    default:{

                        break;
                        }
                   }
                

                //ArrowKey pressed
                
                Console.WriteLine(e.KeyCode.ToString());
            }
             else
                    {
                        //chatRun.AppendText("fail!");
                    }
      
            
        }



        //********************************************MAIN******************************************

        static void Main(String[] args)
        {
            GUI gui = new GUI();
        }



       
    }

}
