using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MultiBoard.KeyboardElements.KeyElements;
using MultiBoardKeyboard;

namespace MultiBoard.KeyboardElements
{
    public partial class KeyBoardGUI : UserControl
    {
        //Vars
        //=============
        private bool _search = false;

        private string _saveFile;
        private KeyGui _keyGui = new KeyGui();

        private Keyboard _keyboard;

        private List<KeyListPanel> _keyPanelList = new List<KeyListPanel>();
        private Point _nextKeyListPoint = new Point(3, 3);

        /// <summary>
        /// Initialize all elements
        /// </summary>
        public KeyBoardGUI(Keyboard keyboard)
        {
            InitializeComponent();
            _keyboard = keyboard;
            KeyboardUuid = _keyboard.KeyboardUuid;
            KeyboardName = _keyboard.KeyboardName;

            _keyGui.UpdatedData += onUpdatedKey;
            _keyGui.DeleteKey += onDeleteKey;

            MAIN_PANEL.Controls.Add(_keyGui);
            _keyGui.Dock = DockStyle.Fill;
            _keyGui.Hide();

            _keyboard.ReceivedKeyUp += KeyboardOnReceivedKeyUp;
            _keyboard.ReceivedKeyDown += KeyboardOnReceivedKeyDown;
        }

        public Keyboard Keyboard
        {
            get { return _keyboard; }
        }

        private void KeyboardOnReceivedKeyDown(object sender, string e)
        {
            keyDown(e);
        }

        private void KeyboardOnReceivedKeyUp(object sender, string e)
        {
            
        }

        /// <summary>
        /// Create a new key
        /// </summary>
        /// <param name="keyName">
        /// Uuid of the key
        /// </param>
        /// <param name="eventState">
        /// The event on which the key reacts
        /// </param>
        /// <param name="keyTag">
        /// The key code
        /// </param>
        /// <param name="keyEnabled">
        /// Is the key enabled
        /// </param>
        /// <param name="exeLoc">
        /// The task of the key (open file/press key)
        /// </param>
        /// <returns>
        /// Return the generated class
        /// </returns>
        public Key createKey(string keyName, int eventState, string keyTag, bool keyEnabled, string exeLoc)
        {
            KEYLIST_PANEL.BackgroundImage = null;

            Key obj = new Key(keyName, eventState, keyTag, keyEnabled, exeLoc);

            _keyboard.AddKey(obj);

            return obj;
        }

        /// <summary>
        /// User clicked "Add new key" control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewKeyClicked(object sender, EventArgs e)
        {
            //generate name
            var keyName = "KEY " + (_keyboard.NumberOfKeys);

            //regenerate new key until valid
            while (!_keyboard.CheckNameAvailable(keyName))
            {
                _keyboard.NumberOfKeys++;
                keyName = "KEY " + (_keyboard.NumberOfKeys);
            }

            //Create the key
            Key k = createKey(keyName, 1, "NONE", true, "");
            _keyGui.settings(keyName, 1, "NONE", true, "", k);

            addKeyToListView(k);
            _keyboard.UpdateKeyNameList();

            _keyGui.Show();
        }

        /// <summary>
        /// Uuid of the keyboard shown to the user
        /// </summary>
        public string KeyboardName
        {
            set
            {
                _keyboard.KeyboardName = value;
                NAME_LABEL.Text = _keyboard.KeyboardName;
            }
            get => _keyboard.KeyboardName;
        }

        /// <summary>
        /// Dynamic id of the keyboard
        /// </summary>
        public string KeyboardUuid
        {
            set => _keyboard.KeyboardUuid = value;
            get => _keyboard.KeyboardUuid;
        }

        /// <summary>
        /// Com port of the keyboard
        /// </summary>
        public string ComPort
        {
            set => _keyboard.KeyboardComPort = value;
            get => _keyboard.KeyboardComPort;
        }

