using System;
using System.Collections.Generic;
using System.Text;

namespace GprsSystem
{

    public class Int16ModbusConverter //: Xdgk.Communi.Interface.BytesConverter
    {
        public byte[] ConvertToBytes(object obj)
        {
            Int16 n = Convert.ToInt16(obj);
            return Int16ToBytes(n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static public byte[] Int16ToBytes(Int16 n)
        {
            byte[] temp = BitConverter.GetBytes(n);
            Array.Reverse(temp);
            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        static public Int16 BytesToInt16(byte[] bytes)
        {
            byte[] temp = (byte[])bytes.Clone();
            Array.Reverse(temp);
            Int16 n = BitConverter.ToInt16(temp, 0);
            return n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public object ConvertToObject(byte[] bytes)
        {
            return BytesToInt16(bytes);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Int32ModbusConverter //: Xdgk.Communi.Interface.BytesConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] ConvertToBytes(object obj)
        {
            Int32 n = Convert.ToInt32(obj);
            byte[] bs = BitConverter.GetBytes(n);

            byte[] bsResult = new byte[] { bs[1], bs[0], bs[3], bs[2] };
            return bsResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public object ConvertToObject(byte[] bytes)
        {
            byte[] bs = new byte[] { bytes[2], bytes[3], bytes[0], bytes[1] };
            Array.Reverse(bs);
            return BitConverter.ToInt32(bs, 0);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UInt32ModbusConverter //: Xdgk.Communi.Interface.BytesConverter 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] ConvertToBytes(object obj)
        {
            UInt32 u = Convert.ToUInt32(obj);
            byte[] bs = BitConverter.GetBytes(u);
            //Console.WriteLine(BitConverter.ToString(bs));
            byte[] bsResult = new byte[] { bs[1], bs[0], bs[3], bs[2] };
            return bsResult;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public object ConvertToObject(byte[] bytes)
        {
            byte[] bs = new byte[] { bytes[2], bytes[3], bytes[0], bytes[1] };
            //Console.WriteLine(BitConverter.ToString(bs));
            Array.Reverse(bs);
            return BitConverter.ToUInt32(bs, 0);
        }
    }
    public class XD202
    {
        /// <summary>
        /// 
        /// </summary>
        static public string DeviceType
        {
            get
            {
                return "XD202";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static byte[] CreateReadRealCommand(byte address)
        {
            CRC_16 c = new CRC_16();
            byte[] bs = new byte[] { address, 0x04, 0x00, 0x00, 0x00, 0x11 };
            byte[] crcResult = c.CRC16(bs);
            byte[] r = new byte[bs.Length + 2];
            Array.Copy(bs, r, bs.Length);
            Array.Copy(crcResult, 0, r, bs.Length, crcResult.Length);
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceInfo"></param>
        /// <param name="inbyte"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public static bool Process(DeviceInfo deviceInfo, byte[] inbyte, LogItem li, out GateDriver.Gate_His gateHisortyData)
        {
            gateHisortyData = null;

            // parse xd202 data
            //
            string errormsg;
            object gateHis = Parse(inbyte,out errormsg);

            // save to db
            //
            if (gateHis != null)
            {
                DbClass db = new DbClass();
                db.Gate_His_Save(ref gateHis);

                gateHisortyData = (GateDriver.Gate_His)gateHis;
                return true;
            }
            else
            {
                li.Add("Error", errormsg);
                return false;
            }
        }

        public static GateDriver.Gate_His ParseForTest(byte[] inbyte)
        {
            string s;
            object obj = Parse(inbyte ,out s);
            Console.WriteLine(s);
            return obj as GateDriver.Gate_His;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inbyte"></param>
        /// <returns></returns>
        private static GateDriver.Gate_His Parse(byte[] inbyte , out string errorMsg)
        {
            errorMsg = string.Empty;
            // check null
            //
            if (inbyte == null)
            {
                return null;
            }

            // check length
            //
            if (inbyte.Length < 39)
            {
                errorMsg = "length < 39, is " + inbyte.Length ;
                return null;
            }

            // check data
            //
            if (inbyte[1] == 0x04 && inbyte[2] == 0x22)
            {
                int address = inbyte[0];
                // check crc
                //
                byte[] bscrc = new CRC_16().CRC16(inbyte);
                if ((bscrc[0] == 00) && (bscrc[1] == 00))
                {

                    float IF = Convert.ToInt32(
                        new UInt32ModbusConverter().ConvertToObject(
                        GetPartBytes(inbyte, 3, 4))
                        );
                    IF /= 100F;

                    int remainAmount = Convert.ToInt32(
                        new Int32ModbusConverter().ConvertToObject(
                        GetPartBytes(inbyte, 7, 4)));

                    int height = Convert.ToInt32(
                        new Int16ModbusConverter().ConvertToObject(
                        GetPartBytes(inbyte, 11, 2)
                        )
                        );

                    int wl2 = Convert.ToInt32(
                        new Int16ModbusConverter().ConvertToObject(
                        GetPartBytes(inbyte, 25, 2)
                        )
                        );

                    int wl1 = Convert.ToInt32(
                        new Int16ModbusConverter().ConvertToObject(
                        GetPartBytes(inbyte, 35, 2)
                        )
                        );


                    int totalAmount = Math.Abs(remainAmount);
                    GateDriver.Gate_His d = new GateDriver.Gate_His(address,
                        0, DateTime.Now.ToString(), wl1, wl2, height, IF, remainAmount, totalAmount, 
                        "", "");
                    return d;
                }
                else
                {
                    // crc error
                    //
                    errorMsg = "crc error";
                }
            }
            else
            {
                errorMsg = "data error";
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="begin"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        static private byte[] GetPartBytes(byte[] source, int begin, int length)
        {
            byte[] r = new byte[length];
            Array.Copy(source, begin, r, 0, length);
            return r;
        }
    }
}
