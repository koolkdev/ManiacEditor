using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSDKv5;

namespace ManiacEditor
{
    public partial class AddAttributeBox : Form
    {
        private SceneObject obj;
        private ListView.ListViewItemCollection names;

        public AddAttributeBox(SceneObject obj, ListView.ListViewItemCollection names)
        {
            InitializeComponent();

            this.obj = obj;
            this.names = names;

            foreach (AttributeTypes attType in Enum.GetValues(typeof(AttributeTypes)))
                typeBox.Items.Add(attType);

            typeBox.SelectedIndex = 0;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (nameBox.Text.Length <= 0)
            {
                var check = MessageBox.Show("You must enter an attribute name!",
                    "No Name!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);

                return;
            }

            foreach (ListViewItem name in names)
            {
                if (name.Text == nameBox.Text)
                {
                    var check = MessageBox.Show("There is already an attribute with the name \"" + name.Text + "\"!\nChoose a different name and try again.",
                        "Name Conflict!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);

                    return;
                }
            }

            obj.AddAttribute(nameBox.Text, (AttributeTypes)typeBox.SelectedItem);//(AttributeTypes)Enum.Parse(typeof(AttributeTypes), typeBox.SelectedText));
            //Console.WriteLine("ComboBox selection is " + typeBox.SelectedItem);

            DialogResult = DialogResult.OK;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
