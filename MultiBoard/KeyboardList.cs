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

        public KeyboardList()
        {
            InitializeComponent();
        }

        public void loaditems(string[] items)
        {
            listView1.Clear();

            foreach (string aItem in items)
            {
                string[] splits = aItem.Split('|');
                ListViewItem item = new ListViewItem(splits[1]);
                item.SubItems.Add(splits[0]);

                listView1.Items.Add(item);
                
            }
        }

        public void addItem(string itemName, string uuidItem, string comportItem)
        {
            ListViewItem item = new ListViewItem(itemName);
            item.SubItems.Add(uuidItem);

            listView1.Items.Add(item);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                SelectedItem(this, new itemName() { name = listView1.SelectedItems[0].Text});
            }

        }
    }

    public class itemName : EventArgs
    {
        public string name { get; set; }
    }
}
