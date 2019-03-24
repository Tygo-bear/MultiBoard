using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MultiBoard.KeyboardElements.KeyElements;

namespace MultiBoard.KeyboardElements
{
    public partial class KeyBoard : UserControl
    {
        //Vars
        //=============
        private string _id;
        private string _name;
        private string _comPort;

        private bool _search = false;

        private string _saveFile;
        private int _numberOfKeys = 0;
        private KeyGui _keyGui = new KeyGui();

        private List<Key> _keyList = new List<Key>();
        private List<string> _keyNameList = new List<string>();
        private List<KeyListPanel> _keyPanelList = new List<KeyListPanel>();

        private Point _nextKeyListPoint = new Point(3, 3);

        /// <summary>
        /// Initialize all elements
        /// </summary>
        public KeyBoard()
        {
            InitializeComponent();

            _keyGui.UpdatedData += onUpdatedKey;
            _keyGui.DeleteKey += onDeleteKey;

            _keyGui.Location = new Point(194, 0);
            this.Controls.Add(_keyGui);
            _keyGui.Hide();
        }

        /// <summary>
        /// Create a new key
        /// </summary>
        /// <param name="keyName">
        /// Name of the key
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

            _numberOfKeys++;
            _keyList.Add(obj);

            return obj;
        }

        /// <summary>
        /// Check the key Name of dupes
        /// </summary>
        /// <param name="s">
        /// The name to check for
        /// </param>
        /// <returns>
        /// True = valid
        /// False = invalid
        /// </returns>
        private bool checkName(string s)
        {
            foreach (string n in _keyNameList)
            {
                if (n == s)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// User clicked "Add new key" control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewKeyClicked(object sender, EventArgs e)
        {
            //generate name
            var keyName = "KEY " + (_numberOfKeys);

            //regenerate new key until valid
            while (!checkName(keyName))
            {
                _numberOfKeys++;
                keyName = "KEY " + (_numberOfKeys);
            }

            //Create the key
            Key k = createKey(keyName, 1, "NONE", true, "");
            _keyGui.settings(keyName, 1, "NONE", true, "", k);

            addKeyToListView(k);
            updateKeyNameList();

            _keyGui.Show();
        }

        /// <summary>
        /// Name of the keyboard shown to the user
        /// </summary>
        public string KeyboardName
        {
            set
            {
                _name = value;
                NAME_LABEL.Text = _name;
            }
            get => _name;
        }

        /// <summary>
        /// Dynamic id of the keyboard
        /// </summary>
        public string KeyboardUuid
        {
            set => _id = value;
            get => _id;
        }

        /// <summary>
        /// Com port of the keyboard
        /// </summary>
        public string ComPort
        {
            set => _comPort = value;
            get => _comPort;
        }

        /// <summary>
        /// Load the keys into the keyboard class
        /// </summary>
        /// <param name="mainDirectory">
        /// The main directory of the program
        /// </param>
        public void loadKeys(string mainDirectory)
        {
            _keyList.Clear();

            //check for file exist
            if(!File.Exists(mainDirectory + @"\" + _name + ".inf"))
            {
                File.Create(mainDirectory + @"\" + _name + ".inf").Close();
            }

            _saveFile = mainDirectory + @"\" + _name + ".inf";

            //read keys
            //============================
            string line;
            var counter = 0;

            System.IO.StreamReader file =
                new System.IO.StreamReader(mainDirectory + @"\" + _name + ".inf");
            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    string[] splits = line.Split('|');

                    Key k = createKey(splits[0], Int32.Parse(splits[1]), splits[2], Convert.ToBoolean(splits[3]), splits[4]);
                    

                    if(counter == 0)
                    {
                        _keyGui.settings(k.key_name, k.EventState, k.keyTag, k.keyEnebled, k.executeLoc, k);
                        _keyGui.Show();
                    }
                    

                    counter++;
                }
            }

            file.Close();
            loadListView();
            updateKeyNameList();
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
        public void keyDown(string key,string keyboardUuid, bool allEnabled)
        {
            //check for matching ids
            if (keyboardUuid == _id)
            {
                //send to all keys
                foreach (Key aKey in _keyList)
                {
                    aKey.keyDown(key, allEnabled);
                }

                //send to GUI components
                _keyGui.keyDown(key, allEnabled);
                if (_search == true)
                {
                    this.Invoke(new Action(() =>
                        SEARCH_TEXTBOC.Text = key));
                }
            }
        }

        /// <summary>
        /// Key up event
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
        public void keyUp(string key, string keyboardUuid , bool allEnabled)
        {
            //check for matching ids
            if (keyboardUuid == _id)
            {
                //send to all keys
                foreach (Key aKey in _keyList)
                {
                    aKey.keyUp(key, allEnabled);
                }
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

            for(int i = 0; i < _keyList.Count; i++)
            {
                Key aKey = _keyList[i];

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
            updateKeyNameList();
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

            updateKeyNameList();
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

            foreach(Key aKey in _keyList)
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
            foreach (Key aKey in _keyList)
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
            updateKeyNameList();
        }

        /// <summary>
        /// User deleted a key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void onDeleteKey(object sender, ObjKeyEventArgs e)
        {
            //Remove key from list
            _keyList.Remove(e.ObjKey);

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
        /// Update the list of the names from all the keys
        /// </summary>
        private void updateKeyNameList()
        {
            _keyNameList.Clear();
            foreach(Key k in _keyList)
            {
                _keyNameList.Add(k.key_name);
            }

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
        /// Name or key code
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