using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MultiBoard.overlays;
using MultiBoardKeyboard;

namespace MultiBoard.KeyboardElements.KeyElements
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

        //user controls
        //=======================
        private SelectKeyTaskOverlay _keyTaskOverlay;
        private HotKeyCreator _hotKeyCreatorOverlay;

        //events
        //=========================
        public event EventHandler UpdatedData;
        public event EventHandler<ObjKeyEventArgs> DeleteKey;

        public KeyGui()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The settings of the key GUI
        /// </summary>
        /// <param name="name">
        /// Uuid of the key
        /// </param>
        /// <param name="eventState">
        /// Event state of the key
        /// </param>
        /// <param name="key">
        /// The key code
        /// </param>
        /// <param name="enabledKey">
        /// Is the key enabled
        /// </param>
        /// <param name="executeLoc">
        /// The task of the key
        /// </param>
        /// <param name="connectKey">
        /// the reference to the key class
        /// </param>
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
                KEY_UP_P.BackColor = EVENT_PANEL.BackColor;
                KEY_PRESSED_p.BackColor = EVENT_PANEL.BackColor;
            }
            else if(eventState == 2)
            {
                _onKeyDownSelected = true;
                _onKeyUpSelected = false;
                _onKeyPressedSelected = false;

                KEY_DOWN_P.BackColor = EVENT_PANEL.BackColor;
                KEY_UP_P.BackColor = Color.DimGray;
                KEY_PRESSED_p.BackColor = EVENT_PANEL.BackColor;

            }
            else if(eventState == 3)
            {
                _onKeyDownSelected = false;
                _onKeyUpSelected = false;
                _onKeyPressedSelected = true;

                KEY_DOWN_P.BackColor = EVENT_PANEL.BackColor;
                KEY_UP_P.BackColor = EVENT_PANEL.BackColor;
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

        /// <summary>
        /// When key down event state is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyDownClicked(object sender, EventArgs e)
        {
            _onKeyDownSelected = true;
            _onKeyUpSelected = false;
            _onKeyPressedSelected = false;

            KEY_DOWN_P.BackColor = Color.DimGray;
            KEY_UP_P.BackColor = EVENT_PANEL.BackColor;
            KEY_PRESSED_p.BackColor = EVENT_PANEL.BackColor;
        }

        /// <summary>
        /// When key up event state is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyUpClicked(object sender, EventArgs e)
        {
            _onKeyDownSelected = false;
            _onKeyUpSelected = true;
            _onKeyPressedSelected = false;

            KEY_DOWN_P.BackColor = EVENT_PANEL.BackColor;
            KEY_UP_P.BackColor = Color.DimGray;
            KEY_PRESSED_p.BackColor = EVENT_PANEL.BackColor;
        }

        /// <summary>
        /// when key pressed event state is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyPressedClicked(object sender, EventArgs e)
        {
            _onKeyDownSelected = false;
            _onKeyUpSelected = false;
            _onKeyPressedSelected = true;

            KEY_DOWN_P.BackColor = EVENT_PANEL.BackColor;
            KEY_UP_P.BackColor = EVENT_PANEL.BackColor;
            KEY_PRESSED_p.BackColor = Color.DimGray;
        }

        /// <summary>
        /// Key down event for key recording
        /// </summary>
        /// <param name="key">
        /// key code
        /// </param>
        /// <param name="allEnebled">
        /// Is key allowed to run
        /// </param>
        public void keyDown(string key)
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
        }

        /// <summary>
        /// When key recording is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startRecordingClicked(object sender, EventArgs e)
        {
            if(_recordingKey == true)
            {
                _recordingKey = false;
                RECORD_KEY_BUTTON.Text = "Start recording";
                KEY_RECORD_PANEL.BackColor = EVENT_PANEL.BackColor;
            }
            else
            {
                _recordingKey = true;
                RECORD_KEY_BUTTON.Text = "Stop recording";
                KEY_RECORD_PANEL.BackColor = Color.OrangeRed;
            }
        }

        /// <summary>
        /// Enable key button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Open file button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        public string KeyName => _keyName;

        public int EventState
        {
            get
            {
                if (_onKeyDownSelected)
                {
                    return 1;
                }
                else if (_onKeyUpSelected)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
        }

        public string KeyTag => _keyTag;

        public bool KeyEnebled => _enabled;

        public string ExecuteLocation => _executeLocation;

        /// <summary>
        /// Event for when data updated
        /// </summary>
        protected virtual void onUpdatedData()
        {
            if(UpdatedData != null)
            {
                UpdatedData(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Key delete button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DELETE_BUTTON_Click(object sender, EventArgs e)
        {
            onDeleteKey();
        }

        /// <summary>
        /// Save button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SAVE_BUTTON_Click(object sender, EventArgs e)
        {
            KEY_NAME_TEXTBOX.BackColor = TOP_PANEL.BackColor;

            _connectedKey.key_name = _keyName;
            _connectedKey.keyEnebled = _enabled;
            _connectedKey.EventState = EventState;
            _connectedKey.executeLoc = _executeLocation;
            _connectedKey.keyTag = _keyTag;

            onUpdatedData();

            SavedOverlay ol = new SavedOverlay();
            ol.Location = new Point(0, 0);
            this.Controls.Add(ol);
            ol.BringToFront();

        }

        /// <summary>
        /// Event for key delete request
        /// </summary>
        protected virtual void onDeleteKey()
        {
            if (DeleteKey != null) DeleteKey(this, new ObjKeyEventArgs() {ObjKey = _connectedKey});
        }

        private void KEY_NAME_TEXTBOX_TextChanged(object sender, EventArgs e)
        {
            _keyName = KEY_NAME_TEXTBOX.Text;
        }
        
        /// <summary>
        /// Stop recording when focus lost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KEY_RECORD_PANEL_Leave(object sender, EventArgs e)
        {
            _recordingKey = false;
            RECORD_KEY_BUTTON.Text = "Start recording";
            KEY_RECORD_PANEL.BackColor = EVENT_PANEL.BackColor;
        }

        private void KEY_TASK_BUTTON_Click(object sender, EventArgs e)
        {
            createKeyTaskOverlay();
        }

        /// <summary>
        /// Create KeyTaskOverlay for advanced settings
        /// </summary>
        private void createKeyTaskOverlay()
        {
            _keyTaskOverlay = new SelectKeyTaskOverlay();
            _keyTaskOverlay.UserMadeSelection += keyTaskOverlayOnUserMadeSelection;
            _keyTaskOverlay.Location = new Point((Width/2)-(_keyTaskOverlay.Width/2), (Height/2)-(_keyTaskOverlay.Height/2));
            Controls.Add(_keyTaskOverlay);
            _keyTaskOverlay.Show();
            _keyTaskOverlay.BringToFront();
        }

        private void createHotkeyCreatorOverlay()
        {
            _hotKeyCreatorOverlay = new HotKeyCreator();
            _hotKeyCreatorOverlay.UserMadeSelection += HotKeyCreatorOverlayOnUserMadeSelection;
            _hotKeyCreatorOverlay.Location = new Point((Width / 2) - (_hotKeyCreatorOverlay.Width / 2), (Height / 2) - (_hotKeyCreatorOverlay.Height / 2));
            this.Controls.Add(_hotKeyCreatorOverlay);
            _hotKeyCreatorOverlay.Show();
            _hotKeyCreatorOverlay.BringToFront();
        }

        private void HotKeyCreatorOverlayOnUserMadeSelection(object sender, string e)
        {
            _executeLocation = e;
            LOCATION_TEXTBOX.Text = e;
        }

        /// <summary>
        /// Collect data input and dispose overlay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyTaskOverlayOnUserMadeSelection(object sender, EventArgs e)
        {
            string s = "<" + _keyTaskOverlay.SelectedKey + ">";
            _executeLocation = s;
            LOCATION_TEXTBOX.Text = s;
            _keyTaskOverlay.Dispose();
        }

        /// <summary>
        /// User clicked autoHotKey button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AHK_BUTTON_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Select autohotkey script";
            theDialog.Filter = "AutoHotKey script|*.ahk";
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
                            string loc = "?" + theDialog.FileName + "?";
                            _executeLocation = loc;
                            LOCATION_TEXTBOX.Text = loc;

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

        private void HOT_KEY_BUTTON_Click(object sender, EventArgs e)
        {
            createHotkeyCreatorOverlay();
        }
    }

    /// <summary>
    /// Give key class reference as event argument
    /// </summary>
    public class ObjKeyEventArgs : EventArgs
    {
        public Key ObjKey { get; set; }
    }

    
}
