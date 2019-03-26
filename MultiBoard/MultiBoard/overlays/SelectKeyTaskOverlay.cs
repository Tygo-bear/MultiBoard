using System;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class SelectKeyTaskOverlay : UserControl
    {
        //Events
        //===============
        public event EventHandler UserMadeSelection;

        //Vars
        //==============
        public string SelectedKey = "";

        public SelectKeyTaskOverlay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// User clicked "OK" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OK_BUTTON_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(KEY_COMBOBOX.Text))
            {
                //error
            }
            else
            {
                SelectedKey = KEY_COMBOBOX.Text;

                if (UserMadeSelection != null)
                {
                    UserMadeSelection(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// User clicked "close" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CLOSE_B_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
