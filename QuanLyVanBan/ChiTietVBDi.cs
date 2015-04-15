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
	public partial class ChiTietVBDi : Form
	{
		public ChiTietVBDi(DataGridViewRow row)
		{
			InitializeComponent();
			int i = 0;
			lbSoHieu.Text = row.Cells[i++].Value.ToString();
			lbTen.Text = row.Cells[i++].Value.ToString();
			lbLoai.Text = row.Cells[i++].Value.ToString();
			lbNgayThang.Text = ((DateTime)row.Cells[i++].Value).ToString("d");
			lbNgKyBC.Text = row.Cells[i++].Value.ToString();
			lbNgKyBP.Text = row.Cells[i++].Value.ToString();
			lbSoTrang.Text = row.Cells[i++].Value.ToString();
			lbSoBan.Text = row.Cells[i++].Value.ToString();
			lbNoiNhan.Text = row.Cells[i++].Value.ToString();
			lbLuuHS.Text = row.Cells[i++].Value.ToString();
			lbSoHop.Text = row.Cells[i++].Value.ToString();
			lbTep.Text = row.Cells[i++].Value.ToString();
			tbGhiChu.Text = row.Cells[i++].Value.ToString();
		}

		private void lbTep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(lbTep.Text);
		}
	}
}
