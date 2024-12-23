using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteManager
{
	public class Installer
	{
		public void Install(string name)
		{
			ProgramStartup startup = new ProgramStartup();
			startup.SetWindowsStartup(name);
		}
	}
}
