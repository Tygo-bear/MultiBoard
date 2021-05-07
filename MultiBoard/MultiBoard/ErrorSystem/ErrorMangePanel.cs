using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MultiBoardKeyboard;

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
            List<ErrorEvent> l = ErrorReport.ErrorEvents;
            

            //add to list view
            foreach(ErrorEvent s in l)
            {
                ERROR_LIST_LISTBOX.Items.Add( s.ToString());
            }

        }

        /// <summary>
        /// Remove all error messages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CLEAR_LIST_BUTTON_Click(object sender, EventArgs e)
        {
            ErrorReport.ClearEvents();

            updateErrorList();
        }

        private void RELOAD_LIST_BUTTON_Click(object sender, EventArgs e)
        {
            updateErrorList();
        }
    }
}
