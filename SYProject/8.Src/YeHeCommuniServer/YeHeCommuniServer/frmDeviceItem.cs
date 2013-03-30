using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Communi;
using Xdgk.Common;

namespace CommuniServer
{
    public partial class frmDeviceItem : NUnit.UiKit.SettingsDialogBase
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public frmDeviceItem()
        //{
        //    InitializeComponent();
        //}

        //private void frmDeviceItem_Load(object sender, EventArgs e)
        //{

        //}



        #region IsAdd
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsAdd()
        {
            return ADEState == ADEStatus.Add;
        }
        #endregion //IsAdd


        #region IsEdit
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEdit()
        {
            return ADEState == ADEStatus.Edit;
        }
        #endregion //IsEdit


        #region Station
        /// <summary>
        /// 
        /// </summary>
        public Station Station
        {
            get { return this._station; }
            set 
            {
                if (this._station != value)
                {
                    this._station = value;
                }
            }
        } private Station _station;
        #endregion //Station


        #region DeviceType
        /// <summary>
        /// 
        /// </summary>
        public string DeviceType
        {
            get { return _deviceType; }
            set { _deviceType = value; }
        } private string  _deviceType;
        #endregion //DeviceType


        #region Device
        /// <summary>
        /// 
        /// </summary>
        public Device Device
        {
            get { return _device; }
            set 
            {
                _device = value;
                //if (_device != null)
                //{
                //    this.Station = _device.Station;
                //}
            }
        } private Device _device;
        #endregion //Device

        #region frmDeviceItem
        /// <summary>
        /// 
        /// </summary>
        protected frmDeviceItem ()
        {
            InitializeComponent();
        }
        #endregion //frmDeviceItem

        #region frmDeviceItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        public frmDeviceItem(Station st, string deviceType)
            : this()
        {
            if (st == null)
                throw new ArgumentNullException("st");
            this.Station = st;
            this.DeviceType= deviceType;
            this._adeState = ADEStatus.Add;

            this.txtOwnerStatoin.Text = Station.Name;

            //string deviceText = YeHeCommuniServerApp.Default.CommuniSoft.OperaFactory.DeviceDefineCollection.GetDeviceText(deviceType);
            string deviceText = YeHeCommuniServerApp.Default.CommuniSoft.DeviceDefineManager.DeviceDefineCollection.GetDeviceText(deviceType);
            this.txtDeviceType.Text = deviceText;
        }
        #endregion //frmDeviceItem

        #region frmDeviceItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public frmDeviceItem(Device device)
            : this()
        {
            
            if (device == null)
            {
                throw new ArgumentNullException("device");
            }
            this._device = device;
            this.DeviceType = device.DeviceType;
            //this._station = (CZGRStation)device.Station;
            this.Station = device.Station;

            this.txtOwnerStatoin.Text = this._device.Station.Name;
            this.txtDeviceType.Text = this._device.Text;
            this.txtName.Text = this._device.Name;
            this.txtRemark.Text = this._device.Remark;
            //this.cmbDeviceType.Text = CZGRCommon.DeviceTypes.GetText(_device.DeviceType);
            this.numDeviceAddress.Value = _device.Address;
            this._adeState = ADEStatus.Edit;
        }
        #endregion //frmDeviceItem

        #region Address
        /// <summary>
        /// 
        /// </summary>
        public int Address
        {
            get { return (int)this.numDeviceAddress.Value; }
            set { this.numDeviceAddress.Value = value; }
        }
        #endregion //Address



        #region DeviceName
        /// <summary>
        /// 
        /// </summary>
        public string DeviceName
        {
            get { return this.txtName.Text.Trim(); }
            set { this.txtName.Text = value; }
        }
        #endregion //DeviceName


        #region Remark
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get { return this.txtRemark.Text.Trim(); }
            set { this.txtRemark.Text = value; }
        }
        #endregion //Remark

        #region ExistAddress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool ExistAddress(string deviceType, int address)
        {
            return this.ExistAddress(deviceType, address, null);
        }
        /// <summary>
        /// 检查集合中是否已经存在相同地址
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool ExistAddress(string deviceType, int address, Device ignore)
        {
            return this.Station.Devices.ExistAddress(deviceType, address, ignore);
        }
        #endregion //ExistAddress


        #region frmDeviceItem_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDeviceItem_Load(object sender, EventArgs e)
        {
            this.UpdateFormText();
        }
        #endregion //frmDeviceItem_Load

        #region VerifyAddress
        /// <summary>
        /// 
        /// </summary>
        public bool VerifyAddress()
        {
            if (ExistAddress(this.DeviceType, this.Address, this.Device))
            {
                // TODO: deviceTypeText
                //
                string deviceTypeText = "CZGRCommon.DeviceTypes.GetText(this.DeviceType)";

                string msg = string.Format(strings.ExistAddress,
                    deviceTypeText, this.Address);
                NUnit.UiKit.UserMessage.DisplayFailure(msg);
                return false;
            }
            return true;
        }
        #endregion //VerifyAddress

        /// <summary>
        /// 
        /// </summary>
        public void UpdateFormText()
        {
            this.Text += " - " + GetADEStateText(this.ADEState);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aDEState"></param>
        /// <returns></returns>
        private string GetADEStateText(ADEStatus aDEState)
        {
            if (aDEState == ADEStatus.Add)
                return "增加";
            if (aDEState == ADEStatus.Edit)
                return "修改";
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public ADEStatus ADEState
        {
            get { return _adeState; }
        } private ADEStatus _adeState;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (VerifyAddress())
            {
                if (ADEState == ADEStatus.Edit)
                {
                    EditDevice();
                }
                else
                {
                    DeviceDefine dd = YeHeCommuniServerApp.Default.CommuniSoft.DeviceDefineManager.DeviceDefineCollection.FindDeviceDefine(this.DeviceType);
                    //this.Device = new Device(dd, "", this.Address);
                    this.Device = DeviceFactory.Create(dd, "", this.Address);
                    this.Device.Remark = this.txtRemark.Text;
                    AddDevice();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure("已经存在相同地址");
            }
        }

        /// <summary>
        /// 添加设备到数据库
        /// </summary>
        private void AddDevice()
        {
            GetCSDBI().AddDevice(this.Station.ID, this.Device);
            this.Station.Devices.Add(this.Device);
        }

        /// <summary>
        /// 
        /// </summary>
        private void EditDevice()
        {
            this.Device.Name = this.txtName.Text.Trim();
            this.Device.Address = (int)this.numDeviceAddress.Value;
            this.Device.Remark = this.txtRemark.Text.Trim();

            GetCSDBI().EditDevice(this.Device);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CSDBI GetCSDBI()
        {
            return YeHeCommuniServerApp.Default.CSDBI;
        }
    }
}
