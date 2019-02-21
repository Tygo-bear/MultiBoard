using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MultiBoard.Keyboard
{
    public partial class KeyboardList : UserControl
    {
        public event EventHandler<ItemName> SelectedItem;
        public event EventHandler UpdateKeyboards;

        private Point NextPoint = new Point(31, 31);
        private List<KeyboardListPanel> _kblp = new List<KeyboardListPanel>();

        private string _mainDirectory;

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

            UpdateKeyboards(this, EventArgs.Empty);
        }

        private void keyboardDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public class ItemName : EventArgs
    {
        public string Name { get; set; }
    }
}
