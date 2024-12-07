using System;
using System.Net;
using System.Net.Sockets;

public class WakeOnLan
{
    public static void SendWakeOnLan(string macAddress)
    {
        byte[] packet = new byte[102]; // Wake-on-LAN packet
        for (int i = 0; i < 6; i++) packet[i] = 0xFF; // 6 bytes of 0xFF
        byte[] macBytes = GetMacBytes(macAddress);
        for (int i = 6; i < 102; i += 6)
        {
            Array.Copy(macBytes, 0, packet, i, 6);
        }

        // Broadcast to the network
        UdpClient udpClient = new UdpClient();
        udpClient.Connect(new IPEndPoint(IPAddress.Broadcast, 9)); // Port 9 default for WoL
        udpClient.Send(packet, packet.Length);
        udpClient.Close();
        Console.WriteLine("Magic packet sent to wake up the computer.");
    }

    private static byte[] GetMacBytes(string macAddress)
    {
        string[] hex = macAddress.Split(':');
        byte[] bytes = new byte[6];
        for (int i = 0; i < 6; i++)
        {
            bytes[i] = Convert.ToByte(hex[i], 16);
        }
        return bytes;
    }
}
