using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DragonsAndRabbits.Manager;
using DragonsAndRabbits.Client;
using DragonsAndRabbits.Exceptions;

/*
 * 
 * Version 1.0512
 *  
 */

namespace DragonsAndRabbits.GUI
{
    public partial class GUI : Form
    {
        private static Manager.Manager mgr = Manager.Manager.getManger();
        private static GUI gui;
        private int rows = 0;
        private int cols = 0;
        private int tileSizeInPx = 0;


        /// <summary>
        /// this method initializes a WinForm - our GZU
        /// </summary>

        public GUI()
        {
            Console.WriteLine("GUI activated!");
            setGUI(this);
            //requests the needed mapDimensions for the following operations
            setMapDimensions();
            InitializeComponent();
            this.updateGUI();
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
            this.mouseLabel = new System.Windows.Forms.Label();
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
            this.sendButton.TabStop = false;
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
            this.mapViewPanel.BackColor = System.Drawing.Color.Black;
            this.mapViewPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            //this.mapViewPanel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mapViewPanel.Location = new System.Drawing.Point(46, 32);
            this.mapViewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mapViewPanel.MaximumSize = new System.Drawing.Size(600, 600);
            this.mapViewPanel.MinimumSize = new System.Drawing.Size(600, 600);
            this.mapViewPanel.Name = "mapViewPanel";
            this.mapViewPanel.Size = new System.Drawing.Size(600, 600);
            this.mapViewPanel.TabIndex = 4;
            this.mapViewPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
            
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
            // mouseLabel
            // 
            this.mouseLabel.AutoSize = true;
            this.mouseLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.mouseLabel.Location = new System.Drawing.Point(12, 650);
            this.mouseLabel.Name = "mouseLabel";
            this.mouseLabel.Size = new System.Drawing.Size(75, 13);
            this.mouseLabel.TabIndex = 7;
            this.mouseLabel.Text = "Mouseposition";
            // 
            // GUI
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(995, 672);
            this.Controls.Add(this.mouseLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mapViewPanel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.chatRun);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.sendButton);
            this.KeyPreview = true;
            this.Name = "GUI";
            this.Text = "DragonsAndRabbits";
            //this.Load += new System.EventHandler(this.GUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_keys);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        /// <summary>
        /// this method returns the GUI
        /// </summary>
        /// <returns></returns>
        public static GUI getGUI()
        {
            return gui;
        }

        private void setGUI(GUI g)
        {
            GUI.gui = g;
        }

        /// <summary>
        /// this method is to update the GUI/Map at once.
        /// </summary>
        internal void updateGUI()
        {
            //requests the needed mapDimensions for the following operations
            setMapDimensions();

            drawMap(mgr.getMapCells());

           
             drawPlayer(); 
            mapViewPanel.Invalidate();
             drawDragon();
        }


        /// <summary>
        /// evaluates wheter the current row is come to an end
        /// </summary>
        /// <param name="length"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="tileSize"></param>
        /// <returns></returns>
        private bool endOfLine(int col)
        {
            //diese methode wird wegen felhendem globalen column-wert nie aufgerufen
            bool b = false;

            if (col == this.cols)
            {
                b = true;
            }
         //   Console.WriteLine("end of the line reached: " + b);
            return b;

        }


        /// <summary>
        /// sets the dimensions of the map global accessible
        /// </summary>
        private void setMapDimensions()
        {
            this.rows = mgr.getHeight();
            this.cols = mgr.getWidth();
        }

        /// <summary>
        /// this method is to find out, which icon according to the properties of a mapcell needs to be painted 
        /// so it's only for painting-reasons, ignoring attributes like huntable
        /// </summary>
        /// <param name="mc"></param>
        /// <returns></returns>
        private Manager.Properties selectPropertyIcon(MapCell mc)
        {
            Manager.Properties iconProp = Manager.Properties.walkable; //default


            if (mc.propList().Contains(Manager.Properties.forest))
            {
                iconProp = Manager.Properties.forest;
            }

            if (mc.propList().Contains(Manager.Properties.wall))
            {
                iconProp = Manager.Properties.wall;
            }

            if (mc.propList().Contains(Manager.Properties.water))
            {
                iconProp = Manager.Properties.water;
            }

            return iconProp;
        }



