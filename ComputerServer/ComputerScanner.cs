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
	public partial class ComputerScanner : Form
	{
		public ComputerScanner()
		{
			InitializeComponent();
			
		}
		string ip = "192.168.1.";
		string new_ip = "";
		bool is_find = false;
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			
			for(int i = 0; i < 256 && is_find==false; i++)
			{
				new_ip = ip + i.ToString();
				client1.Connect(new_ip, 3235);
				int progress = (i / 255)*100;
				backgroundWorker1.ReportProgress(progress);
				
			}
		}

		private void client1_OnConnected()
		{
			client1.Send(new Packet(2550, new List<object>()));
		}

		private void client1_OnPacketRecevied(Packet packet)
		{
			if (packet.Commandtype == 2550)
			{
				is_find = true;
				string ip_adress = new_ip;
				string comp_name=(string)packet.Data[0];
				string user_name = (string)packet.Data[1]; 
				ListViewItem item=new ListViewItem(ip_adress);
				item.SubItems.Add(comp_name); 
				item.SubItems.Add(user_name); 
				listView1.Items.Add(item);
			}
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		private void ComputerScanner_Load(object sender, EventArgs e)
		{
			server1.Start();
			backgroundWorker1.RunWorkerAsync();
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			button1.Enabled = listView1.SelectedItems.Count==1;

		}

		private void button1_Click(object sender, EventArgs e)
		{
			ComputerServer.Properties.Settings.Default.IpAdress = listView1.SelectedItems[0].Text;
			ComputerServer.Properties.Settings.Default.Save();
			MessageBox.Show("Sunucu Kaydedildi" + Environment.NewLine + " Bu bilgisayar açıldığında otomaik olarak bağlanacaktır", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Close();
		}

		private void server1_OnPacketRecevied(string ip, Packet packet)
		{
			if (packet.Commandtype == 2550)
			{
				server1.SendData(ip, new Packet(2550, new List<object>() { }));
			}
		}
	}
}
