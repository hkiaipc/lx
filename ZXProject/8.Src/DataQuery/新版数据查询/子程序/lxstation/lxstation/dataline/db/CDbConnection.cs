using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace lxstation
{
    /// <summary>
    /// CDbConnection 的摘要说明。
    /// </summary>
    public class CDbConnection
    {
        /// <summary>
        /// 
        /// </summary>
        static CDbConnection()
        {
            ReadConfig();
        }

        #region ReadConfig
        public static string strconn;
        /// <summary>
        /// Read System's App.config
        /// </summary>
        public static void ReadConfig()
        {
            System.Collections.Specialized.NameValueCollection nvc = System.Configuration.ConfigurationSettings.AppSettings;
            string stringcon = nvc["ConnString"];
            //string department = nvc["Department"];
            //string place = nvc["Place"];

            strconn = stringcon;
            //this._department = department;
            //this._place = place;
        }
        #endregion

        public CDbConnection()
        {
        }
        //strSql like "select count(*) from table" or "select max(id) from table"
        public static string execScalar(string strSql)
        {
            try
            {
                //string sqlcon =  "Data Source=192.168.0.1;initial catalog=LXDB;user id=sa;password=";
                string sqlcon = // "Data Source=a;initial catalog=LXDB;user id=sa;password=sa";
                     strconn;                   
                SqlConnection sCon = new SqlConnection(sqlcon);
                sCon.Open();

                SqlCommand sCmd = new SqlCommand();
                sCmd.Connection = sCon;
                sCmd.CommandText = strSql;
                object str = sCmd.ExecuteScalar();

                if (str == null)
                {
                    sCon.Close();
                    return "";
                }
                else
                {
                    sCon.Close();
                    return str.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "";

            }
        }


        //select
        public static DataTable getDt(string strSql)
        {
            try
            {
                string sqlcon =   //"Data Source=192.168.0.1;initial catalog=LXDB;user id=sa;password=";
                    strconn;
                SqlConnection sCon = new SqlConnection(sqlcon);
                sCon.Open();

                SqlCommand sCmd = new SqlCommand();
                sCmd.Connection = sCon;
                sCmd.CommandText = strSql;

                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = sCmd;

                DataTable dt = new DataTable();
                sda.Fill(dt);
                //sCmd.ExecuteNonQuery();
                sCon.Close();

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        //edit

        public static void execCmd(string strSql)
        {
            try
            {
                string sqlcon =   //"Data Source=192.168.0.1;initial catalog=LXDB;user id=sa;password=";
                    strconn;
                SqlConnection sCon = new SqlConnection(sqlcon);
                sCon.Open();

                SqlCommand sCmd = new SqlCommand();
                sCmd.Connection = sCon;
                sCmd.CommandText = strSql;
                sCmd.ExecuteNonQuery();

                sCon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }
    }
}

