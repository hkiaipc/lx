namespace lxstation
{
    partial class gate
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
            this.gate_ip = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.freeflux = new System.Windows.Forms.TextBox();
            this.underflux = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.area_name = new System.Windows.Forms.ComboBox();
            this.gate_height = new System.Windows.Forms.TextBox();
            this.gate_width = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TM_number = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.id_pole = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gate_name = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.gate_ip);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 161);
            this.groupBox1.TabIndex = 0;
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
            // gate_ip
            // 
            this.gate_ip.Location = new System.Drawing.Point(263, 24);
            this.gate_ip.Name = "gate_ip";
            this.gate_ip.Size = new System.Drawing.Size(100, 21);
            this.gate_ip.TabIndex = 3;
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
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "站点名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.freeflux);
            this.groupBox2.Controls.Add(this.underflux);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.area_name);
            this.groupBox2.Controls.Add(this.gate_height);
            this.groupBox2.Controls.Add(this.gate_width);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TM_number);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.id_pole);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(12, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 192);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基础信息";
            // 
            // freeflux
            // 
            this.freeflux.Location = new System.Drawing.Point(274, 110);
            this.freeflux.Name = "freeflux";
            this.freeflux.Size = new System.Drawing.Size(89, 21);
            this.freeflux.TabIndex = 14;
            // 
            // underflux
            // 
            this.underflux.Location = new System.Drawing.Point(274, 71);
            this.underflux.Name = "underflux";
            this.underflux.Size = new System.Drawing.Size(89, 21);
            this.underflux.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "自由流系数：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 19;
            this.label10.Text = "潜流系数：";
            // 
            // area_name
            // 
            this.area_name.FormattingEnabled = true;
            this.area_name.Location = new System.Drawing.Point(79, 34);
            this.area_name.Name = "area_name";
            this.area_name.Size = new System.Drawing.Size(100, 20);
            this.area_name.TabIndex = 9;
            // 
            // gate_height
            // 
            this.gate_height.Location = new System.Drawing.Point(79, 110);
            this.gate_height.Name = "gate_height";
            this.gate_height.Size = new System.Drawing.Size(100, 21);
            this.gate_height.TabIndex = 13;
            // 
            // gate_width
            // 
            this.gate_width.Location = new System.Drawing.Point(79, 71);
            this.gate_width.Name = "gate_width";
            this.gate_width.Size = new System.Drawing.Size(100, 21);
            this.gate_width.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "闸底高程：";
            // 
            // TM_number
            // 
            this.TM_number.Location = new System.Drawing.Point(79, 145);
            this.TM_number.MaxLength = 16;
            this.TM_number.Name = "TM_number";
            this.TM_number.Size = new System.Drawing.Size(148, 21);
            this.TM_number.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 8;
            this.label12.Text = "闸门宽度：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "TM卡号：";
            // 
            // id_pole
            // 
            this.id_pole.Location = new System.Drawing.Point(274, 33);
            this.id_pole.Name = "id_pole";
            this.id_pole.Size = new System.Drawing.Size(89, 21);
            this.id_pole.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "行政区域：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(201, 37);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 3;
            this.label17.Text = "排列序号：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 24);
            this.button1.TabIndex = 11;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(296, 438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 24);
            this.button2.TabIndex = 12;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gate_name
            // 
            this.gate_name.Location = new System.Drawing.Point(87, 18);
            this.gate_name.Name = "gate_name";
            this.gate_name.Size = new System.Drawing.Size(93, 21);
            this.gate_name.TabIndex = 1;
            // 
            // gate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 483);
            this.Controls.Add(this.gate_name);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "gate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "口门信息";
            this.Load += new System.EventHandler(this.gate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox place_name;
        private System.Windows.Forms.ComboBox depart_name;
        private System.Windows.Forms.TextBox place_ip;
        private System.Windows.Forms.TextBox depart_ip;
        private System.Windows.Forms.TextBox phone_number;
        private System.Windows.Forms.TextBox gate_ip;
        private System.Windows.Forms.TextBox gate_height;
        private System.Windows.Forms.TextBox gate_width;
        private System.Windows.Forms.TextBox TM_number;
        private System.Windows.Forms.TextBox id_pole;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox area_name;
        private System.Windows.Forms.TextBox gate_name;
        private System.Windows.Forms.TextBox comadr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox freeflux;
        private System.Windows.Forms.TextBox underflux;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}