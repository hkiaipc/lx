using System;
using System.Collections;

namespace GprsSystem
{
    /// <summary>
    /// Solution GPRS Define
    /// </summary>
    public class SGDefine
    {
        /// <summary>
        /// 
        /// </summary>
        private SGDefine()
        {
        }

        public const byte HEAD_VALUE        = 0x7B;
        public const byte TAIL_VALUE        = 0x7B;

        /// <summary>
        /// PAT - PackAge Type
        /// </summary>
        public const byte PAT_REGISTER      = 0x01;
        public const byte PAT_HEARTBEAT     = 0x01;
        public const byte PAT_USERDATA      = 0x09;

        public const int MIN_PA_LEN         = 16;

        /// <summary>
        /// 读取DTU参数
        /// </summary>
        public const byte FC_R_DTU_SETTING   = 0x8B;

        /// <summary>
        /// 设置DTU参数
        /// </summary>
        public const byte FC_W_DTU_SETTING   = 0x8D;

        static public readonly DataField HEAD = new DataField( 0, 1, new byte[] { HEAD_VALUE } );
        static public readonly DataField TAIL = new DataField( DataField.UNSURENESS, 1, new byte[] { TAIL_VALUE } );

        
        // ----------------------------------------------------------------
        // 3.5.1 DTU 发送给DSC 的数据包DTU->DSC
        //
        // 起始标志     包类型  包长度  DTU身份识别码   结束标志    用户数据
        // 1byte        1byte   2bytes  11bytes         1byte       <=1024bytes
        // 0x7B         0x09    0x10    ...             0x7B        ...
        // ----------------------------------------------------------------
        static public readonly DataField PACKAGE_TYPE = new DataField( 1, 1 );
        static public readonly DataField PACKAGE_LEN  = new DataField( 2, 2 );
        static public readonly DataField SIM          = new DataField( 4, 11);
        static public readonly DataField USER_DATA    = new DataField( 15, DataField.UNSURENESS);



        #region DtuParamSettingFC
        /// <summary>
        /// DTU参数查询、设置功能码
        /// </summary>
        public class DtuParamSettingFC
        {
            private DtuParamSettingFC()
            {
            }

            /// <summary>
            /// 查询所有参数
            /// </summary>
            public const byte READ_ALL      = 0x00;

            /// <summary>
            /// 查询移动服务中心设置(MSC)
            /// </summary>
            public const byte READ_MSC      = 0x01;

            /// <summary>
            /// 查询数据终端参数设置
            /// </summary>
            public const byte READ_TERMINAL = 0x02;

            /// <summary>
            /// 查询数据服务中心参数设置
            /// </summary>
            public const byte READ_DSC      = 0x03;

            /// <summary>
            /// 查询串口参数设置
            /// </summary>
            public const byte READ_SERIALPORT = 0x04;

            /// <summary>
            /// 查询特殊参数设置
            /// </summary>
            public const byte READ_SPECIFIC = 0x05;
        }
        #endregion //DtuParamSettingFC

        #region DtuParamSettingTypeFC
        /// <summary>
        /// 
        /// </summary>
        public class DtuParamSettingTypeFC
        {
            /// <summary>
            /// DSC ip 地址
            /// </summary>
            public const byte DSC_IP_ADDRESS    = 0x0D;
            /// <summary>
            /// DSC 域名 
            /// </summary>
            public const byte DSC_DNS           = 0x0E;
            /// <summary>
            /// 网络检测时间间隔 
            /// </summary>
            public const byte NET_CHK_TIMESPAN  = 0x0F;
            /// <summary>
            /// DSC 端口 
            /// </summary>
            public const byte DSC_PORT          = 0x10;
            /// <summary>
            /// DNS ip 地址 
            /// </summary>
            public const byte DNS_IP_ADDRESS    = 0x11;
        }
        #endregion //DtuParamSettingTypeFC

        #region DtuParamSettingItemDesc
        /// <summary>
        /// 
        /// </summary>
        public class DtuParamSettingItemDesc
        {
            public const int UNSURENESS = -1;

            private string  _name; 
            private byte    _typeCode;
            private int     _length;
            private int     _paramValuesLength;

            /// <summary>
            /// 
            /// </summary>
            public string Name 
            {
                get { return _name; }
            }

            /// <summary>
            /// 
            /// </summary>
            public byte TypeCode
            {
                get { return _typeCode; }
            }

            /// <summary>
            /// 
            /// </summary>
            public int Length
            {
                get { return _length; }
            }
            
            /// <summary>
            /// 
            /// </summary>
            public int ParamValuesLength
            {
                get { return _paramValuesLength; }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <param name="typeCode"></param>
            /// <param name="Length"></param>
            /// <param name="paramValuesLength"></param>
            public DtuParamSettingItemDesc( string name, byte typeCode, int Length, int paramValuesLength )
            {
                _name = name;
                _typeCode = typeCode;
                _length = Length;
                _paramValuesLength = paramValuesLength;
            }
        }
        #endregion //DtuParamSettingItemDesc

