using RemoteManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteLanManager
{
	public partial class KeyInstallerForm : Form
	{
		public KeyInstallerForm()
		{
			InitializeComponent(); 
			random=new Random();
		}
		Random random;
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			button1.Enabled = listBox1.SelectedItems.Count > 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.RecoveryKeyID=Guid.Parse(KeyID.Text);
			Properties.Settings.Default.RecoveryKeyNumber = Convert.ToInt32(KeyNumberx.Text.Trim());
			Properties.Settings.Default.IsInstalled = true; 
			Properties.Settings.Default.Save();
			Properties.Settings.Default.Reload();
			for (int i = 0; i < listBox1.SelectedItems.Count; i++)
			{
				KeyMaker maker = new KeyMaker(listBox1.SelectedItems[i] + "passwordkey.data",Guid.Parse(KeyID.Text.Trim()),Convert.ToInt32(KeyNumberx.Text.Trim()));
				maker.Save();
			}
			KeyChecker keyChecker = new KeyChecker(Properties.Settings.Default.RecoveryKeyID.ToString(), Properties.Settings.Default.RecoveryKeyNumber);
			bool is_find=keyChecker.IsKeyFind;
			if (is_find == true)
			{
				MessageBox.Show("Anahtar Kurulum işlemi tamamdır","Bilgilendirme");
				this.Close();
			} 
			DialogResult= DialogResult.OK;
			Close();
		}
		void refresh()
		{
			if (listBox1.Items.Count > 0)
			{
				listBox1.Items.Clear();
			}
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo drive in drives)
			{
				if (drive.DriveType == DriveType.Removable)
				{
					listBox1.Items.Add(drive.RootDirectory);
				}

			}
		}
		private void button2_Click(object sender, EventArgs e)
		{
			refresh();
		}

		private void KeyInstallerForm_Load(object sender, EventArgs e)
		{
			refresh();
			StandartkeyOption.Checked = true;
			KeyID.Text = Guid.Empty.ToString();
			KeyNumberx.Text = 4567.ToString().Trim();
		}

		private void StandartkeyOption_CheckedChanged(object sender, EventArgs e)
		{
			KeyID.Text = Guid.Empty.ToString();
			KeyNumberx.Text = 4567.ToString().Trim();
		}

		private void RandomKeyOption_CheckedChanged(object sender, EventArgs e)
		{

			KeyID.Text = Guid.NewGuid().ToString();
			KeyNumberx.Text = random.Next(1,int.MaxValue).ToString().Trim();
		}

		private void KeyInstallerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
		
		}
	}
}