        /// <summary>
        /// Load the keys into the keyboard class
        /// </summary>
        /// <param name="mainDirectory">
        /// The main directory of the program
        /// </param>
        public void loadKeys(string mainDirectory)
        {

            //check for file exist
            if(!File.Exists(mainDirectory + @"\" + _keyboard.KeyboardUuid + ".inf"))
            {
                File.Create(mainDirectory + @"\" + _keyboard.KeyboardUuid + ".inf").Close();
            }

            _saveFile = mainDirectory + @"\" + _keyboard.KeyboardUuid + ".inf";

            //read keys
            //============================
            System.IO.StreamReader file =
                new System.IO.StreamReader(mainDirectory + @"\" + _keyboard.KeyboardUuid + ".inf");
            string all = file.ReadToEnd();
            _keyboard.loadKeys(all);

            if (_keyboard.KeyboardKeyList.Count > 0)
            {
                Key k = _keyboard.KeyboardKeyList[0];
                KEYLIST_PANEL.BackgroundImage = null;
                _keyGui.settings(k.key_name, k.EventState, k.keyTag, k.keyEnebled, k.executeLoc, k);
                _keyGui.Show();
            }

            file.Close();
            loadListView();
        }

        /// <summary>
        /// Key down event
        /// </summary>
        /// <param name="key">
        /// Key code
        /// </param>
        /// <param name="keyboardUuid">
        /// dynamic id of the keyboard
        /// </param>
        /// <param name="allEnabled">
        /// Is key allowed to run
        /// </param>
        public void keyDown(string key)
        {
            //send to GUI components
            _keyGui.keyDown(key);
            if (_search == true)
            {
                this.Invoke(new Action(() =>
                    SEARCH_TEXTBOC.Text = key));
            }

        }


        /// <summary>
        /// Load the key list
        /// </summary>
        public void loadListView()
        {

            clearKeyList();

            _nextKeyListPoint.X = 5;
            _nextKeyListPoint.Y = 3;

            for(int i = 0; i < _keyboard.KeyboardKeyList.Count; i++)
            {
                Key aKey = _keyboard.KeyboardKeyList[i];

                KeyListPanel item = new KeyListPanel(aKey.key_name, aKey.keyEnebled, aKey);

                item.Location = _nextKeyListPoint;
                _nextKeyListPoint.Y = _nextKeyListPoint.Y + item.Height + 5;
                item.ClickedKey += userSelectedKey;

                KEYLIST_PANEL.Controls.Add(item);
                item.BringToFront();

                _keyPanelList.Add(item);
            }

        }

        /// <summary>
        /// Draw list of keys
        /// </summary>
        /// <param name="lp">
        /// List of key panels to show
        /// </param>
        public void drawListView(List<KeyListPanel> lp)
        {
            foreach(KeyListPanel k in _keyPanelList)
            {
                k.Hide();
            }

            _nextKeyListPoint.X = 5;
            _nextKeyListPoint.Y = 3;

            foreach (KeyListPanel k in lp)
            {
                k.Location = _nextKeyListPoint;
                _nextKeyListPoint.Y = _nextKeyListPoint.Y + k.Height + 5;
                k.Show();
            }
        }

        /// <summary>
        /// Add a key to the end of the list (GUI)
        /// </summary>
        /// <param name="k">
        /// The key class to add to the list
        /// </param>
        public void addKeyToListView(Key k)
        {
            //create a panel for the key
            KeyListPanel item = new KeyListPanel(k.key_name, k.keyEnebled, k);

            if (_keyPanelList.Count == 0)
            {
                item.Location = _nextKeyListPoint;
            }
            else
            {
                item.Location = new Point(5, _keyPanelList[_keyPanelList.Count - 1].Location.Y + item.Height + 5);
            }

            _nextKeyListPoint.Y = _nextKeyListPoint.Y + item.Height + 5;
            item.ClickedKey += userSelectedKey;

            KEYLIST_PANEL.Controls.Add(item);
            item.BringToFront();

            _keyPanelList.Add(item);
            _keyboard.UpdateKeyNameList();
        }

        /// <summary>
        /// Reload the settings of the keyListPanels to match to new ones
        /// </summary>
        public void updateListView()
        {
            foreach(KeyListPanel klp in _keyPanelList)
            {
                Key k = klp.ConnectedKey;
                klp.KeyName = k.key_name;
                klp.KeyEnabledState = k.keyEnebled;
            }

            _keyboard.UpdateKeyNameList();
        }

        /// <summary>
        /// User clicked on key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userSelectedKey(object sender, EventArgs e)
        {
            KeyListPanel k = sender as KeyListPanel;

            foreach (KeyListPanel p in _keyPanelList)
            {
                p.inFocus(false);
            }
            k.inFocus(true);

            foreach(Key aKey in _keyboard.KeyboardKeyList)
            {
                if(aKey == k.ConnectedKey)
                {
                    _keyGui.settings(aKey.key_name, aKey.EventState, aKey.keyTag, aKey.keyEnebled, aKey.executeLoc, aKey);
                }
            }
        }

        /// <summary>
        /// The settings of a key are changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void onUpdatedKey(object sender, EventArgs e)
        {
            string lines = "";

            //generate new save file
            foreach (Key aKey in _keyboard.KeyboardKeyList)
            {
                lines += aKey.key_name + "|";
                lines += aKey.EventState + "|";
                lines += aKey.keyTag.Trim('\n') + "|";
                lines += aKey.keyEnebled + "|";
                lines += aKey.executeLoc + "\n";
            }
            string[] splits = lines.Split('\n');

            System.IO.File.WriteAllLines(_saveFile, splits);

            updateListView();
            _keyboard.UpdateKeyNameList();
        }

        /// <summary>
        /// User deleted a key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void onDeleteKey(object sender, ObjKeyEventArgs e)
        {
            //Remove key from list
            _keyboard.RemoveKey(e.ObjKey);

            //generate new save file
            foreach (KeyListPanel k in _keyPanelList)
            {
                if(k.ConnectedKey == e.ObjKey)
                {
                    _keyPanelList.Remove(k);
                    k.Dispose();
                    break;
                }
            }

            onUpdatedKey(sender, EventArgs.Empty);
            //redraw list view
            drawListView(_keyPanelList);
        }

        /// <summary>
        /// Clear the key list and dispose of panels
        /// </summary>
        public void clearKeyList()
        {
            foreach(KeyListPanel k in _keyPanelList)
            {
                k.Dispose();
            }

            _keyPanelList.Clear();
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            BOTTEM_PANEL.BackColor = Color.FromArgb(252, 163, 17);
            timer1.Stop();
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BOTTEM_PANEL_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            BOTTEM_PANEL.BackColor = Color.DarkOrange;
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BOTTEM_PANEL_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }

        /// <summary>
        /// User toggle key search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SEARCH_BUTTON_Click(object sender, EventArgs e)
        {
            if (_search == true)
            {
                //disable search
                drawListView(_keyPanelList);
                SEARCH_TEXTBOC.Hide();
                NAME_LABEL.Show();
                LEFT_TOP_ICON.Show();
                SEARCH_BUTTON.BackgroundImage = Properties.Resources.baseline_search_white_18dp;
                _search = false;
            }
            else
            {
                //enable search
                SEARCH_TEXTBOC.Show();
                SEARCH_TEXTBOC.Focus();
                NAME_LABEL.Hide();
                LEFT_TOP_ICON.Hide();
                SEARCH_BUTTON.BackgroundImage = Properties.Resources.baseline_close_white_48dp2;
                _search = true;
            }
        }

        /// <summary>
        /// When search text change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SEARCH_TEXTBOC_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(SEARCH_TEXTBOC.Text))
            {
                drawListView(_keyPanelList);
            }
            else
            {
                drawListView(searchKey(SEARCH_TEXTBOC.Text));
            }
            
        }

        /// <summary>
        /// Search for a key
        /// </summary>
        /// <param name="input">
        /// Uuid or key code
        /// </param>
        /// <returns></returns>
        private List<KeyListPanel> searchKey(string input)
        {
            List<KeyListPanel> panelList = new List<KeyListPanel>();

            //key search on key name
            foreach (KeyListPanel k in _keyPanelList)
            {
                if (k.KeyName.ToLower().Replace(input, String.Empty) != k.KeyName.ToLower() 
                    || k.ConnectedKey.keyTag == input)
                {
                    panelList.Add(k);
                }
            }

            return panelList;
        }

        /// <summary>
        /// Enter key pressed in search box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SEARCH_TEXTBOC_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                if (String.IsNullOrEmpty(SEARCH_TEXTBOC.Text))
                {
                    drawListView(_keyPanelList);
                }
                else
                {
                    drawListView(searchKey(SEARCH_TEXTBOC.Text));
                }
                
            }
        }
    }
}