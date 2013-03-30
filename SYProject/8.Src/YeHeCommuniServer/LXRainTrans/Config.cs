using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace LXRainTrans
{
    public class Config
    {
        #region ConnectionString
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        } 
        #endregion //ConnectionString

        #region RemoteIP
        /// <summary>
        /// 
        /// </summary>
        public System.Net.IPAddress RemoteIP
        {
            get
            {
                return System.Net.IPAddress.Parse(ConfigurationManager.AppSettings["RemoteIP"]);
            }
        } 
        #endregion //RemoteIP

        #region RemotePort
        /// <summary>
        /// 
        /// </summary>
        public ushort RemotePort
        {
            get
            {
                return Convert.ToUInt16(ConfigurationManager.AppSettings["RemotePort"]);
            }
        } 
        #endregion //RemotePort


        /// <summary>
        /// 
        /// </summary>
        public int CheckConnectInterval
        {
            // 30s
            //
            get
            {
                int n = Convert.ToInt32(ConfigurationManager.AppSettings["ConnectionInterval"]) * 1000;
                if (n < 5)
                {
                    n = 5;
                }
                return n;
            }
        }
    }
}
