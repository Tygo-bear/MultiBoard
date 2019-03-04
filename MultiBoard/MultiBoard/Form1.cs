using MultiBoard.overlays;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MultiBoard.Keyboard;
using MultiBoard.ErrorSystem;

namespace MultiBoard
{
    public partial class MultiBoard : Form
    {
        //variables
        //==================================
        public string MainDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MultiBoard";
        public bool ToggleB = true;
        private List<KeyBoard> _keyboardList = new List<KeyBoard>();
        private List<Connector> _connectorList = new List<Connector>();

        //classes and user controls
        //====================================
        KeyboardList _listkeyboardElement;
        KeyboardScanner _scanner = new KeyboardScanner();
        addKeyboard _addKeyboardContr;
        ErrorOptions _errorContr = new ErrorOptions();
        LoadingMainOverlay _loadOverlay = new LoadingMainOverlay();
        ErrorMangePanel _errorManagePanel = new ErrorMangePanel();
        Errors _errorDatabase = new Errors();

        //resouces images
        //===============================
        Image TOGGLE_ON = Properties.Resources.TOGGLE_ON;
        Image TOGGLE_OFF = Properties.Resources.TOGGLE_OFF;

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
            
            //loadOverlay control
            _loadOverlay.Location = new Point(0, 0);
            this.Controls.Add(_loadOverlay);
            _loadOverlay.BringToFront();

            //keyboard list control
            _listkeyboardElement = new KeyboardList(MainDirectory);
            _listkeyboardElement.SelectedItem += userSelectedKeyboard;
            _listkeyboardElement.UpdateKeyboards += SaveKeyboardsEvent;
            _listkeyboardElement.Location = new Point(32, 31);
            this.Controls.Add(_listkeyboardElement);

            //errorcontr
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
            _addKeyboardContr.AddKeyboarde += keyboardAdded;

            //loading keyboards
            backgroundWorker2.RunWorkerAsync();
        }

        private void SaveKeyboardsEvent(object sender, KeyboardToArgs e)
        {
            if(e != EventArgs.Empty)
            {
                _keyboardList.Remove(e.keybo);
                e.keybo.Dispose();
            }
            saveBoards();
        }

        private void errorView(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void errorReload(object sender, EventArgs e)
        {
            ERROR_LABEL.Text = "";
            _errorContr.Hide();
            WARRNING_BUTTON.Visible = false;
            reloadKeyboards();
        }

        private void errorIgnore(object sender, EventArgs e)
        {
            ERROR_LABEL.Text = "";
            _errorContr.Hide();
            WARRNING_BUTTON.Visible = false;
        }

        private void keyboardAdded(object sender, EventArgs e)
        {
            string[] allLines = File.ReadAllLines(MainDirectory + @"\keyboards.inf");
            List<string> sstring = allLines.ToList();

            string name = _addKeyboardContr.kbName;
            string uuid = _addKeyboardContr.kbId;
            string port = _addKeyboardContr.kbPort;
            
            sstring.Add(_addKeyboardContr.kbId + "|" + _addKeyboardContr.kbName + "|" + _addKeyboardContr.kbPort + "\n");
            string[] writeAll = sstring.ToArray();

            File.WriteAllLines(MainDirectory + @"\keyboards.inf", writeAll, Encoding.UTF8);

            KeyBoard obj = new KeyBoard();
            obj.Location = new Point(32, 31);
            obj.Visible = true;
            this.Controls.Add(obj);
            obj.BringToFront();

            obj.setKeyBoardName(name);
            obj.setKeyboardUuid(uuid);
            obj.setComPort(port);

            _listkeyboardElement.addItem(name, uuid, port, obj);

            obj.loadKeys(MainDirectory);

            _keyboardList.Add(obj);

            //unloading
            foreach (Connector c in _connectorList)
            {
                c.closePort();
            }
            _connectorList.Clear();

            //loading
            backgroundWorker1.CancelAsync();
            backgroundWorker1.RunWorkerAsync();
        }

        private void saveBoards()
        {
            List<string> sstring = new List<string>();
            //TODO FIX!!!

            foreach (KeyBoard kb in _keyboardList)
            {
                string name = kb.getKeyboardName();
                string uuid = kb.getKeyboardUuid();
                string port = kb.getComPort();

                sstring.Add(uuid + "|" + name + "|" + port + "\n");
            }

            string[] writeAll = sstring.ToArray();

            File.WriteAllLines(MainDirectory + @"\keyboards.inf", writeAll, Encoding.UTF8);
        }

        private void mouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }

