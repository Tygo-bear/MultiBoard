using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiBoard.SettingsElements
{
    public partial class GeneralSettings : UserControl
    {
        /// <summary>
        /// Create control and load in settings
        /// </summary>
        public GeneralSettings()
        {
            InitializeComponent();

            //Load in settings
            PRIORITY_TRACKBAR.Value = Properties.Settings.Default.ThreadPriority;
            STAY_HIDDEN_CHECKBOX.Checked = Properties.Settings.Default.StayHidden;
            TIME_OUT_TRACKBAR.Value = Properties.Settings.Default.TimeOutDelay;
        }

        /// <summary>
        /// Update controls when priority track bar changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PRIORITY_TRACKBAR_ValueChanged(object sender, EventArgs e)
        {
            //Show correct text
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

        /// <summary>
        /// User clicked "save" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SAVE_BUTTON_Click(object sender, EventArgs e)
        {
            //Save settings
            Properties.Settings.Default.ThreadPriority = PRIORITY_TRACKBAR.Value;
            Properties.Settings.Default.StayHidden = STAY_HIDDEN_CHECKBOX.Checked;
            Properties.Settings.Default.TimeOutDelay = TIME_OUT_TRACKBAR.Value;
            Properties.Settings.Default.Save();

            //show save overlay
            overlays.SavedOverlay l = new overlays.SavedOverlay();
            l.Width = this.Width;
            l.Height = this.Height;
            l.Location = new Point(0, 0);
            Controls.Add(l);
            l.Show();
            l.BringToFront();
        }

        /// <summary>
        /// Update controls when delay track bar changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TIME_OUT_TRACKBAR_ValueChanged(object sender, EventArgs e)
        {
            TIME_DELAY_LABEL.Text = TIME_OUT_TRACKBAR.Value + "ms";
        }
    }
}
