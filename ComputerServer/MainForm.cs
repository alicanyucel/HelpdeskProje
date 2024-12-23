using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteManager;
using RemoteManager.Serializer;
namespace ComputerServer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
		} 
		ProgramStartup startup = new ProgramStartup(); 
		public bool IsLockForm=false;
		[DllImport("user32.dll")]
		static extern bool BlockInput(bool fBlockIt);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetForegroundWindow(IntPtr hWnd);
		[DllImport("User32.Dll")]
		public static extern long SetCursorPos(int x, int y);
		public  string MD5(string s)
		{
			var provider = System.Security.Cryptography.MD5.Create();
			StringBuilder builder = new StringBuilder();

			foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
			{
				builder.Append(b.ToString("x2").ToLower());
			}
				

			return builder.ToString();
		}
		IPLoginForm loginForm = new IPLoginForm(); 
		Form2 lockform=new Form2(); 
		DesktopViewer deskviewer = new DesktopViewer();
		void iplogin_button_click(object sender, EventArgs e)
		{
			client1.Connect(loginForm.IPAdress.Text, (int)loginForm.PortNumber.Value); 

		}
		private void MainForm_Load(object sender, EventArgs e)
		{
			
			
			
			
			
			var xc=Properties.Settings.Default.RecoveryKeyID; 
			var dc=Properties.Settings.Default.RecoveryKeyNumber;
			if (Properties.Settings.Default.IsInstall==false)
			{
				
				loginForm.ConnectButton.Click += iplogin_button_click; 
				loginForm.Show();


			}
			else
			{
				//ClientEnv.IsLockingComputer = true;
			}
		}
		bool connected=false; 
		bool keyfind=false;
		private void client1_OnConnected()
		{
			client1.Send(new RemoteManager.Packet(2550,new List<object>()));
			connected = true;
		}

		private void client1_OnPacketRecevied(RemoteManager.Packet packet)
		{
			if (packet.Commandtype == 2550)
			{
				Properties.Settings.Default.RecoveryKeyID =Guid.Parse((string)packet.Data[0]);
				Properties.Settings.Default.RecoveryKeyNumber = (int)packet.Data[1];
				Properties.Settings.Default.Save();
				packet.Data.Clear();
				packet.Commandtype = 2023;
				packet.Data = new List<object> { Properties.Settings.Default.NickName, Environment.UserName, Environment.MachineName, ClientEnv.IsLockingComputer, true };
				client1.Send(packet); 
				//ClientEnv.IsLockingComputer = true;
			}
			CommandTypes types =(CommandTypes)packet.Commandtype;
			switch (types)
			{
				case CommandTypes.LockComputer:
					ClientEnv.locking_form = lockform; 
					ClientEnv.IsLockingComputer = !ClientEnv.IsLockingComputer;
					break;
				case CommandTypes.SaveRecoveryKey:
					Properties.Settings.Default.RecoveryKeyID = Guid.Parse((string)packet.Data[0]); 
					Properties.Settings.Default.RecoveryKeyNumber =(int)packet.Data[1];
					 
					Properties.Settings.Default.Save();
					ClientEnv.checker = new KeyChecker((string)packet.Data[0], (int)packet.Data[1]);
					break;
				case CommandTypes.Sleep:
					Env.Sleep();
					break;
				case CommandTypes.Shutdown:
					ClientEnv.CloseAllRunningPrograms();
					Env.Shutdown();
					
					break;
				case CommandTypes.ChangeNickName:
					Properties.Settings.Default.NickName = (string)packet.Data[0];
					Properties.Settings.Default.Save();
					break;
				case CommandTypes.Restart:
					ClientEnv.CloseAllRunningPrograms();
					Process.Start("shutdown","/r /t 0");

					break;
				case CommandTypes.DesktopImage:
					lock (deskviewer)
					{
						byte[] bytes= (byte[])packet.Data[0]; 
						using(MemoryStream mem=new MemoryStream(bytes))
						{
							Bitmap bmp= new Bitmap(mem);
							deskviewer.pictureBox1.Image = bmp;
						}
						
					}
					break;
				case CommandTypes.StartDesktopViewer:
					ClientEnv.locking_form = deskviewer; 
					ClientEnv.IsLockingComputer = true;

					lock (deskviewer)
					{
						byte[] bytes = (byte[])packet.Data[0];
						using (MemoryStream mem = new MemoryStream(bytes))
						{
							Bitmap bmp = new Bitmap(mem);
							deskviewer.pictureBox1.Image = bmp;
						}

					}
					
					


					break;
				case CommandTypes.StopDesktopViewer:
					deskviewer.Hide();
					ClientEnv.IsLockingComputer = false;
					ClientEnv.locking_form = lockform;
					

					break;

			}







		}
		
		private void timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				if (client1.ClientConnected== false)
				{
					if (Properties.Settings.Default.IsInstall == true)
					{
						client1.Connect(Properties.Settings.Default.IpAdress, Properties.Settings.Default.Port);
					}

				}
				else
				{
					if (Properties.Settings.Default.IsInstall == true)
					{
						client1.Send(new Packet((int)CommandTypes.GetInfo, new List<object>() { ClientEnv.LockComputer(), ClientEnv.checker.IsKeyFind }));
					}

				}
			}
			catch (Exception ex) { }
			
		}

		private void client1_OnDisconnected()
		{
			connected = false; 
			
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			try
			{
				
				if (ClientEnv.locking_form == null)
				{
					ClientEnv.locking_form = new Form2();

				}
				keyfind = ClientEnv.checker.IsKeyFind;
				bool islock = ClientEnv.LockComputer();
				notifyIcon1.Visible = keyfind;
				BlockInput(islock);
				if (islock == true)
				{
					Debug.WriteLine("Trying adding startup"); 
					startup.SetWindowsStartup("Manager");
					
				}
				else
				{
					startup.DeleteWindowsStartup("Manager");
				} 
				
				if (islock == true)
				{
					if (ClientEnv.locking_form.Visible == false)
					{
						ClientEnv.locking_form.Show();
					}
					ClientEnv.locking_form.Visible = islock;
					ClientEnv.locking_form.TopMost = islock; 
					
					SetForegroundWindow(ClientEnv.locking_form.Handle);
					SetCursorPos(0, 0);

				}
				else
				{
					if (ClientEnv.locking_form.Visible == true)
					{
						ClientEnv.locking_form.Hide();
						
					}
				}
				
			} 
			catch { }

			
			
		}

		private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void deletebutton_Click(object sender, EventArgs e)
		{

		}

		private void settingsbutton_Click(object sender, EventArgs e)
		{
			IPLoginForm loginform = new IPLoginForm(); 
			loginform.ShowDialog();
			
		}

		private void rehreshkey_Tick(object sender, EventArgs e)
		{
			
			
		}

		private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
		{
			loginForm = new IPLoginForm();
			loginForm.Show();
		}
	}
}
