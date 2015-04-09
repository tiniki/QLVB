namespace QuanLyVanBan
{
	partial class ThayDoiMatKhau
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbMKHT = new System.Windows.Forms.TextBox();
			this.tbMKM = new System.Windows.Forms.TextBox();
			this.tbNLMK = new System.Windows.Forms.TextBox();
			this.btOK = new System.Windows.Forms.Button();
			this.btHuy = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbMKHT, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tbMKM, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tbNLMK, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 122);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btHuy);
			this.panel1.Controls.Add(this.btOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 121);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(362, 35);
			this.panel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mật khẩu hiện tại *";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 48);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mật khẩu mới *";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 82);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Nhập lại mật khẩu";
			// 
			// tbMKHT
			// 
			this.tbMKHT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbMKHT.Location = new System.Drawing.Point(133, 13);
			this.tbMKHT.Name = "tbMKHT";
			this.tbMKHT.PasswordChar = '*';
			this.tbMKHT.Size = new System.Drawing.Size(216, 20);
			this.tbMKHT.TabIndex = 3;
			// 
			// tbMKM
			// 
			this.tbMKM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbMKM.Location = new System.Drawing.Point(133, 46);
			this.tbMKM.Name = "tbMKM";
			this.tbMKM.PasswordChar = '*';
			this.tbMKM.Size = new System.Drawing.Size(216, 20);
			this.tbMKM.TabIndex = 4;
			// 
			// tbNLMK
			// 
			this.tbNLMK.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbNLMK.Location = new System.Drawing.Point(133, 80);
			this.tbNLMK.Name = "tbNLMK";
			this.tbNLMK.PasswordChar = '*';
			this.tbNLMK.Size = new System.Drawing.Size(216, 20);
			this.tbNLMK.TabIndex = 5;
			// 
			// btOK
			// 
			this.btOK.Location = new System.Drawing.Point(80, 3);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(75, 23);
			this.btOK.TabIndex = 0;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btHuy
			// 
			this.btHuy.Location = new System.Drawing.Point(178, 3);
			this.btHuy.Name = "btHuy";
			this.btHuy.Size = new System.Drawing.Size(75, 23);
			this.btHuy.TabIndex = 1;
			this.btHuy.Text = "Hủy";
			this.btHuy.UseVisualStyleBackColor = true;
			this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
			// 
			// ThayDoiMatKhau
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 156);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ThayDoiMatKhau";
			this.Text = "Thay Đổi Mật Khẩu";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbMKHT;
		private System.Windows.Forms.TextBox tbMKM;
		private System.Windows.Forms.TextBox tbNLMK;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btHuy;
		private System.Windows.Forms.Button btOK;
	}
}