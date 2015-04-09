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
	public partial class ThayDoiMatKhau : Form
	{
		public ThayDoiMatKhau()
		{
			InitializeComponent();
		}

		private void btHuy_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			if (tbMKHT.Text.Equals("") || tbMKM.Text.Equals(""))
			{
				MessageBox.Show(this, "Mật khẩu không thể để trống");
			}
			else if (tbMKHT.Text.Length < 6 || tbMKM.Text.Length < 6)
			{
				MessageBox.Show(this, "Mật khẩu phải có ít nhất 6 kí tự");
			}
			else if (!tbMKM.Text.Equals(tbNLMK.Text))
			{
				MessageBox.Show(this, "Mật khẩu nhập lại không khớp");
			}
			else
			{
				Class.BaoMat bm=new Class.BaoMat(tbMKHT.Text);
				if (bm.dungMK())
				{
					bm = new Class.BaoMat(tbMKM.Text);
					bm.luuMK();
					MessageBox.Show(this, "Lưu thành công");
					Close();
				}
				else
				{
					MessageBox.Show(this, "Mật khẩu không đúng");
				}
			}
		}
	}
}
