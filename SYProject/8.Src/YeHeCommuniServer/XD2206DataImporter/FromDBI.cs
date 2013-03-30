using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace XD2206DataImporter
{
    public class FromDBI : Xdgk.Common.DBIBase
    {
        public FromDBI(string connstring)
            : base(connstring)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param deviceType="deviceType"></param>
        /// <returns></returns>
        public int ReadFromDeviceID(string name)
        {
            string sql = string.Format(
                "SELECT DeviceID FROM tbl_XD2206_Device WHERE (DeviceName = '{0}') AND (Deleted = 0)",
                name);

            object obj = ExecuteScalar(sql);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                throw new ArgumentException(
                    string.Format("cannot find deviceType '{0}'", name)
                    );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param deviceType="fromDateTime"></param>
        /// <returns></returns>
        public DataTable ReadNewDataTable( int deviceID, DateTime fromDateTime)
        {
            string s = string.Format(
                "SELECT * FROM tbl_XD2206_Record where deviceid = {0} and dt > '{1}'",
                deviceID,
                fromDateTime);
            return ExecuteDataTable(s);
        }
    }
}
