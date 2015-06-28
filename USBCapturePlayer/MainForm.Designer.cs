namespace USBCapturePlayer
{
    partial class MainForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.VideoSourceSelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AudioSourceSelector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.ActiveButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainVideoPlayer = new AForge.Controls.VideoSourcePlayer();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.VideoSourceSelector);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.AudioSourceSelector);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.VolumeBar);
            this.flowLayoutPanel1.Controls.Add(this.ActiveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(818, 53);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Video Source:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VideoSourceSelector
            // 
            this.VideoSourceSelector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.VideoSourceSelector.FormattingEnabled = true;
            this.VideoSourceSelector.Location = new System.Drawing.Point(83, 15);
            this.VideoSourceSelector.Name = "VideoSourceSelector";
            this.VideoSourceSelector.Size = new System.Drawing.Size(189, 21);
            this.VideoSourceSelector.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Audio Source:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AudioSourceSelector
            // 
            this.AudioSourceSelector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AudioSourceSelector.FormattingEnabled = true;
            this.AudioSourceSelector.Location = new System.Drawing.Point(358, 15);
            this.AudioSourceSelector.Name = "AudioSourceSelector";
            this.AudioSourceSelector.Size = new System.Drawing.Size(204, 21);
            this.AudioSourceSelector.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(568, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Volume:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VolumeBar
            // 
            this.VolumeBar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.VolumeBar.Location = new System.Drawing.Point(619, 3);
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(104, 45);
            this.VolumeBar.TabIndex = 4;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.VolumeBar.Value = 5;
            // 
            // ActiveButton
            // 
            this.ActiveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ActiveButton.Location = new System.Drawing.Point(729, 14);
            this.ActiveButton.Name = "ActiveButton";
            this.ActiveButton.Size = new System.Drawing.Size(75, 23);
            this.ActiveButton.TabIndex = 6;
            this.ActiveButton.Text = "Play";
            this.ActiveButton.UseVisualStyleBackColor = true;
            this.ActiveButton.Click += new System.EventHandler(this.ActiveButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MainPanel.Controls.Add(this.MainVideoPlayer);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 53);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(818, 319);
            this.MainPanel.TabIndex = 1;
            // 
            // MainVideoPlayer
            // 
            this.MainVideoPlayer.Location = new System.Drawing.Point(12, 6);
            this.MainVideoPlayer.Name = "MainVideoPlayer";
            this.MainVideoPlayer.Size = new System.Drawing.Size(794, 301);
            this.MainVideoPlayer.TabIndex = 0;
            this.MainVideoPlayer.Text = "VideoSourcePlayer";
            this.MainVideoPlayer.VideoSource = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 372);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(834, 410);
            this.Name = "MainForm";
            this.Text = "USB Capture Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox VideoSourceSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AudioSourceSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Windows.Forms.Button ActiveButton;
        private AForge.Controls.VideoSourcePlayer MainVideoPlayer;
    }
}

