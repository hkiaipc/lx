using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GprsSystem
{
	/// <summary>
	/// frmConfig 的摘要说明。
	/// </summary>
	public class frmConfig : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtListenPort;
        private System.Windows.Forms.Label lblListenPort;
        private System.Windows.Forms.TextBox txtCollTimeSpan;
        private System.Windows.Forms.Label lblCollTimeSpan;
        private System.Windows.Forms.Button btnClose;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmConfig()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            FormAdjuster.SetOptionTypeForm( this );
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
            this.lblServerIP = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtListenPort = new System.Windows.Forms.TextBox();
            this.lblListenPort = new System.Windows.Forms.Label();
            this.txtCollTimeSpan = new System.Windows.Forms.TextBox();
            this.lblCollTimeSpan = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServerIP
            // 
            this.lblServerIP.Location = new System.Drawing.Point(16, 16);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(120, 23);
            this.lblServerIP.TabIndex = 0;
            this.lblServerIP.Text = "服务器地址：";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(160, 16);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.ReadOnly = true;
            this.txtServerIP.Size = new System.Drawing.Size(112, 21);
            this.txtServerIP.TabIndex = 1;
            this.txtServerIP.Text = "";
            // 
            // txtListenPort
            // 
            this.txtListenPort.Location = new System.Drawing.Point(160, 48);
            this.txtListenPort.Name = "txtListenPort";
            this.txtListenPort.ReadOnly = true;
            this.txtListenPort.Size = new System.Drawing.Size(112, 21);
            this.txtListenPort.TabIndex = 3;
            this.txtListenPort.Text = "";
            // 
            // lblListenPort
            // 
            this.lblListenPort.Location = new System.Drawing.Point(16, 48);
            this.lblListenPort.Name = "lblListenPort";
            this.lblListenPort.Size = new System.Drawing.Size(120, 23);
            this.lblListenPort.TabIndex = 2;
            this.lblListenPort.Text = "监听端口：";
            // 
            // txtCollTimeSpan
            // 
            this.txtCollTimeSpan.Location = new System.Drawing.Point(160, 80);
            this.txtCollTimeSpan.Name = "txtCollTimeSpan";
            this.txtCollTimeSpan.ReadOnly = true;
            this.txtCollTimeSpan.Size = new System.Drawing.Size(112, 21);
            this.txtCollTimeSpan.TabIndex = 5;
            this.txtCollTimeSpan.Text = "";
            // 
            // lblCollTimeSpan
            // 
            this.lblCollTimeSpan.Location = new System.Drawing.Point(16, 80);
            this.lblCollTimeSpan.Name = "lblCollTimeSpan";
            this.lblCollTimeSpan.Size = new System.Drawing.Size(120, 23);
            this.lblCollTimeSpan.TabIndex = 4;
            this.lblCollTimeSpan.Text = "采集间隔（分钟）：";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(184, 128);
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(288, 165);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtCollTimeSpan);
            this.Controls.Add(this.lblCollTimeSpan);
            this.Controls.Add(this.txtListenPort);
            this.Controls.Add(this.lblListenPort);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.lblServerIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfig";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void frmConfig_Load(object sender, System.EventArgs e)
        {
            LoadConfig();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadConfig()
        {
            this.txtServerIP.Text = Config.Default.ServerIP.ToString();
            this.txtListenPort.Text = Config.Default.ListenPort.ToString();
            this.txtCollTimeSpan.Text = DeviceInfo.CollTimeSpan.TotalMinutes.ToString();
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        private void SetOptionTypeForm( Form f )
        {
            f.ShowInTaskbar = false;
            f.FormBorderStyle = FormBorderStyle.FixedDialog; //大控制按钮，没有图标
            f.MinimizeBox = false;
            f.MaximizeBox = false;
        }

	}
}
