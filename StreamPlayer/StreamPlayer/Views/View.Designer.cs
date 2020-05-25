namespace StreamPlayer.Views
{
    public partial class View
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serverPortNum = new System.Windows.Forms.TextBox();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.setupBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.teardownBtn = new System.Windows.Forms.Button();
            this.clientBox = new System.Windows.Forms.TextBox();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.packetReportCheck = new System.Windows.Forms.CheckBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.videoName = new System.Windows.Forms.ComboBox();
            this.clientPortNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect To Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server IP address:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Video name:";
            // 
            // serverPortNum
            // 
            this.serverPortNum.Location = new System.Drawing.Point(106, 6);
            this.serverPortNum.Name = "serverPortNum";
            this.serverPortNum.Size = new System.Drawing.Size(49, 20);
            this.serverPortNum.TabIndex = 4;
            this.serverPortNum.Text = "3000";
            // 
            // serverIP
            // 
            this.serverIP.Location = new System.Drawing.Point(259, 6);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(82, 20);
            this.serverIP.TabIndex = 5;
            this.serverIP.Text = "192.168.0.101";
            // 
            // setupBtn
            // 
            this.setupBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setupBtn.Enabled = false;
            this.setupBtn.Location = new System.Drawing.Point(15, 434);
            this.setupBtn.Name = "setupBtn";
            this.setupBtn.Size = new System.Drawing.Size(85, 75);
            this.setupBtn.TabIndex = 7;
            this.setupBtn.Text = "Setup";
            this.setupBtn.UseVisualStyleBackColor = true;
            // 
            // playBtn
            // 
            this.playBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playBtn.Enabled = false;
            this.playBtn.Location = new System.Drawing.Point(142, 434);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(85, 75);
            this.playBtn.TabIndex = 8;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            // 
            // pauseBtn
            // 
            this.pauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseBtn.Enabled = false;
            this.pauseBtn.Location = new System.Drawing.Point(473, 434);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(85, 75);
            this.pauseBtn.TabIndex = 9;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            // 
            // teardownBtn
            // 
            this.teardownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.teardownBtn.Enabled = false;
            this.teardownBtn.Location = new System.Drawing.Point(595, 434);
            this.teardownBtn.Name = "teardownBtn";
            this.teardownBtn.Size = new System.Drawing.Size(85, 75);
            this.teardownBtn.TabIndex = 10;
            this.teardownBtn.Text = "Teardown";
            this.teardownBtn.UseVisualStyleBackColor = true;
            // 
            // clientBox
            // 
            this.clientBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clientBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clientBox.Location = new System.Drawing.Point(15, 515);
            this.clientBox.Multiline = true;
            this.clientBox.Name = "clientBox";
            this.clientBox.ReadOnly = true;
            this.clientBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientBox.Size = new System.Drawing.Size(549, 129);
            this.clientBox.TabIndex = 11;
            // 
            // serverBox
            // 
            this.serverBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.serverBox.Location = new System.Drawing.Point(15, 652);
            this.serverBox.Multiline = true;
            this.serverBox.Name = "serverBox";
            this.serverBox.ReadOnly = true;
            this.serverBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverBox.Size = new System.Drawing.Size(549, 129);
            this.serverBox.TabIndex = 12;
            // 
            // packetReportCheck
            // 
            this.packetReportCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.packetReportCheck.AutoSize = true;
            this.packetReportCheck.Location = new System.Drawing.Point(581, 537);
            this.packetReportCheck.Name = "packetReportCheck";
            this.packetReportCheck.Size = new System.Drawing.Size(95, 17);
            this.packetReportCheck.TabIndex = 13;
            this.packetReportCheck.Text = "Packet Report";
            this.packetReportCheck.UseVisualStyleBackColor = true;
            // 
            // connectBtn
            // 
            this.connectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectBtn.Location = new System.Drawing.Point(591, 729);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 15;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.Location = new System.Drawing.Point(591, 758);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 16;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            // 
            // imageBox
            // 
            this.imageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox.Location = new System.Drawing.Point(15, 33);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(665, 382);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 25;
            this.imageBox.TabStop = false;
            // 
            // videoName
            // 
            this.videoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.videoName.Enabled = false;
            this.videoName.FormattingEnabled = true;
            this.videoName.Items.AddRange(new object[] {
            "video1.mjpeg",
            "video2.mjpeg"});
            this.videoName.Location = new System.Drawing.Point(580, 6);
            this.videoName.Name = "videoName";
            this.videoName.Size = new System.Drawing.Size(99, 21);
            this.videoName.TabIndex = 26;
            // 
            // clientPortNum
            // 
            this.clientPortNum.Location = new System.Drawing.Point(425, 6);
            this.clientPortNum.Name = "clientPortNum";
            this.clientPortNum.Size = new System.Drawing.Size(49, 20);
            this.clientPortNum.TabIndex = 27;
            this.clientPortNum.Text = "11000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Receive Port:";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 793);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clientPortNum);
            this.Controls.Add(this.videoName);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.packetReportCheck);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.clientBox);
            this.Controls.Add(this.teardownBtn);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.setupBtn);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.serverPortNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageBox);
            this.Name = "View";
            this.Text = "Player";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serverPortNum;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.Button setupBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button teardownBtn;
        private System.Windows.Forms.TextBox clientBox;
        private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.CheckBox packetReportCheck;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button exitBtn;
        public System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.ComboBox videoName;
        private System.Windows.Forms.TextBox clientPortNum;
        private System.Windows.Forms.Label label4;
    }
}

