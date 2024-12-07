using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

public class NetworkScanner
{
    public static async Task ScanNetwork(string subnet)
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
                    Console.WriteLine($"Active IP found: {ip}");
                }
            }
            catch (PingException ex)
            {
                Console.WriteLine("/n",ex.ToString());
                
            }
        }
    }
}
