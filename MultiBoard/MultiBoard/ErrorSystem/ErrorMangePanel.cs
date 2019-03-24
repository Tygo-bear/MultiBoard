using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MultiBoard.ErrorSystem
{
    public partial class ErrorMangePanel : UserControl
    {

        public ErrorMangePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the error list to latest
        /// </summary>
        public void updateErrorList()
        {
            //clear list
            ERROR_LIST_LISTBOX.Items.Clear();
            //Read settings
            string input = Properties.Settings.Default.ErrorList;
            List<string> l = input.Split(',').ToList();

            //add to list view
            foreach(string s in l)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    ERROR_LIST_LISTBOX.Items.Add(s);
                }
            }

        }

        /// <summary>
        /// Remove all error messages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CLEAR_LIST_BUTTON_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ErrorList = "";
            Properties.Settings.Default.Save();

            updateErrorList();
        }

        private void RELOAD_LIST_BUTTON_Click(object sender, EventArgs e)
        {
            updateErrorList();
        }
    }
}