        /// <summary>
        /// this method is to dynamically draw the different tiles to the GUI
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>     
        /// <param name="attributes as List<String>"></param>
        /// 
        public void drawMap(List<MapCell> cells)
        {
            int fieldSize = cells.Count;
            int currentRow = 0, currentCol = 0;
            bool stop = false;

            PictureBox[] PB = new PictureBox[this.rows * this.cols];
            

            //Graphics g = mapViewPanel.CreateGraphics();

            if (this.rows == 0 || this.cols == 0)
            {
                throw new ManagerInputException("no valid map to draw!");
            }
            if (fieldSize != (this.rows * this.cols))
            {
                throw new WrongWidthOrHeigthException("missing properties to draw the map!");
            }

            //change size according to the relative dimensions -600px total- of the map
            if (rows > cols)
            {
                tileSizeInPx = 600 / rows;
            }
            else
            {
                tileSizeInPx = 600 / cols;
            }

            //list of Mapcells

           // Image TMP = Image.FromFile("C:\\Users\\Moe\\Documents\\sand.bmp");
            
           // g.DrawImage((Image.FromFile("C:\\Users\\Moe\\Documents\\sand.bmp")),25,25);
           // this.mapViewPanel.Invalidate();
           // this.mapViewPanel.Update();



            int tmpCounter = 0;
            foreach (MapCell mc in cells)
            {
                //now to draw the tile with the selected property
                Manager.Properties toDraw = selectPropertyIcon(mc);

             
                //maps are shaped like a rectangle but not nescessarily a square
                if(endOfLine(currentCol)){
                   // Console.WriteLine("new Line!");
                    currentRow++;
                    currentCol = 0;
                }


                //PROPERTY: "WALKABLE"|"WALL"|"FOREST"|"WATER"|(ignoring "HUNTABLE")
            //    if (!stop)
                //
                
                        switch (toDraw)
                         {
                             case Manager.Properties.walkable:
                                 //g.DrawImage(global::DragonsAndRabbits.Properties.Resources.stones, new Rectangle(currentCol * tileSizeInPx, currentRow * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                                PB[tmpCounter] = new System.Windows.Forms.PictureBox();
                                PB[tmpCounter].Click += new System.EventHandler(this.OnClick);
                                PB[tmpCounter].Size = new Size(30, 30);
                                PB[tmpCounter].Margin = new System.Windows.Forms.Padding(0);
                                //PB[tmpCounter].Image = Image.FromFile("C:\\Users\\Moe\\Documents\\Visual Studio 2012\\Projects\\Informatik3_WS1415_Team4\\GUI\\resources\\walkable.jpg");
                                PB[tmpCounter].Image = (Image)(global::DragonsAndRabbits.Properties.Resources.walkable);
                                PB[tmpCounter].Parent = this.mapViewPanel;
                                PB[tmpCounter].Name = tmpCounter.ToString();
                                PB[tmpCounter].SizeMode = PictureBoxSizeMode.Zoom;
                                this.mapViewPanel.Controls.Add(PB[tmpCounter]);tmpCounter++;break;

                             case Manager.Properties.wall:
                                PB[tmpCounter] = new System.Windows.Forms.PictureBox();
                                PB[tmpCounter].Click += new System.EventHandler(this.OnClick);
                                PB[tmpCounter].Size = new Size(30, 30);
                                PB[tmpCounter].Margin = new System.Windows.Forms.Padding(0);
                                PB[tmpCounter].Image = (Image)(global::DragonsAndRabbits.Properties.Resources.stones);
                                PB[tmpCounter].Parent = this.mapViewPanel;
                                PB[tmpCounter].Name = tmpCounter.ToString();
                                
                                this.mapViewPanel.Controls.Add(PB[tmpCounter]);tmpCounter++;break;

                             case Manager.Properties.forest:
                                PB[tmpCounter] = new System.Windows.Forms.PictureBox();
                                PB[tmpCounter].Click += new System.EventHandler(this.OnClick);
                                PB[tmpCounter].Size = new Size(30, 30);
                                PB[tmpCounter].Margin = new System.Windows.Forms.Padding(0);
                                PB[tmpCounter].Image = (Image)(global::DragonsAndRabbits.Properties.Resources.forest);
                                PB[tmpCounter].Parent = this.mapViewPanel;
                                PB[tmpCounter].Name = tmpCounter.ToString();
                                PB[tmpCounter].SizeMode = PictureBoxSizeMode.Zoom;
                               this.mapViewPanel.Controls.Add(PB[tmpCounter]); tmpCounter++;break;

                             case Manager.Properties.water:
                                PB[tmpCounter] = new System.Windows.Forms.PictureBox();
                                PB[tmpCounter].Click += new System.EventHandler(this.OnClick);
                                PB[tmpCounter].Size = new Size(30, 30);
                                PB[tmpCounter].Margin = new System.Windows.Forms.Padding(0);
                                PB[tmpCounter].Image = (Image)(global::DragonsAndRabbits.Properties.Resources.water);
                                PB[tmpCounter].Parent = this.mapViewPanel;
                                PB[tmpCounter].Name = tmpCounter.ToString();
                                PB[tmpCounter].SizeMode = PictureBoxSizeMode.Zoom;
                               this.mapViewPanel.Controls.Add(PB[tmpCounter]); tmpCounter++;break;

                             //not necessarily needed - but default ;)
                             case Manager.Properties.huntable:
    
                                 PB[tmpCounter] = new System.Windows.Forms.PictureBox();
                                 PB[tmpCounter].Click += new System.EventHandler(this.OnClick);
                                PB[tmpCounter].Size = new Size(30, 30);
                                PB[tmpCounter].Margin = new System.Windows.Forms.Padding(0);
                                PB[tmpCounter].Image = (Image)(global::DragonsAndRabbits.Properties.Resources.huntable);
                                PB[tmpCounter].Parent = this.mapViewPanel;
                                PB[tmpCounter].Name = tmpCounter.ToString();
                                PB[tmpCounter].SizeMode = PictureBoxSizeMode.Zoom;
                               this.mapViewPanel.Controls.Add(PB[tmpCounter]); tmpCounter++;break;

                        }
                
                //one tile ahead
                currentCol++;

            }//End foreach mapcells
            
        }



