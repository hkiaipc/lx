using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GprsSystem
{
	/// <summary>
	/// frmTallyDetail ��ժҪ˵����
	/// </summary>
	public class frmTallyDetail : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Button btnClose;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

        private TallyItem _tallyItem;

		public frmTallyDetail( TallyItem ti )
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
            if ( ti == null )
                throw new ArgumentNullException( "ti" );

            _tallyItem = ti;
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDetail
            // 
            this.txtDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetail.Font = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.txtDetail.Location = new System.Drawing.Point(8, 8);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ReadOnly = true;
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetail.Size = new System.Drawing.Size(496, 456);
            this.txtDetail.TabIndex = 1;
            this.txtDetail.Text = "";
            this.txtDetail.WordWrap = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(432, 472);
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "�ر�";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTallyDetail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(512, 501);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTallyDetail";
            this.Text = "frmTallyDetail";
            this.Load += new System.EventHandler(this.frmTallyDetail_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTallyDetail_Load(object sender, System.EventArgs e)
        {
            Text = _tallyItem.Name + " " + _tallyItem.List.Count ;

            foreach ( object obj in _tallyItem.List )
            {
                this.txtDetail.AppendText( obj.ToString() + Environment.NewLine );
            }
        }
	}
}
