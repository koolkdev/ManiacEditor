using ManiacEditor.Properties;
using RSDKv5;
using SharpDX.Multimedia;
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
    public partial class ObjectRemover : Form
    {
        private IList<SceneObject> _sourceSceneObjects;
        private IList<SceneObject> _targetSceneObjects;
        private StageConfig _stageConfig;
        public List<String> objectCheckMemory = new List<string>();

        public ObjectRemover(IList<SceneObject> targetSceneObjects, StageConfig stageConfig)
        {
            InitializeComponent();
            _sourceSceneObjects = targetSceneObjects;
            _targetSceneObjects = targetSceneObjects;
            _stageConfig = stageConfig;

            var targetNames = _targetSceneObjects.Select(tso => tso.Name.ToString());
            var importableObjects = _targetSceneObjects.Where(sso => targetNames.Contains(sso.Name.ToString()))
                                                        .OrderBy(sso => sso.Name.ToString());
            
            updateSelectedText();
            foreach (var io in importableObjects)
            {
                var lvi = io.Name.ToString();
                lvObjects.Items.Add(lvi, false);
                
            }
            updateSelectedText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void filter_textchaged(object sender, EventArgs e)
        {
                ReloadList();
                for (int n = lvObjects.Items.Count - 1; n >= 0; --n)
                {
                    string removelistitem = FilterText.Text;
                    if (!lvObjects.Items[n].ToString().Contains(removelistitem))
                    {
                        lvObjects.Items.RemoveAt(n);
                    }
                }
            updateSelectedText();

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            foreach (var lvci in lvObjects.SelectedItems)
            {
                var item = lvci as ListViewItem;
                SceneObject objectToImport = _sourceSceneObjects.First(sso => sso.Name.ToString().Equals(item.Text));
                objectToImport.Entities.Clear(); // ditch instances of the object from the imported level
                _targetSceneObjects.Remove(_sourceSceneObjects.First(sso => sso.Name.ToString().Equals(item.Text)));

                if (   _stageConfig != null 
                    && !_stageConfig.ObjectsNames.Contains(item.Text))
                {
                    _stageConfig.ObjectsNames.Add(item.Text);
                }
            }

            Close();
        }
        public void addCheckedItems()
        {
            String lvi;
                for (int i = 0; i < lvObjects.Items.Count; i++)
                {
                    lvi = lvObjects.Items[i].ToString(); //Get the current Object's Name
                    if (objectCheckMemory.Contains(lvi) == false) //See if the memory does not have our current object
                    {
                        bool checkStatus = lvObjects.GetItemChecked(i); //Grab the Value of the Checkbox for that Object
                        if (checkStatus == true)
                        { //If it returns true, add it to memory
                            objectCheckMemory.Add(lvi);
                        }
                    }

                    else
                    {


                    }

                }

        }

        public void removeUncheckedItems()
        {
            String lvi;
            for (int i = 0; i < lvObjects.Items.Count; i++)
            {
                lvi = lvObjects.Items[i].ToString(); //Get the current Object's Name
                if (objectCheckMemory.Contains(lvi) == true) //See if the memory has our object
                {
                    bool checkStatus = lvObjects.GetItemChecked(i); //Grab the Value of the Checkbox for that Object
                    if (checkStatus == false) { //If it returns false, grab it's index and remove the range
                        int index = objectCheckMemory.IndexOf(lvi);
                        objectCheckMemory.RemoveRange(index,1);
                    }
                }
            }
        }

        private void ReloadList()
        {
            addCheckedItems();
            removeUncheckedItems();
            lvObjects.Items.Clear();
            var targetNames = _targetSceneObjects.Select(tso => tso.Name.ToString());
            var importableObjects = _targetSceneObjects.Where(sso => targetNames.Contains(sso.Name.ToString()))
                                                        .OrderBy(sso => sso.Name.ToString());


            foreach (var io in importableObjects)
            {
                var lvi = io.Name.ToString();
                bool alreadyChecked = false;
                foreach (string str in objectCheckMemory)
                {
                    if (objectCheckMemory.Contains(lvi) == true)
                    {
                        lvObjects.Items.Add(lvi, true);
                        alreadyChecked = true;
                        break;
                    }
                }
                if (alreadyChecked == false)
                {
                    lvObjects.Items.Add(lvi, false);
                }


            }
        }

        public void RefreshList()
        {
            CommonReset();
            var targetNames = _targetSceneObjects.Select(tso => tso.Name.ToString());
            var importableObjects = _targetSceneObjects.Where(sso => targetNames.Contains(sso.Name.ToString()))
                                                        .OrderBy(sso => sso.Name.ToString());
            
            updateSelectedText();
            foreach (var io in importableObjects)
            {
                var lvi = io.Name.ToString();
                lvObjects.Items.Add(lvi, false);
                
            }
            updateSelectedText();
        }

        private void CommonReset()
        {
            FilterText.Text = "";
            objectCheckMemory.Clear();
            lvObjects.Items.Clear();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void importObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void importSoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ObjectRemover_Load(object sender, EventArgs e)
        {

        }

        private void objectsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lvObjects_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            updateSelectedText();
        }

        private void updateSelectedText()
        {
            label1.Text = "Amount of Objects Selected : " + objectCheckMemory.Count;
        }

        private void lvObjects_CheckChanges(object sender, EventArgs e)
        {
            string s = "";
            for (int x = 0; x < lvObjects.CheckedItems.Count; x++)
            {
                s = s + "Checked Item " + (x + 1).ToString() + " = " + lvObjects.CheckedItems[x].ToString() + "\n";
            }
            MessageBox.Show(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lvObjects_CheckChanges(sender, e);
        }

        private void ObjectRemover_FormClosed(object sender, FormClosedEventArgs e)
        {
            objectCheckMemory.Clear();
        }

        private void lvObjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void importObjectsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Editor.Instance.importObjectsToolStripMenuItem_Click(sender, e);
        }
    }
}
