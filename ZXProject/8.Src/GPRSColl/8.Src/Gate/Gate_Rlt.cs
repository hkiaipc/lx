using System;
using System.Data;
using System.Windows.Forms;

namespace GateDriver
{
    /// <summary>
    /// 
    /// </summary>
    public class Gate_Rlt//:IGate_Rlt
    {
        private int comAdr;
        private int height;
        private int beforeLevel;
        private int behindLevel;
        private float flux;
        private long reWater;
        private long tuWater;
        private string power;
        private string lock_OC;
        private DateTime dt;

        #region Gate_Rlt
        public Gate_Rlt()
        { 
        }
        #endregion //Gate_Rlt

        #region Gate_Rlt
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_beforeLevel"></param>
        /// <param name="_behindLevel"></param>
        /// <param name="_height"></param>
        /// <param name="_flux"></param>
        /// <param name="_reWater"></param>
        /// <param name="_tuWater"></param>
        /// <param name="_power"></param>
        /// <param name="_lock_OC"></param>
        public Gate_Rlt(int _comAdr, int _beforeLevel, int _behindLevel, int _height, float _flux, long _reWater, long _tuWater, string _power, string _lock_OC)
        {

            comAdr = _comAdr;
            beforeLevel = _beforeLevel;
            behindLevel = _behindLevel;
            height = _height;
            flux = _flux;
            reWater = _reWater;
            tuWater = _tuWater;
            power = _power;
            lock_OC = _lock_OC;
        }
        #endregion //Gate_Rlt

        #region Gate_Rlt
        public Gate_Rlt(DateTime _dt, int _comAdr, int _beforeLevel, int _behindLevel, int _height, float _flux, long _reWater, long _tuWater, string _power, string _lock_OC)
        {
            dt = _dt;
            comAdr = _comAdr;
            beforeLevel = _beforeLevel;
            behindLevel = _behindLevel;
            height = _height;
            flux = _flux;
            reWater = _reWater;
            tuWater = _tuWater;
            power = _power;
            lock_OC = _lock_OC;
        }
        #endregion //Gate_Rlt

        //		public Gate_Rlt(DateTime _dt):this(comAdr,beforeLevel,behindLevel,height,flux,reWater,tuWater,power,lock_OC)
        //		{
        //			dt = _dt;
        //		}

        #region Gate_Rlt
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        static public Gate_Rlt Parse(DataRow r)
        {
            if (r == null)
                return null;
            try
            {
                Gate_Rlt gr = new Gate_Rlt();
                gr.dt = Convert.ToDateTime(r["DT"]);
                gr.beforeLevel = Convert.ToInt32(r["BeforeLevel"]);
                gr.behindLevel = Convert.ToInt32(r["BehindLevel"]);
                //	gr.comAdr = Convert.ToInt32(r["adress"]);
                gr.height = Convert.ToInt32(r["Height"]);
                gr.flux = Convert.ToInt32(r["Flux"]);
                gr.reWater = Convert.ToInt32(r["RemainWater"]);
                gr.tuWater = Convert.ToInt32(r["TotalWater"]);

                return gr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        #endregion //Gate_Rlt

        #region DT
        public DateTime DT
        {
            get { return dt; }
        }
        #endregion //DT

        #region ComAdr
        /// <summary>
        /// 
        /// </summary>
        public int ComAdr
        {
            get { return comAdr; }
        }
        #endregion //ComAdr

        #region BeforeLevel
        /// <summary>
        /// 
        /// </summary>
        public int BeforeLevel
        {
            get { return beforeLevel; }
        }
        #endregion //BeforeLevel

        #region BehindLevel
        /// <summary>
        /// 
        /// </summary>
        public int BehindLevel
        {
            get { return behindLevel; }
        }
        #endregion //BehindLevel

        #region Height
        /// <summary>
        /// 
        /// </summary>
        public int Height
        {
            get { return height; }
        }
        #endregion //Height

        #region Flux
        /// <summary>
        /// 
        /// </summary>
        public float Flux
        {
            get { return flux; }
        }
        #endregion //Flux

        #region ReWater
        /// <summary>
        /// 
        /// </summary>
        public long ReWater
        {
            get { return reWater; }
        }
        #endregion //ReWater

        #region TuWater
        /// <summary>
        /// 
        /// </summary>
        public long TuWater
        {
            get { return tuWater; }
        }
        #endregion //TuWater

        #region Power
        /// <summary>
        /// 
        /// </summary>
        public string Power
        {
            get { return power; }
        }
        #endregion //Power

        #region Lock_OC
        /// <summary>
        /// 
        /// </summary>
        public string Lock_OC
        {
            get { return lock_OC; }
        }
        #endregion //Lock_OC

    }
}
