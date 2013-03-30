using System;
using System.Reflection;
using System.Text;

namespace GateDriver
{
    /// <summary>
    /// Pars_His 的摘要说明。
    /// </summary>
    public class Gate_His//:IGate_His
    {
        #region Members

        private int comAdr;
        private int noRec;
        private string dateTime;
        private int beforeLevel;
        private int behindLevel;
        private int height;
        private float flux;
        private long reWater;
        private long tuWater;
        private string power;
        private string lock_OC;
        #endregion //Members

        #region Gate_His
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_comAdr"></param>
        /// <param name="_noRec"></param>
        /// <param name="_dateTime"></param>
        /// <param name="_beforeLevel"></param>
        /// <param name="_behindLevel"></param>
        /// <param name="_height"></param>
        /// <param name="_flux"></param>
        /// <param name="_reWater"></param>
        /// <param name="_tuWater"></param>
        /// <param name="_power"></param>
        /// <param name="_lock_OC"></param>
        public Gate_His(int _comAdr, int _noRec, string _dateTime,
            int _beforeLevel, int _behindLevel, int _height, float _flux,
            long _reWater, long _tuWater, string _power,
            string _lock_OC)
        {
            comAdr = _comAdr;
            noRec = _noRec;
            dateTime = _dateTime;
            beforeLevel = _beforeLevel;
            behindLevel = _behindLevel;
            height = _height;
            flux = _flux;
            reWater = _reWater;
            tuWater = _tuWater;
            power = _power;
            lock_OC = _lock_OC;
        }
        #endregion //Gate_His


        #region ComAdr
        /// <summary>
        /// 
        /// </summary>
        public int ComAdr
        {
            get { return comAdr; }
        }
        #endregion //ComAdr

        #region NoRec
        /// <summary>
        /// 
        /// </summary>
        public int NoRec
        {
            get { return noRec; }
        }
        #endregion //NoRec

        #region DateTime
        /// <summary>
        /// 
        /// </summary>
        public string DateTime
        {
            get { return dateTime; }
        }
        #endregion //DateTime

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Type t = this.GetType();
            PropertyInfo[] pis = t.GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                sb.Append(string.Format("{0}: {1}\r\n", pi.Name, pi.GetValue(this, null)));
            }
            return sb.ToString();
        }

    }
}
