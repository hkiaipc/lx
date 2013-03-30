using System;
using GateDriver;
using GprsSystem;

namespace PumpDriver
{
    /// <summary>
    /// Pump_Read 的摘要说明。
    /// </summary>
    public class PumpProcessor
    {
        #region Members

        private int address;
        private int flux;
        private int efficiency;
        private long reWater;
        private long tuWater;
        // 2008-5-28 pump_save @run == null exception
        //
        private string run = string.Empty;
        private string forceRun = string.Empty;
        private string vibrate = string.Empty;
        private string power = string.Empty;
        private int recordNO;
        private int totalRecordCount;

        private string runDateTime = DateTime.MinValue.ToString();
        private string stpDateTime = DateTime.MinValue.ToString();
        private long usWater;

        private string sign = string.Empty;
        private string datetime = DateTime.MinValue.ToString();

        private long inWater;
        private long in_reWater;

        private byte[] crc = new byte[2];
        private CRC_16 CRC = new CRC_16();

        private DataFlag _dataFlag = DataFlag.UNKNOWN;
        #endregion //Members

        #region DataFlag
        /// <summary>
        /// 
        /// </summary>
        public DataFlag DataFlag
        {
            get { return _dataFlag; }
        }
        #endregion //DataFlag

        #region PumpReader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataLength"></param>
        /// <param name="refValue"></param>
        public PumpProcessor(byte[] data, int Len, ref object oPars)
        {
            //进行校验
            //
            if (Len <= 2)
            {
                oPars = null;
                _dataFlag = DataFlag.LENGTH_ERROR;
                return;
            }

            //进行校验
            byte[] DataVal = new byte[Len - 2];
            for (int i = 0; i < Len - 2; i++)
            {
                DataVal[i] = data[i];
            }
            crc = CRC.CRC16(DataVal);

            //分析数据
            if (data[Len - 2] == crc[0] && data[Len - 1] == crc[1])
            {
                address = (int)data[3];//得到站号
                switch (data[5])
                {
                    //实时数据
                    case PumpDefine.FCDefine.FC_READREAL:
                        {
                            // 正常数据长度应该为46
                            // 有可能上传长度为28且CRC校验正确的数据
                            //
                            if (data.Length == 46)
                            {
                                //Read_Rlt(data, ref refValue);
                                PumpRealData prd = ParseRealData(data);
                                oPars = prd;
                            }
                            else
                            {
                                _dataFlag = DataFlag.LENGTH_ERROR;
                                oPars = null;
                                return;
                            }
                        }
                        break;
                }
                this._dataFlag = DataFlag.OK;
            }
            else
            {
                this._dataFlag = DataFlag.CRC_ERROR;
                oPars = null;
            }
        }
        #endregion //PumpReader

        #region Read_Rlt
        /// <summary>
        /// 读取实时数据部分
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        //private void ParseRealData(byte[] data, ref object refValue)
        private PumpRealData ParseRealData(byte[] Data)
        {
            //运行状态
            switch (Data[7])
            {
                case 0x50:
                    run = "无运行状态";
                    break;
                case 0x5A:
                    run = "正常运行状态";
                    break;
                case 0x5B:
                    run = "振动运行状态";
                    break;
                default:
                    run = string.Format("未知状态(0x{0})", Data[7].ToString("X"));
                    break;
            }
            //剩余水量	
            string strReWater = "";
            for (int i = 8; i < 12; i++)//8,9,10,11
            {
                strReWater += Data[i].ToString("x2");
            }
            reWater = Convert.ToInt32(strReWater, 16);
            //已用水量
            string strTuWater = "";
            for (int i = 12; i < 16; i++)//12,13,14,15
            {
                strTuWater += Data[i].ToString("x2");
            }
            tuWater = Convert.ToInt32(strTuWater, 16);
            //流量
            flux = (Data[16] * 256 + Data[17]);
            //效率
            efficiency = (int)Data[18];

            // 2007-09-18 Modify data[19] == 0x38
            //
            //强启状态
            //			if(data[19]==0x0){forceRun="允许强启";}
            //			if(data[19]==0x1){forceRun="禁止强启";}
            byte forceRunByte = Data[19];
            if (forceRunByte == 0x00)
                forceRun = "允许强启";
            else if (forceRunByte == 0x01)
                forceRun = "禁止强启";
            else
                forceRun = string.Format("未知(0x{0})", forceRunByte.ToString("X2"));

            //振动传感器状态
            if (Data[20] == 0x1) { vibrate = "振动状态"; }
            if (Data[20] == 0x0) { vibrate = "无振状态"; }
            //供电状态
            if (Data[21] == 0x0) { power = "市电状态"; }
            if (Data[21] == 0x1) { power = "电池状态"; }
            //记录号
            recordNO = (int)(Data[22] * 256 + Data[23]);
            //总记录数
            totalRecordCount = (int)(Data[24] * 256 + Data[25]);

            //			//记录号
            //			noRec=(int)(data[26] * 256 + data[27]);	
            if (Data.Length > 30)
            {
                //启泵日期时间	
                string RunDate = "20" + Data[30].ToString("x2") + "-" + Data[29].ToString("x") + "-" + Data[28].ToString("x");
                string RunTime = Data[33].ToString("x") + ":" + Data[32].ToString("x2") + ":" + Data[31].ToString("x2");
                runDateTime = RunDate + " " + RunTime;
                //停泵日期时间	
                string stopDate = "20" + Data[36].ToString("x2") + "-" + Data[35].ToString("x") + "-" + Data[34].ToString("x");
                string stopTime = Data[39].ToString("x") + ":" + Data[38].ToString("x2") + ":" + Data[37].ToString("x2");
                stpDateTime = stopDate + " " + stopTime;
                //期间用水量
                string strUsWater = "";
                for (int i = 40; i < 44; i++)//40,41,42,43
                {
                    strUsWater += Data[i].ToString("x2");
                }
                usWater = Convert.ToInt32(strUsWater, 16);
            }
            PumpRealData rlt = new PumpRealData(address, flux, efficiency, reWater, tuWater, run, forceRun, vibrate,
                power, recordNO, runDateTime, stpDateTime, usWater);
            rlt.OriginalData = (byte[])Data.Clone();
            //refValue = rlt;
            return rlt;

        }
        #endregion //Read_Rlt

