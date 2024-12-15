namespace NetworkScannerForm
{
    public partial class NetworkScannerForm : Form
    {
        private ListBox lbComputers;
        private Button btnShutdown;
        private Button btnWakeUp;
        private TextBox txtComputerName;
        public NetworkScannerForm()
        {
            // Form ayarlar�
            this.Text = "A� Bilgisayarlar�";
            this.Size = new System.Drawing.Size(400, 300);

            // ListBox olu�turuluyor
            lbComputers = new ListBox();
            lbComputers.Location = new System.Drawing.Point(20, 20);
            lbComputers.Size = new System.Drawing.Size(300, 150);
            this.Controls.Add(lbComputers);

            // Shutdown butonu olu�turuluyor
            btnShutdown = new Button();
            btnShutdown.Text = "Kapat";
            btnShutdown.Location = new System.Drawing.Point(20, 180);
            btnShutdown.Click += BtnShutdown_Click;
            this.Controls.Add(btnShutdown);

            // WakeUp butonu olu�turuluyor
            btnWakeUp = new Button();
            btnWakeUp.Text = "A�";
            btnWakeUp.Location = new System.Drawing.Point(120, 180);
            btnWakeUp.Click += BtnWakeUp_Click;
            this.Controls.Add(btnWakeUp);
            // TextBox olu�turuluyor (komut verilecek bilgisayar ad� i�in)
            txtComputerName = new TextBox();
            txtComputerName.Location = new System.Drawing.Point(20, 220);
            txtComputerName.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(txtComputerName);

            // Uygulama ba�lad���nda a� taramas� yap�l�yor
            ScanNetwork("192.168.1"); // A� alt a��na g�re de�i�tirin
        }

        private void NetworkScannerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
