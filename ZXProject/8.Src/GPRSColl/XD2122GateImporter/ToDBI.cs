using System;
using System.Collections.Generic;
using System.Text;

namespace XD2122GateImporter
{
    public class ToDBI : Xdgk.Common.DBIBase
    {
        public ToDBI(string connstring)
            : base(connstring)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal int ReadToDeviceID(string name)
        {
            string s = string.Format(
                "select id from v_gate where address = '{0}'",
                name);

            object obj = ExecuteScalar(s);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                CreateToDevice(name);
                return ReadToDeviceID(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        private void CreateToDevice(string name)
        {
            InsertAddress(name);
            int addressID = GetAddressID(name);
            InsertGate(addressID);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InsertGate(int addressID)
        {
            // comAdr 和 ID 相同
            //
            string s = string.Format(
                "INSERT INTO Tb_GateInf([Id], [ComAdr], [Sim], [Ip], [DeviceType])" +
                "VALUES({0}, {1}, '13900000001', '0.0.0.1', 'xd-2122')",
                addressID,
                addressID);
            ExecuteScalar(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        private void InsertAddress(string name)
        {

            /*
             * 
INSERT INTO [LXDB20110513].[dbo].[Tb_Address]([Id], [Address], [Id_Area], [Id_Place], [Id_Sign], [Id_Pole], [WaterChage])
VALUES(<Id,int,>, <Address,varchar(50),>, <Id_Area,varchar(50),>, <Id_Place,varchar(50),>, <Id_Sign,varchar(50),>, <Id_Pole,int,>, <WaterChage,decimal(18,2),>)
             * 
             */

            string s = string.Format(
                "insert into tb_address(id, address, id_area, id_place, id_sign, id_pole, waterChage)" +
                "values( {0}, '{1}', 'TH', 'ZX',  'Gate', '{2}', 1.0)",
                GetAddressNextID(),
                name,
                GetAddressNextPole());

            ExecuteScalar(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int GetAddressID(string name)
        {
            string s = string.Format(
                "select max(id) from tb_address where Address = '{0}'", 
                name);

            object obj = ExecuteScalar(s);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                throw new ArgumentException(
                    string.Format("cannot find '{0}' from tb_address",name)
                    );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private object GetAddressNextPole()
        {
            string s = "select max(id_pole) from tb_address";
            object obj = ExecuteScalar(s);
            if (obj != null)
            {
                int max = Convert.ToInt32(obj);
                return max + 1;
            }
            else
            {
                return 1;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetAddressNextID()
        {
            string s = "select max(ID) from tb_address";
            object obj = ExecuteScalar(s);
            if (obj != null)
            {
                int max = Convert.ToInt32(obj);
                return max + 1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gateID"></param>
        /// <returns></returns>
        public DateTime ReadLastGateDataDateTime(string name)
        {
            string s = string.Format("select DT from v_gateLast where name = '{0}'", name);
            object obj = ExecuteScalar(s);
            if (obj != null)
            {
                return Convert.ToDateTime(obj);
            }
            else
            {
                return DateTime.Parse("2000-1-1");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal int ReadToDeviceComAdr(int deviceID)
        {
            string s = string.Format(
                "select comAdr from tb_gateInf where id = '{0}'",
                deviceID);

            object obj = ExecuteScalar(s);
            if (obj != null || obj != DBNull.Value)
            {
                return Convert.ToInt32(obj);
            }

            throw new InvalidOperationException(
                string.Format("catnot find gate comadr by id '{0}'",
                deviceID)
                );
        }
    }
}
