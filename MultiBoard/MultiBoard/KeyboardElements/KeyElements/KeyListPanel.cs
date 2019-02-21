using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiBoard.Keyboard.KeyElements
{
    public partial class KeyListPanel : UserControl
    {
        private bool _stateEnebled;
        private bool _focus;
        private string _kName;
        private Key _connectedKey;

        private Image normal_key = Properties.Resources.key;
        private Image dark_key = Properties.Resources.dark_key;

        public event EventHandler ClickedKey;

        public KeyListPanel(string name, bool state, Key cKey)
        {
            InitializeComponent();

            _kName = name;
            KEY_NAME_LABEL.Text = name;
            setState(state);
            ConnectedKey = cKey;
            
        }

        public bool StateEnebled
        {
            get
            {
                return _stateEnebled;
            }
            set
            {
                setState(value);
            }
        }

        public string Kname
        {
            get
            {
                return _kName;
            }
            set
            {
                _kName = value;
                KEY_NAME_LABEL.Text = value;
            }
        }

        public Key connected_key
        {
            get
            {
                return ConnectedKey;
            }
            set
            {
                ConnectedKey = value;
            }
        }

        public Key ConnectedKey { get => _connectedKey; set => _connectedKey = value; }

        private void KeyListPanel_Click(object sender, EventArgs e)
        {
            if (ClickedKey != null)
            {
                ClickedKey(this, EventArgs.Empty);
            }
        }

        public void setState(bool state)
        {
            if(state == true)
            {
                _stateEnebled = true;
                KEY_PICTURE.BackgroundImage = normal_key;
            }
            else
            {
                _stateEnebled = false;
                KEY_PICTURE.BackgroundImage = dark_key;
            }
        }

        private void KeyListPanel_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(252, 163, 17);
            timer1.Stop();
        }

        private void KeyListPanel_MouseLeave(object sender, EventArgs e)
        {
            if (_focus == false)
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }

        public void inFocus(bool b)
        {
            if (b == true)
            {
                timer1.Stop();
                _focus = true;
            }
            else
            {
                timer1.Start();
                _focus = false;
            }
        }
    }
}
