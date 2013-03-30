using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;


namespace GprsSystem
{
	/// <summary>
	/// frmDebug 的摘要说明。
	/// </summary>
	public class frmDebug : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtCommon;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.IContainer components;

		public frmDebug()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDebug));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCommon = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 381);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCommon);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(808, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "输出";
            // 
            // txtCommon
            // 
            this.txtCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommon.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.txtCommon.Location = new System.Drawing.Point(0, 0);
            this.txtCommon.Multiline = true;
            this.txtCommon.Name = "txtCommon";
            this.txtCommon.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommon.Size = new System.Drawing.Size(808, 356);
            this.txtCommon.TabIndex = 2;
            this.txtCommon.Text = "textBox1";
            this.txtCommon.WordWrap = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.ImageIndex = 0;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(8, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 25);
            this.label1.TabIndex = 2;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmDebug
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(816, 409);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDebug";
            this.ShowInTaskbar = false;
            this.Text = "调试窗口";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmDebug_Closing);
            this.Load += new System.EventHandler(this.frmDebug_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        private void frmDebug_Load(object sender, System.EventArgs e)
        {
            this.txtCommon.Clear();
        }

        private void frmDebug_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void menuTopMost_Click(object sender, System.EventArgs e)
        {
//            this.TopMost = !TopMost;
//            this.menuTopMost.Checked = this.TopMost ;
        }

        private void menuThreadCount_Click(object sender, System.EventArgs e)
        {
            this.txtCommon.AppendText( "thread count: " + 
                Process.GetCurrentProcess().Threads.Count +
                Environment.NewLine );
            
        }

        private void menuCsinfo_Click(object sender, System.EventArgs e)
        {
//            ArrayList list = GetCsinfoList();
//            ShowCsinfoList( list );
//            ShowCsinfoListInLV( list );
        }

        public TextBox CommonTextBox
        {
            get { return txtCommon; }
        }

        private ArrayList GetCsinfoList ()
        {
            return DeviceInfoManager.DeviceInfoList;
        }

//        private void ShowCsinfoList( ArrayList list )
//        {
//            this.txtCsinfo.Clear();
//            if ( list == null )
//            {
//                this.txtCsinfo.Text = "<null>" ;
//            }
//            else
//            {
//                foreach (object obj in list )
//                {
//                    Cs_Info info = obj as Cs_Info;
//                    string s = string.Format( "StationName: {0}\r\nCommAddr: {1}\r\nSign: {2}\r\nSim: {3}\r\nSocket: {4}\r\n" + 
//                        "ConnectTime: {5}\r\nLastCollTime: {6}\r\nCorrect: {7}\r\n\r\n",
//                        info.Address,
//                        info.ComAdr,
//                        info.Sign,
//                        info.Sim,
//                        GetSocketString( info.Socket ),
//                        info.ConnectDateTime,
//                        info.LastCollDateTime,
//                        info.Correct );
//                    this.txtCsinfo.AppendText ( s );
//                }
//
//                
//            }
//        }

//        private void ShowCsinfoListInLV( ArrayList list )
//        {
//            this.lvCsinfo.Items.Clear();
//            if ( list == null )
//                return ;
//            int id = 0;
//            foreach ( object obj in list )
//            {
//                id ++;
//                Cs_Info info = obj as Cs_Info;
//                ListViewItem lvi = lvCsinfo.Items.Add( id.ToString() );
//                string [] range = GetCsinfoRange( info );
//                lvi.SubItems.AddRange( range );
//                if ( id % 3 == 0 )
//                    lvi.BackColor = Color.FromArgb(220,220,220);
//            }
//        }

        private string [] GetCsinfoRange( DeviceInfo info )
        {
            string[] r = new string[ 9 ];
            int i=0;
            r[ i++ ] = info.Address;
            r[ i++ ] = info.DeviceAddress.ToString() ;
            r[ i++ ] = info.DeviceKind;
            r[ i++ ] = info.Sim;
            r[ i++ ] = GetSocketString(info.Socket);
            r[ i++ ] = info.ConnectDateTime.ToString();
            r[ i++ ] = info.LastCollDateTime.ToString();
            r[ i++ ] = info.IsUse.ToString();
            r[ i++ ] = GetIPString( info.IP ); 

            return r;
        }

        private string GetIPString( IPAddress ip )
        {
            if ( ip == null )
                return "<null>";
            return ip.ToString();
        }

        private string GetSocketString( Socket socket )
        {
            if ( socket == null )
                return "<null>";
            // TODO: disposed exception 
            //
            try
            {
                return socket.RemoteEndPoint.ToString();
            }
            catch( ObjectDisposedException ex )
            {
                return ex.ToString() ;
            }
        }

        private void lvCsinfo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        
        }

        private void menuClear_Click(object sender, System.EventArgs e)
        {
            DebugLog.Default.Clear();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
//            this.TopMost = !this.TopMost;
//            this.button1.ImageIndex = this.TopMost ? 1 : 0;
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            this.TopMost = !this.TopMost;
            this.label1.ImageIndex = this.TopMost ? 1 : 0;
        }
    }

   
}
