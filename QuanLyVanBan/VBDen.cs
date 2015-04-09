using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QuanLyVanBan
{
	public partial class VBDen : Form
	{
		public VBDen()
		{
			
			InitializeComponent();
			cbbLoai.Items.AddRange(ManHinhChinh.loaiVB);
			cbbLoai.SelectedIndex = 0;
		}

		private void btHuy_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btThem_Click(object sender, EventArgs e)
		{
			if (tbTenVB.Text.Trim().Equals("")) MessageBox.Show(this, "Tên văn bản phải được nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			else if(tbSoHieu.Text.Trim().Equals("")) MessageBox.Show(this, "Số hiệu phải được nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			else if(dtpkNgayThang.Value<dtpkNgayThang.MinDate||dtpkNgayThang.Value>dtpkNgayThang.MaxDate)
				MessageBox.Show(this, "Ngày phải nằm trong khoảng từ 01/01/1990 đến 31/12/2099", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			else
			{
				Class.Database db = new Class.Database();
				if (!db.connect())
				{
					MessageBox.Show(this, "Kết nối cơ sở dữ liệu lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					return;
				}
				MySqlCommand cmd = new MySqlCommand("SELECT * FROM vbden where SoHieu='"+tbSoHieu.Text+"';",db.getConnection());
				MySqlDataReader reader=cmd.ExecuteReader();
				bool hasRows=reader.HasRows;
				reader.Close();
				if (hasRows)
				{
					MessageBox.Show(this, "Số hiệu văn bản đã tồn tại trong cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					db.close();
					return;
				}
				Class.QuanLyTep qltep = new Class.QuanLyTep(1, dtpkNgayThang.Value, openFileDialog1.FileName);
				cmd = new MySqlCommand("insert into vbden values (@soHieu,@ten,@loai,@ngay,@tacgia,@sotrang,@soban,@chuyenChoAi,@luuHoSo,@soHop,@tep,@ghiChu);", db.getConnection());
				cmd.Prepare();
				
				cmd.Parameters.AddWithValue("@soHieu", tbSoHieu.Text);
				cmd.Parameters.AddWithValue("@ten", tbTenVB.Text);
				cmd.Parameters.AddWithValue("@loai", (string)cbbLoai.SelectedItem);
				cmd.Parameters.AddWithValue("@ngay", dtpkNgayThang.Value);
				cmd.Parameters.AddWithValue("@tacgia", tbTacGia.Text);
				cmd.Parameters.AddWithValue("@sotrang", nmrSoTrang.Value);
				cmd.Parameters.AddWithValue("@soban", nmrSoBan.Value);
				cmd.Parameters.AddWithValue("@chuyenChoAi", tbChuyenChoAi.Text);
				cmd.Parameters.AddWithValue("@luuHoSo", tbLuuHS.Text);
				cmd.Parameters.AddWithValue("@soHop", nmrSoHop.Value);
				cmd.Parameters.AddWithValue("@tep", qltep.getNewPath());
				cmd.Parameters.AddWithValue("@ghiChu", tbGhiChu.Text);
				if (cmd.ExecuteNonQuery() > 0)
				{
					qltep.themTep();
					MessageBox.Show(this, "Lưu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					db.close();
					DialogResult = DialogResult.OK;
					Close();
				}

			}
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			tbTep.Text = openFileDialog1.FileName;
		}

		private void btChon_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog(this);
		}
	}
}
