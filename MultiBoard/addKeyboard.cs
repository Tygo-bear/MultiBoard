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
    public partial class addKeyboard : UserControl
    {
        private bool refreshing = false;
        private List<string> IDs = new List<string>();
        private List<string> ports = new List<string>();

        private AutoAddKeyboard aakb;
        private ManuallyAddKeyboard makb;

        private List<string> IDsBlackList;

        public addKeyboard()
        {
            InitializeComponent();

            //start scanner
            //==============
            refreshing = true;
            AUTO_ADD_LABEL.Text = "Searching...";
            refreshKeyboards();
            REFRESH_BUTTON.Enabled = true;
            displayKeyboardCount();
        }

        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            if(refreshing == false)
            {
                refreshing = true;
                AUTO_ADD_LABEL.Text = "Searching...";
                REFRESH_BUTTON.Enabled = false;
                refreshKeyboards();
                REFRESH_BUTTON.Enabled = true;
                displayKeyboardCount();

            }
            else
            {
                REFRESH_BUTTON.Enabled = false;
            }
        }

        private void displayKeyboardCount()
        {
            if (IDs.Count() > 0)
            {
                AUTO_ADD_LABEL.Text = IDs.Count() + " keyboards found";
            }
            else
            {
                AUTO_ADD_LABEL.Text = "No keyboards found";
            }
        }

        private void refreshKeyboards()
        {
            KeyboardScanner kbs = new KeyboardScanner();
            kbs.loadList(115200);

            filterKeyboards(kbs.ports, kbs.uuid);
            refreshing = false;
        }

        public void idBlackListUpdate(List<string> blackIDs)
        {
            IDsBlackList = blackIDs;
        }

        private void filterKeyboards(List<string> AllPorts, List<string> AllIds)
        {
            IDs.Clear();
            ports.Clear();

            int index = 0;
            foreach(string s in AllIds)
            {
                bool newKB = true;
                foreach(string bs in IDsBlackList)
                {
                    if(s == bs)
                    {
                        newKB = false;
                    }
                }

                if(newKB == true)
                {
                    IDs.Add(s);
                    int indexP = 0;
                    foreach(string p in AllPorts)
                    {
                        if(index == indexP)
                        {
                            ports.Add(p);
                        }
                        indexP++;
                    }
                }

                index++;
            }
        }

        private void CANCEL_PANEL_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AUTO_ADD_PANEL_Click(object sender, EventArgs e)
        {
            if (IDs.Count() > -1)
            {
                aakb = new AutoAddKeyboard();
                aakb.Location = new Point(0, 0);
                aakb.IDs = IDs;
                aakb.Ports = ports;
                aakb.loadKbList();
                this.Controls.Add(aakb);
                aakb.BringToFront();
            }
        }

        private void MANUAL_ADD_PANEL_Click(object sender, EventArgs e)
        {
            makb = new ManuallyAddKeyboard();
            makb.Location = new Point(0, 0);
            this.Controls.Add(makb);
            makb.BringToFront();
        }
    }
}
