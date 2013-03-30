using System;
using System.Diagnostics;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Group
    {
        #region DeviceInfoCollection
        /// <summary>
        /// 
        /// </summary>
        public DeviceInfoCollection DeviceInfoCollection
        {
            get
            {
                if (_deviceInfoCollection == null)
                {
                    _deviceInfoCollection = new DeviceInfoCollection();
                }
                return _deviceInfoCollection;
            }
            set
            {
                _deviceInfoCollection = value;
            }
        } private DeviceInfoCollection _deviceInfoCollection;
        #endregion //DeviceInfoCollection

        #region Socket
        /// <summary>
        /// 
        /// </summary>
        public Socket Socket
        {
            get
            {
                return _socket;
            }
            set
            {
                if (_socket != value)
                {
                    _socket = value;
                }
            }
        } private Socket _socket;
        #endregion //Socket

        #region IP
        /// <summary>
        /// 
        /// </summary>
        public IPAddress IP
        {
            get
            {
                return _iP;
            }
            set
            {
                _iP = value;
            }
        } private IPAddress _iP;
        #endregion //IP

        #region LastDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastDateTime
        {
            get
            {
                return _lastDateTime;
            }
            //set
            //{
            //    _lastDateTime = value;
            //}
        } private DateTime _lastDateTime;
        #endregion //LastDateTime

        #region LastDeviceInfo
        /// <summary>
        /// 
        /// </summary>
        public DeviceInfo LastDeviceInfo
        {
            get
            {
                return _lastDeviceInfo;
            }
            //set
            //{
            //    _lastDeviceInfo = value;
            //}
        } private DeviceInfo _lastDeviceInfo;
        #endregion //LastDeviceInfo


        /// <summary>
        /// 
        /// </summary>
        /// <param name="di"></param>
        public void MarkLastDeviceInfo(DeviceInfo di)
        {
            Debug.Assert(di.IP.Equals(this.IP), "mark deviceInfo.ip != group.ip");

            _lastDeviceInfo = di;
            _lastDateTime = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsUsed()
        {
            // 10 second
            //
            TimeSpan USED_TIMESPAN = TimeSpan.FromSeconds(10d);

            TimeSpan ts = DateTime.Now - LastDateTime;
            if (ts <= USED_TIMESPAN)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
