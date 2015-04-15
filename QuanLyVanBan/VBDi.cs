using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyVanBan
{
	public partial class VBDi : Form
	{
		bool isEdit;
		DataGridViewCellCollection row;
		public VBDi(bool edit, DataGridViewCellCollection row)
		{
			InitializeComponent();
			cbbLoai.Items.AddRange(ManHinhChinh.loaiVB);
			cbbLoai.SelectedIndex = 0;
			isEdit = edit;
			this.row = row;
			if (edit)
			{
				btThem.Text = "Sửa";
				tbSoHieu.Enabled = false;
				btChon.Enabled = false;
				tbSoHieu.Text = row[0].Value.ToString();
				tbTenVB.Text = row[1].Value.ToString();
				cbbLoai.SelectedItem = row[2].Value.ToString();
				dtpkNgayThang.Value = (DateTime)row[3].Value;
				tbNKBC.Text = row[4].Value.ToString();
				tbNKBP.Text = row[5].Value.ToString();
				nmrSoTrang.Value = (int)row[6].Value;
				nmrSoBan.Value = (int)row[7].Value;
				tbNoiNhan.Text = row[8].Value.ToString();
				tbLuuHS.Text = row[9].Value.ToString();
				nmrSoHop.Value = (int)row[10].Value;
				tbTep.Text = row[11].Value.ToString();
				tbGhiChu.Text = row[12].Value.ToString();
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
				Class.Database db = new Class.Database();
				if (!db.connect())
				{
					MessageBox.Show(this, "Kết nối cơ sở dữ liệu lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					return;
				}
				Class.QuanLyTep qltep = new Class.QuanLyTep(2, dtpkNgayThang.Value, tbTep.Text, tbSoHieu.Text);
				MySqlCommand cmd;
				if (!isEdit)
				{
					cmd = new MySqlCommand("SELECT * FROM vbdi where SoHieu='" + tbSoHieu.Text + "';", db.getConnection());
					MySqlDataReader reader = cmd.ExecuteReader();
					bool hasRows = reader.HasRows;
					reader.Close();
					if (hasRows)
					{
						MessageBox.Show(this, "Số hiệu văn bản đã tồn tại trong cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						db.close();
						return;
					}


					cmd = new MySqlCommand("insert into vbdi values (@soHieu, @ten, @loai, @ngay, @ngKyBanChinh, @ngKyBanPhu, @soTrang, @soBan, @noiNhan, @luuHoSo, @soHop, @tep, @ghiChu);", db.getConnection());
				}
				else
				{
					cmd = new MySqlCommand("UPDATE vbdi SET SoHieu=@soHieu, Ten=@ten, Loai=@loai, Ngay=@ngay, NgKyBanChinh=@ngKyBanChinh, NgKyBanPhu=@ngKyBanPhu, SoTrang=@soTrang, SoBan=@soBan, NoiNhan=@noiNhan, LuuHoSo=@luuHoSo, SoHop=@soHop, GhiChu=@ghiChu, Tep=@tep WHERE SoHieu=@soHieu;", db.getConnection());
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
				cmd.Prepare();

				cmd.Parameters.AddWithValue("@soHieu", tbSoHieu.Text);
				cmd.Parameters.AddWithValue("@ten", tbTenVB.Text);
				cmd.Parameters.AddWithValue("@loai", (string)cbbLoai.SelectedItem);
				cmd.Parameters.AddWithValue("@ngay", dtpkNgayThang.Value);
				cmd.Parameters.AddWithValue("@ngKyBanChinh", tbNKBC.Text);
				cmd.Parameters.AddWithValue("@ngKyBanPhu", tbNKBP.Text);
				cmd.Parameters.AddWithValue("@sotrang", nmrSoTrang.Value);
				cmd.Parameters.AddWithValue("@soban", nmrSoBan.Value);
				cmd.Parameters.AddWithValue("@noiNhan", tbNoiNhan.Text);
				cmd.Parameters.AddWithValue("@luuHoSo", tbLuuHS.Text);
				cmd.Parameters.AddWithValue("@soHop", nmrSoHop.Value);
				cmd.Parameters.AddWithValue("@tep", qltep.getNewPath());
				cmd.Parameters.AddWithValue("@ghiChu", tbGhiChu.Text);
				if (cmd.ExecuteNonQuery() > 0)
				{
					qltep.themTep();
					MessageBox.Show(this, "Lưu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					db.close();
					((ManHinhChinh)Owner).vbdiDate = dtpkNgayThang.Value;
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
			openFileDialog1.ShowDialog();
		}
	}
}
