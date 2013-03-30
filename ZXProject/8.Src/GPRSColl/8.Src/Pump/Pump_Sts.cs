using System;

namespace PumpDriver
{
    /// <summary>
    /// Pump_Sts 的摘要说明。
    /// </summary>
    public class Pump_Sts//:IPump_Sts
    {
        private int comAdr;
        private string status;

        #region Pump_Sts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_status"></param>
        public Pump_Sts(int _comAdr,string _status)
        {
            comAdr=_comAdr;
            status=_status;
        }
        #endregion //Pump_Sts

        #region ComAdr
        /// <summary>
        /// 
        /// </summary>
        public int ComAdr
        {
            get{return comAdr;}
        }
        #endregion //ComAdr

        #region Status
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            get{return status;}
        }
        #endregion //Status
    }
}
