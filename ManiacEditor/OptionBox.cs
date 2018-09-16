using SharpDX;
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
    public partial class OptionBox : Form
    {
        public OptionBox()
        {
            InitializeComponent();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (SceneSelectRadio2.Checked == true)
            {
                Properties.Settings.Default.IsFilesViewDefault = true;
                Properties.Settings.Default.SceneSelectRadioButton1On = false;
                Properties.Settings.Default.SceneSelectRadioButton2On = true;
            }
            else
            {
                Properties.Settings.Default.IsFilesViewDefault = false;
                Properties.Settings.Default.SceneSelectRadioButton1On = true;
                Properties.Settings.Default.SceneSelectRadioButton2On = false;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (SceneSelectRadio2.Checked == true)
            {
                Properties.Settings.Default.IsFilesViewDefault = true;
                Properties.Settings.Default.SceneSelectRadioButton1On = false;
                Properties.Settings.Default.SceneSelectRadioButton2On = true;
            }
            else
            {
                Properties.Settings.Default.IsFilesViewDefault = false;
                Properties.Settings.Default.SceneSelectRadioButton1On = true;
                Properties.Settings.Default.SceneSelectRadioButton2On = false;

            }
        }

        private void radioButtonY_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonY.Checked == true)
            {
                Properties.Settings.Default.ScrollLockDirection = true;
                Properties.Settings.Default.ScrollLockX = false;
                Properties.Settings.Default.ScrollLockY = true;
            }
            else
            {
                Properties.Settings.Default.ScrollLockDirection = false;
                Properties.Settings.Default.ScrollLockX = true;
                Properties.Settings.Default.ScrollLockY = false;

            }
        }

        private void radioButtonX_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonY.Checked == true)
            {
                Properties.Settings.Default.ScrollLockDirection = true;
                Properties.Settings.Default.ScrollLockX = false;
                Properties.Settings.Default.ScrollLockY = true;
            }
            else
            {
                Properties.Settings.Default.ScrollLockDirection = false;
                Properties.Settings.Default.ScrollLockX = true;
                Properties.Settings.Default.ScrollLockY = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to wipe your settings?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
            }
            else
            {
                
            }
        }

        private void nudgeValueDownMoreButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FasterNudgeValue <= 100 && Properties.Settings.Default.FasterNudgeValue >= 0)
                Properties.Settings.Default.FasterNudgeValue -= 5;
            if (Properties.Settings.Default.FasterNudgeValue < 0)
                Properties.Settings.Default.FasterNudgeValue = 1;
            if (Properties.Settings.Default.FasterNudgeValue > 100)
                Properties.Settings.Default.FasterNudgeValue = 100;
            this.label21.Text = Properties.Settings.Default.FasterNudgeValue.ToString();
        }

        private void nudgeValueDownButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FasterNudgeValue <= 100 && Properties.Settings.Default.FasterNudgeValue >= 0)
                Properties.Settings.Default.FasterNudgeValue -= 1;
            if (Properties.Settings.Default.FasterNudgeValue <= 0)
                Properties.Settings.Default.FasterNudgeValue = 1;
            if (Properties.Settings.Default.FasterNudgeValue > 100)
                Properties.Settings.Default.FasterNudgeValue = 100;
            this.label21.Text = Properties.Settings.Default.FasterNudgeValue.ToString();
        }

        private void nudgeValueUpButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FasterNudgeValue != 100 && Properties.Settings.Default.FasterNudgeValue >= 0)
                Properties.Settings.Default.FasterNudgeValue += 1;
            if (Properties.Settings.Default.FasterNudgeValue <= 0)
                Properties.Settings.Default.FasterNudgeValue = 1;
            if (Properties.Settings.Default.FasterNudgeValue > 100)
                Properties.Settings.Default.FasterNudgeValue = 100;
            this.label21.Text = Properties.Settings.Default.FasterNudgeValue.ToString();
        }

        private void nudgeValueUpMoreButton_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.FasterNudgeValue != 100 && Properties.Settings.Default.FasterNudgeValue >= 0)
                Properties.Settings.Default.FasterNudgeValue += 5;
            if (Properties.Settings.Default.FasterNudgeValue <= 0)
                Properties.Settings.Default.FasterNudgeValue = 1;
            if (Properties.Settings.Default.FasterNudgeValue > 100)
                Properties.Settings.Default.FasterNudgeValue = 100;
            this.label21.Text = Properties.Settings.Default.FasterNudgeValue.ToString();
        }

        private void RPCCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ShowDiscordRPC == false)
            {
                Properties.Settings.Default.ShowDiscordRPC = RPCCheckBox.Checked = true;
                Editor.Instance.UpdateDiscord(Editor.Instance.ScenePath);
            }
            else
            {
                Properties.Settings.Default.ShowDiscordRPC = RPCCheckBox.Checked = false;
                Editor.Instance.UpdateDiscord();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SettingsReader.exportSettings();
        }

        private void importOptionsButton_Click(object sender, EventArgs e)
        {
            SettingsReader.importSettings();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String title = "Save Settings";
            String details = "Are you sure you want to save your settings, if the editor breaks because of one of these settings, you will have to redownload or manually reset you editor's config file! It's best you use the OK button to 'test' out the features before you save them.";
            if (MessageBox.Show(details, title, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Properties.Settings.Default.Save();
            }
            else
            {
                return;
            }
        }
    }
}
