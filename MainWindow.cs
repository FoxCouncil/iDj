using FontAwesome.Sharp;
using iDj.iTunes;
using System.Runtime.InteropServices;

namespace iDj
{
    public partial class MainWindow : Form
    {
        //private readonly char[] SpinnerFrames = { '\u2014', '\u2571', '\u007C', '\u2572', '\u2014' };
        //private readonly char[] SpinnerFrames = {
        //    '\u2014', '\u2574', '\u2576', '\u2575', '\u007C', '\u2577', '\u2575', '\u2576',
        //    '\u2574', '\u2570', '\u256F', '\u256D', '\u256E', '\u256C', '\u256F', '\u2570'
        //};
        private static readonly char[] SpinnerFrames = { '\u2588', '\u2593', '\u2592', '\u2591', '\u2592', '\u2593', '\u2588', '\u2593', '\u2592', '\u2591', '\u2592', '\u2593', '\u258C', '\u2590', '\u2580', '\u2584' };

        private iTunesAppClass iTunes = new();

        private ImageList tabImageList;

        private bool isPlaying;

        private int frameIndex;
        private int currentPlaylistId;
        private int currentTrackDatabaseId;
        private int currentTrackDuration;

        public MainWindow()
        {
            InitializeComponent();

            FormClosed += (s, e) => Marshal.ReleaseComObject(iTunes);

            iTunes.OnAboutToPromptUserToQuitEvent += Quit;
            iTunes.OnQuittingEvent += Quit;

            tabImageList = new();
            tabImageList.AddIcon(IconChar.Gamepad);
            tabImageList.AddIcon(IconChar.List);

            tabControl.ImageList = tabImageList;

            lblTrackArtist.Text = string.Empty;
            lblTrackTitle.Text = string.Empty;
            lblTrackAlbum.Text = string.Empty;
            lblTrackDetails.Text = string.Empty;

            toolStripStatusLabeliTunesVersionText.Text = $"Version: {iTunes.Version}";
            toolStripStatusLabelCurrentTime.Text = string.Empty;
            toolStripStatusLabelCurrentDate.Text = string.Empty;
        }

        private void Quit()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(Quit));

