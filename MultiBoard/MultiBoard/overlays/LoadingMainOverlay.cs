using System;
using System.Drawing;
using System.Windows.Forms;

namespace MultiBoard.overlays
{
    public partial class LoadingMainOverlay : UserControl
    {
        public LoadingMainOverlay()
        {
            InitializeComponent();
        }

        readonly Image _eye1 = Properties.Resources.eyes_1;
        readonly Image _eye2 = Properties.Resources.eyes_2;

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
