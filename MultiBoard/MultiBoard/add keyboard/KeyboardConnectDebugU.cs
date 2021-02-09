using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiBoardKeyboard;

namespace MultiBoard.add_keyboard
{
    public partial class KeyboardConnectDebugU : UserControl
    {
        private bool _busy = false;
        public KeyboardConnectDebugU()
        {
            InitializeComponent();
        }

        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            if (!_busy)
            {
                _busy = true;
                DEBUG_LABEL.Text = "Scanning....";
                LOG_TEXTBOX.Text = "";
                LOG_TEXTBOX.AppendText("Starting...");
                SCANNER_BACKWORKER.RunWorkerAsync();
            }
        }

        private void CLOSE_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SCANNER_BACKWORKER_DoWork(object sender, DoWorkEventArgs e)
        {
            //Start a keyboardScanner
            KeyboardScanner kbs = new KeyboardScanner(
                10000,
                Properties.Resources.KeyboardScanner__staticId,
                false);
            kbs.DebugCallBack += KbsOnDebugCallBack;
            kbs.LoadList(115200);

            //Filter keyboards
            //filterKeyboards(kbs.Ports, kbs.Uuid);

            //Update control
            _busy = false;
            this.Invoke(new Action(() =>
            {
                LOG_TEXTBOX.AppendText("\n\n===KEYBOARDS DISCOVERER===");
                for (int i = 0; i < kbs.Ports.Count; i++)
                {
                    LOG_TEXTBOX.AppendText("\n    " + kbs.Ports[i] + ": " + kbs.Uuid[i]);
                }

                DEBUG_LABEL.Text = "done";
            }));
        }

        private void KbsOnDebugCallBack(object sender, string e)
        {
            this.Invoke(new Action(() =>
            {
                LOG_TEXTBOX.AppendText(e);
                LOG_TEXTBOX.ScrollToCaret();
            }));
        }
    }
}
