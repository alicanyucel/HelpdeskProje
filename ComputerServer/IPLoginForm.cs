using RemoteManager;
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
	public partial class IPLoginForm : Form
	{
		public IPLoginForm()
		{
			InitializeComponent(); 
			

		}

		private void IPAdress_TextChanged(object sender, EventArgs e)
		{
			ConnectButton.Enabled = IPAdress.Text.Length>0;
		}

		private void ConnectButton_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.IpAdress=IPAdress.Text; 
			Properties.Settings.Default.NickName=textBox1.Text;
			Properties.Settings.Default.Port=(int)PortNumber.Value; 
			Properties.Settings.Default.IsInstall=true;
			Properties.Settings.Default.Save(); 
			DialogResult=DialogResult.OK;
			Close();
		}

		private void IPLoginForm_Load(object sender, EventArgs e)
		{
			Cursor.Show(); 
			Properties.Settings.Default.Reload();
			textBox1.Text = Properties.Settings.Default.NickName;
			IPAdress.Text = Properties.Settings.Default.IpAdress;
			PortNumber.Value = Properties.Settings.Default.Port;
			button1.Enabled = ClientEnv.checker.IsKeyFind;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			ProgramStartup startup = new ProgramStartup(); 
			
			startup.DeleteWindowsStartup("Manager");
			Application.Exit();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{

		}
	}
}
