using System;
using System.Windows.Forms;

namespace MultiBoard.Keyboard
{
    public partial class KeyboardListPanel : UserControl
    {

        public KeyboardListPanel(string name, string uuid, string port)
        {
            InitializeComponent();

            NAME_LABEL.Text = name;
            UUID_LABEL.Text = uuid;
            KbName = name;
            _kbUuid = uuid;
            _kbPort = port;
        }

        public event EventHandler OpenBoardClicked;
        public event EventHandler BoardSettingsClicked;


        private string _kbName;
        private string _kbUuid;
        private string _kbPort;

        public string KbName
        {
            get
            {
                return _kbName;
            }
            set
            {
                _kbName = value;
                NAME_LABEL.Text = _kbName;
            }
        }

        public string KbUuid
        {
            get
            {
                return _kbUuid;
            }
            set
            {
                _kbUuid = value;
                UUID_LABEL.Text = _kbUuid;
            }
        }

        public string KbPort
        {
            get
            {
                return _kbPort;
            }
            set
            {
                _kbPort = value;
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
