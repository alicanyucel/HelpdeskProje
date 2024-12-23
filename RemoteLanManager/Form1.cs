using RemoteManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteLanManager
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			Properties.Settings.Default.Reload();
			Control.CheckForIllegalCrossThreadCalls = false;

		}
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool LockWorkStation();
		public void HideForm()
		{
			Opacity = 0;
			ShowInTaskbar = false;

			Hide();
		}
		public void ShowForm()
		{
			Opacity = 100;
			ShowInTaskbar = true;

			Show();
		}
		Client client = new Client();
		private void Form1_Load(object  sender, EventArgs e)
		{

			LockWorkStation(); 
			if (Properties.Settings.Default.IsInstalled == false)
			{
				KeyInstallerForm form = new KeyInstallerForm(); 
				DialogResult res=form.ShowDialog();
				if (res != DialogResult.OK)
				{
					Application.Exit();
					Close();
				}
			}
			server1.Port = 5876;
			server1.Start(); 
			
			
			
			string str=RemoteManager.Env.MD5Hash("2357");
			//timer1.Start();
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			e.Cancel = !(listView1.SelectedItems.Count>0);
		}
		
		byte[] capture()
		{
			
			Bitmap memoryImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
			{
				Size s = new Size(memoryImage.Width, memoryImage.Height);

				Graphics memoryGraphics = Graphics.FromImage(memoryImage);
				try
				{
					memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);
				}
				catch
				{
					memoryGraphics.FillRectangle(new SolidBrush(Color.Black), Screen.PrimaryScreen.Bounds);
				}
				MemoryStream mem = new MemoryStream(); 
				memoryImage.Save(mem,ImageFormat.Png);
				return mem.ToArray();
			}
		}

		private void server1_OnPacketRecevied(string ip, RemoteManager.Packet packet)
		{
			CommandTypes types = (CommandTypes)packet.Commandtype;
			if (packet.Commandtype == 12)
			{
				
			}
			if (packet.Commandtype == 2550)
			{
				packet.Data.Add(Properties.Settings.Default.RecoveryKeyID.ToString());
				packet.Data.Add(Properties.Settings.Default.RecoveryKeyNumber);
				server1.SendData(ip, packet); 
				
			} 
			if (packet.Commandtype == 2023)
			{
				var item=new ListViewItem((string)packet.Data[0]);
				item.Tag = ip; 
				item.SubItems.Add(ip); 
				item.SubItems.Add((string)packet.Data[1]); 
				item.SubItems.Add(((string)packet.Data[2]));
				bool locked = (bool)packet.Data[3];
				bool iskey=(bool)packet.Data[4];
				string is_key_desc = "";
				string locked_desc = "";
				if (locked == true)
				{
					locked_desc = "Kilitli";
				}
				else
				{
					locked_desc = "Serbest";
				}
				if (iskey == true)
				{
					is_key_desc = "Takılı";
				}
				else
				{
					is_key_desc = "Yok";
				}
				item.SubItems.Add(locked_desc);
				item.SubItems.Add(is_key_desc);
				listView1.Items.Add(item);
			}
			if (types == CommandTypes.GetInfo)
			{
				for (int i = 0; i < listView1.Items.Count; i++) {
					if (listView1.Items[i].Tag.ToString() == ip) {
						var item=listView1.Items[i];
						bool locked = (bool)packet.Data[0];
						bool iskey = (bool)packet.Data[1];
						string is_key_desc = "";
						string locked_desc = "";
						if (locked == true)
						{
							locked_desc = "Kilitli";
						}
						else
						{
							locked_desc = "Serbest";
						}
						if (iskey == true)
						{
							is_key_desc = "Takılı";
						}
						else
						{
							is_key_desc = "Yok";
						}
						item.SubItems[4].Text = locked_desc;
						item.SubItems[5].Text = is_key_desc;

					}
				}
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			SettingsForm settingsForm = new SettingsForm();
			settingsForm.ShowDialog();
		}

		private void kurtarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			 
			KeyInstallerForm keyInstallerForm = new KeyInstallerForm(); 
			keyInstallerForm.ShowDialog();
			server1.SendAllClients(new Packet((int)CommandTypes.SaveRecoveryKey, new List<object>() {Properties.Settings.Default.RecoveryKeyID.ToString(),Properties.Settings.Default.RecoveryKeyNumber }));

		}
		public void SendData(Packet pack)
		{
			for(int i = 0; i < listView1.SelectedItems.Count; i++)
			{
				server1.SendData((string)listView1.SelectedItems[i].Tag, pack);
			}
		}
		private void kilitleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendData(new Packet((int)CommandTypes.LockComputer,new List<object>()));
		}

		

		private void yenidenBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
		}

		private void kapatToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			SendData(new Packet((int)CommandTypes.Shutdown, new List<object>()));
		}

		private void yenidenBaşlatToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			SendData(new Packet((int)CommandTypes.Restart, new List<object>()));
		}

		private void uykuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendData(new Packet((int)CommandTypes.Sleep, new List<object>()));
		}

		private void kapatToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			server1.SendAllClients(new Packet((int)CommandTypes.Shutdown, new List<object>()));
			
		}

		private void kilitleToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			server1.SendAllClients(new Packet((int)CommandTypes.LockComputer, new List<object>()));
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Process.GetCurrentProcess().Kill();
			
		}

		private void yenidenBaşlatToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			server1.SendAllClients(new Packet((int)CommandTypes.Restart, new List<object>()));
		}

		private void uykuToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			server1.SendAllClients(new Packet((int)CommandTypes.Sleep, new List<object>()));
		}

		private void server1_OnDisconnected(string ip)
		{
			for(int i = 0; i < listView1.Items.Count; i++)
			{
				if ((string)listView1.Items[i].Tag == ip)
				{
					listView1.Items[i].Remove();
				}
			}
		}

		private void standartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			
			
		}

		private void rastgeleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			
		}

		private void standartToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			Properties.Settings.Default.Reload(); 
			KeyChecker checker= new KeyChecker(Properties.Settings.Default.RecoveryKeyID.ToString(),Properties.Settings.Default.RecoveryKeyNumber);
			if (checker.IsKeyFind == true)
			{
				Properties.Settings.Default.RecoveryKeyID = Guid.Empty;
				Properties.Settings.Default.RecoveryKeyNumber = 4567;
				KeyMaker maker = new KeyMaker(checker.selectedDrive.RootDirectory + "passwordkey.data", Properties.Settings.Default.RecoveryKeyID, Properties.Settings.Default.RecoveryKeyNumber);
				maker.Save(); 
				Properties.Settings.Default.Save();
				server1.SendAllClients(new Packet((int)CommandTypes.SaveRecoveryKey, new List<object>() { Properties.Settings.Default.RecoveryKeyID.ToString(), Properties.Settings.Default.RecoveryKeyNumber }));
			}
			else
			{
				MessageBox.Show("Tüm bilgisayarlarda anahtarın güncellenebilmesi için bilgisayarınızda güncel anahtar bellek takılı durumda olmalıdır","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		private void rastgeleToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			Properties.Settings.Default.Reload();
			KeyChecker checker = new KeyChecker(Properties.Settings.Default.RecoveryKeyID.ToString(), Properties.Settings.Default.RecoveryKeyNumber);
			if (checker.IsKeyFind == true)
			{
				Properties.Settings.Default.RecoveryKeyID = Guid.NewGuid();
				Properties.Settings.Default.RecoveryKeyNumber = new Random().Next(1,int.MaxValue);
				KeyMaker maker = new KeyMaker(checker.selectedDrive.RootDirectory + "passwordkey.data", Properties.Settings.Default.RecoveryKeyID, Properties.Settings.Default.RecoveryKeyNumber);
				maker.Save();
				Properties.Settings.Default.Save();
				server1.SendAllClients(new Packet((int)CommandTypes.SaveRecoveryKey, new List<object>() { Properties.Settings.Default.RecoveryKeyID.ToString(), Properties.Settings.Default.RecoveryKeyNumber }));
			}
			else
			{
				MessageBox.Show("Tüm bilgisayarlarda anahtarın güncellenebilmesi için bilgisayarınızda güncel anahtar bellek takılı durumda olmalıdır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < server1.sockets.Count; i++) {
				bool find = false;
				string ipadr = "";
				int index = 0;
				for (index=0; index < listView1.Items.Count; index++)  
				{
					//bool isfind=(string)listView1.Items[index].Tag == server1.sockets.ElementAt(i).Value.RemoteEndPoint.ToString();
					bool isfind = false;
					if (isfind == true)
					{
						ipadr = (string)listView1.Items[index].Tag; 
						find = true;
						break;
					}
					

				}
				if (find == false)
				{
					//server1.SendData(server1.sockets.ElementAt(i).Value.RemoteEndPoint.ToString(), new Packet(2550, new List<object>() { Properties.Settings.Default.RecoveryKeyID.ToString(),Properties.Settings.Default.RecoveryKeyNumber}));
				}

			}
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			
		}
	
		private void refheshDesktop_Tick(object sender, EventArgs e)
		{
			
			
			server1.SendAllClients(new Packet((int)CommandTypes.DesktopImage, new List<object>() { capture() }));
		}

		private void desktopViewerBtn_Click(object sender, EventArgs e)
		{
			if (refheshDesktop.Enabled == false)
			{
				server1.SendAllClients(new Packet((int)CommandTypes.StartDesktopViewer, new List<object>() { capture() }));
				refheshDesktop.Enabled = true; 
				
			}
			else
			{
				refheshDesktop.Enabled = false;
				server1.SendAllClients(new Packet((int)CommandTypes.StopDesktopViewer, new List<object>()));
			}
			
			desktopViewerBtn.Checked = refheshDesktop.Enabled;
		}
	}
}
