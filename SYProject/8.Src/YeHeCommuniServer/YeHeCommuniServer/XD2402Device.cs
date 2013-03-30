using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Communi;
using Xdgk.Common;

namespace CommuniServer
{
    /// <summary>
    /// 
    /// </summary>
    public class XD2402Device : Device
    {
        #region XD2402Device
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public XD2402Device(DeviceDefine dd, string name, long address) :
            base(dd, name, address)
        {

        }
        #endregion //XD2402Device



        #region IsLastRecordIndexValid
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsLastRecordIndexValid()
        {
            if (_lastRecordIndex == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion //IsLastRecordIndexValid
            
        #region LastRecordIndex
        /// <summary>
        /// 
        /// </summary>
        public int LastRecordIndex
        {
            get
            {
                return _lastRecordIndex;
            }
            set
            {
                _lastRecordIndex = value;
            }
        } private int _lastRecordIndex = -1;
        #endregion //LastRecordIndex


        #region XD2402Data
        /// <summary>
        /// 
        /// </summary>
        public XD2402Data XD2402Data
        {
            get 
            { 
                return this.Data as XD2402Data; 
            }
            set
            {
                this.Data = value;
            }
        }
        #endregion //XD2402Data
    }


    /// <summary>
    /// 
    /// </summary>
    public class XD2402Data : Xdgk.Communi.IData
    {

        #region XD2402Data
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="wlBefore"></param>
        /// <param name="wlBehind"></param>
        /// <param name="height"></param>
        /// <param name="instantFlux"></param>
        /// <param name="usedAmount"></param>
        /// <param name="remainAmount"></param>
        public XD2402Data(DateTime dt, int wlBefore, int wlBehind, int height,
            int instantFlux, int usedAmount, int remainAmount)
        {
            this.DT = dt;
            this.BeforeWaterLevel = wlBefore;
            this.BehindWaterLevel = wlBehind;
            this.Height = height;
            this.InstantFlux = instantFlux;
            this.UsedAmount = usedAmount;
            this.RemainAmount = remainAmount;
        }
        #endregion //

        #region IData 成员
        /// <summary>
        /// 
        /// </summary>
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
        } private DateTime _dt;

        #endregion

        #region InstantFlux
        /// <summary>
        /// 获取或设置瞬时流量(m3 / h)
        /// </summary>
        public int InstantFlux
        {
            get { return _instantFlux; }
            set { _instantFlux = value; }
        } private int _instantFlux;
        #endregion //InstantFlux

        #region UsedAmount
        /// <summary>
        /// 
        /// </summary>
        public int UsedAmount
        {
            get { return _usedAmount; }
            set { _usedAmount = value; }
        } private int _usedAmount;
        #endregion //

        #region RemainAmount
        /// <summary>
        /// 获取或设置剩余水量(m3)
        /// </summary>
        public int RemainAmount
        {
            get { return _remainAmount; }
            set { _remainAmount = value; }
        } private int _remainAmount;
        #endregion //RemainAmount

        #region Height
        /// <summary>
        /// 获取或设置闸门高度(cm)
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        } private int _height;
        #endregion //Height

        #region BeforeWaterLevel
        /// <summary>
        /// 获取或设置闸前水位(cm)
        /// </summary>
        public int BeforeWaterLevel
        {
            get { return _beforeWaterLevel; }
            set { _beforeWaterLevel = value; }
        } private int _beforeWaterLevel;
        #endregion //BeforeWaterLevel

        #region BehindWaterLevel
        /// <summary>
        /// 获取或设置闸后水位(cm)
        /// </summary>
        public int BehindWaterLevel
        {
            get { return _behindWaterLevel; }
            set { _behindWaterLevel = value; }
        } private int _behindWaterLevel;
        #endregion //BehindWaterLevel

    }
}
