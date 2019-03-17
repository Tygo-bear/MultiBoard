using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MultiBoard.overlays;

namespace MultiBoard.Keyboard
{
    public partial class KeyboardList : UserControl
    {
        public event EventHandler<ItemName> SelectedItem;
        public event EventHandler<KeyboardToArgs> UpdateKeyboards;

        private Point NextPoint = new Point(31, 31);
        private List<KeyboardListPanel> _kblp = new List<KeyboardListPanel>();

        private string _mainDirectory;
        private string _undo;

        public KeyboardList(string mainDire)
        {
            InitializeComponent();
            _mainDirectory = mainDire;
        }

        public void addItem(string itemName, string uuidItem, string comportItem, KeyBoard board)
        {
            KeyboardListPanel obj = new KeyboardListPanel(itemName, uuidItem, comportItem, board);
            obj.Location = NextPoint;
            obj.Visible = true;
            obj.BoardSettingsClicked += bsClikced;
            obj.OpenBoardClicked += obClicked;
            MAIN_PANEL.Controls.Add(obj);

            _kblp.Add(obj);

            if(NextPoint.X == 31)
            {
                NextPoint.X = NextPoint.X + obj.Width + 31;
            }
            else
            {
                NextPoint.X = 31;
                NextPoint.Y = NextPoint.Y + obj.Height + 31;
            }
        }

        private void obClicked(object sender, EventArgs e)
        {
            foreach(KeyboardListPanel k in _kblp)
            {
                if(k == sender)
                {
                    SelectedItem(this, new ItemName() { Name = k.KbName });
                }
            }
            
        }

        private void bsClikced(object sender, EventArgs e)
        {
            KeyboardListPanel k = sender as KeyboardListPanel;
            KeyboardSettings obj = new KeyboardSettings(k.KbName, k.KbUuid, k.KbPort, k.connectedBoard);

            obj.Save += keyboardSave;
            obj.Delete += keyboardDelete;

            obj.Location = new Point(0, 0);
            obj.Visible = true;
            this.Controls.Add(obj);
            obj.BringToFront();

        }

        private void keyboardSave(object sender, EventArgs e)
        {
            KeyboardSettings k = sender as KeyboardSettings;
            KeyBoard b = k.connectedKeyboard;

            //TODO error naming
            //throw new NotImplementedException();

            if (File.Exists(_mainDirectory + @"\" + b.getKeyboardName() + ".inf"))
            {
                File.Move(_mainDirectory + @"\" + b.getKeyboardName() + ".inf", _mainDirectory + @"\" + k.KbName + ".inf");
            }
            else
            {
                Console.WriteLine("File rename error");
            }


            b.setKeyBoardName(k.KbName);
            b.setKeyboardUuid(k.KbUuid);
            b.setComPort(k.KbPort);

            UpdateKeyboards(this, new KeyboardToArgs() { keybo = null });
        }

        private void keyboardDelete(object sender, EventArgs e)
        {
            KeyboardSettings k = sender as KeyboardSettings;
            KeyBoard b = k.connectedKeyboard;

            if (File.Exists(_mainDirectory + @"\" + b.getKeyboardName() + ".inf"))
            {
                if (Directory.Exists(_mainDirectory + @"\.del"))
                {
                    if (File.Exists(_mainDirectory + @"\.del\keyboards.inf"))
                    {
                        File.Delete(_mainDirectory + @"\.del\keyboards.inf");
                    }
                    if (File.Exists(_mainDirectory + @"\.del" + @"\" + b.getKeyboardName() + ".inf"))
                    {
                        File.Delete(_mainDirectory + @"\.del" + @"\" + b.getKeyboardName() + ".inf");
                    }


                    File.Copy(_mainDirectory + @"\keyboards.inf"
                        , _mainDirectory + @"\.del\keyboards.inf");
                    File.Move(_mainDirectory + @"\" + b.getKeyboardName() + ".inf"
                        , _mainDirectory + @"\.del" + @"\" + b.getKeyboardName() + ".inf");

                    
                }
                else
                {
                    Directory.CreateDirectory(_mainDirectory + @"\.del");
                    File.Copy(_mainDirectory + @"\keyboards.inf"
                        , _mainDirectory + @"\.del\keyboards.inf");
                    File.Move(_mainDirectory + @"\" + b.getKeyboardName() + ".inf"
                        , _mainDirectory + @"\.del" + @"\" + b.getKeyboardName() + ".inf");

                }

                _undo = b.getKeyboardName();
                createUndo("Undo " + b.getKeyboardName() + "delete");

            }
            else
            {
                Console.WriteLine("File delete error");
            }

            foreach (KeyboardListPanel p in _kblp)
            {
                if (p.connectedBoard == b)
                {
                    p.Dispose();
                }
            }

            k.Dispose();
            UpdateKeyboards(this, new KeyboardToArgs() {keybo = b});
        }

        private void createUndo(string mes)
        {
            UndoKeyboardDelete u = new UndoKeyboardDelete();
            u.text = mes;
            u.Undo += UOnUndo;
            u.Location = new Point(this.Width-u.Width, this.Height - u.Height);
            Controls.Add(u);
            u.BringToFront();
            this.Show();
        }

        private void UOnUndo(object sender, EventArgs e)
        {
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

            Application.Restart();
            Environment.Exit(0);
        }
    }

    public class ItemName : EventArgs
    {
        public string Name { get; set; }
    }

    public class KeyboardToArgs : EventArgs
    {
        public KeyBoard keybo { get; set; }
    }
}
