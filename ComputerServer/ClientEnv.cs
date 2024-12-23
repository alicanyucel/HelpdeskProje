using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteManager;
namespace ComputerServer
{
	public static class ClientEnv
	{
		public static bool IsLockingComputer=false;
		public static Form locking_form;
		public static KeyChecker checker = new KeyChecker();
		public static void CloseAllRunningPrograms()
		{
			Process[] prcs = Process.GetProcesses();
			int id = Process.GetCurrentProcess().Id;
			for (int i = 0; i < prcs.Length; i++)
			{
				try
				{
					Process p = prcs[i];
					if (p.MainWindowHandle != IntPtr.Zero)
					{
						if(p.Id != id)
						{
							p.Kill();
						} 
						
					}
				}
				catch (Exception e) {  
				}
				
			}
		}
		public static bool LockComputer() 
		{
			return IsLockingComputer == true && checker.IsKeyFind==false;
		}
	}
}
