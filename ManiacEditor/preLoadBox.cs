using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManiacEditor
{
    public partial class preLoadBox : Form
    {
        public preLoadBox()
        {
            InitializeComponent();
        }

        private void StartBackgroundWork()
        {
            if (Application.RenderWithVisualStyles)
                progressBar1.Style = ProgressBarStyle.Marquee;
            else
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
                //timer.Enabled = true;
            }
            //backgroundWorker.RunWorkerAsync();
        }

        /*private void timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
                progressBar1.Increment(5);
            else
                progressBar1.Value = progressBar.Minimum;
        }*/
    }
}
