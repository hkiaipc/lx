using System;
using System.Data;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms ;
using LXRainCommon;

namespace LXRainTrans
{
    public class Trans
    {
        /// <summary>
        /// 
        /// </summary>
        private Timer _timer = new Timer();

        /// <summary>
        /// 
        /// </summary>
        public Trans()
        {
            this.SocketClient.ReceivedEvent += new EventHandler(SocketClient_ReceivedEvent);

            _timer.Interval = App.Default.Config.CheckConnectInterval;
            _timer.Tick += new EventHandler(_timer_Tick);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start ()
        {
            _timer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SocketClient_ReceivedEvent(object sender, EventArgs e)
        {
            byte[] bs = this.SocketClient.ReceivedBytes;

            RainRequest q;
            bool b = RainRequest.Parse(bs, out q);
            if (b)
            {
                string s = string.Format("请求 '{0}' 数据", q.LastDateTime);
                Logger.Log(s);

                DataTable tbl = App.Default.DB.GetRainDataTable(q.LastDateTime);

                RainResponse response = new RainResponse(q.Address);
                response.RainDataTable = tbl;
                byte[] bsR = response.ToBytes();

                System.Diagnostics.Debug.Assert(bsR.Length == 68,"len != 68");

                try
                {
                    this.SocketClient.Send(bsR);
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                    return;
                }

                string sendmsg = string.Format("发送 '{0}' 条数据", tbl.Rows.Count);
                Logger.Log(sendmsg );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        Logger Logger
        {
            get
            {
                return App.Default.Logger;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _timer_Tick(object sender, EventArgs e)
        {
            if (!this.SocketClient.IsConnected)
            {
                IPAddress ip = App.Default.Config.RemoteIP;
                ushort port = App.Default.Config.RemotePort;

                string s = string.Format("尝试连接到 '{0}:{1}'", ip, port);
                Logger.Log(s);

                try
                {
                    this.SocketClient.Connect(ip, port);
                    Logger.Log("连接成功");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                }
            }
        }

        #region SocketClient
        /// <summary>
        /// 
        /// </summary>
        public SocketClient SocketClient
        {
            get
            {
                if (_socketClient == null)
                {
                    _socketClient = new SocketClient();
                }
                return _socketClient;
            }
            set
            {
                _socketClient = value;
            }
        } private SocketClient _socketClient;
        #endregion //SocketClient

    }
}
