using System;

namespace PumpDriver
{
    /// <summary>
    /// Pars_Inp 的摘要说明。
    /// </summary>
    public class Pump_Inp//:IPump_Inp
    {
        private int comAdr;
        private int noRec;
        private string dateTime;
        private long inWater;
        private long reWater;
        private long in_reWater;

        #region Pump_Inp
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_noRec"></param>
        /// <param name="_dateTime"></param>
        /// <param name="_inWater"></param>
        /// <param name="_reWater"></param>
        /// <param name="_in_reWater"></param>
        public Pump_Inp(int _comAdr,int _noRec,string _dateTime,long _inWater,long _reWater,long _in_reWater)
        {
            comAdr=_comAdr;
            noRec=_noRec;
            dateTime=_dateTime;
            inWater=_inWater;
            reWater=_reWater;
            in_reWater=_in_reWater;
        }
        #endregion //Pump_Inp

        #region ComAdr
        /// <summary>
        /// 
        /// </summary>
        public int ComAdr
        {
            get{return comAdr;}
        }
        #endregion //ComAdr

        #region NoRec
        /// <summary>
        /// 
        /// </summary>
        public int NoRec
        {
            get{return noRec;}
        }
        #endregion //NoRec

        #region DateTime
        /// <summary>
        /// 
        /// </summary>
        public string DateTime
        {
            get{return dateTime;}
        }
        #endregion //DateTime

        #region InWater
        /// <summary>
        /// 
        /// </summary>
        public long InWater
        {
            get{return inWater;}
        }	
        #endregion //InWater

        #region ReWater
        /// <summary>
        /// 
        /// </summary>
        public long ReWater
        {
            get{return reWater;}
        }
        #endregion //ReWater

        #region In_ReWater
        /// <summary>
        /// 
        /// </summary>
        public long In_ReWater
        {
            get{return in_reWater;}
        }
        #endregion //In_ReWater

    }
}