                return;
            }

            iTunes.OnAboutToPromptUserToQuitEvent -= Quit;
            iTunes.OnQuittingEvent -= Quit;

            Close();
        }

        private void timerInterface_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            iTunes.PlayPause();
        }

        private void btnStepBack_Click(object sender, EventArgs e)
        {
            iTunes.PreviousTrack();
        }

        private void btnStepForward_Click(object sender, EventArgs e)
        {
            iTunes.NextTrack();
        }

        private void UpdateUI()
        {
            timerInterface.Stop();

            UpdateUIStates();

            var currentTrack = iTunes.CurrentTrack;

            if (currentTrack != null && currentTrackDatabaseId != currentTrack.TrackDatabaseID)
            {
                currentTrackDatabaseId = currentTrack.TrackDatabaseID;
                currentTrackDuration = currentTrack.Duration;

                Marshal.ReleaseComObject(currentTrack);

                UpdateCurrentTrack();

                UpdatePlaylist();

                UpdateAlbumArt();
            }
            else if (currentTrack != null && isPlaying)
            {
                UpdatePlaybackTime();
            }

            UpdateUIStatusBar();

            timerInterface.Start();

            toolStripStatusLabelActivity.Text = ShowNextFrame();
        }
        private void UpdateUIStates()
        {
            var isPlaying = iTunes.PlayerState == ITPlayerState.ITPlayerStatePlaying;

            btnPlayPause.IconChar = isPlaying ? IconChar.Pause : IconChar.Play;
        }

        private void UpdateCurrentTrack()
        {
            var currentTrack = iTunes.CurrentTrack;
            
            progPlayerTime.Maximum = currentTrack.Duration;

            var timeSpan = TimeSpan.FromSeconds(currentTrack.Duration);

            lblTrackTotal.Text = timeSpan.ToString(@"mm\:ss");

            lblTrackArtist.Text = currentTrack.Artist;
            lblTrackTitle.Text = currentTrack.Name;
            lblTrackAlbum.Text = currentTrack.Album;
            lblTrackDetails.Text = $"Year: {currentTrack.Year} | {currentTrack.SampleRate / 1000.0f:F1}Khz | {currentTrack.KindAsString}";

            Marshal.ReleaseComObject(currentTrack);
        }

        private void UpdatePlaylist()
        {
            var currentTrack = iTunes.CurrentTrack;

            var playlist = currentTrack.Playlist;

            if (playlist != null && currentPlaylistId != playlist.playlistID)
            {
                currentPlaylistId = playlist.playlistID;

                tabPagePlaylists.Text = $"Playlist: {playlist.Name}";
                lblPlaylistName.Text = $"{playlist.Name} | {playlist.Time} | {playlist.Tracks.Count}";

                listBoxPlaylistTracks.Items.Clear();

                if (playlist.Tracks.Count < 5000)
                {
                    listBoxPlaylistTracks.BeginInvoke(new Action(() =>
                    {
                        listBoxPlaylistTracks.BeginUpdate();

                        foreach (IITTrack track in playlist.Tracks)
                        {
                            listBoxPlaylistTracks.Items.Add($"{track.PlayOrderIndex}. {track.Artist} - {track.Name}");
                        }

                        listBoxPlaylistTracks.EndUpdate();
                    }));

                }
            }

            var trackSelectedIndex = currentTrack.PlayOrderIndex - 1;

            if (listBoxPlaylistTracks.Items.Count > currentTrack.PlayOrderIndex)
            {
                listBoxPlaylistTracks.SelectedIndex = trackSelectedIndex;
            }

            Marshal.ReleaseComObject(currentTrack);
        }

        private void UpdateAlbumArt()
        {
            ClearAlbumArtwork();

            var currentTrack = iTunes.CurrentTrack;

            var artwork = currentTrack.Artwork.Count != 0 ? currentTrack.Artwork[1] : null;

            if (artwork != null)
            {
                var fileExtension = GetFileExtensionFromFormat(artwork.Format);

                var executivePath = Path.GetDirectoryName(Application.ExecutablePath) ?? string.Empty;

                var fullPath = Path.Combine(executivePath, $"albumart.{fileExtension}");

                artwork.SaveArtworkToFile(fullPath);

                picboxTrackArtwork.Image = Image.FromFile(fullPath);
            }

            Marshal.ReleaseComObject(currentTrack);
        }

        private void UpdatePlaybackTime()
        {
            progPlayerTime.Value = iTunes.PlayerPosition;
            progPlayerTime.Text = TimeSpan.FromSeconds(currentTrackDuration - iTunes.PlayerPosition).ToString(@"\-mm\:ss");

            lblPlayerCurrent.Text = TimeSpan.FromSeconds(progPlayerTime.Value).ToString(@"mm\:ss");
        }

        private void UpdateUIStatusBar()
        {
            toolStripStatusLabelCurrentTime.Text = DateTime.Now.ToString("T");

            toolStripStatusLabelCurrentDate.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy");

            Text = $"{lblTrackArtist.Text} - {lblTrackTitle.Text} | iDj";
        }

        private void ClearAlbumArtwork()
        {
            if (picboxTrackArtwork.Image != null)
            {
                picboxTrackArtwork.Image.Dispose();
                picboxTrackArtwork.Image = null;
            }
        }

        private string GetFileExtensionFromFormat(ITArtworkFormat format)
        {
            switch (format)
            {
                case ITArtworkFormat.ITArtworkFormatJPEG: return "jpg";
                case ITArtworkFormat.ITArtworkFormatPNG: return "png";
                case ITArtworkFormat.ITArtworkFormatBMP: return "bmp";
                default: return "bin";
            }
        }

        private string ShowNextFrame()
        {
            string frame = SpinnerFrames[frameIndex].ToString();
            frameIndex = (frameIndex + 1) % SpinnerFrames.Length;
            return frame;
        }
    }
}