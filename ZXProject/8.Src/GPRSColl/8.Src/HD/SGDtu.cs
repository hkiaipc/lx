using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace GprsSystem
{
    /// <summary>
    /// Slotion Gprs DTU
    /// </summary>
    public class SGDtu
    {

        #region SGDtu
        /// <summary>
        /// 
        /// </summary>
        public SGDtu()
        {
        }
        #endregion //SGDtu


        #region IsDtuHeartBeat
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtuDatas"></param>
        /// <returns></returns>
        public static bool IsDtuHeartBeat(byte[] dtuDatas)
        {
            if (Config.Default.IsUseHDProtocol)
            {
                if (dtuDatas == null || dtuDatas.Length < SGDefine.MIN_PA_LEN)
                    return false;

                return dtuDatas[SGDefine.PACKAGE_TYPE.BeginPostion] == SGDefine.PAT_HEARTBEAT;
            }
            else
            {
                return true;
            }
        }
        #endregion //IsDtuHeartBeat

        #region IsDtuUserData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtuDatas"></param>
        /// <returns></returns>
        public static bool IsDtuUserData(byte[] dtuDatas)
        {
            if (Config.Default.IsUseHDProtocol)
            {
                if (dtuDatas == null || dtuDatas.Length < SGDefine.MIN_PA_LEN)
                {
                    return false;
                }
                else
                {
                    return dtuDatas[SGDefine.PACKAGE_TYPE.BeginPostion] == SGDefine.PAT_USERDATA;
                }
            }
            else
            {
                return true;
            }
        }
        #endregion //IsDtuUserData

        #region GetDtuData
        /// <summary>
        /// 获取DTU数据包数组，每个DTU数据包格式为: 7B ... 7B
        /// </summary>
        /// <param name="receivedData"></param>
        /// <returns></returns>
        static public byte[][] GetDtuData(byte[] receivedData)
        {
            if (!Config.Default.IsUseHDProtocol)
            {
                return new byte[][] { receivedData };
            }



            if (receivedData == null || receivedData.Length == 0)
                return null;

            ArrayList al = new ArrayList();
            // 最短数据包长度为16，
            if (receivedData.Length < SGDefine.MIN_PA_LEN)
                return null;

            for (int i = 0; i < receivedData.Length - SGDefine.MIN_PA_LEN; i++)
            {
                if (receivedData[i] == SGDefine.HEAD_VALUE &&
                    IsCorrectPackageType(receivedData[i + 1]))
                {
                    int packageLen = GetDtuPackageLen(receivedData, i);
                    int tailPos = i + packageLen - 1;
                    // check tailpos in receive 
                    //
                    if (tailPos < receivedData.Length)
                    {
                        if (receivedData[tailPos] == SGDefine.TAIL_VALUE)
                        {
                            byte[] bs = new byte[packageLen];
                            Array.Copy(receivedData, i, bs, 0, packageLen);
                            al.Add(bs);
                        }
                    }
                }
            }

            if (al.Count == 0)
            {
                return null;
            }
            else
            {
                byte[][] r = new byte[al.Count][];
                for (int i = 0; i < al.Count; i++)
                {
                    r[i] = al[i] as byte[];
                }
                return r;
            }
        }
        #endregion //GetDtuData


        #region GetUserData
        /// <summary>
        /// 获取数据包内的用户数据
        /// </summary>
        /// <param name="dtuData"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        static public byte[] GetUserData(byte[] dtuData)
        {
            if (Config.Default.IsUseHDProtocol)
            {
                int size = dtuData.Length - SGDefine.MIN_PA_LEN;
                if (size > 0)
                {
                    byte[] bs = new byte[size];
                    Array.Copy(dtuData, SGDefine.USER_DATA.BeginPostion, bs, 0, dtuData.Length - SGDefine.MIN_PA_LEN);
                    return bs;
                }
                else
                {
                    return new byte[0];
                }
            }
            else
            {
                return dtuData;
            }
        }
        #endregion //GetUserData

        #region GetSimNumber
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtuData"></param>
        /// <returns></returns>
        static public string GetSimNumber(byte[] dtuData)
        {
            string s = string.Empty;
            DataField df = SGDefine.SIM;
            int b = df.BeginPostion;
            int e = df.BeginPostion + df.DataLength;

            //for( int i=df.BeginPostion; i<df.DataLength + i; i++ )
            for (int i = b; i < e; i++)
                s += Convert.ToChar(dtuData[i]);
            return s;
        }
        #endregion //GetSimNumber

        #region GetSimNumberBytes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sim"></param>
        /// <returns></returns>
        static public byte[] GetSimNumberBytes(string sim)
        {
            sim = sim.Trim();
            //            System.Diagnostics.Debug.Assert( sim.Length == 11 );
            if (sim.Length != 11)
                throw new InvalidCastException("invalid sim: " + sim);

            char[] chars = sim.ToCharArray();
            byte[] bs = new byte[chars.Length];

            for (int i = 0; i < chars.Length; i++)
            {
                bs[i] = Convert.ToByte(chars[i]);
            }
            return bs;
        }
        #endregion //GetSimNumberBytes

        #region MakeDtuCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fc"></param>
        /// <param name="sim"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        static public byte[] MakeDtuCommand(byte fc, string sim, byte[] userData)
        {
            int userDataLen = userData != null ? userData.Length : 0;
            //if ( userData != null )
            //    userDataLen = userData.Length;
            byte[] cmd = new byte[SGDefine.MIN_PA_LEN + userDataLen];
            System.IO.MemoryStream ms = new System.IO.MemoryStream(cmd);
            ms.WriteByte(SGDefine.HEAD_VALUE);
            ms.WriteByte(fc);
            ms.Write(GetDtuLengthBytes(userDataLen + SGDefine.MIN_PA_LEN), 0, 2);

            byte[] simbs = SGDtu.GetSimNumberBytes(sim);
            ms.Write(simbs, 0, simbs.Length);

            if (userData != null && userData.Length > 0)
                ms.Write(userData, 0, userData.Length);
            ms.WriteByte(SGDefine.TAIL_VALUE);

            //return ms.GetBuffer();
            return ms.ToArray();
            //return (byte[])ms;

        }
        #endregion //MakeDtuCommand

        #region GetDtuLengthBytes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        static private byte[] GetDtuLengthBytes(int length)
        {
            byte[] bs = new byte[2];
            bs[0] = (byte)(length / 0x100);
            bs[1] = (byte)(length % 0x100);
            return bs;
        }
        #endregion //GetDtuLengthBytes

        #region GetDtuPackageLen
        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedData"></param>
        /// <param name="beginIndex"></param>
        /// <returns></returns>
        static private int GetDtuPackageLen(byte[] receivedData, int beginIndex)
        {
            int b = beginIndex + SGDefine.PACKAGE_LEN.BeginPostion;
            int e = b + SGDefine.PACKAGE_LEN.DataLength;
            string s = string.Empty;
            for (int i = b; i < e; i++)
            {
                s += receivedData[i].ToString("X2");
            }

            return Convert.ToInt32(s, 16);
        }
        #endregion //GetDtuPackageLen

        #region IsCorrectPackageType
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        static private bool IsCorrectPackageType(byte b)
        {
            return b == SGDefine.PAT_HEARTBEAT ||
                b == SGDefine.PAT_USERDATA ||
                b == SGDefine.PAT_REGISTER;
        }
        #endregion //IsCorrectPackageType

        #region HDBytesWrap
        /// <summary>
        /// 发送指令处理
        /// </summary>
        /// <param name="order"></param>
        /// <param name="sim"></param>
        /// <returns></returns>
        static public byte[] HDBytesWrap(byte[] source, string sim)
        {
            if (!Config.Default.IsUseHDProtocol)
            {
                return source;
            }

            byte[] outbyte = new byte[source.Length + 16];
            int Len = 16 + source.Length;
            outbyte[0] = 0x7B;
            outbyte[1] = 0x89;
            outbyte[2] = (byte)((int)(Len / 256));
            outbyte[3] = (byte)((int)(Len % 256));
            for (int i = 0; i < 11; i++)//4__14
            {
                outbyte[i + 4] = Convert.ToByte(Convert.ToChar(sim.Substring(i, 1)));
            }
            for (int i = 0; i < source.Length; i++)
            {
                outbyte[i + 15] = source[i];
            }
            outbyte[15 + source.Length] = 0x7B;
            return outbyte;
        }
        #endregion //HDBytesWrap
    }


}
