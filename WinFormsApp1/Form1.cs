using System.Net.NetworkInformation;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            string str = "fdff"; 
            Type typ= str.GetType();
            
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

        private void btnShutdown_Click(object sender, EventArgs e)
        {

            // ListBox'tan seçili bilgisayarýn kapatýlmasý
            string selectedComputer = lbComputers.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedComputer))
            {
                ShutdownComputer(selectedComputer);
            }
        }

        private void btnWakeUp_Click(object sender, EventArgs e)
        {
            // Wake-on-LAN iþlemi burada yapýlabilir
            string? selectedComputer = lbComputers.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedComputer))
            {
                WakeUpComputer(selectedComputer);
            }
        }
        private void WakeUpComputer(string computerName)
        {
            // Wake-on-LAN komutunu göndermek için gerekli kodu ekleyin
            // Bu kýsýmda, uzak bilgisayara bir Wake-on-LAN paket gönderilebilir.
            MessageBox.Show($"Wake-up command sent to {computerName}");
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

    }
}
