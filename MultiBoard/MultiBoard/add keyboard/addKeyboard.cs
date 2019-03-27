using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MultiBoard.KeyboardElements.KeyboardScannerElements;

namespace MultiBoard.add_keyboard
{
    public partial class addKeyboard : UserControl
    {
        private bool _refreshing = false;
        private List<string> _IDs = new List<string>();
        private List<string> _ports = new List<string>();

        private AutoAddKeyboard _autoAddKeyboard;
        private ManuallyAddKeyboard _manuallyAddKeyboard;

        public event EventHandler AddKeyboard;
        public string KeyboardName;
        public string KeyboardID;
        public string KeyboardPort;

        //List of keyboards to ignore
        private List<string> _IDsBlackList;

        public addKeyboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// User clicked "refresh" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            //Check if it already started
            if(_refreshing == false)
            {
                //start refreshing keyboard list
                _refreshing = true;
                AUTO_ADD_LABEL.Text = "Searching...";
                REFRESH_BUTTON.Enabled = false;

                refreshKeyboards();
            }
            else
            {
                REFRESH_BUTTON.Enabled = false;
            }
        }

        /// <summary>
        /// Display keyboard number sentence
        /// </summary>
        private void displayKeyboardCount()
        {
            if (_IDs.Any())
            {
                if (_IDs.Count() > 1)
                {
                    //more than 1 keyboard found
                    AUTO_ADD_LABEL.Text = _IDs.Count() + " keyboards found";
                }
                else
                {
                    //1 keyboard found
                    AUTO_ADD_LABEL.Text = _IDs.Count() + " keyboard found";
                }
            }
            else
            {
                //no keyboards found
                AUTO_ADD_LABEL.Text = "No keyboards found";
            }
        }

        /// <summary>
        /// Start refreshing keyboard list with background worker
        /// </summary>
        private void refreshKeyboards()
        {
            BACKGROUND_SCANNER.RunWorkerAsync();
        }

        /// <summary>
        /// Update black list of keyboard IDs
        /// </summary>
        /// <param name="blackIDs">
        /// List of IDs
        /// </param>
        public void idBlackListUpdate(List<string> blackIDs)
        {
            _IDsBlackList = blackIDs;
        }

        /// <summary>
        /// Filter to list of keyboard-scanner results and
        /// generate list of new keyboards
        /// </summary>
        /// <param name="allPorts">
        /// List of all com Ports
        /// </param>
        /// <param name="allIds">
        /// List of all IDs
        /// </param>
        private void filterKeyboards(List<string> allPorts, List<string> allIds)
        {
            _IDs.Clear();
            _ports.Clear();

            int index = 0;
            foreach(string s in allIds)
            {
                bool newKB = true;
                if (_IDsBlackList != null)
                {
                    foreach (string bs in _IDsBlackList)
                    {
                        if (s == bs)
                        {
                            newKB = false;
                        }
                    }
                }

                if(newKB == true && s != "NONE")
                {
                    _IDs.Add(s);
                    int indexP = 0;
                    foreach(string p in allPorts)
                    {
                        if(index == indexP)
                        {
                            _ports.Add(p);
                        }
                        indexP++;
                    }
                }

                index++;
            }
        }

        /// <summary>
        /// User clicked "cancel" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CANCEL_PANEL_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        /// <summary>
        /// User clicked "auto add" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AUTO_ADD_PANEL_Click(object sender, EventArgs e)
        {
            //Check if there are new keyboards found
            if (_IDs.Any())
            {
                makeAutoAddControl();
            }
        }

        /// <summary>
        /// Create and place "AutoAdd" control
        /// </summary>
        private void makeAutoAddControl()
        {
            _autoAddKeyboard = new AutoAddKeyboard();
            _autoAddKeyboard.AddClicked += autoAddKeyboardEvent;
            _autoAddKeyboard.Location = new Point(0, 0);
            _autoAddKeyboard.IDs = _IDs;
            _autoAddKeyboard.Ports = _ports;
            _autoAddKeyboard.loadKbList();
            this.Controls.Add(_autoAddKeyboard);
            _autoAddKeyboard.BringToFront();
        }

