namespace CommuniServer
{
    partial class UCLXRainDevice
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCommuniLog = new System.Windows.Forms.Button();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDevice
            // 
            this.txtDevice.BackColor = System.Drawing.Color.White;
            this.txtDevice.Location = new System.Drawing.Point(111, 39);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.ReadOnly = true;
            this.txtDevice.Size = new System.Drawing.Size(131, 21);
            this.txtDevice.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "设备：";
            // 
            // btnCommuniLog
            // 
            this.btnCommuniLog.Location = new System.Drawing.Point(313, 10);
            this.btnCommuniLog.Name = "btnCommuniLog";
            this.btnCommuniLog.Size = new System.Drawing.Size(75, 23);
            this.btnCommuniLog.TabIndex = 29;
            this.btnCommuniLog.Text = "通讯记录";
            this.btnCommuniLog.UseVisualStyleBackColor = true;
            this.btnCommuniLog.Click += new System.EventHandler(this.btnCommuniLog_Click);
            // 
            // txtStationName
            // 
            this.txtStationName.BackColor = System.Drawing.Color.White;
            this.txtStationName.Location = new System.Drawing.Point(111, 12);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.ReadOnly = true;
            this.txtStationName.Size = new System.Drawing.Size(131, 21);
            this.txtStationName.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "站名：";
            // 
            // txtDT
            // 
            this.txtDT.BackColor = System.Drawing.Color.White;
            this.txtDT.Location = new System.Drawing.Point(111, 66);
            this.txtDT.Name = "txtDT";
            this.txtDT.ReadOnly = true;
            this.txtDT.Size = new System.Drawing.Size(131, 21);
            this.txtDT.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "时间：";
            // 
            // txtWL1
            // 
            this.txtRain.BackColor = System.Drawing.Color.White;
            this.txtRain.Location = new System.Drawing.Point(111, 94);
            this.txtRain.Name = "txtWL1";
            this.txtRain.ReadOnly = true;
            this.txtRain.Size = new System.Drawing.Size(131, 21);
            this.txtRain.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "雨量：";
            // 
            // UCLXRainDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDevice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCommuniLog);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRain);
            this.Controls.Add(this.label1);
            this.Name = "UCLXRainDevice";
            this.Size = new System.Drawing.Size(427, 344);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCommuniLog;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRain;
        private System.Windows.Forms.Label label1;
    }
}
