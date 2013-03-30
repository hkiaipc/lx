using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GprsSystem
{
	/// <summary>
	/// frmPassword 的摘要说明。
	/// </summary>
	public class frmPassword : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button bt_Cancle;
		private System.Windows.Forms.Button bt_Ok;
		private System.Windows.Forms.TextBox txtPwd_New1;
		private System.Windows.Forms.TextBox txtPwd_Old;
		private System.Windows.Forms.TextBox txtPwd_New2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPassword()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPassword));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPwd_New1 = new System.Windows.Forms.TextBox();
			this.txtPwd_Old = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txtPwd_New2 = new System.Windows.Forms.TextBox();
			this.bt_Cancle = new System.Windows.Forms.Button();
			this.bt_Ok = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(64, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "原 口 令:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(64, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "新 口 令:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(64, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "验证口令:";
			// 
			// txtPwd_New1
			// 
			this.txtPwd_New1.Location = new System.Drawing.Point(136, 56);
			this.txtPwd_New1.Name = "txtPwd_New1";
			this.txtPwd_New1.PasswordChar = '*';
			this.txtPwd_New1.Size = new System.Drawing.Size(136, 21);
			this.txtPwd_New1.TabIndex = 6;
			this.txtPwd_New1.Text = "";
			// 
			// txtPwd_Old
			// 
			this.txtPwd_Old.Location = new System.Drawing.Point(136, 24);
			this.txtPwd_Old.Name = "txtPwd_Old";
			this.txtPwd_Old.PasswordChar = '*';
			this.txtPwd_Old.Size = new System.Drawing.Size(136, 21);
			this.txtPwd_Old.TabIndex = 5;
			this.txtPwd_Old.Text = "";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 48);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// txtPwd_New2
			// 
			this.txtPwd_New2.Location = new System.Drawing.Point(136, 88);
			this.txtPwd_New2.Name = "txtPwd_New2";
			this.txtPwd_New2.PasswordChar = '*';
			this.txtPwd_New2.Size = new System.Drawing.Size(136, 21);
			this.txtPwd_New2.TabIndex = 9;
			this.txtPwd_New2.Text = "";
			// 
			// bt_Cancle
			// 
			this.bt_Cancle.Location = new System.Drawing.Point(200, 128);
			this.bt_Cancle.Name = "bt_Cancle";
			this.bt_Cancle.Size = new System.Drawing.Size(72, 23);
			this.bt_Cancle.TabIndex = 11;
			this.bt_Cancle.Text = "取消(&C)";
			this.bt_Cancle.Click += new System.EventHandler(this.bt_Cancle_Click);
			// 
			// bt_Ok
			// 
			this.bt_Ok.Location = new System.Drawing.Point(104, 128);
			this.bt_Ok.Name = "bt_Ok";
			this.bt_Ok.Size = new System.Drawing.Size(72, 23);
			this.bt_Ok.TabIndex = 10;
			this.bt_Ok.Text = "确定(&O)";
			this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
			// 
			// frmPassword
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(294, 163);
			this.Controls.Add(this.bt_Cancle);
			this.Controls.Add(this.bt_Ok);
			this.Controls.Add(this.txtPwd_New2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.txtPwd_New1);
			this.Controls.Add(this.txtPwd_Old);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "frmPassword";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "修改口令";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion
		//引用DbClass类
		DbClass Db=new DbClass();

		private void bt_Ok_Click(object sender, System.EventArgs e)
		{
			string pwd_old=this.txtPwd_Old.Text;
			string pwd_new1=this.txtPwd_New1.Text;
			string pwd_new2=this.txtPwd_New2.Text;
            int inf_val=-1;
            Db.PassWord_New(pwd_old,pwd_new1,pwd_new2,ref inf_val);
			//引用DbClass类
			if ( inf_val < 0 )
			{
				if ( inf_val == -1 )
				{
					this.txtPwd_Old.Text="";
					MessageBox.Show(this,"您输入的口令错误，请重新输入！","提示！",MessageBoxButtons.OK,MessageBoxIcon.Information);
				} 
				else
				{
					this.txtPwd_New1.Text="";
					this.txtPwd_New2.Text="";
					MessageBox.Show(this,"新口令与验证口令不匹配，请重新输入","提示！",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show(this,"新口令设置成功！","提示！",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void bt_Cancle_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