        /// <summary>
        /// User clicked "manual add" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MANUAL_ADD_PANEL_Click(object sender, EventArgs e)
        {
            makeManualAddControl();
        }

        /// <summary>
        /// Create and place "ManualAdd" control
        /// </summary>
        private void makeManualAddControl()
        {
            _manuallyAddKeyboard = new ManuallyAddKeyboard();
            _manuallyAddKeyboard.Location = new Point(0, 0);
            _manuallyAddKeyboard.KeyboardAdded += manuallyAddKeyboardEvent;
            this.Controls.Add(_manuallyAddKeyboard);
            _manuallyAddKeyboard.BringToFront();
        }

        /// <summary>
        /// Call "add keyboard" event
        /// </summary>
        protected virtual void onAddKeyboard()
        {
            if (AddKeyboard != null)
            {
                AddKeyboard(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// keyboard added (auto add control)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoAddKeyboardEvent(object sender, EventArgs e)
        {
            KeyboardName = _autoAddKeyboard.KeyboardName;
            KeyboardID = _autoAddKeyboard.KeyboardUuid;
            KeyboardPort = _autoAddKeyboard.KeyboardPort;
            onAddKeyboard();
        }

        /// <summary>
        /// Keyboard added (manually add control)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manuallyAddKeyboardEvent(object sender, EventArgs e)
        {
            KeyboardName = _manuallyAddKeyboard.keyboardName;
            KeyboardID = _manuallyAddKeyboard.keyboardId;
            KeyboardPort = _manuallyAddKeyboard.keyboardComPort;
            onAddKeyboard();
        }

        /// <summary>
        /// Update list of new keyboards as background-worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BACKGROUND_SCANNER_DoWork(object sender, DoWorkEventArgs e)
        {
            //Start a keyboardScanner
            KeyboardScanner kbs = new KeyboardScanner();
            kbs.loadList(115200);

            //Filter keyboards
            filterKeyboards(kbs.Ports, kbs.Uuid);

            //Update control
            _refreshing = false;
            this.Invoke(new Action(() => {
                REFRESH_BUTTON.Enabled = true;
                displayKeyboardCount();
            }));
            
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AUTO_ADD_HOVER_TIMER_Tick(object sender, EventArgs e)
        {
            AUTO_ADD_PANEL.BackColor = Color.DarkGray;
            REFRESH_BUTTON.BackColor = Color.DarkGray;
            AUTO_ADD_HOVER_TIMER.Stop();
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MANUAL_ADD_HOVER_TIMER_Tick(object sender, EventArgs e)
        {
            MANUAL_ADD_PANEL.BackColor = Color.DarkGray;
            MANUAL_ADD_HOVER_TIMER.Stop();
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CANCEL_HOVER_TIMER_Tick(object sender, EventArgs e)
        {
            CANCEL_PANEL.BackColor = Color.DarkGray;
            CANCEL_HOVER_TIMER.Stop();
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AUTO_ADD_PANEL_MouseEnter(object sender, EventArgs e)
        {
            AUTO_ADD_HOVER_TIMER.Stop();
            AUTO_ADD_PANEL.BackColor = Color.Gray;
            REFRESH_BUTTON.BackColor = Color.Gray;
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AUTO_ADD_PANEL_MouseLeave(object sender, EventArgs e)
        {
            AUTO_ADD_HOVER_TIMER.Start();
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MANUAL_ADD_PANEL_MouseEnter(object sender, EventArgs e)
        {
            MANUAL_ADD_HOVER_TIMER.Stop();
            MANUAL_ADD_PANEL.BackColor = Color.Gray;
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MANUAL_ADD_PANEL_MouseLeave(object sender, EventArgs e)
        {
            MANUAL_ADD_HOVER_TIMER.Start();
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CANCEL_PANEL_MouseEnter(object sender, EventArgs e)
        {
            CANCEL_HOVER_TIMER.Stop();
            CANCEL_PANEL.BackColor = Color.Gray;
        }

        /// <summary>
        /// Hover effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CANCEL_PANEL_MouseLeave(object sender, EventArgs e)
        {
            CANCEL_HOVER_TIMER.Start();
        }
    }
}
