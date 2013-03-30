using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lxstation
{
    public partial class pump : Form
    {
        public pump()
        {
            InitializeComponent();
        }


    	#region _id_pole
		public int _id_pole
		{
			get { return Convert.ToInt32(id_pole.Text.Trim()=="" ? "0":id_pole.Text.Trim()); }
			set { id_pole.Text = value.ToString(); }
		}
		#endregion 

		#region _pump_name
		public string _pump_name
		{
            get { return this.pump_name.Text; }
            set { this.pump_name.Text = value; }
		}
		#endregion 

        #region _comadr
		public int _comadr
		{
			get { return Convert.ToInt32(comadr.Text.Trim()=="" ? "0":comadr.Text.Trim()); }
			set { comadr.Text = value.ToString(); }
		}
		#endregion 

        #region _phone_number
		public string _phone_number
		{
			get { return this.phone_number.Text; }
			set { this.phone_number.Text = value; }
		}
		#endregion 

        #region _pump_ip
		public string _pump_ip
		{
			get { return this.pump_ip.Text; }
			set { this.pump_ip.Text = value; }
		}
		#endregion 

        #region _place_name
		public string _place_name
		{
			get { return this.place_name.Text; }
			set { this.place_name.Text = value; }
		}
		#endregion 

        #region _depart_name
		public string _depart_name
		{
			get { return this.depart_name.Text; }
			set { this.depart_name.Text = value; }
		}
		#endregion 

        #region _place_ip
        public string _place_ip
        {
            get { return this.place_ip.Text; }
            set { this.place_ip.Text = value; }
        }
        #endregion

        #region _depart_ip
        public string _depart_ip
        {
            get { return this.depart_ip.Text; }
            set { this.depart_ip.Text = value; }
        }
        #endregion 

        #region _area_name
		public string _area_name
		{
			get { return this.area_name.Text; }
			set { this.area_name.Text = value; }
		}
		#endregion 

        private void button1_Click(object sender, EventArgs e)
        {

            double double_test;

            if (_id_pole < 0 || _id_pole>65535)
            {
                MessageBox.Show("排列序号错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_pump_name == string.Empty)
            {
                MessageBox.Show("站名不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_comadr < 0 || _comadr > 65535)
            {
                MessageBox.Show("通讯地址错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_depart_name == string.Empty)
            {
                MessageBox.Show("管理所不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_place_name == string.Empty)
            {
                MessageBox.Show("管理站站不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_area_name == string.Empty)
            {
                MessageBox.Show("行政区域不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (_pump_ip.Length == 0)
                {
                    MessageBox.Show("IP地址不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                System.Net.IPAddress.Parse(_pump_ip);
            }
            catch
            {
                MessageBox.Show("IP地址错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pump_Load(object sender, EventArgs e)
        {
            DataTable tb_depart = CDbConnection.getDt("select [id_department],[department],[ip] from tb_department");
            for (int i = 0; i < tb_depart.Rows.Count; i++)
            {
                depart_name.Items.Add(tb_depart.Rows[i]["department"]);
            }
            DataTable tbl_place = CDbConnection.getDt("select [id_place],[place],[id_department],[ip] from tb_place");
            for (int j = 0; j < tbl_place.Rows.Count; j++)
            {
                place_name.Items.Add(tbl_place.Rows[j]["place"]);
            }
            DataTable tb_area = CDbConnection.getDt("select [id_area],[area] from tb_area");
            for (int k = 0; k < tb_area.Rows.Count; k++)
            {
                area_name.Items.Add(tb_area.Rows[k]["area"]);
            }
        }

        private void depart_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                depart_ip.Text = CDbConnection.execScalar("select [ip] from tb_department where [department]='" + depart_name.SelectedItem.ToString() + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void place_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                place_ip.Text = CDbConnection.execScalar("select [ip] from tb_place where [place]='" + place_name.SelectedItem.ToString() + "'");
            }
            catch(Exception ex)
            {       
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

