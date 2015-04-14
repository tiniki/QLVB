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
		bool isEdit;
		string soHieu;
		public VBDen(bool Edit,string sHieu)
		{

			InitializeComponent();
			cbbLoai.Items.AddRange(ManHinhChinh.loaiVB);
			cbbLoai.SelectedIndex = 0;
			isEdit = Edit;
			soHieu = sHieu;
			if (Edit)
			{
				btThem.Text = "Sửa";
				tbSoHieu.Enabled = false;
				btChon.Enabled = false;
				Class.Database db = new Class.Database();
				if (!db.connect())
				{
					MessageBox.Show(this, "Kết nối cơ sở dữ liệu lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					return;
				}
				var cmd = new MySqlCommand("SELECT * FROM vbden where SoHieu='" + soHieu + "';", db.getConnection());
				MySqlDataReader reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					tbTenVB.Text = reader.GetString("Ten");
					cbbLoai.SelectedItem = reader.GetString("Loai");
					dtpkNgayThang.Value = reader.GetDateTime("Ngay");
					tbSoHieu.Text = reader.GetString("SoHieu");
					tbTacGia.Text = reader.GetString("TacGia");
					nmrSoTrang.Value = reader.GetInt32("SoTrang");
					nmrSoBan.Value = reader.GetInt32("SoBan");
					tbChuyenChoAi.Text = reader.GetString("ChuyenChoAi");
					tbLuuHS.Text = reader.GetString("LuuHoSo");
					nmrSoHop.Value = reader.GetInt32("SoHop");
					tbGhiChu.Text = reader.GetString("GhiChu");
					tbTep.Text = reader.GetString("Tep");
					reader.Close();
				}
				else
				{
					MessageBox.Show(this, "Kết nối cơ sở dữ liệu lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				}
				db.close();
			}
			
		}

		private void btHuy_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btThem_Click(object sender, EventArgs e)
		{
			if (tbTenVB.Text.Trim().Equals("")) MessageBox.Show(this, "Tên văn bản phải được nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			else if (tbSoHieu.Text.Trim().Equals("")) MessageBox.Show(this, "Số hiệu phải được nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			else if (dtpkNgayThang.Value < dtpkNgayThang.MinDate || dtpkNgayThang.Value > dtpkNgayThang.MaxDate)
				MessageBox.Show(this, "Ngày phải nằm trong khoảng từ 01/01/1990 đến 31/12/2099", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			else
			{
				MySqlCommand cmd;
				Class.Database db = new Class.Database();
				if (!db.connect())
				{
					MessageBox.Show(this, "Kết nối cơ sở dữ liệu lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					return;
				}
				Class.QuanLyTep qltep = new Class.QuanLyTep(1, dtpkNgayThang.Value, tbTep.Text);
				
				if (!isEdit)
				{
					cmd = new MySqlCommand("SELECT * FROM vbden where SoHieu='" + tbSoHieu.Text + "';", db.getConnection());
					MySqlDataReader reader = cmd.ExecuteReader();
					bool hasRows = reader.HasRows;
					reader.Close();
					if (hasRows)
					{
						MessageBox.Show(this, "Số hiệu văn bản đã tồn tại trong cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						db.close();
						return;
					}
					int ktfile = qltep.kiemtra();
					if (ktfile != 0)
					{
						if (ktfile == 2)
						{
							MessageBox.Show(this, "Không thể tạo thư mục", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
							db.close();
							return;
						}
						if (ktfile == 3)
						{
							MessageBox.Show(this, "Tệp không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
							db.close();
							return;
						}
						if (ktfile == 4)
						{
							MessageBox.Show(this, "Không thể truy xuất đến tệp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
							db.close();
							return;
						}

						if (ktfile == 10)
						{
							var dialog = MessageBox.Show("Tệp đã tồn tại. Bạn có muốn copy đè lên không?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
							if (dialog == DialogResult.Yes)
							{
								qltep.setOverwriten(true);
							}
							else if (dialog == DialogResult.No)
							{
								qltep.setOverwriten(false);
							}
							else
							{
								db.close();
								return;
							}
						}
					}
					cmd = new MySqlCommand("insert into vbden values (@soHieu,@ten,@loai,@ngay,@tacgia,@sotrang,@soban,@chuyenChoAi,@luuHoSo,@soHop,@tep,@ghiChu);", db.getConnection());
				}
				else
				{
					
					cmd = new MySqlCommand("UPDATE vbden SET Ten=@ten, Loai=@loai, Ngay=@ngay, TacGia=@tacGia, SoTrang=@soTrang, SoBan=@soBan, ChuyenChoAi=@chuyenChoAi, LuuHoSo=@luuHoSo, SoHop=@soHop, GhiChu=@ghiChu WHERE SoHieu=@soHieu;", db.getConnection());
				}

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
				if (!isEdit)
					cmd.Parameters.AddWithValue("@tep", qltep.getNewPath());
				cmd.Parameters.AddWithValue("@ghiChu", tbGhiChu.Text);
				if (cmd.ExecuteNonQuery() > 0)
				{
					if (!isEdit)
						qltep.themTep();
					MessageBox.Show(this, "Lưu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					db.close();
					((ManHinhChinh)Owner).vbdenDate = dtpkNgayThang.Value;
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
