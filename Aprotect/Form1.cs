using RemoteManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aprotect
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			 inf= new FileInfo(Application.ExecutablePath);
		}
		FileInfo inf;
		private void Form1_Load(object sender, EventArgs e)
		{
			
		}
		void protect()
		{
			if (Env.IsPreventCloseA() == true)
			{
				Process[] prcs = Process.GetProcessesByName("bprotect");
				if (prcs.Length == 0)
				{
					
				}
			}
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel=Env.IsPreventCloseA();
		}
	}
}
