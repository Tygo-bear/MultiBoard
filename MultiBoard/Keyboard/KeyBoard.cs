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
using MultiBoard.Keyboard;

namespace MultiBoard
{
    public partial class KeyBoard : UserControl
    {
        private string ID;
        private string name;
        private string comPort;

        private string saveFile;

        private int numberOfKeys = 0;

        private List<Key> keyList = new List<Key>();
        private List<string> KeyNameList = new List<string>();

        private List<KeyListPanel> keyPanelList = new List<KeyListPanel>();
        private Point nextKeyListPoint = new Point(3, 3);

        public void createKey(string namekey, int eventState, string keytag, bool keyEnebled, string exeLoc)
        {
            KEYLIST_PANEL.BackgroundImage = null;

            Key obj = new Key();
            obj.Location = new Point(194, 0);

            obj.UpdatedData += onUpdatedKey;
            obj.DeleteKey += onDeleteKey;

            obj.settings(namekey, eventState, keytag, keyEnebled, exeLoc);
            numberOfKeys++;

            keyList.Add(obj);
            this.Controls.Add(obj);

            loadListVieuw();
            updateKeyNameList();
        }

        private bool checkName(string s)
        {
            foreach(string n in KeyNameList)
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
        }

        private void addNewKeyClicked(object sender, EventArgs e)
        {
            //add key clicked
            foreach(Key akey in keyList)
            {
                akey.Visible = false;
            }

            string kname;
            do
            {
                kname = "KEY " + (++numberOfKeys);
            }
            while (!checkName(kname));

            createKey(kname, 1, "NONE", true, "");

        }

        public void setKeyBoardName(string NAME)
        {
            name = NAME;
            NAME_LABEL.Text = name;
        }

        public string getKeyboardName()
        {
            return name;
        }

        public void setKeyboardUUID(string UUID)
        {
            ID = UUID;
        }

        public string getKeyboardUUID()
        {
            return ID;
        }

        public void setComPort(string port)
        {
            comPort = port;
        }

        public string getComPort()
        {
            return comPort;
        }

        public void loadKeys(string mainDirecory)
        {
            if(!File.Exists(mainDirecory + @"\" + name + ".inf"))
            {
                File.Create(mainDirecory + @"\" + name + ".inf").Close();
            }

            saveFile = mainDirecory + @"\" + name + ".inf";

            //read keys
            //============================
            string line;
            int counter = 0;

            System.IO.StreamReader file =
                new System.IO.StreamReader(mainDirecory + @"\" + name + ".inf");
            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    string[] splits = line.Split('|');

                    createKey(splits[0], Int32.Parse(splits[1]), splits[2], Convert.ToBoolean(splits[3]), splits[4]);

                    counter++;
                }
            }

            file.Close();
            updateKeyNameList();
        }

        public void keyDown(string KEY,string keyboardUUID, bool allEnebled)
        {
            if (keyboardUUID == ID)
            {
                foreach (Key aKey in keyList)
                {
                    aKey.keyDown(KEY, allEnebled);
                }
            }
        }

        public void keyUp(string KEY, string keyboardUUID , bool allEnebled)
        {
            if (keyboardUUID == ID)
            {
                foreach (Key aKey in keyList)
                {
                    aKey.keyUp(KEY, allEnebled);
                }
            }
        }

        public void loadListVieuw()
        {
            clearKeyList();
            nextKeyListPoint.X = 3;
            nextKeyListPoint.Y = 3;

            foreach (Key aKey in keyList)
            {
                KeyListPanel item = new KeyListPanel(aKey.getName(), aKey.getEnebled(), aKey);

                item.Location = nextKeyListPoint;
                nextKeyListPoint.Y = nextKeyListPoint.Y + item.Height + 3;
                item.ClickedKey += userSelectedKey;

                KEYLIST_PANEL.Controls.Add(item);
                item.BringToFront();

                keyPanelList.Add(item);
            }
        }

        private void userSelectedKey(object sender, EventArgs e)
        {
            KeyListPanel k = sender as KeyListPanel;

            foreach(Key aKey in keyList)
            {
                if(aKey == k.connected_key)
                {
                    aKey.Visible = true;
                    aKey.BringToFront();
                }
                else
                {
                    aKey.Hide();
                }
            }
        }

        void onUpdatedKey(object sender, EventArgs e)
        {
            string lines = "";

            foreach (Key aKey in keyList)
            {
                lines += aKey.getName() + "|";
                lines += aKey.getEvent() + "|";
                lines += aKey.getKeytag() + "|";
                lines += aKey.getEnebled() + "|";
                lines += aKey.getExecuteLocation() + "\n";
            }
            string[] splits = lines.Split('\n');

            System.IO.File.WriteAllLines(saveFile, splits);

            loadListVieuw();
            updateKeyNameList();
        }

        void onDeleteKey(object sender, objKeyEventArgs e)
        {
            keyList.Remove(e.objKey);
            e.objKey.Dispose();

            onUpdatedKey(sender, EventArgs.Empty);
            loadListVieuw();
        }

        private void updateKeyNameList()
        {
            KeyNameList.Clear();
            foreach(Key k in keyList)
            {
                KeyNameList.Add(k.getName());
            }

            foreach (Key k in keyList)
            {
                k.nameAllKeys = KeyNameList;
            }
        }

        public Key Key
        {
            get => default(Key);
            set
            {
            }
        }

        public void clearKeyList()
        {
            foreach(KeyListPanel k in keyPanelList)
            {
                k.Dispose();
            }
            keyPanelList.Clear();
        }
    }
}