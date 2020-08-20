using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiBoard.KeyboardElements.KeyElements;
using MultiBoardKeyboard;

namespace MultiBoard.scripts
{
    public partial class ScriptCallMenuUC : UserControl
    {
        public event EventHandler<MTask> ScriptCallingMade;

        private bool runDrawUpdates = true;
        public List<Script> ScriptList;

        public ScriptCallMenuUC()
        {
            InitializeComponent();
        }

        public void DrawTask(KeyboardElements.KeyElements.MTask t)
        {
            Clear();
            if (t.AhkScriptNameAndArgs != null)
            {
                List<string> tempList = t.AhkScriptNameAndArgs;
                if (tempList.Count >= 2)
                {
                    ScriptComboBox.Text = tempList[0];
                    FunctionTextBox.Text = tempList[1];

                    if (tempList.Count >= 3)
                    {
                        List<string> args = new List<string>(tempList);
                        args.RemoveRange(0, 2);

                        int i = 0;
                        runDrawUpdates = false;

                        foreach (Control argumentPanelControl in ArgumentPanel.Controls)
                        {
                            if (argumentPanelControl is Panel)
                            {
                                foreach (Control control in (argumentPanelControl as Panel).Controls)
                                {
                                    if (control is TextBox)
                                    {
                                        if (args.Count > i)
                                        {
                                            (control as TextBox).Text = args[i];
                                        }
                                        
                                    }
                                    else if (control is CheckBox)
                                    {
                                        if (args.Count > i)
                                        {
                                            (control as CheckBox).Checked = true;
                                        }
                                        else if (args.Count == i)
                                        {
                                            runDrawUpdates = true;
                                            (control as CheckBox).Checked = true;
                                            (control as CheckBox).Checked = false;
                                        }
                                    }
                                }
                            }

                            i++;
                        }

                        runDrawUpdates = true;

                    }
                }
            }
        }

        public void Clear()
        {
            checkBox10.Checked = false;
            ScriptComboBox.Text = "";
            FunctionTextBox.Text = "";
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            RedrawArgs();
        }

        private void RedrawArgs()
        {
            if (!runDrawUpdates)
            {
                return;
            }

            runDrawUpdates = false;

            bool currentChecked = true;
            foreach (Control control in ArgumentPanel.Controls)
            {
                if (control is Panel)
                {
                    Panel p = (control as Panel);
                    p.Visible = currentChecked;
                    foreach (Control pControl in p.Controls)
                    {
                        if (pControl is CheckBox)
                        {
                            CheckBox check = (pControl as CheckBox);
                            if (currentChecked == false)
                            {
                                check.Checked = false;
                            }
                            else
                            {
                                currentChecked = check.Checked;
                            }

                            foreach (Control pControl1 in p.Controls)
                            {
                                if (pControl1 is TextBox)
                                {
                                    (pControl1 as TextBox).Enabled = currentChecked;
                                }
                            }
                        }
                    }
                }
            }

            runDrawUpdates = true;
        }

        private void CLOSE_B_Click(object sender, EventArgs e)
        {
            this.Hide();
            panel1.BackColor = Color.FromName("Control");
        }

        private List<string> GetFunctionArgs()
        {
            List<string> retList = new List<string>();

            foreach (Control control in ArgumentPanel.Controls)
            {
                if (control is Panel)
                {
                    Panel p = (control as Panel);
                    if (p.Visible == false)
                    {
                        return retList;
                    }

                    string text = "";
                    bool submit = false;
                    foreach (Control pControl in p.Controls)
                    {
                        if (pControl is TextBox)
                        {
                            text = (pControl as TextBox).Text;
                            if(submit) { retList.Add(text); }
                        }
                        else if (pControl is CheckBox)
                        {
                            if ((pControl as CheckBox).Checked)
                            {
                                
                                submit = true;
                            }
                        }
                    }
                }
            }

            return retList;
        }

        private List<string> GenerateFunctionCalling()
        {
            List<string> retList = new List<string>();

            retList.Add(ScriptComboBox.Text);
            retList.Add(FunctionTextBox.Text);

            retList.AddRange(GetFunctionArgs());

            return retList;
        }

        private MTask GenerateTask()
        {
            MTask mTask = new MTask();
            mTask.AhkScriptNameAndArgs = GenerateFunctionCalling();
            if(ScriptList != null) { mTask.AssignScript(ScriptList);}

            return mTask;
        }

        public void UpdateScriptList(List<Script> sList)
        {
            ScriptList = sList;
            ScriptComboBox.Items.Clear();
            foreach (Script script in sList)
            {
                String[] spearator = { "/", @"\" };
                String[] strlist = script.ScriptLabel.Split(spearator,
                    StringSplitOptions.RemoveEmptyEntries);

                if (strlist.Length >= 1)
                {
                    ScriptComboBox.Items.Add(strlist[strlist.Length - 1]);
                }
                else
                {
                    ScriptComboBox.Items.Add(script.ScriptLabel);
                }
                
            }
        }

        private void OK_BUTTON_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromName("Control");

            if (!String.IsNullOrEmpty(ScriptComboBox.Text))
            {
                if (!String.IsNullOrEmpty(FunctionTextBox.Text))
                {
                    OnScriptCallingMade(GenerateTask());
                    this.Hide();
                }
                else
                {
                    panel1.BackColor = Color.LightCoral;
                }
            }
            else
            {
                panel1.BackColor = Color.LightCoral;
            }

        }

        protected virtual void OnScriptCallingMade(MTask e)
        {
            ScriptCallingMade?.Invoke(this, e);
        }
    }
}
