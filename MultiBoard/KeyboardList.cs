using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard
{
    public partial class KeyboardList : UserControl
    {
        public event EventHandler<itemName> SelectedItem;

        private Point NextPoint = new Point(31, 31);

        private List<KeyboardListPanel> kblp = new List<KeyboardListPanel>();

        public KeyboardList()
        {
            InitializeComponent();
        }

        public void loaditems(string[] items)
        {
            kblp.Clear();

            foreach (string aItem in items)
            {
                string[] splits = aItem.Split('|');
                addItem(splits[0], splits[1], "");
            }
        }

        public void addItem(string itemName, string uuidItem, string comportItem)
        {
            KeyboardListPanel obj = new KeyboardListPanel(itemName, uuidItem);
            obj.Location = NextPoint;
            obj.Visible = true;
            obj.BoardSettingsClicked += BSclikced;
            obj.OpenBoardClicked += OBclicked;
            MAIN_PANEL.Controls.Add(obj);

            kblp.Add(obj);

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

        private void OBclicked(object sender, EventArgs e)
        {
            foreach(KeyboardListPanel k in kblp)
            {
                if(k == sender)
                {
                    SelectedItem(this, new itemName() { name = k.kbname });
                }
            }
            
        }

        private void BSclikced(object sender, EventArgs e)
        {
            
        }
    }

    public class itemName : EventArgs
    {
        public string name { get; set; }
    }
}
