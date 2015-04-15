namespace QuanLyVanBan
{
	partial class TimKiem
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
			this.tbTen = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dtpkNgayThang = new System.Windows.Forms.DateTimePicker();
			this.rdobtNgay = new System.Windows.Forms.RadioButton();
			this.rdobtThang = new System.Windows.Forms.RadioButton();
			this.rdobtNam = new System.Windows.Forms.RadioButton();
			this.cbbLoai = new System.Windows.Forms.ComboBox();
			this.btTim = new System.Windows.Forms.Button();
			this.btHuy = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tên văn bản:";
			// 
			// tbTen
			// 
			this.tbTen.Location = new System.Drawing.Point(80, 30);
			this.tbTen.Name = "tbTen";
			this.tbTen.Size = new System.Drawing.Size(229, 20);
			this.tbTen.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Loại:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdobtNam);
			this.groupBox1.Controls.Add(this.rdobtThang);
			this.groupBox1.Controls.Add(this.rdobtNgay);
			this.groupBox1.Controls.Add(this.dtpkNgayThang);
			this.groupBox1.Location = new System.Drawing.Point(10, 100);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(299, 113);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ngày tháng";
			// 
			// dtpkNgayThang
			// 
			this.dtpkNgayThang.CustomFormat = "yyyy";
			this.dtpkNgayThang.Location = new System.Drawing.Point(57, 30);
			this.dtpkNgayThang.Name = "dtpkNgayThang";
			this.dtpkNgayThang.Size = new System.Drawing.Size(205, 20);
			this.dtpkNgayThang.TabIndex = 0;
			// 
			// rdobtNgay
			// 
			this.rdobtNgay.AutoSize = true;
			this.rdobtNgay.Location = new System.Drawing.Point(57, 70);
			this.rdobtNgay.Name = "rdobtNgay";
			this.rdobtNgay.Size = new System.Drawing.Size(50, 17);
			this.rdobtNgay.TabIndex = 1;
			this.rdobtNgay.TabStop = true;
			this.rdobtNgay.Text = "Ngày";
			this.rdobtNgay.UseVisualStyleBackColor = true;
			// 
			// rdobtThang
			// 
			this.rdobtThang.AutoSize = true;
			this.rdobtThang.Location = new System.Drawing.Point(131, 70);
			this.rdobtThang.Name = "rdobtThang";
			this.rdobtThang.Size = new System.Drawing.Size(56, 17);
			this.rdobtThang.TabIndex = 2;
			this.rdobtThang.TabStop = true;
			this.rdobtThang.Text = "Tháng";
			this.rdobtThang.UseVisualStyleBackColor = true;
			// 
			// rdobtNam
			// 
			this.rdobtNam.AutoSize = true;
			this.rdobtNam.Location = new System.Drawing.Point(215, 70);
			this.rdobtNam.Name = "rdobtNam";
			this.rdobtNam.Size = new System.Drawing.Size(47, 17);
			this.rdobtNam.TabIndex = 3;
			this.rdobtNam.TabStop = true;
			this.rdobtNam.Text = "Năm";
			this.rdobtNam.UseVisualStyleBackColor = true;
			// 
			// cbbLoai
			// 
			this.cbbLoai.FormattingEnabled = true;
			this.cbbLoai.Location = new System.Drawing.Point(80, 60);
			this.cbbLoai.Name = "cbbLoai";
			this.cbbLoai.Size = new System.Drawing.Size(229, 21);
			this.cbbLoai.TabIndex = 5;
			// 
			// btTim
			// 
			this.btTim.Location = new System.Drawing.Point(67, 234);
			this.btTim.Name = "btTim";
			this.btTim.Size = new System.Drawing.Size(75, 23);
			this.btTim.TabIndex = 6;
			this.btTim.Text = "Tìm";
			this.btTim.UseVisualStyleBackColor = true;
			this.btTim.Click += new System.EventHandler(this.btTim_Click);
			// 
			// btHuy
			// 
			this.btHuy.Location = new System.Drawing.Point(177, 234);
			this.btHuy.Name = "btHuy";
			this.btHuy.Size = new System.Drawing.Size(75, 23);
			this.btHuy.TabIndex = 7;
			this.btHuy.Text = "Hủy";
			this.btHuy.UseVisualStyleBackColor = true;
			this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
			// 
			// TimKiem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 269);
			this.Controls.Add(this.btHuy);
			this.Controls.Add(this.btTim);
			this.Controls.Add(this.cbbLoai);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbTen);
			this.Controls.Add(this.label1);
			this.Name = "TimKiem";
			this.Text = "TimKiem";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbTen;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dtpkNgayThang;
		private System.Windows.Forms.RadioButton rdobtNam;
		private System.Windows.Forms.RadioButton rdobtThang;
		private System.Windows.Forms.RadioButton rdobtNgay;
		private System.Windows.Forms.ComboBox cbbLoai;
		private System.Windows.Forms.Button btTim;
		private System.Windows.Forms.Button btHuy;
	}
}