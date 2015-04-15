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
	public partial class ManHinhChinh : Form
	{
		public static readonly string[] loaiVB = { "Công văn", "Chương trình", "Nghị quyết", "Quyết định", "Báo cáo", "Kết luận", "Thông báo", "Tài liệu mật", "Khác" };
		public static readonly string connectString = string.Format("Server={0};Port={1};Database=document;Uid={2};Pwd=toor;", Properties.Settings.Default.Server, Properties.Settings.Default.Port, Properties.Settings.Default.User);
		public static DateTime d0 = new DateTime(1, 1, 1);
		DataSet dataSetVBDen, dataSetVBDi;
		internal DataSet dataSetKQ;
		internal int ketQuaLoaiVB;
		internal DateTime vbdenDate, vbdiDate;
		public ManHinhChinh()
		{
			InitializeComponent();
			dataSetVBDen = new DataSet();
			dataSetVBDi = new DataSet();
			dataSetKQ = new DataSet();
			loadTreeView(d0, vbDentreeView);
			loadTreeView(d0, vBDitreeView);
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
				VBDen vbden = new VBDen(false, null);
				dalRs = vbden.ShowDialog(this);
				if (dalRs == DialogResult.OK)
					loadTreeView(vbdenDate, vbDentreeView);
			}
			else if (tabControl1.SelectedTab == vBDitabPage)
			{
				VBDi vbdi = new VBDi(false, null);
				dalRs = vbdi.ShowDialog(this);
				if (dalRs == DialogResult.OK)
					loadTreeView(vbdiDate, vBDitreeView);
			}
		}
		private void loadTreeView(DateTime date, TreeView trv)
		{
			trv.Nodes.Clear();
			Class.Database db = new Class.Database();
			if (!db.connect())
			{
				MessageBox.Show(this, "Kết nối cơ sở dữ liệu lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				Application.Exit();
			}
			var cmd = new MySqlCommand(string.Format("SELECT distinct year(Ngay) as y FROM {0} order by y;", trv.Tag), db.getConnection());
			MySqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				trv.Nodes.Add(reader.GetInt32(0).ToString(), reader.GetInt32(0).ToString());
			}
			reader.Close();
			for (int i = 0; i < trv.Nodes.Count; i++)
			{
				int y = int.Parse(trv.Nodes[i].Text);
				cmd = new MySqlCommand(string.Format("SELECT distinct month(Ngay) as m FROM {0} where year(Ngay)={1} order by m;", trv.Tag, y), db.getConnection());
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					trv.Nodes[i].Nodes.Add(reader.GetInt32(0).ToString(), reader.GetInt32(0).ToString());

				}
				reader.Close();
			}
			db.close();
			if (trv.Nodes.Count > 0)
			{
				if (date == d0)
				{
					var nodel1 = trv.Nodes[trv.GetNodeCount(false) - 1];
					trv.SelectedNode = nodel1.LastNode;
				}
				else
				{
					trv.SelectedNode = trv.Nodes.Find(date.Year.ToString(), false).First().Nodes.Find(date.Month.ToString(), false).First();
				}
			}
		}

		private void vBDitreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			Class.Database db = new Class.Database();
			db.connect();
			string cmdString = "SELECT * FROM vbdi where year(Ngay)=";
			if (12 < int.Parse(e.Node.Text))
			{
				cmdString += e.Node.Text;
			}
			else
			{
				cmdString += string.Format("{0} and month(Ngay)={1}", e.Node.Parent.Text, e.Node.Text);
			}
			dataSetVBDi.Clear();
			MySqlDataAdapter adapter = new MySqlDataAdapter(cmdString, db.getConnection());
			adapter.Fill(dataSetVBDi);
			db.close();
			vBDidataGridView.DataSource = dataSetVBDi.Tables[0];
		}

		private void vbDentreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			Class.Database db = new Class.Database();
			db.connect();
			string cmdString = "SELECT * FROM vbden where year(Ngay)=";
			if (12 < int.Parse(e.Node.Text))
			{
				cmdString += e.Node.Text;
			}
			else
			{
				cmdString += string.Format("{0} and month(Ngay)={1}", e.Node.Parent.Text, e.Node.Text);
			}
			dataSetVBDen.Clear();
			MySqlDataAdapter adapter = new MySqlDataAdapter(cmdString, db.getConnection());
			adapter.Fill(dataSetVBDen);
			db.close();
			vBDendataGridView.DataSource = dataSetVBDen.Tables[0];
		}

		private void suatoolStripButton1_Click(object sender, EventArgs e)
		{
			DialogResult dalRs;
			if (tabControl1.SelectedTab == vBDebtabPage)
			{
				VBDen vbden = new VBDen(true, vBDendataGridView.SelectedRows[0].Cells);
				dalRs = vbden.ShowDialog(this);
				if (dalRs == DialogResult.OK)
					loadTreeView(vbdenDate, vbDentreeView);
			}
			else if (tabControl1.SelectedTab == vBDitabPage)
			{
				VBDi vbdi = new VBDi(true, vBDidataGridView.SelectedRows[0].Cells);
				dalRs = vbdi.ShowDialog(this);
				if (dalRs == DialogResult.OK)
					loadTreeView(vbdiDate, vBDitreeView);
			}
			else if (tabControl1.SelectedTab == kQTKtabPage)
			{
				if (ketQuaLoaiVB == 1)
				{
					VBDen vbden = new VBDen(true, kQTKdataGridView.SelectedRows[0].Cells);
					if (vbden.ShowDialog(this) == DialogResult.OK)
					{
						loadTreeView(vbdenDate, vbDentreeView);
						tabControl1.SelectedTab = vBDebtabPage;
					}
				}
				else
				{
					VBDi vbdi = new VBDi(true, kQTKdataGridView.SelectedRows[0].Cells);
					if (vbdi.ShowDialog(this) == DialogResult.OK)
					{
						loadTreeView(vbdiDate, vBDitreeView);
						tabControl1.SelectedTab = vBDitabPage;
					}
						
				}
				dataSetKQ.Clear();
			}
		}

		private void ManHinhChinh_Activated(object sender, EventArgs e)
		{
			Console.WriteLine("Act");
			if (tabControl1.SelectedTab == vBDebtabPage)
				checkButton(vBDendataGridView);
			else if (tabControl1.SelectedTab == vBDitabPage)
				checkButton(vBDidataGridView);
			else checkButton(kQTKdataGridView);
		}

		private void checkButton(DataGridView dtgrv)
		{
			xemtoolStripButton.Enabled = suatoolStripButton1.Enabled = xoatoolStripButton.Enabled = dtgrv.SelectedCells.Count != 0;
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ManHinhChinh_Activated(this, new EventArgs());
			timKiemtoolStripButton.Enabled = themtoolStripButton.Enabled = timKiemToolStripMenuItem.Enabled = themToolStripMenuItem.Enabled = thêmToolStripMenuItem.Enabled = tabControl1.SelectedTab  != kQTKtabPage;
		}

		private void xoatoolStripButton_Click(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == vBDebtabPage && vBDendataGridView.SelectedRows.Count > 0)
			{

				if (MessageBox.Show(this, "Bạn có chắc muốn xóa (những) văn bản được chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					xoaVB("vbden", vBDendataGridView.SelectedRows);
					loadTreeView(d0, vbDentreeView);
				}
			}
			else if (tabControl1.SelectedTab == vBDitabPage && vBDidataGridView.SelectedRows.Count > 0)
			{

				if (MessageBox.Show(this, "Bạn có chắc muốn xóa (những) văn bản được chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					xoaVB("vbdi", vBDidataGridView.SelectedRows);
					loadTreeView(d0, vBDitreeView);
				}
			}
			else if (tabControl1.SelectedTab == kQTKtabPage && kQTKdataGridView.SelectedRows.Count > 0)
			{
				if (MessageBox.Show(this, "Bạn có chắc muốn xóa (những) văn bản được chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					string m = ketQuaLoaiVB == 1 ? "vbden" : "vbdi";
					xoaVB(m, kQTKdataGridView.SelectedRows);
					foreach (DataGridViewRow r in kQTKdataGridView.SelectedRows)
					{
						kQTKdataGridView.Rows.Remove(r);
					}
					if (ketQuaLoaiVB == 1)
					{
						loadTreeView(d0, vbDentreeView);
					}
					else
					{
						loadTreeView(d0, vBDitreeView);
					}
				}
			}
		}

		private int xoaVB(string loaiVB, DataGridViewSelectedRowCollection rows)
		{
			Class.Database db = new Class.Database();
			db.connect();
			foreach (DataGridViewRow r in rows)
			{
				MySqlCommand cmd = new MySqlCommand(string.Format("DELETE FROM {0} WHERE SoHieu='{1}';", loaiVB, r.Cells[0].Value.ToString()), db.getConnection());
				cmd.ExecuteNonQuery();
				Class.QuanLyTep.xoafile(r.Cells["Tep"].Value.ToString());
			}
			db.close();
			return 1;
		}

		private void xemtoolStripButton_Click(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == vBDebtabPage)
			{
				ChiTietVBDen chiTietVBDen = new ChiTietVBDen(vBDendataGridView.SelectedRows[0]);
				chiTietVBDen.ShowDialog(this);
			}
			else if (tabControl1.SelectedTab == vBDitabPage)
			{
				ChiTietVBDi chiTietVBDi = new ChiTietVBDi(vBDidataGridView.SelectedRows[0]);
				chiTietVBDi.ShowDialog(this);
			}
			else if (tabControl1.SelectedTab == kQTKtabPage)
			{
				if (ketQuaLoaiVB == 1)
				{
					ChiTietVBDen chiTietVBDen = new ChiTietVBDen(kQTKdataGridView.SelectedRows[0]);
					chiTietVBDen.ShowDialog(this);
				}
				else
				{
					ChiTietVBDi chiTietVBDen = new ChiTietVBDi(kQTKdataGridView.SelectedRows[0]);
					chiTietVBDen.ShowDialog(this);
				}
			}

		}

		private void timKiemtoolStripButton_Click(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == vBDebtabPage)
			{
				TimKiem timKiem = new TimKiem(1);
				if (timKiem.ShowDialog(this) == DialogResult.OK)
				{
					ketQuaLoaiVB = 1;
					tabControl1.SelectedTab = kQTKtabPage;
					if (((DataTable)kQTKdataGridView.DataSource).Rows.Count == 0)
						MessageBox.Show(this, "Thông tin  văn bản không tồn tại", "Thông báo", MessageBoxButtons.OK);
				}

			}
			else if (tabControl1.SelectedTab == vBDitabPage)
			{
				TimKiem timKiem = new TimKiem(2);
				if (timKiem.ShowDialog(this) == DialogResult.OK)
				{
					ketQuaLoaiVB = 2;
					tabControl1.SelectedTab = kQTKtabPage;
					if (((DataTable)kQTKdataGridView.DataSource).Rows.Count == 0)
						MessageBox.Show(this, "Thông tin  văn bản không tồn tại", "Thông báo", MessageBoxButtons.OK);
				}
			}
		}

		private void mởTệpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == vBDebtabPage && vBDendataGridView.SelectedRows.Count > 0)
			{
				System.Diagnostics.Process.Start(vBDendataGridView.SelectedRows[0].Cells["Tep"].Value.ToString());
			}
			else if (tabControl1.SelectedTab == vBDitabPage && vBDidataGridView.SelectedRows.Count > 0)
			{
				System.Diagnostics.Process.Start(vBDidataGridView.SelectedRows[0].Cells["Tep"].Value.ToString());
			}
			else if (tabControl1.SelectedTab == kQTKtabPage && kQTKdataGridView.SelectedRows.Count > 0)
			{
				System.Diagnostics.Process.Start(kQTKdataGridView.SelectedRows[0].Cells["Tep"].Value.ToString());
			}
		}

		private void vBDendataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				vBDendataGridView.ClearSelection();
				vBDendataGridView.Rows[e.RowIndex].Selected = true;
				mởTệpToolStripMenuItem.Enabled = vBDendataGridView.SelectedRows[0].Cells["Tep"].Value.ToString() != "";
				contextMenuStrip1.Show(Cursor.Position);

			}
		}

		private void vBDidataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				vBDidataGridView.ClearSelection();
				vBDidataGridView.Rows[e.RowIndex].Selected = true;
				mởTệpToolStripMenuItem.Enabled = vBDidataGridView.SelectedRows[0].Cells["Tep"].Value.ToString() != "";
				contextMenuStrip1.Show(Cursor.Position);
				
			}
		}

		private void kQTKdataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				kQTKdataGridView.ClearSelection();
				kQTKdataGridView.Rows[e.RowIndex].Selected = true;
				mởTệpToolStripMenuItem.Enabled = kQTKdataGridView.SelectedRows[0].Cells["Tep"].Value.ToString() != "";
				contextMenuStrip1.Show(Cursor.Position);
			}
		}

		private void kQTKdataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (kQTKdataGridView.SelectedRows.Count > 0)
			{
				xemtoolStripButton_Click(xemtoolStripButton, null);
			}
		}

		private void vBDendataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (vBDendataGridView.SelectedRows.Count > 0)
			{
				xemtoolStripButton_Click(xemtoolStripButton, null);
			}
		}

		private void vBDidataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (kQTKdataGridView.SelectedRows.Count > 0)
			{
				xemtoolStripButton_Click(xemtoolStripButton, null);
			}
		}

	}
}
