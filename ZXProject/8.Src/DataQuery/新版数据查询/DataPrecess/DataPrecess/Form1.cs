using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dataline;
using DataQuery;
using lxstation;


namespace DataPrecess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataQuery.frmDataQuery frm = new frmDataQuery();
            frm.MdiParent = this;
            frm.Show();
        }

        private bool checkChildFrmExist(string childFrmText)
        {
            try
            {
                foreach (Form childFrm in this.MdiChildren)
                {
                    //用子窗体的Name进行判断，如果已经存在则将他激活
                    if (childFrm.Text == childFrmText)
                    {
                        if (childFrm.WindowState == FormWindowState.Minimized)
                            childFrm.WindowState = FormWindowState.Normal;
                        childFrm.Activate();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                 
                MessageBox.Show("程序导入错误,请重新启动程序!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        private void dataQuery_Click(object sender, EventArgs e)
        {
            if (this.checkChildFrmExist("数据查询") == true)
            {
                return;
            }
            DataQuery.frmDataQuery frm = new frmDataQuery();
            frm.MdiParent = this;
            frm.Text = "数据查询";
            frm.Show();
        }

        private void dataLine_Click(object sender, EventArgs e)
        {
            if (this.checkChildFrmExist("数据曲线") == true)
            {
                return;
            }
            dataline.Form1 frm = new dataline.Form1();
            frm.MdiParent = this;
            frm.Text = "数据曲线";
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
          //  frm.FormBorderStyle = FormBorderStyle.None;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lxstation_Click(object sender, EventArgs e)
        {
            if (this.checkChildFrmExist("站点管理") == true)
            {
                return;
            }
            lxstation.lxstation frm = new lxstation.lxstation();
            frm.MdiParent = this;
            frm.Text = "站点管理";
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 雨量查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.checkChildFrmExist("雨量查询"))
            {
                return;
            }

            frmRain f = new frmRain();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = string.Format ("{0}\r\n\r\nV{1}", "滦下灌区数据统计", Application.ProductVersion);
            MessageBox.Show(s, "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
