using System;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class UndoKeyboardDelete : UserControl
    {
        //Events
        //===============
        public event EventHandler Undo;
        public event EventHandler Closed;

        //Vars
        //==================
        private string _text = "";
        private string _tag = "";

        /// <summary>
        /// Control create, start fade timer
        /// </summary>
        public UndoKeyboardDelete()
        {
            InitializeComponent();
            FADE_TIMER.Start();
        }

        /// <summary>
        /// User clicked "undo" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UNDO_BUTTON_Click(object sender, EventArgs e)
        {
            if (Undo != null)
            {
                Undo(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Message shown to the user
        /// </summary>
        public string text
        {
            get { return _text; }
            set
            {
                MESSAGE_LABEL.Text = value;
                _text = value;
            }
        }

        /// <summary>
        /// Hidden tag
        /// </summary>
        public string tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        /// <summary>
        /// Fade delay ended, delete control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FADE_TIMER_Tick(object sender, EventArgs e)
        {
            if (Closed != null)
            {
                Closed(this, EventArgs.Empty);
            }
            this.Dispose();
        }

        /// <summary>
        /// User clicked "close" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
