using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace QuanLyVanBan.Class
{
	class QuanLyTep
	{
		int t;
		DateTime d;
		FileInfo file;
		string newPathDirec;

		public QuanLyTep(int type, DateTime date, string fileName)
		{
			t = type;
			d = date;
			if (type == 1)
			{
				newPathDirec = string.Format("{0}\\vbden\\{1}\\{2}", Directory.GetCurrentDirectory(), date.Year, date.Month);
			}
			else
			{
				newPathDirec = string.Format("{0}\\vbdi\\{1}\\{2}", Directory.GetCurrentDirectory(), date.Year, date.Month);
			}
			file = new FileInfo(fileName);
		}
		public int themTep()
		{
			Directory.CreateDirectory(newPathDirec);
			var newpath = newPathDirec + "\\" + file.Name;
			bool overwriten = false;
			if (File.Exists(newpath))
			{
				if (MessageBox.Show("Tệp đã tồn tại", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
				{
					overwriten = true;
				}

			}
			File.Copy(file.FullName, newpath, overwriten);
			return 1;
		}
		public string getNewPath()
		{
			return newPathDirec + "\\" + file.Name;
		}
	}
}
