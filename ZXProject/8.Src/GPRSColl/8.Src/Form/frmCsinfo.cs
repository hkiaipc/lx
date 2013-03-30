using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace GprsSystem
{
	/// <summary>
	/// frmCsinfo ��ժҪ˵����
	/// </summary>
	public class frmCsinfo : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Button btnClose;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ComboBox cmbListName;
        private System.Windows.Forms.Button btnDetail;

        private DeviceInfo _info; 

		public frmCsinfo( DeviceInfo info )
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
            Debug.Assert( info != null );
            _info = info;
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
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.cmbListName = new System.Windows.Forms.ComboBox();
            this.btnDetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(384, 492);
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "�ر�";
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
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
            this.txtDetail.Size = new System.Drawing.Size(452, 476);
            this.txtDetail.TabIndex = 0;
            this.txtDetail.Text = "";
            this.txtDetail.WordWrap = false;
            // 
            // cmbListName
            // 
            this.cmbListName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbListName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListName.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.cmbListName.Location = new System.Drawing.Point(8, 492);
            this.cmbListName.Name = "cmbListName";
            this.cmbListName.Size = new System.Drawing.Size(192, 23);
            this.cmbListName.Sorted = true;
            this.cmbListName.TabIndex = 1;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetail.Location = new System.Drawing.Point(208, 492);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(40, 24);
            this.btnDetail.TabIndex = 2;
            this.btnDetail.Text = "��ϸ";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // frmCsinfo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(468, 529);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.cmbListName);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmCsinfo";
            this.Text = "frmCsinfo";
            this.Load += new System.EventHandler(this.frmCsinfo_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void button1_Click(object sender, System.EventArgs e)
        {
//            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCsinfo_Load(object sender, System.EventArgs e)
        {
            Text = _info.Address;
            LogItem li = new LogItem();
            li.HasDateTime = false;
            li.Add( "����    ", _info.Address );
            li.Add( "ͨѶ��ַ", _info.DeviceAddress);
            li.Add( "IP��ַ  ", _info.IP.ToString());
            li.Add( "�豸����", _info.DeviceKind );
            li.Add( "�绰����", _info.Sim );

            if ( _info.DeviceKind == DeviceInfoManager.TEXT_PUMP )
            {
                li.Add( "��վЭ��", _info.PumpCommunicationProtocolVersion );
            }

            li.Add( string.Empty  );

            for( int i=0; i<_info.Tally.Count; i++ )
            {
                TallyItem ti = _info.Tally[ i ];
                li.Add( ti.Name, ti.List.Count );
                cmbListName.Items.Add( ti.Name );
            }
            if ( cmbListName.Items.Count > 0 )
            {
                cmbListName.SelectedIndex = 0;
            }
            this.txtDetail.Text = li.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetail_Click(object sender, System.EventArgs e)
        {
            string text = cmbListName.Text;
            if ( text != string.Empty )
            {
                TallyItem ti = GetTallyItem( text ); 
                if ( ti != null )
                    new frmTallyDetail( ti ).ShowDialog( this );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private TallyItem GetTallyItem( string name )
        {
            Tally t = _info.Tally;
            
            for ( int i=0; i<t.Count; i++ )
            {   
                if ( t[ i ].Name == name )
                    return t[ i ];
            }
            return null;
        }
	}
}
