using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ManiacEditor
{
    public partial class CustomMsgBox : Form
    {
        string error;
        string title;
        int type;
        int icon;
        public CustomMsgBox(string error_input, string title_input, int type_input, int icon_input)
        {
            InitializeComponent();
            error = error_input;
            title = title_input;
            type = type_input;
            icon = icon_input;
        }

        public void setupDialog(string error, string title, int type, int icon)
        {
            CustomMsgBox.ActiveForm.Text = title;
            label1.Text = error;
            switch (type)
            {
                case 1:
                    okButton.Visible = false;
                    yesButton.Visible = true;
                    noButton.Visible = true;
                    CustomMsgBox.ActiveForm.AcceptButton = yesButton;
                    CustomMsgBox.ActiveForm.CancelButton = noButton;
                    break;
                case 2:
                    okButton.Visible = true;
                    yesButton.Visible = false;
                    noButton.Visible = false;
                    CustomMsgBox.ActiveForm.AcceptButton = okButton;
                    break;
            }
            switch (icon)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.ErrorMonitor;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.WarningMonitor;
                    break;
                default:
                    pictureBox1.Image = Properties.Resources.WarningMonitor;
                    break;

            }




        }

        private void CustomMsgBox_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void CustomMsgBox_Shown(object sender, EventArgs e)
        {
            setupDialog(error, title, type, icon);
        }


        private void CustomMsgBox_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
