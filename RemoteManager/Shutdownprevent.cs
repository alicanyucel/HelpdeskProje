using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteManager
{
	using Microsoft.Win32;
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;

	namespace ComputerManager
	{
		public class ShutDownPrevent : ComputerBlocker
		{
			public ShutDownPrevent()
			{
			}
			[DllImport("advapi32.dll", SetLastError = true)]
			static extern bool AbortSystemShutdown(string lpMachineName);
			void lock_shutdown_command()
			{
				try
				{
					AbortSystemShutdown("localhost");
				}
				catch
				{

				}
				try
				{
					AbortSystemShutdown(null);
				}
				catch { }
				try
				{
					AbortSystemShutdown("127.0.0.1");
				}
				catch { }


			}
			void disable_shutdown()
			{
				try
				{
					disable_shutdown_current_machine();
				}
				catch (Exception ex)
				{
				}
				try
				{
					disable_shutdown_current_user();
				}
				catch (Exception ex)
				{
				}
			}
			void disable_shutdown_current_user()
			{
				RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);
				if (rkApp != null)
				{

				}
				else
				{
					rkApp = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");

				}
				rkApp.SetValue("NoClose", 1);
			}
			void disable_shutdown_current_machine()
			{

				RegistryKey rkApp = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);
				if (rkApp != null)
				{

				}
				else
				{
					rkApp = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);

				}
				rkApp.SetValue("NoClose", 1);

			}
			void disable_shutdown_prevent()
			{
				try
				{
					string keypath = "Software\\Policies\\Microsoft\\Windows\\System";
					RegistryKey key = Registry.LocalMachine.OpenSubKey(keypath);
					key.SetValue("AllowBlockingAppsAtShutdown", 1);
				}
				catch (Exception ex) { }

			}
			void enable_shutdown_prevent()
			{
				try
				{
					string keypath = "Software\\Policies\\Microsoft\\Windows\\System";
					RegistryKey key = Registry.LocalMachine.OpenSubKey(keypath);
					key.SetValue("AllowBlockingAppsAtShutdown", 0);
					key.DeleteValue("AllowBlockingAppsAtShutdown");
				}
				catch (Exception ex) { }

			}
			void enable_shutdown_current_user()
			{
				RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);
				if (rkApp != null)
				{

				}
				else
				{
					rkApp = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");

				}
				rkApp.SetValue("NoClose", 0);
			}
			void enable_shutdown_current_machine()
			{

				RegistryKey rkApp = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);
				if (rkApp != null)
				{

				}
				else
				{
					rkApp = Registry.LocalMachine.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);

				}

				rkApp.SetValue("NoClose", 0);
				rkApp.DeleteValue("NoClose");
			}
			internal override void Lock()
			{
				lock_shutdown_command();
				disable_shutdown_prevent();
				disable_shutdown();


			}

			internal override void Unlock()
			{
				enable_shutdown_current_machine();
				enable_shutdown_current_user();
				enable_shutdown_prevent();
			}
		}
	}

}
