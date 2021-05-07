using System;
using System.Drawing;
using System.Windows.Forms;
using MultiBoardKeyboard;

namespace MultiBoard.KeyboardElements.KeyElements
{
    public partial class KeyListPanel : UserControl
    {
        private bool _stateEnabled;
        private bool _focus;
        private string _keyName;
        private Key _connectedKey;

        private Image _normalKey = Properties.Resources.key;
        private Image _darkKey = Properties.Resources.dark_key;

        public event EventHandler ClickedKey;

        /// <summary>
        /// Create a key panel for key list
        /// </summary>
        /// <param name="name">
        /// Uuid of the key
        /// </param>
        /// <param name="state">
        /// Is the key enabled
        /// </param>
        /// <param name="cKey">
        /// Reference to key class
        /// </param>
        public KeyListPanel(string name, bool state, Key cKey)
        {
            InitializeComponent();

            _keyName = name;
            KEY_NAME_LABEL.Text = name;
            KeyEnabledState = state;
            ConnectedKey = cKey;
            
        }

        /// <summary>
        /// Is the key enabled
        /// </summary>
        public bool StateEnabled
        {
            get => _stateEnabled;
            set => KeyEnabledState = value;
        }

        /// <summary>
        /// Uuid of the key shown to the user
        /// </summary>
        public string KeyName
        {
            get => _keyName;
            set
            {
                _keyName = value;
                KEY_NAME_LABEL.Text = value;
            }
        }

        /// <summary>
        /// reference to the key class it represents
        /// </summary>
        public Key ConnectedKey { get => _connectedKey; set => _connectedKey = value; }

        /// <summary>
        /// Send event when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyListPanel_Click(object sender, EventArgs e)
        {
            if (ClickedKey != null)
            {
                ClickedKey(this, EventArgs.Empty);
            }
        }
        
        /// <summary>
        /// The enabled state of key
        /// </summary>
        public bool KeyEnabledState
        {
            set
            {
                if (value == true)
                {
                    _stateEnabled = true;
                    KEY_PICTURE.BackgroundImage = _normalKey;
                }
                else
                {
                    _stateEnabled = false;
                    KEY_PICTURE.BackgroundImage = _darkKey;
                }
            }
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyListPanel_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(252, 163, 17);
            timer1.Stop();
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyListPanel_MouseLeave(object sender, EventArgs e)
        {
            if (_focus == false)
            {
                timer1.Start();
            }
        }

        /// <summary>
        /// Hover effect delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="b"></param>
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