        #region Read_His
        /// <summary>
        /// 读取历史数据部分
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_His(byte[] Data, ref object oPars)
        {
            //记录号
            recordNO = Data[7] * 256 + Data[8];
            //启泵日期时间	
            string RunDate = "20" + Data[11].ToString("x2") + "-" + Data[10].ToString("x") + "-" + Data[9].ToString("x");
            string RunTime = Data[14].ToString("x") + ":" + Data[13].ToString("x2") + ":" + Data[12].ToString("x2");
            runDateTime = RunDate + " " + RunTime;
            //停泵日期时间	
            string StpDate = "20" + Data[17].ToString("x2") + "-" + Data[16].ToString("x") + "-" + Data[15].ToString("x");
            string StpTime = Data[20].ToString("x") + ":" + Data[19].ToString("x2") + ":" + Data[18].ToString("x2");
            stpDateTime = StpDate + " " + StpTime;
            //期间用水量
            string strUsedWater = "";
            for (int i = 21; i < 25; i++)//21,22,23,24
            {
                strUsedWater += Data[i].ToString("x2");
            }
            usWater = Convert.ToInt32(strUsedWater, 16);
            oPars = new PumpHistoryData(address, recordNO, runDateTime, stpDateTime, usWater);
        }
        #endregion //Read_His

        #region Read_RS_Par
        /// <summary>
        /// 读取上传的电流或振动启停的数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_RS_Par(byte[] Data, ref object oPars)
        {
            //标志位
            switch (Data[7])
            {
                case 0x01:
                    sign = "电流启动";
                    break;
                case 0x02:
                    sign = "电流停止";
                    break;
                case 0x03:
                    sign = "振动启动";
                    break;
                case 0x04:
                    sign = "振动停止";
                    break;
            }
            //当前日期时间	
            string RunDate = "20" + Data[10].ToString("x2") + "-" + Data[9].ToString("x") + "-" + Data[8].ToString("x");
            string RunTime = Data[13].ToString("x") + ":" + Data[12].ToString("x2") + ":" + Data[11].ToString("x2");
            datetime = RunDate + " " + RunTime;
            //当前总用水量
            string strUsedWater = "";
            for (int i = 14; i < 18; i++)//14,15,16,17
            {
                strUsedWater += Data[i].ToString("x2");
            }
            tuWater = Convert.ToInt32(strUsedWater, 16);
            //当前剩余水量
            string strReWater = "";
            for (int i = 18; i < 22; i++)//18,19,20,21
            {
                strReWater += Data[i].ToString("x2");
            }
            reWater = Convert.ToInt32(strReWater, 16);
            oPars = new Pump_RS(address, sign, datetime, tuWater, reWater);
        }
        #endregion //Read_RS_Par

