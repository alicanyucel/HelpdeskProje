using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteLanManager
{
	internal static class Program
	{
		/// <summary>
		/// Uygulamanın ana girdi noktası.
		/// </summary>
		[STAThread]
		static void Main()
		{
			using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
			{
				if (!mutex.WaitOne(0, false))
				{
					
					return;
				}

				
				
				Application.SetCompatibleTextRenderingDefault(false);
				Application.EnableVisualStyles();
				Application.Run(new Form1());
			}
			


				
				
			}
		private static string appGuid = "c0a76b5a-12ab-45c5-b9d9-d693faa6e7b9";
	}
	
}

