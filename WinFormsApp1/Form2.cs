using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent(); 
            th=new Thread(init);
        }
        Thread th; 
        void init()
        {
            while (true) {
                Process[] procs = Process.GetProcessesByName("shutdown");
                for (int i = 0; i < procs.Length; i++) {
                   
                    kill(procs[i]);
                    MessageBox.Show("killed");
                }
            }
        } 
        void kill(Process prc)
        {
            prc.Kill();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            th.Start();
        }
    }
}
