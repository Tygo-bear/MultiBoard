using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class LoadingMainOverlay : UserControl
    {
        //Resources
        //=================
        readonly Image _eye1 = Properties.Resources.eyes_1;
        readonly Image _eye2 = Properties.Resources.eyes_2;

        public LoadingMainOverlay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Play animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(LOADING_PICTURE.BackgroundImage == _eye1)
            {
                LOADING_PICTURE.BackgroundImage = _eye2;
            }
            else
            {
                LOADING_PICTURE.BackgroundImage = _eye1;
            }
        }
    }
}
