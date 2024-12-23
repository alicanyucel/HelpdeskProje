using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerServer
{
	internal static class Program
	{
		/// <summary>
		/// Uygulamanın ana girdi noktası.
		/// </summary>
		[STAThread]
		static void Main()
		{
			
			
			string name=Process.GetCurrentProcess().ProcessName; 
			Process[] prcs=Process.GetProcessesByName(name);
			if(prcs.Length!=1 && prcs.Length>0)
			{
				Application.ExitThread();
			}
			else
			{
				Application.SetCompatibleTextRenderingDefault(false);
				Application.EnableVisualStyles();
				Application.Run(new MainForm());
			}
			
		}
	}
}
