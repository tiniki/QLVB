using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyVanBan
{
	
	static class Program
	{
		public static bool OpenMain { get; set; }
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			OpenMain = false;	
			Application.Run(new XacThuc());
			if (OpenMain)
			{
				Application.Run(new ManHinhChinh());
			}
		}
	}
}
