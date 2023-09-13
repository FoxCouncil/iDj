namespace iDj
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            statusBar = new StatusStrip();
            lblActivity = new ToolStripStatusLabel();
            toolStripStatusLabeliTunesVersionText = new ToolStripStatusLabel();
            lblTest = new ToolStripStatusLabel();
            timerInterface = new System.Windows.Forms.Timer(components);
            lblTrackTitle = new Label();
            btnStepBack = new FontAwesome.Sharp.IconButton();
            btnStepForward = new FontAwesome.Sharp.IconButton();
            btnPlayPause = new FontAwesome.Sharp.IconButton();
            picboxTrackArtwork = new PictureBox();
            lblTrackArtist = new Label();
            lblTrackAlbum = new Label();
            progPlayerTime = new IDjTimeBar();
            lblPlayerCurrent = new Label();
            lblTrackTotal = new Label();
            panel1 = new Panel();
            lblTrackDetails = new Label();
            tabControl = new TabControl();
            tabPageControls = new TabPage();
            tabPagePlaylists = new TabPage();
            listBoxPlaylistTracks = new ListBox();
            lblPlaylistName = new Label();
            statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picboxTrackArtwork).BeginInit();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPagePlaylists.SuspendLayout();
            SuspendLayout();
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize = new Size(24, 24);
            statusBar.Items.AddRange(new ToolStripItem[] { lblActivity, toolStripStatusLabeliTunesVersionText, lblTest });
            statusBar.Location = new Point(0, 728);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(798, 36);
            statusBar.TabIndex = 1;
            statusBar.Text = "statusStrip1";
            // 
            // lblActivity
            // 
            lblActivity.AutoSize = false;
            lblActivity.BackColor = SystemColors.Control;
            lblActivity.BorderSides = ToolStripStatusLabelBorderSides.Right;
            lblActivity.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lblActivity.Font = new Font("Consolas", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblActivity.ForeColor = Color.DarkGreen;
            lblActivity.Name = "lblActivity";
            lblActivity.Size = new Size(50, 29);
            lblActivity.Text = "-";
            lblActivity.TextAlign = ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabeliTunesVersionText
            // 
            toolStripStatusLabeliTunesVersionText.BackColor = SystemColors.Control;
            toolStripStatusLabeliTunesVersionText.BorderSides = ToolStripStatusLabelBorderSides.Right;
            toolStripStatusLabeliTunesVersionText.Name = "toolStripStatusLabeliTunesVersionText";
            toolStripStatusLabeliTunesVersionText.Size = new Size(83, 29);
            toolStripStatusLabeliTunesVersionText.Text = "OFFLINE";
            // 
            // lblTest
            // 
            lblTest.BackColor = SystemColors.Control;
            lblTest.Name = "lblTest";
            lblTest.Size = new Size(0, 29);
            // 
            // timerInterface
            // 
            timerInterface.Enabled = true;
            timerInterface.Tick += timerInterface_Tick;
            // 
            // lblTrackTitle
            // 
            lblTrackTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTrackTitle.AutoEllipsis = true;
            lblTrackTitle.BackColor = Color.FromArgb(32, 32, 32);
            lblTrackTitle.Font = new Font("Consolas", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblTrackTitle.ForeColor = Color.White;
            lblTrackTitle.Location = new Point(168, 59);
            lblTrackTitle.Name = "lblTrackTitle";
            lblTrackTitle.Size = new Size(618, 36);
            lblTrackTitle.TabIndex = 4;
            lblTrackTitle.Text = "ABC";
            lblTrackTitle.UseMnemonic = false;
            // 
            // btnStepBack
            // 
            btnStepBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStepBack.IconChar = FontAwesome.Sharp.IconChar.BackwardStep;
            btnStepBack.IconColor = Color.Black;
            btnStepBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStepBack.Location = new Point(12, 625);
            btnStepBack.Name = "btnStepBack";
            btnStepBack.Size = new Size(160, 90);
            btnStepBack.TabIndex = 5;
            btnStepBack.UseVisualStyleBackColor = true;
            btnStepBack.Click += btnStepBack_Click;
            // 
            // btnStepForward
            // 
            btnStepForward.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnStepForward.IconChar = FontAwesome.Sharp.IconChar.ForwardStep;
            btnStepForward.IconColor = Color.Black;
            btnStepForward.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnStepForward.Location = new Point(626, 625);
            btnStepForward.Name = "btnStepForward";
            btnStepForward.Size = new Size(160, 90);
            btnStepForward.TabIndex = 6;
            btnStepForward.UseVisualStyleBackColor = true;
            btnStepForward.Click += btnStepForward_Click;
            // 
            // btnPlayPause
            // 
            btnPlayPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPlayPause.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnPlayPause.IconColor = Color.Black;
            btnPlayPause.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPlayPause.Location = new Point(178, 625);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(442, 90);
            btnPlayPause.TabIndex = 7;
            btnPlayPause.UseVisualStyleBackColor = true;
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // picboxTrackArtwork
            // 
            picboxTrackArtwork.BackColor = Color.FromArgb(32, 32, 32);
            picboxTrackArtwork.BorderStyle = BorderStyle.FixedSingle;
            picboxTrackArtwork.Location = new Point(12, 12);
            picboxTrackArtwork.Name = "picboxTrackArtwork";
            picboxTrackArtwork.Size = new Size(150, 149);
            picboxTrackArtwork.SizeMode = PictureBoxSizeMode.Zoom;
            picboxTrackArtwork.TabIndex = 8;
            picboxTrackArtwork.TabStop = false;
            // 
            // lblTrackArtist
            // 
            lblTrackArtist.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTrackArtist.AutoEllipsis = true;
            lblTrackArtist.BackColor = Color.FromArgb(32, 32, 32);
            lblTrackArtist.Font = new Font("Consolas", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblTrackArtist.ForeColor = Color.White;
            lblTrackArtist.Location = new Point(168, 13);
            lblTrackArtist.Name = "lblTrackArtist";
            lblTrackArtist.Size = new Size(618, 36);
            lblTrackArtist.TabIndex = 9;
            lblTrackArtist.Text = "ABC";
            lblTrackArtist.UseMnemonic = false;
            // 
            // lblTrackAlbum
            // 
            lblTrackAlbum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTrackAlbum.AutoEllipsis = true;
            lblTrackAlbum.BackColor = Color.FromArgb(32, 32, 32);
            lblTrackAlbum.Font = new Font("Consolas", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblTrackAlbum.ForeColor = Color.White;
            lblTrackAlbum.Location = new Point(168, 105);
            lblTrackAlbum.Name = "lblTrackAlbum";
            lblTrackAlbum.Size = new Size(618, 26);
            lblTrackAlbum.TabIndex = 10;
            lblTrackAlbum.Text = "ABC";
            lblTrackAlbum.UseMnemonic = false;
            // 
            // progPlayerTime
            // 
            progPlayerTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progPlayerTime.BackColor = Color.Black;
            progPlayerTime.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            progPlayerTime.ForeColor = Color.Black;
            progPlayerTime.Location = new Point(82, 581);
            progPlayerTime.MarqueeAnimationSpeed = 50;
            progPlayerTime.Maximum = 1000000;
            progPlayerTime.Name = "progPlayerTime";
            progPlayerTime.Size = new Size(638, 31);
            progPlayerTime.Step = 1;
            progPlayerTime.Style = ProgressBarStyle.Continuous;
            progPlayerTime.TabIndex = 11;
            progPlayerTime.Value = 500000;
            // 
            // lblPlayerCurrent
            // 
            lblPlayerCurrent.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPlayerCurrent.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlayerCurrent.ForeColor = Color.White;
            lblPlayerCurrent.Location = new Point(12, 581);
            lblPlayerCurrent.Name = "lblPlayerCurrent";
            lblPlayerCurrent.Size = new Size(64, 31);
            lblPlayerCurrent.TabIndex = 12;
            lblPlayerCurrent.Text = "00:00";
            lblPlayerCurrent.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTrackTotal
            // 
            lblTrackTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTrackTotal.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTrackTotal.ForeColor = Color.White;
            lblTrackTotal.Location = new Point(726, 581);
            lblTrackTotal.Name = "lblTrackTotal";
            lblTrackTotal.Size = new Size(60, 31);
            lblTrackTotal.TabIndex = 13;
            lblTrackTotal.Text = "00:00";
            lblTrackTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(lblTrackDetails);
            panel1.Controls.Add(lblTrackAlbum);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 174);
            panel1.TabIndex = 18;
            // 
            // lblTrackDetails
            // 
            lblTrackDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTrackDetails.AutoEllipsis = true;
            lblTrackDetails.BackColor = Color.FromArgb(32, 32, 32);
            lblTrackDetails.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTrackDetails.ForeColor = Color.White;
            lblTrackDetails.Location = new Point(168, 139);
            lblTrackDetails.Name = "lblTrackDetails";
            lblTrackDetails.Size = new Size(618, 22);
            lblTrackDetails.TabIndex = 20;
            lblTrackDetails.Text = "ABC";
            lblTrackDetails.UseMnemonic = false;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageControls);
            tabControl.Controls.Add(tabPagePlaylists);
            tabControl.Location = new Point(12, 190);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(774, 377);
            tabControl.TabIndex = 19;
            // 
            // tabPageControls
            // 
            tabPageControls.ImageIndex = 0;
            tabPageControls.Location = new Point(4, 34);
            tabPageControls.Name = "tabPageControls";
            tabPageControls.Padding = new Padding(3);
            tabPageControls.Size = new Size(766, 339);
            tabPageControls.TabIndex = 0;
            tabPageControls.Text = "Controls";
            tabPageControls.UseVisualStyleBackColor = true;
            // 
            // tabPagePlaylists
            // 
            tabPagePlaylists.Controls.Add(listBoxPlaylistTracks);
            tabPagePlaylists.Controls.Add(lblPlaylistName);
            tabPagePlaylists.ImageIndex = 1;
            tabPagePlaylists.Location = new Point(4, 34);
            tabPagePlaylists.Name = "tabPagePlaylists";
            tabPagePlaylists.Padding = new Padding(3);
            tabPagePlaylists.Size = new Size(766, 339);
            tabPagePlaylists.TabIndex = 1;
            tabPagePlaylists.Text = "Playlists";
            tabPagePlaylists.UseVisualStyleBackColor = true;
            // 
            // listBoxPlaylistTracks
            // 
            listBoxPlaylistTracks.Dock = DockStyle.Fill;
            listBoxPlaylistTracks.FormattingEnabled = true;
            listBoxPlaylistTracks.ItemHeight = 25;
            listBoxPlaylistTracks.Location = new Point(3, 53);
            listBoxPlaylistTracks.Name = "listBoxPlaylistTracks";
            listBoxPlaylistTracks.Size = new Size(760, 283);
            listBoxPlaylistTracks.TabIndex = 3;
            // 
            // lblPlaylistName
            // 
            lblPlaylistName.BackColor = Color.Black;
            lblPlaylistName.Dock = DockStyle.Top;
            lblPlaylistName.Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblPlaylistName.ForeColor = Color.White;
            lblPlaylistName.Location = new Point(3, 3);
            lblPlaylistName.Name = "lblPlaylistName";
            lblPlaylistName.Size = new Size(760, 50);
            lblPlaylistName.TabIndex = 2;
            lblPlaylistName.Text = "Name";
            lblPlaylistName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(798, 764);
            Controls.Add(tabControl);
            Controls.Add(lblTrackTotal);
            Controls.Add(lblPlayerCurrent);
            Controls.Add(progPlayerTime);
            Controls.Add(lblTrackArtist);
            Controls.Add(picboxTrackArtwork);
            Controls.Add(btnPlayPause);
            Controls.Add(btnStepForward);
            Controls.Add(btnStepBack);
            Controls.Add(lblTrackTitle);
            Controls.Add(statusBar);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(820, 820);
            Name = "MainWindow";
            Text = "iDj";
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picboxTrackArtwork).EndInit();
            panel1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPagePlaylists.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusBar;
        private ToolStripStatusLabel toolStripStatusLabeliTunesVersionText;
        private System.Windows.Forms.Timer timerInterface;
        private Label lblTrackTitle;
        private FontAwesome.Sharp.IconButton btnStepBack;
        private FontAwesome.Sharp.IconButton btnStepForward;
        private FontAwesome.Sharp.IconButton btnPlayPause;
        private PictureBox picboxTrackArtwork;
        private Label lblTrackArtist;
        private Label lblTrackAlbum;
        private IDjTimeBar progPlayerTime;
        private Label lblPlayerCurrent;
        private Label lblTrackTotal;
        private ToolStripStatusLabel lblActivity;
        private Panel panel1;
        private TabControl tabControl;
        private TabPage tabPageControls;
        private TabPage tabPagePlaylists;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblTest;
        private Label lblTrackDetails;
        private ListBox listBoxPlaylistTracks;
        private Label lblPlaylistName;
    }
}