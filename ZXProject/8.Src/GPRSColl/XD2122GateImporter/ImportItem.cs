using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Data.SqlClient;

namespace XD2122GateImporter
{
    public class TransItem
    {
        #region FromDevice
        /// <summary>
        /// 
        /// </summary>
        public FromDevice FromDevice
        {
            get
            {
                if (_fromDevice == null)
                {
                    _fromDevice = new FromDevice();
                }
                return _fromDevice;
            }
            set
            {
                _fromDevice = value;
            }
        } private FromDevice _fromDevice;
        #endregion //FromDevice

        #region ToDevice
        /// <summary>
        /// 
        /// </summary>
        public ToDevice ToDevice
        {
            get
            {
                if (_toDevice == null)
                {
                    _toDevice = new ToDevice();
                }
                return _toDevice;
            }
            set
            {
                _toDevice = value;
            }
        } private ToDevice _toDevice;
        #endregion //ToDevice

    }


    public class DeviceBase
    {
        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name

        #region ID
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
            }
        } private int _iD;
        #endregion //ID

        #region DBI
        /// <summary>
        /// 
        /// </summary>
        public Xdgk.Common.DBIBase DBI
        {
            get
            {
                return _dBI;
            }
            set
            {
                _dBI = value;
            }
        } private Xdgk.Common.DBIBase _dBI;
        #endregion //DBI


        #region Elvation
        /// <summary>
        /// 基本高程, 单位M
        /// </summary>
        public float Elvation
        {
            get
            {
                return _elvation;
            }
            set
            {
                _elvation = value;
            }
        } private float _elvation;
        #endregion //Elvation

    }


    public class FromDevice : DeviceBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formDateTime"></param>
        /// <returns></returns>
        public DataTable ReadDataTable(DateTime fromDateTime)
        {
            return ((FromDBI)DBI).ReadNewDataTable(this.ID, fromDateTime);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ToDevice : DeviceBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        public void WriteDataTable(DataTable tbl)
        {
            foreach (DataRow row in tbl.Rows)
            {
                WriteDataRow(row);
            }
        }

        static private float MToCM(float value)
        {
             return value * 100f;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private object SafeFloat(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return obj;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        private void WriteDataRow(DataRow row)
        {
            DateTime dt = Convert.ToDateTime(row["DT"]);
            float height = Convert.ToSingle(SafeFloat(row["SluiceHeight"]));
            float before = Convert.ToSingle(SafeFloat (row["BeforeDepth"]));
            float after = Convert.ToSingle(SafeFloat(row["AfterDepth"]));
            float discharge = Convert.ToSingle(SafeFloat (row["Discharge"]));
            double totalWaterVolum = Convert.ToDouble (SafeFloat(row["TotalWaterVolume"]));
            double remineWater = 0 - totalWaterVolum;

            before += Elvation;
            after += Elvation;


            height = MToCM(height);
            before = MToCM(before);
            after = MToCM(after);

            /*
             * 
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
             * 
             */

            SqlCommand myCommand = new SqlCommand("TT_Gate_Save");
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.AddWithValue("@ComAdr", this.ComAdr);
            myCommand.Parameters.AddWithValue("@StrTime", dt);
            myCommand.Parameters.AddWithValue("@BeforeLevel", before);
            myCommand.Parameters.AddWithValue("@BehindLevel", after);
            myCommand.Parameters.AddWithValue("@Height", height);
            myCommand.Parameters.AddWithValue("@Flux", discharge);
            myCommand.Parameters.AddWithValue("@ReWater", remineWater);
            myCommand.Parameters.AddWithValue("@TuWater", totalWaterVolum);
            myCommand.Parameters.AddWithValue("@Power", "");
            myCommand.Parameters.AddWithValue("@Lock", "");

            DBI.ExecuteScalar(myCommand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime ReadLastDataDateTime()
        {
            ToDBI dbi = this.DBI as ToDBI;
            DateTime dt = dbi.ReadLastGateDataDateTime(this.Name);
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        public int ComAdr
        {
            get
            {
                return _comAdr;
            }
            set
            {
                _comAdr = value;
            }
        } private int _comAdr;
    }
}
