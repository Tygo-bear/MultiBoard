using System;
using System.Windows.Forms;

namespace MultiBoard.add_keyboard
{
    public partial class ManuallyAddKeyboard : UserControl
    {
        //Events
        //==================
        public event EventHandler KeyboardAdded;

        //Vars
        //=================
        public string keyboardName;
        public string keyboardComPort;
        public string keyboardId;


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
            if (checkUserInput())
            {
                keyboardName = NAME_TEXT_BOX.Text;
                keyboardComPort = COM_PORT_TEXT_BOX.Text;
                keyboardId = UUID_TEXT_BOX.Text;

                if (KeyboardAdded != null)
                {
                    KeyboardAdded(this, EventArgs.Empty);
                    this.Dispose();
                }

            }
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

        /// <summary>
        /// Check if user as provided valid input
        /// </summary>
        /// <returns>
        /// true = valid
        /// false = invalid
        /// </returns>
        private bool checkUserInput()
        {
            if (!String.IsNullOrEmpty(NAME_TEXT_BOX.Text)
                && !String.IsNullOrEmpty(COM_PORT_TEXT_BOX.Text)
                && !String.IsNullOrEmpty(UUID_TEXT_BOX.Text))
            {
                return true;
            }
            return false;
        }
    }
}
