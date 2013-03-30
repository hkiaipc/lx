using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;
using Xdgk.Communi;

namespace CommuniServer
{
    /// <summary>
    /// 
    /// </summary>
    public class XD202Device : Device
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public XD202Device(DeviceDefine dd, string name, int address)
            : base(dd, name, address)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        public XD202Data XD202Data
        {
            get
            {
                return this.Data as XD202Data;
            }
            set
            {
                this.Data = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LXRainDevice : Device
    {
        public LXRainDevice(DeviceDefine dd, long address)
            : base(dd, "", address)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastRainDateTime
        {
            get 
            { 
                //  TODO:
                //
                // 1. db last datetime
                // 
                // 2. 2012-7-1
                //
                // 3. max(1, 2)
                //
                if (_lastRainDateTime == DateTime.MinValue)
                {
                    DateTime safe = DateTime.Parse ("2012-07-01");
                    _lastRainDateTime = LXDBDBI.LXDB.GetLastRainDateTime(this.ID);
                    if (_lastRainDateTime < safe)
                    {
                        _lastRainDateTime = safe;
                    }
                }
                return _lastRainDateTime; 
            }
            set { _lastRainDateTime = value; }
        } private DateTime _lastRainDateTime = DateTime.MinValue;

        /// <summary>
        /// 
        /// </summary>
        public LXRainData LXRainData
        {
            get { return this.Data as LXRainData; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("LXRainData");
                }
                this.Data = value;

                this.LastRainDateTime = this.Data.DT;

                // save
                //
                LXDBDBI.LXDB.InsertRainData(
                    this.ID, value.DT, value.Rain);
            }
        }

    }

    public class LXRainData : Xdgk.Communi.IData
    {
        #region IData 成员

        public DateTime DT
        {
            get
            {
                return _dt;
            }
            set
            {
                _dt = value;
            }
        }private DateTime _dt;

        #endregion

        #region Rain
        /// <summary>
        /// 
        /// </summary>
        public int Rain
        {
            get
            {
                return _rain;
            }
            set
            {
                _rain = value;
            }
        } private int _rain;
        #endregion //Rain
    }
}
