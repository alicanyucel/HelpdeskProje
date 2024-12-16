using RemoteManager;
using RemoteManager.Serializer;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetProcessShutdownParameters(0x3FF, SHUTDOWN_NORETRY);
        }
        //
        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_ENDSESSION = 0x0016;
        public const uint SHUTDOWN_NORETRY = 0x00000001;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string reason);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShutdownBlockReasonDestroy(IntPtr hWnd);
        [DllImport("kernel32.dll")]
        static extern bool SetProcessShutdownParameters(uint dwLevel, uint dwFlags);
        [DllImport("Advapi32.dll")]
        static extern bool AbortSystemShutdownW([MarshalAs(UnmanagedType.LPWStr)] string lpMachineName);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION || m.Msg == WM_ENDSESSION)
            {
                // Prevent windows shutdown
                ShutdownBlockReasonCreate(this.Handle, "I want to live!");

                // This method must be called on the same thread as the one that have create the Handle, so use BeginInvoke


                // Allow Windows to shutdown




                return;
            }

            base.WndProc(ref m);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = checkBox1.Checked;
            




        }
        private void DoOperation(string oparation)
        {


        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool ret=AbortSystemShutdownW(null);
        }
    }
}
