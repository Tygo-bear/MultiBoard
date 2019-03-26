﻿using MultiBoard.overlays;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MultiBoard.add_keyboard;
using MultiBoard.ErrorSystem;
using MultiBoard.KeyboardElements;
using MultiBoard.KeyboardElements.KeyboardScannerElements;
using MultiBoard.SettingsElements;

namespace MultiBoard
{
    public partial class MultiBoard : Form
    {
        //variables
        //==================================
        public string MainDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MultiBoard";
        public bool ToggleB = true;
        private bool _firstStartUp = true;
        private List<KeyBoard> _keyboardList = new List<KeyBoard>();
        private List<Connector> _connectorList = new List<Connector>();
        private List<string> _showErrorList = new List<string>();

        //classes and user controls
        //====================================
        KeyboardList _listkeyboardElement;
        KeyboardScanner _scanner = new KeyboardScanner();
        addKeyboard _addKeyboardContr;
        ErrorOptions _errorContr = new ErrorOptions();
        LoadingMainOverlay _loadOverlay = new LoadingMainOverlay();
        ErrorMangePanel _errorManagePanel = new ErrorMangePanel();
        MainSettings _mainSettings = new MainSettings();
        

        //resouces images
        //===============================
        readonly Image TOGGLE_ON = Properties.Resources.TOGGLE_ON;
        readonly Image TOGGLE_OFF = Properties.Resources.TOGGLE_OFF;

        //drag bar
        //===============================
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MultiBoard()
        {
            InitializeComponent();

            //Clear error list
            Properties.Settings.Default.ErrorList = "";
            Properties.Settings.Default.Save();

            //loadOverlay control
            _loadOverlay.Location = new Point(0, 0);
            this.Controls.Add(_loadOverlay);
            _loadOverlay.BringToFront();

            //keyboard list control
            _listkeyboardElement = new KeyboardList(MainDirectory);
            _listkeyboardElement.SelectedItem += userSelectedKeyboard;
            _listkeyboardElement.UpdateKeyboards += saveKeyboardsEvent;
            _listkeyboardElement.Location = new Point(32, 31);
            this.Controls.Add(_listkeyboardElement);

            //settings control
            _mainSettings.Location = new Point(32,31);
            _mainSettings.Hide();
            Controls.Add(_mainSettings);

            //error control
            _errorContr.IgnoreClicked += errorIgnore;
            _errorContr.ReloadClicked += errorReload;
            _errorContr.ViewClicked += errorView;

            Point p = new Point();
            p.X = this.Width - _errorContr.Width - 5;
            p.Y = this.Height - _errorContr.Height - 34 - 5;
            _errorContr.Location = p;

            _errorContr.Visible = false;
            this.Controls.Add(_errorContr);

            //errorManagePanel
            _errorManagePanel.Location = new Point(32, 31);
            _errorManagePanel.Hide();
            this.Controls.Add(_errorManagePanel);
            
            //addkeyboard control
            _addKeyboardContr = new addKeyboard();
            _addKeyboardContr.Location = new Point(32, 31);
            this.Controls.Add(_addKeyboardContr);
            _addKeyboardContr.AddKeyboard += keyboardAdded;
            
            //loading keyboards
            backgroundWorker2.RunWorkerAsync();

        }

        /// <summary>
        /// Save keyboard event called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// Keyboard to remove
        /// </param>
        private void saveKeyboardsEvent(object sender, KeyboardToArgs e)
        {
            if(e != EventArgs.Empty)
            {
                //remove keyboard in args
                _keyboardList.Remove(e.Keyboard);
                e.Keyboard.Dispose();
            }
            saveBoards();
        }

        /// <summary>
        /// View error event called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void errorView(object sender, EventArgs e)
        {
            //Update error manage panel errorList
            _errorManagePanel.updateErrorList();
            //Show errorManagePanel
            _errorManagePanel.Show();
            _errorManagePanel.BringToFront();
        }

        /// <summary>
        /// Reload keyboards event called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void errorReload(object sender, EventArgs e)
        {
            //Reset error control
            ERROR_LABEL.Text = "";
            _errorContr.Hide();

            //Clear error list
            Properties.Settings.Default.ErrorList = "";
            Properties.Settings.Default.Save();

            //Start reloading
            WARRNING_BUTTON.Visible = false;
            reloadKeyboards();
        }

