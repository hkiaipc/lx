using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Xdgk.Communi;

namespace CommuniServer
{
    public partial class UCXD202Device : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private Device _device;

        /// <summary>
        /// 
        /// </summary>
        public UCXD202Device()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWL2_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCXd202Data_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public XD2402Device XD2402Device
        {
            get { return this._device as XD2402Device; }
            set
            {
                //_xd2402Device = value;
                this._device = value;
                if (_device != null)
                {
                    XD2402Device _xd2402Device = (XD2402Device)_device;
                    this.txtStationName.Text = _xd2402Device.Station.Name;
                    this.txtDevice.Text = _xd2402Device.DeviceDefine.Text;
                    RefreshXD2402Data(_xd2402Device.XD2402Data);
                }
            }
        }
        //private XD2402Device _xd2402Device;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xD2402Data"></param>
        private void RefreshXD2402Data(XD2402Data xD2402Data)
        {
            if (xD2402Data == null)
            {
                ClearData();
            }
            else
            {

                /*
                this.txtDT.Text = data.DT.ToString();
                this.txtBeforeWaterLevel.Text = data.BeforeWaterLevel.ToString();
                this.txtBehindWaterLevel.Text = data.BehindWaterLevel.ToString();
                this.txtHeight.Text = data.Height.ToString();
                this.txtRemainAmount.Text = data.RemainAmount.ToString();
                this.txtInstantFlux.Text = data.InstantFlux.ToString();
                */

                this.txtDT.Text = XD2402Device.XD2402Data.DT.ToString();
                this.txtBeforeWaterLevel.Text = xD2402Data.BeforeWaterLevel.ToString();
                this.txtBehindWaterLevel.Text = xD2402Data.BehindWaterLevel.ToString();
                this.txtHeight.Text = xD2402Data.Height.ToString();
                this.txtInstantFlux.Text = xD2402Data.InstantFlux.ToString();
                this.txtRemainAmount.Text = xD2402Data.RemainAmount.ToString();
                // TODO: 2011-06-13
                //
                //xD2402Data.UsedAmount;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearData()
        {
            this.txtDT.Clear();
            this.txtBeforeWaterLevel.Clear();
            this.txtBehindWaterLevel.Clear();
            this.txtHeight.Clear();
            this.txtRemainAmount.Clear();
            this.txtInstantFlux.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public XD202Device XD202Device
        {
            get { return _device as XD202Device; }
            set
            {
                _device = value;
                if (_device != null)
                {
                    XD202Device _xd202Device = (XD202Device)_device;
                    this.txtStationName.Text = _xd202Device.Station.Name;
                    this.txtDevice.Text = _xd202Device.DeviceDefine.Text;
                    RefreshXD202Data(_xd202Device.XD202Data);
                }
            }
        } private XD202Device _xd202Device;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void RefreshXD202Data(XD202Data data)
        {
            if (data != null)
            {
                this.txtDT.Text = data.DT.ToString();
                this.txtBeforeWaterLevel.Text = data.BeforeWaterLevel.ToString();
                this.txtBehindWaterLevel.Text = data.BehindWaterLevel.ToString();
                this.txtHeight.Text = data.Height.ToString();
                this.txtRemainAmount.Text = data.RemainAmount.ToString();
                this.txtInstantFlux.Text = data.InstantFlux.ToString();
            }
            else
            {
                ClearData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCommuniLog_Click(object sender, EventArgs e)
        {
            //frmCommuniFail f = new frmCommuniFail(this.XD202Device ,
            //    this.XD202Device.CommuniFailDetails);
            if (this._device != null)
            {
                //frmCommuniFail f = new frmCommuniFail(this._device,
                //    this._device.CommuniFailDetails);
                //f.ShowDialog();
                _device.ShowCommuniDetailsDialog();
            }
        }
    }
}
