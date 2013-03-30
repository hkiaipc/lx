using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace GprsSystem
{
    /// <summary>
    /// cs_info communication debug form.
    /// </summary>
    public class frmCsinfoComm : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.Label lblReveivedData;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSendData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCmdSelect;
        private DeviceInfo _info;

        public frmCsinfoComm(DeviceInfo info)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            FormAdjuster.SetOptionTypeForm(this);
            Debug.Assert(info != null);
            _info = info;
            _info.ReceivedEvent += new ReceivedEventHandler(_info_ReceivedEvent);
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
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.lblReveivedData = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblSendData = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCmdSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(8, 40);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(584, 21);
            this.txtSend.TabIndex = 0;
            this.txtSend.Text = "";
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(8, 136);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceived.Size = new System.Drawing.Size(584, 248);
            this.txtReceived.TabIndex = 1;
            this.txtReceived.Text = "";
            this.txtReceived.WordWrap = false;
            // 
            // lblReveivedData
            // 
            this.lblReveivedData.Location = new System.Drawing.Point(8, 112);
            this.lblReveivedData.Name = "lblReveivedData";
            this.lblReveivedData.TabIndex = 2;
            this.lblReveivedData.Text = "接收数据";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(512, 72);
            this.btnSend.Name = "btnSend";
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSendData
            // 
            this.lblSendData.Location = new System.Drawing.Point(8, 16);
            this.lblSendData.Name = "lblSendData";
            this.lblSendData.TabIndex = 4;
            this.lblSendData.Text = "发送数据";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(512, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(16, 392);
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCmdSelect
            // 
            this.btnCmdSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btnCmdSelect.Location = new System.Drawing.Point(16, 72);
            this.btnCmdSelect.Name = "btnCmdSelect";
            this.btnCmdSelect.TabIndex = 7;
            this.btnCmdSelect.Text = "选择...";
            this.btnCmdSelect.Click += new System.EventHandler(this.btnCmdSelect_Click);
            // 
            // frmCsinfoComm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(600, 421);
            this.Controls.Add(this.btnCmdSelect);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSendData);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblReveivedData);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.txtSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCsinfoComm";
            this.Text = "frmCsinfoComm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmCsinfoComm_Closing);
            this.Load += new System.EventHandler(this.frmCsinfoComm_Load);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCsinfoComm_Load(object sender, System.EventArgs e)
        {
            this.Text = _info.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _info_ReceivedEvent(object sender, ReceivedEventArgs e)
        {
            string s = string.Format("{0} : {1}",
                DateTime.Now,
                Utilities.CT.BytesToString(e.Datas)
                );

            this.txtReceived.AppendText(s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCsinfoComm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._info.ReceivedEvent -= new ReceivedEventHandler(_info_ReceivedEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, System.EventArgs e)
        {
            byte[] cmds = null;
            try
            {
                cmds = Utilities.CT.StringToBytes(txtSend.Text, null, Utilities.StringFormat.Hex);
            }
            catch
            {
                ShowSendDataError();
                return;
            }

            if (_info.Socket != null && _info.Socket.Connected)
                _info.Socket.Send(cmds);
            else
            {
                MessageBox.Show("连接不存在或已关闭", DeviceInfoManager.TEXT_TIP, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowSendDataError()
        {
            MessageBox.Show("输入数据错误", DeviceInfoManager.TEXT_TIP);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, System.EventArgs e)
        {
            txtReceived.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCmdSelect_Click(object sender, System.EventArgs e)
        {
            frmCmdSelect f = new frmCmdSelect(this._info);
            if (f.ShowDialog() == DialogResult.OK)
            {

                byte[] cmd = f.SelectedCmd;
                string cmdStr = Utilities.CT.BytesToString(cmd);
                this.txtSend.Text = cmdStr;
            }
        }
    }
}
