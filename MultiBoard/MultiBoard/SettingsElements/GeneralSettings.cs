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
    public partial class GeneralSettings : UserControl
    {
        public GeneralSettings()
        {
            InitializeComponent();

            PRIORITY_TRACKBAR.Value = Properties.Settings.Default.ThreadPriority;
            STAY_HIDDEN_CHECKBOX.Checked = Properties.Settings.Default.StayHidden;
            TIME_OUT_TRACKBAR.Value = Properties.Settings.Default.TimeOutDelay;
        }

        private void PRIORITY_TRACKBAR_ValueChanged(object sender, EventArgs e)
        {
            switch (PRIORITY_TRACKBAR.Value)
            {
                case 1:
                    THREAD_PRI_LABEL.Text = "Idle";
                    break;
                case 2:
                    THREAD_PRI_LABEL.Text = "Below normal";
                    break;
                case 3:
                    THREAD_PRI_LABEL.Text = "Normal";
                    break;
                case 4:
                    THREAD_PRI_LABEL.Text = "Above normal";
                    break;
                case 5:
                    THREAD_PRI_LABEL.Text = "Highest";
                    break;
                case 6:
                    THREAD_PRI_LABEL.Text = "RealTime";
                    break;
            }

        }

        private void SAVE_BUTTON_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ThreadPriority = PRIORITY_TRACKBAR.Value;
            Properties.Settings.Default.StayHidden = STAY_HIDDEN_CHECKBOX.Checked;
            Properties.Settings.Default.TimeOutDelay = TIME_OUT_TRACKBAR.Value;
            Properties.Settings.Default.Save();

            overlays.SavedOverlay l = new overlays.SavedOverlay();
            l.Width = this.Width;
            l.Height = this.Height;
            l.Location = new Point(0, 0);
            Controls.Add(l);
            l.Show();
            l.BringToFront();
        }

        private void TIME_OUT_TRACKBAR_ValueChanged(object sender, EventArgs e)
        {
            TIME_DELAY_LABEL.Text = TIME_OUT_TRACKBAR.Value + "ms";
        }
    }
}
