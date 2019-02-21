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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
