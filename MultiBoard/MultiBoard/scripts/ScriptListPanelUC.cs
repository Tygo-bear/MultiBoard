using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoHotkey.Interop;
using MultiBoardKeyboard;

namespace MultiBoard.scripts
{
    public partial class ScriptListPanelUC : UserControl
    {
        public Script AhkScript;
        public ScriptListPanelUC(Script script)
        {
            InitializeComponent();
            AhkScript = script;

            String[] spearator = { "/", @"\" };
            String[] strlist = script.ScriptLabel.Split(spearator,
                StringSplitOptions.RemoveEmptyEntries);

            if (strlist.Length >= 1)
            {
                NameLabel.Text = strlist[strlist.Length - 1];
            }
            else
            {
                NameLabel.Text = script.ScriptLabel;
            }

            if(script.IsRunning) { StopStartButton.BackgroundImage = Properties.Resources.stop_fill; }
        }

        private void StopStartButton_Click(object sender, EventArgs e)
        {
            if (AhkScript.IsRunning)
            {
                AhkScript.TerminateScript();
                StopStartButton.BackgroundImage = Properties.Resources.play_fill;
            }
            else
            {
                AhkScript.LoadScript(AhkScript.ScriptLabel);
                StopStartButton.BackgroundImage = Properties.Resources.stop_fill;
            }
        }
    }
}
