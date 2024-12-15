using System;
using System.Diagnostics;

public class RemoteShutdown
{
    static void Main(string[] args)
    {
        // Kullanıcıdan bilgisayar adı alınıyor
        Console.WriteLine("Enter the computer name to shutdown:");
        string computerName = Console.ReadLine();

        // ShutdownComputer metodunu doğru şekilde çağırıyoruz
        ShutdownComputer(computerName);
    }

    public static void ShutdownComputer(string computerName)
    {
        try
        {
            // Komut oluşturuluyor
            string command = $@"\\{computerName} shutdown /s /f /t 0";

            // Komut çalıştırılıyor
            Process.Start("cmd.exe", "/C " + command);

            // Bilgisayara shutdown komutunun gönderildiği yazdırılıyor
            Console.WriteLine($"Shutdown command sent to {computerName}");
        }
        catch (Exception ex)
        {
            // Hata varsa yazdırılıyor
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
