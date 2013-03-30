using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using PumpDriver;
namespace GprsSystem
{

	/// <summary>
	/// 保存控制器的相关信息
	/// </summary>
	public class DeviceInfo : IComparable
    {
        #region Texts
        public const string TEXT_HEARTBEAT      = "心跳"; //"HeartBeat";
        public const string TEXT_CONNECT        = "连接"; //"Connect";
        public const string TEXT_DISCONNECT     = "断开"; //"Disconnect";
        public const string TEXT_GATE_CMD3C     = "口门采集"; //"GateCmd0x3C";
        public const string TEXT_PUMP_CMD1A     = "泵站采集"; //"PumpCmd0x1A";
        #endregion //Texts

        #region Members

        protected string address;
		protected int deviceAddress;
		protected string sim;
		protected string m_deviceKind;
		protected int isUse;
        
        // for new pump communication protocol v7.05
        //
        private int _collTimesReadNo_705;
        private int _collTimesReadRecord_705;

        /// <summary>
        /// 
        /// </summary>
        private Socket _socket;

        private DateTime _connectDateTime           = DateTime.MinValue;
        /// <summary>
        /// 最后一次采集该站点时间
        /// </summary>
        private DateTime _lastCollDateTime          = DateTime.MinValue;

        /// <summary>
        /// not use
        /// </summary>
        private DateTime _lastCollSuccessDateTime   = DateTime.MinValue; 

        private DateTime _disconnectDateTiem        = DateTime.MinValue;

        /// <summary>
        /// 最后更新数据时间
        /// </summary>
        private DateTime _lastUpdateDateTime        = DateTime.MinValue;

        /// <summary>
        /// 采集的次数
        /// </summary>
        private int      _collTimes                 = 0;

        /// <summary>
        /// 站点采集时间间隔
        /// </summary>
        private static TimeSpan _collTimeSpan  = new TimeSpan(0,0,15,0,0 );

        /// <summary>
        /// 最大采集次数
        /// </summary>
        private static int      _maxCollTimes  = 2;

        /// <summary>
        /// 
        /// </summary>
        private int             _pumpCommunicationProtocolVer;  // 705 - V7.05

        /// <summary>
        /// 
        /// </summary>
        private IPAddress       _ip;

        private Tally           _tally = new Tally();
        private DeviceInfoState     _deviceInfoState = new DeviceInfoState();

        public event ReceivedEventHandler     ReceivedEvent;
        #endregion //Members

        #region DeviceInfoState
        /// <summary>
        /// 
        /// </summary>
        public DeviceInfoState DeviceInfoState
        {
            get { return _deviceInfoState; }
        }
        #endregion //DeviceInfoState

        #region Tally
        /// <summary>
        /// 
        /// </summary>
        public Tally Tally
        {
            get { return _tally; }
        }
        #endregion //Tally

        #region IP
        /// <summary>
        /// 
        /// </summary>
        public IPAddress IP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        #endregion //IP

        #region PumpCommunicationProtocolVersion
        /// <summary>
        /// 泵站通讯协议版本
        /// </summary>
        public int PumpCommunicationProtocolVersion
        {
            get { return _pumpCommunicationProtocolVer; }
            set { _pumpCommunicationProtocolVer = value; }
        }
        #endregion //PumpCommunicationProtocolVersion


        #region CollTimeSpan
        /// <summary>
        /// 采集时间间隔
        /// </summary>
        public static TimeSpan CollTimeSpan
        {
            get { return _collTimeSpan; }
            set { _collTimeSpan = value; }
        }
        #endregion //CollTimeSpan

        #region MaxCollTimes
        /// <summary>
        /// 采集次数上限
        /// </summary>
        public static int MaxCollTimes
        {
            get { return _maxCollTimes; }
            set 
            { 
                System.Diagnostics.Debug.Assert( value >= 1 ); 
                _maxCollTimes = value; 
            }
        }
        #endregion //MaxCollTimes

		#region DeviceInfo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_address"></param>
        /// <param name="_comAdr"></param>
        /// <param name="_sim"></param>
        /// <param name="_sign"></param>
        /// <param name="_correct"></param>
		public DeviceInfo(string _address,int _comAdr,string _sim,string deviceKind,int _correct, string ip)
        {
            address = _address;
            deviceAddress = _comAdr;
            sim = _sim;
            m_deviceKind = deviceKind;
            isUse = _correct;
            if (ip != null && ip.Length > 0)
            {
                this._ip = IPAddress.Parse(ip);
            }

            //_newPumpDataCache = new NewPumpDataCache( _comAdr );
            InitTally();
		}
		#endregion //DeviceInfo


        #region InitTally
        /// <summary>
        /// 
        /// </summary>
        private void InitTally()
        {
            string[] tiName = new string[] {
                TEXT_HEARTBEAT,
                TEXT_CONNECT,
                TEXT_DISCONNECT,
                TEXT_GATE_CMD3C,
                TEXT_PUMP_CMD1A
            };

            foreach ( string s in tiName )
            {
                this._tally.AddTallyItem( s );
            }
        }
        #endregion //InitTally

        #region Socket
        /// <summary>
        /// 
        /// </summary>
        public Socket Socket
        {
            get { return _socket; }
            set 
            {
                _socket = value; 
                if ( value != null )
                    this._connectDateTime = DateTime.Now;
                else
                    this._disconnectDateTiem = DateTime.Now;

                this.Group.Socket = value;
            }
        }
        #endregion //Socket

        #region ConnectDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime ConnectDateTime
        {
            get { return _connectDateTime;}
            set { _connectDateTime = value; }
        }
        #endregion //ConnectDateTime

