using System;
using System.IO;
using GprsSystem;

namespace GateDriver
{
    /// <summary>
    /// 解析口门数据类，见结果保存到oPars对象中。如果解析错误，则oPars为null。
    /// </summary>
    public class GateReader
    {
        private int comAdr;
        private int beforeLevel;
        private int behindLevel;
        private int height;
        private float flux;
        private long reWater;
        private long tuWater;
        private string power = string.Empty;
        private string lock_OC = string.Empty;

        private int noRec;
        private string datetime = DateTime.MinValue.ToString();

        private int toRec;
        private long inWater;

        private int width;
        private int bottomHeight;
        private float freeFlux;
        private float undrFlux;
        private int beforeCorrect;
        private int behindCorrect;

        private byte[] crc = new byte[2];
        private CRC_16 CRC = new CRC_16();

        private DataFlag _dataFlag;

        #region DataFlag
        /// <summary>
        /// 获取数据状态标志
        /// </summary>
        public DataFlag DataFlag
        {
            get { return _dataFlag; }
        }
        #endregion //DataFlag

        #region GateReader
        /// <summary>
        /// 解析来自口门测控仪数据
        /// </summary>
        /// <param name="data">用户数据</param>
        /// <param name="dataLength"></param>
        /// <param name="refValue">返回结果</param>
        public GateReader(byte[] data, ref object oPars)
        {
            int dataLength = 0;
            if (data != null)
            {
                dataLength = data.Length;
            }

            //TODO: len < 2, 2007-06-25 Added
            //
            //进行校验
            if (dataLength <= 2)
            {
                oPars = null;
                _dataFlag = DataFlag.LENGTH_ERROR;
                return;
            }

            byte[] dataValue = new byte[dataLength - 2];
            for (int i = 0; i < dataLength - 2; i++)
            {
                dataValue[i] = data[i];
            }
            crc = CRC.CRC16(dataValue);

            //分析数据(带校验)
            //
            // crc success
            //
            if (data[dataLength - 2] == crc[0] && data[dataLength - 1] == crc[1])
            {
                //得到站号
                comAdr = (int)data[3];

                // data[5] - Function code
                //
                switch (data[5])
                {
                    //参数数据
                    case 0x23:
                        Read_Par(data, ref oPars);
                        break;
                    //实时数据
                    case 0x24:
                        Read_Rlt(data, ref oPars);
                        break;
                    //历史记录
                    case 0x25:
                        {
                            if (!Read_His(data, ref oPars))
                            {
                                _dataFlag = DataFlag.DATA_ERROR;
                                oPars = null;
                                return;
                            }
                            break;
                        }
                    //输入水量记录
                    //
                    case 0x37:
                        Read_InWater(data, ref oPars);
                        break;

                    //最后一条记录
                    //
                    case 0x3C:
                        if (!Read_His(data, ref oPars))
                        {
                            _dataFlag = DataFlag.DATA_ERROR;
                            oPars = null;
                            return;
                        }
                        break;

                    //读取状态量
                    //
                    default:
                        Read_Sts(data, ref oPars);
                        break;
                }
                _dataFlag = DataFlag.OK;
            }
            else
            {
                _dataFlag = DataFlag.CRC_ERROR;
                oPars = null;
            }
        }
        #endregion //GateReader

        #region Read_Rlt
        /// <summary>
        /// 读取实时数据部分
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_Rlt(byte[] Data, ref object oPars)
        {
            //实际闸高
            height = Data[7] * 256 + Data[8];
            //闸前水位
            beforeLevel = Data[9] * 256 + Data[10];
            //闸后水位
            behindLevel = Data[11] * 256 + Data[12];
            //瞬时流量
            if (Data[13] == 0xFF && Data[14] == 0xFF)
            {
                flux = 9999;//错误瞬时流量
            }
            else
            {
                flux = (Data[13] * 256 + Data[14]) / 100f;//正确瞬时流量
            }
            //剩余水量
            string strReWater = "";
            for (int i = 15; i < 19; i++)//15,16,17,18
            {
                strReWater += Data[i].ToString("x2");
            }
            reWater = Convert.ToInt32(strReWater, 16);
            //总用水量
            string strTuWater = "";
            for (int i = 19; i < 23; i++)//19,20,21,22
            {
                strTuWater += Data[i].ToString("x2");
            }
            tuWater = Convert.ToInt32(strTuWater, 16);
            //供电状态
            if (Data[23] == 0x00) { power = "市电状态"; }
            if (Data[23] == 0xFF) { power = "电池状态"; }
            //开关锁状态
            switch (Data[24])
            {
                case 0x00:
                    lock_OC = "强关状态";
                    break;

                case 0x01:
                    lock_OC = "强开状态";
                    break;

                case 0x02:
                    lock_OC = "正常状态";
                    break;

                default:
                    lock_OC = "未知状态";
                    break;

            }
            oPars = new Gate_Rlt(comAdr, beforeLevel, behindLevel, height, flux, reWater, tuWater, power, lock_OC);
        }
        #endregion //Read_Rlt