        /// <summary>
        /// this method locates the player, resets his icon at the old tile and draws an icon on the new tile he is standing on
        /// </summary>
        /// <param name="id"></param>
        /// <param name="direction"></param>
        internal void drawPlayer()
        {
            mgr = Manager.Manager.getManger();
            foreach (Player p in mgr.getPlayers())
            {
             //   Graphics g = mapViewPanel.CreateGraphics();
             //   g.DrawImage(global::DragonsAndRabbits.Properties.Resources.player_female_2, new Rectangle((p.getColumn() - 1) * tileSizeInPx, (p.getRow() - 1) * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                PictureBox PB = new PictureBox();
                PB.Size = new Size(30, 30);
                PB.Click += new System.EventHandler(this.OnClick);
                PB.Margin = new System.Windows.Forms.Padding(0);
                PB.Image = (Image)(global::DragonsAndRabbits.Properties.Resources.player_male);
                PB.Parent = this.mapViewPanel;
                PB.SizeMode = PictureBoxSizeMode.Zoom;

                int X = p.getRow();  
                int Y = p.getColumn(); 

                int Result = X * mgr.getWidth() + Y;


                int counter = this.mapViewPanel.Controls.Count;

                System.Windows.Forms.Control[] tmp = new System.Windows.Forms.Control[(mgr.getWidth() * mgr.getHeight())+1];

                this.mapViewPanel.Controls.CopyTo(tmp,0);

                tmp[Result] = PB;

                this.mapViewPanel.Controls.Clear();

                for (int i = 0; i < tmp.Length-1 ; i++){
                    this.mapViewPanel.Controls.Add(tmp[i]);
                }


          /*      foreach (System.Windows.Forms.Control pb in tmp)
                {
                    this.mapViewPanel.Controls.Add(pb);
                } */


                // g.DrawImage(global::DragonsAndRabbits.Properties.Resources.player_female_2, new Rectangle(0, 3*tileSizeInPx, tileSizeInPx, tileSizeInPx));
            }


        }
        /// <summary>
        /// this method paints the playerIcon to the map according to its coordinates
        /// </summary>
        /// 
        private void drawDragon()
        {

            foreach (Dragon d in mgr.getDragons())
            {
                //   Graphics g = mapViewPanel.CreateGraphics();
                //   g.DrawImage(global::DragonsAndRabbits.Properties.Resources.player_female_2, new Rectangle((p.getColumn() - 1) * tileSizeInPx, (p.getRow() - 1) * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                PictureBox PB = new PictureBox();
                PB.Size = new Size(30, 30);
                PB.Click += new System.EventHandler(this.OnClick);
                PB.Margin = new System.Windows.Forms.Padding(0);
                PB.Image = (Image)(global::DragonsAndRabbits.Properties.Resources.dragon);
                PB.Parent = this.mapViewPanel;
                PB.SizeMode = PictureBoxSizeMode.Zoom;

                int X = d.getRow();  
                int Y = d.getColumn();

                int Result = X * mgr.getWidth() + Y;


                int counter = this.mapViewPanel.Controls.Count;

                System.Windows.Forms.Control[] tmp = new System.Windows.Forms.Control[(mgr.getWidth() * mgr.getHeight()) + 1];

                this.mapViewPanel.Controls.CopyTo(tmp, 0);

                tmp[Result] = PB;

                this.mapViewPanel.Controls.Clear();

                for (int i = 0; i < tmp.Length - 1; i++)
                {
                    this.mapViewPanel.Controls.Add(tmp[i]);
                }


                /*      foreach (System.Windows.Forms.Control pb in tmp)
                      {
                          this.mapViewPanel.Controls.Add(pb);
                      } */


             
            }

        }



