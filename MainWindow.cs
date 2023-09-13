using FontAwesome.Sharp;
using iDj.iTunes;
using System.Collections.Concurrent;
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

        private readonly iTunesAppClass iTunes = new();

        private ImageList tabImageList;

        private int frameIndex;
        private int currentPlaylistId;
        private int currentTrackDatabaseId;
        private int currentTrackDuration;

        public MainWindow()
        {
            InitializeComponent();

            iTunes.OnAboutToPromptUserToQuitEvent += Quit;
            iTunes.OnQuittingEvent += Quit;

            tabImageList = new();
            tabImageList.AddIcon(IconChar.Gamepad);
            tabImageList.AddIcon(IconChar.List);

            tabControl.ImageList = tabImageList;

            toolStripStatusLabeliTunesVersionText.Text = $"Version: {iTunes.Version}";
        }

        private void Quit()
        {
            if (InvokeRequired)
            {
                Invoke(Quit);

                return;
            }

            Marshal.ReleaseComObject(iTunes);

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

            var isPlaying = iTunes.PlayerState == ITPlayerState.ITPlayerStatePlaying;

            btnPlayPause.IconChar = isPlaying ? IconChar.Pause : IconChar.Play;

            var currentTrack = iTunes.CurrentTrack;

            if (currentTrack != null)
            {
                try
                {
                    if (currentTrackDatabaseId != currentTrack.TrackDatabaseID)
                    {
                        // Update Only Once Per Change

                        currentTrackDatabaseId = currentTrack.TrackDatabaseID;
                        currentTrackDuration = currentTrack.Duration;

                        progPlayerTime.Maximum = currentTrack.Duration;

                        var timeSpan = TimeSpan.FromSeconds(currentTrack.Duration);

                        lblTrackTotal.Text = timeSpan.ToString(@"mm\:ss");

                        lblTrackArtist.Text = currentTrack.Artist;
                        lblTrackTitle.Text = currentTrack.Name;
                        lblTrackAlbum.Text = currentTrack.Album;
                        lblTrackDetails.Text = $"Year: {currentTrack.Year} | {currentTrack.SampleRate / 1000.0f:F1}Khz | {currentTrack.KindAsString}";

                        var playlist = currentTrack.Playlist;

                        if (playlist != null && currentPlaylistId != playlist.playlistID)
                        {
                            currentPlaylistId = playlist.playlistID;

                            tabPagePlaylists.Text = $"Playlist: {playlist.Name}";
                            lblPlaylistName.Text = $"{playlist.Name} | {playlist.Time} | {playlist.Tracks.Count}";

                            listBoxPlaylistTracks.Items.Clear();

                            if (playlist.Tracks.Count < 500)
                            {
                                var tracks = new List<string>(playlist.Tracks.Count);

                                foreach (IITTrack track in playlist.Tracks)
                                {
                                    tracks.Add($"{track.Artist} - {track.Name}");
                                }

                                listBoxPlaylistTracks.Items.AddRange(tracks.ToArray());
                            }
                        }

                        listBoxPlaylistTracks.SelectedIndex = currentTrack.PlayOrderIndex - 1;

                        ClearAlbumArtwork();

                        var artwork = currentTrack.Artwork.Count != 0 ? currentTrack.Artwork[1] : null;

                        if (artwork != null)
                        {
                            var fileExtension = GetFileExtensionFromFormat(artwork.Format);

                            var executivePath = Path.GetDirectoryName(Application.ExecutablePath) ?? string.Empty;

                            var fullPath = Path.Combine(executivePath, $"albumart.{fileExtension}");

                            artwork.SaveArtworkToFile(fullPath);

                            picboxTrackArtwork.Image = Image.FromFile(fullPath);
                        }
                    }

                    // Update Time;
                    progPlayerTime.Value = iTunes.PlayerPosition;
                    progPlayerTime.Text = TimeSpan.FromSeconds(currentTrackDuration - iTunes.PlayerPosition).ToString(@"\-mm\:ss");

                    lblPlayerCurrent.Text = TimeSpan.FromSeconds(progPlayerTime.Value).ToString(@"mm\:ss");
                }
                catch
                {
                    // noop
                }

                Marshal.ReleaseComObject(currentTrack);
            }

            Text = $"{lblTrackArtist.Text} - {lblTrackTitle.Text} | iDj";

            timerInterface.Start();

            lblActivity.Text = ShowNextFrame();
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