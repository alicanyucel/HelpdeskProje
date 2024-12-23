using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerServer
{
	public partial class DesktopViewer : Form
	{
		public DesktopViewer()
		{
			InitializeComponent(); 
			Control.CheckForIllegalCrossThreadCalls = false;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}
