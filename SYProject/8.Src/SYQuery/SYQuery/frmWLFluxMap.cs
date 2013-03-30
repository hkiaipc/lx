using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SYQuery
{
    public partial class frmWLFluxMap : Form
    {
        public frmWLFluxMap()
        {
            InitializeComponent();
        }

        private void frmWLFluxMap_Load(object sender, EventArgs e)
        {
            this.Text = Strings.WLFluxMap;
            DataTable tbl = DBI.GetDBI().GetWLFluxMapDataTable();
            this.dataGridView1.DataSource = tbl;
        }
    }
}
