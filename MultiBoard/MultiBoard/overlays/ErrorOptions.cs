using System;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class ErrorOptions : UserControl
    {
        //Events
        //=============
        public event EventHandler IgnoreClicked;
        public event EventHandler ReloadClicked;
        public event EventHandler ViewClicked;

        public ErrorOptions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// User clicked "ignore" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IGNORE_PANEL_Click(object sender, EventArgs e)
        {
            if (IgnoreClicked != null) IgnoreClicked(this, EventArgs.Empty);
        }

        /// <summary>
        /// User clicked "show" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VIEW_PANEL_Click(object sender, EventArgs e)
        {
            if (ViewClicked != null) ViewClicked(this, EventArgs.Empty);
        }

        /// <summary>
        /// User clicked "reload" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RELOAD_PAENEL_Click(object sender, EventArgs e)
        {
            if (ReloadClicked != null) ReloadClicked(this, EventArgs.Empty);
        }

        /// <summary>
        /// Focus lost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErrorOptions_Leave(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
