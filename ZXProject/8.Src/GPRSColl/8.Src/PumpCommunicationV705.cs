using System;
using Utilities;

namespace GprsSystem
{
//    /// <summary>
//    /// 泵站通讯 Version7.05 相关
//    /// </summary>
//    public class PumpCommunicationV705
//    {

//        private const int DEVIVE_TYPE = 0x12;
//        private const int INNER_DATA_BEGIN_POS = 7;
//        private const int ZERO_DATA_CMD_LENGTH = 9;
//        private const int ZERO_DATA_RECEIVED_LENGTH = 9;
//        private const int FUNCTION_CODE_POS = 5;


//        public PumpCommunicationV705()
//        {
//        }

//        public static byte[] MakeCommand(int address, int deviceType, int functionCode, byte[] datas)
//        {
//            int datasLength = (datas == null ? 0 : datas.Length) ;
//            int length = ZERO_DATA_CMD_LENGTH + datasLength; 

//            byte[] r = new byte[length];
//            r[0] = 0x21;            //!
//            r[1] = 0x58;            //X
//            r[2] = 0x44;            //D
//            r[3] = (byte)address;
//            r[4] = (byte)deviceType;
//            r[5] = (byte)functionCode;
//            r[6] = (byte)datasLength;

//            for (int i=0; i<datasLength; i++)
//            {
//                r[ INNER_DATA_BEGIN_POS + i ] = datas[i];
//            }
//            byte hi, lo;
//            Utilities.CRC16.CalculateCRC(r, length - 2, out hi, out lo );
            
//            r[length - 2] = lo;
//            r[length - 1] = hi;

//            return r;
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="commAddress"></param>
//        /// <returns></returns>
//        public static byte[] MakeReadCurrentRecordNoCmd(int commAddress )
//        {
//            return MakeCommand( commAddress, DEVIVE_TYPE, 0x51, new byte[] {0} );
//        }



//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="commAddress"></param>
//        /// <returns></returns>
//        public static byte[] MakeReadRunStateCmd( int commAddress )
//        {
//            return MakeCommand( commAddress, DEVIVE_TYPE, 0x41, new byte[] {0} );
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="commAddress"></param>
//        /// <returns></returns>
//        public static byte[] MakeReadRemainWaterCmd( int commAddress )
//        {
//            return MakeCommand( commAddress, DEVIVE_TYPE, 0x42, new byte[] {0} );
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="commAddress"></param>
//        /// <returns></returns>
//        public static byte[] MakeReadFluxEfficeCmd ( int commAddress )
//        {
//            return MakeCommand( commAddress, DEVIVE_TYPE, 0x25, new byte[] {0} );
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="commAddress"></param>
//        /// <returns></returns>
//        public static byte[] MakeReadUsedWaterCmd( int commAddress )
//        {
//            return MakeCommand( commAddress, DEVIVE_TYPE, 0x43, new byte[] {0} );
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="commAddress"></param>
//        /// <param name="recordNo"></param>
//        /// <returns></returns>
//        public static byte[] MakeReadHistoryRecordCmd( int commAddress, int recordNo )
//        {
//            return MakeCommand( commAddress, DEVIVE_TYPE, 0x50, new byte[] { (byte)recordNo } );
//        }

//        private static readonly string[] _errors = new string[] {
//                                           "SUCCESS",
//                                           "LENGTH_ERROR",    
//                                           "DATA_ERROR",
//                                           "DEV_TYPE_ERROR",
//                                           "CRC_ERROR",
//                                           "UNKNOWN"
//                                       };

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="checkReceivedResult"></param>
//        /// <returns></returns>
//        public static string GetErrorText( int checkReceivedResult )
//        {

//            int old = checkReceivedResult;
//            if ( checkReceivedResult >= _errors.Length )
//                checkReceivedResult = _errors.Length - 1;
//            return _errors[ checkReceivedResult ] + " " + old;
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetRunState( byte[] datas )
//        {
//            return datas[ 7 ];
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetPowerState( byte[] datas )
//        {
//            //return datas[ 9 ];
//            byte b = datas[ 9 ];
//            return GetBit( b, 0 );

//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="b"></param>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        private static int GetBit( byte b, int index )
//        {
//            // index - base 0, [0 , 7]
//            System.Diagnostics.Debug.Assert( index >=0 && index <= 7 );
//            byte mask = (byte)Math.Pow(2, index );
//            if ( (b & mask )> 0 )
//                return 1;
//            else
//                return 0;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetVibrateState( byte[] datas )
//        {
////            return datas[ 10 ];
//            byte b = datas[ 9 ];
//            return GetBit( b, 7 );
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetForceState( byte[] datas )
//        {
////            return datas[ 11 ];
//            byte b = datas[ 9 ];
//            return GetBit( b, 6 );
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="state"></param>
//        /// <returns></returns>
//        public static string GetForceStateText( int state )
//        {
//            switch( state )
//            {
//                case 0x01: 
//                    return "允许强启";
//                case 0x00:
//                    return "禁止强启";
//                default:
//                    return "未知(0x" + state.ToString("X2") + ")";
//            }  
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="state"></param>
//        /// <returns></returns>
//        public static string GetVibrateStateText( int state )
//        {
//            switch( state )
//            {
//                case 0x01: 
//                    return "振动状态";
//                case 0x00:
//                    return "无振状态";
//                default:
//                    return "未知(0x" + state.ToString("X2") + ")";
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="state"></param>
//        /// <returns></returns>
//        public static string GetPowerStateText( int state )
//        {
//            switch( state )
//            {
//                case 0x01: 
//                    return "电池状态";
//                case 0x00:
//                    return "市电状态";
//                default:
//                    return "未知(0x" + state.ToString("X2") + ")";
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="runState"></param>
//        /// <returns></returns>
//        public static string GetRunStateText( int runState )
//        {
//            switch( runState )
//            {
//                case 0x80: 
//                    return "运行状态";
//                case 0x00:
//                    return "无运行状态";
//                default:
//                    return "未知(0x" + runState.ToString("X2") + ")";
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetRemainWater( byte[] datas )
//        {
////            for ( int i=7; i<7+4; i++ ) // 7 8 9 10
//            byte[] bs = new byte[4];
//            int idx = 0;
//            for ( int i=10; i>=7; i-- )
//            {
//                bs[idx++] = datas[i];
//            }

//            return BitConverter.ToInt32( bs, 0 );
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetFlux( byte[] datas )
//        {
//            byte[] bs = new byte[2];
//            int idx = 0;
//            for ( int i=8; i>=7; i-- )
//            {
//                bs[idx++] = datas[i];
//            }

//            return BitConverter.ToInt16( bs, 0 );
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetEffice( byte[] datas )
//        {
//            byte b = datas[9];
//            return b;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetUsedWater( byte[] datas )
//        {
//            byte[] bs = new byte[4];
//            int idx = 0;
//            for ( int i=10; i>=7; i-- )
//            {
//                bs[idx++] = datas[i];
//            }

//            return BitConverter.ToInt32( bs, 0 );
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns>0 - success</returns>
//        public static int CheckReceived( byte[] datas )
//        {
//            if ( datas == null || datas.Length < ZERO_DATA_RECEIVED_LENGTH )
//                return 1;   // length error

//            bool b =    datas[ 0 ] == 0x21 &&
//                        datas[ 1 ] == 0x58 &&
//                        datas[ 2 ] == 0x44;

//            if ( !b )
//                return 2; // data error

//            if ( datas[ 4 ] != 0x12 )
//            {
//                return 3; // command data type error
//            }

//            byte hi, lo;
//            CRC16.CalculateCRC( datas, datas.Length - 2, out hi, out lo );
//            if (!( datas[ datas.Length - 1 ] == hi &&
//                datas[ datas.Length - 2 ] == lo ))
//            {
//                return 4; // crc error
//            }

//            return 0; // success
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetFC( byte[] datas )
//        {
//            return datas[ FUNCTION_CODE_POS ];
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetAddress( byte[] datas )
//        {
//            return datas[ 3 ];
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static int GetInnerdatalen( byte[] datas )
//        {
//            return datas[ 6 ];
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static HistoryRecord  GetHistoryRecord( byte[] datas )
//        {
//            return HistoryRecord.Parse( datas );
//        }
         
   
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="datas"></param>
//        /// <returns></returns>
//        public static RecordNo GetCurrentRecordNo( byte[] datas )
//        {
//            return RecordNo.Parse( datas );

//        }
//    }


