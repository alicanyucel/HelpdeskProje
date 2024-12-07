using System;
using System.Diagnostics;

public class RemoteShutdown
{
    public static void ShutdownComputer(string computerName)
    {
        try
        {
            string command = $@"\\{computerName} shutdown /s /f /t 0";
            Process.Start("cmd.exe", command);
            Console.WriteLine($"Shutdown command sent to {computerName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}