using System;


namespace Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class CRC16
    {

        #region CRC16
        /// <summary>
        /// 
        /// </summary>
        private CRC16()
        {
        }
        #endregion //CRC16

        #region CalculateCRC
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pByte"></param>
        /// <param name="nNumberOfBytes"></param>
        /// <param name="pChecksum"></param>
        public static void CalculateCRC(byte [] pByte, int nNumberOfBytes, out ushort pChecksum)
        {
            int nBit;
            ushort nShiftedBit;
            pChecksum = 0xFFFF;

            for (int nByte = 0; nByte < nNumberOfBytes; nByte++)
            {
                pChecksum ^= pByte[nByte];

                for (nBit = 0; nBit < 8; nBit++)
                {
                    if((pChecksum & 0x1) == 1)
                    {
                        nShiftedBit = 1;
                    }
                    else
                    {
                        nShiftedBit = 0;
                    }

                    pChecksum >>= 1;
                    if(nShiftedBit != 0)
                    {
                        pChecksum ^= 0xA001;
                    }
                }
            }
        }
        #endregion //CalculateCRC

        #region CalculateCRC
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pByte"></param>
        /// <param name="nNumberOfBytes"></param>
        /// <param name="hi"></param>
        /// <param name="lo"></param>
        public static void CalculateCRC( byte[] pByte, int nNumberOfBytes, out byte hi, out byte lo)
        {
            ushort sum;
            CRC16.CalculateCRC( pByte, nNumberOfBytes, out sum );
            lo = (byte) (sum & 0xFF);
            hi = (byte) ( (sum & 0xFF00) >> 8 );
        }
        #endregion //CalculateCRC
    }


    #region StringFormat
    /// <summary>
    /// 
    /// </summary>
    public enum StringFormat
    {
        Hex,
        Dec,
    }
    #endregion //StringFormat


    /// <summary>
    /// 
    /// </summary>
    public class CT
    {
        private static bool _isWithLength = true;

        #region IsWithLength
        /// <summary>
        /// 
        /// </summary>
        public static bool IsWithLength
        {
            get { return _isWithLength; }
            set {_isWithLength = true; }
        }
        #endregion //IsWithLength

        #region BytesToString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToString(byte[] bytes)
        {
            return BytesToString( bytes, "X2" );
        }
        #endregion //BytesToString

        #region BytesToString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string BytesToString( byte[] bytes, string format )
        {
            if ( bytes == null )
            {
                // 2007.02.15 Modify
                //
                //throw new ArgumentNullException("bytes");
                return string.Empty;
            }
            if ( bytes.Length == 0 )
                return string.Empty;

            //string s = string.Empty;
            string s = "[ " + bytes.Length + " ] ";
            for(int i=0; i<bytes.Length; i++)
            {
                s += bytes[i].ToString( format ) + ( ( i != bytes.Length - 1 ) ? " " : "" );
            }

            return s;
        }
        #endregion //BytesToString

        #region GetFromBase
        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        private static int GetFromBase( StringFormat format )
        {
            if ( format == StringFormat.Hex )
                return 16;
            else if ( format == StringFormat.Hex )
                return 10;
            else
                throw new ArgumentException( format.ToString() );
        }
        #endregion //GetFromBase

        #region StringToBytes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToBytes ( string str,  char[] split, StringFormat format )
        {
            string[] items = str.Split( split );
            if ( items == null || items.Length == 0 )
                return null;

            byte[] bs = new byte[ items.Length ];
            for( int i=0; i<items.Length; i++)
            {
                bs[i] = Convert.ToByte(items[i], GetFromBase( format ) );
            }

            return bs;
        }
        #endregion //StringToBytes
    }

    #region BCDConvert
    /// <summary>
    /// 
    /// </summary>
    public class BCDConvert
    {

        #region BCDConvert
        /// <summary>
        /// 
        /// </summary>
        private BCDConvert()
        {
        }
        #endregion //BCDConvert

        #region DecToBCD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public int DecToBCD( int value )
        {
            return Convert.ToInt32( value.ToString(), 16 );
        }
        #endregion //DecToBCD

        #region BCDToDec
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public int BCDToDec( int value )
        {
            return Convert.ToInt32( value.ToString("X"), 10 );
        }
        #endregion //BCDToDec
    }
    #endregion // BCDConvert
}
