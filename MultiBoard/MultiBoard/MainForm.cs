using MultiBoard.overlays;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MultiBoard.add_keyboard;
using MultiBoard.ErrorSystem;
using MultiBoard.KeyboardElements;
using MultiBoard.SettingsElements;
using MultiBoardKeyboard;
using Newtonsoft.Json;

namespace MultiBoard
{
    public partial class MultiBoard : Form
    {

        //variables
        //==================================
        public string MainDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MultiBoard";
        public bool ToggleB = true;
        private bool _firstStartUp = true;
        private List<KeyBoardGUI> _keyboardGUIList = new List<KeyBoardGUI>();
        private List<string> _showErrorList = new List<string>();
        private List<Keyboard> _keyboards = new List<Keyboard>();


        //classes and user controls
        //====================================
        KeyboardList _listkeyboardElement;

        private KeyboardScanner _scanner = new KeyboardScanner(
            Properties.Settings.Default.TimeOutDelay,
            Properties.Resources.KeyboardScanner__staticId,
            Properties.Settings.Default.SafeModeScan);
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

            //Debug
            //=========================

            //manage files
            if(!Directory.Exists(MainDirectory + @"\logs")) Directory.CreateDirectory(MainDirectory + @"\logs");
            if(File.Exists(MainDirectory + @"\logs\debugOld.log")) File.Delete(MainDirectory + @"\logs\debugOld.log");
            if(File.Exists(MainDirectory + @"\logs\debug.log")) File.Move(MainDirectory + @"\logs\debug.log", MainDirectory + @"\logs\debugOld.log");
            FileStream _debugLogStream = new FileStream(MainDirectory + @"\logs\debug.log", FileMode.Append);

            //connect listener
            TextWriterTraceListener myTextListener =
                new TextWriterTraceListener(_debugLogStream);
            Debug.Listeners.Add(myTextListener);
            Debug.AutoFlush = true;

            Debug.WriteLine("--DEBUG STARTED--");
            Debug.AutoFlush = true;

            //Clear error list
            //======================
            Properties.Settings.Default.ErrorList = "";
            Properties.Settings.Default.Save();
            //TODO redo

            //loadOverlay control
            _loadOverlay.Location = new Point(0, 0);
            this.Controls.Add(_loadOverlay);
            _loadOverlay.BringToFront();

            //keyboard list control
            _listkeyboardElement = new KeyboardList(MainDirectory);
            _listkeyboardElement.SelectedItem += UserSelectedKeyboard;
            _listkeyboardElement.UpdateKeyboards += saveKeyboardsEvent;
            MAIN_PANEL.Controls.Add(_listkeyboardElement);
            _listkeyboardElement.Dock = DockStyle.Fill;

            //settings control
            _mainSettings.Hide();
            MAIN_PANEL.Controls.Add(_mainSettings);
            _mainSettings.Dock = DockStyle.Fill;

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
            _errorManagePanel.Hide();
            MAIN_PANEL.Controls.Add(_errorManagePanel);
            _errorManagePanel.Dock = DockStyle.Fill;
            
            //addkeyboard control
            _addKeyboardContr = new addKeyboard();
            MAIN_PANEL.Controls.Add(_addKeyboardContr);
            _addKeyboardContr.Dock = DockStyle.Fill;
            _addKeyboardContr.AddKeyboard += keyboardAdded;

            //loading keyboards
            backgroundWorker2.RunWorkerAsync();

            //AutoUpdate prompt
            if (Properties.Settings.Default.CheckForUpdates == 2)
            {
                CheckForUpdatesOverlay cfu = new CheckForUpdatesOverlay();
                cfu.Location = new Point(0, 0);
                this.Controls.Add(cfu);
                cfu.BringToFront();
            }

            //enable toggle button
            EnableB();

            //Version updates
            VERSION_LABEL.Text = Properties.Resources.Version;

            Debug.WriteLine("Construction main done");

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
                _keyboardGUIList.Remove(e.Keyboard);
                e.Keyboard.Dispose();
                //TODO backend
            }
            SaveKeyboardSaveFile();
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
            _showErrorList.Clear();

            //Clear error list
            Properties.Settings.Default.ErrorList = "";
            Properties.Settings.Default.Save();

            //Start reloading
            WARRNING_BUTTON.Visible = false;
            ReloadKeyboards();
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
                ErrorLabelShowMessage(_showErrorList[0]);
                
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
        /// Show a message on error label
        /// </summary>
        /// <param name="mes">
        /// Message for the user
        /// </param>
        private void ErrorLabelShowMessage(string mes)
        {
            ERROR_LABEL.Text = mes;
            ERROR_LABEL.Location = new Point(WARRNING_BUTTON.Location.X - 3 - ERROR_LABEL.Width,
                ERROR_LABEL.Location.Y);
        }

