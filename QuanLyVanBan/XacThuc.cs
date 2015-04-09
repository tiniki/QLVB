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
	public partial class XacThuc : Form
	{
		public XacThuc()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if ((new Class.BaoMat(textBox1.Text)).dungMK())
			{
				Program.OpenMain = true;
				this.Close();
			}
			else
			{
				MessageBox.Show(this, "Mật khẩu không đúng . Vui lòng thử lại", "Xác thực không thành công");
			}
		}
	}
}
