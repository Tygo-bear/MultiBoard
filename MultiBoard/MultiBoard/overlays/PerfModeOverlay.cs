using System;
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

        /// <summary>
        /// User clicked "start" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void START_BUTTON_Click(object sender, EventArgs e)
        {
            if (StartPerfMode != null)
            {
                StartPerfMode(this, EventArgs.Empty);
            }
        }
    }
}
