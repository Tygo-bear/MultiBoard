using System;
using System.Windows.Forms;

namespace MultiBoard.add_keyboard
{
    public partial class ManuallyAddKeyboard : UserControl
    {
        public ManuallyAddKeyboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// User clicked on "ADD" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ADD_BUTTON_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// User clicked on "back"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BACK_BUTTON_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
