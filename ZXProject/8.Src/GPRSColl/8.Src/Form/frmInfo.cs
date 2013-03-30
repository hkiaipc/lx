using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace GprsSystem
{
    /// <summary>
    /// frmInfo 的摘要说明。
    /// </summary>
    public class frmInfo : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.ListView lvCsinfo;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chAddr;
        private System.Windows.Forms.ColumnHeader chSign;
        private System.Windows.Forms.ColumnHeader chSim;
        private System.Windows.Forms.ColumnHeader chSocket;
        private System.Windows.Forms.ColumnHeader chConnTime;
        private System.Windows.Forms.ColumnHeader chLastCollTime;
        private System.Windows.Forms.ColumnHeader chCorrect;
        private System.Windows.Forms.ColumnHeader chIP;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmInfo()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.lvCsinfo = new System.Windows.Forms.ListView();
            this.chId = new System.Windows.Forms.ColumnHeader();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chAddr = new System.Windows.Forms.ColumnHeader();
            this.chSign = new System.Windows.Forms.ColumnHeader();
            this.chSim = new System.Windows.Forms.ColumnHeader();
            this.chSocket = new System.Windows.Forms.ColumnHeader();
            this.chConnTime = new System.Windows.Forms.ColumnHeader();
            this.chLastCollTime = new System.Windows.Forms.ColumnHeader();
            this.chCorrect = new System.Windows.Forms.ColumnHeader();
            this.chIP = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuItemExit});
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 0;
            this.menuItemExit.Text = "刷新(&R)";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // lvCsinfo
            // 
            this.lvCsinfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                       this.chId,
                                                                                       this.chName,
                                                                                       this.chAddr,
                                                                                       this.chSign,
                                                                                       this.chSim,
                                                                                       this.chSocket,
                                                                                       this.chConnTime,
                                                                                       this.chLastCollTime,
                                                                                       this.chCorrect,
                                                                                       this.chIP});
            this.lvCsinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCsinfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.lvCsinfo.FullRowSelect = true;
            this.lvCsinfo.GridLines = true;
            this.lvCsinfo.Location = new System.Drawing.Point(0, 0);
            this.lvCsinfo.Name = "lvCsinfo";
            this.lvCsinfo.Size = new System.Drawing.Size(848, 625);
            this.lvCsinfo.TabIndex = 1;
            this.lvCsinfo.View = System.Windows.Forms.View.Details;
            // 
            // chId
            // 
            this.chId.Text = "编号";
            // 
            // chName
            // 
            this.chName.Text = "名称";
            this.chName.Width = 90;
            // 
            // chAddr
            // 
            this.chAddr.Text = "通讯地址";
            // 
            // chSign
            // 
            this.chSign.Text = "设备类型";
            // 
            // chSim
            // 
            this.chSim.Text = "电话号码";
            this.chSim.Width = 120;
            // 
            // chSocket
            // 
            this.chSocket.Text = "连接字";
            this.chSocket.Width = 120;
            // 
            // chConnTime
            // 
            this.chConnTime.Text = "连接时间";
            this.chConnTime.Width = 200;
            // 
            // chLastCollTime
            // 
            this.chLastCollTime.Text = "采集时间";
            this.chLastCollTime.Width = 200;
            // 
            // chCorrect
            // 
            this.chCorrect.Text = "启用";
            // 
            // chIP
            // 
            this.chIP.Text = "IP地址";
            this.chIP.Width = 120;
            // 
            // frmInfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(848, 625);
            this.Controls.Add(this.lvCsinfo);
            this.Menu = this.mainMenu1;
            this.Name = "frmInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPRS信息窗体";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInfo_Load);
            this.ResumeLayout(false);

        }
        #endregion

        //		private void ReadInfo()
        //		{
        //			StreamReader myReader=new StreamReader("InfoFile.txt",Encoding.UTF8);
        //			string myinfo=myReader.ReadToEnd();
        //			myReader.Close();
        //			this.richTextBox1.AppendText(myinfo);
        //		}

        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            this.ShowCsinfoListInLV(DeviceInfoManager.DeviceInfoList);
        }

        private void frmInfo_Load(object sender, System.EventArgs e)
        {
            //			ReadInfo();
            ShowCsinfoListInLV(DeviceInfoManager.DeviceInfoList);
        }

        private void ShowCsinfoListInLV(ArrayList list)
        {
            this.lvCsinfo.Items.Clear();
            if (list == null)
                return;
            int id = 0;
            foreach (object obj in list)
            {
                id++;
                DeviceInfo info = obj as DeviceInfo;
                ListViewItem lvi = lvCsinfo.Items.Add(id.ToString());
                string[] range = GetCsinfoRange(info);
                lvi.SubItems.AddRange(range);
                if (id % 2 == 0)
                    lvi.BackColor = Config.Default.LvColor2;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private string[] GetCsinfoRange(DeviceInfo info)
        {
            string[] r = new string[9];
            int i = 0;
            r[i++] = info.Address;
            r[i++] = info.DeviceAddress.ToString();
            r[i++] = GetDeviceKindAndDevice(info);
            r[i++] = info.Sim;
            r[i++] = GetSocketString(info.Socket);
            r[i++] = info.ConnectDateTime.ToString();
            r[i++] = info.LastCollDateTime.ToString();
            r[i++] = info.IsUse.ToString();
            r[i++] = GetIPString(info.IP);

            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private string GetDeviceKindAndDevice(DeviceInfo info)
        {
            if (info.DeviceType.Length > 0)
            {
                return string.Format("{0}({1})", info.DeviceKind, info.DeviceType);
            }
            else
            {
                return info.DeviceKind;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private string GetIPString(IPAddress ip)
        {
            if (ip == null)
                return "<无>";
            return ip.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        private string GetSocketString(Socket socket)
        {
            if (socket == null)
                return "<无>";
            return socket.RemoteEndPoint.ToString();
        }
    }
}
