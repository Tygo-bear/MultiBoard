using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MultiBoard.Keyboard
{
    public partial class KeyboardList : UserControl
    {
        public event EventHandler<ItemName> SelectedItem;

        private Point NextPoint = new Point(31, 31);

        private List<KeyboardListPanel> _kblp = new List<KeyboardListPanel>();

        public KeyboardList()
        {
            InitializeComponent();
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

            //TODO save to file
            throw new NotImplementedException();

            b.setKeyBoardName(k.KbName);
            b.setKeyboardUuid(k.KbUuid);
            b.setComPort(k.KbPort);

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
