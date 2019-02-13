using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MultiBoard.overlays;

namespace MultiBoard.Keyboard.KeyElements
{

    public partial class KeyGui : UserControl
    {
        //resouces
        //===============================
        Image _toggleOn = Properties.Resources.TOGGLE_ON;
        Image _toggleOff = Properties.Resources.TOGGLE_OFF;

        //variables
        //===============================
        private bool _onKeyDownSelected = false;
        private bool _onKeyUpSelected = false;
        private bool _onKeyPressedSelected = false;

        private string _keyName;
        private bool _recordingKey = false;
        private bool _enabled = true;
        private string _keyTag;
        private string _executeLocation;
        private Key _connectedKey;

        private string _oldName;

        public List<string> NameAllKeys = new List<string>();

        //events
        //=========================
        public event EventHandler UpdatedData;
        public event EventHandler<ObjKeyEventArgs> DeleteKey;

        public KeyGui()
        {
            InitializeComponent();
        }

        public void settings(string name ,int eventState, string key, bool enabledKey, string executeLoc, Key connectKey)
        {
            _keyName = name;
            _oldName = _keyName;
            KEY_NAME_TEXTBOX.Text = name;
            _connectedKey = connectKey;

            if(eventState == 1)
            {
                _onKeyDownSelected = true;
                _onKeyUpSelected = false;
                _onKeyPressedSelected = false;

                KEY_DOWN_P.BackColor = Color.DimGray;
                KEY_UP_P.BackColor = groupBox1.BackColor;
                KEY_PRESSED_p.BackColor = groupBox1.BackColor;
            }
            else if(eventState == 2)
            {
                _onKeyDownSelected = true;
                _onKeyUpSelected = false;
                _onKeyPressedSelected = false;

                KEY_DOWN_P.BackColor = groupBox1.BackColor;
                KEY_UP_P.BackColor = Color.DimGray;
                KEY_PRESSED_p.BackColor = groupBox1.BackColor;

            }
            else if(eventState == 3)
            {
                _onKeyDownSelected = false;
                _onKeyUpSelected = false;
                _onKeyPressedSelected = true;

                KEY_DOWN_P.BackColor = groupBox1.BackColor;
                KEY_UP_P.BackColor = groupBox1.BackColor;
                KEY_PRESSED_p.BackColor = Color.DimGray;

            }

            KEY_LABEL.Text = key;
            _keyTag = key;


            if (enabledKey != true)
            {
                _enabled = false;
                ENABLE_BUTTON.BackgroundImage = _toggleOff;
            }
            else
            {
                _enabled = true;
                ENABLE_BUTTON.BackgroundImage = _toggleOn;
            }

            _executeLocation = executeLoc;
            LOCATION_TEXTBOX.Text = executeLoc;
        }

        private void keyDownClicked(object sender, EventArgs e)
        {
            _onKeyDownSelected = true;
            _onKeyUpSelected = false;
            _onKeyPressedSelected = false;

            KEY_DOWN_P.BackColor = Color.DimGray;
            KEY_UP_P.BackColor = groupBox1.BackColor;
            KEY_PRESSED_p.BackColor = groupBox1.BackColor;
        }

        private void keyUpClicked(object sender, EventArgs e)
        {
            _onKeyDownSelected = false;
            _onKeyUpSelected = true;
            _onKeyPressedSelected = false;

            KEY_DOWN_P.BackColor = groupBox1.BackColor;
            KEY_UP_P.BackColor = Color.DimGray;
            KEY_PRESSED_p.BackColor = groupBox1.BackColor;
        }

        private void keyPressedClicked(object sender, EventArgs e)
        {
            _onKeyDownSelected = false;
            _onKeyUpSelected = false;
            _onKeyPressedSelected = true;

            KEY_DOWN_P.BackColor = groupBox1.BackColor;
            KEY_UP_P.BackColor = groupBox1.BackColor;
            KEY_PRESSED_p.BackColor = Color.DimGray;
        }

        public void keyDown(string key, bool allEnebled)
        {
            if(_recordingKey == true)
            {
                if (KEY_LABEL.InvokeRequired)
                {
                    KEY_LABEL.Invoke(new Action(() => { KEY_LABEL.Text = key; }));
                }
                else
                {
                    KEY_LABEL.Text = key;
                }

                _keyTag = key;
            }
            else
            {
                if(_keyTag == key && _enabled == true && _onKeyDownSelected  && File.Exists(_executeLocation) && allEnebled)
                {
                    //execute
                    System.Diagnostics.Process.Start(_executeLocation);
                }
            }
        }

