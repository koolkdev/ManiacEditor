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
    public partial class EditSceneSelectInfoForm : Form
    {
        public RSDKv5.GameConfig.SceneInfo Scene;

        public EditSceneSelectInfoForm()
        {
            Scene = new RSDKv5.GameConfig.SceneInfo();
            InitializeComponent();
        }

        public EditSceneSelectInfoForm(RSDKv5.GameConfig.SceneInfo scene)
        {
            if (scene == null)
                Scene = new RSDKv5.GameConfig.SceneInfo();
            else
                Scene = scene;
            InitializeComponent();
            textBox1_TextChanged(null, null);
        }

        private void EditSceneSelectInfoForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Scene.Name;
            textBox2.Text = Scene.Zone;
            textBox3.Text = Scene.SceneID;
            checkBox1.Checked = (Scene.ModeFilter & 0b0001) != 0;
            checkBox2.Checked = (Scene.ModeFilter & 0b0010) != 0;
            checkBox3.Checked = (Scene.ModeFilter & 0b0100) != 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scene.Name    = textBox1.Text;
            Scene.Zone    = textBox2.Text;
            Scene.SceneID = textBox3.Text;
            Scene.ModeFilter |= (byte)((checkBox1.Checked ? 1 : 0) << 0);
            Scene.ModeFilter |= (byte)((checkBox2.Checked ? 1 : 0) << 1);
            Scene.ModeFilter |= (byte)((checkBox3.Checked ? 1 : 0) << 2);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = $"Data\\Stages\\{textBox2.Text}\\Scene{textBox3.Text}.bin";
        }
    }
}
