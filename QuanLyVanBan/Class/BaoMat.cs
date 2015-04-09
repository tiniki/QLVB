using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyVanBan.Class
{
	class BaoMat
	{
		private string ptext;
		private System.Security.Cryptography.SHA512 shaM;
		private string ctext;
		public BaoMat(string plaintext)
		{
			ptext = plaintext;
			shaM = new System.Security.Cryptography.SHA512Managed();
			byte[] input = Encoding.UTF8.GetBytes(ptext);
			byte[] result = shaM.ComputeHash(input);
			ctext = System.Convert.ToBase64String(result);
		}
		public bool dungMK()
		{			
			return ctext.Equals(Properties.Settings.Default.Password);
		}
		public void luuMK()
		{
			Properties.Settings.Default["Password"] = ctext;
			Properties.Settings.Default.Save();
		}

	}
}
