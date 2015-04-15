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
		//thong tin file nguon
		FileInfo file;
		string newPathDirec,newPathFile;
		bool noFile,overwriten;

		public QuanLyTep(int type, DateTime date, string fileName,string soHieu)
		{
			if (fileName != "")
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
				noFile = false;
				newPathFile = newPathDirec + "\\" + soHieu + file.Extension;
				overwriten = true;
			}
			else noFile = true;
			
			
		}
		public int themTep()
		{
			if (noFile) return 0;//vb ko co tep kem theo		
			if (overwriten)
				if (file.FullName.Contains(Directory.GetCurrentDirectory()))
					File.Move(file.FullName, newPathFile);
				else File.Copy(file.FullName, newPathFile, overwriten);
			return 1;//thanh cong
		}
		public int kiemtra()
		{
			if (noFile) return 0;
			try
			{
				Directory.CreateDirectory(newPathDirec);
			}
			catch (IOException)
			{
				return 2;//loi tao thu muc
			}
			if (!File.Exists(file.FullName))
			{
				return 3;//file nguon ko ton tai
			}
			FileStream stream = null;
			try
			{
				stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
			}
			catch (IOException)
			{
				return 4;//khong the truy xuat file nguon
			}
			if (stream != null)
			{
				stream.Close();
			}
			if (File.Exists(newPathFile))
			{
				return 10;//file dich da ton tai
			}
			return 1;
		}
		public void setOverwriten(bool yes)
		{
			overwriten = yes;
		}
		public string getNewPath()
		{
			if (noFile) return "";
			return newPathFile;
		}
		public static int xoafile(string filePath)
		{
			try 
			{ 
				File.Delete(filePath); 
				return 1; 
			}
			catch
			{
				return -1;
			}
		}
	}
}
