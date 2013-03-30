using System;

namespace GprsSystem
{
    #region CsInfoTimeOutEventHandler
    /// <summary>
    /// 
    /// </summary>
    public delegate void CsInfoTimeOutEventHandler ( object sender, TimeOutEventArgs e );
    #endregion //CsInfoTimeOutEventHandler

    #region ReceivedEventHandler
    /// <summary>
    /// 
    /// </summary>
    public delegate void ReceivedEventHandler( object sender, ReceivedEventArgs e );
    #endregion //ReceivedEventHandler
	
    #region RevertEventHandler
    /// <summary>
    /// 
    /// </summary>
    public delegate void RevertEventHandler( object sender, RevertEventArgs e );
    #endregion //RevertEventHandler

    #region SocketEventHandler
    /// <summary>
    /// 
    /// </summary>
    public delegate void SocketEventHandler ( object sender , SocketEventArgs e );
    #endregion //SocketEventHandler

    #region SocketEventArgs
    /// <summary>
    /// 
    /// </summary>
    public class SocketEventArgs : System.EventArgs
    {
        private bool _isConnectedEvent; // connect event or disconnect event
        private DeviceInfo _info;

        public SocketEventArgs ( DeviceInfo info , bool connected )
        {

            if ( info == null )
                throw new ArgumentNullException( "info" );

            _info = info;
            _isConnectedEvent = connected;
        }

        public DeviceInfo Info
        {
            get { return _info; }
        }

        public bool ConnectEvent
        {
            get { return _isConnectedEvent; }
        }
    }
    #endregion //SocketEventArgs

    #region RevertEventArgs
    /// <summary>
    /// 
    /// </summary>
    public class RevertEventArgs : EventArgs
    {
        private byte[] _datas = null;
        private byte[] _revertDatas = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        public RevertEventArgs( byte[] datas )
        {
            _datas = datas;
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Datas 
        {
            get { return _datas; }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] RevertDatas
        {
            get { return _revertDatas; }
            set { _revertDatas = value; }
        }
    }
    #endregion //RevertEventArgs

    #region TimeOutEventArgs
    /// <summary>
    /// 
    /// </summary>
    public class TimeOutEventArgs : System.EventArgs 
    {
        /// <summary>
        /// 
        /// </summary>
        private DeviceInfo _info;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public TimeOutEventArgs( DeviceInfo info )
        {
            _info = info;
        }

        /// <summary>
        /// 
        /// </summary>
        public DeviceInfo Info 
        {
            get { return _info; }
        }
    }
    #endregion //TimeOutEventArgs

    #region ReceivedEventArgs
    /// <summary>
    /// 
    /// </summary>
    public class ReceivedEventArgs : System.EventArgs 
    {
        private byte[] _datas;
            
        public ReceivedEventArgs ( byte[] datas )
        {
            _datas = datas;
        }

        public byte[] Datas
        {
            get { return _datas; }
        }
    }
    #endregion //ReceivedEventArgs

}
