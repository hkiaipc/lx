using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;

namespace DataQuery
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmDataQuery : System.Windows.Forms.Form
	{
		#region Members
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnOut;
		private System.Windows.Forms.DataGrid dataGridData;

		private DateTime _Dtime;
		private DateTime beginTime;
		private DateTime endTime;
		private DateTime _beginTime;
		private DateTime _endTime;
		private string _class="v_Gate";           //用于区分是口门还是泵站
		private string _address;     
		private DataTable _dt;               //存放数据表用于计算日用水量
		private SqlConnection strconn;   //数据库的 连接
		private string _department;   //用于区分是哪个所
		private string _place;  //用于区分是哪个站
		private DataTable _dtGate;
		private DataTable _dtPump;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DateTimePicker dtpbeginDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbbAddress;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lRYS;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpTime;
		private System.Windows.Forms.NumericUpDown nud1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dtpEndTime;
		private System.Windows.Forms.DateTimePicker dtpBeginTime;
       
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public frmDataQuery()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbbAddress = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpbeginDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lRYS = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnOut = new System.Windows.Forms.Button();
			this.dataGridData = new System.Windows.Forms.DataGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.nud1 = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpTime = new System.Windows.Forms.DateTimePicker();
			this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
			this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridData)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dtpBeginTime);
			this.groupBox1.Controls.Add(this.cbbAddress);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.dtpEndDate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.dtpbeginDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.lRYS);
			this.groupBox1.Controls.Add(this.dtpEndTime);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(8, 136);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(152, 384);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "阶段用水统计条件";
			// 
			// cbbAddress
			// 
			this.cbbAddress.Location = new System.Drawing.Point(16, 56);
			this.cbbAddress.Name = "cbbAddress";
			this.cbbAddress.Size = new System.Drawing.Size(112, 22);
			this.cbbAddress.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 9;
			this.label3.Text = "具体位置：";
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpEndDate.Location = new System.Drawing.Point(16, 216);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(112, 23);
			this.dtpEndDate.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 192);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "结束时间：";
			// 
			// dtpbeginDate
			// 
			this.dtpbeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpbeginDate.Location = new System.Drawing.Point(16, 120);
			this.dtpbeginDate.Name = "dtpbeginDate";
			this.dtpbeginDate.Size = new System.Drawing.Size(112, 23);
			this.dtpbeginDate.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "开始时间：";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(8, 288);
			this.label4.Name = "label4";
			this.label4.TabIndex = 4;
			this.label4.Text = "阶段用水量：";
			// 
			// lRYS
			// 
			this.lRYS.BackColor = System.Drawing.SystemColors.Control;
			this.lRYS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lRYS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lRYS.Location = new System.Drawing.Point(16, 320);
			this.lRYS.Name = "lRYS";
			this.lRYS.Size = new System.Drawing.Size(120, 40);
			this.lRYS.TabIndex = 5;
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "口门",
														   "泵站"});
			this.comboBox1.Location = new System.Drawing.Point(16, 64);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(112, 22);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.Text = "口门";
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(16, 528);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(56, 40);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "查询";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnOut
			// 
			this.btnOut.Location = new System.Drawing.Point(88, 528);
			this.btnOut.Name = "btnOut";
			this.btnOut.Size = new System.Drawing.Size(56, 40);
			this.btnOut.TabIndex = 2;
			this.btnOut.Text = "输出";
			this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
			// 
			// dataGridData
			// 
			this.dataGridData.DataMember = "";
			this.dataGridData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dataGridData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridData.Location = new System.Drawing.Point(176, 0);
			this.dataGridData.Name = "dataGridData";
			this.dataGridData.ReadOnly = true;
			this.dataGridData.Size = new System.Drawing.Size(852, 749);
			this.dataGridData.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Controls.Add(this.btnOut);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(176, 749);
			this.panel1.TabIndex = 5;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkBox1);
			this.groupBox3.Controls.Add(this.comboBox1);
			this.groupBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox3.Location = new System.Drawing.Point(8, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(152, 112);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "用水统计基本条件";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(16, 24);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(112, 24);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "阶段用水统计";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.nud1);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.dtpTime);
			this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox2.Location = new System.Drawing.Point(8, 176);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(152, 136);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "日用水统计条件";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(80, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 23);
			this.label6.TabIndex = 3;
			this.label6.Text = "时";
			// 
			// nud1
			// 
			this.nud1.Location = new System.Drawing.Point(16, 88);
			this.nud1.Maximum = new System.Decimal(new int[] {
																 23,
																 0,
																 0,
																 0});
			this.nud1.Name = "nud1";
			this.nud1.Size = new System.Drawing.Size(56, 23);
			this.nud1.TabIndex = 2;
			this.nud1.Value = new System.Decimal(new int[] {
															   6,
															   0,
															   0,
															   0});
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.TabIndex = 0;
			this.label5.Text = "时间：";
			// 
			// dtpTime
			// 
			this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTime.Location = new System.Drawing.Point(16, 48);
			this.dtpTime.Name = "dtpTime";
			this.dtpTime.Size = new System.Drawing.Size(112, 23);
			this.dtpTime.TabIndex = 1;
			// 
			// dtpEndTime
			// 
			this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtpEndTime.Location = new System.Drawing.Point(16, 248);
			this.dtpEndTime.Name = "dtpEndTime";
			this.dtpEndTime.ShowUpDown = true;
			this.dtpEndTime.Size = new System.Drawing.Size(112, 23);
			this.dtpEndTime.TabIndex = 8;
			// 
			// dtpBeginTime
			// 
			this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtpBeginTime.Location = new System.Drawing.Point(16, 152);
			this.dtpBeginTime.Name = "dtpBeginTime";
			this.dtpBeginTime.ShowUpDown = true;
			this.dtpBeginTime.Size = new System.Drawing.Size(112, 23);
			this.dtpBeginTime.TabIndex = 11;
			// 
			// frmDataQuery
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(1028, 749);
			this.Controls.Add(this.dataGridData);
			this.Controls.Add(this.panel1);
			this.Name = "frmDataQuery";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用水数据统计";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridData)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nud1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run (new frmDataQuery());
		}
        
		#region ReadConfig
		/// <summary>
		/// Read System's App.config
		/// </summary>
		private void ReadConfig()
		{
			System.Collections.Specialized.NameValueCollection nvc=System.Configuration.ConfigurationSettings.AppSettings;
			string stringcon=nvc["ConnString"];
			string department=nvc["Department"];
			string place=nvc["Place"];

			strconn=new SqlConnection(stringcon);
			this._department=department;
			this._place=place;
		}
		#endregion

		#region DayExToExcel
		private void GateDataDayToExcel()
		{
			_Dtime=System.Convert.ToDateTime(this.dtpTime.Value.ToShortDateString()+" "+this.nud1.Value.ToString()+":00:00");

			try
			{
				DataTable dt=(DataTable)this.dataGridData.DataSource;
				if(dt==null)
				{
					MessageBox.Show("没有可导出的数据!");
					return;
				}
				if(dt.Rows.Count==0)
				{
					MessageBox.Show("没有可导出的数据!");
					return;
				}

				GateDataDayPrint gdp=new GateDataDayPrint(this._Dtime,this.dataGridData.DataSource as DataTable );
				gdp.Export();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void PumpDataDayToExcel()
		{
			_Dtime=System.Convert.ToDateTime(this.dtpTime.Value.ToShortDateString()+" "+this.nud1.Value.ToString()+":00:00");
	
			try
			{
				DataTable dt=(DataTable)this.dataGridData.DataSource;
				if(dt==null)
				{
					MessageBox.Show("没有可以导出的数据!");
					return;
				}
				if(dt.Rows.Count==0)
				{
					MessageBox.Show("没有可以导出的数据!");
					return;
				}
				PumpDataDayPrint pdp=new PumpDataDayPrint(this._Dtime,this.dataGridData.DataSource as DataTable );
				pdp.Export();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		#endregion

		#region JDExToExcel

		private void GateDatasToExcel()
		{ 
			beginTime=System.Convert.ToDateTime(this.dtpbeginDate.Value.ToShortDateString()+" "+this.dtpBeginTime.Value.ToShortTimeString());
			endTime=System.Convert.ToDateTime(this.dtpEndDate.Value.ToShortDateString()+" "+this.dtpEndTime.Value.ToShortTimeString());

			try
			{
				DataTable dt=(DataTable)this.dataGridData.DataSource;
				if(dt==null)
				{
					MessageBox.Show("没有可导出的数据!");
					return;
				}
				if(dt.Rows.Count==0)
				{
					MessageBox.Show("没有可导出的数据!");
					return;
				}

				GateDatasPrint gdp=new GateDatasPrint(this.beginTime,this.endTime,this.dataGridData.DataSource as DataTable );
				gdp.Export();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void PumpDatasToExcel()
		{
			beginTime=System.Convert.ToDateTime(this.dtpbeginDate.Value.ToShortDateString()+" "+this.dtpBeginTime.Value.ToShortTimeString());
			endTime=System.Convert.ToDateTime(this.dtpEndDate.Value.ToShortDateString()+" "+this.dtpEndTime.Value.ToShortTimeString());
           
			try
			{
				DataTable dt=(DataTable)this.dataGridData.DataSource;
				if(dt==null)
				{
					MessageBox.Show("没有可以导出的数据!");
					return;
				}
				if(dt.Rows.Count==0)
				{
					MessageBox.Show("没有可以导出的数据!");
					return;
				}
				PumpDatasPrint pdp=new PumpDatasPrint(this.beginTime,this.endTime,this.dataGridData.DataSource as DataTable );
				pdp.Export();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		#endregion

		#region DayQuery
		private void DayQuery()
		{
			_Dtime=System.Convert.ToDateTime(this.dtpTime.Value.ToShortDateString()+" "+this.nud1.Value.ToString()+":00:00");
			_beginTime=_Dtime.AddMinutes(-10);
			_endTime=_Dtime.AddMinutes(10);
			try
			{
				this.ReadConfig();
				strconn.Open();
                
				if(this.comboBox1.Text=="口门")
				{
					this.Text="口门数据查询";
				//	this.GateDataDayQuery();
					this.GateQuery();
				}
               
				else if(this.comboBox1.Text=="泵站")
				{
					this.Text="泵站数据查询";
				//	this.PumpDataDayQuery();
					this.PumpQuery();
				}

				strconn.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		#endregion

		#region JDQuery
		private void JDQuery()
		{
			beginTime=System.Convert.ToDateTime(this.dtpbeginDate.Value.ToShortDateString()+" "+this.dtpBeginTime.Value.ToShortTimeString());
			endTime=System.Convert.ToDateTime(this.dtpEndDate.Value.ToShortDateString()+" "+this.dtpEndTime.Value.ToShortTimeString());
			this._address=this.cbbAddress.Text.ToString().Trim();

			try
			{
				this.ReadConfig();
				
				strconn.Open();
                
				if(this.comboBox1.Text=="口门")
				{
					this.Text="口门数据查询";
					this.GateDatasQuery();
					this.statisticJDUse(); 
				}
               
				else if(this.comboBox1.Text=="泵站")
				{
					this.Text="泵站数据查询";
					this.PumpDatasQuery();
					this.statisticJDUse();
				}

				strconn.Close();

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

		}
		#endregion

		#region Buttons_Click

		private void btnOK_Click(object sender, System.EventArgs e)
		{ 
			try
			{
				if(this.checkBox1.Checked)
					this.JDQuery();
				else
					this.DayQuery();
			}
			catch(Exception ex)
			{ 
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnOut_Click(object sender, System.EventArgs e)
		{
			if(this.checkBox1.Checked)
			{
				if(this.comboBox1.Text=="口门")
				{
					this.GateDatasToExcel();
				}
				else
				{
					this.PumpDatasToExcel();
				}
			}
			else
			{
				if(this.comboBox1.Text=="口门")
				{
					this.GateDataDayToExcel();
				}
				else
				{
					this.PumpDataDayToExcel();
				}
			}
            
		}

		#endregion

		#region GateQuery
		private void GateQuery()
		{
			int nn=_Dtime.Hour*60*60; //将当前时间转化为秒

			//添加Address
			string sql1=string.Format("select Address from v_Gate order by Id_Pole asc");
			DataSet ds1=new DataSet();
			SqlDataAdapter ada1=new SqlDataAdapter(sql1,strconn);
			ada1.Fill(ds1,"GateDay");
			this._dtGate=ds1.Tables["GateDay"];
            //准确查找
			string sql2=string.Format("select Address,strTime,BeforeLevel,BehindLevel,Height,Flux,ReWater,TuWater from v_GateDatas where StrTime between '{0}' and '{1}'",_beginTime,_endTime);
			DataSet ds2=new DataSet();
			SqlDataAdapter ada2=new SqlDataAdapter(sql2,strconn);
			ada2.Fill(ds2,"dt2");

			DataColumn col = ds2.Tables["dt2"].Columns.Add("YesTuWater",typeof(Int32));
			DataColumn colm= ds2.Tables["dt2"].Columns.Add("DayWaUse",typeof(Int32));
			DataColumn coln= ds2.Tables["dt2"].Columns.Add("AllWater",typeof(Int32));
            
			//昨日总用水量
			for(int k=0;k<ds2.Tables["dt2"].Rows.Count;k++)
			{
				string str="select Address,TuWater from v_GateDatas where Address='";
				str=str+ds2.Tables["dt2"].Rows[k]["Address"].ToString();
				str=str+"'and strTime between'";
				str=str+_beginTime.AddDays(-1);
				str=str+"'and'";
				str=str+_endTime.AddDays(-1);
				str=str+"' ";

				SqlDataAdapter ada3=new SqlDataAdapter(str,strconn);
				DataSet ds3=new DataSet();
				ada3.Fill(ds3,"t");
				ada3.Dispose();

				for(int n=0;n<ds2.Tables["dt2"].Rows.Count;n++)
				{
					for(int m=0;m<ds3.Tables["t"].Rows.Count;m++)
					{
						if(ds2.Tables["dt2"].Rows[n]["Address"].ToString()==ds3.Tables["t"].Rows[m]["Address"].ToString())
						{
							ds2.Tables["dt2"].Rows[n]["YesTuWater"]=Convert.ToInt32(ds3.Tables["t"].Rows[m]["TuWater"]);
						}
						continue;
					}
				}
				//如果昨天这个时刻没有数据的处理,在两小时范围内取最大的流量算昨天该时刻的累计用水量。
				for(int r=0;r<ds2.Tables["dt2"].Rows.Count;r++)
				{
					if(ds2.Tables["dt2"].Rows[r]["YesTuWater"]==DBNull.Value)
					{
						string sql3="select top 1 Address,strTime,Flux,TuWater from v_GateDatas where Address='";
						sql3=sql3+ds2.Tables["dt2"].Rows[r]["Address"].ToString();
						sql3=sql3+"' and strTime between '";
						sql3=sql3+_beginTime.AddHours(-25);
						sql3=sql3+"' and '";
						sql3=sql3+_endTime.AddHours(-23);
						sql3=sql3+"' order by Flux desc";

						DataSet dst=new DataSet();
						SqlDataAdapter adat=new SqlDataAdapter(sql3,strconn);
						adat.Fill(dst,"dtt");

						for(int a=0;a<dst.Tables["dtt"].Rows.Count;a++)
						{
							if(ds2.Tables["dt2"].Rows[r]["Address"].ToString()==dst.Tables["dtt"].Rows[a]["Address"].ToString())
							{
								DateTime dateTime1=Convert.ToDateTime(dst.Tables["dtt"].Rows[a]["strTime"]);
								int mm1=dateTime1.Hour*60*60+dateTime1.Minute*60;
								ds2.Tables["dt2"].Rows[r]["YesTuWater"]=Convert.ToInt32(dst.Tables["dtt"].Rows[a]["TuWater"])
									+Convert.ToInt32(dst.Tables["dtt"].Rows[a]["Flux"])*(nn-mm1);
							}
							continue;
						}
//						ds2.Tables["dt2"].Rows[r]["YesTuWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["TuWater"])
//							-(Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["Flux"])*24*60*60);						
					}
					ds2.Tables["dt2"].Rows[r]["DayWaUse"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["TuWater"])
						-Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["YesTuWater"]);
					ds2.Tables["dt2"].Rows[r]["AllWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["ReWater"])
						+Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["TuWater"]);
//					if(ds2.Tables["dt2"].Rows[r]["TuWater"].ToString()==ds2.Tables["dt2"].Rows[r]["DayWaUse"].ToString())
//					{
//						ds2.Tables["dt2"].Rows[r]["DayWaUse"]=(Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["Flux"])
//							*24*60*60);
//					}
					continue;
				}

			}

			DataColumn col0 = _dtGate.Columns.Add("strTime",typeof(DateTime));
			DataColumn col1 = _dtGate.Columns.Add("BeforeLevel",typeof(Int32));
			DataColumn col2 = _dtGate.Columns.Add("BehindLevel",typeof(Int32));
			DataColumn col3 = _dtGate.Columns.Add("Height",typeof(Int32));
			DataColumn col4 = _dtGate.Columns.Add("Flux",typeof(Int32));
			DataColumn col5 = _dtGate.Columns.Add("ReWater",typeof(Int32));
			DataColumn col6 = _dtGate.Columns.Add("TuWater",typeof(Int32));
			DataColumn col7 = _dtGate.Columns.Add("YesTuWater",typeof(Int32));
			DataColumn col8 = _dtGate.Columns.Add("DayWaUse",typeof(Int32));
			DataColumn col9 = _dtGate.Columns.Add("AllWater",typeof(Int32));

			try
			{
				for(int i=0;i<_dtGate.Rows.Count;i++)
				{
					for(int j=0;j<ds2.Tables["dt2"].Rows.Count;j++)
					{
						if(_dtGate.Rows[i]["Address"].ToString()==ds2.Tables["dt2"].Rows[j]["Address"].ToString())
						{
							_dtGate.Rows[i]["strTime"]=Convert.ToDateTime(ds2.Tables["dt2"].Rows[j]["strTime"]);
							_dtGate.Rows[i]["BeforeLevel"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["Beforelevel"]);
							_dtGate.Rows[i]["BehindLevel"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["Behindlevel"]);
							_dtGate.Rows[i]["Height"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["Height"]);
							_dtGate.Rows[i]["Flux"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["Flux"]);
							_dtGate.Rows[i]["ReWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["ReWater"]);
							_dtGate.Rows[i]["TuWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["TuWater"]);
							_dtGate.Rows[i]["YesTuWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["YesTuWater"]);
							_dtGate.Rows[i]["DayWaUse"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["DayWaUse"]);
							_dtGate.Rows[i]["AllWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["AllWater"]);

						}
						continue;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		    //今日该时刻无数据及昨日该时刻有数据或无数据的情况。
            //处理该时刻无数据的情况, 取两小时内流量最大的算出该时刻的累计用水量。
			for(int t=0;t<_dtGate.Rows.Count;t++)
			{
				if(_dtGate.Rows[t]["strTime"]==DBNull.Value)
				{
					string str1="select top 1 Address,strTime,BeforeLevel,BehindLevel,Height,TuWater,ReWater,Flux from v_GateDatas where Address='";
					str1=str1+_dtGate.Rows[t]["Address"].ToString();
					str1=str1+"'and strTime between '";
					str1=str1+_beginTime.AddHours(-1);
					str1=str1+"' and '";
					str1=str1+_endTime.AddHours(1);
					str1=str1+"' order by Flux desc";

					DataSet dss1=new DataSet();
					SqlDataAdapter adaa1=new SqlDataAdapter(str1,strconn);
					adaa1.Fill(dss1,"dtt1");
		
					for(int tt=0;tt<dss1.Tables["dtt1"].Rows.Count;tt++)
					{
						if(_dtGate.Rows[t]["Address"].ToString()==dss1.Tables["dtt1"].Rows[tt]["Address"].ToString())
						{
							DateTime dateTime=Convert.ToDateTime(dss1.Tables["dtt1"].Rows[tt]["strTime"]);
							int mm=dateTime.Hour*60*60+dateTime.Minute*60;
							
							_dtGate.Rows[t]["strTime"]=Convert.ToDateTime(_Dtime);
						//	_dtGate.Rows[t]["strTime"]=Convert.ToDateTime(dss1.Tables["dtt1"].Rows[tt]["strTIme"]);
							_dtGate.Rows[t]["Beforelevel"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["BeforeLevel"]);
							_dtGate.Rows[t]["BehindLevel"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["BehindLevel"]);
							_dtGate.Rows[t]["Height"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["Height"]);
							_dtGate.Rows[t]["Flux"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["Flux"]);
							_dtGate.Rows[t]["ReWater"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["ReWater"])
								-Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["Flux"])*(nn-mm);
							_dtGate.Rows[t]["TuWater"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["TuWater"])
								+Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["Flux"])*(nn-mm);
					    //	_dtGate.Rows[t]["DayWaUse"]=(Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["Flux"])
						//		*24*60*60);
							_dtGate.Rows[t]["AllWater"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["ReWater"])
								+Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["TuWater"]);
						//	_dtGate.Rows[t]["YesTuWater"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["TuWater"])
						//		-Convert.ToInt32(_dtGate.Rows[t]["DayWaUse"]);
						}
						continue;
					}
				   //昨日该时刻的累计用水量 有直接取出。
					string str2="select Address,TuWater from v_GateDatas where Address='";
					str2=str2+_dtGate.Rows[t]["Address"].ToString();
					str2=str2+"'and strTime between '";
					str2=str2+_beginTime.AddDays(-1);
					str2=str2+"' and '";
					str2=str2+_endTime.AddDays(-1);
					str2=str2+"'";

					DataSet dss2=new DataSet();
					SqlDataAdapter adaa2=new SqlDataAdapter(str2,strconn);
					adaa2.Fill(dss2,"dtt2");

					for(int tt1=0;tt1<dss2.Tables["dtt2"].Rows.Count;tt1++)
					{
						if(_dtGate.Rows[t]["Address"].ToString()==dss2.Tables["dtt2"].Rows[tt1]["Address"].ToString())
						{
							_dtGate.Rows[t]["YesTuWater"]=Convert.ToInt32(dss2.Tables["dtt2"].Rows[tt1]["TuWater"]);
							_dtGate.Rows[t]["DayWaUse"]=Convert.ToInt32(_dtGate.Rows[t]["TuWater"])
								-Convert.ToInt32(_dtGate.Rows[t]["YesTuWater"]);
						}
						continue;
					}
             
			    //昨日该时刻无数据的处理
					if(_dtGate.Rows[t]["YesTuWater"]==DBNull.Value)
					{
						string sql4="select top 1 Address,strTime,TuWater,Flux from v_GateDatas where Address='";
						sql4=sql4+_dtGate.Rows[t]["Address"].ToString();
						sql4=sql4+"' and strTime between '";
						sql4=sql4+_beginTime.AddHours(-25);
						sql4=sql4+"' and '";
						sql4=sql4+_endTime.AddHours(-23);
						sql4=sql4+"' order by Flux desc";

						DataSet ds4=new DataSet();
						SqlDataAdapter ada4=new SqlDataAdapter(sql4,strconn);
						ada4.Fill(ds4,"dt4");

						for(int b=0;b<ds4.Tables["dt4"].Rows.Count;b++)
						{
							if(_dtGate.Rows[t]["Address"].ToString()==ds4.Tables["dt4"].Rows[b]["Address"].ToString())
							{
								DateTime dateTime4=Convert.ToDateTime(ds4.Tables["dt4"].Rows[b]["strTime"]);
								int mm4=dateTime4.Hour*60*60+dateTime4.Minute*60;
								_dtGate.Rows[t]["YesTuWater"]=Convert.ToInt32(ds4.Tables["dt4"].Rows[b]["TuWater"])
									+Convert.ToInt32(ds4.Tables["dt4"].Rows[b]["Flux"])*(nn-mm4);
								_dtGate.Rows[t]["DayWaUse"]=Convert.ToInt32(_dtGate.Rows[t]["TuWater"])
									-Convert.ToInt32(_dtGate.Rows[t]["YesTuWater"]);
							}
							continue;
						}
					}


				}
//				_dtGate.Rows[t]["AllWater"]=Convert.ToInt32(_dtGate.Rows[t]["ReWater"])
//					+Convert.ToInt32(_dtGate.Rows[t]["TuWater"]);
				continue;
			}

			this.dataGridData.DataSource=_dtGate;
		}

		#endregion

		#region PumpQuery
		private void PumpQuery()
		{
			int nn=_Dtime.Hour*60*60; //将当前时间转化为秒

			//添加Address
			string sql1=string.Format("select Address from v_Pump order by Id_Pole asc");
			DataSet ds1=new DataSet();
			SqlDataAdapter ada1=new SqlDataAdapter(sql1,strconn);
			ada1.Fill(ds1,"PumpDay");
			this._dtPump=ds1.Tables["PumpDay"];
			//准确查找
			string sql2=string.Format("select Address,StrTime,Flux,Efficiency,ReWater,TuWater from V_PumpDatasHis where StrTime between '{0}' and '{1}'",_beginTime,_endTime);
			DataSet ds2=new DataSet();
			SqlDataAdapter ada2=new SqlDataAdapter(sql2,strconn);
			ada2.Fill(ds2,"dt2");

			DataColumn col = ds2.Tables["dt2"].Columns.Add("YesTuWater",typeof(Int32));
			DataColumn colm= ds2.Tables["dt2"].Columns.Add("DayWaUse",typeof(Int32));
			DataColumn coln= ds2.Tables["dt2"].Columns.Add("AllWater",typeof(Int32));
            
			//昨日总用水量
			for(int k=0;k<ds2.Tables["dt2"].Rows.Count;k++)
			{
				string str="select Address,TuWater from v_PumpDatasHis where Address='";
				str=str+ds2.Tables["dt2"].Rows[k]["Address"].ToString();
				str=str+"'and strTime between'";
				str=str+_beginTime.AddDays(-1);
				str=str+"'and'";
				str=str+_endTime.AddDays(-1);
				str=str+"' ";

				SqlDataAdapter ada3=new SqlDataAdapter(str,strconn);
				DataSet ds3=new DataSet();
				ada3.Fill(ds3,"t");
				ada3.Dispose();

				for(int n=0;n<ds2.Tables["dt2"].Rows.Count;n++)
				{
					for(int m=0;m<ds3.Tables["t"].Rows.Count;m++)
					{
						if(ds2.Tables["dt2"].Rows[n]["Address"].ToString()==ds3.Tables["t"].Rows[m]["Address"].ToString())
						{
							ds2.Tables["dt2"].Rows[n]["YesTuWater"]=Convert.ToInt32(ds3.Tables["t"].Rows[m]["TuWater"]);
						}
						continue;
					}
				}
				//如果昨天这个时刻没有数据的处理,在两小时范围内取最大的流量算昨天该时刻的累计用水量。
				for(int r=0;r<ds2.Tables["dt2"].Rows.Count;r++)
				{
					if(ds2.Tables["dt2"].Rows[r]["YesTuWater"]==DBNull.Value)
					{
						string sql3="select top 1 Address,strTime,Flux,TuWater from v_PumpDatasHis where Address='";
						sql3=sql3+ds2.Tables["dt2"].Rows[r]["Address"].ToString();
						sql3=sql3+"' and strTime between '";
						sql3=sql3+_beginTime.AddHours(-25);
						sql3=sql3+"' and '";
						sql3=sql3+_endTime.AddHours(-23);
						sql3=sql3+"' order by Flux desc";

						DataSet dst=new DataSet();
						SqlDataAdapter adat=new SqlDataAdapter(sql3,strconn);
						adat.Fill(dst,"dtt");

						for(int a=0;a<dst.Tables["dtt"].Rows.Count;a++)
						{
							if(ds2.Tables["dt2"].Rows[r]["Address"].ToString()==dst.Tables["dtt"].Rows[a]["Address"].ToString())
							{
								DateTime dateTime1=Convert.ToDateTime(dst.Tables["dtt"].Rows[a]["strTime"]);
								int mm1=dateTime1.Hour*60*60+dateTime1.Minute*60;
								ds2.Tables["dt2"].Rows[r]["YesTuWater"]=Convert.ToInt32(dst.Tables["dtt"].Rows[a]["TuWater"])
									+Convert.ToInt32(dst.Tables["dtt"].Rows[a]["Flux"])*(nn-mm1);
							}
							continue;
						}					
					}
					ds2.Tables["dt2"].Rows[r]["DayWaUse"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["TuWater"])
						-Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["YesTuWater"]);
					ds2.Tables["dt2"].Rows[r]["AllWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["ReWater"])
						+Convert.ToInt32(ds2.Tables["dt2"].Rows[r]["TuWater"]);
					
					continue;
				}

			}

			DataColumn col0 = _dtPump.Columns.Add("strTime",typeof(DateTime));
			
			DataColumn col3 = _dtPump.Columns.Add("Efficiency",typeof(Int32));
			DataColumn col4 = _dtPump.Columns.Add("Flux",typeof(Int32));
			DataColumn col5 = _dtPump.Columns.Add("ReWater",typeof(Int32));
			DataColumn col6 = _dtPump.Columns.Add("TuWater",typeof(Int32));
			DataColumn col7 = _dtPump.Columns.Add("YesTuWater",typeof(Int32));
			DataColumn col8 = _dtPump.Columns.Add("DayWaUse",typeof(Int32));
			DataColumn col9 = _dtPump.Columns.Add("AllWater",typeof(Int32));

			try
			{
				for(int i=0;i<_dtPump.Rows.Count;i++)
				{
					for(int j=0;j<ds2.Tables["dt2"].Rows.Count;j++)
					{
						if(_dtPump.Rows[i]["Address"].ToString()==ds2.Tables["dt2"].Rows[j]["Address"].ToString())
						{
							_dtPump.Rows[i]["strTime"]=Convert.ToDateTime(ds2.Tables["dt2"].Rows[j]["strTime"]);
							
							_dtPump.Rows[i]["Efficiency"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["Efficiency"]);
							_dtPump.Rows[i]["Flux"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["Flux"]);
							_dtPump.Rows[i]["ReWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["ReWater"]);
							_dtPump.Rows[i]["TuWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["TuWater"]);
							_dtPump.Rows[i]["YesTuWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["YesTuWater"]);
							_dtPump.Rows[i]["DayWaUse"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["DayWaUse"]);
							_dtPump.Rows[i]["AllWater"]=Convert.ToInt32(ds2.Tables["dt2"].Rows[j]["AllWater"]);

						}
						continue;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			//今日该时刻无数据及昨日该时刻有数据或无数据的情况。
			//处理该时刻无数据的情况, 取两小时内流量最大的算出该时刻的累计用水量。
			for(int t=0;t<_dtPump.Rows.Count;t++)
			{
				if(_dtPump.Rows[t]["strTime"]==DBNull.Value)
				{
					string str1="select top 1 Address,strTime,Efficiency,TuWater,ReWater,Flux from v_PumpDatasHis where Address='";
					str1=str1+_dtPump.Rows[t]["Address"].ToString();
					str1=str1+"'and strTime between '";
					str1=str1+_beginTime.AddHours(-1);
					str1=str1+"' and '";
					str1=str1+_endTime.AddHours(1);
					str1=str1+"' order by Flux desc";

					DataSet dss1=new DataSet();
					SqlDataAdapter adaa1=new SqlDataAdapter(str1,strconn);
					adaa1.Fill(dss1,"dtt1");
		
					for(int tt=0;tt<dss1.Tables["dtt1"].Rows.Count;tt++)
					{
						if(_dtPump.Rows[t]["Address"].ToString()==dss1.Tables["dtt1"].Rows[tt]["Address"].ToString())
						{
							DateTime dateTime=Convert.ToDateTime(dss1.Tables["dtt1"].Rows[tt]["strTime"]);
							int mm=dateTime.Hour*60*60+dateTime.Minute*60;
							
							_dtPump.Rows[t]["strTime"]=Convert.ToDateTime(_Dtime);
						
							_dtPump.Rows[t]["Efficiency"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["Efficiency"]);
							_dtPump.Rows[t]["Flux"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["Flux"]);
							_dtPump.Rows[t]["ReWater"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["ReWater"])
								-Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["Flux"])*(nn-mm);
							_dtPump.Rows[t]["TuWater"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["TuWater"])
								+Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["Flux"])*(nn-mm);
							_dtPump.Rows[t]["AllWater"]=Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["ReWater"])
								+Convert.ToInt32(dss1.Tables["dtt1"].Rows[tt]["TuWater"]);
							
						}
						continue;
					}
					//昨日该时刻的累计用水量 有直接取出。
					string str2="select Address,TuWater from v_PumpDatasHis where Address='";
					str2=str2+_dtPump.Rows[t]["Address"].ToString();
					str2=str2+"'and strTime between '";
					str2=str2+_beginTime.AddDays(-1);
					str2=str2+"' and '";
					str2=str2+_endTime.AddDays(-1);
					str2=str2+"'";

					DataSet dss2=new DataSet();
					SqlDataAdapter adaa2=new SqlDataAdapter(str2,strconn);
					adaa2.Fill(dss2,"dtt2");

					for(int tt1=0;tt1<dss2.Tables["dtt2"].Rows.Count;tt1++)
					{
						if(_dtPump.Rows[t]["Address"].ToString()==dss2.Tables["dtt2"].Rows[tt1]["Address"].ToString())
						{
							_dtPump.Rows[t]["YesTuWater"]=Convert.ToInt32(dss2.Tables["dtt2"].Rows[tt1]["TuWater"]);
							_dtPump.Rows[t]["DayWaUse"]=Convert.ToInt32(_dtPump.Rows[t]["TuWater"])
								-Convert.ToInt32(_dtPump.Rows[t]["YesTuWater"]);
						}
						continue;
					}
             
					//昨日该时刻无数据的处理
					if(_dtPump.Rows[t]["YesTuWater"]==DBNull.Value)
					{
						string sql4="select top 1 Address,strTime,TuWater,Flux from v_PumpDatasHis where Address='";
						sql4=sql4+_dtPump.Rows[t]["Address"].ToString();
						sql4=sql4+"' and strTime between '";
						sql4=sql4+_beginTime.AddHours(-25);
						sql4=sql4+"' and '";
						sql4=sql4+_endTime.AddHours(-23);
						sql4=sql4+"' order by Flux desc";

						DataSet ds4=new DataSet();
						SqlDataAdapter ada4=new SqlDataAdapter(sql4,strconn);
						ada4.Fill(ds4,"dt4");

						for(int b=0;b<ds4.Tables["dt4"].Rows.Count;b++)
						{
							if(_dtPump.Rows[t]["Address"].ToString()==ds4.Tables["dt4"].Rows[b]["Address"].ToString())
							{
								DateTime dateTime4=Convert.ToDateTime(ds4.Tables["dt4"].Rows[b]["strTime"]);
								int mm4=dateTime4.Hour*60*60+dateTime4.Minute*60;
								_dtPump.Rows[t]["YesTuWater"]=Convert.ToInt32(ds4.Tables["dt4"].Rows[b]["TuWater"])
									+Convert.ToInt32(ds4.Tables["dt4"].Rows[b]["Flux"])*(nn-mm4);
								_dtPump.Rows[t]["DayWaUse"]=Convert.ToInt32(_dtPump.Rows[t]["TuWater"])
									-Convert.ToInt32(_dtPump.Rows[t]["YesTuWater"]);
							}
							continue;
						}
					}


				}
				
				continue;
			}

			this.dataGridData.DataSource=_dtPump;
		}

		#endregion

		#region DayDatasQuery....
//		private void GateDataDayQuery()
//		{
//			string sql1=string.Format("select Address,strTime,BeforeLevel,BehindLevel,Height,Flux,ReWater,TuWater from v_GateDatas where StrTime between '{0}' and '{1}'",_beginTime,_endTime);
//
//			DataSet ds=new DataSet();
//			SqlDataAdapter ada=new SqlDataAdapter(sql1,strconn);
//			ada.Fill(ds,"GateDay");
//           
//			DataColumn col =ds.Tables["GateDay"].Columns.Add("YesTuWater",typeof(Int32));
//			DataColumn col1=ds.Tables["GateDay"].Columns.Add("DayWaUse",typeof(Int32));
//			DataColumn col2=ds.Tables["GateDay"].Columns.Add("AllWater",typeof(Int32));
//           
//			try
//			{             
//				//昨日总水量
//				for(int j=0;j<ds.Tables["GateDay"].Rows.Count;j++)
//				{
//					string str="select Address,TuWater from v_GateDatas where Address='";
//					str=str+ds.Tables["GateDay"].Rows[j]["Address"].ToString();
//					str=str+"'and strTime between'";
//					str=str+_beginTime.AddDays(-1);
//					str=str+"'and'";
//					str=str+_endTime.AddDays(-1);
//					str=str+"'";
//               
//					SqlDataAdapter da=new SqlDataAdapter(str,strconn);
//					DataSet dst=new DataSet();
//					da.Fill(dst,"t");
//					da.Dispose();
//              
//					for(int k=0;k<dst.Tables["t"].Rows.Count;k++)
//					{
//						for(int l=0;l<ds.Tables["GateDay"].Rows.Count;l++)
//						{
//							if(ds.Tables["GateDay"].Rows[l]["Address"].ToString()==dst.Tables["t"].Rows[k]["Address"].ToString())
//							{
//								ds.Tables["GateDay"].Rows[l]["YesTuWater"]=System.Convert.ToInt32(dst.Tables["t"].Rows[k]["TuWater"]);
//                                
//							}
//                                                 
//							continue;
//						}
//					}
//				}
//				for(int m=0;m<ds.Tables["GateDay"].Rows.Count;m++)
//				{
//					if(ds.Tables["GateDay"].Rows[m]["YesTuWater"]==DBNull.Value)
// 
//						ds.Tables["GateDay"].Rows[m]["YesTuWater"]=0;      
//				}
//			}
//            
//			catch(Exception ex)
//			{
//				MessageBox.Show(ex.ToString());
//			}
//
//			//通过循环排除重复的项
//			for( int z=0;z<ds.Tables["GateDay"].Rows.Count;z++)
//			{
//				for(int i=z+1;i<ds.Tables["GateDay"].Rows.Count;i++)
//				{
//					DataRow row=ds.Tables["GateDay"].Rows[i];
//					if( ds.Tables["GateDay"].Rows[z]["Address"].ToString()==ds.Tables["GateDay"].Rows[i]["Address"].ToString())
//					{
//						ds.Tables["GateDay"].Rows.Remove(row);
//					}
//				}
//			}
//           
//			//总输入水量
//			for(int r=0;r<ds.Tables["GateDay"].Rows.Count;r++)
//			{
//				ds.Tables["GateDay"].Rows[r]["AllWater"]=System.Convert.ToInt32(ds.Tables["GateDay"].Rows[r]["ReWater"].ToString())
//					+System.Convert.ToInt32(ds.Tables["GateDay"].Rows[r]["TuWater"]);
//				continue;
//			}
//
//			try
//			{
//				//日用水量
//				for(int n=0;n<ds.Tables["GateDay"].Rows.Count;n++)
//				{
//					ds.Tables["GateDay"].Rows[n]["DayWaUse"]=System.Convert.ToInt32(ds.Tables["GateDay"].Rows[n]["TuWater"])
//						-System.Convert.ToInt32(ds.Tables["GateDay"].Rows[n]["YesTuWater"]);
//                    
//					continue;
//				}
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show(ex.ToString());
//			}
//            
//
//			this.dataGridData.DataSource=ds.Tables["GateDay"];
//		}
//
//       
//		private void PumpDataDayQuery()
//		{
//			string sql2=string.Format("select Address,StrTime,Flux,Efficiency,ReWater,TuWater from V_PumpDatasHis where StrTime between '{0}' and '{1}'",_beginTime,_endTime);
//            
//			DataSet ds1=new DataSet();
//			SqlDataAdapter ada1=new SqlDataAdapter(sql2,strconn);
//			ada1.Fill(ds1,"PumpDataDay");
//
//			DataColumn col =ds1.Tables["PumpDataDay"].Columns.Add("YesTuWater",typeof(Int32));
//			DataColumn col1=ds1.Tables["PumpDataDay"].Columns.Add("DayWaterUse",typeof(Int32));
//			DataColumn col2=ds1.Tables["PumpDataDay"].Columns.Add("AllWater",typeof(Int32));
//
//			//昨日剩余水量
//			for(int j=0;j<ds1.Tables["PumpDataDay"].Rows.Count;j++)
//			{
//				string str="select Address,TuWater from v_PumpDatasHis where Address='";
//				str=str+ds1.Tables["PumpDataDay"].Rows[j]["Address"].ToString();
//				str=str+"'and strTime between'";
//				str=str+_beginTime.AddDays(-1);
//				str=str+"'and'";
//				str=str+_endTime.AddDays(-1);
//				str=str+"'";
//				SqlDataAdapter da=new SqlDataAdapter(str,strconn);
//				DataSet dst=new DataSet();
//				da.Fill(dst,"t");
//				da.Dispose();
//
//				for(int k=0;k<dst.Tables["t"].Rows.Count;k++)
//				{
//					for(int l=0;l<ds1.Tables["PumpDataDay"].Rows.Count;l++)
//					{
//						if(ds1.Tables["PumpDataDay"].Rows[l]["Address"].ToString()==dst.Tables["t"].Rows[k]["Address"].ToString())
//							ds1.Tables["PumpDataDay"].Rows[l]["YesTuWater"]=System.Convert.ToInt32(dst.Tables["t"].Rows[k]["TuWater"]);
//						continue;
//					}
//				}
//			}
//			for(int m=0;m<ds1.Tables["PumpDataDay"].Rows.Count;m++)
//			{
//				if(ds1.Tables["PumpDataDay"].Rows[m]["YesTuWater"]==DBNull.Value)
// 
//					ds1.Tables["PumpDataDay"].Rows[m]["YesTuWater"]=0;      
//			}
//
//			//通过循环排除重复的项
//			for( int z=0;z<ds1.Tables["PumpDataDay"].Rows.Count;z++)
//			{
//				for(int i=z+1;i<ds1.Tables["PumpDataDay"].Rows.Count;i++)
//				{
//					DataRow row=ds1.Tables["PumpDataDay"].Rows[i];
//					if( ds1.Tables["PumpDataDay"].Rows[z]["Address"].ToString()==ds1.Tables["PumpDataDay"].Rows[i]["Address"].ToString())
//					{
//						ds1.Tables["PumpDataDay"].Rows.Remove(row);
//					}
//				}
//			}
//
//
//			//总输入水量
//			for(int r=0;r<ds1.Tables["PumpDataDay"].Rows.Count;r++)
//			{
//				ds1.Tables["PumpDataDay"].Rows[r]["AllWater"]=System.Convert.ToInt32(ds1.Tables["PumpDataDay"].Rows[r]["ReWater"].ToString())
//					+System.Convert.ToInt32(ds1.Tables["PumpDataDay"].Rows[r]["TuWater"].ToString());
//			}
//
//			//日用水量
//			for(int n=0;n<ds1.Tables["PumpDataDay"].Rows.Count;n++)
//			{
//				ds1.Tables["PumpDataDay"].Rows[n]["DayWaterUse"]=System.Convert.ToInt32(ds1.Tables["PumpDataDay"].Rows[n]["TuWater"].ToString())
//					-System.Convert.ToInt32(ds1.Tables["PumpDataDay"].Rows[n]["YesTuWater"].ToString());
//				continue;
//			}
//
//			this.dataGridData.DataSource=ds1.Tables["PumpDataDay"];
//		}
		#endregion

		#region JDDatasQuery
		#region   GateDatasQuery
		private void GateDatasQuery()
		{
			string sql1=string.Format("select Address,strTime,BeforeLevel,BehindLevel,Height,Flux,ReWater,TuWater from v_GateDatas where Address='{0}' and StrTime between '{1}' and '{2}' order by StrTime asc",_address,beginTime,endTime);

			DataSet ds=new DataSet();
			SqlDataAdapter ada=new SqlDataAdapter(sql1,strconn);
			ada.Fill(ds,"GateDatas");

			//           DataColumn col =ds.Tables["GateDatas"].Columns.Add("YesWaUse",typeof(Int32));
			//           DataColumn col1=ds.Tables["GateDatas"].Columns.Add("DayWaUse",typeof(Int32));
			/*                        
						//昨日总水量
						for(int j=0;j<ds.Tables["GateDatas"].Rows.Count;j++)
						{
							string str="select Address,TuWater from v_GateDatas where Address='";
							str=str+ds.Tables["GateDatas"].Rows[j]["Address"].ToString();
							str=str+"'and strTime between'";
							str=str+beginTime.AddDays(-1);
							str=str+"'and'";
							str=str+endTime.AddDays(-1);
							str=str+"'";
							SqlDataAdapter da=new SqlDataAdapter(str,strconn);
							DataSet dst=new DataSet();
							da.Fill(dst,"t");
							da.Dispose();

							for(int k=0;k<dst.Tables["t"].Rows.Count;k++)
							{
								for(int l=0;l<ds.Tables["GateDatas"].Rows.Count;l++)
								{
									if(ds.Tables["GateDatas"].Rows[l]["Address"].ToString()==dst.Tables["t"].Rows[k]["Address"].ToString())
									{
										if(dst.Tables["t"].Rows[k]["TuWater"]==null)
										{
											ds.Tables["GateDatas"].Rows[l]["YesWaUse"]=0;
										}    
										else
										{
											ds.Tables["GateDatas"].Rows[l]["YesWaUse"]=System.Convert.ToInt32(dst.Tables["t"].Rows[k]["TuWater"]);
										}
									}
                                                 
									continue;
								}
							}
						}
			*/
			//通过循环排除重复的项
			for( int z=0;z<ds.Tables["GateDatas"].Rows.Count;z++)
			{
				for(int i=z+1;i<ds.Tables["GateDatas"].Rows.Count;i++)
				{
					DataRow row=ds.Tables["GateDatas"].Rows[i];
					if(( ds.Tables["GateDatas"].Rows[z]["Address"].ToString()==ds.Tables["GateDatas"].Rows[i]["Address"].ToString())
						&&(ds.Tables["GateDatas"].Rows[z]["strTime"].ToString()==ds.Tables["GateDatas"].Rows[i]["strTime"].ToString()))
					{
						ds.Tables["GateDatas"].Rows.Remove(row);
					}
				}
			}

			//日用水量
			//               for(int n=0;n<ds.Tables["GateDatas"].Rows.Count;n++)
			//               {
			//                   ds.Tables["GateDatas"].Rows[n]["DayWaUse"]=System.Convert.ToInt32(ds.Tables["GateDatas"].Rows[n]["TuWater"])
			//                       -System.Convert.ToInt32(ds.Tables["GateDatas"].Rows[n]["YesWaUse"]);
			//                   continue;
			//               }
            
			this.dataGridData.DataSource=ds.Tables["GateDatas"];
			this._dt=ds.Tables["GateDatas"];
           
			//计算日用水
			// int r=ds.Tables["GateDatas"].Rows.Count;
			// this._rysh=(System.Convert.ToInt32(ds.Tables["GateDatas"].Rows[0]["ReWater"])
			//    -System.Convert.ToInt32(ds.Tables["GateDatas"].Rows[r]["ReWater"]));
 
           
          
		}
		#endregion

		#region  PumpDatasQuery

		private void PumpDatasQuery()
		{ 
			string sql2=string.Format("select Address,StrTime,Flux,Efficiency,ReWater,TuWater,Run from V_PumpDatasHis where Address='{0}' and StrTime between '{1}' and '{2}' order by StrTime asc",_address,beginTime,endTime);
            
			DataSet ds1=new DataSet();
			SqlDataAdapter ada1=new SqlDataAdapter(sql2,strconn);
			ada1.Fill(ds1,"PumpDatas");
			/*
						DataColumn col =ds1.Tables["PumpDatas"].Columns.Add("YesReWater",typeof(Int32));
						DataColumn col1=ds1.Tables["PumpDatas"].Columns.Add("DayWaterUse",typeof(Int32));

						//昨日剩余水量
						for(int j=0;j<ds1.Tables["PumpDatas"].Rows.Count;j++)
						{
							string str="select Address,ReWater from v_PumpDatasHis where Address='";
							str=str+ds1.Tables["PumpDatas"].Rows[j]["Address"].ToString();
							str=str+"'and strTime between'";
							str=str+beginTime.AddDays(-1);
							str=str+"'and'";
							str=str+endTime.AddDays(-1);
							str=str+"'";
							SqlDataAdapter da=new SqlDataAdapter(str,strconn);
							DataSet dst=new DataSet();
							da.Fill(dst,"t");
							da.Dispose();

							for(int k=0;k<dst.Tables["t"].Rows.Count;k++)
							{
								for(int l=0;l<ds1.Tables["PumpDatas"].Rows.Count;l++)
								{
									if(ds1.Tables["PumpDatas"].Rows[l]["Address"].ToString()==dst.Tables["t"].Rows[k]["Address"].ToString())
										ds1.Tables["PumpDatas"].Rows[l]["YesReWater"]=System.Convert.ToInt32(dst.Tables["t"].Rows[k]["ReWater"]);
									continue;
								}
							}
						}
			*/
			//通过循环排除重复的项
			for( int z=0;z<ds1.Tables["PumpDatas"].Rows.Count;z++)
			{
				for(int i=z+1;i<ds1.Tables["PumpDatas"].Rows.Count;i++)
				{
					DataRow row=ds1.Tables["PumpDatas"].Rows[i];
					if(( ds1.Tables["PumpDatas"].Rows[z]["Address"].ToString()==ds1.Tables["PumpDatas"].Rows[i]["Address"].ToString())
						&&(ds1.Tables["PumpDatas"].Rows[z]["strTime"].ToString()==ds1.Tables["PumpDatas"].Rows[i]["strTime"].ToString()))
					{
						ds1.Tables["PumpDatas"].Rows.Remove(row);
					}
				}
			}

			//日用水量
			//            for(int n=0;n<ds1.Tables["PumpDatas"].Rows.Count;n++)
			//            {
			//                ds1.Tables["PumpDatas"].Rows[n]["DayWaterUse"]=System.Convert.ToInt32(ds1.Tables["PumpDatas"].Rows[n]["YesReWater"])
			//                    -System.Convert.ToInt32(ds1.Tables["PumpDatas"].Rows[n]["ReWater"]);
			//                continue;
			//           }

			this.dataGridData.DataSource=ds1.Tables["PumpDatas"];
			this._dt=ds1.Tables["PumpDatas"];

		}
     
		#endregion
		#endregion
     
		#region statisticJDUse
		private void statisticJDUse()
		{
			Decimal _dayUse;
			if(_dt.Rows.Count==0)
				return;
			else
			{
				int r=_dt.Rows.Count-1;
				_dayUse=System.Convert.ToDecimal(_dt.Rows[r]["TuWater"])-System.Convert.ToDecimal(_dt.Rows[0]["TuWater"]);
			}
			this.lRYS.Text=_dayUse.ToString();

		}
		#endregion

		#region .....   
		/*       private void QueryGateDatas()
				{
      
					try
					{
						string strAddress=string.Format("select Address from Tb_Address where Id_Sign='Gate'");
                
						SqlDataAdapter daAddress=new SqlDataAdapter(strAddress,strconn);
						DataSet dsAddress=new DataSet();
						daAddress.Fill(dsAddress,"tt");
						daAddress.Dispose();
						int z=0;
						for(int i=0;i<dsAddress.Tables["tt"].Rows.Count;i++)
						{
							string sql1=@"select Address,strTime,BeforeLevel,BehindLevel,Height,Flux,ReWater,TuWater
										 from v_GateDatas where Address='";
							sql1=sql1+dsAddress.Tables["tt"].Rows[i]["Address"].ToString();
							sql1=sql1+"'and strTime between'";
							sql1=sql1+_Dtime.AddMinutes(-7);
							sql1=sql1+"'and'";
							sql1=sql1+_Dtime.AddMinutes(8);
							sql1=sql1+"'";
                    
							SqlDataAdapter da=new SqlDataAdapter(sql1,strconn);
							DataSet ds=new DataSet();
							da.Fill(ds,"t");
							da.Dispose();
							GateDatas=new DataTable();
							for(int j=0;j<ds.Tables["t"].Rows.Count;j++)
							{
								DataRow newrow=GateDatas.NewRow();
								GateDatas.Rows.Add(newrow);
								GateDatas.Rows[z]["Address"]=ds.Tables["t"].Rows[j]["Address"].ToString();
								GateDatas.Rows[z]["strTime"]=ds.Tables["t"].Rows[j]["strTime"].ToString();
								GateDatas.Rows[z]["BeforeLevel"]=ds.Tables["t"].Rows[j]["BeforeLevel"].ToString();
								GateDatas.Rows[z]["BehindLevel"]=ds.Tables["t"].Rows[j]["BehindLevel"].ToString();
								GateDatas.Rows[z]["Height"]=ds.Tables["t"].Rows[j]["Height"].ToString();
								GateDatas.Rows[z]["Flux"]=ds.Tables["t"].Rows[j]["Flux"].ToString();
								GateDatas.Rows[z]["ReWater"]=ds.Tables["t"].Rows[j]["ReWater"].ToString();
								GateDatas.Rows[z]["TuWater"]=ds.Tables["t"].Rows[j]["TuWater"].ToString();
								z=z+1;
							}
							this.dataGridData.DataSource=ds.Tables["GateDatas"];
						}
              
					}
					catch(Exception ex)
					{
						MessageBox.Show(ex.ToString());
					}

				}

			*/
		#endregion

		#region  setDefaultTime
		private void setDefaultTime()
		{
			this.dtpbeginDate.Value=DateTime.Now.AddDays(-1);  
		}
		#endregion

		#region FillAddress
		private void FillAddress()
		{
			try
			{ 
				this.ReadConfig();

				string strAddress=string.Format("select Address from {0} ",this._class);
				if(this._department !="")
				{
					strAddress +=string.Format("where Department='{0}'",this._department);
				}
				if(this._place !="")
				{
					strAddress +=string.Format("and Place='{0}'",this._place);
				}
				strAddress +=string.Format("order by Id_Pole asc");
               
				strconn.Open(); 
				SqlDataAdapter daAddress=new SqlDataAdapter(strAddress,strconn);
				DataSet dsAddress=new DataSet();
				daAddress.Fill(dsAddress);

				this.cbbAddress.DataSource=dsAddress.Tables[0];
				this.cbbAddress.DisplayMember="Address";

				strconn.Close();

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		#endregion
   
		#region Form1_Load
		private void Form1_Load(object sender, System.EventArgs e)
		{
			string[] colNames0={"Address","StrTime","BeforeLevel","BehindLevel","Height","Flux","ReWater","YesTuWater","TuWater",
								   "DayWaUse","AllWater"};
			string[] showNames0={"位置","时间","闸前水位","闸后水位","提闸高度","流量","剩余水量","昨日累计用水量","今日累计用水量",
									"日用水量","总输入水量"};
			int[]  colWiths0={100,120,70,70,70,70,100,110,110,100,100};

			DataGridTableStyle dgts0=Misc.CreateDataGridTableStyle("GateDay"/* "_dtGate"*/,colNames0,showNames0,null,colWiths0);
			this.dataGridData.TableStyles.Add(dgts0);

			string[] colNames1={"Address","StrTime","BeforeLevel","BehindLevel","Height","Flux","ReWater","TuWater"/*,"YesWaUse",
                               "DayWaUse"*/};
			string[] showNames1={"位置","时间","闸前水位","闸后水位","提闸高度","流量","剩余水量","总用水量"/*,"昨日总水量",
                                "日用水量"*/};
			int[]  colWiths1={100,110,70,70,70,70,90,100/*,100,100*/};

			DataGridTableStyle dgts1=Misc.CreateDataGridTableStyle("GateDatas",colNames1,showNames1,null,colWiths1);
			this.dataGridData.TableStyles.Add(dgts1);

			string[] colNames2={"Address","StrTime","Flux","Efficiency","ReWater","YesTuWater","TuWater","DayWaUse",
								   "AllWater"};
			string[] showNames2={"位置","时间","流量","效率","剩余水量","昨日总用水量","今日总用水量","日用水量",
									"总输入水量"};
			int[] colWiths2=new int[]{100,110,70,70,100,100,100,100,100};

			DataGridTableStyle dgts2=Misc.CreateDataGridTableStyle("PumpDay",colNames2,showNames2,null,colWiths2);
			this.dataGridData.TableStyles.Add(dgts2);

			string[] colNames3={"Address","StrTime","Flux","Efficiency","ReWater",/*"YesReWater","DayWaterUse",*/"TuWater",
								   "Run"};
			string[] showNames3={"位置","时间","流量","效率","剩余水量",/*"昨日剩余水量","日用水量",*/"已用水量",
									"泵站状态"};
			int[] colWiths3=new int[]{100,110,70,70,90,/*90,90,*/100,100};

			DataGridTableStyle dgts3=Misc.CreateDataGridTableStyle("PumpDatas",colNames3,showNames3,null,colWiths3);
			this.dataGridData.TableStyles.Add(dgts3);

			this.setDefaultTime();
			this.FillAddress();
			this.checkBox1.Checked=false;
			this.groupBox1.Visible=false;
			this.groupBox2.Visible=true;
           
		}
		#endregion
      
		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.comboBox1.Text=="口门")
			{
				this._class="v_Gate";
				this.FillAddress();
			}
			else
			{
				this._class="v_Pump";
				this.FillAddress();
			}
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.checkBox1.Checked )
			{
				this.groupBox2.Visible=false;
				this.groupBox1.Visible=true;
			}
			else if(!this.checkBox1.Checked )
			{
				this.groupBox1.Visible=false;
				this.groupBox2.Visible=true;
			}
		}
 
	}
}
