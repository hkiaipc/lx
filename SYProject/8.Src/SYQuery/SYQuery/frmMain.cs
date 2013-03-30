using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SYQuery
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = Strings.Title;
            this.dtpBeginDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now + TimeSpan.FromDays(1);

        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime BeginDT
        {
            get
            {
                return this.dtpBeginDate.Value.Date + this.dtpBeginTime.Value.TimeOfDay;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDT
        {
            get
            {
                return this.dtpEndDate.Value.Date + this.dtpEndTime.Value.TimeOfDay;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable tbl = DBI.GetDBI().Query(this.BeginDT, this.EndDT);
            this.dataGridView1.DataSource = tbl;

            // calc during amount
            //
            if (tbl.Rows.Count <= 1)
            {
                this.lblDuringAmount.Text = string.Empty;
            }
            else
            {
                DataRow firstRow = tbl.Select("时间 = min(时间)")[0];
                DataRow lastRow = tbl.Select("时间 = max(时间)")[0];

                DateTime firstDT = Convert.ToDateTime (firstRow["时间"]);
                DateTime lastDT = Convert.ToDateTime(lastRow["时间"]);

                double first = Convert.ToDouble (firstRow["累计流量(m3)"]);
                double last= Convert.ToDouble (lastRow["累计流量(m3)"]);

                double duringAmount = last - first;

                string s =string.Format("阶段时间: {0} ~ {1}" +Environment.NewLine + Environment.NewLine + "阶段水量: {2} (m3)",
                                    firstDT, lastDT, duringAmount);

                this.lblDuringAmount.Text = s;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAbout_Click(object sender, EventArgs e)
        {
            string s = "{0}" + Environment.NewLine + Environment.NewLine + "V{1}";
            s = string.Format(s, Strings.Title, Application.ProductVersion);
            MessageBox.Show(this, s, Strings.About, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuWLFluxMap_Click(object sender, EventArgs e)
        {
            frmWLFluxMap f = new frmWLFluxMap();
            f.ShowDialog(this);
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