        /// <summary>
        /// Keyboard added event called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyboardAdded(object sender, EventArgs e)
        {
            //TODO json write
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
            Keyboard kb = new Keyboard(Properties.Resources.KeyboardScanner__staticId);
            _keyboards.Add(kb);

            kb.KeyboardName = name;
            kb.KeyboardComPort = port;
            kb.KeyboardUuid = uuid;

            kb.Connect();

            KeyBoardGUI obj = new KeyBoardGUI(kb);
            obj.Visible = true;
            MAIN_PANEL.Controls.Add(obj);
            obj.Dock = DockStyle.Fill;
            obj.BringToFront();


            //Add new keyboard class to the keyboard list control
            _listkeyboardElement.addItem(name, uuid, port, obj);

            //Load in the keys of the new keyboard
            obj.LegacyLoadKeys(MainDirectory);

            //Add new keyboard to keyboard list
            _keyboardGUIList.Add(obj);


        }

        private void SaveKeyboardSaveFile()
        {
            if (!Directory.Exists(MainDirectory + @"\saves"))
            {
                Directory.CreateDirectory(MainDirectory + @"\saves");
            }

            foreach (Keyboard keyboard in _keyboards)
            {
                JKeyboard jk = keyboard.SaveKeyboard(Properties.Resources.Version);
                string output = JsonConvert.SerializeObject(jk, Formatting.Indented);
                File.WriteAllText(MainDirectory + @"\saves\" + jk.Id + ".mkb", output, Encoding.UTF8);
            }
        }

        /// <summary>
        /// Save all keyboards to main config file
        /// </summary>
        private void LegacySaveBoards()
        {
            //List of strings to write
            List<string> sstring = new List<string>();

            //Add each keyboard file write list (string)
            foreach (KeyBoardGUI kb in _keyboardGUIList)
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
                DisableB();
            }
            else
            {
                //enable
                EnableB();
            }
        }

        /// <summary>
        /// Disable "all keyboards enabled"
        /// </summary>
        private void DisableB()
        {
            TOGGLE_B.BackgroundImage = TOGGLE_OFF;
            ToggleB = false;
            foreach (Keyboard keyboard in _keyboards)
            {
                keyboard.Enabled = false;
            }
        }

        /// <summary>
        /// Enable "all keyboards enabled"
        /// </summary>
        private void EnableB()
        {
            TOGGLE_B.BackgroundImage = TOGGLE_ON;
            ToggleB = true;
            foreach (Keyboard keyboard in _keyboards)
            {
                keyboard.Enabled = true;
            }
        }

