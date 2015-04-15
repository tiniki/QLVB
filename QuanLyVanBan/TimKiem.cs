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
	public partial class TimKiem : Form
	{
		int loaiVB;
		public TimKiem(int loai)
		{
			InitializeComponent();
			loaiVB = loai;
			if (loai == 1)
			{
				Text = "Tìm kiếm vắn bản đến";
			}
			else{
				Text = "Tìm kiếm văn bản đi";
			}
			cbbLoai.Items.AddRange(ManHinhChinh.loaiVB);
		}

		private void btHuy_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btTim_Click(object sender, EventArgs e)
		{
			Class.Database db = new Class.Database();
			db.connect();
			string cmdString;
			if (loaiVB == 1)
			{
				cmdString = "SELECT * FROM vbden where 1=1 ";
			}
			else cmdString = "SELECT * FROM vbdi where 1=1 ";
			if (tbTen.Text != "") cmdString += string.Format("and Ten like '{0}%' ", tbTen.Text);
			if (cbbLoai.SelectedItem != null) cmdString += string.Format("and Loai='{0}' ", cbbLoai.SelectedItem.ToString());
			if (rdobtNam.Checked) cmdString += string.Format("and date_format(Ngay,'%Y')='{0}'", dtpkNgayThang.Value.ToString("yyyy"));
			if (rdobtThang.Checked) cmdString += string.Format("and date_format(Ngay,'%Y-%m')='{0}'", dtpkNgayThang.Value.ToString("yyyy-MM"));
			if (rdobtNgay.Checked) cmdString += string.Format("and Ngay='{0}'", dtpkNgayThang.Value.ToString("yyyy-MM-dd"));
			MySqlDataAdapter adapter=new MySqlDataAdapter(cmdString,db.getConnection());
			ManHinhChinh owner = (ManHinhChinh)Owner;
			owner.dataSetKQ.Clear();
			adapter.Fill(owner.dataSetKQ);
			owner.kQTKdataGridView.DataSource = owner.dataSetKQ.Tables[0];
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
