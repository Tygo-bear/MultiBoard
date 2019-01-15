﻿using System;
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
    public partial class Form1 : Form
    {
        //variables
        //==================================
        public string MAIN_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MultiBoard";
        public bool toggleB = true;
        public List<KeyBoard> keyboardList = new List<KeyBoard>();
        private List<connector> connectorList = new List<connector>();
        KeyboardList ListkeyboardElement;
        KeyboardScanner scanner = new KeyboardScanner();

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

        public Form1()
        {
            InitializeComponent();

            ListkeyboardElement = new KeyboardList();
            ListkeyboardElement.SelectedItem += UserSelectedKeyboard;
            ListkeyboardElement.Location = new Point(31, 31);
            this.Controls.Add(ListkeyboardElement);

            scanner.loadList(115200);

            loadingBoards();
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
            this.Close();
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
            string[] boards = { "" };

            // read main file
            //============================
            System.IO.StreamReader file =
                new System.IO.StreamReader(MAIN_DIRECTORY + @"\keyboards.inf");
            while ((line = file.ReadLine()) != null)
            {
                boards[counter] = line;
                counter++;
            }

            file.Close();

            //add boards to form
            //=================================

            for (int i = 0; i < boards.Length; i++)
            {
                if (boards[i] == "" || boards[i] == null)
                {

                }
                else
                {
                    string[] splits = boards[i].Split('|');

                    KeyBoard obj = new KeyBoard();
                    obj.Location = new Point(31, 31);
                    obj.Visible = false;
                    this.Controls.Add(obj);

                    obj.setKeyBoardName(splits[1]);
                    obj.setKeyboardUUID(splits[0]);
                    obj.setComPort(splits[2]);

                    ListkeyboardElement.addItem(splits[1], splits[0], splits[2]);

                    obj.loadKeys(MAIN_DIRECTORY);

                    keyboardList.Add(obj);
                }
            }
        }

        void onKeyDown(object sender, KeyEventArgs e)
        {
            foreach(KeyBoard aKeyBoard in keyboardList)
            {
                aKeyBoard.keyDown(e.key, toggleB);
            }
        }

        void onKeyUp(object sender, KeyEventArgs e)
        {
            foreach (KeyBoard aKeyBoard in keyboardList)
            {
                aKeyBoard.keyUp(e.key, toggleB);
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
                    WARRNING_BUTTON.Visible = true;
                }
                else
                {
                    connector conect1 = new connector();
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
        }

        private void UserSelectedKeyboard(object sender, itemName e)
        {
            foreach(KeyBoard aKeyboard in keyboardList)
            {
                if(aKeyboard.getKeyboardName() == e.name)
                {
                    aKeyboard.Visible = true;
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
    }
}
