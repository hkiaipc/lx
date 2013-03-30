using System;
using GprsSystem;

namespace PumpDriver
{

    /// <summary>
    /// Pump_Send ��ժҪ˵����
    /// </summary>
    public class PumpCommandMaker
    {
        //���帨���ֽ�
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
        /// ����0������0�ֽڱ�վ����
        /// 
        /// 0x00����
        /// 0x01ͣ��
        /// 0x0D���ˮ�����м�¼
        /// 0x0E����򿨼�¼
        /// 0x0F���ˮ����ˮ��
        /// 0x10�������ʱ��
        /// 0x12��ȡ��վ��ǰ״̬
        /// 0x13��ȡʣ��ˮ��
        /// 0x14��ȡ��ˮ��
        /// 0x15��ȡ����ˮ��
        /// 0x16��ȡ����
        /// 0x17��ȡЧ��
        /// 0x19��ȡ��վǿ��״̬
        /// 0x1A��ȡʵʱ����
        /// 0x1B��ȡ�񶯴�����״̬
        /// 0x1C��ȡ����ˮ��¼����
        /// 0x1D��ȡ���һ����ˮ��¼��λ��
        /// 0x1E��ȡ��������
        /// 0x1F��ȡ��ͤ������
        /// 0x20��ȡ���ݿ�����
        /// 0x27��ȡ��վ���һ�ζ���ʱ�ļ�¼����
        /// 0x29��ȡ�ܴ򿨼�¼����
        /// 0x2A��ȡ���һ���򿨼�¼��λ��
        /// 0x2C��ȡ����״̬
        /// 0x2E��ȡ�Ӵ���״̬
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
        /// ����1������1�ֽڱ�վ����
        /// 
        /// 0x08����Ч��
        /// 0x09����վ��
        /// 0x0A�����񶯴���������ʱ��
        /// 0x18����ǿ��״̬
        /// 0x28��ȡ�򿨼�¼
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
