using System;
using GprsSystem;

namespace PumpDriver
{

    /// <summary>
    /// Pump_Send 的摘要说明。
    /// </summary>
    public class PumpCommandMaker
    {
        //定义辅助字节
        private byte[] crc=new byte[2];
        CRC_16 CRC=new CRC_16();

        #region MakeReadLastRecordCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public byte[] MakeReadLastRecordCommand(int address)
        {
            return MakeCommandHelp(address, PumpDefine.FCDefine.FC_READREAL);
        }
        #endregion //MakeReadLastRecordCommand

        #region MakeCommandHelp
        /// <summary>
        /// 发送0个参数0字节泵站命令
        /// 
        /// 0x00启泵
        /// 0x01停泵
        /// 0x0D清除水量运行记录
        /// 0x0E清除打卡记录
        /// 0x0F清除水量总水量
        /// 0x10清除已用时间
        /// 0x12读取泵站当前状态
        /// 0x13读取剩余水量
        /// 0x14读取总水量
        /// 0x15读取已用水量
        /// 0x16读取流量
        /// 0x17读取效率
        /// 0x19读取泵站强启状态
        /// 0x1A读取实时数据
        /// 0x1B读取振动传感器状态
        /// 0x1C读取总用水记录条数
        /// 0x1D读取最后一条用水记录的位置
        /// 0x1E读取管理卡密码
        /// 0x1F读取启亭卡密码
        /// 0x20读取数据卡密码
        /// 0x27读取泵站最后一次动作时的记录资料
        /// 0x29读取总打卡记录条数
        /// 0x2A读取最后一条打卡记录的位置
        /// 0x2C读取供电状态
        /// 0x2E读取接触器状态
        /// </summary>
        public byte[] MakeCommandHelp(int ComAdr,byte function)
        {
            byte[] outByte=new byte[9];
            byte[] outByteVal=new byte[7];

            outByte[0] = 0x21;
            outByteVal[0] =outByte[0];
            outByte[1] = 0x58;
            outByteVal[1] = outByte[1];
            outByte[2] = 0x44;
            outByteVal[2] = outByte[2];
            outByte[3] = (byte)ComAdr;
            outByteVal[3] = outByte[3];
            //outByte[4] = 0xA1;
            outByte[4] = PumpDefine.DEV_TYPE.FirstByte;
            outByteVal[4] = outByte[4];
            outByte[5] =function;
            outByteVal[5] = outByte[5];
            outByte[6] = 0x0;
            outByteVal[6] = outByte[6];
            //**************************
            crc=CRC.CRC16(outByteVal);
            outByte[7] = crc[0];
            outByte[8] = crc[1];
            return outByte;
        }
        #endregion //MakeCommandHelp

        #region Send_oP_oB
        /// <summary>
        /// 发送1个参数1字节泵站命令
        /// 
        /// 0x08设置效率
        /// 0x09设置站号
        /// 0x0A设置振动传感器阻尼时间
        /// 0x18设置强启状态
        /// 0x28读取打卡记录
        /// </summary>
        public byte[] Send_oP_oB(int ComAdr,int uPar,byte function)
        {
            byte[] outByte=new byte[10];
            byte[] outByteVal=new byte[8];

            outByte[0] = 0x21;
            outByteVal[0] =outByte[0];
            outByte[1] = 0x58;
            outByteVal[1] = outByte[1];
            outByte[2] = 0x44;
            outByteVal[2] = outByte[2];
            outByte[3] = (byte)ComAdr;
            outByteVal[3] = outByte[3];
            //outByte[4] = 0xA1;
            outByte[4] = PumpDefine.DEV_TYPE.FirstByte;
            outByteVal[4] = outByte[4];
            outByte[5] = function;
            outByteVal[5] = outByte[5];
            outByte[6] = 0x1;
            outByteVal[6] = outByte[6];

            outByte[7] = (byte)uPar;
            outByteVal[7] = outByte[7];
            //**************************
            crc=CRC.CRC16(outByteVal);
            outByte[8] = crc[0];
            outByte[9] = crc[1];
            return outByte;
        }
        #endregion //Send_oP_oB

    }
}
