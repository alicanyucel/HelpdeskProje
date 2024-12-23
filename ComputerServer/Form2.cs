using RemoteManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerServer
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		[DllImport("user32.dll", EntryPoint = "BlockInput")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);
		public enum MonitorState
		{
			MonitorStateOn = -1,
			MonitorStateOff = 2,
			MonitorStateStandBy = 1
		}
		[DllImport("user32.dll")]
		private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
		private void button1_Click(object sender, EventArgs e)
		{
			Env.Lock(); 

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Env.Unlock();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Env.Shutdown();
		}
		private void SetMonitorInState(MonitorState state)
		{
			//SendMessage(0xFFFF, 0x112, 0xF170, (int)state);
		}
		private void Form2_Load(object sender, EventArgs e)
		{
			timer1.Start();
			BlockInput(true);
			Cursor.Hide(); 
			
		} 
		public void FreeUser()
		{
			Cursor.Show();
			BlockInput(false);
			if (ClientEnv.LockComputer() == false)
			{
				//SetMonitorInState(MonitorState.MonitorStateOn);
			}
		}
		public void BlockUser()
		{
			Cursor.Hide();
			BlockInput(true);
			
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (ClientEnv.IsLockingComputer)
			{
				this.TopMost = true;
				
			} 
			

		}
		bool isprevent = true;
		private void button1_Click_1(object sender, EventArgs e)
		{
			isprevent = false;
			this.Close();
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = ClientEnv.LockComputer();
		}

		private void client1_OnPacketRecevied(Packet packet)
		{
			
		}
		void check()
		{
			if (Visible == true)
			{
				SetMonitorInState(MonitorState.MonitorStateOff);
			}
			else
			{
				SetMonitorInState(MonitorState.MonitorStateOn);
			}
		}
		private void Form2_VisibleChanged(object sender, EventArgs e)
		{
			check();
		}

		private void Form2_MouseMove(object sender, MouseEventArgs e)
		{
			
		}

		private void timer1_Tick_1(object sender, EventArgs e)
		{
			if (Visible == true) {

				BlockInput(true);
				Cursor.Hide();
				try
				{
					Graphics g = Graphics.FromHwnd(IntPtr.Zero);
					g.Clear(Color.Black);
				}
				catch
				{

				}
			}
			
		}
	}
}
