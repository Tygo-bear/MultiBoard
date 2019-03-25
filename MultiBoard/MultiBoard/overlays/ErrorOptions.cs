using System;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class ErrorOptions : UserControl
    {
        public ErrorOptions()
        {
            InitializeComponent();
        }

        public event EventHandler IgnoreClicked;
        public event EventHandler ReloadClicked;
        public event EventHandler ViewClicked;

        private void IGNORE_PANEL_Click(object sender, EventArgs e)
        {
            if (IgnoreClicked != null) IgnoreClicked(this, EventArgs.Empty);
        }

        private void VIEW_PANEL_Click(object sender, EventArgs e)
        {
            if (ViewClicked != null) ViewClicked(this, EventArgs.Empty);
        }

        private void RELOAD_PAENEL_Click(object sender, EventArgs e)
        {
            if (ReloadClicked != null) ReloadClicked(this, EventArgs.Empty);
        }

        private void ErrorOptions_Leave(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
