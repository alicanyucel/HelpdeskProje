//namespace HelpDeskForm
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Form1 : Form
{
    private ListBox lbComputers;
    private Button btnShutdown;
    private Button btnWakeUp;
    private TextBox txtComputerName;

    public Form1()
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

    private async Task ScanNetwork(string subnet)
    {
        for (int i = 1; i < 255; i++)
        {
            string ip = $"{subnet}.{i}";
            var ping = new Ping();
            try
            {
                PingReply reply = await ping.SendPingAsync(ip, 1000);
                if (reply.Status == IPStatus.Success)
                {
                    lbComputers.Items.Add(ip); // Aktif bilgisayarlarý ListBox'a ekliyoruz
                }
            }
            catch (PingException ex)
            {
                // Hata durumunda hiçbir iþlem yapmýyoruz
            }
        }
    }

    private void BtnShutdown_Click(object sender, EventArgs e)
    {
        // ListBox'tan seçili bilgisayarýn kapatýlmasý
        string selectedComputer = lbComputers.SelectedItem as string;
        if (!string.IsNullOrEmpty(selectedComputer))
        {
            ShutdownComputer(selectedComputer);
        }
    }

    private void BtnWakeUp_Click(object sender, EventArgs e)
    {
        // Wake-on-LAN iþlemi burada yapýlabilir
        string selectedComputer = lbComputers.SelectedItem as string;
        if (!string.IsNullOrEmpty(selectedComputer))
        {
            WakeUpComputer(selectedComputer);
        }
    }

    private void ShutdownComputer(string computerName)
    {
        try
        {
            string command = $@"\\{computerName} shutdown /s /f /t 0";
            System.Diagnostics.Process.Start("cmd.exe", "/C " + command);
            MessageBox.Show($"Shutdown command sent to {computerName}");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    private void WakeUpComputer(string computerName)
    {
        // Wake-on-LAN komutunu göndermek için gerekli kodu ekleyin
        // Bu kýsýmda, uzak bilgisayara bir Wake-on-LAN paket gönderilebilir.
        MessageBox.Show($"Wake-up command sent to {computerName}");
    }

    public static void Main()
    {
        Application.Run(new Form1());
    }
}

