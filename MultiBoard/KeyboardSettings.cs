using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard
{
    public partial class KeyboardSettings : UserControl
    {
        public string kbName;
        public string kbUUID;
        public string kbPort;

        public KeyboardSettings(string kname, string kId, string kCOM)
        {
            InitializeComponent();

            kbName = kname;
            kbUUID = kId;
            kbPort = kCOM;

            KEYBOARD_NAME_TEXTBOX.Text = kname;
            KEYBOARD_UUID_TEXTBOX.Text = kId;
            KEYBOARD_COMP_TEXTBOX.Text = kCOM;

        }

        public event EventHandler save;
        public event EventHandler delete;

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

        private bool CheckInput()
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
