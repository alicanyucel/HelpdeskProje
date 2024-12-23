using RemoteManager;
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
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			 
			Properties.Settings.Default.Port = (int)numericUpDown1.Value;
			Properties.Settings.Default.Save();
			Application.Restart();
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			Properties.Settings.Default.Reload(); 
			numericUpDown1.Value= Properties.Settings.Default.Port;
			IpadressLabel.Text=Env.GetLocalIPAdress();

			// Get the IP from GetHostByName method of dns class. 
		
		}
	}
}
