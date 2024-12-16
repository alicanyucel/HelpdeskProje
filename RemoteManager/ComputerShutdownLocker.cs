using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteManager
{
    public class ComputerShutdownLocker
    {
        public ComputerShutdownLocker()
        {
            thread=new Thread(start);
        } 
        Thread thread; 
        void hideShutdownButtton()
        {

        } 
        public void Start()
        {
            thread.Start();
        }
        bool islocking = true;
        void start()
        {
            Process prc = new Process();
            prc.StartInfo.WorkingDirectory = Environment.SystemDirectory;
            prc.StartInfo.UseShellExecute = false;
            prc.StartInfo.CreateNoWindow = true;
            prc.EnableRaisingEvents = true;
            prc.StartInfo.RedirectStandardInput = true;
            prc.StartInfo.FileName = "cmd.exe";

            prc.Start();
            while (true)
            {
                if (islocking == true) {
                    if (prc.HasExited == false)
                    {
                        prc.Start();
                    }
                    if (prc.HasExited == false)
                    {
                        prc.StandardInput.WriteLine("shutdown -a");
                    }
                }
                else
                {

                }
               Thread.Sleep(1000);
            }
        }
    }
}
