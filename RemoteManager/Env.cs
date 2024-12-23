using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteManager
{
	public static class Env
	{
		[DllImport("user32")]
		public static extern void LockWorkStation();
		[DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)] 
		public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
		
		public static Thread th;
		public static Thread preventclose; 
		
		public static List<ComputerBlocker> blockers = new List<ComputerBlocker>() { };
		public static bool is_init = false; 
		public static void init()
		{
			Installer installer = new Installer();
			installer.Install("Manager");
			Type[] types = Assembly.GetExecutingAssembly().GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				Type t = types[i];
				if (t.BaseType == typeof(ComputerBlocker))
				{
					try
					{
						ComputerBlocker blocker = (ComputerBlocker)Activator.CreateInstance(t);
						blockers.Add(blocker);
					}
					catch (Exception ex)
					{
					}


				}
			}
			is_init = true;
			Lock();
		} 
		public static bool IsPreventCloseA()
		{
			Properties.Settings.Default.Reload(); 
			return Properties.Settings.Default.IsCloseProtectA;
		}
		public static bool IsPreventCloseB()
		{
			Properties.Settings.Default.Reload();
			return Properties.Settings.Default.IsCloseProtectB;
		} 
		public static void EnableProtectProcess()
		{
			Properties.Settings.Default.IsCloseProtectA = true;
			Properties.Settings.Default.IsCloseProtectB = true; 
			Properties.Settings.Default.Save();
		}
		public static void DisableProtectProcess()
		{
			Properties.Settings.Default.IsCloseProtectA = false;
			Properties.Settings.Default.IsCloseProtectB = false;
			Properties.Settings.Default.Save();
		}
		public static string MD5Hash(string text)
		{
			MD5 md5H = MD5.Create();
			//convert the input string to a byte array and compute its hash
			byte[] data = md5H.ComputeHash(Encoding.UTF8.GetBytes(text));
			// create a new stringbuilder to collect the bytes and create a string
			StringBuilder sB = new StringBuilder();
			//loop through each byte of hashed data and format each one as a hexadecimal string
			for (int i = 0; i < data.Length; i++)
			{
				sB.Append(data[i].ToString("x2"));
			}
			//return hexadecimal string
			return sB.ToString();
		}
		
		public static void LockComputer() {
			LockWorkStation();
		}
		public static void Hibernate()
		{
			SetSuspendState(true, true, true);
		}
		public static void Sleep()
		{
			SetSuspendState(false, true, true);
		} 
		public static string GetLocalIPAdress()
		{
			string hostName=Dns.GetHostName(); 
			var list = Dns.GetHostEntry(hostName).AddressList;
			foreach (var item in list)
			{
				if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					return item.ToString();
				}
			} 
			return "0.0.0.0";
		}
		public static void Shutdown() {
			ManagementBaseObject mboShutdown = null;
			ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
			mcWin32.Get();

			// You can't shutdown without security privileges
			mcWin32.Scope.Options.EnablePrivileges = true;
			ManagementBaseObject mboShutdownParams =
					 mcWin32.GetMethodParameters("Win32Shutdown");

			// Flag 1 means we want to shut down the system. Use "2" to reboot.
			mboShutdownParams["Flags"] = "1";
			mboShutdownParams["Reserved"] = "0";
			foreach (ManagementObject manObj in mcWin32.GetInstances())
			{
				mboShutdown = manObj.InvokeMethod("Win32Shutdown",
											   mboShutdownParams, null);
			}
		}
		
		public static void Lock()
		{
			if (is_init == false)
			{
				init();
			}
			else
			{
				for (int i = 0; i < blockers.Count; i++)
				{
					blockers[i].StartLocking();
				}
			} 
			
		}
		public static void Unlock()
		{
			for (int i = 0; i < blockers.Count; i++)
			{
				blockers[i].StopLocking();
			}
		}
	}
}
