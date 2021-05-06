using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiBoardKeyboard;

namespace MultiBoard.overlays
{
    public partial class HotKeyCreator : UserControl
    {
        public event EventHandler<KeyTask> UserMadeSelection; 

        private Random _random = new Random();
        private string _selection = "";
        public HotKeyCreator()
        {
            InitializeComponent();
        }

        private void CLOSE_B_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OK_BUTTON_Click(object sender, EventArgs e)
        {
            GenerateHotkeyScript(SinglePushModeRadioButton.Checked);
            OnUserMadeSelection(_selection);
            this.Dispose();
        }

        private void LastKeyTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            if (e.Alt == false && e.Control == false)
            {
                LastKeyTextBox.Text = e.KeyCode.ToString().ToLower();
            }

            e.SuppressKeyPress = true;
        }

        private void HotKeyCreator_Load(object sender, EventArgs e)
        {
            FirstKeySelectComboBox.SelectedIndex = 0;
            SecondKeySelectComboBox.SelectedIndex = 0;
        }

        private void RandomHotkeyButton_Click(object sender, EventArgs e)
        {
            FirstKeySelectComboBox.SelectedIndex = 2;
            SecondKeySelectComboBox.SelectedIndex = _random.Next(1, SecondKeySelectComboBox.Items.Count);

            string[] l = Properties.Resources.RandomHotkey.Split(',');
            LastKeyTextBox.Text = l.ElementAt(_random.Next(0, l.Length)).ToLower();
        }

        private void GenerateHotkeyScript(bool single)
        {
            if (single)
            {
                List<string> StartTemp = new List<string>();

                List<string> EndTemp = new List<string>();

                if (SecondKeySelectComboBox.Text == "NONE")
                {
                    string temp1 = "";
                    string temp2 = "";

                    temp1 = "{" + FirstKeySelectComboBox.Text + " down}";
                    StartTemp.Add(temp1);
                    temp2 = "{" + FirstKeySelectComboBox.Text + " up}";
                    EndTemp.Add(temp2);

                    temp1 = "{" + LastKeyTextBox.Text + "}";
                    StartTemp.Add(temp1);

                    EndTemp.Reverse();
                    StartTemp.AddRange(EndTemp);
                    _selection = String.Join("", StartTemp.ToArray());
                }
                else
                {
                    string temp1 = "";
                    string temp2 = "";

                    temp1 = "{" + FirstKeySelectComboBox.Text + " down}";
                    StartTemp.Add(temp1);
                    temp2 = "{" + FirstKeySelectComboBox.Text + " up}";
                    EndTemp.Add(temp2);

                    temp1 = "{" + SecondKeySelectComboBox.Text + " down}";
                    StartTemp.Add(temp1);
                    temp2 = "{" + SecondKeySelectComboBox.Text + " up}";
                    EndTemp.Add(temp2);

                    temp1 = "{" + LastKeyTextBox.Text + "}";
                    StartTemp.Add(temp1);

                    EndTemp.Reverse();
                    StartTemp.AddRange(EndTemp);
                    _selection = String.Join("", StartTemp.ToArray());
                }
            }
            else
            {
                List<string> StartTemp = new List<string>();

                List<string> EndTemp = new List<string>();

                if (SecondKeySelectComboBox.Text == "NONE")
                {
                    string temp1 = "";
                    string temp2 = "";

                    temp1 = "{" + FirstKeySelectComboBox.Text + " down}";
                    StartTemp.Add(temp1);
                    temp2 = "{" + FirstKeySelectComboBox.Text + " up}";
                    EndTemp.Add(temp2);

                    temp1 = "{" + LastKeyTextBox.Text + " down}";
                    StartTemp.Add(temp1);
                    temp2 = "{" + LastKeyTextBox.Text + " up}";
                    EndTemp.Add(temp2);

                    EndTemp.Reverse();
                    StartTemp.AddRange(EndTemp);
                    _selection = String.Join("", StartTemp.ToArray());
                }
                else
                {
                    string temp1 = "";
                    string temp2 = "";

                    temp1 = "{" + FirstKeySelectComboBox.Text + " down}";
                    StartTemp.Add(temp1);
                    temp2 = "{" + FirstKeySelectComboBox.Text + " up}";
                    EndTemp.Add(temp2);

                    temp1 = "{" + SecondKeySelectComboBox.Text + " down}";
                    StartTemp.Add(temp1);
                    temp2 = "{" + SecondKeySelectComboBox.Text + " up}";
                    EndTemp.Add(temp2);

                    temp1 = "{" + LastKeyTextBox.Text + " down}";
                    StartTemp.Add(temp1);
                    temp2 = "{" + LastKeyTextBox.Text + " up}";
                    EndTemp.Add(temp2);

                    EndTemp.Reverse();
                    StartTemp.AddRange(EndTemp);
                    _selection = String.Join("", StartTemp.ToArray());
                }
            }

            _selection = "SendInput, " + _selection;
        }

        protected virtual void OnUserMadeSelection(string e)
        {
            if (UserMadeSelection != null)
            {
                UserMadeSelection?.Invoke(this, new KeyTask(){OneLineAhkScript = e });
            }
        }

    }
}