        #region Read_Inp_Water
        /// <summary>
        /// 读取上传数据卡输入数据时的数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_Inp_Water(byte[] Data, ref object oPars)
        {
            //记录号
            recordNO = Data[7];

            //打卡日期时间
            string RunDate = "20" + Data[10].ToString("x2") + "-" + Data[9].ToString("x") + "-" + Data[8].ToString("x");
            string RunTime = Data[13].ToString("x") + ":" + Data[12].ToString("x2") + ":" + Data[11].ToString("x2");
            datetime = RunDate + " " + RunTime;

            //加入水量
            string strInWater = "";
            for (int i = 14; i < 18; i++)//14,15,16,17
            {
                strInWater += Data[i].ToString("x2");
            }
            inWater = Convert.ToInt32(strInWater, 16);

            //打卡前剩余水量
            string strReWater = "";
            for (int i = 18; i < 22; i++)//18,19,20,21
            {
                strReWater += Data[i].ToString("x2");
            }
            reWater = Convert.ToInt32(strReWater, 16);

            //打卡前剩余水量
            string in_strReWater = "";
            for (int i = 22; i < 26; i++)//22,23,24,25
            {
                in_strReWater += Data[i].ToString("x2");
            }
            in_reWater = Convert.ToInt32(in_strReWater, 16);
            oPars = new Pump_Inp(address, recordNO, datetime, inWater, reWater, in_reWater);
        }
        #endregion //Read_Inp_Water

        #region Read_Sts
        /// <summary>
        /// 读取上传数据状态
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_Sts(byte[] Data, ref object oPars)
        {
            switch (Data[5])
            {
                //启泵状态
                case 0x00:
                    oPars = new Pump_Sts(address, "启泵成功");
                    break;
                //停泵状态
                case 0x01:
                    oPars = new Pump_Sts(address, "停泵成功");
                    break;
                //水量设置状态
                case 0x02:
                    oPars = new Pump_Sts(address, "水量设置成功");
                    break;
                //管理卡设置
                case 0x03:
                    oPars = new Pump_Sts(address, "管理卡设置成功");
                    break;
                //启停卡设置
                case 0x04:
                    oPars = new Pump_Sts(address, "启停卡设置成功");
                    break;
                //数据卡设置
                case 0x05:
                    oPars = new Pump_Sts(address, "数据卡设置成功");
                    break;
                //流量设置
                case 0x07:
                    oPars = new Pump_Sts(address, "流量设置成功");
                    break;
                //效率设置
                case 0x08:
                    oPars = new Pump_Sts(address, "效率设置成功");
                    break;
                //站号设置
                case 0x09:
                    oPars = new Pump_Sts(address, "站号设置成功");
                    break;
                //振动传感器阻尼时间
                case 0x0A:
                    oPars = new Pump_Sts(address, "振动传感器阻尼时间设置成功");
                    break;
                //修改日期
                case 0x0B:
                    oPars = new Pump_Sts(address, "修改日期成功");
                    break;
                //修改时间
                case 0x0C:
                    oPars = new Pump_Sts(address, "修改时间成功");
                    break;
                //清除运行记录
                case 0x0D:
                    oPars = new Pump_Sts(address, "清除运行记录成功");
                    break;
                //清除打卡记录
                case 0x0E:
                    oPars = new Pump_Sts(address, "清除打卡记录成功");
                    break;
                //清除剩余水量总用水量
                case 0x0F:
                    oPars = new Pump_Sts(address, "清除剩余水量总用水量成功");
                    break;
                //清除已用时间
                case 0x10:
                    oPars = new Pump_Sts(address, "清除已用时间成功");
                    break;
                //设置泵站强启状态
                case 0x18:
                    oPars = new Pump_Sts(address, "操作设置成功");
                    break;
                //读取管理卡密码
                case 0x1E:
                    string Pwd_Mn = Convert.ToString(Data[7] * 256 + Data[8]);
                    oPars = new Pump_Sts(address, "管理卡密码:" + "\r\n" + Pwd_Mn);
                    break;
                //读取启停卡密码
                case 0x1F:
                    string Pwd_Rs = Convert.ToString(Data[7] * 256 + Data[8]);
                    oPars = new Pump_Sts(address, "启停卡密码:" + "\r\n" + Pwd_Rs);
                    break;
                //读取数据卡密码
                case 0x20:
                    string Pwd_Dt = Convert.ToString(Data[7] * 256 + Data[8]);
                    oPars = new Pump_Sts(address, "数据卡密码:" + "\r\n" + Pwd_Dt);
                    break;
                //设置管理卡密码
                case 0x21:
                    oPars = new Pump_Sts(address, "设置管理卡密码成功");
                    break;
                //设置启停卡密码
                case 0x22:
                    oPars = new Pump_Sts(address, "设置启停卡密码成功");
                    break;
                //设置数据卡密码
                case 0x23:
                    oPars = new Pump_Sts(address, "设置数据卡密码成功");
                    break;
            }
        }
        #endregion //Read_Sts
    }
}
