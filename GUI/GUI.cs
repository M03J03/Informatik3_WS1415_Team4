﻿using System;
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
using System.Threading;

/*
 * 
 * Version 1.0512
 *  
 */

namespace DragonsAndRabbits.GUI
{
    public partial class GUI : Form
    {
        
        private static GUI gui;
        private int rows = 0;
        private int cols = 0;
        private int tileSizeInPx = 0;
        private Manager.Manager mgr;
        //private Thread demoThread = null;
        public delegate void myDelegate(List<MapCell> cells);
     

        /// <summary>
        /// this method initializes a WinForm - our GUI
        /// </summary>

        public GUI()
        {
            Console.WriteLine("GUI activated!");

            gui = this;
         //initialize Manager
             mgr = Manager.Manager.getManger();
             mgr.setGui(this);

            //requests the needed mapDimensions for the following operations
            //setMapDimensions();
            setMapDimensions();      
            InitializeComponent();

            
           

            
            //this.updateGUI();
             
            ////initialize Connector
            //Connector.Connector c = new Connector.Connector();
            ////starting Connectorthread
            //c.start();
            

        }


        /// <summary>
        /// initializes and collects all the compunents and its attributes for the WinForm
        /// </summary>
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
            this.mapViewPanel.BackColor = System.Drawing.Color.DimGray;
            this.mapViewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mapViewPanel.CausesValidation = false;
            this.mapViewPanel.Cursor = System.Windows.Forms.Cursors.Cross;
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_keys);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      



        /// <summary>
        /// this method returns the GUI
        /// </summary>
        /// <returns></returns>
        public GUI getGUI()
        {
            return this;
        }

        
        private void setGUI(GUI g)
        {
            gui = g;
        }
        
        



        /// <summary>
        /// this method is to update the GUI/Map at once.
        /// </summary>
        internal void updateGUI()
        {
            //requests the needed mapDimensions for the following operations
           
            setMapDimensions();
            if (mgr.getMapCells() != null)
            {
                drawMap(mgr.getMapCells());
            }
            drawPlayer(); 
            drawDragon();
           // idLabel.Text +=  mgr.getYourID();
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

            //PictureBox[] PB = new PictureBox[this.rows * this.cols];
            setMapDimensions();

            //create Graphics for the tile on the mapviewpanel
            Graphics g = mapViewPanel.CreateGraphics();
           
            
            //evaluate the given map
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

             int tmpCounter = 0;


             //list of Mapcells
             foreach (MapCell mc in cells)
             {
                 Manager.Properties selectedIcon = selectPropertyIcon(mc);

                 //maps are shaped like a rectangle but not nescessarily a square
                 if (endOfLine(currentCol))
                 {
                     Console.WriteLine("new Line!");
                     currentRow++;
                     currentCol = 0;
                 }
                    
                 //now to draw the tile with the selected property
                 //PROPERTY: "WALKABLE"|"WALL"|"FOREST"|"WATER"|"HUNTABLE"
                 switch (selectedIcon)
                 {
                     case Manager.Properties.walkable:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.walkable, new Rectangle(currentCol * tileSizeInPx, currentRow * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                     case Manager.Properties.wall:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.stones, new Rectangle(currentCol * tileSizeInPx, currentRow * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                     case Manager.Properties.forest:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.forest, new Rectangle(currentCol * tileSizeInPx, currentRow * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                     case Manager.Properties.water:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.water, new Rectangle(currentCol * tileSizeInPx, currentRow * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                     //not necessarily needed - but default ;)
                     case Manager.Properties.huntable:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.huntable, new Rectangle(currentCol * tileSizeInPx, currentRow * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                 }


                 //one tile ahead
                 currentCol++;

             }//End foreach mapcells
            
        }


        /// <summary>
        /// this method is triggered, if the mapviewpanel is invalidated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnPaint(object sender, PaintEventArgs e)
        {
            updateGUI();
        }


        
        /// <summary>
        /// this method locates the player, resets his icon at the old tile and draws an icon on the new tile he is standing on
        /// </summary>
        /// <param name="id"></param>
        /// <param name="direction"></param>
        internal void drawPlayer()
        {
            //mgr = Manager.Manager.getManger();
            foreach (Player p in mgr.getPlayers())
            {
               Graphics g = mapViewPanel.CreateGraphics();
               g.DrawImage(global::DragonsAndRabbits.Properties.Resources.player_female_2, new Rectangle((p.getRow() - 1) * tileSizeInPx, (p.getColumn() - 1) * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                                              
            }


        }


        internal void redrawTile(int x, int y)
        {
            foreach (MapCell mc in mgr.getMapCells())
            {
                if (mc.getColumn() == x && mc.getRow() == y)
                {
                    Graphics g = mapViewPanel.CreateGraphics();

                    switch(selectPropertyIcon(mc))
                    {
                     case Manager.Properties.walkable:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.walkable, new Rectangle(x * tileSizeInPx, y * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                     case Manager.Properties.wall:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.stones, new Rectangle(x * tileSizeInPx, y * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                     case Manager.Properties.forest:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.forest, new Rectangle(x * tileSizeInPx, y * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                     case Manager.Properties.water:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.water, new Rectangle(x * tileSizeInPx, y * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                     //not necessarily needed - but default ;)
                     case Manager.Properties.huntable:
                         g.DrawImage(global::DragonsAndRabbits.Properties.Resources.huntable, new Rectangle(x * tileSizeInPx, y * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                         break;

                     }
                }
            }
        }






        /// <summary>
        /// this method paints the playerIcon to the map according to its coordinates
        /// </summary>
        /// 
        internal void drawDragon()
        {
            if (mgr.getDragons() != null)
            {

                foreach (Dragon d in mgr.getDragons())
                {
                      Graphics g = mapViewPanel.CreateGraphics();
                      g.DrawImage(global::DragonsAndRabbits.Properties.Resources.dragon, new Rectangle((d.getRow() - 1) * tileSizeInPx, (d.getColumn() - 1) * tileSizeInPx, tileSizeInPx, tileSizeInPx));
                }    
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
                // MessageBox.Show("Enter");
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
                    //this.Invalidate();
                    //this.Update();

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



    }

}
