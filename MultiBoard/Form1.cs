using MultiBoard.overlays;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard
{
    public partial class MultiBoard : Form
    {
        //variables
        //==================================
        public string MAIN_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MultiBoard";
        public bool toggleB = true;
        public List<KeyBoard> keyboardList = new List<KeyBoard>();
        private List<connector> connectorList = new List<connector>();
        KeyboardList ListkeyboardElement;
        KeyboardScanner scanner = new KeyboardScanner();
        addKeyboard AddKeyboardContr;
        ErrorOptions errorContr = new ErrorOptions();
        LoadingMainOverlay LoadOverlay = new LoadingMainOverlay();

        //resouces images
        //===============================
        Image TOGGLE_ON = Properties.Resources.TOGGLE_ON;
        Image TOGGLE_OFF = Properties.Resources.TOGGLE_OFF;

        //drag bar
        //===============================
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MultiBoard()
        {
            InitializeComponent();
            
            //loadOverlay control
            LoadOverlay.Location = new Point(0, 0);
            this.Controls.Add(LoadOverlay);
            LoadOverlay.BringToFront();

            //keyboard list control
            ListkeyboardElement = new KeyboardList();
            ListkeyboardElement.SelectedItem += UserSelectedKeyboard;
            ListkeyboardElement.Location = new Point(32, 31);
            this.Controls.Add(ListkeyboardElement);

            //errorcontr
            errorContr.ignoreClicked += errorIgnore;
            errorContr.reloadClicked += errorReload;
            errorContr.viewClicked += errorView;

            Point p = new Point();
            p.X = this.Width - errorContr.Width - 5;
            p.Y = this.Height - errorContr.Height - 34 - 5;
            errorContr.Location = p;

            errorContr.Visible = false;
            this.Controls.Add(errorContr);

            //addkeyboard control
            AddKeyboardContr = new addKeyboard();
            AddKeyboardContr.Location = new Point(32, 31); ;
            this.Controls.Add(AddKeyboardContr);
            AddKeyboardContr.AddKeyboarde += keyboardAdded;

            //loading keyboards
            backgroundWorker2.RunWorkerAsync();
        }

        private void errorView(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void errorReload(object sender, EventArgs e)
        {
            reloadKeyboards();
        }

        private void errorIgnore(object sender, EventArgs e)
        {
            ERROR_LABEL.Text = "";
            errorContr.Hide();
            WARRNING_BUTTON.Visible = false;
        }

        private void keyboardAdded(object sender, EventArgs e)
        {
            string[] allLines = File.ReadAllLines(MAIN_DIRECTORY + @"\keyboards.inf");
            List<string> sstring = allLines.ToList();

            string name = AddKeyboardContr.kbName;
            string uuid = AddKeyboardContr.kbId;
            string port = AddKeyboardContr.kbPort;
            
            sstring.Add(AddKeyboardContr.kbId + "|" + AddKeyboardContr.kbName + "|" + AddKeyboardContr.kbPort + "\n");
            string[] writeAll = sstring.ToArray();

            File.WriteAllLines(MAIN_DIRECTORY + @"\keyboards.inf", writeAll, Encoding.UTF8);

            KeyBoard obj = new KeyBoard();
            obj.Location = new Point(32, 31);
            obj.Visible = true;
            this.Controls.Add(obj);
            obj.BringToFront();

            obj.setKeyBoardName(name);
            obj.setKeyboardUUID(uuid);
            obj.setComPort(port);

            ListkeyboardElement.addItem(name, uuid, port);

            obj.loadKeys(MAIN_DIRECTORY);

            keyboardList.Add(obj);

            //unloading
            foreach (connector c in connectorList)
            {
                c.closePort();
            }
            connectorList.Clear();

            //loading
            backgroundWorker1.CancelAsync();
            backgroundWorker1.RunWorkerAsync();
        }


        private void MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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
            if (toggleB == true)
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
            toggleB = false;
        }

        private void enableB()
        {
            TOGGLE_B.BackgroundImage = TOGGLE_ON;
            toggleB = true;
        }

        private void loadingBoards()
        {
            if (!File.Exists(MAIN_DIRECTORY + @"\keyboards.inf"))
            {
                //greate file
                if (!Directory.Exists(MAIN_DIRECTORY))
                {
                    Directory.CreateDirectory(MAIN_DIRECTORY);
                }

                File.Create(MAIN_DIRECTORY + @"\keyboards.inf").Close();
            }

            int counter = 0;
            string line;
            List<string> temp = new List<string>();
            string[] boards;

            // read main file
            //============================
            System.IO.StreamReader file =
                new System.IO.StreamReader(MAIN_DIRECTORY + @"\keyboards.inf");
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
                    obj.setKeyboardUUID(splits[0]);
                    obj.setComPort(splits[2]);

                    ListkeyboardElement.addItem(splits[1], splits[0], splits[2]);

                    obj.loadKeys(MAIN_DIRECTORY);

                    keyboardList.Add(obj);

                    count++;
                }
            }

            if(count == 0)
            {
                ListkeyboardElement.Visible = false;
                AddKeyboardContr.Visible = true;
            }

        }

        void onKeyDown(object sender, KeyEventArgs e)
        {
            connector c = sender as connector;

            foreach (KeyBoard aKeyBoard in keyboardList)
            {
                aKeyBoard.keyDown(e.key, c.dynamicID, toggleB);
            }
        }

        void onKeyUp(object sender, KeyEventArgs e)
        {

            connector c = sender as connector;
            foreach (KeyBoard aKeyBoard in keyboardList)
            {
                aKeyBoard.keyUp(e.key, c.dynamicID, toggleB);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            connectorList.Clear();

            foreach (KeyBoard kb in keyboardList)
            {
                string comport = getPortFromID(kb.getKeyboardUUID());
                if(comport == null)
                {
                    this.Invoke(new Action(() => {
                        WARRNING_BUTTON.Visible = true;
                        ERROR_LABEL.Text = kb.getKeyboardName() + " --> not found!";
                    }));
                }
                else
                {
                    connector conect1 = new connector();
                    conect1.dynamicID = kb.getKeyboardUUID();
                    conect1.setup(comport, 115200);
                    conect1.openPort();
                    conect1.KeyDown += onKeyDown;

                    connectorList.Add(conect1);
                }

            }
        }

        private void KEYBOARD_LIST_CLICKED(object sender, EventArgs e)
        {
            foreach(KeyBoard aKeyboard in keyboardList)
            {
                aKeyboard.Visible = false;
            }

            ListkeyboardElement.Visible = true;
            ListkeyboardElement.BringToFront();
        }

        private void UserSelectedKeyboard(object sender, itemName e)
        {
            foreach(KeyBoard aKeyboard in keyboardList)
            {
                if(aKeyboard.getKeyboardName() == e.name)
                {
                    aKeyboard.Visible = true;
                    aKeyboard.BringToFront();
                    ListkeyboardElement.Visible = false;
                }
                else
                {
                    aKeyboard.Visible = false;

                }
            }
        }

        private string getPortFromID(string id)
        {
            int i = 0;

            foreach(string s in scanner.uuid)
            {
                int o = 0;

                if(s == id)
                {
                    foreach(string p in scanner.ports)
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
            AddKeyboardContr.Visible = true;
            AddKeyboardContr.BringToFront();

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
            if (errorContr.Visible == false)
            {
                errorContr.Visible = true;
                errorContr.BringToFront();
            }
            else
            {
                errorContr.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //scanning boards
            scanner.loadList(115200);
            this.Invoke(new Action(() =>
            {
                loadingBoards();
                backgroundWorker1.RunWorkerAsync();
                LoadOverlay.Hide();
            }));
        }

        private void reloadKeyboards()
        {
            //LoadOverlay
            LoadOverlay.Show();
            LoadOverlay.BringToFront();

            //resetting
            ERROR_LABEL.Text = "";
            errorContr.Hide();
            WARRNING_BUTTON.Visible = false;

            //unloading
            foreach (connector c in connectorList)
            {
                c.closePort();
            }
            connectorList.Clear();

            foreach (KeyBoard k in keyboardList)
            {
                k.Dispose();
            }
            keyboardList.Clear();


            ListkeyboardElement.Dispose();
            ListkeyboardElement = new KeyboardList();
            ListkeyboardElement.SelectedItem += UserSelectedKeyboard;
            ListkeyboardElement.Location = new Point(32, 31);
            this.Controls.Add(ListkeyboardElement);

            //loading
            backgroundWorker1.CancelAsync();
            backgroundWorker2.RunWorkerAsync();

        }
    }
}
