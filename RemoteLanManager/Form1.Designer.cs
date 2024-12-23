namespace RemoteLanManager
{
	partial class Form1
	{
		/// <summary>
		///Gerekli tasarımcı değişkeni.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///Kullanılan tüm kaynakları temizleyin.
		/// </summary>
		///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer üretilen kod

		/// <summary>
		/// Tasarımcı desteği için gerekli metot - bu metodun 
		///içeriğini kod düzenleyici ile değiştirmeyin.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripSplitButton();
			this.kurtarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.standartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rastgeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripDropDownButton();
			this.kilitleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.kapatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.yenidenBaşlatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.uykuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.desktopViewerBtn = new System.Windows.Forms.ToolStripButton();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.kilitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.güçİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.kapatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.yenidenBaşlatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uykuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hibernateGüvenliUykuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listView1 = new RemoteManager.ExplorerListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.server1 = new RemoteManager.Server();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.refheshDesktop = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 35);
			this.panel1.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.desktopViewerBtn});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(800, 35);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(132, 32);
			this.toolStripLabel1.Text = "Bir bilgisayar seçin";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(60, 32);
			this.toolStripButton1.Text = "Ayarlar";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kurtarToolStripMenuItem});
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(100, 32);
			this.toolStripButton2.Text = "Daha Fazla";
			// 
			// kurtarToolStripMenuItem
			// 
			this.kurtarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standartToolStripMenuItem,
            this.rastgeleToolStripMenuItem});
			this.kurtarToolStripMenuItem.Name = "kurtarToolStripMenuItem";
			this.kurtarToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
			this.kurtarToolStripMenuItem.Text = "Anahtar";
			this.kurtarToolStripMenuItem.Click += new System.EventHandler(this.kurtarToolStripMenuItem_Click);
			// 
			// standartToolStripMenuItem
			// 
			this.standartToolStripMenuItem.Name = "standartToolStripMenuItem";
			this.standartToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
			this.standartToolStripMenuItem.Text = "Standart";
			this.standartToolStripMenuItem.Click += new System.EventHandler(this.standartToolStripMenuItem_Click_1);
			// 
			// rastgeleToolStripMenuItem
			// 
			this.rastgeleToolStripMenuItem.Name = "rastgeleToolStripMenuItem";
			this.rastgeleToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
			this.rastgeleToolStripMenuItem.Text = "Rastgele";
			this.rastgeleToolStripMenuItem.Click += new System.EventHandler(this.rastgeleToolStripMenuItem_Click_1);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kilitleToolStripMenuItem1,
            this.kapatToolStripMenuItem1,
            this.yenidenBaşlatToolStripMenuItem1,
            this.uykuToolStripMenuItem1});
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(144, 32);
			this.toolStripButton3.Text = "Tüm Bilgisayarlar\'ı";
			// 
			// kilitleToolStripMenuItem1
			// 
			this.kilitleToolStripMenuItem1.Name = "kilitleToolStripMenuItem1";
			this.kilitleToolStripMenuItem1.Size = new System.Drawing.Size(188, 26);
			this.kilitleToolStripMenuItem1.Text = "Kilitle";
			this.kilitleToolStripMenuItem1.Click += new System.EventHandler(this.kilitleToolStripMenuItem1_Click);
			// 
			// kapatToolStripMenuItem1
			// 
			this.kapatToolStripMenuItem1.Name = "kapatToolStripMenuItem1";
			this.kapatToolStripMenuItem1.Size = new System.Drawing.Size(188, 26);
			this.kapatToolStripMenuItem1.Text = "Kapat";
			this.kapatToolStripMenuItem1.Click += new System.EventHandler(this.kapatToolStripMenuItem1_Click);
			// 
			// yenidenBaşlatToolStripMenuItem1
			// 
			this.yenidenBaşlatToolStripMenuItem1.Name = "yenidenBaşlatToolStripMenuItem1";
			this.yenidenBaşlatToolStripMenuItem1.Size = new System.Drawing.Size(188, 26);
			this.yenidenBaşlatToolStripMenuItem1.Text = "Yeniden Başlat";
			this.yenidenBaşlatToolStripMenuItem1.Click += new System.EventHandler(this.yenidenBaşlatToolStripMenuItem1_Click);
			// 
			// uykuToolStripMenuItem1
			// 
			this.uykuToolStripMenuItem1.Name = "uykuToolStripMenuItem1";
			this.uykuToolStripMenuItem1.Size = new System.Drawing.Size(188, 26);
			this.uykuToolStripMenuItem1.Text = "Uyku";
			this.uykuToolStripMenuItem1.Click += new System.EventHandler(this.uykuToolStripMenuItem1_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
			// 
			// desktopViewerBtn
			// 
			this.desktopViewerBtn.Image = global::RemoteLanManager.Properties.Resources.play_flat;
			this.desktopViewerBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.desktopViewerBtn.Name = "desktopViewerBtn";
			this.desktopViewerBtn.Size = new System.Drawing.Size(122, 32);
			this.desktopViewerBtn.Text = "Sunum Başlat";
			this.desktopViewerBtn.Click += new System.EventHandler(this.desktopViewerBtn_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kilitleToolStripMenuItem,
            this.güçİşlemleriToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(164, 52);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// kilitleToolStripMenuItem
			// 
			this.kilitleToolStripMenuItem.Name = "kilitleToolStripMenuItem";
			this.kilitleToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
			this.kilitleToolStripMenuItem.Text = "Kilitle / Aç";
			this.kilitleToolStripMenuItem.Click += new System.EventHandler(this.kilitleToolStripMenuItem_Click);
			// 
			// güçİşlemleriToolStripMenuItem
			// 
			this.güçİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kapatToolStripMenuItem,
            this.yenidenBaşlatToolStripMenuItem,
            this.uykuToolStripMenuItem,
            this.hibernateGüvenliUykuToolStripMenuItem});
			this.güçİşlemleriToolStripMenuItem.Name = "güçİşlemleriToolStripMenuItem";
			this.güçİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
			this.güçİşlemleriToolStripMenuItem.Text = "Güç İşlemleri";
			// 
			// kapatToolStripMenuItem
			// 
			this.kapatToolStripMenuItem.Name = "kapatToolStripMenuItem";
			this.kapatToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
			this.kapatToolStripMenuItem.Text = "Kapat";
			this.kapatToolStripMenuItem.Click += new System.EventHandler(this.kapatToolStripMenuItem_Click_1);
			// 
			// yenidenBaşlatToolStripMenuItem
			// 
			this.yenidenBaşlatToolStripMenuItem.Name = "yenidenBaşlatToolStripMenuItem";
			this.yenidenBaşlatToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
			this.yenidenBaşlatToolStripMenuItem.Text = "Yeniden Başlat";
			this.yenidenBaşlatToolStripMenuItem.Click += new System.EventHandler(this.yenidenBaşlatToolStripMenuItem_Click_1);
			// 
			// uykuToolStripMenuItem
			// 
			this.uykuToolStripMenuItem.Name = "uykuToolStripMenuItem";
			this.uykuToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
			this.uykuToolStripMenuItem.Text = "Uyku";
			this.uykuToolStripMenuItem.Click += new System.EventHandler(this.uykuToolStripMenuItem_Click);
			// 
			// hibernateGüvenliUykuToolStripMenuItem
			// 
			this.hibernateGüvenliUykuToolStripMenuItem.Name = "hibernateGüvenliUykuToolStripMenuItem";
			this.hibernateGüvenliUykuToolStripMenuItem.Size = new System.Drawing.Size(253, 26);
			this.hibernateGüvenliUykuToolStripMenuItem.Text = "Hibernate(Güvenli Uyku)";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 35);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(800, 415);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Bilgisayar ID";
			this.columnHeader1.Width = 147;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Bağlantı";
			this.columnHeader2.Width = 153;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Kullanıcı Adı";
			this.columnHeader3.Width = 198;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Bilgisayar Adı";
			this.columnHeader4.Width = 126;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Kilitli";
			this.columnHeader5.Width = 86;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Anahtar";
			// 
			// server1
			// 
			this.server1.BufferSize = 4096;
			this.server1.Port = 0;
			this.server1.OnPacketRecevied += new RemoteManager.ServerBase.PacketRecevied(this.server1_OnPacketRecevied);
			this.server1.OnDisconnected += new RemoteManager.ServerBase.Disconnected(this.server1_OnDisconnected);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Enabled = true;
			this.timer2.Interval = 1;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// refheshDesktop
			// 
			this.refheshDesktop.Interval = 1;
			this.refheshDesktop.Tick += new System.EventHandler(this.refheshDesktop_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lan Computer Manager";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private RemoteManager.ExplorerListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem kilitleToolStripMenuItem;
		public RemoteManager.Server server1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripSplitButton toolStripButton2;
		private System.Windows.Forms.ToolStripMenuItem kurtarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ToolStripDropDownButton toolStripButton3;
		private System.Windows.Forms.ToolStripMenuItem kilitleToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem kapatToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem yenidenBaşlatToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem güçİşlemleriToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem kapatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem yenidenBaşlatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uykuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hibernateGüvenliUykuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem uykuToolStripMenuItem1;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ToolStripMenuItem standartToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rastgeleToolStripMenuItem;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton desktopViewerBtn;
		private System.Windows.Forms.Timer refheshDesktop;
	}
}

