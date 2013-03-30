namespace lxstation
{
    partial class pump
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pump_name = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.area_name = new System.Windows.Forms.ComboBox();
            this.id_pole = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comadr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.place_name = new System.Windows.Forms.ComboBox();
            this.depart_name = new System.Windows.Forms.ComboBox();
            this.place_ip = new System.Windows.Forms.TextBox();
            this.depart_ip = new System.Windows.Forms.TextBox();
            this.phone_number = new System.Windows.Forms.TextBox();
            this.pump_ip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pump_name
            // 
            this.pump_name.Location = new System.Drawing.Point(87, 12);
            this.pump_name.Name = "pump_name";
            this.pump_name.Size = new System.Drawing.Size(93, 21);
            this.pump_name.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 24);
            this.button2.TabIndex = 18;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 24);
            this.button1.TabIndex = 17;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.area_name);
            this.groupBox2.Controls.Add(this.id_pole);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(12, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 73);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基础信息";
            // 
            // area_name
            // 
            this.area_name.FormattingEnabled = true;
            this.area_name.Location = new System.Drawing.Point(79, 30);
            this.area_name.Name = "area_name";
            this.area_name.Size = new System.Drawing.Size(106, 20);
            this.area_name.TabIndex = 9;
            // 
            // id_pole
            // 
            this.id_pole.Location = new System.Drawing.Point(263, 29);
            this.id_pole.Name = "id_pole";
            this.id_pole.Size = new System.Drawing.Size(100, 21);
            this.id_pole.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "行政区域：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(201, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 3;
            this.label17.Text = "排列序号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comadr);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.place_name);
            this.groupBox1.Controls.Add(this.depart_name);
            this.groupBox1.Controls.Add(this.place_ip);
            this.groupBox1.Controls.Add(this.depart_ip);
            this.groupBox1.Controls.Add(this.phone_number);
            this.groupBox1.Controls.Add(this.pump_ip);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 161);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通讯信息";
            // 
            // comadr
            // 
            this.comadr.Location = new System.Drawing.Point(86, 128);
            this.comadr.Name = "comadr";
            this.comadr.Size = new System.Drawing.Size(98, 21);
            this.comadr.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "通讯地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "IP地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "IP地址：";
            // 
            // place_name
            // 
            this.place_name.FormattingEnabled = true;
            this.place_name.Location = new System.Drawing.Point(75, 93);
            this.place_name.Name = "place_name";
            this.place_name.Size = new System.Drawing.Size(110, 20);
            this.place_name.TabIndex = 6;
            this.place_name.SelectedIndexChanged += new System.EventHandler(this.place_name_SelectedIndexChanged);
            // 
            // depart_name
            // 
            this.depart_name.FormattingEnabled = true;
            this.depart_name.Location = new System.Drawing.Point(75, 59);
            this.depart_name.Name = "depart_name";
            this.depart_name.Size = new System.Drawing.Size(110, 20);
            this.depart_name.TabIndex = 4;
            this.depart_name.SelectedIndexChanged += new System.EventHandler(this.depart_name_SelectedIndexChanged);
            // 
            // place_ip
            // 
            this.place_ip.Location = new System.Drawing.Point(263, 92);
            this.place_ip.Name = "place_ip";
            this.place_ip.ReadOnly = true;
            this.place_ip.Size = new System.Drawing.Size(100, 21);
            this.place_ip.TabIndex = 7;
            // 
            // depart_ip
            // 
            this.depart_ip.Location = new System.Drawing.Point(263, 58);
            this.depart_ip.Name = "depart_ip";
            this.depart_ip.ReadOnly = true;
            this.depart_ip.Size = new System.Drawing.Size(100, 21);
            this.depart_ip.TabIndex = 5;
            // 
            // phone_number
            // 
            this.phone_number.Location = new System.Drawing.Point(75, 24);
            this.phone_number.MaxLength = 11;
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(110, 21);
            this.phone_number.TabIndex = 2;
            // 
            // pump_ip
            // 
            this.pump_ip.Location = new System.Drawing.Point(263, 24);
            this.pump_ip.Name = "pump_ip";
            this.pump_ip.Size = new System.Drawing.Size(100, 21);
            this.pump_ip.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "管理所：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "管理站：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "IP地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "手机号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "站点名称：";
            // 
            // pump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 352);
            this.Controls.Add(this.pump_name);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "泵站信息";
            this.Load += new System.EventHandler(this.pump_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pump_name;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox area_name;
        private System.Windows.Forms.TextBox id_pole;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox comadr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox place_name;
        private System.Windows.Forms.ComboBox depart_name;
        private System.Windows.Forms.TextBox place_ip;
        private System.Windows.Forms.TextBox depart_ip;
        private System.Windows.Forms.TextBox phone_number;
        private System.Windows.Forms.TextBox pump_ip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}