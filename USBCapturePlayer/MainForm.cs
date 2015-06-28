using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using NAudio.Wave;

namespace USBCapturePlayer
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            InitializeProperties();
            InitializeSelectors();
        }

        #endregion


        #region Properties

        /// <summary>
        /// Collection of video source devices.
        /// </summary>
        private FilterInfoCollection VideoDevices { get; set; }

        /// <summary>
        /// Value indicating whether a video is playing.
        /// </summary>
        private bool IsPlaying { get; set; }

        /// <summary>
        /// Value of width/height ratio of video source.
        /// </summary>
        private float VideoSourceWHRatio { get; set; }

        private WaveIn CurrentWaveIn { get; set; }
        private WaveOut CurrentWaveOut { get; set; }
        private BufferedWaveProvider WaveBuffer { get; set; }

        #endregion


        #region Methods

        /// <summary>
        /// Initialize properties.
        /// </summary>
        private void InitializeProperties()
        {
            IsPlaying = false;
            
            VideoSourceWHRatio = 1f;

            CurrentWaveIn = new WaveIn();
            CurrentWaveIn.DataAvailable += AudioWaveIn_DataAvailable;
            CurrentWaveOut = new WaveOut();
            CurrentWaveOut.DesiredLatency = 100;
            WaveBuffer = null;
        }

        /// <summary>
        /// Initialize both video and audio sources selectors.
        /// </summary>
        private void InitializeSelectors()
        {
            try
            {
                // Initialize all video devices.
                VideoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (VideoDevices.Count == 0)
                {
                    throw new ApplicationException();
                }

                // Add all devices to source selector.
                VideoSourceSelector.Items.Clear();

                foreach (FilterInfo device in VideoDevices)
                {
                    VideoSourceSelector.Items.Add(device.Name);
                }

                // Enable source selector.
                VideoSourceSelector.SelectedIndex = 0;
                VideoSourceSelector.Enabled = true;
            }
            catch (ApplicationException)
            {
                // There was a problem in loading video sources, disabling the source selector.
                VideoSourceSelector.Enabled = false;
                ActiveButton.Enabled = false;
            }

            try
            {
                // Initialize audio sources.
                AudioSourceSelector.Items.Clear();
                int waveInDevices = WaveIn.DeviceCount;

                if (waveInDevices == 0)
                {
                    throw new ApplicationException();
                }

                // Add all devices to source selector.
                for (int waveInDevice = 0; waveInDevice < waveInDevices; waveInDevice++)
                {
                    WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(waveInDevice);
                    AudioSourceSelector.Items.Add(deviceInfo.ProductName);
                }

                // Enable source selector.
                AudioSourceSelector.SelectedIndex = 0;
                AudioSourceSelector.Enabled = true;
            }
            catch (Exception)
            {
                // There was a problem in loading audio sources, disabling the source selector.
                AudioSourceSelector.Enabled = false;
                ActiveButton.Enabled = false;
            }
        }

        /// <summary>
        /// Activates or desactivates the video and audio player.
        /// </summary>
        private void TogglePlayerState()
        {
            if (IsPlaying)
            {
                // Link video input device.
                VideoCaptureDevice videoCaptureDevice = new VideoCaptureDevice(VideoDevices[VideoSourceSelector.SelectedIndex].MonikerString);
                VideoSourceWHRatio = ((float)(videoCaptureDevice.VideoCapabilities.FirstOrDefault().FrameSize.Width)) / ((float)(videoCaptureDevice.VideoCapabilities.FirstOrDefault().FrameSize.Height));
                MainVideoPlayer.VideoSource = videoCaptureDevice;

                // Link audio input device to WaveIn.
                CurrentWaveIn.DeviceNumber = AudioSourceSelector.SelectedIndex;

                // Create WaveBuffer with the WaveIn.
                WaveBuffer = new BufferedWaveProvider(CurrentWaveIn.WaveFormat);
                WaveBuffer.DiscardOnBufferOverflow = true;

                // Initialize WaveOut with the WaveBuffer.
                CurrentWaveOut.Init(WaveBuffer);

                // Start playing the video and audio.
                ResizeVideoPlayer();
                MainVideoPlayer.Start();
                CurrentWaveIn.StartRecording();
                CurrentWaveOut.Play();
            }
            else
            {
                // Stop audio components.
                CurrentWaveOut.Stop();
                CurrentWaveIn.StopRecording();

                // Stop video components.
                MainVideoPlayer.SignalToStop();
                MainVideoPlayer.WaitForStop();
            }
        }

        /// <summary>
        /// Resizes the video player to keep the right ratio.
        /// </summary>
        private void ResizeVideoPlayer()
        {

            float PanelWHRatio = ((float)(MainPanel.Width)) / ((float)(MainPanel.Height));

            // Panel is larger in width than its height.
            if (PanelWHRatio < VideoSourceWHRatio)
            {
                MainVideoPlayer.Width = MainPanel.Width;
                MainVideoPlayer.Height = (int)(MainPanel.Width / VideoSourceWHRatio);
            }
            // Panel is higher in height than its width.
            else
            {
                MainVideoPlayer.Height = MainPanel.Height;
                MainVideoPlayer.Width = (int)(MainPanel.Height * VideoSourceWHRatio);
            }
            
            //Reposition the player.
            int leftside = (MainPanel.Width - MainVideoPlayer.Width) / 2;
            int upside = (MainPanel.Height - MainVideoPlayer.Height) / 2;
            MainVideoPlayer.Location = new Point(leftside, upside); 
        }

        #endregion

        
        
        
        #region Events

        /// <summary>
        /// Event called when the Active Button is clicked, managing the state of the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveButton_Click(object sender, EventArgs e)
        {
            IsPlaying = !IsPlaying;

            TogglePlayerState();

            if (IsPlaying)
            {
                ActiveButton.Text = "Stop";
                VideoSourceSelector.Enabled = false;
                AudioSourceSelector.Enabled = false;
            }
            else
            {
                ActiveButton.Text = "Play";
                VideoSourceSelector.Enabled = true;
                AudioSourceSelector.Enabled = true;
            }
        }

        /// <summary>
        /// Feed the audio buffer when data is available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AudioWaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            WaveBuffer.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        /// <summary>
        /// When the window size changes, stop the video, resize then restart the video.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            MainVideoPlayer.SignalToStop();
            MainVideoPlayer.WaitForStop();
            
            ResizeVideoPlayer();

            MainVideoPlayer.Start();
        }

        /// <summary>
        /// Assures that everything is stopped before exiting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop audio components.
            CurrentWaveOut.Stop();
            CurrentWaveIn.StopRecording();

            // Stop video components.
            MainVideoPlayer.SignalToStop();
            MainVideoPlayer.WaitForStop();
        }

        #endregion

        

    }
}
