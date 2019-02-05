using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MultiBoard.overlays;

namespace MultiBoard
{

    public partial class Key : UserControl
    {
        //resouces
        //===============================
        Image TOGGLE_ON = Properties.Resources.TOGGLE_ON;
        Image TOGGLE_OFF = Properties.Resources.TOGGLE_OFF;

        //variables
        //===============================
        private bool OnKeyDownSelected = false;
        private bool OnKeyUpSelected = false;
        private bool OnKeyPressedSelected = false;

        private string keyName;
        private bool recordingKey = false;
        private bool enabled = true;
        private string KeyTag;
        private string ExecuteLocation;
        private string oldName;

        public List<string> nameAllKeys = new List<string>();

        //events
        //=========================
        public event EventHandler UpdatedData;
        public event EventHandler<objKeyEventArgs> DeleteKey;

        public Key()
        {
            InitializeComponent();
        }

        public void settings(string name ,int eventState, string key, bool enabledKey, string executeLoc)
        {
            keyName = name;
            oldName = keyName;
            KEY_NAME_TEXTBOX.Text = name;

            if(eventState == 1)
            {
                OnKeyDownSelected = true;
                OnKeyUpSelected = false;
                OnKeyPressedSelected = false;

                KEY_DOWN_P.BackColor = Color.DimGray;
                KEY_UP_P.BackColor = groupBox1.BackColor;
                KEY_PRESSED_p.BackColor = groupBox1.BackColor;
            }
            else if(eventState == 2)
            {
                OnKeyDownSelected = true;
                OnKeyUpSelected = false;
                OnKeyPressedSelected = false;

                KEY_DOWN_P.BackColor = groupBox1.BackColor;
                KEY_UP_P.BackColor = Color.DimGray;
                KEY_PRESSED_p.BackColor = groupBox1.BackColor;

            }
            else if(eventState == 3)
            {
                OnKeyDownSelected = false;
                OnKeyUpSelected = false;
                OnKeyPressedSelected = true;

                KEY_DOWN_P.BackColor = groupBox1.BackColor;
                KEY_UP_P.BackColor = groupBox1.BackColor;
                KEY_PRESSED_p.BackColor = Color.DimGray;

            }

            KEY_LABEL.Text = key;
            KeyTag = key;


            if (enabledKey != true)
            {
                enabled = false;
                ENABLE_BUTTON.BackgroundImage = TOGGLE_OFF;
            }
            else
            {
                enabled = true;
                ENABLE_BUTTON.BackgroundImage = TOGGLE_ON;
            }

            ExecuteLocation = executeLoc;
            LOCATION_TEXTBOX.Text = executeLoc;
        }

        private void keyDownClicked(object sender, EventArgs e)
        {
            OnKeyDownSelected = true;
            OnKeyUpSelected = false;
            OnKeyPressedSelected = false;

            KEY_DOWN_P.BackColor = Color.DimGray;
            KEY_UP_P.BackColor = groupBox1.BackColor;
            KEY_PRESSED_p.BackColor = groupBox1.BackColor;
        }

        private void keyUpClicked(object sender, EventArgs e)
        {
            OnKeyDownSelected = false;
            OnKeyUpSelected = true;
            OnKeyPressedSelected = false;

            KEY_DOWN_P.BackColor = groupBox1.BackColor;
            KEY_UP_P.BackColor = Color.DimGray;
            KEY_PRESSED_p.BackColor = groupBox1.BackColor;
        }

        private void keyPressedClicked(object sender, EventArgs e)
        {
            OnKeyDownSelected = false;
            OnKeyUpSelected = false;
            OnKeyPressedSelected = true;

            KEY_DOWN_P.BackColor = groupBox1.BackColor;
            KEY_UP_P.BackColor = groupBox1.BackColor;
            KEY_PRESSED_p.BackColor = Color.DimGray;
        }

        public void keyDown(string KEY, bool allEnebled)
        {
            if(recordingKey == true)
            {
                if (KEY_LABEL.InvokeRequired)
                {
                    KEY_LABEL.Invoke(new Action(() => { KEY_LABEL.Text = KEY; }));
                }
                else
                {
                    KEY_LABEL.Text = KEY;
                }

                KeyTag = KEY;
            }
            else
            {
                if(KeyTag == KEY && enabled == true && OnKeyDownSelected  && File.Exists(ExecuteLocation) && allEnebled)
                {
                    //execute
                    System.Diagnostics.Process.Start(ExecuteLocation);
                }
            }
        }

        public void keyUp(string KEY, bool allEnebled)
        {
            if (KeyTag == KEY && enabled == true && OnKeyUpSelected && File.Exists(ExecuteLocation) && allEnebled)
            {
                //execute
                System.Diagnostics.Process.Start(ExecuteLocation);
            }
        }

        private void StartRecordingClicked(object sender, EventArgs e)
        {
            if(recordingKey == true)
            {
                recordingKey = false;
                RECORD_KEY_BUTTON.Text = "Start recording";
                KEY_RECORD_PANEL.BackColor = groupBox1.BackColor;
            }
            else
            {
                recordingKey = true;
                RECORD_KEY_BUTTON.Text = "Stop recording";
                KEY_RECORD_PANEL.BackColor = Color.OrangeRed;
            }
        }

        private void ENABLE_BUTTON_CLICK(object sender, EventArgs e)
        {
            if(enabled == true)
            {
                enabled = false;
                ENABLE_BUTTON.BackgroundImage = TOGGLE_OFF;
            }
            else
            {
                enabled = true;
                ENABLE_BUTTON.BackgroundImage = TOGGLE_ON;
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
                            ExecuteLocation = theDialog.FileName;
                            LOCATION_TEXTBOX.Text = theDialog.FileName;

                            //save to "FileOpenLastLocation"
                            string[] splits = ExecuteLocation.Split(new string[] { @"\" }, StringSplitOptions.None);
                            string remove = splits[splits.Length - 1];
                            Properties.Settings.Default.FileOpen_LastLocation = ExecuteLocation.Split(new string[] { remove }, StringSplitOptions.None)[0];
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
            return keyName;
        }

        public int getEvent()
        {
            if(OnKeyDownSelected)
            {
                return 1;
            }
            else if(OnKeyUpSelected)
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
            return KeyTag;
        }

        public bool getEnebled()
        {
            return enabled;
        }

        public string getExecuteLocation()
        {
            return ExecuteLocation;
        }

        protected virtual void OnUpdatedData()
        {
            if(UpdatedData != null)
            {
                UpdatedData(this, EventArgs.Empty);
            }
        }

        private void DELETE_BUTTON_Click(object sender, EventArgs e)
        {
            OnDeleteKey();
        }

        private void SAVE_BUTTON_Click(object sender, EventArgs e)
        {
            if (checkKeyName(keyName))
            {
                KEY_NAME_TEXTBOX.BackColor = TOP_PANEL.BackColor;
                OnUpdatedData();

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

        protected virtual void OnDeleteKey()
        {
            DeleteKey(this, new objKeyEventArgs() { objKey = this });
        }

        private void KEY_NAME_TEXTBOX_TextChanged(object sender, EventArgs e)
        {
            keyName = KEY_NAME_TEXTBOX.Text;
        }

        private bool checkKeyName(string s)
        {
            return true;
        }

        private void KEY_RECORD_PANEL_Leave(object sender, EventArgs e)
        {
            recordingKey = false;
            RECORD_KEY_BUTTON.Text = "Start recording";
            KEY_RECORD_PANEL.BackColor = groupBox1.BackColor;
        }
    }

    public class objKeyEventArgs : EventArgs
    {
        public Key objKey { get; set; }
    }

    
}
