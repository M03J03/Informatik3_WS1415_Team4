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

        private void InitializeComponent()
        {

            this.sendButton = new System.Windows.Forms.Button();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.chatRun = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.mapViewPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(908, 469);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "send...";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(718, 469);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.Size = new System.Drawing.Size(184, 20);
            this.chatTextBox.TabIndex = 1;
            // 
            // chatRun
            // 
            this.chatRun.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.chatRun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatRun.Location = new System.Drawing.Point(718, 155);
            this.chatRun.Multiline = true;
            this.chatRun.Name = "chatRun";
            this.chatRun.ReadOnly = true;
            this.chatRun.Size = new System.Drawing.Size(265, 295);
            this.chatRun.TabIndex = 2;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLabel.ForeColor = System.Drawing.Color.Maroon;
            this.idLabel.Location = new System.Drawing.Point(718, 13);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(90, 25);
            this.idLabel.TabIndex = 3;
            this.idLabel.Text = "Your ID:";
            // 
            // mapViewPanel
            // 
            this.mapViewPanel.BackColor = System.Drawing.Color.Silver;
            this.mapViewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapViewPanel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mapViewPanel.Location = new System.Drawing.Point(46, 32);
            this.mapViewPanel.Name = "mapViewPanel";
            this.mapViewPanel.Size = new System.Drawing.Size(600, 600);
            this.mapViewPanel.TabIndex = 4;
            // 
            // GUI
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(995, 670);
            this.Controls.Add(this.mapViewPanel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.chatRun);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.sendButton);
            this.Name = "GUI";
            this.Text = "DragonsAndRabbits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       


        
    }
}
