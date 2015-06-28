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
        }


        #endregion
        
        
        #region Events



        #endregion
    }
}
