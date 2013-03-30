    using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data ;
using Xdgk.Common ;

namespace SYQuery
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Xdgk.Common.ExceptionHandler.Handle(e.ExceptionObject as Exception);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Xdgk.Common.ExceptionHandler.Handle(e.Exception);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class DBI : DBIBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connstring"></param>
        private DBI(string connstring)
            : base (connstring )
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DBI GetDBI()
        {
            if (_dbi == null)
            {
                string conn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
                _dbi = new DBI(conn);
            }
            return _dbi;
        } private static DBI _dbi;

        /// <summary>
        /// 
        /// </summary>
        public DataTable Query( DateTime b, DateTime e )
        {
            string s = @"SELECT ditchdataid as 序号, dt as 时间, wl1/100 as '水位(m)', instantflux as '流量(m3/s)', usedAmount as '累计流量(m3)'
                        FROM tblditchdata where dt between '{0}' and '{1}'
                        order by dt";

            string sql = string.Format(s, b, e);
            return GetDBI().ExecuteDataTable(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal DataTable GetWLFluxMapDataTable()
        {
            string s = @"select wlfluxguanxiid as 序号, wl/100 as '水位(m)', flux as '流量(m3/s)' from tblwlfluxmap ";
            DataTable tbl = ExecuteDataTable(s);
            return tbl;
        }
    }
}
