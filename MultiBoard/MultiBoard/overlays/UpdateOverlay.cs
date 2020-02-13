using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class UpdateOverlay : UserControl
    {
        public string downloadUrl { get; set; }
        private string _main = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MultiBoard";
        private bool installStarted = false;
        public UpdateOverlay()
        {
            InitializeComponent();
        }

        private void DISABLE_UPDATES_BUTTON_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdates = 0;
            Properties.Settings.Default.Save();
            this.Dispose();
        }

        private void LATER_BUTTON_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void INSTALL_BUTTON_Click(object sender, EventArgs e)
        {
            startDownload();
        }

        private void startDownload()
        {
            progressBar1.Visible = true;
            LATER_BUTTON.Enabled = false;
            DISABLE_UPDATES_BUTTON.Enabled = false;

            checkFileSystem();

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri(downloadUrl),
                    // Param2 = Path to save
                    _main + @"\update\MultiBoard_setup.exe"
                );
            }


        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100 && !installStarted)
            {
                System.Diagnostics.Process.Start(_main + @"\update\MultiBoard_setup.exe");
                installStarted = true;
                Application.Exit();
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void checkFileSystem()
        {
            
            if (!Directory.Exists(_main + @"\update"))
            {
                Directory.CreateDirectory(_main + @"\update");
            }

            if (File.Exists(_main + @"\update\MultiBoard_setup.exe"))
            {
                File.Delete(_main + @"\update\MultiBoard_setup.exe");
            }
        }
    }
}
