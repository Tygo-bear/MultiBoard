using System;
using System.Windows.Forms;

namespace MultiBoard.KeyboardElements
{
    public partial class KeyboardSettings : UserControl
    {
        //vars
        //===================
        public string KbName;
        public string KbUuid;
        public string KbPort;

        private bool _lockedSettings = true;

        public KeyBoard ConnectedKeyboard;

        //Events
        //==========================
        public event EventHandler Save;
        public event EventHandler Delete;

        /// <summary>
        /// Settings to load in the user control
        /// </summary>
        /// <param name="kName">
        /// Uuid of the keyboard
        /// </param>
        /// <param name="kId">
        /// Keyboard ID
        /// </param>
        /// <param name="kCom">
        /// The com port of the keyboard
        /// </param>
        /// <param name="board">
        /// The keyboard class in represents
        /// </param>
        public KeyboardSettings(string kName, string kId, string kCom, KeyBoard board)
        {
            InitializeComponent();

            KbName = kName;
            KbUuid = kId;
            KbPort = kCom;
            ConnectedKeyboard = board;

            KEYBOARD_NAME_TEXTBOX.Text = kName;
            KEYBOARD_UUID_TEXTBOX.Text = kId;
            KEYBOARD_COMP_TEXTBOX.Text = kCom;

        }

        private void BACK_BUTTON_Click(object sender, EventArgs e)
        {
            //back/close
            this.Dispose();
        }

        private void DELETE_BUTTON_Click(object sender, EventArgs e)
        {
            //delete
            if(Delete != null)
            {
                Delete(this, EventArgs.Empty);
            }
        }

        private void SAVE_BUTTON_Click(object sender, EventArgs e)
        {
            //check for correct input
            if (checkInput())
            {
                //save the data
                KbName = KEYBOARD_NAME_TEXTBOX.Text;
                KbUuid = KEYBOARD_UUID_TEXTBOX.Text;
                KbPort = KEYBOARD_COMP_TEXTBOX.Text;

                //call event
                if (Save != null)
                {
                    Save(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Check user input if it is valid
        /// </summary>
        /// <returns>
        /// Valid = true
        /// Invalid = false
        /// </returns>
        private bool checkInput()
        {
            //check if user has left the field empty
            if(String.IsNullOrEmpty(KEYBOARD_NAME_TEXTBOX.Text) 
               || String.IsNullOrEmpty(KEYBOARD_UUID_TEXTBOX.Text)
               || String.IsNullOrEmpty(KEYBOARD_COMP_TEXTBOX.Text))
            {
                return false;
            }

            if (KEYBOARD_NAME_TEXTBOX.Text.Contains("|")
                || KEYBOARD_UUID_TEXTBOX.Text.Contains("|")
                || KEYBOARD_COMP_TEXTBOX.Text.Contains("|"))
            {
                return false;
            }
            return true;
        }

        private void LOCK_BUTTON_Click(object sender, EventArgs e)
        {
            //Toggle the dangerous settings lock on/off
            if (_lockedSettings == true)
            {
                _lockedSettings = false;
                LOCK_1_PICTURE.Hide();
                LOCK_2_PICTURE.Hide();
                DELETE_BUTTON.Enabled = true;
                KEYBOARD_UUID_TEXTBOX.ReadOnly = false;
            }
            else
            {
                _lockedSettings = true;
                LOCK_1_PICTURE.Show();
                LOCK_2_PICTURE.Show();
                DELETE_BUTTON.Enabled = false;
                KEYBOARD_UUID_TEXTBOX.ReadOnly = true;
            }
        }
    }
}
