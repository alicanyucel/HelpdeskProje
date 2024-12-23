using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteManager
{
	public class ProgramStartup
	{
		
		public void SetWindowsStartup(string name)
		{
			var rWrite = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
			try
			{
				rWrite.SetValue(name,
								  Application.ExecutablePath);
				Debug.WriteLine("Startup Added :" + name);
			} 
			catch { }
		}
		public void DeleteWindowsStartup(string name)
		{
			 
			var rWrite = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
			try{
				rWrite.DeleteValue(name);
			}catch { }
			
		}
	}
}
