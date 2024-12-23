namespace RemoteLanManager
{
	partial class KeyInstallerForm
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
			this.button1 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.StandartkeyOption = new System.Windows.Forms.RadioButton();
			this.RandomKeyOption = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.KeyID = new System.Windows.Forms.TextBox();
			this.KeyNumberx = new System.Windows.Forms.TextBox();
			this.keylabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(523, 295);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 31);
			this.button1.TabIndex = 2;
			this.button1.Text = "Kur";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(3, 110);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(598, 180);
			this.listBox1.TabIndex = 3;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.button2.Location = new System.Drawing.Point(7, 296);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 31);
			this.button2.TabIndex = 4;
			this.button2.Text = "Yenile";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(581, 21);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "Anahtarın yükleneceği disk seçin. Eğer bilgisayarlar açılmazsa  anahtar ile açabi" +
    "lirsiniz";
			// 
			// StandartkeyOption
			// 
			this.StandartkeyOption.AutoSize = true;
			this.StandartkeyOption.Checked = true;
			this.StandartkeyOption.Location = new System.Drawing.Point(176, 39);
			this.StandartkeyOption.Name = "StandartkeyOption";
			this.StandartkeyOption.Size = new System.Drawing.Size(127, 20);
			this.StandartkeyOption.TabIndex = 6;
			this.StandartkeyOption.TabStop = true;
			this.StandartkeyOption.Text = "Standart Anahtar";
			this.StandartkeyOption.UseVisualStyleBackColor = true;
			this.StandartkeyOption.CheckedChanged += new System.EventHandler(this.StandartkeyOption_CheckedChanged);
			// 
			// RandomKeyOption
			// 
			this.RandomKeyOption.AutoSize = true;
			this.RandomKeyOption.Location = new System.Drawing.Point(309, 39);
			this.RandomKeyOption.Name = "RandomKeyOption";
			this.RandomKeyOption.Size = new System.Drawing.Size(132, 20);
			this.RandomKeyOption.TabIndex = 7;
			this.RandomKeyOption.Text = "Rastgele Anahtar";
			this.RandomKeyOption.UseVisualStyleBackColor = true;
			this.RandomKeyOption.CheckedChanged += new System.EventHandler(this.RandomKeyOption_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 71);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "Key ID";
			// 
			// KeyID
			// 
			this.KeyID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.KeyID.Location = new System.Drawing.Point(56, 65);
			this.KeyID.Name = "KeyID";
			this.KeyID.ReadOnly = true;
			this.KeyID.Size = new System.Drawing.Size(329, 22);
			this.KeyID.TabIndex = 9;
			// 
			// KeyNumberx
			// 
			this.KeyNumberx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.KeyNumberx.Location = new System.Drawing.Point(487, 68);
			this.KeyNumberx.Name = "KeyNumberx";
			this.KeyNumberx.ReadOnly = true;
			this.KeyNumberx.Size = new System.Drawing.Size(106, 22);
			this.KeyNumberx.TabIndex = 11;
			// 
			// keylabel
			// 
			this.keylabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.keylabel.AutoSize = true;
			this.keylabel.Location = new System.Drawing.Point(400, 71);
			this.keylabel.Name = "keylabel";
			this.keylabel.Size = new System.Drawing.Size(81, 16);
			this.keylabel.TabIndex = 10;
			this.keylabel.Text = "Key Number";
			// 
			// KeyInstallerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(605, 332);
			this.Controls.Add(this.KeyNumberx);
			this.Controls.Add(this.keylabel);
			this.Controls.Add(this.KeyID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RandomKeyOption);
			this.Controls.Add(this.StandartkeyOption);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "KeyInstallerForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Anahtar Yükle";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyInstallerForm_FormClosing);
			this.Load += new System.EventHandler(this.KeyInstallerForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.RadioButton StandartkeyOption;
		private System.Windows.Forms.RadioButton RandomKeyOption;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox KeyID;
		private System.Windows.Forms.TextBox KeyNumberx;
		private System.Windows.Forms.Label keylabel;
	}
}