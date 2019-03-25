using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MultiBoard.add_keyboard
{
    public partial class AutoAddKeyboard : UserControl
    {
        //Events
        //==============
        public event EventHandler AddClicked;

        //Vars
        //=============
        public List<string> IDs;
        public List<string> Ports;

        public string KeyboardName;
        public string KeyboardUuid;
        public string KeyboardPort;


        public AutoAddKeyboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load list of available keyboards into combobox
        /// </summary>
        public void loadKbList()
        {
            SELECT_KEYBOARD_COMBOX.Items.Clear();

            foreach(string s in IDs)
            {
                SELECT_KEYBOARD_COMBOX.Items.Add(s);
            }
        }

        /// <summary>
        /// User clicked "back" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BACK_BUTTON_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// User clicked "ADD" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ADD_BUTTON_Click(object sender, EventArgs e)
        {
            if(checkName(NAME_TEXT_BOX.Text))
            {
                //add keyboard to list
                KeyboardName = NAME_TEXT_BOX.Text;
                KeyboardUuid = SELECT_KEYBOARD_COMBOX.SelectedItem.ToString();
                onAddClicked();

                //Close "autoAddKeyboard" control
                this.Dispose();
            }
            else
            {
                //invalid name;
            }
        }

        /// <summary>
        /// Check keyboard name
        /// </summary>
        /// <param name="name">
        /// Name of the keyboard
        /// </param>
        /// <returns>
        /// true = valid name
        /// false = invalid name
        /// </returns>
        private bool checkName(string name)
        {
            //TODO make it better
            if(string.IsNullOrEmpty(name))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Call add keyboard clicked event
        /// </summary>
        protected virtual void onAddClicked()
        {
            if (AddClicked != null)
            {
                AddClicked(this, EventArgs.Empty);
            }
        }
    }
}
