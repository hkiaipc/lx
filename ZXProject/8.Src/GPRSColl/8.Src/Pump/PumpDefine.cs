using System;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class PumpDefine
    {
        // -----------------------------------------------------------------------------
        // 定义:  起始字符 握手字节 设备地址 设备类型 功能代码 数据个数 数据字节 CRC校验
        // 长度:  1        2         1       1        1        1        n        2   
        // 数值:  !        XD        .       0xA1     .        .        .        .   
        // -----------------------------------------------------------------------------
        // 数据个数 = n

        public const int MIN_LEN = 9;
        static public readonly DataField HEAD           = new DataField( 0, 3, new byte[] {0x21, 0x58, 0x44} );
        static public readonly DataField DEV_ADDRESS    = new DataField( 3, 1 );
        //static public readonly DataField DEV_TYPE       = new DataField( 4, 1, new byte[] {0xA1} );
        static public readonly DataField DEV_TYPE = new DataField(4, 1, new byte[] { 0x80 });
        static public readonly DataField FC             = new DataField( 5, 1 );
        static public readonly DataField DATALEN        = new DataField( 6, 1 );
        static public readonly DataField INNERDATA      = new DataField( 7, DataField.UNSURENESS );
        static public readonly DataField CRCCODE        = new DataField( DataField.UNSURENESS, 2 );


        /// <summary>
        /// 
        /// </summary>
        public class FCDefine
        {
            /// <summary>
            /// 读取泵站实时状态(为与老泵站协议相结合)
            /// </summary>
            public const byte FC_READREAL = 0x1A;
            public const byte FC_Force_START_STOP = 0x3A;
        }

        /// <summary>
        /// 强制起停泵数值
        /// </summary>
        public class ForceStartStopValue
        {
            /// <summary>
            /// 
            /// </summary>
            public const byte Stop = 0x00;
            /// <summary>
            /// 
            /// </summary>
            public const byte Start = 0x01;
        }
    }

}