        /// <summary>
        /// this method lists the recieved message in the chatrun of the Client-GUI.
        /// </summary>
        /// <param name="message"></param>
        public void setChatUpdate(string message)
        {
            if (message != null && message != "")
            {
                chatRun.AppendText(message + "\r\n");
            }

        }


        //**************************************vv******EVENTS*****vv***************************************




        /*/////////////////////////Form-Events//////////////////////////////////*/

        /// <summary>
        /// Button-Click-Event. This method adds a message to the chatrun and sends an update towards the manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendButton_Click(object sender, EventArgs e)
        {
            //mapViewPanel.Invalidate();
            if (sender == null)
            {
                throw new ArgumentNullException("GUI ButtonClick argument is null");
            }

            if (chatTextBox.TextLength > 0)
            {
                //then sendText to Server:
                try
                {
                    mgr.sendChatUpdateToServer(chatTextBox.Text);
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Missing Manager in GUI");
                }
                //IMPORTANT:showText on Chatrun ONLY IF THE PARSER SENT AN 'OK':
                chatRun.AppendText(chatTextBox.Text + "\r\n");
            }

            chatTextBox.ResetText();

        }



        /*/////////////////////////KEY-Events//////////////////////////////////*/



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
                if (chatTextBox.TextLength > 0)
                {
                    this.sendButton_Click(sender, e);
                }

                    //draw map testcase - for testpurposes only

               /* else
                {
                    //for testing purposes only

                    List<Manager.Properties> attr = new List<Manager.Properties> { 
                     Manager.Properties.huntable, Manager.Properties.wall, Manager.Properties.walkable, Manager.Properties.water, Manager.Properties.huntable, Manager.Properties.wall, Manager.Properties.walkable, Manager.Properties.water,Manager.Properties.huntable, Manager.Properties.wall, Manager.Properties.walkable, Manager.Properties.water,Manager.Properties.huntable, Manager.Properties.wall, Manager.Properties.walkable, Manager.Properties.water,
                    Manager.Properties.forest, Manager.Properties.walkable, Manager.Properties.forest, Manager.Properties.huntable, };
                    rows = 4; cols = 5;

                    drawMap();
                 }
                 */
                else
                {
                    this.Invalidate();
                    this.Update();

                }
            }

        }


        /// <summary>
        /// this method generates an Key-Object according to the Arrowkey, that has been pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_keys(object sender, KeyEventArgs e)
        {

            List<Keys> keyCodes = new List<Keys> { Keys.Left, Keys.Right, Keys.Up, Keys.Down };

            Console.WriteLine("controlkeys entered");


            if (keyCodes.Contains(e.KeyCode))
            {
                switch (e.KeyCode)
                {
                    case (Keys.Left):
                        mgr.movePlayer(Manager.Direction.left);
                        break;

                    case (Keys.Right):
                        mgr.movePlayer(Manager.Direction.right);
                        break;

                    case (Keys.Up):
                        mgr.movePlayer(Manager.Direction.up);
                        break;

                    case (Keys.Down):
                        mgr.movePlayer(Manager.Direction.down);
                        break;
                }


                //ArrowKey pressed

                Console.WriteLine(e.KeyCode.ToString());
            }

        }


        /*/////////////////////////MOUSE-Events//////////////////////////////////*/



        /// <summary>
        /// this method recieves a mouseclick and sends the coordinates to the Backend
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnMouseClick(Object source, MouseEventArgs e)
        {
            Point location = e.Location;

            idLabel.Text = ("Mouseposition: " + e.Location.ToString());
            mouseLabel.Text = "current tile: (" + e.Location.X / tileSizeInPx + ", " + e.Location.Y / tileSizeInPx + ")";

        }

        private void OnClick(object sender, EventArgs e)
        {
            int x= MousePosition.X % 20;
            mouseLabel.Text = ("Picturebox clicked. at " + MousePosition.X+ "," + MousePosition.Y) ;
            // Width Pixels of Mapviewpanel ~ 270 x 870


            var locationInForm = this.mapViewPanel.Location;
            var locationOnScreen = this.PointToScreen(locationInForm);

 
            mouseLabel.Text = ("X: " + (MousePosition.X - locationOnScreen.X) / 30 + "Y: " + (MousePosition.Y - locationOnScreen.Y) / 30);
            // Height Pixels of Mapviewpanel ~ 180 x 780
        }


        
        /*
        /// <summary>
        /// GUI-Form events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUI_Load(object sender, EventArgs e)
        {
            
        }
         */




        //********************************************MAIN******************************************
        /*
        static void Main(String[] args)
        {
            GUI gui = new GUI();
        }
        */
        /*******/





    }

}
