using System;
using GprsSystem;

namespace GateDriver
{
	/// <summary>
	/// ���Ϳ�������
	/// </summary>
	public class GateCommandMaker
	{
		//���帨���ֽ�
		private byte[] crc=new byte[2];
		CRC_16 CRC=new CRC_16();


        #region MakeRecordCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comAdr"></param>
        /// <param name="recordIdx"></param>
        /// <returns></returns>
        public byte[] MakeRecordCmd( int comAdr, int recordIdx )
        {
			byte[] outByte=new byte[10];
			byte[] outByteVal=new byte[8];

			outByte[0] = 0x40;
			outByteVal[0] = outByte[0];
			outByte[1] = 0x58;
			outByteVal[1] = outByte[1];
			outByte[2] = 0x44;
			outByteVal[2] = outByte[2];
			outByte[3] = (byte)comAdr;
			outByteVal[3] = outByte[3];
			outByte[4] = 0x0B;
			outByteVal[4] = outByte[4];
			outByte[5] = 0x25;
			outByteVal[5] = outByte[5];
			outByte[6] = 0x09;
			outByteVal[6] = outByte[6];
            outByte[7] = (byte) recordIdx;
            outByteVal[7] = outByte[7];
			//**************************
			crc=CRC.CRC16(outByteVal);
			outByte[8] = crc[0];
			outByte[9] = crc[1];
			return outByte;
        }
        #endregion //MakeRecordCmd

		#region Send_zP_zB
		/// <summary>
		/// ����0������0�ֽڿ�������
		/// 
		/// 0x21�����ˮ��
		/// 0x23�ϴ�����
		/// 0x24ʵʱ����
		/// 0x26�����ʷ��¼
		/// 0x27�ϴ����ݿ���
		/// 0x2Dǿ�ƿ�������
		/// 0x2Eǿ�ƹ�������
		/// 0x2F��������������
		/// 0x3C�ϴ����һ�μ�¼����
		/// </summary>
		public byte[] Send_zP_zB(int ComAdr,byte function)
		{
			byte[] outByte=new byte[9];
			byte[] outByteVal=new byte[7];

			outByte[0] = 0x40;
			outByteVal[0] = outByte[0];
			outByte[1] = 0x58;
			outByteVal[1] = outByte[1];
			outByte[2] = 0x44;
			outByteVal[2] = outByte[2];
			outByte[3] = (byte)ComAdr;
			outByteVal[3] = outByte[3];
			outByte[4] = 0x0B;
			outByteVal[4] = outByte[4];
			outByte[5] = function;
			outByteVal[5] = outByte[5];
			outByte[6] = 0x09;
			outByteVal[6] = outByte[6];
			//**************************
			crc=CRC.CRC16(outByteVal);
			outByte[7] = crc[0];
			outByte[8] = crc[1];
			return outByte;
		}
		#endregion //Send_zP_zB

