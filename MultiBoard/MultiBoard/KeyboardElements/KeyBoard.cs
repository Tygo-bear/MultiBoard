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
using System.Threading;
using MultiBoard.Keyboard;
using MultiBoard.Keyboard.KeyElements;
using MultiBoard.KeyboardElements.KeyElements;

namespace MultiBoard
{
    public partial class KeyBoard : UserControl
    {
        private string _id;
        private string _name;
        private string _comPort;

        private string _saveFile;
        private int _numberOfKeys = 0;
        private KeyGui _keyGui = new KeyGui();

        private List<Key> _keyList = new List<Key>();
        private List<string> _keyNameList = new List<string>();
        private List<KeyListPanel> _keyPanelList = new List<KeyListPanel>();

        private Point _nextKeyListPoint = new Point(3, 3);

        public Key createKey(string namekey, int eventState, string keytag, bool keyEnebled, string exeLoc)
        {
            KEYLIST_PANEL.BackgroundImage = null;

            Key obj = new Key(namekey, eventState, keytag, keyEnebled, exeLoc);

            _numberOfKeys++;
            _keyList.Add(obj);

            return obj;
        }

        private bool checkName(string s)
        {
            foreach(string n in _keyNameList)
            {
                if(n == s)
                {
                    return false;
                }
            }
            return true;
        }

        public KeyBoard()
        {
            InitializeComponent();

            _keyGui.UpdatedData += onUpdatedKey;
            _keyGui.DeleteKey += onDeleteKey;

            _keyGui.Location = new Point(194, 0);
            this.Controls.Add(_keyGui);
            _keyGui.Hide();
        }

        private void addNewKeyClicked(object sender, EventArgs e)
        {
            //add key clicked
            string kname;
            kname = "KEY " + (_numberOfKeys);

            while (!checkName(kname))
            {
                _numberOfKeys++;
                kname = "KEY " + (_numberOfKeys);
            }

            Key k = createKey(kname, 1, "NONE", true, "");
            _keyGui.settings(kname, 1, "NONE", true, "", k);

            addKeyToListVieuw(k);
            updateKeyNameList();

            _keyGui.Show();
        }

        public void setKeyBoardName(string name)
        {
            _name = name;
            NAME_LABEL.Text = _name;
        }

        public string getKeyboardName()
        {
            return _name;
        }

        public void setKeyboardUuid(string uuid)
        {
            _id = uuid;
        }

        public string getKeyboardUuid()
        {
            return _id;
        }

        public void setComPort(string port)
        {
            _comPort = port;
        }

        public string getComPort()
        {
            return _comPort;
        }

        public void loadKeys(string mainDirecory)
        {
            _keyList.Clear();

            if(!File.Exists(mainDirecory + @"\" + _name + ".inf"))
            {
                File.Create(mainDirecory + @"\" + _name + ".inf").Close();
            }

            _saveFile = mainDirecory + @"\" + _name + ".inf";

            //read keys
            //============================
            string line;
            var counter = 0;

            System.IO.StreamReader file =
                new System.IO.StreamReader(mainDirecory + @"\" + _name + ".inf");
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

        public void keyDown(string key,string keyboardUuid, bool allEnebled)
        {
            if (keyboardUuid == _id)
            {
                foreach (Key aKey in _keyList)
                {
                    aKey.keyDown(key, allEnebled);
                }

                _keyGui.keyDown(key, allEnebled);
            }
        }

        public void keyUp(string key, string keyboardUuid , bool allEnebled)
        {
            if (keyboardUuid == _id)
            {
                foreach (Key aKey in _keyList)
                {
                    aKey.keyUp(key, allEnebled);
                }
            }
        }

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

        public void addKeyToListVieuw(Key k)
        {

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

        public void updateListView()
        {
            foreach(KeyListPanel klp in _keyPanelList)
            {
                Key k = klp.connected_key;
                klp.Kname = k.key_name;
                klp.setState(k.keyEnebled);
            }

            updateKeyNameList();
        }

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
                if(aKey == k.connected_key)
                {
                    _keyGui.settings(aKey.key_name, aKey.EventState, aKey.keyTag, aKey.keyEnebled, aKey.executeLoc, aKey);
                }
            }
        }

        void onUpdatedKey(object sender, EventArgs e)
        {
            string lines = "";

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

        void onDeleteKey(object sender, ObjKeyEventArgs e)
        {
            _keyList.Remove(e.ObjKey);
            foreach(KeyListPanel k in _keyPanelList)
            {
                if(k.connected_key == e.ObjKey)
                {
                    _keyPanelList.Remove(k);
                    k.Dispose();
                    break;
                }
            }

            onUpdatedKey(sender, EventArgs.Empty);
            drawListView(_keyPanelList);
        }

        private void updateKeyNameList()
        {
            _keyNameList.Clear();
            foreach(Key k in _keyList)
            {
                _keyNameList.Add(k.key_name);
            }
            
            //foreach (Key k in keyList)
            //{
            //    k.nameAllKeys = KeyNameList;
            //}
        }

        public void clearKeyList()
        {
            foreach(KeyListPanel k in _keyPanelList)
            {
                k.Dispose();
            }

            _keyPanelList.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BOTTEM_PANEL.BackColor = Color.FromArgb(252, 163, 17);
            timer1.Stop();
        }

        private void BOTTEM_PANEL_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            BOTTEM_PANEL.BackColor = Color.DarkOrange;
        }

        private void BOTTEM_PANEL_MouseLeave(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}