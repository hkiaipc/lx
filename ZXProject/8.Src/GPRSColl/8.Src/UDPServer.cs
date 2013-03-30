//using System;
//using System.Net;
//using System.Net.Sockets;

//namespace GprsSystem
//{
//    #region UDPServer
//    /// <summary>
//    /// 
//    /// </summary>
//    public class UDPServer
//    {
//        private const int BUF_SIZE = 512;

//        private Socket  _server;
//        private int     _bindPort;// = 2001;
//        private string  _ip      ;// = "192.168.0.55";


//        /// <summary>
//        /// 
//        /// </summary>
//        public UDPServer()
//        {
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        public event RevertEventHandler RevertEvent;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="bindIP"></param>
//        /// <param name="bindPort"></param>
//        public void Start( string bindIP, int bindPort )
//        {
//            _ip = bindIP ;
//            _bindPort = bindPort;
//            _server = new Socket( AddressFamily.InterNetwork,
//                SocketType.Dgram,
//                ProtocolType.Udp );

//            IPAddress ip = IPAddress.Parse( _ip );
//            IPEndPoint ipep = new IPEndPoint( ip, _bindPort );

//            _server.Bind( ipep );

//            byte[] buf = new byte[ BUF_SIZE ];

//            for ( ;; )
//            {
//                EndPoint remoteEP = new IPEndPoint( ip, _bindPort );
            
//                int receLen = _server.ReceiveFrom( buf, ref remoteEP );
//                if ( RevertEvent != null )
//                {
//                    byte[] bs = new byte[ receLen ];
//                    Array.Copy( buf, 0, bs, 0, receLen );
//                    RevertEventArgs e = new RevertEventArgs( bs ) ;
//                    RevertEvent( this, e );
                    
//                    if ( e.RevertDatas != null )
//                        _server.SendTo( e.RevertDatas, remoteEP );
//                }
//            }
//        }
//    }
//    #endregion //UDPServer
//}
