using System;

namespace GateDriver
{
	/// <summary>
	/// Pars_Inp 的摘要说明。
	/// </summary>
	public class Gate_Inp//:IGate_Inp
	{
		private int comAdr;
		private int toRec;
		private int noRec;
		private string dateTime;
		private long inWater;

		#region Gate_Inp
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_toRec"></param>
        /// <param name="_noRec"></param>
        /// <param name="_dateTime"></param>
        /// <param name="_inWater"></param>
		public Gate_Inp(int _comAdr,int _toRec,int _noRec,string _dateTime,long _inWater)
		{
			comAdr=_comAdr;
			toRec=_toRec;
			noRec=_noRec;
			dateTime=_dateTime;
			inWater=_inWater;
		}
		#endregion //Gate_Inp

		#region ComAdr
        /// <summary>
        /// 
        /// </summary>
		public int ComAdr
		{
			get{return comAdr;}
		}	
		#endregion //ComAdr

		#region ToRec
        /// <summary>
        /// 
        /// </summary>
		public int ToRec
		{
			get{return toRec;}
		}
		#endregion //ToRec

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

	}
}
