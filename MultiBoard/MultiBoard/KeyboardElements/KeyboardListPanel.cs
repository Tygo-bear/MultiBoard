using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiBoard.KeyboardElements
{
    public partial class KeyboardListPanel : UserControl
    {
        //Events
        //===============
        public event EventHandler OpenBoardClicked;
        public event EventHandler BoardSettingsClicked;

        //Vars
        //================
        private string _keyboardName;
        private string _keyboardUuid;
        private string _keyboardPort;
        private bool _inFocus = false;
        private KeyBoard _connectedBoard;


        /// <summary>
        /// Setup settings of keyboard list panel
        /// </summary>
        /// <param name="name">
        /// The name of the keyboard
        /// </param>
        /// <param name="uuid">
        /// The dynamic id of the keyboard
        /// </param>
        /// <param name="port">
        /// The comport of the keyboard</param>
        /// <param name="board">
        /// The keyboard class it represents
        /// </param>
        public KeyboardListPanel(string name, string uuid, string port, KeyBoard board)
        {
            InitializeComponent();

            NAME_LABEL.Text = name;
            UUID_LABEL.Text = uuid;
            KeyboardName = name;
            _keyboardUuid = uuid;
            _keyboardPort = port;
            _connectedBoard = board;
        }

        /// <summary>
        /// The keyboard class that it represents
        /// </summary>
        public KeyBoard ConnectedBoard
        {
            get => _connectedBoard;
            set => _connectedBoard = value;
        }

        /// <summary>
        /// The name of the keyboard shown to the user
        /// </summary>
        public string KeyboardName
        {
            get => _keyboardName;
            set
            {
                _keyboardName = value;
                NAME_LABEL.Text = _keyboardName;
            }
        }

        /// <summary>
        /// The dynamic ID of the keyboard
        /// </summary>
        public string KeyboardUuid
        {
            get => _keyboardUuid;
            set
            {
                _keyboardUuid = value;
                UUID_LABEL.Text = _keyboardUuid;
            }
        }

        /// <summary>
        /// The com port of the keyboard
        /// </summary>
        public string KeyboardPort
        {
            get => _keyboardPort;
            set => _keyboardPort = value;
        }

        private void KeyboardListPanel_Click(object sender, EventArgs e)
        {
            //call event
            if(OpenBoardClicked != null)
            {
                OpenBoardClicked(this, e);
            }
        }

        private void SETTINGS_BUTTON_Click(object sender, EventArgs e)
        {
            //call event
            if(BoardSettingsClicked != null)
            {
                BoardSettingsClicked(this, e);
            }
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_inFocus == true)
            {
                this.BackColor = Color.DarkGray;
                this.Location = new Point(this.Location.X + 2, this.Location.Y + 2);
                this.Size = new Size(this.Size.Width - 4, this.Size.Height - 4);
                timer1.Stop();
                _inFocus = false;
            }
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardListPanel_MouseEnter(object sender, EventArgs e)
        {
            this.timer1.Stop();
            if (_inFocus == false)
            {
                this.BackColor = Color.CornflowerBlue;
                this.Location = new Point(this.Location.X - 2, this.Location.Y - 2);
                this.Size = new Size(this.Size.Width + 4, this.Size.Height + 4);
                _inFocus = true;
            }
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyboardListPanel_MouseLeave(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}
