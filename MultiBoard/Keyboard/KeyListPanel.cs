using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard.Keyboard
{
    public partial class KeyListPanel : UserControl
    {
        private bool stateEnebled;
        private string kName;
        private Key connectedKey;

        private Image normal_key = Properties.Resources.key;
        private Image dark_key = Properties.Resources.dark_key;

        public event EventHandler ClickedKey;

        public KeyListPanel(string name, bool state, ref Key cKey)
        {
            InitializeComponent();

            kName = name;
            KEY_NAME_LABEL.Text = name;
            setState(state);
            connectedKey = cKey;
        }

        public bool state_enebled
        {
            get
            {
                return stateEnebled;
            }
            set
            {
                setState(value);
            }
        }

        public string kname
        {
            get
            {
                return kName;
            }
            set
            {
                kName = value;
                KEY_NAME_LABEL.Text = value;
            }
        }

        public Key connected_key
        {
            get
            {
                return connectedKey;
            }
            set
            {
                connectedKey = value;
            }
        }

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
                stateEnebled = true;
                KEY_PICTURE.BackgroundImage = normal_key;
            }
            else
            {
                stateEnebled = false;
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
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray;
        }
    }
}