        /// <summary>
        /// Ignore error event called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void errorIgnore(object sender, EventArgs e)
        {
            if (_showErrorList.Count > 0)
            {
                //Remove error
                _showErrorList.RemoveAt(0);
            }
            if (_showErrorList.Count > 0)
            {
                //Show next error
                ERROR_LABEL.Text = _showErrorList[0];
            }
            else
            {
                //Hide error control
                ERROR_LABEL.Text = "";
                _errorContr.Hide();
                WARRNING_BUTTON.Visible = false;
            }
        }

        /// <summary>
        /// Keyboard added event called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyboardAdded(object sender, EventArgs e)
        {
            //Read main config file
            string[] allLines = File.ReadAllLines(MainDirectory + @"\keyboards.inf");
            List<string> sstring = allLines.ToList();

            //Collect new keyboard information
            string name = _addKeyboardContr.KeyboardName;
            string uuid = _addKeyboardContr.KeyboardID;
            string port = _addKeyboardContr.KeyboardPort;
            
            //Add keyboard to main config file
            sstring.Add(_addKeyboardContr.KeyboardID + "|" + _addKeyboardContr.KeyboardName + "|" + _addKeyboardContr.KeyboardPort + "\n");
            string[] writeAll = sstring.ToArray();

            //Update main config file
            File.WriteAllLines(MainDirectory + @"\keyboards.inf", writeAll, Encoding.UTF8);

            //Create new keyboard class/userControl
            KeyBoard obj = new KeyBoard();
            obj.Location = new Point(32, 31);
            obj.Visible = true;
            this.Controls.Add(obj);
            obj.BringToFront();

            //Write keyboard settings to class
            obj.KeyboardName = name;
            obj.KeyboardUuid = uuid;
            obj.ComPort = port;

            //Add new keyboard class to the keyboard list control
            _listkeyboardElement.addItem(name, uuid, port, obj);

            //Load in the keys of the new keyboard
            obj.loadKeys(MainDirectory);

            //Add new keyboard to keyboard list
            _keyboardList.Add(obj);

            //unloading all keyboards
            foreach (Connector c in _connectorList)
            {
                c.closePort();
            }
            _connectorList.Clear();

            //load all keyboards
            backgroundWorker1.CancelAsync();
            backgroundWorker1.RunWorkerAsync();
        }

        /// <summary>
        /// Save all keyboards to main config file
        /// </summary>
        private void saveBoards()
        {
            //List of strings to write
            List<string> sstring = new List<string>();

            //Add each keyboard file write list (sstring)
            foreach (KeyBoard kb in _keyboardList)
            {
                string name = kb.KeyboardName;
                string uuid = kb.KeyboardUuid;
                string port = kb.ComPort;

                sstring.Add(uuid + "|" + name + "|" + port + "\n");
            }

            //Create write array
            string[] writeAll = sstring.ToArray();

            //Write to main keyboard config file
            File.WriteAllLines(MainDirectory + @"\keyboards.inf", writeAll, Encoding.UTF8);
        }

        /// <summary>
        /// Used for drag bar on top of control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }

        /// <summary>
        /// User clicked "close" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CLOSE_B_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        /// <summary>
        /// User clicked "minimize" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MINIMIZE_B_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Toggle "all keyboards enabled"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TOGGLE_B_Click(object sender, EventArgs e)
        {
            if (ToggleB == true)
            {
                //disable
                disableB();
            }
            else
            {
                //enable
                enableB();
            }
        }

        /// <summary>
        /// Disable "all keyboards enabled"
        /// </summary>
        private void disableB()
        {
            TOGGLE_B.BackgroundImage = TOGGLE_OFF;
            ToggleB = false;
        }

        /// <summary>
        /// Enable "all keyboards enabled"
        /// </summary>
        private void enableB()
        {
            TOGGLE_B.BackgroundImage = TOGGLE_ON;
            ToggleB = true;
        }

