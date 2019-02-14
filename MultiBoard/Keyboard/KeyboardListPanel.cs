using System;
using System.Drawing;
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
        private bool _infocus = false;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_infocus == true)
            {
                this.BackColor = Color.DarkGray;
                this.Location = new Point(this.Location.X + 4, this.Location.Y + 4);
                this.Size = new Size(this.Size.Width - 8, this.Size.Height - 8);
                timer1.Stop();
                _infocus = false;
            }
        }

        private void KeyboardListPanel_MouseEnter(object sender, EventArgs e)
        {
            this.timer1.Stop();
            if (_infocus == false)
            {
                this.BackColor = Color.CornflowerBlue;
                this.Location = new Point(this.Location.X - 4, this.Location.Y - 4);
                this.Size = new Size(this.Size.Width + 8, this.Size.Height + 8);
                _infocus = true;
            }
        }

        private void KeyboardListPanel_MouseLeave(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}
