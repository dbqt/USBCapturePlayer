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

        private FilterInfoCollection VideoDevices { get; set; }

        #endregion


        #region Methods

        private void InitializeProperties()
        {
            
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
            }
        }


        #endregion
        
        
        #region Events



        #endregion
    }
}
