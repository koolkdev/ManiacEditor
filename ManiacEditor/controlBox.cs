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
    public partial class controlBox : Form
    {
        public controlBox()
        {
            InitializeComponent();
        }


        private void controlBox_Quit(object sender, EventArgs e)
        {
            Editor.Instance.controlWindowOpen = false;
        }
    }
}
