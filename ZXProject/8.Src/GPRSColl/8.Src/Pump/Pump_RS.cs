using System;
using System.Diagnostics;

namespace PumpDriver
{
	/// <summary>
	/// Pars_RS 的摘要说明。
	/// </summary>
	public class Pump_RS//:IPump_RS
	{
		private int comAdr;
		private string sign;
//		private string dateTime;
        private DateTime datetime;
		private long tuWater;
		private long reWater;

		#region Pump_RS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_sign"></param>
        /// <param name="_dateTime"></param>
        /// <param name="_tuWater"></param>
        /// <param name="_reWater"></param>
		public Pump_RS(int _comAdr,string _sign,string _dateTime,long _tuWater,long _reWater)
		{
			comAdr=_comAdr;
			sign=_sign;
//            DateTime
//            datetime=Convert.ToDateTime(  );
            try
            {
                datetime = DateTime.Parse(_dateTime);
            }
            catch(Exception ex )
            {
                Debug.Fail( string.Format( "{0}\r\n{1}", _dateTime, ex.ToString() ));
            }
			tuWater=_tuWater;
			reWater=_reWater;
		}
		#endregion //Pump_RS

		#region ComAdr
        /// <summary>
        /// 
        /// </summary>
		public int ComAdr
		{
			get{return comAdr;}
		}
		#endregion //ComAdr

		#region Sign
        /// <summary>
        /// 
        /// </summary>
		public string Sign
		{
			get{return sign;}
		}
		#endregion //Sign

		#region DT
        /// <summary>
        /// 
        /// </summary>
		public DateTime DT
		{
			get{return this.datetime;}
		}
		#endregion //DT

		#region TuWater
        /// <summary>
        /// 
        /// </summary>
		public long TuWater
		{
			get{return tuWater;}
		}	
		#endregion //TuWater

		#region ReWater
        /// <summary>
        /// 
        /// </summary>
		public long ReWater
		{
			get{return reWater;}
		}
		#endregion //ReWater

	}
}
