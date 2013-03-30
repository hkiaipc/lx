namespace DataPrecess
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.dataLine = new System.Windows.Forms.ToolStripMenuItem();
            this.lxstation = new System.Windows.Forms.ToolStripMenuItem();
            this.雨量查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataQuery,
            this.dataLine,
            this.lxstation,
            this.雨量查询ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataQuery
            // 
            this.dataQuery.Name = "dataQuery";
            this.dataQuery.Size = new System.Drawing.Size(67, 20);
            this.dataQuery.Text = "&数据查询";
            this.dataQuery.Click += new System.EventHandler(this.dataQuery_Click);
            // 
            // dataLine
            // 
            this.dataLine.Name = "dataLine";
            this.dataLine.Size = new System.Drawing.Size(67, 20);
            this.dataLine.Text = "&曲线分析";
            this.dataLine.Click += new System.EventHandler(this.dataLine_Click);
            // 
            // lxstation
            // 
            this.lxstation.Name = "lxstation";
            this.lxstation.Size = new System.Drawing.Size(67, 20);
            this.lxstation.Text = "&站点管理";
            this.lxstation.Click += new System.EventHandler(this.lxstation_Click);
            // 
            // 雨量查询ToolStripMenuItem
            // 
            this.雨量查询ToolStripMenuItem.Name = "雨量查询ToolStripMenuItem";
            this.雨量查询ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.雨量查询ToolStripMenuItem.Text = "雨量查询";
            this.雨量查询ToolStripMenuItem.Click += new System.EventHandler(this.雨量查询ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(656, 471);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "滦下灌区数据统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataQuery;
        private System.Windows.Forms.ToolStripMenuItem dataLine;
        private System.Windows.Forms.ToolStripMenuItem lxstation;
        private System.Windows.Forms.ToolStripMenuItem 雨量查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
    }
}

