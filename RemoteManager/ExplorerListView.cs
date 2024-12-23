using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteManager
{
	public class ExplorerListView:ListView
	{
		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
		public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList); 
		public ExplorerListView()
		{
			SetWindowTheme(this.Handle, "explorer", null);
		}
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);

			if (!this.DesignMode && Environment.OSVersion.Platform ==
			  PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
			{
				SetWindowTheme(this.Handle, "explorer", null);
			}
				
		}
	}
}
