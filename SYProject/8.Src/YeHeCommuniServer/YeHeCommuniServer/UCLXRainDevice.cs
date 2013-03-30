using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CommuniServer
{
    public partial class UCLXRainDevice : UserControl
    {
        #region RainDevice
        /// <summary>
        /// 
        /// </summary>
        public LXRainDevice RainDevice
        {
            get
            {
                return _rainDevice;
            }
            set
            {
                _rainDevice = value;
                if (_rainDevice != null)
                {
                    this.txtStationName.Text = _rainDevice.Station.Name;
                    this.txtDevice.Text = _rainDevice.DeviceType;
                    if (_rainDevice.Data != null)
                    {
                        LXRainData rainData = _rainDevice.Data as LXRainData;
                        this.txtDT.Text = rainData.DT.ToString();
                        this.txtRain.Text = rainData.Rain.ToString();
                    }

                }
            }
        } private LXRainDevice _rainDevice;
        #endregion //RainDevice

        /// <summary>
        /// 
        /// </summary>
        public UCLXRainDevice()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommuniLog_Click(object sender, EventArgs e)
        {
            this.RainDevice.ShowCommuniDetailsDialog();
        }
    }
}
