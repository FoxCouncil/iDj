// Copyright (c) 2023 Fox Council - iDj - https://github.com/FoxCouncil/iDj

using FontAwesome.Sharp;
using iDj.iTunes;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace iDj
{
    public partial class MainWindow : Form
    {
        //private readonly char[] SpinnerFrames = { '\u2014', '\u2571', '\u007C', '\u2572', '\u2014' };
        //private readonly char[] SpinnerFrames = {
        //    '\u2014', '\u2574', '\u2576', '\u2575', '\u007C', '\u2577', '\u2575', '\u2576',
        //    '\u2574', '\u2570', '\u256F', '\u256D', '\u256E', '\u256C', '\u256F', '\u2570'B
        //};
        private static readonly char[] SpinnerFrames = { '\u2588', '\u2593', '\u2592', '\u2591', '\u2592', '\u2593', '\u2588', '\u2593', '\u2592', '\u2591', '\u2592', '\u2593', '\u258C', '\u2590', '\u2580', '\u2584' };

        private iTunesAppClass iTunes = new();

        private ImageList tabImageList;

        private string albumArtBase64;

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

            IITSource? iTunesLibrarySource = null;

            // Loop through sources to find the library
            foreach (IITSource source in iTunes.Sources)
            {
                if (source.Kind == ITSourceKind.ITSourceKindLibrary)
                {
                    iTunesLibrarySource = source;
                    // break;
                }
            }

            var indent = string.Empty;

            foreach (IITPlaylist playlist in iTunesLibrarySource.Playlists)
            {
                if (playlist.Kind == ITPlaylistKind.ITPlaylistKindUser)
                {
                    var userPlaylist = playlist as IITUserPlaylist;

                    Debug.WriteLine($"Playlist: ({userPlaylist.SpecialKind}){playlist.Name}");
                }
            }

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

            StartWebServer();
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

                var albumArtFilePath = Path.Combine(executivePath, $"albumart.{fileExtension}");

                artwork.SaveArtworkToFile(albumArtFilePath);

                var image = Image.FromFile(albumArtFilePath);

                albumArtBase64 = image.ToBase64(GetFileMimeTypeFromFormat(artwork.Format));

                picboxTrackArtwork.Image = image;

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

            albumArtBase64 = string.Empty;
        }

        private string ShowNextFrame()
        {
            string frame = SpinnerFrames[frameIndex].ToString();
            frameIndex = (frameIndex + 1) % SpinnerFrames.Length;
            return frame;
        }

        private static string GetFileExtensionFromFormat(ITArtworkFormat format)
        {
            return format switch
            {
                ITArtworkFormat.ITArtworkFormatJPEG => "jpg",
                ITArtworkFormat.ITArtworkFormatPNG => "png",
                ITArtworkFormat.ITArtworkFormatBMP => "bmp",
                _ => "bin",
            };
        }

        private static string GetFileMimeTypeFromFormat(ITArtworkFormat format)
        {
            return format switch
            {
                ITArtworkFormat.ITArtworkFormatJPEG => "image/jpeg",
                ITArtworkFormat.ITArtworkFormatPNG => "image/png",
                ITArtworkFormat.ITArtworkFormatBMP => "image/bmp",
                _ => "image/raw",
            };
        }

        private void StartWebServer()
        {
            Task.Run(() =>
            {
                var listener = new HttpListener();

                listener.Prefixes.Add("http://localhost:5000/");
                listener.Start();

                while (true)
                {
                    var context = listener.GetContext();
                    var request = context.Request;
                    var response = context.Response;

                    var responseData = HandleRequest(request);

                    if (responseData == null)
                    {
                        var path = string.Empty;

                        if (request.RawUrl == null || request.RawUrl == "/")
                        {
                            path = "index.html";
                        }
                        else
                        {
                            path = request.RawUrl;
                        }

                        WriteHtmlResponse(response, path);
                    }
                    else
                    {
                        WriteJsonResponse(response, responseData);
                    }
                }
            });
        }

        private object HandleRequest(HttpListenerRequest request)
        {
            switch (request.RawUrl)
            {
                case "/info":
                {
                    if (iTunes.CurrentTrack != null)
                    {
                        return new
                        {
                            response = "ok",
                            artist = iTunes.CurrentTrack.Artist,
                            title = iTunes.CurrentTrack.Name,
                            album = iTunes.CurrentTrack.Album,
                            genre = iTunes.CurrentTrack.Genre,
                            year = iTunes.CurrentTrack.Year,
                            art = albumArtBase64,
                        };
                    }

                    return new
                    {
                        response = "ok",
                    };
                }
                
                case "/playpause":
                {
                    Invoke((MethodInvoker)delegate
                    {
                        iTunes.PlayPause();
                    });

                    return new { response = "ok" };
                }

                case "/next":
                {
                    Invoke((MethodInvoker)delegate
                    {
                        iTunes.NextTrack();
                    });

                    return new { response = "ok" };
                }

                case "/prev":
                {
                    Invoke((MethodInvoker)delegate
                    {
                        iTunes.PreviousTrack();
                    });

                    return new { response = "ok" };
                }
            }

            return null;
        }

        private static void WriteHtmlResponse(HttpListenerResponse response, string path)
        {
            if (path.StartsWith('/'))
            {
                path = path[1..];
            }

            var filePath = Path.Combine(Debugger.IsAttached ? "..\\..\\..\\" : "", "static\\", path);

            if (!File.Exists(filePath))
            {
                filePath = Path.Combine(Debugger.IsAttached ? "..\\..\\..\\" : "", "static\\index.html");
            }

            var buffer = File.ReadAllBytes(filePath);

            var fileInfo = new FileInfo(filePath);

            response.ContentType = GetFileMimeTypeFromFileExtension(fileInfo.Extension[1..]);
            response.ContentLength64 = buffer.Length;

            var output = response.OutputStream;

            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        private static string GetFileMimeTypeFromFileExtension(string ext)
        {
            return ext switch
            {
                "jpg" => "image/jpeg",
                "jpeg" => "image/jpeg",
                "png" => "image/png",
                "bmp" => "image/bmp",
                "htm" => "text/html",
                "html" => "text/html",
                "css" => "text/css",
                "woff" => "application/font-woff",
                "woff2" => "font/woff2",
                "ttf" => "font/truetype",
                _ => "image/raw",
            };
        }

        private static void WriteJsonResponse(HttpListenerResponse response, object responseData)
        {
            var buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(responseData));

            response.ContentType = "application/json";
            response.ContentLength64 = buffer.Length;

            var output = response.OutputStream;

            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}