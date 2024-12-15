using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

public class NetworkScanner
{
    static async Task Main(string[] args)
    {
        // Kullanıcıdan ağ alt ağı (subnet) bilgisi alınıyor
        Console.WriteLine("Enter the subnet to scan (e.g., 192.168.1):");
        string subnet = Console.ReadLine();

        // ScanNetwork metodu çağrılıyor
        await ScanNetwork(subnet);
    }

    public static async Task ScanNetwork(string subnet)
    {
        // 1'den 254'e kadar IP'leri tarama
        for (int i = 1; i < 255; i++)
        {
            string ip = $"{subnet}.{i}";
            var ping = new Ping();
            try
            {
                // IP'ye ping gönderiliyor ve yanıt bekleniyor
                PingReply reply = await ping.SendPingAsync(ip, 1000);
                if (reply.Status == IPStatus.Success)
                {
                    // Eğer ping başarılıysa, aktif IP yazdırılıyor
                    Console.WriteLine($"Active IP found: {ip}");
                }
            }
            catch (PingException ex)
            {
                // Hata durumu yazdırılıyor (isteğe bağlı)
                Console.WriteLine($"Error pinging {ip}: {ex.Message}");
            }
        }
    }
}
