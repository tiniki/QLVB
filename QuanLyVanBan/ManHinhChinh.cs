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
	public partial class ManHinhChinh : Form
	{
		public static readonly string[] loaiVB = { "Công văn", "Chương trình", "Nghị quyết", "Quyết định", "Báo cáo", "Kết luận", "Thông báo", "Tài liệu mật", "Khác" };
		public static readonly string connectString = string.Format("Server={0};Port={1};Database=document;Uid={2};Pwd=toor;", Properties.Settings.Default.Server, Properties.Settings.Default.Port, Properties.Settings.Default.User);
		public ManHinhChinh()
		{
			InitializeComponent();
		}

		private void thietLaptoolStripButton_Click(object sender, EventArgs e)
		{
			ThayDoiMatKhau thaydoiMK = new ThayDoiMatKhau();
			thaydoiMK.ShowDialog(this);
		}

		private void themtoolStripButton_Click(object sender, EventArgs e)
		{
			DialogResult dalRs;
			if (tabControl1.SelectedTab == vBDebtabPage)
			{
				VBDen vbden = new VBDen();
				dalRs = vbden.ShowDialog(this);
			}
			else if (tabControl1.SelectedTab==vBDitabPage)
			{
				VBDi vbdi = new VBDi();
				dalRs = vbdi.ShowDialog(this);
			}
		}
	}
}
