namespace ComputerServer
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.client1 = new RemoteManager.Client();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.locker = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.settingsbutton = new System.Windows.Forms.ToolStripMenuItem();
			this.rehreshkey = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// client1
			// 
			this.client1.BufferSize = 4096;
			this.client1.Port = 0;
			this.client1.OnPacketRecevied += new RemoteManager.Client.PackRecevied(this.client1_OnPacketRecevied);
			this.client1.OnDisconnected += new RemoteManager.Client.Disconnected(this.client1_OnDisconnected);
			this.client1.OnConnected += new RemoteManager.Client.Connected(this.client1_OnConnected);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// locker
			// 
			this.locker.Enabled = true;
			this.locker.Interval = 1;
			this.locker.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "Manager Client";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsbutton});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(153, 28);
			this.contextMenuStrip1.Text = "Ağ ayarları";
			this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
			// 
			// settingsbutton
			// 
			this.settingsbutton.Name = "settingsbutton";
			this.settingsbutton.Size = new System.Drawing.Size(152, 24);
			this.settingsbutton.Text = "Ağ Ayarları";
			this.settingsbutton.Click += new System.EventHandler(this.settingsbutton_Click);
			// 
			// rehreshkey
			// 
			this.rehreshkey.Enabled = true;
			this.rehreshkey.Interval = 1;
			this.rehreshkey.Tick += new System.EventHandler(this.rehreshkey_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(263, 199);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Opacity = 0D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "MainForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private RemoteManager.Client client1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer locker;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		public System.Windows.Forms.ToolStripMenuItem settingsbutton;
		private System.Windows.Forms.Timer rehreshkey;
	}
}