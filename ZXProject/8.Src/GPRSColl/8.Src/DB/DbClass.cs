using System;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using GateDriver;
using PumpDriver;

namespace GprsSystem
{
    /// <summary>
    /// ���ݿ��д�Լ���ز���
    /// </summary>
    public class DbClass
    {
        /// <summary>
        /// ���幫��SQL���ݿ����ӱ���
        /// </summary>
        private SqlConnection myConnection;


        #region DataBaseConnect
        /// <summary>
        /// ����һ��Sql���ӣ����浽myConnection�У��Թ���д���ݿ�ʹ�á�
        /// </summary>
        /// <remarks>
        /// ���ݿ����ӹ���
        /// </remarks>
        private void DataBaseConnect()
        {
            myConnection = new SqlConnection(Config.Default.ConnString);

        }
        #endregion //DataBaseConnect

        #region GetServerIP
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetServerIP()
        {
            return Config.Default.ServerIP;
        }
        #endregion //GetServerIP


        #region IsCenterIP
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverIP"></param>
        /// <returns></returns>
        private bool IsCenterIP(string serverIP)
        {
            string s = string.Format("select id_Department from tb_department where ip = '{0}'",
                serverIP);

            DataBaseConnect();
            SqlConnection con = myConnection;
            con.Open();
            SqlCommand cmd = new SqlCommand(s, con);
            object result = cmd.ExecuteScalar();


            cmd.Dispose();
            con.Close();
            if (result == null)
                return false;

            if (string.Compare(result.ToString(), "ZX", true) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion //IsCenterIP


        #region MakeGateSql
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverIP"></param>
        /// <returns></returns>
        private string MakeGateSql(string serverIP)
        {
            string s = string.Empty;
            if (IsCenterIP(serverIP))
            {
                s = "select * from v_Gate order by id_pole";
                return s;
            }
            else
            {
                s = string.Format("select * from v_gate where IP = '{0}' order by id_pole", serverIP);
            }

            return s;

        }
        #endregion //MakeGateSql


        #region MakePumpSql
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverIP"></param>
        /// <returns></returns>
        private string MakePumpSql(string serverIP)
        {
            string s = string.Empty;
            if (IsCenterIP(serverIP))
            {
                s = "SELECT * FROM v_Pump ORDER BY Id_Pole";
                return s;
            }
            else
            {
                s = string.Format(
                    "SELECT * FROM v_Pump where DepartmentIP = '{0}' ORDER BY Id_Pole",
                    serverIP);
            }

            return s;

        }
        #endregion //MakePumpSql


        #region GetDeviceType
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetDeviceType(SqlDataReader dr)
        {
            object obj = dr["DeviceType"];
            return obj.ToString().Trim();
        }
        #endregion //GetDeviceType

        #region GetInfoAll
        /// <summary>
        /// create deviceInfo class from db, and save to Global.CSinfoList
        /// </summary>
        public void GetInfoAll()
        {
            this.DataBaseConnect();
            SqlConnection conn = myConnection;
            conn.Open();

            string serverIP = Config.Default.ServerIP;

            string sql = MakeGateSql(serverIP);

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DeviceInfo info = new DeviceInfo(
                    dr["Address"].ToString().Trim(),
                    int.Parse(dr["ComAdr"].ToString()),
                    dr["Sim"].ToString().Trim(),
                    DeviceInfoManager.TEXT_GATE,
                    1,
                    dr["GateIP"].ToString().Trim()
                    );

                info.DeviceType = GetDeviceType(dr);
                info.ID = int.Parse(dr["Id"].ToString());

                DeviceInfoManager.DeviceInfoList.Add(info);
            }
            dr.Close();


            sql = MakePumpSql(serverIP);
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DeviceInfo info = new DeviceInfo(
                    dr["Address"].ToString().Trim(),
                    int.Parse(dr["ComAdr"].ToString()),
                    dr["Sim"].ToString().Trim(),
                    DeviceInfoManager.TEXT_PUMP,
                    1,
                    dr["PumpIP"].ToString().Trim()
                    );

                info.DeviceType = GetDeviceType(dr);
                info.ID = int.Parse(dr["Id"].ToString());
                DeviceInfoManager.DeviceInfoList.Add(info);
            }
            dr.Close();
            cmd.Dispose();
            conn.Close();
        }
        #endregion //GetInfoAll


