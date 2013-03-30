using System;
using System.Data ;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class DB2 : DBIBase 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public DB2 GetDBI()
        {
            if (_db2 == null)
            {
                string conn = Config.Default.DB2ConnectString;
                _db2 = new DB2(conn);
            }
            return _db2;
        } static private DB2 _db2;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public DB2(string conn)
            : base(conn)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetGateDataLastDataTable()
        {
            string s = "select * from vGateDataLast";
            return ExecuteDataTable(s);
        }

        public DataTable GetDitchDataLastDataTable()
        {
            string s = "select * from vDitchDataLast";
            return ExecuteDataTable(s);
        }
    }
}
