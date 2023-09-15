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
            Label labelPlaybackSource;
            Panel panelCurrentTrackBackground;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            lblTrackDetails = new Label();
            lblTrackAlbum = new Label();
            statusBar = new StatusStrip();
            toolStripStatusLabelActivity = new ToolStripStatusLabel();
            toolStripStatusLabeliTunesVersionText = new ToolStripStatusLabel();
            toolStripStatusLabelCurrentTime = new ToolStripStatusLabel();
            toolStripStatusLabelCurrentDate = new ToolStripStatusLabel();
            lblTest = new ToolStripStatusLabel();
            timerInterface = new System.Windows.Forms.Timer(components);
            lblTrackTitle = new Label();
            btnStepBack = new FontAwesome.Sharp.IconButton();
            btnStepForward = new FontAwesome.Sharp.IconButton();
            btnPlayPause = new FontAwesome.Sharp.IconButton();
            picboxTrackArtwork = new PictureBox();
            lblTrackArtist = new Label();
            progPlayerTime = new IDjTimeBar();
            lblPlayerCurrent = new Label();
            lblTrackTotal = new Label();
            tabControl = new TabControl();
            tabPageControls = new TabPage();
            idjToggleButton1 = new iDJToggleButton();
            comboBox1 = new ComboBox();
            tabPagePlaylists = new TabPage();
            iDjSpinnerPlaylist = new iDjSpinner();
            listBoxPlaylistTracks = new iDjDoubleClickListBox();
            lblPlaylistName = new Label();
            labelPlaybackSource = new Label();
            panelCurrentTrackBackground = new Panel();
            panelCurrentTrackBackground.SuspendLayout();
            statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picboxTrackArtwork).BeginInit();
            tabControl.SuspendLayout();
            tabPageControls.SuspendLayout();
            tabPagePlaylists.SuspendLayout();
            SuspendLayout();
            // 
            // labelPlaybackSource
            // 
            labelPlaybackSource.BorderStyle = BorderStyle.FixedSingle;
            labelPlaybackSource.Location = new Point(6, 14);
            labelPlaybackSource.Name = "labelPlaybackSource";
            labelPlaybackSource.Size = new Size(120, 25);
            labelPlaybackSource.TabIndex = 0;
            labelPlaybackSource.Text = "Source:";
            labelPlaybackSource.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelCurrentTrackBackground
            // 
            panelCurrentTrackBackground.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelCurrentTrackBackground.BackColor = Color.Black;
            panelCurrentTrackBackground.Controls.Add(lblTrackDetails);
            panelCurrentTrackBackground.Controls.Add(lblTrackAlbum);
            panelCurrentTrackBackground.Location = new Point(0, 0);
            panelCurrentTrackBackground.Name = "panelCurrentTrackBackground";
            panelCurrentTrackBackground.Size = new Size(798, 174);
            panelCurrentTrackBackground.TabIndex = 18;
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
            // statusBar
            // 
            statusBar.ImageScalingSize = new Size(24, 24);
            statusBar.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelActivity, toolStripStatusLabeliTunesVersionText, toolStripStatusLabelCurrentTime, toolStripStatusLabelCurrentDate, lblTest });
            statusBar.Location = new Point(0, 728);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(798, 36);
            statusBar.TabIndex = 1;
            statusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabelActivity
            // 
            toolStripStatusLabelActivity.AutoSize = false;
            toolStripStatusLabelActivity.BackColor = SystemColors.Control;
            toolStripStatusLabelActivity.BorderSides = ToolStripStatusLabelBorderSides.Right;
            toolStripStatusLabelActivity.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusLabelActivity.Font = new Font("Consolas", 11F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabelActivity.ForeColor = Color.DarkGreen;
            toolStripStatusLabelActivity.Name = "toolStripStatusLabelActivity";
            toolStripStatusLabelActivity.Size = new Size(50, 29);
            toolStripStatusLabelActivity.Text = "-";
            toolStripStatusLabelActivity.TextAlign = ContentAlignment.TopCenter;
            // 
            // toolStripStatusLabeliTunesVersionText
            // 
            toolStripStatusLabeliTunesVersionText.BackColor = SystemColors.Control;
            toolStripStatusLabeliTunesVersionText.BorderSides = ToolStripStatusLabelBorderSides.Right;
            toolStripStatusLabeliTunesVersionText.Name = "toolStripStatusLabeliTunesVersionText";
            toolStripStatusLabeliTunesVersionText.Size = new Size(83, 29);
            toolStripStatusLabeliTunesVersionText.Text = "OFFLINE";
            // 
            // toolStripStatusLabelCurrentTime
            // 
            toolStripStatusLabelCurrentTime.BackColor = SystemColors.Control;
            toolStripStatusLabelCurrentTime.BorderSides = ToolStripStatusLabelBorderSides.Right;
            toolStripStatusLabelCurrentTime.Name = "toolStripStatusLabelCurrentTime";
            toolStripStatusLabelCurrentTime.Size = new Size(105, 29);
            toolStripStatusLabelCurrentTime.Text = "4:20:00 PM";
            // 
            // toolStripStatusLabelCurrentDate
            // 
            toolStripStatusLabelCurrentDate.BackColor = SystemColors.Control;
            toolStripStatusLabelCurrentDate.BorderSides = ToolStripStatusLabelBorderSides.Right;
            toolStripStatusLabelCurrentDate.Name = "toolStripStatusLabelCurrentDate";
            toolStripStatusLabelCurrentDate.Size = new Size(216, 29);
            toolStripStatusLabelCurrentDate.Text = "Monday, June 15th, 2009";
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
            tabPageControls.BackColor = Color.Black;
            tabPageControls.Controls.Add(idjToggleButton1);
            tabPageControls.Controls.Add(comboBox1);
            tabPageControls.Controls.Add(labelPlaybackSource);
            tabPageControls.ForeColor = Color.White;
            tabPageControls.ImageIndex = 0;
            tabPageControls.Location = new Point(4, 34);
            tabPageControls.Name = "tabPageControls";
            tabPageControls.Padding = new Padding(3);
            tabPageControls.Size = new Size(766, 339);
            tabPageControls.TabIndex = 0;
            tabPageControls.Text = "Controls";
            // 
            // idjToggleButton1
            // 
            idjToggleButton1.BackColor = Color.Transparent;
            idjToggleButton1.FlatStyle = FlatStyle.Flat;
            idjToggleButton1.IconChar = FontAwesome.Sharp.IconChar.MicrophoneAlt;
            idjToggleButton1.IconColor = Color.White;
            idjToggleButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            idjToggleButton1.IconSize = 72;
            idjToggleButton1.Location = new Point(100, 159);
            idjToggleButton1.Name = "idjToggleButton1";
            idjToggleButton1.Size = new Size(132, 118);
            idjToggleButton1.TabIndex = 2;
            idjToggleButton1.ToggleOnColor = Color.Red;
            idjToggleButton1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(132, 11);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(628, 33);
            comboBox1.TabIndex = 1;
            // 
            // tabPagePlaylists
            // 
            tabPagePlaylists.BackColor = Color.DimGray;
            tabPagePlaylists.Controls.Add(iDjSpinnerPlaylist);
            tabPagePlaylists.Controls.Add(listBoxPlaylistTracks);
            tabPagePlaylists.Controls.Add(lblPlaylistName);
            tabPagePlaylists.ForeColor = Color.White;
            tabPagePlaylists.ImageIndex = 1;
            tabPagePlaylists.Location = new Point(4, 34);
            tabPagePlaylists.Name = "tabPagePlaylists";
            tabPagePlaylists.Padding = new Padding(3);
            tabPagePlaylists.Size = new Size(766, 339);
            tabPagePlaylists.TabIndex = 1;
            tabPagePlaylists.Text = "Playlists";
            // 
            // iDjSpinnerPlaylist
            // 
            iDjSpinnerPlaylist.Dock = DockStyle.Fill;
            iDjSpinnerPlaylist.Location = new Point(3, 53);
            iDjSpinnerPlaylist.Name = "iDjSpinnerPlaylist";
            iDjSpinnerPlaylist.Size = new Size(760, 283);
            iDjSpinnerPlaylist.TabIndex = 4;
            iDjSpinnerPlaylist.Visible = false;
            // 
            // listBoxPlaylistTracks
            // 
            listBoxPlaylistTracks.BackColor = Color.DimGray;
            listBoxPlaylistTracks.Dock = DockStyle.Fill;
            listBoxPlaylistTracks.ForeColor = Color.White;
            listBoxPlaylistTracks.ItemHeight = 25;
            listBoxPlaylistTracks.Location = new Point(3, 53);
            listBoxPlaylistTracks.Name = "listBoxPlaylistTracks";
            listBoxPlaylistTracks.ScrollAlwaysVisible = true;
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
            Controls.Add(panelCurrentTrackBackground);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(820, 820);
            Name = "MainWindow";
            Text = "iDj";
            panelCurrentTrackBackground.ResumeLayout(false);
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picboxTrackArtwork).EndInit();
            tabControl.ResumeLayout(false);
            tabPageControls.ResumeLayout(false);
            tabPagePlaylists.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusBar;
        private ToolStripStatusLabel toolStripStatusLabelCurrentTime;
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
        private ToolStripStatusLabel toolStripStatusLabelActivity;
        private TabControl tabControl;
        private TabPage tabPageControls;
        private TabPage tabPagePlaylists;
        private ToolStripStatusLabel toolStripStatusLabelCurrentDate;
        private ToolStripStatusLabel lblTest;
        private Label lblTrackDetails;
        private iDjDoubleClickListBox listBoxPlaylistTracks;
        private Label lblPlaylistName;
        private ToolStripStatusLabel toolStripStatusLabeliTunesVersionText;
        private ComboBox comboBox1;
        private iDjSpinner iDjSpinnerPlaylist;
        private iDJToggleButton idjToggleButton1;
    }
}