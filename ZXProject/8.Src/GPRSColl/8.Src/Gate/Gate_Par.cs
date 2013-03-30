using System;

namespace GateDriver
{
    /// <summary>
    /// 
    /// </summary>
	public class Gate_Par//:IGate_Par
	{
		private int comAdr;
		private int width;
		private int bottomHeight;
		private float freeFlux;
		private float undrFlux;
		private int beforeLevel;
		private int behindLevel;
		private int beforeCorrect;
		private int behindCorrect;
	
		#region Gate_Par	
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_width"></param>
        /// <param name="_bottomHeight"></param>
        /// <param name="_freeFlux"></param>
        /// <param name="_undrFlux"></param>
        /// <param name="_beforeLevel"></param>
        /// <param name="_behindLevel"></param>
        /// <param name="_beforeCorrect"></param>
        /// <param name="_behindCorrect"></param>
		public Gate_Par(int _comAdr,int _width,int _bottomHeight,float _freeFlux,float _undrFlux,int _beforeLevel,int _behindLevel,int _beforeCorrect,int _behindCorrect)
		{
			comAdr=_comAdr;
			width=_width;
            bottomHeight=_bottomHeight;
            freeFlux=_freeFlux;
            undrFlux=_undrFlux;
			beforeLevel=_beforeLevel;
			behindLevel=_behindLevel;
			beforeCorrect=_beforeCorrect;
			behindCorrect=_behindCorrect;
		}
		#endregion //Gate_Par
       
		#region ComAdr 
        /// <summary>
        /// 
        /// </summary>
		public int ComAdr
		{
			get{return comAdr;}
		}
		#endregion //ComAdr

		#region Width
        /// <summary>
        /// 
        /// </summary>
		public int Width
		{
			get{return width;}
		}
		#endregion //Width

		#region BottomHeight
        /// <summary>
        /// 
        /// </summary>
		public int BottomHeight
		{
			get{return bottomHeight;}
		}
		#endregion //BottomHeight

		#region FreeFlux
        /// <summary>
        /// 
        /// </summary>
		public float FreeFlux
		{
			get{return freeFlux;}
		}
		#endregion //FreeFlux

		#region UndrFlux
        /// <summary>
        /// 
        /// </summary>
		public float UndrFlux
		{
			get{return undrFlux;}
		}
		#endregion //UndrFlux

		#region BeforeLevel
        /// <summary>
        /// 
        /// </summary>
		public int BeforeLevel
		{
			get{return beforeLevel;}
		}
		#endregion //BeforeLevel

		#region BehindLevel
        /// <summary>
        /// 
        /// </summary>
		public int BehindLevel
		{
			get{return behindLevel;}
		}
		#endregion //BehindLevel

		#region BeforeCorrect
        /// <summary>
        /// 
        /// </summary>
		public int BeforeCorrect
		{
			get{return beforeCorrect;}
		}
		#endregion //BeforeCorrect

		#region BehindCorrect
        /// <summary>
        /// 
        /// </summary>
		public int BehindCorrect
		{
			get{return behindCorrect;}
		}
		#endregion //BehindCorrect

	}
}
