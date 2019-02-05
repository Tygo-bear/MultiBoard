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
    public partial class LoadingMainOverlay : UserControl
    {
        public LoadingMainOverlay()
        {
            InitializeComponent();
        }

        Image EYE_1 = Properties.Resources.eyes_1;
        Image EYE_2 = Properties.Resources.eyes_2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(LOADING_PICTURE.BackgroundImage == EYE_1)
            {
                LOADING_PICTURE.BackgroundImage = EYE_2;
            }
            else
            {
                LOADING_PICTURE.BackgroundImage = EYE_1;
            }
        }
    }
}
