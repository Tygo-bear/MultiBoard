using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard
{
    public partial class ErrorOptions : UserControl
    {
        public ErrorOptions()
        {
            InitializeComponent();
        }

        public event EventHandler ignoreClicked;
        public event EventHandler reloadClicked;
        public event EventHandler viewClicked;

        private void IGNORE_PANEL_Click(object sender, EventArgs e)
        {
            ignoreClicked(this, EventArgs.Empty);
        }

        private void VIEW_PANEL_Click(object sender, EventArgs e)
        {
            viewClicked(this, EventArgs.Empty);
        }

        private void RELOAD_PAENEL_Click(object sender, EventArgs e)
        {
            reloadClicked(this, EventArgs.Empty);
        }
    }
}
