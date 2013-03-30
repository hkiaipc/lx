using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace LXRainTrans
{
    public class DB : DBIBase 
    {
        public DB(string s)
            : base(s)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastDateTime"></param>
        /// <returns></returns>
        public DataTable GetRainDataTable( DateTime lastDateTime )
        {
            DateTime min =  DateTime.Parse("2012-07-01");
            if (lastDateTime < min)
            {
                lastDateTime = min;
            }

            string s = string.Format(
                "select top 5 * from tbl_RainData where RD_Date > '{0}' order by RD_Date",
                lastDateTime);
            DataTable tbl =  ExecuteDataTable (s);
            return tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        public void TestDBConnection()
        {
            DateTime dt = DateTime.Now;
            DataTable tbl = GetRainDataTable(dt);
        }
    }
}
