using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LXRainTrans
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = string.Format("{0}\r\n\r\nV{1}",
                this.Text, Application.ProductVersion);
            MessageBox.Show(s, "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Default.Exit(0);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public TextBox LogTextBox
        {
            get { return this.textBox1; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            App.Default.Trans.Start();
            App.Default.DB.TestDBConnection();
        }

        private void 清除CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }
    }
}
