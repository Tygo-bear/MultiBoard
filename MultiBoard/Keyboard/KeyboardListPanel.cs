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
    public partial class KeyboardListPanel : UserControl
    {

        public KeyboardListPanel(string name, string uuid, string port)
        {
            InitializeComponent();

            NAME_LABEL.Text = name;
            UUID_LABEL.Text = uuid;
            kbname = name;
            kbUUID = uuid;
            kbPort = port;
        }

        public event EventHandler OpenBoardClicked;
        public event EventHandler BoardSettingsClicked;


        private string kbName;
        private string kbUUID;
        private string kbPort;

        public string kbname
        {
            get
            {
                return kbName;
            }
            set
            {
                kbName = value;
                NAME_LABEL.Text = kbName;
            }
        }

        public string kbuuid
        {
            get
            {
                return kbUUID;
            }
            set
            {
                kbUUID = value;
                UUID_LABEL.Text = kbUUID;
            }
        }

        public string kbport
        {
            get
            {
                return kbPort;
            }
            set
            {
                kbPort = value;
            }
        }

        private void KeyboardListPanel_Click(object sender, EventArgs e)
        {
            if(OpenBoardClicked != null)
            {
                OpenBoardClicked(this, e);
            }
        }

        private void SETTINGS_BUTTON_Click(object sender, EventArgs e)
        {
            if(BoardSettingsClicked != null)
            {
                BoardSettingsClicked(this, e);
            }
        }
    }
}