		#region Send_oP_oB
		/// <summary>
		/// ����1������1�ֽڿ�������
		/// 
		/// 0x37�ϴ�����ˮ����¼
		/// </summary>
		public byte[] Send_oP_oB(int ComAdr,int uPar,byte function)
		{
			byte[] outByte=new byte[10];
			byte[] outByteVal=new byte[8];

			outByte[0] = 0x40;
			outByteVal[0] =outByte[0];
			outByte[1] = 0x58;
			outByteVal[1] = outByte[1];
			outByte[2] = 0x44;
			outByteVal[2] = outByte[2];
			outByte[3] = (byte)ComAdr;
			outByteVal[3] = outByte[3];
			outByte[4] = 0x0B;
			outByteVal[4] = outByte[4];
			outByte[5] =function;
			outByteVal[5] = outByte[5];
			outByte[6] = 0x0A;
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

		#region Send_oP_tB
		/// <summary>
		/// ����1������2�ֽڿ�������
		/// 
		/// 0x17�޸�բ��
		/// 0x18�޸�բ�׸߳�
		/// 0x1A�޸�բǰˮλ����
		/// 0x1B�޸�բ��ˮλ����
		/// 0x1C�޸�բǰˮ��
		/// 0x1D�޸�բ��ˮ��
		/// 0x25�ϴ���¼
		/// </summary>
		public byte[] Send_oP_tB(int ComAdr,int uPar,byte function)
		{
			byte[] outByte=new byte[11];
			byte[] outByteVal=new byte[9];

			outByte[0] = 0x40;
			outByteVal[0] =outByte[0];
			outByte[1] = 0x58;
			outByteVal[1] = outByte[1];
			outByte[2] = 0x44;
			outByteVal[2] = outByte[2];
			outByte[3] = (byte)ComAdr;
			outByteVal[3] = outByte[3];
			outByte[4] = 0x0B;
			outByteVal[4] = outByte[4];
			outByte[5] = function;
			outByteVal[5] = outByte[5];
			outByte[6] = 0x0B;
			outByteVal[6] = outByte[6];

			outByte[7] = (byte)((int)(uPar/256));
			outByteVal[7] = outByte[7];
			outByte[8] = (byte)((int)(uPar%256));
			outByteVal[8] = outByte[8];
			//**************************
			crc=CRC.CRC16(outByteVal);
			outByte[9] = crc[0];
			outByte[10] = crc[1];
			return outByte;
		}	
		#endregion //Send_oP_tB

		#region Send_tP_tB
		/// <summary>
		/// ����2������2�ֽڿ�������
		/// 
		/// 0x16�޸Ĵӻ�վ�Ų�����
		/// 0x19�޸�����ϵ��
		/// </summary>
		public byte[] Send_tP_tB(int ComAdr,int uPar0,int uPar1,byte function)
		{
			byte[] outByte=new byte[11];
			byte[] outByteVal=new byte[9];

			outByte[0] = 0x40;
			outByteVal[0] =outByte[0];
			outByte[1] = 0x58;
			outByteVal[1] = outByte[1];
			outByte[2] = 0x44;
			outByteVal[2] = outByte[2];
			outByte[3] = (byte)ComAdr;
			outByteVal[3] = outByte[3];
			outByte[4] = 0x0B;
			outByteVal[4] = outByte[4];
			outByte[5] = function;
			outByteVal[5] = outByte[5];
			outByte[6] = 0x0B;
			outByteVal[6] = outByte[6];

			outByte[7] = (byte)uPar0;
			outByteVal[7] = outByte[7];
			outByte[8] = (byte)uPar1;
			outByteVal[8] = outByte[8];
			//**************************
			crc=CRC.CRC16(outByteVal);
			outByte[9] = crc[0];
			outByte[10] = crc[1];
			return outByte;
		}	
		#endregion //Send_tP_tB

		#region Input_Water
		/// <summary>
		/// ����ˮ������
		/// </summary>
		public byte[] Input_Water(int ComAdr,long Water)
		{
			byte[] outByte=new byte[13];
			byte[] outByteVal=new byte[11];
			string str=Water.ToString("x8");

			outByte[0] = 0x40;
			outByteVal[0] =outByte[0];
			outByte[1] = 0x58;
			outByteVal[1] = outByte[1];
			outByte[2] = 0x44;
			outByteVal[2] = outByte[2];
			outByte[3] = (byte)ComAdr;
			outByteVal[3] = outByte[3];
			outByte[4] = 0x0B;
			outByteVal[4] = outByte[4];
			outByte[5] = 0x20;
			outByteVal[5] = outByte[5];
			outByte[6] = 0x0D;
			outByteVal[6] = outByte[6];

			outByte[7] = Convert.ToByte("0x"+str.Substring(0,2),16);
			outByteVal[7] = outByte[7];
			outByte[8] = Convert.ToByte("0x"+str.Substring(2,2),16);
			outByteVal[8] = outByte[8];
			outByte[9] = Convert.ToByte("0x"+str.Substring(4,2),16);
			outByteVal[9] = outByte[9];
			outByte[10] = Convert.ToByte("0x"+str.Substring(6,2),16);
			outByteVal[10] = outByte[10];
			//**************************
			crc=CRC.CRC16(outByteVal);
			outByte[11] = crc[0];
			outByte[12] = crc[1];
			return outByte;
		}
		#endregion //Input_Water

		#region Set_Tm
		/// <summary>
		/// 0x22�������ݿ�
		/// </summary>
		public byte[] Set_Tm(int ComAdr,string Tm)
		{
			byte[] outByte=new byte[17];
			byte[] outByteVal=new byte[15];

			outByte[0] = 0x40;
			outByteVal[0] =outByte[0];
			outByte[1] = 0x58;
			outByteVal[1] = outByte[1];
			outByte[2] = 0x44;
			outByteVal[2] = outByte[2];
			outByte[3] = (byte)ComAdr;
			outByteVal[3] = outByte[3];
			outByte[4] = 0x0B;
			outByteVal[4] = outByte[4];
			outByte[5] = 0x22;
			outByteVal[5] = outByte[5];
			outByte[6] = 0x11;
			outByteVal[6] = outByte[6];

			outByte[7] = Convert.ToByte("0x"+Tm.Substring(0,2),16);
			outByteVal[7] = outByte[7];
			outByte[8] = Convert.ToByte("0x"+Tm.Substring(2,2),16);
			outByteVal[8] = outByte[8];
			outByte[9] = Convert.ToByte("0x"+Tm.Substring(4,2),16);
			outByteVal[9] = outByte[9];
			outByte[10] = Convert.ToByte("0x"+Tm.Substring(6,2),16);
			outByteVal[10] = outByte[10];
			outByte[11] = Convert.ToByte("0x"+Tm.Substring(8,2),16);
			outByteVal[11] = outByte[11];
			outByte[12] = Convert.ToByte("0x"+Tm.Substring(10,2),16);
			outByteVal[12] = outByte[12];
			outByte[13] = Convert.ToByte("0x"+Tm.Substring(12,2),16);
			outByteVal[13] = outByte[13];
			outByte[14] = Convert.ToByte("0x"+Tm.Substring(14,2),16);
			outByteVal[14] = outByte[14];
			//**************************
			crc=CRC.CRC16(outByteVal);
			outByte[15] = crc[0];
			outByte[16] = crc[1];
			return outByte;
		}
		#endregion //Set_Tm

		#region Update_Date
		/// <summary>
		/// �޸�������
		/// </summary>
		public byte[] Update_Date(int ComAdr,int Yy,int Mm,int Dd)
		{
			byte[] outByte=new byte[12];
			byte[] outByteVal=new byte[10];

			outByte[0] = 0x40;
			outByteVal[0] =outByte[0];
			outByte[1] = 0x58;
			outByteVal[1] = outByte[1];
			outByte[2] = 0x44;
			outByteVal[2] = outByte[2];
			outByte[3] = (byte)ComAdr;
			outByteVal[3] = outByte[3];
			outByte[4] = 0x0B;
			outByteVal[4] = outByte[4];
			outByte[5] = 0x1E;
			outByteVal[5] = outByte[5];
			outByte[6] = 0x0C;
			outByteVal[6] = outByte[6];
			outByte[7] = (byte)Yy;
			outByteVal[7] = outByte[7];
			outByte[8] = (byte)Mm;
			outByteVal[8] = outByte[8];
			outByte[9] = (byte)Dd;
			outByteVal[9] = outByte[9];
			//**************************
			crc=CRC.CRC16(outByteVal);
			outByte[10] = crc[0];
			outByte[11] = crc[1];
			return outByte;
		}
		#endregion //Update_Date

		#region Update_Time
		/// <summary>
		/// //�޸�ʱ����
		/// </summary>
		public byte[] Update_Time(int ComAdr,int Hh,int Mm,int Ss)
		{
			byte[] outByte=new byte[12];
			byte[] outByteVal=new byte[10];

			outByte[0] = 0x40;
			outByteVal[0] =outByte[0];
			outByte[1] = 0x58;
			outByteVal[1] = outByte[1];
			outByte[2] = 0x44;
			outByteVal[2] = outByte[2];
			outByte[3] = (byte)ComAdr;
			outByteVal[3] = outByte[3];
			outByte[4] = 0x0B;
			outByteVal[4] = outByte[4];
			outByte[5] = 0x1F;
			outByteVal[5] = outByte[5];
			outByte[6] = 0x0C;
			outByteVal[6] = outByte[6];
			outByte[7] = (byte)Hh;
			outByteVal[7] = outByte[7];
			outByte[8] = (byte)Mm;
			outByteVal[8] = outByte[8];
			outByte[9] = (byte)Ss;
			outByteVal[9] = outByte[9];
			//**************************
			crc=CRC.CRC16(outByteVal);
			outByte[10] = crc[0];
			outByte[11] = crc[1];
			return outByte;
		}
		#endregion //Update_Time
	}
}
