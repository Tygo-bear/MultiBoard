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

        public void createKey(string namekey, int eventState, string keytag, bool keyEnebled, string exeLoc)
        {
            Key obj = new Key();
            obj.Location = new Point(194, 0);

            obj.UpdatedData += onUpdatedKey;
            obj.DeleteKey += onDeleteKey;

            obj.settings(namekey, eventState, keytag, keyEnebled, exeLoc);
            numberOfKeys++;

            keyList.Add(obj);
            this.Controls.Add(obj);

            loadListVieuw();

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

            createKey("KEY " + (numberOfKeys + 1), 1, "NONE", true, "");

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

        public void keyDown(string KEY, bool allEnebled)
        {
            Console.WriteLine("Recieved: " + KEY);
            foreach(Key aKey in keyList)
            {
                aKey.keyDown(KEY, allEnebled);
            }
        }

        public void keyUp(string KEY, bool allEnebled)
        {
            Console.WriteLine("Recieved: " + KEY);
            foreach (Key aKey in keyList)
            {
                aKey.keyUp(KEY, allEnebled);
            }
        }

        public void loadListVieuw()
        {
            KEY_LIST.Clear();

            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();

            imageListSmall.ImageSize = new Size(50, 50);
            imageListLarge.ImageSize = new Size(50, 50);

            Image normal_key = Properties.Resources.key;
            Image dark_key = Properties.Resources.dark_key;

            imageListSmall.Images.Add(dark_key);
            imageListSmall.Images.Add(normal_key);

            imageListLarge.Images.Add(dark_key);
            imageListLarge.Images.Add(normal_key);

            KEY_LIST.SmallImageList = imageListSmall;
            KEY_LIST.LargeImageList = imageListLarge;

            foreach (Key aKey in keyList)
            {
                ListViewItem item = new ListViewItem(aKey.getName(), aKey.getEnebled() ? 1 : 0);

                item.SubItems.Add(aKey.getKeytag());

                KEY_LIST.Items.Add(item);
            }
        }

        private void KEY_LIST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KEY_LIST.SelectedItems.Count > 0)
            {

                string searh = KEY_LIST.SelectedItems[0].Text;

                foreach (Key aKey in keyList)
                {

                    if (aKey.getName() == searh)
                    {
                        aKey.Visible = true;
                    }
                    else
                    {
                        aKey.Visible = false;
                    }
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
    }
}