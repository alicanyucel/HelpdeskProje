using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteLanManager
{
	public static class ProgEnv
	{
		public static Form1 form=null;
		public static List<Form> InstallForms = new List<Form>() { new KeyInstallerForm() };
		
	}
}