        #region Read_His
        /// <summary>
        /// 读取历史数据部分
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private bool Read_His(byte[] bs, ref object refValue)
        {
            try
            {
                if (bs == null || bs.Length < 32)
                {
                    return false;
                }
                // TODO: 2012-04-24 
                // System.IndexOutOfRangeException: 索引超出了数组界限。
                //
                //

                //记录号
                noRec = bs[7] * 256 + bs[8];
                //日期时间	
                string Date = "20" + bs[9].ToString("x2") + "-" + bs[10].ToString("x") + "-" + bs[11].ToString("x");
                string Time = bs[12].ToString("x") + ":" + bs[13].ToString("x2") + ":" + bs[14].ToString("x2");
                datetime = Date + " " + Time;

                //            if (datetime.
                // TODO: Added 07-07-16 datetime error
                //
                try
                {
                    DateTime dt = DateTime.Parse(datetime);
                }
                catch (Exception ex)
                {
                    SaveException(bs, ex);
                    //                System.Diagnostics.Debug.Assert( false, datetime );
                    refValue = null;
                    return false;
                }
                //闸前水位
                beforeLevel = bs[15] * 256 + bs[16];
                //闸后水位
                behindLevel = bs[17] * 256 + bs[18];
                //实际闸高
                height = bs[19] * 256 + bs[20];
                //瞬时流量
                if (bs[21] == 0xFF && bs[22] == 0xFF)
                {
                    flux = 9999;//错误瞬时流量
                }
                else
                {
                    flux = (bs[21] * 256 + bs[22]) / 100f;//正确瞬时流量
                }
                //剩余水量
                string strReWater = "";
                for (int i = 23; i < 27; i++)//23,24,25,26
                {
                    strReWater += bs[i].ToString("x2");
                }
                reWater = Convert.ToInt32(strReWater, 16);
                //总用水量
                string strTuWater = "";
                for (int i = 27; i < 31; i++)//27,28,29,30
                {
                    strTuWater += bs[i].ToString("x2");
                }
                tuWater = Convert.ToInt32(strTuWater, 16);
                //供电状态
                if (bs[31] == 0x00) { power = "市电状态"; }
                if (bs[31] == 0xFF) { power = "电池状态"; }
                //开关锁状态
                switch (bs[32])
                {
                    case 0x00:
                        lock_OC = "强关状态";
                        break;
                    case 0x01:
                        lock_OC = "强开状态";
                        break;
                    case 0x02:
                        lock_OC = "正常状态";
                        break;
                }
                refValue = new Gate_His(comAdr, noRec, datetime, beforeLevel, behindLevel, height, flux, reWater, tuWater, power, lock_OC);
                return true;
            }
            catch (Exception ex)
            {
                SaveException(bs, ex);
                return false;
            }
        }
        #endregion //Read_His

        #region SaveException
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <param name="ex"></param>
        private void SaveException(byte[] bs, Exception ex)
        {
            try
            {
                System.IO.StreamWriter sw = File.AppendText("c:\\read_his.err");
                string s = BitConverter.ToString(bs);
                sw.WriteLine(s);
                sw.WriteLine(ex.ToString());
                sw.WriteLine(datetime);
                sw.Close();
            }
            finally
            {

            }
        }
        #endregion //SaveException

        #region Read_InWater
        /// <summary>
        /// 读取输入水量记录
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_InWater(byte[] Data, ref object oPars)
        {
            //总记录号
            toRec = Data[7];
            //记录号
            noRec = Data[8];
            //日期时间	
            string Date = "20" + Data[9].ToString("x2") + "-" + Data[10].ToString("x") + "-" + Data[11].ToString("x");
            string Time = Data[12].ToString("x") + ":" + Data[13].ToString("x2") + ":" + Data[14].ToString("x2");
            datetime = Date + " " + Time;
            //输入水量
            string strInWater = "";
            for (int i = 15; i < 19; i++)//15,16,17,18
            {
                strInWater += Data[i].ToString("x2");
            }
            inWater = Convert.ToInt32(strInWater, 16);
            oPars = new Gate_Inp(comAdr, toRec, noRec, datetime, inWater);
        }
        #endregion //Read_InWater