        /// <summary>
        /// Load keyboards from main keyboard file
        /// </summary>
        private void loadingBoards()
        {
            //Check for file exists
            if (!File.Exists(MainDirectory + @"\keyboards.inf"))
            {
                //Check for directory
                if (!Directory.Exists(MainDirectory))
                {
                    //Create directory
                    Directory.CreateDirectory(MainDirectory);
                }
                //Create File
                File.Create(MainDirectory + @"\keyboards.inf").Close();
            }

            int counter = 0;
            string line;
            List<string> temp = new List<string>();
            string[] boards;

            // read main file
            //============================
            System.IO.StreamReader file =
                new System.IO.StreamReader(MainDirectory + @"\keyboards.inf");
            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    temp.Add(line);
                    counter++;
                }
            }

            boards = temp.ToArray();

            file.Close();

            //add boards to form
            //=================================
            int count = 0;

            for (int i = 0; i < boards.Length; i++)
            {
                if (boards[i] == "" || boards[i] == null)
                {

                }
                else
                {
                    string[] splits = boards[i].Split('|');

                    //Create boards
                    KeyBoard obj = new KeyBoard();
                    obj.Location = new Point(32, 31);
                    obj.Visible = false;
                    this.Controls.Add(obj);

                    obj.KeyboardName = splits[1];
                    obj.KeyboardUuid = splits[0];
                    obj.ComPort = splits[2];

                    _listkeyboardElement.addItem(splits[1], splits[0], splits[2], obj);

                    obj.loadKeys(MainDirectory);

                    _keyboardList.Add(obj);

                    count++;
                }
            }