        private void ReadSaveFiles()
        {
            Debug.WriteLine("loading boards");

            if (!Directory.Exists(MainDirectory))
            {
                Directory.CreateDirectory(MainDirectory);
            }

            if (!Directory.Exists(MainDirectory + @"\saves"))
            {
                Directory.CreateDirectory(MainDirectory + @"\saves");
                if (File.Exists(MainDirectory + @"\keyboards.inf"))
                {
                    Debug.WriteLine("legacy loader");
                    LegacySaveFileLoader();
                    SaveKeyboardSaveFile(); // Save in new save file format
                    return;
                }
            }

            string[] filePaths = Directory.GetFiles(MainDirectory + @"\saves\", "*.mkb");
            foreach (string path in filePaths)
            {
                Debug.WriteLine("loading: " + path);
                LoadKeyboardConfig(path);
            }

            if (filePaths.Length == 0)
            {
                //When no keyboards added show "add keyboards" control
                _listkeyboardElement.Visible = false;
                _addKeyboardContr.Visible = true;
            }
        }

        private void LoadKeyboardConfig(string path)
        {
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path, Encoding.UTF8);
                JKeyboard deserializedKeyboard = JsonConvert.DeserializeObject<JKeyboard>(text);

                Keyboard kb = new Keyboard(deserializedKeyboard, Properties.Resources.KeyboardScanner__staticId);
                kb.ConnectTimeoutDelay = Properties.Settings.Default.TimeOutDelay;

                Debug.WriteLine("loading keyboard " + kb.KeyboardUuid);

                string com = GetPortFromId(kb.KeyboardUuid);
                if (com == null)
                {
                    AddError(true, kb.KeyboardName + " --> not found!");
                    Debug.WriteLine(kb.KeyboardName + " --> not found!");
                }
                else
                {
                    kb.KeyboardComPort = com;
                    kb.Connect();
                }

                _keyboards.Add(kb);

                KeyBoardGUI obj = new KeyBoardGUI(kb);
                obj.Visible = false;
                MAIN_PANEL.Controls.Add(obj);
                obj.Dock = DockStyle.Fill;

                obj.loadKeys();

                _listkeyboardElement.addItem(kb.KeyboardName, kb.KeyboardUuid, kb.KeyboardComPort, obj);

                _keyboardGUIList.Add(obj);
            }
        }

        /// <summary>
        /// Load keyboards from main keyboard file
        /// </summary>
        private void LegacySaveFileLoader()
        {
            Debug.WriteLine("loading boards");
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
                    Debug.WriteLine("loading keyboard "+ splits[0]);

                    //Create boards
                    Keyboard kb = new Keyboard(Properties.Resources.KeyboardScanner__staticId);
                    kb.ConnectTimeoutDelay = Properties.Settings.Default.TimeOutDelay;
                    string com = GetPortFromId(splits[0]);

                    kb.KeyboardUuid = splits[0];
                    kb.KeyboardName = splits[1];

                    if (com == null)
                    {
                        AddError(true, kb.KeyboardName + " --> not found!");
                        Debug.WriteLine(kb.KeyboardName + " --> not found!");
                    }
                    else
                    {
                        kb.KeyboardComPort = com;
                        kb.Connect();
                    }
                    
                    _keyboards.Add(kb);

                    KeyBoardGUI obj = new KeyBoardGUI(kb);
                    obj.Visible = false;
                    MAIN_PANEL.Controls.Add(obj);
                    obj.Dock = DockStyle.Fill;

                    _listkeyboardElement.addItem(splits[1], splits[0], splits[2], obj);

                    obj.LegacyLoadKeys(MainDirectory);

                    _keyboardGUIList.Add(obj);

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
        /// User clicked "keyboard list" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KEYBOARD_LIST_CLICKED(object sender, EventArgs e)
        {
            foreach(KeyBoardGUI aKeyboard in _keyboardGUIList)
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
        /// Uuid of the keyboard
        /// </param>
        private void UserSelectedKeyboard(object sender, ItemName e)
        {

            foreach (KeyBoardGUI aKeyboard in _keyboardGUIList)
            {
                //Find matching keyboard
                if(aKeyboard.KeyboardUuid == e.Uuid)
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
        private string GetPortFromId(string id)
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
                Application.Exit();
                Environment.Exit(Environment.ExitCode);

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
        private void WARNING_BUTTON_Click(object sender, EventArgs e)
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
            Thread.Sleep(1);
            CheckForUpdates();
            //scanning boards
            _scanner.LoadList(115200);
            this.Invoke(new Action(() =>
            {
                ReadSaveFiles();
                _loadOverlay.Hide();
            }));
        }

        /// <summary>
        /// Reload keyboards
        /// </summary>
        private void ReloadKeyboards()
        {
            Debug.WriteLine("reloading keyboards");
            //LoadOverlay
            _loadOverlay.Show();
            _loadOverlay.BringToFront();

            //resetting
            ERROR_LABEL.Text = "";
            _errorContr.Hide();
            _showErrorList.Clear();
            WARRNING_BUTTON.Visible = false;


            foreach (KeyBoardGUI k in _keyboardGUIList)
            {
                k.Keyboard.DisConnect();
                k.Dispose();
            }
            _keyboardGUIList.Clear();

            foreach (Keyboard keyboard in _keyboards)
            {
                keyboard.DisConnect();
            }
            _keyboards.Clear();


            _listkeyboardElement.Dispose();
            _listkeyboardElement = new KeyboardList(MainDirectory);
            _listkeyboardElement.SelectedItem += UserSelectedKeyboard;
            MAIN_PANEL.Controls.Add(_listkeyboardElement);
            _listkeyboardElement.Dock = DockStyle.Fill;

            //loading
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
        private void AddError(bool show, string mes)
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
                    ErrorLabelShowMessage(mes);
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
                ShowMe();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Second instance showMe
        /// </summary>
        private void ShowMe()
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
            _mainSettings.UpdateSettings();
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

        /// <summary>
        /// Check if there is a software update
        /// </summary>
        private void CheckForUpdates()
        {
            if (Properties.Settings.Default.CheckForUpdates == 1)
            {
                GitApiUpdateCheck g = new GitApiUpdateCheck();
                bool newV;
                try
                {
                    newV = g.checkForUpdate(Properties.Resources.Version);
                    if (newV)
                    {
                        Debug.WriteLine("new Version detected");

                        UpdateOverlay uo = new UpdateOverlay(Properties.Resources.Version, g.latestVersion);
                        uo.Location = new Point(0, 0);
                        this.Invoke(new Action(() =>
                        {
                            this.Controls.Add(uo);
                            uo.BringToFront();
                            uo.downloadUrl = g.downloadUri;
                        }));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Debug.WriteLine("update check failed");
                }

            }
        }
    }
}
