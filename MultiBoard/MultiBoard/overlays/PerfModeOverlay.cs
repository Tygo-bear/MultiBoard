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
    public partial class PerfModeOverlay : UserControl
    {
        public event EventHandler StartPerfMode;

        public PerfModeOverlay()
        {
            InitializeComponent();
        }

        private void START_BUTTON_Click(object sender, EventArgs e)
        {
            if (StartPerfMode != null)
            {
                StartPerfMode(this, EventArgs.Empty);
            }
        }
    }
}
