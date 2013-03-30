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
    public partial class gate : Form
    {
        public gate()
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

		#region _gate_name
		public string _gate_name
		{
            get { return this.gate_name.Text; }
            set { this.gate_name.Text = value; }
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

        #region _gate_ip
		public string _gate_ip
		{
			get { return this.gate_ip.Text; }
			set { this.gate_ip.Text = value; }
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

        #region _TM_number
        public string _TM_number
        {
            get { return this.TM_number.Text; }
            set { this.TM_number.Text = value; }
        }
        #endregion 

        #region _gate_width
        public int _gate_width
        {
            get { return Convert.ToInt32(gate_width.Text.Trim()=="" ? "0":comadr.Text.Trim()); }
            set { gate_width.Text = value.ToString(); }
        }
        #endregion 

        #region _gate_height
        public int _gate_height
        {
            get { return Convert.ToInt32(gate_height.Text.Trim()=="" ? "0":gate_height.Text.Trim()); }
            set { gate_height.Text = value.ToString(); }
        }
        #endregion 

        #region _underflux
        public double _underflux
        {
            get { return Convert.ToDouble(underflux.Text.Trim()=="" ? "0":underflux.Text.Trim()); }
            set { underflux.Text = value.ToString(); }
        }
        #endregion

        #region _freeflux
        public double _freeflux
        {
            get { return Convert.ToDouble(freeflux.Text.Trim()=="" ? "0":freeflux.Text.Trim()); }
            set { freeflux.Text = value.ToString(); }
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

            if (_gate_name == string.Empty)
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
                if (_gate_ip.Length == 0)
                {
                    MessageBox.Show("IP地址不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                System.Net.IPAddress.Parse(_gate_ip);
            }
            catch
            {
                MessageBox.Show("IP地址错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_gate_width < 0 || _gate_width > 65535)
            {
                MessageBox.Show("闸高错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_gate_width < 0 || _gate_width > 65535)
            {
                MessageBox.Show("闸底高程错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                double_test = _underflux;
            }
            catch
            {
                MessageBox.Show("潜流系数错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                double_test = _freeflux;
            }
            catch
            {
                MessageBox.Show("自由流系数错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gate_Load(object sender, EventArgs e)
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
