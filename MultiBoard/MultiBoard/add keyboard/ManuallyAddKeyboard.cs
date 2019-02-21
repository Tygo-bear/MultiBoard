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
    public partial class ManuallyAddKeyboard : UserControl
    {
        public ManuallyAddKeyboard()
        {
            InitializeComponent();
        }

        private void ADD_BUTTON_Click(object sender, EventArgs e)
        {

        }

        private void BAKC_BUTTON_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
