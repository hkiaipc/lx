using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataPrecess
{
    public partial class frmRain : Form
    {
        public frmRain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRain_Load(object sender, EventArgs e)
        {
            this.dtpbeginDate.Value = DateTime.Now.Date - TimeSpan.FromDays(1d);
            this.dtpBeginTime.Value = DateTime.Now.Date;

            this.dtpEndDate.Value = DateTime.Now.Date + TimeSpan.FromDays(1d);
            this.dtpEndTime.Value = DateTime.Now.Date;

            // fill 
            //
            string s = string.Format("select * from tbl_RainAddr order by Rain_name");
            DataTable tbl = lxstation.CDbConnection.getDt(s);
            this.cbRainName.DisplayMember = "Rain_name";
            this.cbRainName.ValueMember = "Rain_Addr";
            this.cbRainName.DataSource = tbl;
        }

        DateTime Begin
        {
            get { return this.dtpbeginDate.Value.Date + this.dtpBeginTime.Value.TimeOfDay; }
        }

        DateTime End
        {
            get { return this.dtpEndDate.Value.Date + this.dtpEndTime.Value.TimeOfDay; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Query();
        }

        /// <summary>
        /// 
        /// </summary>
        void Query()
        {
            if (this.cbRainName.SelectedIndex != -1)
            {
                object addr = this.cbRainName.SelectedValue;
                string s = string.Format(
                    "SELECT [RD_Addr], [RD_Date], " +
                    "convert( float, [RD_Sum]) / 100 as RD_Sum, " +
                    "[Rain_Name], [Rain_IP] FROM [v_RainData] " +
                    "where RD_Addr = {0} and RD_date >= '{1}' and RD_Date < '{2}' order by RD_Date",
                    addr, Begin, End);

                DataTable tbl = lxstation.CDbConnection.getDt(s);
                this.dataGridData.DataSource = tbl;

                object sum = tbl.Compute("Sum(RD_Sum)", "true");
                
                this.txtSum.Text = string.Format("{0:F2}", sum);

            }
        }
    }
}
