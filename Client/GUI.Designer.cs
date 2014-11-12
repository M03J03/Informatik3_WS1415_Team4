namespace DragonsAndRabbits.GUI
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatRunField = new System.Windows.Forms.TextBox();
            this.chatTextField = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.onlinePlayersLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.controlUpButton = new System.Windows.Forms.Button();
            this.controlDownButton = new System.Windows.Forms.Button();
            this.controlLeftButton = new System.Windows.Forms.Button();
            this.controlRightButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.finishedButton = new System.Windows.Forms.Button();
            this.playerIdLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chatRunField
            // 
            this.chatRunField.BackColor = System.Drawing.Color.LemonChiffon;
            this.chatRunField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatRunField.Cursor = System.Windows.Forms.Cursors.No;
            this.chatRunField.Location = new System.Drawing.Point(735, 25);
            this.chatRunField.Multiline = true;
            this.chatRunField.Name = "chatRunField";
            this.chatRunField.ReadOnly = true;
            this.chatRunField.Size = new System.Drawing.Size(244, 249);
            this.chatRunField.TabIndex = 0;
            // 
            // chatTextField
            // 
            this.chatTextField.AllowDrop = true;
            this.chatTextField.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.chatTextField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.chatTextField.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatTextField.Location = new System.Drawing.Point(735, 307);
            this.chatTextField.Name = "chatTextField";
            this.chatTextField.Size = new System.Drawing.Size(244, 22);
            this.chatTextField.TabIndex = 1;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(902, 333);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "send";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(732, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "your message:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(735, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "chat running";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(13, 587);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(29, 13);
            this.timeLabel.TabIndex = 5;
            this.timeLabel.Text = "time:";
            // 
            // onlinePlayersLabel
            // 
            this.onlinePlayersLabel.AutoSize = true;
            this.onlinePlayersLabel.Location = new System.Drawing.Point(98, 587);
            this.onlinePlayersLabel.Name = "onlinePlayersLabel";
            this.onlinePlayersLabel.Size = new System.Drawing.Size(74, 13);
            this.onlinePlayersLabel.TabIndex = 6;
            this.onlinePlayersLabel.Text = "players online:";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(230, 587);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(38, 13);
            this.pointsLabel.TabIndex = 7;
            this.pointsLabel.Text = "points:";
            // 
            // controlUpButton
            // 
            this.controlUpButton.Location = new System.Drawing.Point(821, 485);
            this.controlUpButton.Name = "controlUpButton";
            this.controlUpButton.Size = new System.Drawing.Size(75, 42);
            this.controlUpButton.TabIndex = 8;
            this.controlUpButton.Text = "up";
            this.controlUpButton.UseVisualStyleBackColor = true;
            // 
            // controlDownButton
            // 
            this.controlDownButton.Location = new System.Drawing.Point(821, 533);
            this.controlDownButton.Name = "controlDownButton";
            this.controlDownButton.Size = new System.Drawing.Size(75, 42);
            this.controlDownButton.TabIndex = 9;
            this.controlDownButton.Text = "down";
            this.controlDownButton.UseVisualStyleBackColor = true;
            // 
            // controlLeftButton
            // 
            this.controlLeftButton.Location = new System.Drawing.Point(757, 504);
            this.controlLeftButton.Name = "controlLeftButton";
            this.controlLeftButton.Size = new System.Drawing.Size(58, 51);
            this.controlLeftButton.TabIndex = 10;
            this.controlLeftButton.Text = "left";
            this.controlLeftButton.UseVisualStyleBackColor = true;
            // 
            // controlRightButton
            // 
            this.controlRightButton.Location = new System.Drawing.Point(902, 504);
            this.controlRightButton.Name = "controlRightButton";
            this.controlRightButton.Size = new System.Drawing.Size(58, 51);
            this.controlRightButton.TabIndex = 11;
            this.controlRightButton.Text = "right";
            this.controlRightButton.UseVisualStyleBackColor = true;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(421, 582);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 12;
            this.pauseButton.Text = "pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // resumeButton
            // 
            this.resumeButton.Location = new System.Drawing.Point(525, 582);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(75, 23);
            this.resumeButton.TabIndex = 13;
            this.resumeButton.Text = "resume";
            this.resumeButton.UseVisualStyleBackColor = true;
            // 
            // finishedButton
            // 
            this.finishedButton.Location = new System.Drawing.Point(630, 582);
            this.finishedButton.Name = "finishedButton";
            this.finishedButton.Size = new System.Drawing.Size(75, 23);
            this.finishedButton.TabIndex = 14;
            this.finishedButton.Text = "finished";
            this.finishedButton.UseVisualStyleBackColor = true;
            // 
            // playerIdLabel
            // 
            this.playerIdLabel.AutoSize = true;
            this.playerIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerIdLabel.Location = new System.Drawing.Point(16, 13);
            this.playerIdLabel.Name = "playerIdLabel";
            this.playerIdLabel.Size = new System.Drawing.Size(55, 17);
            this.playerIdLabel.TabIndex = 15;
            this.playerIdLabel.Text = "your id:";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 612);
            this.Controls.Add(this.playerIdLabel);
            this.Controls.Add(this.finishedButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.controlRightButton);
            this.Controls.Add(this.controlLeftButton);
            this.Controls.Add(this.controlDownButton);
            this.Controls.Add(this.controlUpButton);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.onlinePlayersLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.chatTextField);
            this.Controls.Add(this.chatRunField);
            this.Name = "GUI";
            this.Text = "DragonsAndRabbits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chatRunField;
        private System.Windows.Forms.TextBox chatTextField;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label onlinePlayersLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Button controlUpButton;
        private System.Windows.Forms.Button controlDownButton;
        private System.Windows.Forms.Button controlLeftButton;
        private System.Windows.Forms.Button controlRightButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Button finishedButton;
        private System.Windows.Forms.Label playerIdLabel;
    }
}