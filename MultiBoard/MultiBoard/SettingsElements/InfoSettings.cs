using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard.SettingsElements
{
    public partial class InfoSettings : UserControl
    {
        public InfoSettings()
        {
            InitializeComponent();
        }

        private void OPEN_GITHUB_BUTTON_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Tygo-bear/MultiBoard");
        }

        private void OPEN_BUGREPORT_BUTTON_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Tygo-bear/MultiBoard/issues");
        }
    }
}
