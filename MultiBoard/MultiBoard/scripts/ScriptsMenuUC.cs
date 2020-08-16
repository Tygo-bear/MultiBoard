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

namespace MultiBoard.scripts
{
    public partial class ScriptsMenuUC : UserControl
    {
        public List<Script> ScriptList;
        public ScriptsMenuUC(List<Script> scripts)
        {
            InitializeComponent();

            ScriptList = scripts;
        }

        public void DisplayScripts()
        {
            PlacementPanel.Controls.Clear();

            const int margin = 10;
            int i = 0;
            foreach (Script s in ScriptList)
            {
                ScriptListPanelUC scriptListPanel = new ScriptListPanelUC(s);
                scriptListPanel.Width = PlacementPanel.Width - 2 * margin;
                Point p = new Point(margin, (scriptListPanel.Height + margin) * i + margin);
                scriptListPanel.Location = p;
                PlacementPanel.Controls.Add(scriptListPanel);

                i++;
            }
        }
    }
}
