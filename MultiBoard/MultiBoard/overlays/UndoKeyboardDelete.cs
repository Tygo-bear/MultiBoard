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
        public event EventHandler Closed;

        private string _text = "";
        private string _tag = "";

        public UndoKeyboardDelete()
        {
            InitializeComponent();
            FADE_TIMER.Start();
        }

        private void UNDO_BUTTON_Click(object sender, EventArgs e)
        {
            if (Undo != null)
            {
                Undo(this, EventArgs.Empty);
            }
        }

        public string text
        {
            get { return _text; }
            set
            {
                MESSAGE_LABEL.Text = value;
                _text = value;
            }
        }

        public string tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        private void FADE_TIMER_Tick(object sender, EventArgs e)
        {
            if (Closed != null)
            {
                Closed(this, EventArgs.Empty);
            }
            this.Dispose();
        }

        private void CLOSE_BUTTON_Click(object sender, EventArgs e)
        {
            if (Closed != null)
            {
                Closed(this, EventArgs.Empty);
            }
            this.Dispose();
        }
    }
}
