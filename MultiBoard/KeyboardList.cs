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
        public event EventHandler<itemName> SettingsSelectedItem;

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
                ListViewItem item = new ListViewItem(splits[1]);
                item.SubItems.Add(splits[0]);

                //listView1.Items.Add(item);
                
            }
        }

        public void addItem(string itemName, string uuidItem, string comportItem)
        {
            KeyboardListPanel obj = new KeyboardListPanel(itemName, uuidItem);
            obj.Location = new Point(30,30);
            obj.Visible = true;
            MAIN_PANEL.Controls.Add(obj);

            kblp.Add(obj);
        }

    }

    public class itemName : EventArgs
    {
        public string name { get; set; }
    }
}
