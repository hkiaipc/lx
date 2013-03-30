using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;

using Xdgk.Communi;
using Xdgk.Communi.Builder;

namespace CommuniServer
{
    public class DBHardWareBuilder : HardwareBuilderBase
    {
        /// <summary>
        /// 
        /// </summary>
        //private DBStation[] _stations;
        private DataTable _hardWareDataTable;
        private DataTable _stationDataTable;
        private DataTable _deviceDataTable;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stations"></param>
        public DBHardWareBuilder(DataTable hardWareDataTable)
        {
            if (hardWareDataTable == null)
                throw new ArgumentNullException("hardWareDataTable");
            //this._stations = stations;
            this._hardWareDataTable = hardWareDataTable;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationDataTable"></param>
        /// <param name="deviceDataTable"></param>
        public DBHardWareBuilder(DataTable stationDataTable, DataTable deviceDataTable)
        {
            this._stationDataTable = stationDataTable;
            this._deviceDataTable = deviceDataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soft"></param>
        public override void Build(CommuniSoft soft)
        {
            System.Collections.Hashtable idStationMap = new System.Collections.Hashtable();
            // build station
            //
            foreach (DataRow stationDR in _stationDataTable.Rows)
            {
                bool isStationDeleted = false;
                if (stationDR["Deleted"] != DBNull.Value)
                {
                    isStationDeleted = Convert.ToBoolean(stationDR["Deleted"]);
                }

                if (!isStationDeleted)
                {
                    string stationName = stationDR["Name"].ToString();
                    bool isExistStation = soft.HardwareManager.Stations.ExistName(stationName, null);
                    if (!isExistStation)
                    {
                        string xml = stationDR["CommuniTypeContent"].ToString().Trim();
                        if (xml.Length == 0)
                        {
                            // TODO: 2010-09-17
                            // log error info
                            //
                            continue;
                        }

                        int stationID = (int)stationDR["StationID"];

                        XmlDataDocument doc = new XmlDataDocument();
                        doc.LoadXml(xml);
                        XmlNode node = doc.SelectSingleNode("socketcommunitype");
                        CommuniType communiType = Xdgk.Communi.XmlBuilder.XmlSocketCommuniBuilder.Build(node);

                        Station station = new Station(stationName, communiType);
                        station.ID = stationID;
                        idStationMap.Add(stationID, station);
                        soft.HardwareManager.Stations.Add(station);
                    }
                }
            }

            // build device
            //
            foreach (DataRow deviceDR in _deviceDataTable.Rows)
            {
                bool isDeviceDeleted = false;
                if (deviceDR["deleted"] != DBNull.Value)
                {
                    isDeviceDeleted = Convert.ToBoolean(deviceDR["Deleted"]);
                }

                if (isDeviceDeleted)
                {
                    continue;
                }

                int stationID = (int)deviceDR["StationID"];
                int deviceID = (int)deviceDR["DeviceID"];
                string deviceType = deviceDR["DeviceType"].ToString();
                string addressString = deviceDR["Address"].ToString().Trim();

                if (addressString.Length == 0)
                    continue;

                int address = Convert.ToInt32(addressString);

                Station st = idStationMap[stationID] as Station;
                if (st == null)
                {
                    continue;
                }

                //DeviceDefine dd = soft.DeviceDefineCollection.FindDeviceDefine(deviceType);
                DeviceDefine dd = soft.DeviceDefineManager.DeviceDefineCollection.FindDeviceDefine(deviceType);
                if (dd == null)
                {
                    bool exist = soft.UnDefineDeviceType.Exist(deviceType);
                    if (!exist)
                    {
                        soft.UnDefineDeviceType.Add(deviceType);
                        string msg = string.Format(strings.UnDefineDeviceType, deviceType);
                        NUnit.UiKit.UserMessage.Display(msg);
                    }
                    continue;
                }

                //Xdgk.Communi.Device device = new Device(dd, "", address);
                Xdgk.Communi.Device device = DeviceFactory.Create(dd, "", address);

                //Xdgk.Communi.Device device = new Device(deviceType, address);
                //string t = soft.OperaFactory.DeviceDefineCollection.GetDeviceText(deviceType);
                //device.Text = t;
                device.ID = deviceID;

                //Station st = soft.HardwareManager.GetStation(stationName);
                st.Devices.Add(device);
            }

            //
            //
            StationCollection rainStations = this.CreateRainStations(soft);
            foreach ( Station item in rainStations )
            {
                soft.HardwareManager.Stations.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StationCollection CreateRainStations(CommuniSoft soft)
        {
            string deviceType = "LXRainDevice";

            StationCollection stations = new StationCollection();
            DataTable stTable = LXDBDBI.LXDB.GetRainStationDataTable();
            foreach (DataRow row in stTable.Rows)
            {
                string rainName = row["Rain_Name"].ToString();
                int rainAddress = Convert.ToInt32(row["Rain_addr"]);
                string ipString = row["Rain_IP"].ToString();
                IPAddress ip = IPAddress.Parse(ipString);
                int deviceid = rainAddress;
                int stationid = rainAddress;

                SocketCommuniType ct = new SocketCommuniType(ip);
                Station st = new Station(rainName, ct);
                st.ID = stationid;

                DeviceDefine dd = soft.DeviceDefineManager.
                    DeviceDefineCollection.FindDeviceDefine(deviceType);
                LXRainDevice d = new LXRainDevice(dd,rainAddress);
                d.ID = deviceid;

                st.Devices.Add(d);

                stations.Add(st);
            }
            return stations;
        }
    }
}