        #region LastCollDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastCollDateTime
        {
            get { return _lastCollDateTime; }
            set { _lastCollDateTime = value; }
        }
        #endregion //LastCollDateTime

        #region LastCollSuccessDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastCollSuccessDateTime
        {
            get { return _lastCollSuccessDateTime ; }
            set { _lastCollSuccessDateTime = value; }
        }
        #endregion //LastCollSuccessDateTime

        #region DisconnectDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime DisconnectDateTime
        {
            get { return _disconnectDateTiem; }
            set { _disconnectDateTiem = value; }
        }
        #endregion //DisconnectDateTime

        #region LastUpdateDateTime
        /// <summary>
        /// 最后一次更新数据的时间
        /// </summary>
        public DateTime LastUpdateDateTime
        {
            get { return _lastUpdateDateTime; }
            set 
            { 
                _lastUpdateDateTime = value; 
                this._collTimes = 0;
            }
        }
        #endregion //LastUpdateDateTime

		#region Address
        #region Name
        /// <summary>
        /// 同 Address 
        /// </summary>
        public string Name
        {
            get { return Address; }
            set { Address = value; }
        }
        #endregion //Name
        /// <summary>
        /// 控制器所处的地址
        /// </summary>
		public string Address
		{ 
			get{return address;} 
			set{address = value;} 
		} 
		#endregion //Address

		#region DeviceAddress
        /// <summary>
        /// 通讯地址
        /// </summary>
		public int DeviceAddress
		{ 
			get{return deviceAddress;} 
			set{deviceAddress = value;} 
		} 
		#endregion //DeviceAddress


		#region Sim
        /// <summary>
        /// Sim卡号
        /// </summary>
		public string Sim
		{ 
			get{return sim;} 
			set{sim = value;} 
		}
		#endregion //Sim

		#region DeviceType
        /// <summary>
        /// 标示口门还是泵站
        /// </summary>
		public string DeviceKind
		{
			get{return m_deviceKind;} 
			set{m_deviceKind = value;}
		}
		#endregion //DeviceType

		#region IsUse
        /// <summary>
        /// 是否启用标志
        /// </summary>
		public int IsUse
		{ 
			get{return isUse;} 
			set{isUse = value;} 
		}
		#endregion //IsUse

        #region SortNumber
        /// <summary>
        /// 
        /// </summary>
        public int SortNumber
        {
            get { return _sortNumber; }
            set { _sortNumber = value; }
        }   private int _sortNumber = int.MaxValue;
        #endregion //SortNumber

        #region ID
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }   private int _id;
        #endregion //ID

        #region NeedColl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool NeedColl( DateTime dt )
        {
            TimeSpan ts1 = dt - this._lastCollDateTime;
            TimeSpan ts2 = dt - this._lastUpdateDateTime;
                
            // _collTimes 应该始终 <= _maxCollTims
            //
            if ( _collTimes < _maxCollTimes )
            {
                if ( ts1 >= DeviceInfo._collTimeSpan &&
                    ts2 >= DeviceInfo._collTimeSpan )
                {
                    return true;
                }
            }
            else
            {
                _collTimes = 0;
            }
            return false;
        }
        #endregion //NeedColl

        #region UpdateLastCollDateTime
        /// <summary>
        /// 更新最后采集时间
        /// </summary>
        /// <param name="dt"></param>
        public void UpdateLastCollDateTime( DateTime dt )
        {
            if ( this.PumpCommunicationProtocolVersion == 705 )
            {
                if ( _lastHistoryRecordNo == -1 )
                {
                    _collTimesReadNo_705 ++;
                }
                else 
                {
                    _collTimesReadRecord_705 ++; 
                }

                if ( _collTimesReadNo_705 >= DeviceInfo._maxCollTimes ||
                    _collTimesReadRecord_705 >= DeviceInfo._maxCollTimes )
                {
                    _collTimesReadNo_705 = 0;
                    _collTimesReadRecord_705 = 0;
                    _lastHistoryRecordNo = -1;
                    _lastCollDateTime = dt;
                }
            }
            else
            {
                _collTimes ++;

                if ( _collTimes >= DeviceInfo._maxCollTimes )
                {
                    _collTimes = 0;
                    _lastCollDateTime = dt;
                }
            }
        }
        #endregion //UpdateLastCollDateTime

        #region LastHistoryRecordNo
        private int _lastHistoryRecordNo = -1;
        /// <summary>
        /// 获取 或 设置最后一条历史记录号
        /// </summary>
        public int LastHistoryRecordNo
        {
            get { return _lastHistoryRecordNo; }
            set { _lastHistoryRecordNo = value; }
        }
        #endregion //LastHistoryRecordNo

        #region FireReceivedDataEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        public void FireReceivedDataEvent( byte[] datas )
        {
            if ( this.ReceivedEvent != null )
            {
                this.ReceivedEvent( this, new ReceivedEventArgs( datas ) );
            }
        }
        #endregion //FireReceivedDataEvent

        #region CompareTo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            DeviceInfo info = obj as DeviceInfo;
            if (info == null)
                return 1;
            int d = 0;
            d = this.SortNumber - info.SortNumber;
            if (d > 0)
                return 1;
            else if (d < 0)
                return -1;
            else
                return 0;
        }
        #endregion //CompareTo

        #region DeviceType
        /// <summary>
        /// 
        /// </summary>
        public string DeviceType
        {
            get
            {
                if (_deviceType == null)
                {
                    _deviceType = string.Empty;
                }
                return _deviceType;
            }
            set
            {
                _deviceType = value;
            }
        } private string _deviceType;
        #endregion //DeviceType


        #region Group
        /// <summary>
        /// 
        /// </summary>
        public Group Group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
            }
        } private Group _group;
        #endregion //Group

    }
}

