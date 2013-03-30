using System;
using System.Collections;
using System.Drawing;
using System.Net;
using System.Configuration;

namespace GprsSystem
{
	/// <summary>
	/// Global 的摘要说明。
	/// </summary>
	public class DeviceInfoManager
	{

		#region DeviceInfoManager
        /// <summary>
        /// 
        /// </summary>
        public DeviceInfoManager()
        {
        }
		#endregion //

        #region Members
        /// <summary>
        /// 
        /// </summary>
        static public ArrayList DeviceInfoList = new ArrayList( 100 );
        #endregion //Members

        #region GetDeviceinfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address">名称</param>
        /// <returns></returns>
        static public DeviceInfo GetDeviceInfo( string address, string sign )
        {
            foreach ( object obj in DeviceInfoList  )
            {
                DeviceInfo info = (DeviceInfo) obj;
                if ( string.Compare( info.Address, address, true ) == 0 &&
                    string.Compare( info.DeviceKind, sign, true) == 0 )
                {
                    return info;
                }
            }
            return null;
        }
        #endregion //GetDeviceinfo
       
        #region GetDeviceInfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commAddress"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        static public DeviceInfo GetDeviceInfo( int commAddress, string sign )
        {
            foreach ( object obj in DeviceInfoList )
            {
                DeviceInfo info = (DeviceInfo) obj;
                if ( string.Compare( info.DeviceKind , sign, true ) == 0 &&
                    info.DeviceAddress == commAddress )
                    return info;
            }

            return null;
        }
        #endregion //GetDeviceInfo

        #region GetDeviceInfoArray
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        static public DeviceInfo[] GetDeviceInfo( IPAddress ip )
        {
            ArrayList list = new ArrayList();

            foreach ( object obj in DeviceInfoList )
            {
                DeviceInfo info = (DeviceInfo) obj;
                if ( ip.Equals( info.IP ) )
                {
                    //if ( info.Socket != null )
                    list.Add( info );
                }
            }
            if ( list.Count > 0 )
            {
                DeviceInfo[] result = (DeviceInfo[]) list.ToArray( typeof( DeviceInfo ) );
                return result;
            }
            return null;
        }
        #endregion //GetDeviceInfoArray

        #region GetCsInfoByID
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="cs_info_id"></param>
        ///// <returns></returns>
        //static public DeviceInfo GetDeviceInfoByID( int cs_info_id )
        //{
        //    foreach ( object obj in DeviceInfoList )
        //    {
        //        DeviceInfo info = obj as DeviceInfo ;
        //        if( info.ID == cs_info_id )
        //            return info;
        //    }
        //    return null;
        //}
        #endregion //GetCsInfoByID

        #region Texts
        public const string TEXT_GATE                   = "Gate";
        public const string TEXT_PUMP                   = "Pump";
        public const string TEXT_TIP                    = "提示";
        public const string TEXT_ERROR                  = "错误";
        public const string TEXT_APPNAME                = "GPRS 采集系统";
        public const string TEXT_RUNSTATE_NONE          = "无运行状态";
        public const string TEXT_RUNSTATE_NORMAL        = "正常运行状态";
        public const string TEXT_RUNSTATE_VIBRATE       = "振动运行状态";
        #endregion //Texts
	}
}
