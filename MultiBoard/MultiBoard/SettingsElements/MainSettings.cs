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
        private InfoSettings _is = new InfoSettings();

        public MainSettings()
        {
            InitializeComponent();

            MAIN_PANEL.Controls.Add(_gs);
            _gs.Dock = DockStyle.Fill;
            _gs.Show();

            MAIN_PANEL.Controls.Add(_is);
            _is.Dock = DockStyle.Fill;
        }

        public void UpdateSettings()
        {
            _gs.UpdateSettings();
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

        private void INFO_BUTTON_Click(object sender, EventArgs e)
        {
            _is.Show();
            _is.BringToFront();
        }
    }
}
