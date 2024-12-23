using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteLanManager
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			form = new Form1();
			
		}
		Form1 form;
		private void MainForm_Load(object sender, EventArgs e)
		{
			

		} 
		
	}
}
