namespace QuanLyVanBan
{
	partial class VBDi
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbTenVB = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbSoHieu = new System.Windows.Forms.TextBox();
			this.cbbLoai = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpkNgayThang = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tbNKBC = new System.Windows.Forms.TextBox();
			this.tbNKBP = new System.Windows.Forms.TextBox();
			this.nmrSoTrang = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.nmrSoBan = new System.Windows.Forms.NumericUpDown();
			this.tbNoiNhan = new System.Windows.Forms.TextBox();
			this.tbLuuHS = new System.Windows.Forms.TextBox();
			this.nmrSoHop = new System.Windows.Forms.NumericUpDown();
			this.tbTep = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btChon = new System.Windows.Forms.Button();
			this.tbGhiChu = new System.Windows.Forms.TextBox();
			this.btThem = new System.Windows.Forms.Button();
			this.btHuy = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nmrSoTrang)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmrSoBan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmrSoHop)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên văn bản *";
			// 
			// tbTenVB
			// 
			this.tbTenVB.Location = new System.Drawing.Point(94, 17);
			this.tbTenVB.MaxLength = 100;
			this.tbTenVB.Name = "tbTenVB";
			this.tbTenVB.Size = new System.Drawing.Size(292, 20);
			this.tbTenVB.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Loại*";
			// 
			// tbSoHieu
			// 
			this.tbSoHieu.Location = new System.Drawing.Point(273, 47);
			this.tbSoHieu.Name = "tbSoHieu";
			this.tbSoHieu.Size = new System.Drawing.Size(113, 20);
			this.tbSoHieu.TabIndex = 3;
			// 
			// cbbLoai
			// 
			this.cbbLoai.FormattingEnabled = true;
			this.cbbLoai.Location = new System.Drawing.Point(94, 47);
			this.cbbLoai.Name = "cbbLoai";
			this.cbbLoai.Size = new System.Drawing.Size(121, 21);
			this.cbbLoai.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(220, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Số hiệu*";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Ngày tháng";
			// 
			// dtpkNgayThang
			// 
			this.dtpkNgayThang.Location = new System.Drawing.Point(94, 74);
			this.dtpkNgayThang.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
			this.dtpkNgayThang.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.dtpkNgayThang.Name = "dtpkNgayThang";
			this.dtpkNgayThang.Size = new System.Drawing.Size(191, 20);
			this.dtpkNgayThang.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 110);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Người ký BC";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 140);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Người ký BP";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 170);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Số trang";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 200);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(50, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "Nơi nhận";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(13, 230);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(54, 13);
			this.label9.TabIndex = 12;
			this.label9.Text = "Lưu hồ sơ";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(13, 260);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 13);
			this.label10.TabIndex = 13;
			this.label10.Text = "Số hộp";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(13, 290);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(26, 13);
			this.label11.TabIndex = 14;
			this.label11.Text = "Tệp";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(13, 320);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 13);
			this.label12.TabIndex = 15;
			this.label12.Text = "Ghi chú";
			// 
			// tbNKBC
			// 
			this.tbNKBC.Location = new System.Drawing.Point(94, 107);
			this.tbNKBC.MaxLength = 50;
			this.tbNKBC.Name = "tbNKBC";
			this.tbNKBC.Size = new System.Drawing.Size(292, 20);
			this.tbNKBC.TabIndex = 16;
			// 
			// tbNKBP
			// 
			this.tbNKBP.Location = new System.Drawing.Point(94, 137);
			this.tbNKBP.MaxLength = 50;
			this.tbNKBP.Name = "tbNKBP";
			this.tbNKBP.Size = new System.Drawing.Size(292, 20);
			this.tbNKBP.TabIndex = 17;
			// 
			// nmrSoTrang
			// 
			this.nmrSoTrang.Location = new System.Drawing.Point(95, 168);
			this.nmrSoTrang.Name = "nmrSoTrang";
			this.nmrSoTrang.Size = new System.Drawing.Size(120, 20);
			this.nmrSoTrang.TabIndex = 18;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(220, 170);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(41, 13);
			this.label13.TabIndex = 19;
			this.label13.Text = "Số bản";
			// 
			// nmrSoBan
			// 
			this.nmrSoBan.Location = new System.Drawing.Point(266, 168);
			this.nmrSoBan.Name = "nmrSoBan";
			this.nmrSoBan.Size = new System.Drawing.Size(120, 20);
			this.nmrSoBan.TabIndex = 20;
			// 
			// tbNoiNhan
			// 
			this.tbNoiNhan.Location = new System.Drawing.Point(94, 197);
			this.tbNoiNhan.MaxLength = 50;
			this.tbNoiNhan.Name = "tbNoiNhan";
			this.tbNoiNhan.Size = new System.Drawing.Size(292, 20);
			this.tbNoiNhan.TabIndex = 21;
			// 
			// tbLuuHS
			// 
			this.tbLuuHS.Location = new System.Drawing.Point(94, 227);
			this.tbLuuHS.MaxLength = 50;
			this.tbLuuHS.Name = "tbLuuHS";
			this.tbLuuHS.Size = new System.Drawing.Size(292, 20);
			this.tbLuuHS.TabIndex = 22;
			// 
			// nmrSoHop
			// 
			this.nmrSoHop.Location = new System.Drawing.Point(95, 258);
			this.nmrSoHop.Name = "nmrSoHop";
			this.nmrSoHop.Size = new System.Drawing.Size(120, 20);
			this.nmrSoHop.TabIndex = 23;
			// 
			// tbTep
			// 
			this.tbTep.Enabled = false;
			this.tbTep.Location = new System.Drawing.Point(95, 287);
			this.tbTep.Name = "tbTep";
			this.tbTep.Size = new System.Drawing.Size(228, 20);
			this.tbTep.TabIndex = 24;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// btChon
			// 
			this.btChon.Location = new System.Drawing.Point(329, 284);
			this.btChon.Name = "btChon";
			this.btChon.Size = new System.Drawing.Size(57, 23);
			this.btChon.TabIndex = 25;
			this.btChon.Text = "Chọn...";
			this.btChon.UseVisualStyleBackColor = true;
			// 
			// tbGhiChu
			// 
			this.tbGhiChu.Location = new System.Drawing.Point(94, 317);
			this.tbGhiChu.Multiline = true;
			this.tbGhiChu.Name = "tbGhiChu";
			this.tbGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbGhiChu.Size = new System.Drawing.Size(292, 71);
			this.tbGhiChu.TabIndex = 26;
			// 
			// btThem
			// 
			this.btThem.Location = new System.Drawing.Point(113, 415);
			this.btThem.Name = "btThem";
			this.btThem.Size = new System.Drawing.Size(75, 23);
			this.btThem.TabIndex = 27;
			this.btThem.Text = "Thêm";
			this.btThem.UseVisualStyleBackColor = true;
			// 
			// btHuy
			// 
			this.btHuy.Location = new System.Drawing.Point(223, 415);
			this.btHuy.Name = "btHuy";
			this.btHuy.Size = new System.Drawing.Size(75, 23);
			this.btHuy.TabIndex = 28;
			this.btHuy.Text = "Hủy";
			this.btHuy.UseVisualStyleBackColor = true;
			// 
			// VBDi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 449);
			this.Controls.Add(this.btHuy);
			this.Controls.Add(this.btThem);
			this.Controls.Add(this.tbGhiChu);
			this.Controls.Add(this.btChon);
			this.Controls.Add(this.tbTep);
			this.Controls.Add(this.nmrSoHop);
			this.Controls.Add(this.tbLuuHS);
			this.Controls.Add(this.tbNoiNhan);
			this.Controls.Add(this.nmrSoBan);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.nmrSoTrang);
			this.Controls.Add(this.tbNKBP);
			this.Controls.Add(this.tbNKBC);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dtpkNgayThang);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbbLoai);
			this.Controls.Add(this.tbSoHieu);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbTenVB);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "VBDi";
			this.Text = "Văn Bản Đi";
			((System.ComponentModel.ISupportInitialize)(this.nmrSoTrang)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmrSoBan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmrSoHop)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbTenVB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbSoHieu;
		private System.Windows.Forms.ComboBox cbbLoai;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpkNgayThang;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbNKBC;
		private System.Windows.Forms.TextBox tbNKBP;
		private System.Windows.Forms.NumericUpDown nmrSoTrang;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.NumericUpDown nmrSoBan;
		private System.Windows.Forms.TextBox tbNoiNhan;
		private System.Windows.Forms.TextBox tbLuuHS;
		private System.Windows.Forms.NumericUpDown nmrSoHop;
		private System.Windows.Forms.TextBox tbTep;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btChon;
		private System.Windows.Forms.TextBox tbGhiChu;
		private System.Windows.Forms.Button btThem;
		private System.Windows.Forms.Button btHuy;
	}
}