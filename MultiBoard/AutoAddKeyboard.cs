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
    public partial class AutoAddKeyboard : UserControl
    {
        public List<string> IDs;
        public List<string> Ports;

        public string kbName;
        public string kbUUID;
        public string kbPort;

        public event EventHandler AddClicked;

        public AutoAddKeyboard()
        {
            InitializeComponent();
        }

        public void loadKbList()
        {
            SELECT_KEYBOARD_COMBOX.Items.Clear();

            foreach(string s in IDs)
            {
                SELECT_KEYBOARD_COMBOX.Items.Add(s);
            }
        }

        private void BAKC_BUTTON_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ADD_BUTTON_Click(object sender, EventArgs e)
        {
            if(checkName(NAME_TEXT_BOX.Text))
            {
                //add keyboard to list
                kbName = NAME_TEXT_BOX.Text;
                kbUUID = SELECT_KEYBOARD_COMBOX.SelectedItem.ToString();
                OnAddClicked();
                this.Dispose();
            }
            else
            {
                //invalid name;
            }
        }

        private bool checkName(string NAME)
        {
            //TODO make it better
            if(NAME == "" || NAME == null)
            {
                return false;
            }

            return true;
        }

        protected virtual void OnAddClicked()
        {
            if (AddClicked != null)
            {
                AddClicked(this, EventArgs.Empty);
            }
        }
    }
}
