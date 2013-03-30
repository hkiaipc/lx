using System;

namespace GprsSystem
{
	/// <summary>
	/// 
	/// </summary>
	public class DeviceInfoState
	{

        #region StateFlag
        /// <summary>
        /// 
        /// </summary>
        public enum StateFlag
        {
            Idly,
            Sended,
        }
        #endregion //StateFlag

        private DateTime    _sendTime;
        private DateTime    _receiveTime;
        private byte[]      _sendData;
        private byte[]      _receiveData;

        /// <summary>
        /// 
        /// </summary>
        private StateFlag   _state = StateFlag.Idly;

        /// <summary>
        /// 
        /// </summary>
        public static readonly TimeSpan TIMEOUT = TimeSpan.FromSeconds( 9 );

		#region DeviceInfoState
        /// <summary>
        /// 
        /// </summary>
		public DeviceInfoState()
		{
            Reset();
		}
		#endregion //DeviceInfoState

        #region Reset
        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            this._state = StateFlag.Idly;
            this._sendTime = DateTime.MinValue;
            this._receiveTime = DateTime.MinValue;
            this._sendData = null;
            this._receiveData = null;
        }
        #endregion //Reset

        #region AppendReceivedData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        public void AppendReceivedData ( byte[] bs )
        {
            if ( bs == null )
                return;

            if ( _receiveData == null )
            {
                _receiveData = (byte[])bs.Clone();
                return;
            }

            int len = GetLen( _receiveData ) + GetLen( bs ) ;
            byte[] newbs = new byte[ len ];
            Array.Copy( _receiveData, 0, newbs, 0, GetLen( _receiveData ) );
            Array.Copy ( bs, 0, newbs, GetLen( _receiveData ), GetLen( bs ) );
            _receiveData = newbs;
        }
        #endregion //AppendReceivedData

        #region GetLen
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        private int GetLen( byte[] bs )
        {
            if ( bs == null )
                return 0;
            return bs.Length;

        }
        #endregion //GetLen


        #region SetSendData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        public void SetSendData ( byte[] bs )
        {
            //System.Diagnostics.Debug.Assert( _state == StateFlag.Idly );

            this._sendData = bs;
            this._sendTime = DateTime.Now; 
            this._state = StateFlag.Sended ;
        }
        #endregion //SetSendData

        #region IsIdly
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsIdly()
        {
            return _state == StateFlag.Idly;
        }
        #endregion //IsIdly

        #region IsSended
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSended()
        {
            return _state == StateFlag.Sended;
        }
        #endregion //IsSended

        #region IsTimeOut
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsTimeOut( DateTime dt )
        {
            TimeSpan ts = dt - this._sendTime;
            if ( ts >= TIMEOUT || ts < TimeSpan.Zero )
                return true;

            return false;
        }
        #endregion //IsTimeOut

        #region State
        /// <summary>
        /// 
        /// </summary>
        public StateFlag State
        {
            get { return _state; }
        }
        #endregion //State

        #region SendTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime SendTime
        {
            get { return _sendTime; }
            set { _sendTime = value; }
        }
        #endregion //SendTime

        #region ReceiveTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReceiveTime 
        {
            get { return _receiveTime ;}
            set { _receiveTime = value; }
        }
        #endregion //ReceiveTime

        #region SendData
        /// <summary>
        /// 
        /// </summary>
        public byte[]  SendData 
        {
            get { return _sendData;}
            set { _sendData = value; }
        }
        #endregion //SendData

        #region ReceiveData
        /// <summary>
        /// 
        /// </summary>
        public byte[] ReceiveData
        {
            get { return _receiveData; }
            set { _receiveData = value; }
        }
        #endregion //ReceiveData
	}
}
