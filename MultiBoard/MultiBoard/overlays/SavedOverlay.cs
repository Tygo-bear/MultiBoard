using System;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class SavedOverlay : UserControl
    {
        public SavedOverlay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fade timer, delete control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