        #region DtuParamSettingItemDescCollection
        /// <summary>
        /// 
        /// </summary>
        public class DtuParamSettingItemDescCollection
        {
            static public DtuParamSettingItemDesc DscIpAddress      = new DtuParamSettingItemDesc( "DSC IP 地址", 0x0D, 6, 4 );
            static public DtuParamSettingItemDesc DscDns            = new DtuParamSettingItemDesc( 
                                                                            "DSC 域名", 
                                                                            0x0E, 
                                                                            DtuParamSettingItemDesc.UNSURENESS , 
                                                                            DtuParamSettingItemDesc.UNSURENESS );
            static public DtuParamSettingItemDesc NetChkTimespan    = new DtuParamSettingItemDesc( "网络检测时间间隔", 0x0F, 4, 2 );
            static public DtuParamSettingItemDesc DscPort           = new DtuParamSettingItemDesc( "DSC 通讯端口", 0x10, 4, 2 );
            static public DtuParamSettingItemDesc DnsIpAddress      = new DtuParamSettingItemDesc( "DNS IP 地址", 0x11, 6, 4 );
        }
        #endregion //DtuParamSettingItemDescCollection

        #region ReadDscParamCmd
        /// <summary>
        /// 
        /// </summary>
        public class ReadDscParamCmd
        {
            private string _sim ;
            public ReadDscParamCmd( string sim )
            {
                _sim = sim;
            }

            public byte[] MakeCmd()
            {
                byte[] simBytes = SGDtu.GetSimNumberBytes( _sim );
                byte[] cmd = new byte[ 16 + 1 ];
                cmd[0] = SGDefine.HEAD_VALUE;
                cmd[1] = SGDefine.FC_R_DTU_SETTING;
                cmd[2] = 0x00;  // cmd.length / 0xFF
                cmd[3] = (byte)cmd.Length;
                Array.Copy( simBytes, 0, cmd, 4, simBytes.Length );
                cmd[15] = SGDefine.DtuParamSettingFC.READ_DSC;
                cmd[16] = SGDefine.TAIL_VALUE;
                
                return cmd;
            }
        }
        #endregion //ReadDscParamCmd

        #region DtuParamParser
        /// <summary>
        /// dtu 参数查询分析器
        /// </summary>
        public class DtuParamParser
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="paramDatas">dtu 返回的用户数据部分</param>
            /// <returns>dtu参数选项数组</returns>
            public DtuParamSettingItem[] Parse( byte[] paramDatas )
            {
                int i = 0;
                ArrayList list = new ArrayList();

                while( i < paramDatas.Length - 1 )
                {
                    int typePos = i;
                    int lengthPos = i + 1;
                    int valuesBeginPos = i + 2;


                    byte type = paramDatas[ typePos ];
                    byte len = paramDatas[ lengthPos ];

                    int valuesLen = len - 2;
                    int valuesEndPos = valuesBeginPos + valuesLen ;
                    
                    if ( valuesEndPos < paramDatas.Length )
                    {
                        byte[] values = new byte[ valuesLen ];               
                        Array.Copy( paramDatas, i + 2, values, 0, valuesLen );

                        DtuParamSettingItem dpsi = new DtuParamSettingItem(type, len, values);
                        list.Add( dpsi );
                    }
                }
                if ( list.Count > 0 )
                {
                    DtuParamSettingItem[] returns = new DtuParamSettingItem[ list.Count ];
                    for( int idx=0; idx<list.Count; idx++ )
                    {
                        returns[ idx ] = (DtuParamSettingItem) list[idx];
                    }
                    return returns;
                }
                else
                {
                    return null;
                }
            }

            ///// <summary>
            ///// 获取 Dtu 参数值的一般表示形式，如字符串、数字、IP地址等
            ///// </summary>
            ///// <param name="dpsi"></param>
            ///// <returns></returns>
            //public object GetDtuParamSettingItemValue( DtuParamSettingItem dpsi )
            //{
            //
            //}
            //
            ///// <summary>
            ///// 
            ///// </summary>
            ///// <param name="value"></param>
            ///// <returns></returns>
            //public DtuParamSettingItem GetDtuParamSettingItem( object value )
            //{
            //
            //}
        }
        #endregion //DtuParamParser

        #region DtuParamSettingItem
        /// <summary>
        /// DTU参数设置项
        /// </summary>
        public class DtuParamSettingItem
        {
            private byte    _type;
            private byte    _length;
            private byte[]  _values;

            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="type"></param>
            /// <param name="length"></param>
            /// <param name="values"></param>
            public DtuParamSettingItem( byte type, byte length, byte[] values )
            {
                _type = type;
                _length = length;
                _values = values;
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="type"></param>
            /// <param name="generalValueType"></param>
            /// <param name="generalValue"></param>
            public DtuParamSettingItem ( byte type, string generalValueType, object generalValue )
            {
                throw new NotImplementedException("DtuParamSettingItem");
            }

            /// <summary>
            /// 
            /// </summary>
            public byte Type
            {
                get { return _type; }
            }

            /// <summary>
            /// 
            /// </summary>
            public byte Length
            {
                get { return _length; }
            }

            /// <summary>
            /// 
            /// </summary>
            public byte[] Values
            {
                get { return _values; }
            }

            /// <summary>
            /// 
            /// </summary>
            public object GeneralValue
            {
                //TODO: GeneralValue
                get { return null;}
            }

            /// <summary>
            /// 
            /// </summary>
            public string GeneralValueType
            {
                //TODO: GeneralValueType
                get { return string.Empty; }
            }
        }
        #endregion //DtuParamSettingItem
    }
}
