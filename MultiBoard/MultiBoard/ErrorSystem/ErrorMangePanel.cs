using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard.ErrorSystem
{
    public partial class ErrorMangePanel : UserControl
    {

        public ErrorMangePanel()
        {
            InitializeComponent();
        }

        public void UpdateErrorList()
        {
            ERROR_LIST_LISTBOX.Items.Clear();
            string input = Properties.Settings.Default.ErrorList;
            List<string> l = input.Split(',').ToList();

            foreach(string s in l)
            {
                if (!String.IsNullOrEmpty(s))
                {
                    ERROR_LIST_LISTBOX.Items.Add(s);
                }
            }

        }

        private void CLEAR_LIST_BUTTON_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ErrorList = "";
            Properties.Settings.Default.Save();

            UpdateErrorList();
        }
    }
}
