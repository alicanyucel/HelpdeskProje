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
            // Form ayarlarý
            this.Text = "Að Bilgisayarlarý";
            this.Size = new System.Drawing.Size(400, 300);

            // ListBox oluþturuluyor
            lbComputers = new ListBox();
            lbComputers.Location = new System.Drawing.Point(20, 20);
            lbComputers.Size = new System.Drawing.Size(300, 150);
            this.Controls.Add(lbComputers);

            // Shutdown butonu oluþturuluyor
            btnShutdown = new Button();
            btnShutdown.Text = "Kapat";
            btnShutdown.Location = new System.Drawing.Point(20, 180);
            btnShutdown.Click += BtnShutdown_Click;
            this.Controls.Add(btnShutdown);

            // WakeUp butonu oluþturuluyor
            btnWakeUp = new Button();
            btnWakeUp.Text = "Aç";
            btnWakeUp.Location = new System.Drawing.Point(120, 180);
            btnWakeUp.Click += BtnWakeUp_Click;
            this.Controls.Add(btnWakeUp);
            // TextBox oluþturuluyor (komut verilecek bilgisayar adý için)
            txtComputerName = new TextBox();
            txtComputerName.Location = new System.Drawing.Point(20, 220);
            txtComputerName.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(txtComputerName);

            // Uygulama baþladýðýnda að taramasý yapýlýyor
            ScanNetwork("192.168.1"); // Að alt aðýna göre deðiþtirin
        }

        private void NetworkScannerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
