using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GprsSystem
{
	/// <summary>
	/// frmCmdSelect 的摘要说明。
	/// </summary>
	public class frmCmdSelect : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCmdList;
        private System.Windows.Forms.Label lblCmdContent;
        private System.Windows.Forms.ListBox lstCmd;
        private System.Windows.Forms.TextBox txtCmdContent;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        private byte[]  _selectedCmd = null;
        private DeviceInfo     _csinfo = null;
		public frmCmdSelect( DeviceInfo info )
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            FormAdjuster.SetOptionTypeForm( this );
            System.Diagnostics.Debug.Assert( info != null );

            _csinfo = info;
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
            this.lstCmd = new System.Windows.Forms.ListBox();
            this.txtCmdContent = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCmdList = new System.Windows.Forms.Label();
            this.lblCmdContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstCmd
            // 
            this.lstCmd.ItemHeight = 12;
            this.lstCmd.Location = new System.Drawing.Point(8, 32);
            this.lstCmd.Name = "lstCmd";
            this.lstCmd.Size = new System.Drawing.Size(376, 112);
            this.lstCmd.TabIndex = 0;
            // 
            // txtCmdContent
            // 
            this.txtCmdContent.Location = new System.Drawing.Point(8, 184);
            this.txtCmdContent.Multiline = true;
            this.txtCmdContent.Name = "txtCmdContent";
            this.txtCmdContent.ReadOnly = true;
            this.txtCmdContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCmdContent.Size = new System.Drawing.Size(376, 96);
            this.txtCmdContent.TabIndex = 1;
            this.txtCmdContent.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(224, 296);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(304, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCmdList
            // 
            this.lblCmdList.Location = new System.Drawing.Point(8, 8);
            this.lblCmdList.Name = "lblCmdList";
            this.lblCmdList.TabIndex = 4;
            this.lblCmdList.Text = "命令列表";
            // 
            // lblCmdContent
            // 
            this.lblCmdContent.Location = new System.Drawing.Point(8, 160);
            this.lblCmdContent.Name = "lblCmdContent";
            this.lblCmdContent.TabIndex = 4;
            this.lblCmdContent.Text = "命令内容";
            // 
            // frmCmdSelect
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(392, 325);
            this.Controls.Add(this.lblCmdList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCmdContent);
            this.Controls.Add(this.lstCmd);
            this.Controls.Add(this.lblCmdContent);
            this.Name = "frmCmdSelect";
            this.Text = "命令选择";
            this.Load += new System.EventHandler(this.frmCmdSelect_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void frmCmdSelect_Load(object sender, System.EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] SelectedCmd
        {
            get { return _selectedCmd; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            _selectedCmd = GetSelectedCmd();
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private byte[] GetSelectedCmd()
        {
            int idx = this.lstCmd.SelectedIndex ;
            if ( idx != -1 )
            {
                string selName = lstCmd.Items[ idx ].ToString();
                return CmdFactory.CreateCmd( selName, _csinfo );
            }
            return null;
        }
	}
}
