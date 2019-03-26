using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiBoard.SettingsElements
{
    public partial class MainSettings : UserControl
    {
        //Controls
        //==================
        private GeneralSettings _gs = new GeneralSettings();

        public MainSettings()
        {
            InitializeComponent();

            _gs.Location = new Point(168,0);
            Controls.Add(_gs);
            _gs.Show();
        }

        /// <summary>
        /// User clicked "general" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GENERAL_BUTTON_Click(object sender, EventArgs e)
        {
            _gs.Show();
            _gs.BringToFront();
        }
    }
}
