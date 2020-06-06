using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MultiBoard.overlays;

namespace MultiBoard.KeyboardElements
{
    public partial class KeyboardList : UserControl
    {
        //Events
        //=================
        public event EventHandler<ItemName> SelectedItem;
        public event EventHandler<KeyboardToArgs> UpdateKeyboards;

        //Vars
        //=================
        private Point _nextPoint = new Point(31, 31);
        private List<KeyboardListPanel> _KeyboardPanelList = new List<KeyboardListPanel>();

        private string _mainDirectory;
        private string _undo;

        /// <summary>
        /// Setup of keyboardList
        /// </summary>
        /// <param name="mainDire">
        /// The main directory of the program
        /// </param>
        public KeyboardList(string mainDire)
        {
            InitializeComponent();
            _mainDirectory = mainDire;
        }

        /// <summary>
        /// Add a Keyboard to the keyboardList
        /// </summary>
        /// <param name="itemName">
        /// Uuid of the Keyboard
        /// </param>
        /// <param name="uuidItem">
        /// Dynamic ID of the keyboard
        /// </param>
        /// <param name="comportItem">
        /// The com port of the keyboard
        /// </param>
        /// <param name="boardGui">
        /// The keyboard class it represents
        /// </param>
        public void addItem(string itemName, string uuidItem, string comportItem, KeyBoardGUI boardGui)
        {
            //Create panel and add to control
            KeyboardListPanel obj = new KeyboardListPanel(itemName, uuidItem, comportItem, boardGui);
            obj.Location = _nextPoint;
            obj.Visible = true;
            obj.BoardSettingsClicked += bsClicked;
            obj.OpenBoardClicked += obClicked;
            MAIN_PANEL.Controls.Add(obj);

            _KeyboardPanelList.Add(obj);

            //Draw point on control
            if(_nextPoint.X == 31)
            {
                _nextPoint.X = _nextPoint.X + obj.Width + 31;
            }
            else
            {
                _nextPoint.X = 31;
                _nextPoint.Y = _nextPoint.Y + obj.Height + 31;
            }
        }

        /// <summary>
        /// User clicked on keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obClicked(object sender, EventArgs e)
        {
            foreach(KeyboardListPanel k in _KeyboardPanelList)
            {
                if(k == sender)
                {
                    if (SelectedItem != null) SelectedItem(this, new ItemName() {Uuid = k.KeyboardUuid});
                }
            }
            
        }

        /// <summary>
        /// USer clicked on Settings icon of keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bsClicked(object sender, EventArgs e)
        {
            //Show settings control of keyboard
            KeyboardListPanel k = sender as KeyboardListPanel;
            KeyboardSettings obj = new KeyboardSettings(k.KeyboardName, k.KeyboardUuid, k.KeyboardPort, k.ConnectedBoardGui);

            obj.Save += keyboardSave;
            obj.Delete += keyboardDelete;

            obj.Location = new Point(0, 0);
            obj.Visible = true;
            this.Controls.Add(obj);
            obj.BringToFront();

        }

        /// <summary>
        /// Save the new settings of the keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyboardSave(object sender, EventArgs e)
        {
            KeyboardSettings k = sender as KeyboardSettings;
            KeyBoardGUI b = k.ConnectedKeyboard;

            //Check file exist
            if (File.Exists(_mainDirectory + @"\" + b.KeyboardUuid + ".inf"))
            {
                File.Move(_mainDirectory + @"\" + b.KeyboardUuid + ".inf", _mainDirectory + @"\" + k.KbUuid + ".inf");
            }
            else
            {
                //report error
                Properties.Settings.Default.ErrorList += ",File rename error --> " + b.KeyboardName;
                Properties.Settings.Default.Save();
                Console.WriteLine("File rename error");
            }

            //Applies new settings to keyboard class
            b.KeyboardName = k.KbName;
            b.KeyboardUuid = k.KbUuid;
            b.ComPort = k.KbPort;

            //call event for saving settings
            if (UpdateKeyboards != null) UpdateKeyboards(this, new KeyboardToArgs() {Keyboard = null});
        }

        /// <summary>
        /// Keyboard delete request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyboardDelete(object sender, EventArgs e)
        {
            KeyboardSettings k = sender as KeyboardSettings;
            KeyBoardGUI b = k.ConnectedKeyboard;

            //MOVE FILES TO .DEL FOLDER
            //=============================

            //.del directory
            if (Directory.Exists(_mainDirectory + @"\.del"))
            {
                Directory.Delete(_mainDirectory + @"\.del", true);
            }

            Directory.CreateDirectory(_mainDirectory + @"\.del");

            //Keyboards config
            if (File.Exists(_mainDirectory + @"\keyboards.inf"))
            {
                File.Copy(_mainDirectory + @"\keyboards.inf"
                    , _mainDirectory + @"\.del\keyboards.inf");
            }
            
            //keyboard file
            if (File.Exists(_mainDirectory + @"\" + b.KeyboardUuid + ".inf"))
            {
                File.Move(_mainDirectory + @"\" + b.KeyboardUuid + ".inf"
                          , _mainDirectory + @"\.del\" + b.KeyboardUuid + ".inf");
            }
            else
            {
                //report error
                Properties.Settings.Default.ErrorList += ",File delete error --> " + b.KeyboardName;
                Properties.Settings.Default.Save();
                Console.WriteLine("File delete error");
            }

            createUndo("Undo " + b.KeyboardName +" delete");
            _undo = b.KeyboardUuid;

            //dispose representing keyboardPanel
            foreach (KeyboardListPanel p in _KeyboardPanelList)
            {
                if (p.ConnectedBoardGui == b)
                {
                    p.Dispose();
                }
            }

            //dispose Keyboard settings control
            k.Dispose();

            //Call delete event for saving new settings
            if (UpdateKeyboards != null) UpdateKeyboards(this, new KeyboardToArgs() {Keyboard = b});
        }

        /// <summary>
        /// Create a undo control
        /// </summary>
        /// <param name="mes">
        /// The message shown to the user
        /// </param>
        private void createUndo(string mes)
        {
            UndoKeyboardDelete u = new UndoKeyboardDelete();
            u.text = mes;
            u.Undo += OnUndo;
            u.Location = new Point(this.Width-u.Width, this.Height - u.Height);
            Controls.Add(u);
            u.BringToFront();
            this.Show();
        }

        /// <summary>
        /// User clicked undo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUndo(object sender, EventArgs e)
        {
            //Move files out of .del folder
            if (Directory.Exists(_mainDirectory + @"\.del"))
            {
                if (File.Exists(_mainDirectory + @"\keyboards.inf"))
                {
                    File.Delete(_mainDirectory + @"\keyboards.inf");
                }

                if (File.Exists(_mainDirectory + @"\" + _undo + ".inf"))
                {
                    File.Delete(_mainDirectory + @"\" + _undo + ".inf");
                }

                File.Move(_mainDirectory + @"\.del\keyboards.inf"
                    ,_mainDirectory + @"\keyboards.inf");
                File.Move(_mainDirectory + @"\.del" + @"\" + _undo + ".inf"
                    , _mainDirectory + @"\" + _undo + ".inf"); 
            }

            //restart application
            Application.Restart();
            Environment.Exit(0);
        }
    }

    public class ItemName : EventArgs
    {
        public string Uuid { get; set; }
    }

    public class KeyboardToArgs : EventArgs
    {
        public KeyBoardGUI Keyboard { get; set; }
    }
}
