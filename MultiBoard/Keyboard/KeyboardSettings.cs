using System;
using System.Windows.Forms;

namespace MultiBoard.Keyboard
{
    public partial class KeyboardSettings : UserControl
    {
        public string KbName;
        public string KbUuid;
        public string KbPort;

        public KeyboardSettings(string kname, string kId, string kCom)
        {
            InitializeComponent();

            KbName = kname;
            KbUuid = kId;
            KbPort = kCom;

            KEYBOARD_NAME_TEXTBOX.Text = kname;
            KEYBOARD_UUID_TEXTBOX.Text = kId;
            KEYBOARD_COMP_TEXTBOX.Text = kCom;

        }

        public event EventHandler Save;
        public event EventHandler Delete;

        private void BACK_BUTTON_Click(object sender, EventArgs e)
        {
            //back/close
            this.Dispose();
        }

        private void DELETE_BUTTON_Click(object sender, EventArgs e)
        {
            //delete
        }

        private void SAVE_BUTTON_Click(object sender, EventArgs e)
        {
            //save
        }

        private bool checkInput()
        {
            if(KEYBOARD_COMP_TEXTBOX.Text != "" && KEYBOARD_UUID_TEXTBOX.Text != "" 
                && KEYBOARD_NAME_TEXTBOX.Text != "")
            {
                //TODO make better
                return true;
            }
            return false;
        }
    }
}
