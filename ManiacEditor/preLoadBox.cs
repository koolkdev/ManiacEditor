using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ManiacEditor
{
    public partial class preLoadBox : Form
    {
        public bool isVisible = false;
        public preLoadBox()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }

        public void SetProgressBarStatus(int x, int y)
        {
            progressBar1.Value = x;
            progressBar2.Value = y;
            label2.Text = "Too fast if this is seen";
        }

        private void form_shown(object sender, EventArgs e)
        {
            isVisible = true;
            //progressBar1.Value = 100;
            //label2.Text = "Too fast if this is seen";

        }
        public void StartLoop()
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (bool w = false; w != true;)
                {
                    if (Properties.CheatCodes.Default.isPreRendering == true)
                    {
                    //Properties.CheatCodes.Default.Reload();
                    //backgroundWorker1.ReportProgress((Properties.CheatCodes.Default.ProgressX + Properties.CheatCodes.Default.ProgressY)/2);
                }
                    else
                    {
                        w = true;

                    }       

                }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.progressBar1.Value = Properties.CheatCodes.Default.ProgressX;
            //Debug.Print(Properties.CheatCodes.Default.ProgressX.ToString());
            //this.progressBar2.Value = Properties.CheatCodes.Default.ProgressY;
        }
    }
}
