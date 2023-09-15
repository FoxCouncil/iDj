// Copyright (c) 2023 Fox Council - iDj - https://github.com/FoxCouncil/iDj

using FontAwesome.Sharp;
using iDj.iTunes;
using System.ComponentModel;
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

            if (currentTrack != null)
            {
                if (currentTrackDatabaseId != currentTrack.TrackDatabaseID)
                {
                    currentTrackDatabaseId = currentTrack.TrackDatabaseID;

                    UpdateCurrentTrack(currentTrack);

                    UpdateAlbumArt(currentTrack);

                    UpdatePlaylist(currentTrack);
                }

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

        private void UpdateCurrentTrack(IITTrack currentTrack)
        {
            currentTrackDuration = currentTrack.Duration;

            progPlayerTime.Maximum = currentTrack.Duration;

            var timeSpan = TimeSpan.FromSeconds(currentTrack.Duration);

            lblTrackTotal.Text = timeSpan.ToString(@"mm\:ss");

            lblTrackArtist.Text = currentTrack.Artist;
            lblTrackTitle.Text = currentTrack.Name;
            lblTrackAlbum.Text = currentTrack.Album;
            lblTrackDetails.Text = $"Year: {currentTrack.Year} | {currentTrack.SampleRate / 1000.0f:F1}Khz | {currentTrack.KindAsString}";
        }

        private async void UpdatePlaylist(IITTrack currentTrack)
        {
            var playlist = currentTrack.Playlist;

            if (playlist != null && currentPlaylistId != playlist.playlistID)
            {
                currentPlaylistId = playlist.playlistID;

                tabPagePlaylists.Text = $"Playlist: {playlist.Name}";
                lblPlaylistName.Text = $"{playlist.Name} | {playlist.Time} | {playlist.Tracks.Count:N0} Tracks";

                listBoxPlaylistTracks.Visible = false;
                iDjSpinnerPlaylist.Visible = true;

                var newPlaylist = new List<string>();

                await Task.Run(() =>
                {
                    var tracks = playlist.Tracks;

                    foreach (IITTrack track in tracks)
                    {
                        newPlaylist.Add($"{track.PlayOrderIndex}. {track.Artist} - {track.Name}");

                        Marshal.FinalReleaseComObject(track);
                    }

                    newPlaylist = newPlaylist.OrderBy(x => int.Parse(x.Split('.').First())).ToList();

                    Marshal.FinalReleaseComObject(tracks);
                });

                Marshal.FinalReleaseComObject(playlist);

                listBoxPlaylistTracks.BeginUpdate();

                listBoxPlaylistTracks.Items.Clear();

                listBoxPlaylistTracks.Items.AddRange(newPlaylist.ToArray());

                listBoxPlaylistTracks.EndUpdate();

                iDjSpinnerPlaylist.Visible = false;

                listBoxPlaylistTracks.Visible = true;
            }

            if (playlist != null)
            {
                if (listBoxPlaylistTracks.Items.Count > currentTrack.PlayOrderIndex)
                {
                    listBoxPlaylistTracks.SelectedIndex = currentTrack.PlayOrderIndex - 1;
                }
            }
        }

        private void UpdateAlbumArt(IITTrack currentTrack)
        {
            ClearAlbumArtwork();

            var artworkCollection = currentTrack.Artwork;

            if (artworkCollection.Count != 0)
            {
                var artwork = artworkCollection[1];

                var fileExtension = GetFileExtensionFromFormat(artwork.Format);

                var executivePath = Path.GetDirectoryName(Application.ExecutablePath) ?? string.Empty;

                var fullPath = Path.Combine(executivePath, $"albumart.{fileExtension}");

                artwork.SaveArtworkToFile(fullPath);

                picboxTrackArtwork.Image = Image.FromFile(fullPath);

                // Perform operations on artwork
                Marshal.FinalReleaseComObject(artwork);  // Release individual Artwork object
            }

            Marshal.FinalReleaseComObject(artworkCollection);  // Release Artwork collection
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