        private void CLOSE_B_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void MINIMIZE_B_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TOGGLE_B_Click(object sender, EventArgs e)
        {
            if (ToggleB == true)
            {
                //disble
                disableB();
            }
            else
            {
                //enable
                enableB();
            }
        }

        private void disableB()
        {
            TOGGLE_B.BackgroundImage = TOGGLE_OFF;
            ToggleB = false;
        }

        private void enableB()
        {
            TOGGLE_B.BackgroundImage = TOGGLE_ON;
            ToggleB = true;
        }

        private void loadingBoards()
        {
            if (!File.Exists(MainDirectory + @"\keyboards.inf"))
            {
                //create file
                if (!Directory.Exists(MainDirectory))
                {
                    Directory.CreateDirectory(MainDirectory);
                }

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

                    KeyBoard obj = new KeyBoard();
                    obj.Location = new Point(32, 31);
                    obj.Visible = false;
                    this.Controls.Add(obj);

                    obj.setKeyBoardName(splits[1]);
                    obj.setKeyboardUuid(splits[0]);
                    obj.setComPort(splits[2]);

                    _listkeyboardElement.addItem(splits[1], splits[0], splits[2], obj);

                    obj.loadKeys(MainDirectory);

                    _keyboardList.Add(obj);

                    count++;
                }
            }

            if(count == 0)
            {
                _listkeyboardElement.Visible = false;
                _addKeyboardContr.Visible = true;
            }

        }

        void onKeyDown(object sender, KeyEventArgs e)
        {
            Connector c = sender as Connector;

            foreach (KeyBoard aKeyBoard in _keyboardList)
            {
                aKeyBoard.keyDown(e.Key, c.DynamicId, ToggleB);
            }
        }

        void onKeyUp(object sender, KeyEventArgs e)
        {

            Connector c = sender as Connector;
            foreach (KeyBoard aKeyBoard in _keyboardList)
            {
                aKeyBoard.keyUp(e.Key, c.DynamicId, ToggleB);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _connectorList.Clear();

            foreach (KeyBoard kb in _keyboardList)
            {
                string comport = getPortFromId(kb.getKeyboardUuid());
                if(comport == null)
                {
                    this.Invoke(new Action(() => {
                        WARRNING_BUTTON.Visible = true;
                        ERROR_LABEL.Text = kb.getKeyboardName() + " --> not found!";
                    }));
                }
                else
                {
                    Connector conect1 = new Connector();
                    conect1.DynamicId = kb.getKeyboardUuid();
                    conect1.setup(comport, 115200);
                    conect1.openPort();
                    conect1.KeyDown += onKeyDown;

                    _connectorList.Add(conect1);
                }

            }
        }

        private void KEYBOARD_LIST_CLICKED(object sender, EventArgs e)
        {
            foreach(KeyBoard aKeyboard in _keyboardList)
            {
                aKeyboard.Visible = false;
            }

            _listkeyboardElement.Visible = true;
            _listkeyboardElement.BringToFront();
        }

        private void userSelectedKeyboard(object sender, ItemName e)
        {
            foreach(KeyBoard aKeyboard in _keyboardList)
            {
                if(aKeyboard.getKeyboardName() == e.Name)
                {
                    aKeyboard.Visible = true;
                    aKeyboard.BringToFront();
                    _listkeyboardElement.Visible = false;
                }
                else
                {
                    aKeyboard.Visible = false;

                }
            }
        }

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

        private void ADD_KEYBOARD_BUTTON_Click(object sender, EventArgs e)
        {
            _addKeyboardContr.Visible = true;
            _addKeyboardContr.BringToFront();

        }

        private void NOTIFY_ICO_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void NOTIFY_ICO_CONTENT_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Text == "Close")
            {
                this.Close();
            }
            else if(e.ClickedItem.Text == "Open")
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

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

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WmShowme)
            {
                showMe();
            }
            base.WndProc(ref m);
        }

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

        private void PERF_MODE_BUTTON_Click(object sender, EventArgs e)
        {
            
        }

        private void ERROR_MANAGE_BUTTON_Click(object sender, EventArgs e)
        {
            _errorManagePanel.Show();
            _errorManagePanel.BringToFront();
        }
    }
}
