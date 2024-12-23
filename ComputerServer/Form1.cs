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

namespace ComputerServer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent(); 
			Control.CheckForIllegalCrossThreadCalls = false;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			client1.Connect("192.168.1.102", 5876);
		}

		private void client1_OnConnected()
		{
			timer1.Start();
		}
		byte[] capture()
		{
			try
			{
				Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
				using (Graphics g = Graphics.FromImage(bmp))
				{

					g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);

				}
				using (MemoryStream mem = new MemoryStream()) {
					bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Png);
					return mem.ToArray();
				}
			} 
			catch {
				return null;
			}
			
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			client1.Send(new RemoteManager.Packet(12, new List<object>() { capture() }));
		}

		private void client1_OnPacketRecevied(RemoteManager.Packet packet)
		{
			if (packet.Commandtype == 31)
			{
				Process.Start("chrome.exe");
			}
		}
	}
}
