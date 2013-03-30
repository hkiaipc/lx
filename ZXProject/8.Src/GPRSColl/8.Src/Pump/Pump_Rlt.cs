using System;

namespace PumpDriver
{
    /// <summary>
    /// 
    /// </summary>
    public class PumpRealData //:IPump_Rlt
    {
        private int address;
        private int flux;
        private int efficiency;
        private long remainWater;
        private long totalWater;
        private string run;
        private string forceRun;
        private string vibrate;
        private string power;
        private int recordNO;

        private string runDateTime;
        private string stpDateTime;
        private long usWater;

        private byte[] _originalData;

        #region OriginalData
        /// <summary>
        /// 
        /// </summary>
        public byte[] OriginalData
        {
            get { return _originalData; }
            set { _originalData = value; }
        }
        #endregion //OriginalData

        #region PumpRealData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_flux"></param>
        /// <param name="_efficiency"></param>
        /// <param name="_reWater"></param>
        /// <param name="_tuWater"></param>
        /// <param name="_run"></param>
        /// <param name="_forceRun"></param>
        /// <param name="_vibrate"></param>
        /// <param name="_power"></param>
        /// <param name="_noRec"></param>
        /// <param name="_runDateTime"></param>
        /// <param name="_stpDateTime"></param>
        /// <param name="_usWater"></param>
        public PumpRealData(int _comAdr, int _flux, int _efficiency, long _reWater, long _tuWater,
            string _run, string _forceRun, string _vibrate, string _power, int _noRec, string _runDateTime,
            string _stpDateTime, long _usWater)
        {
            address = _comAdr;
            flux = _flux;
            efficiency = _efficiency;
            remainWater = _reWater;
            totalWater = _tuWater;
            run = _run;
            forceRun = _forceRun;
            vibrate = _vibrate;
            power = _power;
            recordNO = _noRec;
            runDateTime = _runDateTime;
            stpDateTime = _stpDateTime;
            usWater = _usWater;
        }
        #endregion //PumpRealData

        #region ComAdr
        /// <summary>
        /// 
        /// </summary>
        public int ComAdr
        {
            get { return address; }
        }
        #endregion //ComAdr

        #region Flux
        /// <summary>
        /// 
        /// </summary>
        public int Flux
        {
            get { return flux; }
        }
        #endregion //Flux

        #region Efficiency
        /// <summary>
        /// 
        /// </summary>
        public int Efficiency
        {
            get { return efficiency; }
        }
        #endregion //Efficiency

        #region RemainWater
        /// <summary>
        /// 
        /// </summary>
        public long RemainWater
        {
            get { return remainWater; }
        }
        #endregion //RemainWater

        #region TotalWater
        /// <summary>
        /// 
        /// </summary>
        public long TotalWater
        {
            get { return totalWater; }
        }
        #endregion //TotalWater

        #region Run
        /// <summary>
        /// 
        /// </summary>
        public string Run
        {
            get { return run; }
        }
        #endregion //Run

        #region ForceRun
        /// <summary>
        /// 
        /// </summary>
        public string ForceRun
        {
            get { return forceRun; }
        }
        #endregion //ForceRun

        #region Vibrate
        /// <summary>
        /// 
        /// </summary>
        public string Vibrate
        {
            get { return vibrate; }
        }
        #endregion //Vibrate

        #region Power
        /// <summary>
        /// 
        /// </summary>
        public string Power
        {
            get { return power; }
        }
        #endregion //Power

        #region RecordNO
        /// <summary>
        /// ¼ÇÂ¼ºÅ
        /// </summary>
        public int RecordNO
        {
            get { return recordNO; }
        }
        #endregion //RecordNO

        #region RunDateTime
        /// <summary>
        /// 
        /// </summary>
        public string RunDateTime
        {
            get { return runDateTime; }
        }
        #endregion //RunDateTime

        #region StpDateTime
        /// <summary>
        /// 
        /// </summary>
        public string StpDateTime
        {
            get { return stpDateTime; }
        }
        #endregion //StpDateTime

        #region UsWater
        /// <summary>
        /// 
        /// </summary>
        public long UsWater
        {
            get { return usWater; }
        }
        #endregion //UsWater
    }
}
