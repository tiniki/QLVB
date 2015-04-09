using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace QuanLyVanBan.Class
{

	class Database
	{
		private string connectString = string.Format("Server={0};Port={1};Database=document;Uid={2};Pwd=toor;", Properties.Settings.Default.Server, Properties.Settings.Default.Port, Properties.Settings.Default.User);
		MySqlConnection cnt;
		public bool connect()
		{
			try
			{
				if (cnt == null)
				{
					cnt = new MySqlConnection(connectString);
					cnt.Open();
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public void close()
		{
			if (cnt!= null) cnt.Close();
		}
		public MySqlConnection getConnection()
		{
			return cnt;
		}

	}
}
