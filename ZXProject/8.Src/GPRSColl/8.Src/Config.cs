using System;
using System.Drawing;
using System.Configuration;
using System.Net;

namespace GprsSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 
        /// </summary>
        static private Config s_default;

        /// <summary>
        /// 
        /// </summary>
        static public Config Default
        {
            get
            {
                if (s_default == null)
                    s_default = new Config();
                return s_default;
            }
        }


        private bool _isLogDtuRegisterAnswer;
        private bool _isLogDtuHeartBeat;
        private bool _isLogDtuCorrectData;
        private int _receiveThreadSleepTime;
        private Color _connectionedColor = Color.FromArgb(128, 255, 128);
        private Color _unConnectionedColor = Color.FromArgb(255, 255, 255);

        private Color _lvColor1 = Color.FromArgb(255, 255, 255);
        private Color _lvColor2 = Color.FromArgb(230, 230, 230);

        private Color _pumpVibrationColor = Color.FromArgb(255, 0, 0);
        private Color _defaultForeColor = Color.Black;


        private string _serverIP;
        private string[] _ddd;

        #region Ddd
        /// <summary>
        /// 
        /// </summary>
        public string[] Ddd
        {
            get { return _ddd; }
            set { _ddd = value; }
        }
        #endregion //Ddd

        private int _listenPort;

        private string _udpServerIP = IPAddress.Any.ToString();
        private int _udpServerPort = 2001;

        private string _soundFile;
        private string _connString;
        private string _userName;

        #region UserName
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        #endregion //UserName

        #region ConnString
        /// <summary>
        /// 
        /// </summary>
        public string ConnString
        {
            get { return _connString; }
            set { _connString = value; }
        }
        #endregion //ConnString

        #region DB2ConnectString
        /// <summary>
        /// 
        /// </summary>
        public string DB2ConnectString
        {
            get
            {
                if (_dB2ConnectString == null)
                {
                    _dB2ConnectString = string.Empty;
                }
                return _dB2ConnectString;
            }
            set
            {
                _dB2ConnectString = value;
            }
        } private string _dB2ConnectString;
        #endregion //DB2ConnectString

        #region SoundFile
        /// <summary>
        /// 
        /// </summary>
        public string SoundFile
        {
            get { return _soundFile; }
            set { _soundFile = value; }
        }
        #endregion //SoundFile

        #region UdpServerIP
        /// <summary>
        /// 
        /// </summary>
        public string UdpServerIP
        {
            get { return _udpServerIP; }
            set { _udpServerIP = value; }
        }
        #endregion //UdpServerIP

        #region UdpServerPort
        /// <summary>
        /// 
        /// </summary>
        public int UdpServerPort
        {
            get { return _udpServerPort; }
            set { _udpServerPort = value; }
        }
        #endregion //UdpServerPort

        #region ServerIP
        /// <summary>
        /// 
        /// </summary>
        public string ServerIP
        {
            get { return _serverIP; }
            set { _serverIP = value; }
        }
        #endregion //ServerIP

        #region ListenPort
        /// <summary>
        /// 
        /// </summary>
        public int ListenPort
        {
            get { return _listenPort; }
            set { _listenPort = value; }
        }
        #endregion //ListenPort


        #region DefaultForeColor
        /// <summary>
        /// 
        /// </summary>
        public Color DefaultForeColor
        {
            get { return _defaultForeColor; }
            set { _defaultForeColor = value; }
        }
        #endregion //DefaultForeColor

        #region LvColor2
        /// <summary>
        /// List view color 2
        /// </summary>
        public Color LvColor2
        {
            get { return _lvColor2; }
            set { _lvColor2 = value; }
        }
        #endregion //LvColor2

        #region LvColor1
        /// <summary>
        /// List view color 1
        /// </summary>
        public Color LvColor1
        {
            get { return _lvColor1; }
            set { _lvColor1 = value; }
        }
        #endregion //LvColor1

        #region ConnectionedColor
        /// <summary>
        /// 
        /// </summary>
        public Color ConnectionedColor
        {
            get { return _connectionedColor; }
            set { _connectionedColor = value; }
        }
        #endregion //ConnectionedColor

        #region UnConnectionedColor
        /// <summary>
        /// 
        /// </summary>
        public Color UnConnectionedColor
        {
            get { return _unConnectionedColor; }
            set { _unConnectionedColor = value; }
        }
        #endregion //UnConnectionedColor


        #region ShowSpecifyCommandMsgbox
        /// <summary>
        /// 
        /// </summary>
        public bool ShowSpecifyCommandMsgbox
        {
            get { return _showSpecifyCommandMsgbox; }
            set
            {
                if (_showSpecifyCommandMsgbox != value)
                {
                    _showSpecifyCommandMsgbox = value;
                }
            }
        } private bool _showSpecifyCommandMsgbox = true;
        #endregion //ShowSpecifyCommandMsgbox


        #region ShowSpecifyCommandContent
        /// <summary>
        /// 
        /// </summary>
        public bool ShowSpecifyCommandContent
        {
            get { return _showSpecifyCommandContent; }
            set
            {
                if (_showSpecifyCommandContent != value)
                {
                    _showSpecifyCommandContent = value;
                }
            }
        } private bool _showSpecifyCommandContent = false;
        #endregion //ShowSpecifyCommandContent

        #region PumpVibrationColor
        /// <summary>
        /// 
        /// </summary>
        public Color PumpVibrationColor
        {
            get { return _pumpVibrationColor; }
            set { _pumpVibrationColor = value; }
        }
        #endregion //PumpVibrationColor

        #region Config
        /// <summary>
        /// 
        /// </summary>
        private Config()
        {
            _isLogDtuRegisterAnswer = true;
            _receiveThreadSleepTime = 1000;

            //            IPHostEntry iphe = Dns.GetHostByName( Dns.GetHostName() );
            //            iphe.AddressList[0].add
        }
        #endregion //Config

        #region IsLogDtuCorrectData
        /// <summary>
        /// 
        /// </summary>
        public bool IsLogDtuCorrectData
        {
            get { return _isLogDtuCorrectData; }
            set { _isLogDtuCorrectData = value; }
        }
        #endregion //IsLogDtuCorrectData

        #region IsLogDtuRegisterAnswer
        /// <summary>
        /// 
        /// </summary>
        public bool IsLogDtuRegisterAnswer
        {
            get { return _isLogDtuRegisterAnswer; }
            set { _isLogDtuRegisterAnswer = value; }
        }
        #endregion //IsLogDtuRegisterAnswer

        #region IsLogDtuHeartBeat
        /// <summary>
        /// 
        /// </summary>
        public bool IsLogDtuHeartBeat
        {
            get { return _isLogDtuHeartBeat; }
            set { _isLogDtuHeartBeat = value; }
        }
        #endregion //IsLogDtuHeartBeat

        #region ReceiveThreadSleepTime
        /// <summary>
        /// 接收数据线程的sleep时间
        /// </summary>
        public int ReceiveThreadSleepTime
        {
            get { return _receiveThreadSleepTime; }
            set
            {
                if (value >= 10)
                    _receiveThreadSleepTime = value;
            }
        }
        #endregion //ReceiveThreadSleepTime

        #region ReadConfig
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ReadConfig()
        {
            System.Collections.Specialized.NameValueCollection nvc = ConfigurationSettings.AppSettings;
            string gprsIP = nvc["IP"];
            string port = nvc["Port"];
            string conn = nvc["ConnString"];
            string userName = nvc["UserName"];
            string soundFile = nvc["SoundFile"];
            string showCmdMsgbox = nvc["showcmdmsgbox"];
            string showCmdContent = nvc["showcmdcontent"];
            string sort = nvc["Sort"];

            string db2 = nvc["db2"];
            this.DB2ConnectString = db2;

            this.HasNewGate = bool.Parse(nvc["hasNewGate"]);

            try
            {
                Config.Default.ListenPort = int.Parse(port);
            }
            catch
            {
                ReadConfigFail("Port");
                return false;
            }

            try
            {
                IPAddress.Parse(gprsIP);
                _serverIP = gprsIP;
            }
            catch
            {
                ReadConfigFail("IP");
                return false;
            }

            try
            {
                Config.Default.ShowSpecifyCommandMsgbox = bool.Parse(showCmdMsgbox);
            }
            catch
            {
            }

            try
            {
                Config.Default.ShowSpecifyCommandContent = bool.Parse(showCmdContent);
            }
            catch
            {
            }

            this._connString = conn;
            _userName = userName;
            return true;
        }
        #endregion //ReadConfig

        #region ReadConfigFail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        private void ReadConfigFail(string text)
        {
            string s = string.Format("读取配置文件是错误\r\n无效的 '{0}'", text);
            System.Windows.Forms.MessageBox.Show(
                s,
                DeviceInfoManager.TEXT_TIP,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error
                );
        }
        #endregion //ReadConfigFail

        #region HasNewGate
        /// <summary>
        /// 是否获取新口门数据(XD2402)
        /// </summary>
        public bool HasNewGate
        {
            get
            {
                return _hasNewGate;
            }
            set
            {
                _hasNewGate = value;
            }
        } private bool _hasNewGate;
        #endregion //HasNewGate


        #region IsUseHDProtocol
        /// <summary>
        /// 是否启用宏电数据包装(使用宏电协议)
        /// </summary>
        public bool IsUseHDProtocol
        {
            get
            {
                // for test
                //
                return true;
            }
        }
        #endregion //IsUseHDProtocol

        #region IsTest
        /// <summary>
        /// 
        /// </summary>
        public bool IsTest
        {
            get
            {
                return false;
            }
        }
        #endregion //IsTest
    }
}