    /// <summary>
    /// 
    /// </summary>
    public class RecordNo
    {
        private int _currentHistoryRecordNo;
        private int _currentPoweroffRecordNo;
        private int _currentVibratoRecordNo;
        private int _fromAddress;
            
        private RecordNo()
        {
        }

        public int FromAddres
        {
            get { return _fromAddress; }
        }

        public int CurrentHistoryRecordNo
        {
            get { return _currentHistoryRecordNo; }
        }

        public int CurrentPoweroffRecordNo
        {
            get { return _currentPoweroffRecordNo; }
        }

        public int CurrentVibratoRecordNo
        {
            get { return _currentVibratoRecordNo; }
        }

        private const int ADDRESS_POS = 3;
        private const int CURRENT_HISTORY_RECORDNO_POS  = 7;
        private const int CURRENT_POWEROFF_RECORDNO_POS = 8;
        private const int CURRENT_VIBRATO_RECORDNO_POS  = 9;

        public static RecordNo Parse(byte[] datas)
        {
            RecordNo r = new RecordNo();
            r._fromAddress = datas[ ADDRESS_POS ];
            r._currentHistoryRecordNo  = BCDConvert.BCDToDec( datas[ CURRENT_HISTORY_RECORDNO_POS ] );
            r._currentPoweroffRecordNo = BCDConvert.BCDToDec( datas[ CURRENT_POWEROFF_RECORDNO_POS ] );
            r._currentVibratoRecordNo  = BCDConvert.BCDToDec( datas[ CURRENT_VIBRATO_RECORDNO_POS ] );
            return r;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class HistoryRecord
    {
        //private int _recordNO;
        private int _fromAddress;
        private DateTime _beginDateTime;
        private DateTime _endDatetTiem;
        private int _usedWaterQuantity;

        private const int BEGIN_DATETIME_BEGIN_POS = 7;
        private const int END_DATETIME_BEGIN_POS = 12;
        private const int USED_WATER_QUANTITY_BEGIN_POS = 17;
        private const int ADDRESS_POS = 3;


        private HistoryRecord() 
        {
        }

        //public int RecordNo
        //{
        //    get { return _recordNO; }
        //}

        public int FromAddress
        {
            get { return _fromAddress; }
        }

        public DateTime BeginDateTime
        {
            get { return _beginDateTime; } 
        }

        public DateTime EndDateTime
        {
            get { return _endDatetTiem; }
        }

        public int UsedWaterQuantity
        {
            get { return _usedWaterQuantity; } 
        }

        static public HistoryRecord Parse( byte[] datas )
        {
            HistoryRecord r = new HistoryRecord();

            r._fromAddress = datas[ ADDRESS_POS ];

            r._beginDateTime = new DateTime(
                BCDConvert.BCDToDec ( datas[ BEGIN_DATETIME_BEGIN_POS + 0 ] ) + 2000,
                BCDConvert.BCDToDec ( datas[ BEGIN_DATETIME_BEGIN_POS + 1 ] ),
                BCDConvert.BCDToDec ( datas[ BEGIN_DATETIME_BEGIN_POS + 2 ] ),
                BCDConvert.BCDToDec ( datas[ BEGIN_DATETIME_BEGIN_POS + 3 ] ),
                BCDConvert.BCDToDec ( datas[ BEGIN_DATETIME_BEGIN_POS + 4 ] ),
                0 );

            r._endDatetTiem = new DateTime(
                BCDConvert.BCDToDec ( datas[ END_DATETIME_BEGIN_POS + 0 ] ) + 2000,
                BCDConvert.BCDToDec ( datas[ END_DATETIME_BEGIN_POS + 1 ] ),
                BCDConvert.BCDToDec ( datas[ END_DATETIME_BEGIN_POS + 2 ] ),
                BCDConvert.BCDToDec ( datas[ END_DATETIME_BEGIN_POS + 3 ] ),
                BCDConvert.BCDToDec ( datas[ END_DATETIME_BEGIN_POS + 4 ] ),
                0 );

            // 获取用水量
            //
            // 如：byte[] {0x00 0x01 0xE2 0x40} 表示 123456，
            // 使用的是高位在前低位在后，将其转换为低位在前高位在后形式，
            // 再使用BitConvert进行转换
            // 
            byte[] usedWQ = new byte[4];
            Array.Copy( datas, USED_WATER_QUANTITY_BEGIN_POS, usedWQ, 0, 4 );
            Array.Reverse( usedWQ );

            r._usedWaterQuantity = BitConverter.ToInt32(datas, USED_WATER_QUANTITY_BEGIN_POS );

            return r;
        }
    }
}
