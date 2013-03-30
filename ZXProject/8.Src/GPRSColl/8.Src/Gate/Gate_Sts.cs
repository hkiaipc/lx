using System;

namespace GateDriver
{
	/// <summary>
	/// Pars_Str 的摘要说明。
	/// </summary>
	public class Gate_Sts
	{
        // 2007.06.07 Added function code
        //
        private int _fc = -1;
		private int comAdr;
		private string status;

		#region Status
		#region ComAdr
		#region Gate_Sts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_status"></param>
		public Gate_Sts(int _comAdr,string _status)
		{
			comAdr=_comAdr;
			status=_status;
		}
		#endregion //Gate_Sts
        /// <summary>
        /// 
        /// </summary>
		public int ComAdr
		{
			get{return comAdr;}
		}
		#endregion //ComAdr
        /// <summary>
        /// 
        /// </summary>
		public string Status
		{
			get{return status;}
		}
		#endregion //Status

        #region FunctionCode
        /// <summary>
        /// 
        /// </summary>
        public int FunctionCode 
        {
            get { return _fc; }
        }
        #endregion //FunctionCode
	}
}
