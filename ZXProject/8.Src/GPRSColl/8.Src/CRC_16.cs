using System;

namespace GprsSystem
{
	/// <summary>
	/// CRC_16 的摘要说明。
	/// </summary>
	public class CRC_16
	{
		/// <summary>
		/// 进行CRC16校验
		/// </summary>
		public byte[] CRC16(Byte[] data) 
		{
			byte CRC16Lo=0xff,CRC16Hi=0xff;
			byte CL=0x1,CH=0xA0;
			byte SaveHi,SaveLo;
			for(int i=0;i<data.Length;i++)
			{
				CRC16Lo^=data[i];
				for (int Flag=0;Flag<8;Flag++)
				{
					SaveHi = CRC16Hi;
					SaveLo = CRC16Lo;
					CRC16Hi>>=1;  
					CRC16Lo>>=1;
					if((SaveHi & 0x01)==0x01)
					{
						CRC16Lo|=0x80;
					}
					if((SaveLo & 0x1)==0x1)
					{
						CRC16Hi^=CH;
						CRC16Lo^=CL;
					}
				}
			}
			byte[] ReturnData=new byte[2];
			ReturnData[0] = CRC16Lo; 
			ReturnData[1] = CRC16Hi;
			return ReturnData;
		}
	}
}