        #region Read_Par
        /// <summary>
        /// 读取参数数据部分
        /// </summary>
        /// <param name="data">用户数据</param>
        /// <param name="refValue">返回结果</param>
        private void Read_Par(byte[] Data, ref object oPars)
        {
            //从机地址
            comAdr = Data[7];
            //实际闸宽
            width = Data[8] * 256 + Data[9];
            //闸底高程
            bottomHeight = Data[10] * 256 + Data[11];
            //自由流系数
            freeFlux = Data[12] / 100;
            //潜流系数
            undrFlux = Data[21] / 100;
            //闸前水位量程
            beforeLevel = Data[13] * 256 + Data[14];
            //闸后水位量程
            behindLevel = Data[15] * 256 + Data[16];
            //闸前水位修正
            if (Data[17] == 0x43) { beforeCorrect = (int)Data[18]; }
            if (Data[17] == 0x45) { beforeCorrect = (int)Data[18] * -1; }
            //闸后水位修正
            if (Data[19] == 0x43) { behindCorrect = (int)Data[20]; }
            if (Data[19] == 0x45) { behindCorrect = (int)Data[20] * -1; }
            oPars = new Gate_Par(comAdr, width, bottomHeight, freeFlux, undrFlux, beforeLevel, behindLevel, beforeCorrect, behindCorrect);
        }
        #endregion //Read_Par

        #region Read_Sts
        /// <summary>
        /// 读取上传数据状态
        /// </summary>
        /// <param name="data"></param>
        /// <param name="refValue"></param>
        private void Read_Sts(byte[] Data, ref object oPars)
        {
            // data[5] - function code
            //
            switch (Data[5])
            {
                //开锁状态
                case 0x2D:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "开锁成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "开锁失败");
                    }
                    break;
                //关锁状态
                case 0x2E:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "关锁成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "关锁失败");
                    }
                    break;
                //正常开关锁状态
                case 0x2F:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "正常开关锁设置成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "正常开关锁设置失败");
                    }
                    break;
                //上传数据卡号
                case 0x27:
                    string strTm = "";
                    for (int i = 7; i < 15; i++)//7,8,9,10,11,12,13,14
                    {
                        strTm += Data[i].ToString("x2") + " ";
                    }
                    oPars = new Gate_Sts(comAdr, "数据卡号:" + "\r\n" + strTm);
                    break;
                //修改从机栈号波特率
                case 0x16:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "修改从机栈号波特率成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "修改从机栈号波特率失败");
                    }
                    break;
                //修改闸宽
                case 0x17:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "修改闸宽成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "修改闸宽失败");
                    }
                    break;
                //修改闸底高程
                case 0x18:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "修改闸底高程成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "修改闸底高程失败");
                    }
                    break;
                //修改流量系数
                case 0x19:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "修改流量系数成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "修改流量系数失败");
                    }
                    break;
                //修改闸前水位量程
                case 0x1A:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "修改闸前水位量程成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "修改闸前水位量程失败");
                    }
                    break;
                //修改闸后水位量程
                case 0x1B:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "修改闸后水位量程成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "修改闸后水位量程失败");
                    }
                    break;
                //修改日期
                case 0x1E:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "修改日期成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "修改日期失败");
                    }
                    break;
                //修改时间
                case 0x1F:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "修改时间成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "修改时间失败");
                    }
                    break;
                //加入水量
                case 0x20:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "加入水量成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "加入水量失败");
                    }
                    break;
                //清除总水量
                case 0x21:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "清除总水量成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "清除总水量失败");
                    }
                    break;
                //数据卡设置
                case 0x22:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "数据卡设置成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "数据卡设置失败");
                    }
                    break;
                //清除历史记录
                case 0x26:
                    if (Data[7] == 0x4F && Data[8] == 0x4B)
                    {
                        oPars = new Gate_Sts(comAdr, "清除历史记录成功");
                    }
                    else
                    {
                        oPars = new Gate_Sts(comAdr, "清除历史记录失败");
                    }
                    break;
            }
        }
        #endregion //Read_Sts
    }
}
