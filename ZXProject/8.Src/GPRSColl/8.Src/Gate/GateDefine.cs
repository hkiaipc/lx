using System;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class GateDefine
    {
        // -----------------------------------------------------------------------------
        // 定义:  起始字符 握手字节 设备地址 设备类型 功能代码 数据个数 数据字节 CRC校验
        // 长度:  1        2         1       1        1        1        n        2   
        // 数值:  @        XD        .       0x0B     .        .        .        .   
        // -----------------------------------------------------------------------------
        // 数据个数 = n + 9

        public const int MIN_LEN = 9;
        static public readonly DataField HEAD           = new DataField( 0, 3, new byte[] {0x40, 0x58, 0x44} );
        static public readonly DataField DEV_ADDRESS    = new DataField( 3, 1 );
        static public readonly DataField DEV_TYPE       = new DataField( 4, 1, new byte[] {0x0B} );
        static public readonly DataField FC             = new DataField( 5, 1 );
        static public readonly DataField DATALEN        = new DataField( 6, 1 );
        static public readonly DataField INNERDATA      = new DataField( 7, DataField.UNSURENESS );
        static public readonly DataField CRCCODE        = new DataField( DataField.UNSURENESS, 2 );
    }
}
