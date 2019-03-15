using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class UndoKeyboardDelete : UserControl
    {
        public event EventHandler Undo;

        private string _text = "";
        private string _tag = "";

        public UndoKeyboardDelete()
        {
            InitializeComponent();
        }

        private void UNDO_BUTTON_Click(object sender, EventArgs e)
        {
            if (Undo != null)
            {
                Undo(this, EventArgs.Empty);
            }
        }

    }
}
