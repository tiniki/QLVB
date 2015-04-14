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
		DataSet dataSetVBDen, dataSetVBDi, dataSetKQ;
		public DateTime vbdenDate, vbdiDate;
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
				VBDen vbden = new VBDen(false, "");
				dalRs = vbden.ShowDialog(this);
				if (dalRs == DialogResult.OK)
					loadTreeView(vbdenDate, vbDentreeView);
			}
			else if (tabControl1.SelectedTab == vBDitabPage)
			{
				VBDi vbdi = new VBDi(false, "");
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
				VBDen vbden = new VBDen(true, vBDendataGridView.SelectedRows[0].Cells["SoHieu"].Value.ToString());
				dalRs = vbden.ShowDialog(this);
				if (dalRs == DialogResult.OK)
					loadTreeView(vbdenDate, vbDentreeView);
			}
			else if (tabControl1.SelectedTab == vBDitabPage)
			{
				VBDi vbdi = new VBDi(true, vBDidataGridView.SelectedRows[0].Cells["SoHieu"].Value.ToString());
				dalRs = vbdi.ShowDialog(this);
				if (dalRs == DialogResult.OK)
					loadTreeView(vbdiDate, vBDitreeView);
			}
		}
	}
}
