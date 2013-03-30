using System;

namespace PumpDriver
{
    /// <summary>
    /// 
    /// </summary>
    public class PumpHistoryData
	{
		private int address;
		private int recordNO;
		private string runDateTime;
		private string stpDateTime;
		private long usWater;

        #region PumpHistoryData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_noRec"></param>
        /// <param name="_runDateTime"></param>
        /// <param name="_stpDateTime"></param>
        /// <param name="_usWater"></param>
        public PumpHistoryData(int _comAdr, int _noRec, string _runDateTime, string _stpDateTime, long _usWater)
        {
            address = _comAdr;
			recordNO=_noRec;
			runDateTime=_runDateTime;
			stpDateTime=_stpDateTime;
			usWater=_usWater;
		}
        #endregion //PumpHistoryData

		#region ComAdr
        /// <summary>
        /// 
        /// </summary>
		public int ComAdr
		{
			get{return address;}
		}
		#endregion //ComAdr

		#region NoRec
        /// <summary>
        /// 
        /// </summary>
		public int NoRec
		{
			get{return recordNO;}
		}
		#endregion //NoRec

		#region StpDateTime
		#region RunDateTime
        /// <summary>
        /// 
        /// </summary>
		public string RunDateTime
		{
			get{return runDateTime;}
		}
		#endregion //RunDateTime
        ///
        /// <summary>
        /// 
        /// </summary>
		public string StpDateTime
		{
			get{return stpDateTime;}
		}
		#endregion //StpDateTime

		#region UsWater
        /// <summary>
        /// 
        /// </summary>
		public long UsWater
		{
			get{return usWater;}
		}	
		#endregion //UsWater
	}
}