        #region Gate_His_Save
        /// <summary>
        /// �洢������ʷ����
        /// </summary>
        /// <param name="gate_his">������ʷ����,����ΪGate_His����</param>
        public void Gate_His_Save(ref object gate_his)
        {
            if (gate_his == null)
                throw new ArgumentNullException("gate_his");

            if (!(gate_his is Gate_His))
                throw new ArgumentException("argument isn't Gate_His type");

            DataBaseConnect();
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("TT_Gate_Save", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            Gate_His gatehis = (Gate_His)gate_his;

            myCommand.Parameters.AddWithValue("@ComAdr", gatehis.ComAdr);
            myCommand.Parameters.AddWithValue("@StrTime", gatehis.DateTime);
            myCommand.Parameters.AddWithValue("@BeforeLevel", gatehis.BeforeLevel);
            myCommand.Parameters.AddWithValue("@BehindLevel", gatehis.BehindLevel);
            myCommand.Parameters.AddWithValue("@Height", gatehis.Height);
            myCommand.Parameters.AddWithValue("@Flux", gatehis.Flux);
            myCommand.Parameters.AddWithValue("@ReWater", gatehis.ReWater);
            myCommand.Parameters.AddWithValue("@TuWater", gatehis.TuWater);
            myCommand.Parameters.AddWithValue("@Power", gatehis.Power);
            myCommand.Parameters.AddWithValue("@Lock", gatehis.Lock_OC);

            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        #endregion //Gate_His_Save


        #region SavePumpHistoryData
        /// <summary>
        /// �洢��վ��ʷ����
        /// </summary>
        /// <param name="pump_his">��վ��ʷ����, Pump_Rlt type</param>
        public void SavePumpHistoryData(ref object pump_his)
        {
            PumpRealData pumprlt = (PumpRealData)pump_his;

            DataBaseConnect();
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("TT_Pump_Save", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;



            myCommand.Parameters.AddWithValue("@ComAdr", pumprlt.ComAdr);
            myCommand.Parameters.AddWithValue("@Flux", pumprlt.Flux);
            myCommand.Parameters.AddWithValue("@Efficiency", pumprlt.Efficiency);
            myCommand.Parameters.AddWithValue("@ReWater", pumprlt.RemainWater);
            myCommand.Parameters.AddWithValue("@TuWater", pumprlt.TotalWater);
            myCommand.Parameters.AddWithValue("@Run", pumprlt.Run);
            myCommand.Parameters.AddWithValue("@ForceRun", pumprlt.ForceRun);
            myCommand.Parameters.AddWithValue("@Vibrate", pumprlt.Vibrate);
            myCommand.Parameters.AddWithValue("@Power", pumprlt.Power);

            //TODO : 2007-06-25 Added Rundatetime and StpDateTime can't is null
            //
            // 2011-05-06 run datetime and stp datetime invalid
            //
            //myCommand.Parameters.Add( "@RunTime",   pumprlt.RunDateTime );
            //myCommand.Parameters.Add( "@StpTime",   pumprlt.StpDateTime );
            myCommand.Parameters.AddWithValue("@RunTime", "2011-1-1");
            myCommand.Parameters.AddWithValue("@StpTime", "2011-1-1");

            myCommand.Parameters.AddWithValue("@UsWater", pumprlt.UsWater);

            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        #endregion //SavePumpHistoryData


        #region Pump_Inp_Save
        /// <summary>
        /// ��վ�򿨼�ˮ����¼�洢
        /// </summary>
        /// <param name="pump_inp"></param>
        public void Pump_Inp_Save(ref object pump_inp)
        {
            if (pump_inp is Pump_Inp)
                throw new ArgumentException(" argument isn't pump_inp");

            DataBaseConnect();
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("TT_Pump_Inp", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            Pump_Inp pumpinp = (Pump_Inp)pump_inp;

            myCommand.Parameters.AddWithValue("@ComAdr", pumpinp.ComAdr);
            myCommand.Parameters.AddWithValue("@StrTime", pumpinp.DateTime);
            myCommand.Parameters.AddWithValue("@InWater", pumpinp.InWater);
            myCommand.Parameters.AddWithValue("@ReWater", pumpinp.ReWater);
            myCommand.Parameters.AddWithValue("@In_ReWater", pumpinp.In_ReWater);

            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        #endregion //Pump_Inp_Save


        #region Login
        /// <summary>
        /// �û���¼��֤
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <param name="Id_Role">����Ȩ��id</param>
        public void Login(string UserName, string UserPwd, ref int Id_Role)
        {
            DataBaseConnect();
            myConnection.Open();
            SqlParameter Return_Role;

            SqlCommand myCommand = new SqlCommand("TS_Login", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            Return_Role = myCommand.Parameters.Add("RETURN_ROLE", SqlDbType.Int);
            Return_Role.Direction = ParameterDirection.ReturnValue;
            myCommand.Parameters.AddWithValue("@UserName", UserName);
            myCommand.Parameters.AddWithValue("@UserPwd", UserPwd);
            myCommand.ExecuteNonQuery();
            Id_Role = System.Convert.ToInt32(myCommand.Parameters["RETURN_ROLE"].Value);
            myConnection.Close();
        }
        #endregion //Login


        #region PassWord_New
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <param name="Pwd_Old"></param>
        /// <param name="Pwd_New1"></param>
        /// <param name="Pwd_New2"></param>
        /// <param name="Inf_Val">����ֵ</param>
        public void PassWord_New(string Pwd_Old, string Pwd_New1, string Pwd_New2, ref int Inf_Val)
        {
            string UserName = Config.Default.UserName;
            DataBaseConnect();
            myConnection.Open();
            SqlParameter Return_Info;

            SqlCommand myCommand = new SqlCommand("TS_Password", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            Return_Info = myCommand.Parameters.Add("RETURN_INFO", SqlDbType.Int);
            Return_Info.Direction = ParameterDirection.ReturnValue;
            myCommand.Parameters.AddWithValue("@UserName", UserName);
            myCommand.Parameters.AddWithValue("@Pwd_Old", Pwd_Old);
            myCommand.Parameters.AddWithValue("@Pwd_New1", Pwd_New1);
            myCommand.Parameters.AddWithValue("@Pwd_New2", Pwd_New2);
            myCommand.ExecuteNonQuery();
            Inf_Val = System.Convert.ToInt32(myCommand.Parameters["RETURN_INFO"].Value);
            myConnection.Close();
        }
        #endregion //PassWord_New
    }
}
