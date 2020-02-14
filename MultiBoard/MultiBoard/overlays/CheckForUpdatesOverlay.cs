using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class CheckForUpdatesOverlay : UserControl
    {
        public CheckForUpdatesOverlay()
        {
            InitializeComponent();
        }

        private void YES_BUTTON_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdates = 1;
            Properties.Settings.Default.Save();
            this.Dispose();
        }

        private void NO_BUTTON_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdates = 0;
            Properties.Settings.Default.Save();
            this.Dispose();
        }

        private void LATER_BUTTON_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