        public void keyUp(string key, bool allEnebled)
        {
            if (_keyTag == key && _enabled == true && _onKeyUpSelected && File.Exists(_executeLocation) && allEnebled)
            {
                //execute
                System.Diagnostics.Process.Start(_executeLocation);
            }
        }

        private void startRecordingClicked(object sender, EventArgs e)
        {
            if(_recordingKey == true)
            {
                _recordingKey = false;
                RECORD_KEY_BUTTON.Text = "Start recording";
                KEY_RECORD_PANEL.BackColor = groupBox1.BackColor;
            }
            else
            {
                _recordingKey = true;
                RECORD_KEY_BUTTON.Text = "Stop recording";
                KEY_RECORD_PANEL.BackColor = Color.OrangeRed;
            }
        }

        private void ENABLE_BUTTON_CLICK(object sender, EventArgs e)
        {
            if(_enabled == true)
            {
                _enabled = false;
                ENABLE_BUTTON.BackgroundImage = _toggleOff;
            }
            else
            {
                _enabled = true;
                ENABLE_BUTTON.BackgroundImage = _toggleOn;
            }
        }

        private void OPEN_FILE_CLICKED(object sender, EventArgs e)
        {

            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open file on key event";
            theDialog.Filter = "All files|*.*";
            theDialog.InitialDirectory = Properties.Settings.Default.FileOpen_LastLocation;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            //file exists
                            _executeLocation = theDialog.FileName;
                            LOCATION_TEXTBOX.Text = theDialog.FileName;

                            //save to "FileOpenLastLocation"
                            string[] splits = _executeLocation.Split(new string[] { @"\" }, StringSplitOptions.None);
                            string remove = splits[splits.Length - 1];
                            Properties.Settings.Default.FileOpen_LastLocation = _executeLocation.Split(new string[] { remove }, StringSplitOptions.None)[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public string getName()
        {
            return _keyName;
        }

        public int getEvent()
        {
            if(_onKeyDownSelected)
            {
                return 1;
            }
            else if(_onKeyUpSelected)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public string getKeytag()
        {
            return _keyTag;
        }

        public bool getEnebled()
        {
            return _enabled;
        }

        public string getExecuteLocation()
        {
            return _executeLocation;
        }

        protected virtual void onUpdatedData()
        {
            if(UpdatedData != null)
            {
                UpdatedData(this, EventArgs.Empty);
            }
        }

        private void DELETE_BUTTON_Click(object sender, EventArgs e)
        {
            onDeleteKey();
        }

        private void SAVE_BUTTON_Click(object sender, EventArgs e)
        {
            if (checkKeyName(_keyName))
            {
                KEY_NAME_TEXTBOX.BackColor = TOP_PANEL.BackColor;

                _connectedKey.key_name = _keyName;
                _connectedKey.keyEnebled = _enabled;
                _connectedKey.EventState = getEvent();
                _connectedKey.executeLoc = _executeLocation;
                _connectedKey.keyTag = _keyTag;

                onUpdatedData();

                SavedOverlay ol = new SavedOverlay();
                ol.Location = new Point(0, 0);
                this.Controls.Add(ol);
                ol.BringToFront();

                
            }
            else
            {
                KEY_NAME_TEXTBOX.BackColor = Color.Red;
            }
        }

        protected virtual void onDeleteKey()
        {
            if (DeleteKey != null) DeleteKey(this, new ObjKeyEventArgs() {ObjKey = _connectedKey});
        }

        private void KEY_NAME_TEXTBOX_TextChanged(object sender, EventArgs e)
        {
            _keyName = KEY_NAME_TEXTBOX.Text;
        }

        private bool checkKeyName(string s)
        {
            return true;
        }

        private void KEY_RECORD_PANEL_Leave(object sender, EventArgs e)
        {
            _recordingKey = false;
            RECORD_KEY_BUTTON.Text = "Start recording";
            KEY_RECORD_PANEL.BackColor = groupBox1.BackColor;
        }
    }

    public class ObjKeyEventArgs : EventArgs
    {
        public Key ObjKey { get; set; }
    }

    
}
