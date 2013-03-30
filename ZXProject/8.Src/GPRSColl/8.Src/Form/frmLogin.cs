using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GprsSystem
{
    /// <summary>
    /// frmLogin 的摘要说明。
    /// </summary>
    public class frmLogin : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Button bt_Ok;
        private System.Windows.Forms.Button bt_Cancle;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmLogin()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            this.txtPassWord.Text = "power";
            txtUserName.Text = "power";
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.bt_Ok = new System.Windows.Forms.Button();
            this.bt_Cancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "口  令:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(112, 24);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(136, 21);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Text = "";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(112, 64);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(136, 21);
            this.txtPassWord.TabIndex = 4;
            this.txtPassWord.Text = "";
            // 
            // bt_Ok
            // 
            this.bt_Ok.Location = new System.Drawing.Point(80, 104);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(72, 23);
            this.bt_Ok.TabIndex = 5;
            this.bt_Ok.Text = "确定(&O)";
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // bt_Cancle
            // 
            this.bt_Cancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt_Cancle.Location = new System.Drawing.Point(176, 104);
            this.bt_Cancle.Name = "bt_Cancle";
            this.bt_Cancle.Size = new System.Drawing.Size(72, 23);
            this.bt_Cancle.TabIndex = 6;
            this.bt_Cancle.Text = "取消(&C)";
            this.bt_Cancle.Click += new System.EventHandler(this.bt_Cancle_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.bt_Ok;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.bt_Cancle;
            this.ClientSize = new System.Drawing.Size(274, 139);
            this.Controls.Add(this.bt_Cancle);
            this.Controls.Add(this.bt_Ok);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户验证";
            this.ResumeLayout(false);

        }
        #endregion
        //创建委托
        public delegate void MyDelegate(int Role);

        public event MyDelegate GetRole;
        //引用DbClass类
        DbClass Db=new DbClass();
        public bool isShow=false;
        //进行用户验证
        private void bt_Ok_Click(object sender, System.EventArgs e)
        {
            int Role=-1;
            string UserName = this.txtUserName.Text;
            string UserPwd  = this.txtPassWord.Text;
            Db.Login(UserName,UserPwd,ref Role);
            if ( Role < 0 )
            {
                if ( Role == -1 )
                {
                    MessageBox.Show(this,"该用户名未注册！","提示！",MessageBoxButtons.OK,MessageBoxIcon.Information);
                } 
                else
                {
                    MessageBox.Show(this,"用户口令错误，请重新输入！","提示！",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                if(!isShow)
                {
                    frmMain frm=new frmMain();
                    frm.Show();
                }
                else
                {
                    //委托事件
                    this.GetRole(Role);
                }
                //Db.Info_User(UserName);//,UserPwd
                this.Hide();
            }
        }
        
        //取消用户验证
        private void bt_Cancle_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

    }
}
