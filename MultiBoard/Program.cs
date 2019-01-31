using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard
{
    static class Program
    {
        private static string appGuid = "8c14eced-65ff-49d3-9077-a8c95aa2a054";

        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Instance already running");
                    return;
                }

                GC.Collect();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
