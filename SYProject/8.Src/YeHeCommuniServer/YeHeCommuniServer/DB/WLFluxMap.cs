using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CommuniServer.DB
{
    /// <summary>
    /// 
    /// </summary>
    public class WLFluxMapDB
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public DataTable GetWLFluxMapDataTable()
        {
            string s = "select * from tblWLFluxMap order by wl";
            return CSDBI.CSDB .ExecuteDataTable(s);
            
        }

        /// <summary>
        /// 根据水位获取流量
        /// </summary>
        /// <param name="wl">水位(cm)</param>
        /// <returns>流量(m3/s)</returns>
        static public float FindFluxByWL(int wl)
        {
            float flux = 0f;
            string s = string.Format(
                "select * from tblWLFluxMap where wl <= {0} order by wl desc",
                wl);
            DataTable tbl = CSDBI.CSDB.ExecuteDataTable(s);
            if (tbl.Rows.Count > 0)
            {
                flux = Convert.ToSingle(tbl.Rows[0]["flux"]);
            }
            else
            {

            }
            return flux;
        }


        #region test

        /// <summary>
        /// 
        /// </summary>
        static private void TestWLFluxMap()
        {
            object obj = DB.WLFluxMapDB.FindFluxByWL(1200);
            Console.WriteLine("1200 -> " + obj);

            obj = DB.WLFluxMapDB.FindFluxByWL(2400);
            Console.WriteLine("2400 -> " + obj);

            obj = DB.WLFluxMapDB.FindFluxByWL(100);
            Console.WriteLine("100 -> " + obj);
        }
        #endregion //test

    }
}
