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
    public partial class lxstation : Form
    {
        public lxstation()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.Add("口门");
            this.comboBox1.Items.Add("泵站");
            this.comboBox1.SelectedIndex=0;
            refresh_Click(null, null);
        }


        private void refresh_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DataTable tb = CDbConnection.getDt("select [id_pole],[address],[comadr],[sim],[gateip],[place],[department],[area],[tmdata],[width],[bottomheight],[underflux],[freeflux] from v_gate order by [id_pole]");
                dataGridView1.DataSource = tb;
                string[] colNames = new string[] { "id_pole", "address", "comadr", "sim", "gateip", "place", "department", "area", "tmdata", "width", "bottomheight","underflux","freeflux" };
                string[] showNames = new string[] {  " 序号","  站点名称", " 地址", "  手机号", "  IP地址", "  管理站", "  管理所", "行政区域", "  TM卡号", " 闸宽", "闸底高程","潜流系数","自由流系数" };
                int[] colwidth = new int[] {55,90,55,100,100,90,120,75,120,55,75,75,85};
                for (int i = 0; i < colNames.Length; i++)
                {
                    dataGridView1.Columns[colNames[i]].HeaderText = showNames[i];
                    dataGridView1.Columns[colNames[i]].Width = colwidth[i];
                }               
            }
            if (comboBox1.SelectedIndex == 1)
            {
                DataTable tb = CDbConnection.getDt("select [id_pole],[address],[comadr],[sim],[pumpip],[place],[department],[area] from v_pump order by [id_pole]");
                dataGridView1.DataSource = tb;
                string[] colNames = new string[] { "id_pole", "address", "comadr", "sim", "pumpip", "place", "department", "area"};
                string[] showNames = new string[] { " 序号", "  站点名称", " 地址", "  手机号", "  IP地址", "  管理站", "  管理所", "行政区域" };
                int[] colwidth = new int[] { 55, 90, 55, 100, 100, 90, 120, 75 };
                for (int i = 0; i < colNames.Length; i++)
                {
                    dataGridView1.Columns[colNames[i]].HeaderText = showNames[i];
                    dataGridView1.Columns[colNames[i]].Width = colwidth[i];
                } 
            }            
        }

        private void change_Click(object sender, EventArgs e)
        {
            int row = this.dataGridView1.CurrentRow.Index;
            if (row == -1)
            { 
                return; 
            }
            int id_pole = Convert.ToInt32(dataGridView1[0, row].Value.ToString());
            string name = dataGridView1[1, row].Value.ToString();
            int comadr = Convert.ToInt32(dataGridView1[2, row].Value.ToString());
            string phone_number = dataGridView1[3, row].Value.ToString();
            string ip = dataGridView1[4, row].Value.ToString();
            string place_name = dataGridView1[5, row].Value.ToString();
            string depart_name = dataGridView1[6, row].Value.ToString();
            string depart_ip = CDbConnection.execScalar("select [ip] from tb_department where [department]='" + depart_name + "'");
            string place_ip = CDbConnection.execScalar("select [ip] from tb_place where [place]='" + place_name + "'");
            string area_name = dataGridView1[7, row].Value.ToString();
            if (comboBox1.SelectedIndex == 0)
            {               
                string TM_number = dataGridView1[8, row].Value.ToString();
                int gate_width = 0;
                if (dataGridView1[9, row].Value.ToString() != "")
                {
                    gate_width = Convert.ToInt32(dataGridView1[9, row].Value.ToString());
                }
                int gate_height = 0;
                if (dataGridView1[10, row].Value.ToString() != "")
                {
                    gate_height = Convert.ToInt32(dataGridView1[10, row].Value.ToString());
                }
                double underflux = 0;
                if (dataGridView1[11, row].Value.ToString() != "")
                {
                    underflux = Convert.ToDouble(dataGridView1[11, row].Value.ToString());
                }
                double freeflux = 0;
                if (dataGridView1[12, row].Value.ToString() != "")
                {
                    freeflux = Convert.ToDouble(dataGridView1[12, row].Value.ToString());
                }
                gate gate_inf = new gate();
                gate_inf._id_pole = id_pole;
                gate_inf._gate_name = name;
                gate_inf._comadr = comadr;
                gate_inf._phone_number = phone_number;
                gate_inf._gate_ip = ip;
                gate_inf._place_name = place_name;
                gate_inf._depart_name = depart_name;
                gate_inf._place_ip = place_ip;
                gate_inf._depart_ip = depart_ip;
                gate_inf._area_name = area_name;
                gate_inf._TM_number = TM_number;
                gate_inf._gate_width = gate_width;
                gate_inf._gate_height = gate_height;
                gate_inf._underflux = underflux;
                gate_inf._freeflux = freeflux;

                if (gate_inf.ShowDialog(this) == DialogResult.OK)
                {
                    id_pole = gate_inf._id_pole;
                    name = gate_inf._gate_name;
                    comadr = gate_inf._comadr;
                    phone_number = gate_inf._phone_number;
                    ip = gate_inf._gate_ip;
                    place_name = gate_inf._place_name;
                    depart_name = gate_inf._depart_name;
                    place_ip = gate_inf._place_ip;
                    depart_ip = gate_inf._depart_ip;
                    area_name = gate_inf._area_name;
                    TM_number = gate_inf._TM_number;
                    gate_width = gate_inf._gate_width;
                    gate_height = gate_inf._gate_height;
                    underflux = gate_inf._underflux;
                    freeflux = gate_inf._freeflux;

                    int station_id = Convert.ToInt32(CDbConnection.execScalar("select [id] from tb_address where [address]='" + name + "'"));

                    CDbConnection.execCmd("update tb_address set "
                        + "[id_pole]=" + id_pole + ", "
                        + "[address]='" + name + "',"
                        + "[id_area]=(select [id_area] from tb_area where [area]='" + area_name + "'),"
                        + "[id_place]=(select [id_place] from tb_place where [place]='" + place_name + "') "
                        + "where [id]=" + station_id + "");

                    CDbConnection.execCmd("update tb_gateinf set "
                        + "[comadr]      = " + comadr + " ,"
                        + "[tmdata]      ='" + TM_number + "',"
                        + "[width]       = " + gate_width + " ,"
                        + "[bottomheight]= " + gate_height + " ,"
                        + "[underflux]   = " + underflux + " ,"
                        + "[freeflux]    = " + freeflux + " ,"
                        + "[sim]         ='" + phone_number + "',"
                        + "[ip]          ='" + ip + "' "
                        + "where [id]=" + station_id + "");
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                pump pump_inf = new pump();

                pump_inf._id_pole = id_pole;
                pump_inf._pump_name = name;
                pump_inf._comadr = comadr;
                pump_inf._phone_number = phone_number;
                pump_inf._pump_ip = ip;
                pump_inf._place_name = place_name;
                pump_inf._depart_name = depart_name;
                pump_inf._place_ip = place_ip;
                pump_inf._depart_ip = depart_ip;
                pump_inf._area_name = area_name;


                if (pump_inf.ShowDialog(this) == DialogResult.OK)
                {
                    id_pole = pump_inf._id_pole;
                    name = pump_inf._pump_name;
                    comadr = pump_inf._comadr;
                    phone_number = pump_inf._phone_number;
                    ip = pump_inf._pump_ip;
                    place_name = pump_inf._place_name;
                    depart_name = pump_inf._depart_name;
                    place_ip = pump_inf._place_ip;
                    depart_ip = pump_inf._depart_ip;
                    area_name = pump_inf._area_name;

                    int station_id = Convert.ToInt32(CDbConnection.execScalar("select [id] from tb_address where [address]='" + name + "'"));

                    CDbConnection.execCmd("update tb_address set "
                        + "[id_pole]=" + id_pole + ", "
                        + "[address]='" + name + "',"
                        + "[id_area]=(select [id_area] from tb_area where [area]='" + area_name + "'),"
                        + "[id_place]=(select [id_place] from tb_place where [place]='" + place_name + "') "
                        + "where [id]=" + station_id + "");

                    CDbConnection.execCmd("update tb_pumpinf set "
                        + "[comadr]      = " + comadr + " ,"
                        + "[sim]         ='" + phone_number + "',"
                        + "[ip]          ='" + ip + "' "
                        + "where [id]=" + station_id + "");                    
                }
            }
            refresh_Click(null, null);
        }

        private void add_Click(object sender, EventArgs e)
        {
            string area_str="";
            string place_str="";
            DataTable tb_name = CDbConnection.getDt("select [address] from tb_address");
            if (comboBox1.SelectedIndex == 0)
            {
                gate gate_inf = new gate();
                if (gate_inf.ShowDialog(this) == DialogResult.OK)
                {
                    for (int i = 0; i < tb_name.Rows.Count; i++)
                    {
                        if (tb_name.Rows[i][0].ToString() == gate_inf._gate_name)
                        {
                            MessageBox.Show("站名已经存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    area_str = CDbConnection.execScalar("select [id_area] from tb_area where [area]='" + gate_inf._area_name + "'");
                    place_str = CDbConnection.execScalar("select [id_place] from tb_place where [place]='" + gate_inf._place_name + "'");
                    int id = Convert.ToInt32(CDbConnection.execScalar("select max([id]) from tb_address")) + 1;
                    CDbConnection.execCmd("insert into tb_address ([id],[id_sign],[id_pole],[address],[id_area],[id_place]) values (" + id + ",'Gate'," + gate_inf._id_pole + ", '" + gate_inf._gate_name + "', '" + area_str + "','" + place_str + "')");

                    CDbConnection.execCmd("insert into tb_gateinf ([id],[comadr],[tmdata],[width],[bottomheight],[underflux],[freeflux],[sim],[ip]) values "
                        + "(" + id + "," + gate_inf._comadr + " ,'" + gate_inf._TM_number + "'," + gate_inf._gate_width + " ," + gate_inf._gate_height + " ,"
                        + "" + gate_inf._underflux + " ," + gate_inf._freeflux + " ,'" + gate_inf._phone_number + "','" + gate_inf._gate_ip + "' )");
                }                
            }
            if (comboBox1.SelectedIndex == 1)
            {
                pump pump_inf = new pump();
                if (pump_inf.ShowDialog(this) == DialogResult.OK)
                {
                    for (int i = 0; i < tb_name.Rows.Count; i++)
                    {
                        if (tb_name.Rows[i][0].ToString() == pump_inf._pump_name)
                        {
                            MessageBox.Show("站名已经存在!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    area_str = CDbConnection.execScalar("select [id_area] from tb_area where [area]='" + pump_inf._area_name + "'");
                    place_str = CDbConnection.execScalar("select [id_place] from tb_place where [place]='" + pump_inf._place_name + "'");
                    int id = Convert.ToInt32(CDbConnection.execScalar("select max([id]) from tb_address")) + 1;
                    CDbConnection.execCmd("insert into tb_address ([id],[id_sign],[id_pole],[address],[id_area],[id_place]) values (" + id + ",'Gate'," + pump_inf._id_pole + ", '" + pump_inf._pump_name + "', '" + area_str + "','" + place_str + "')");
                    CDbConnection.execCmd("insert into tb_pumpinf ([id],[comadr],[sim],[ip]) values (" + id + "," + pump_inf._comadr + " ,'" + pump_inf._phone_number + "','" + pump_inf._pump_ip + "' )");
                } 
            }
            refresh_Click(null, null);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int row = this.dataGridView1.CurrentRow.Index;
            if (row == -1)
            {
                return;
            }

            if (MessageBox.Show("确定要删除" + dataGridView1[1, row].Value.ToString() + "?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(CDbConnection.execScalar("select [id] from tb_address where [address] = '" + dataGridView1[1, row].Value.ToString() + "'"));
                CDbConnection.execCmd("delete tb_address where [id]=" + id + " ");
                CDbConnection.execCmd("delete tb_gateinf where [id]=" + id + " ");
            }
            refresh_Click(null, null);
        }

    }
}