            if(count == 0)
            {
                //When no keyboards added show "add keyboards" control
                _listkeyboardElement.Visible = false;
                _addKeyboardContr.Visible = true;
            }

        }

        /// <summary>
        /// Key down events called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// The key code
        /// </param>
        void onKeyDown(object sender, KeyEventArgs e)
        {
            Connector c = sender as Connector;

            //pass event to each keyboard
            foreach (KeyBoard aKeyBoard in _keyboardList)
            {
                //open a new thread foreach keyboard
                Thread t = new Thread(() => aKeyBoard.keyDown(e.Key, c.DynamicId, ToggleB));
                t.Start();
            }
        }

        /// <summary>
        /// Key up event called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// Key code
        /// </param>
        void onKeyUp(object sender, KeyEventArgs e)
        {
            Connector c = sender as Connector;

            //pass event to each keyboard
            foreach (KeyBoard aKeyBoard in _keyboardList)
            {
                //open a new thread foreach keyboard
                Thread t = new Thread(() => aKeyBoard.keyUp(e.Key, c.DynamicId, ToggleB));
                t.Start();
            }
        }

        /// <summary>
        /// Open a connector foreach keyboard as a background task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _connectorList.Clear();

            foreach (KeyBoard kb in _keyboardList)
            {
                string comport = getPortFromId(kb.KeyboardUuid);
                if(comport == null)
                {

                    addError(true, kb.KeyboardName + " --> not found!");

                }
                else
                {
                    Connector conect1 = new Connector();
                    conect1.DynamicId = kb.KeyboardUuid;
                    conect1.setup(comport, 115200);
                    conect1.openPort();
                    conect1.KeyDown += onKeyDown;
                    conect1.KeyUp += onKeyUp;

                    _connectorList.Add(conect1);
                }

            }
        }

        /// <summary>
        /// User clicked "keyboard list" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KEYBOARD_LIST_CLICKED(object sender, EventArgs e)
        {
            foreach(KeyBoard aKeyboard in _keyboardList)
            {
                aKeyboard.Visible = false;
            }

            _listkeyboardElement.Visible = true;
            _listkeyboardElement.BringToFront();
        }

        /// <summary>
        /// User clicked on a keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// Name of the keyboard
        /// </param>
        private void userSelectedKeyboard(object sender, ItemName e)
        {
            //TODO move from name to UUID

            foreach (KeyBoard aKeyboard in _keyboardList)
            {
                //Find matching keyboard
                if(aKeyboard.KeyboardName == e.Name)
                {
                    //show matching keyboard
                    aKeyboard.Visible = true;
                    aKeyboard.BringToFront();
                    _listkeyboardElement.Visible = false;
                }
                else
                {
                    //Hide non matching keyboard
                    aKeyboard.Visible = false;

                }
            }
        }

        /// <summary>
        /// Get the com port of a keyboard with the ID
        /// </summary>
        /// <param name="id">
        /// dynamic ID (UUID)
        /// </param>
        /// <returns>
        /// Com port of the keyboard
        /// NULL if not found
        /// </returns>
        private string getPortFromId(string id)
        {
            int i = 0;

            foreach(string s in _scanner.Uuid)
            {
                int o = 0;

                if(s == id)
                {
                    foreach(string p in _scanner.Ports)
                    {
                        if(o == i && p != "NONE")
                        {
                            return p;
                        }
                        o++;
                    }
                    return null;
                }

                i++;
            }

            return null;
        }

        /// <summary>
        /// User clicked "add keyboard" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ADD_KEYBOARD_BUTTON_Click(object sender, EventArgs e)
        {
            _addKeyboardContr.Visible = true;
            _addKeyboardContr.BringToFront();

        }

        /// <summary>
        /// User clicked on icon in task array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NOTIFY_ICO_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }

        }

        /// <summary>
        /// User clicked on option on notifyIcon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NOTIFY_ICO_CONTENT_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Text == "Close")
            {
                //Close application
                this.Close();
            }
            else if(e.ClickedItem.Text == "Open")
            {
                //show application
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// User clicked "warning" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WARRNING_BUTTON_Click(object sender, EventArgs e)
        {
            if (_errorContr.Visible == false)
            {
                _errorContr.Visible = true;
                _errorContr.BringToFront();
            }
            else
            {
                _errorContr.Visible = false;
            }
        }

        /// <summary>
        /// Start a keyboard scanner as background task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //scanning boards
            _scanner.loadList(115200);
            this.Invoke(new Action(() =>
            {
                loadingBoards();
                backgroundWorker1.RunWorkerAsync();
                _loadOverlay.Hide();
            }));
        }

        /// <summary>
        /// Reload keyboards
        /// </summary>
        private void reloadKeyboards()
        {
            //LoadOverlay
            _loadOverlay.Show();
            _loadOverlay.BringToFront();

            //resetting
            ERROR_LABEL.Text = "";
            _errorContr.Hide();
            WARRNING_BUTTON.Visible = false;

            //unloading
            foreach (Connector c in _connectorList)
            {
                c.closePort();
            }
            _connectorList.Clear();

            foreach (KeyBoard k in _keyboardList)
            {
                k.Dispose();
            }
            _keyboardList.Clear();


            _listkeyboardElement.Dispose();
            _listkeyboardElement = new KeyboardList(MainDirectory);
            _listkeyboardElement.SelectedItem += userSelectedKeyboard;
            _listkeyboardElement.Location = new Point(32, 31);
            this.Controls.Add(_listkeyboardElement);

            //loading
            backgroundWorker1.CancelAsync();
            backgroundWorker2.RunWorkerAsync();

        }

        /// <summary>
        /// Add error to error list
        /// </summary>
        /// <param name="show">
        /// true = error control pop-up
        /// false = no notify
        /// </param>
        /// <param name="mes">
        /// Message shown to the user
        /// </param>
        private void addError(bool show, string mes)
        {
            //Write settings
            Properties.Settings.Default.ErrorList = Properties.Settings.Default.ErrorList + mes + ",";
            Properties.Settings.Default.Save();

            if(show)
            {
                _showErrorList.Add(mes);
            }

            if(WARRNING_BUTTON.Visible == false && show)
            {
                this.Invoke(new Action(() =>
                {
                    this.Show();
                    WARRNING_BUTTON.Show();
                    ERROR_LABEL.Text = mes;
                }));
            }

        }

        /// <summary>
        /// Second instance showMe
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WmShowme)
            {
                showMe();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Second instance showMe
        /// </summary>
        private void showMe()
        {
            this.Show();
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        /// <summary>
        /// User clicked "perfMode" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PERF_MODE_BUTTON_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// User clicked "error mange" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ERROR_MANAGE_BUTTON_Click(object sender, EventArgs e)
        {
            _errorManagePanel.updateErrorList();
            _errorManagePanel.Show();
            _errorManagePanel.BringToFront();
        }

        /// <summary>
        /// User clicked "settings" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SETTINGS_BUTTON_Click(object sender, EventArgs e)
        {
            _mainSettings.Show();
            _mainSettings.BringToFront();
        }

        /// <summary>
        /// "Stay hidden" implementation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiBoard_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StayHidden && _firstStartUp)
            {
                this.Visible = false;
                _firstStartUp = false;
            }
        }
    }
}
