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
    public partial class SelectKeyTaskOverlay : UserControl
    {
        public event EventHandler UserMadeSelection;

        public string selectedKey = "";

        public SelectKeyTaskOverlay()
        {
            InitializeComponent();
        }

        private void OK_BUTTON_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(KEY_COMBOBOX.Text))
            {
                //error
            }
            else
            {
                selectedKey = KEY_COMBOBOX.Text;

                if (UserMadeSelection != null)
                {
                    UserMadeSelection(this, EventArgs.Empty);
                }
            }
        }

        private void CLOSE_B_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
