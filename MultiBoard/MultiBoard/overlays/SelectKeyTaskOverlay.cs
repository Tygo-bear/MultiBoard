using System;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class SelectKeyTaskOverlay : UserControl
    {
        //Events
        //===============
        public event EventHandler UserMadeSelection;

        //Vars
        //==============
        public string SelectedKey = "";

        public SelectKeyTaskOverlay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// User clicked "OK" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OK_BUTTON_Click(object sender, EventArgs e)
        {
            string selection = getSelection();
            if (String.IsNullOrEmpty(selection))
            {
                //error
            }
            else
            {
                SelectedKey = selection;

                if (UserMadeSelection != null)
                {
                    UserMadeSelection(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// User clicked "close" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CLOSE_B_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OnCheckRadioButton(object sender, EventArgs e)
        {
            F_KEYS_RADIOBUTTON.Checked = false;
            NORML_KEY_RADUIBUTTON.Checked = false;
            UND_KEY_RADIOBUTTON.Checked = false;

            var b = sender as RadioButton;
            b.Checked = true;
        }

        private string getSelection()
        {
            if (F_KEYS_RADIOBUTTON.Checked == true)
            {
                return F_KEY_COMBOBOX.Text;
            }

            if (NORML_KEY_RADUIBUTTON.Checked == true)
            {
                return NORMAL_COMBOBOX.Text;
            }
            else
            {
                return UND_COMBOBOX.Text;
            }
        }
    }
}
