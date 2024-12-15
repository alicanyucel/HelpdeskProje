using System.Net.NetworkInformation;

namespace NwtworkScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ScanNetwork("192.168.1");
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
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void btnShutDown_Click(object sender, EventArgs e)
        {
            string selectedComputer = lbComputers.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedComputer))
            {
                ShutdownComputer(selectedComputer);
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

        private void btnWakeUp_Click(object sender, EventArgs e)
        {
            // Wake-on-LAN iþlemi burada yapýlabilir
            string selectedComputer = lbComputers.SelectedItem as string;
            if (!string.IsNullOrEmpty(selectedComputer))
            {
                WakeUpComputer(selectedComputer);
            }
        }
        public static void Main()
        {
            Application.Run(new Form1());
        }
    }
}
