using ManiacEditor.Properties;
using RSDKv5;
using SharpDX.Multimedia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                /*
                var lvi = io.Name.ToString();
                lvObjects.Items.Add(lvi, false);
                */

                var lvi = new ListViewItem(io.Name.ToString())
                {
                    Checked = false
                };
                lvObjects.Items.Add(lvi);
            }

            updateSelectedText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
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

        public void addCheckedItems()
        {
            String lvi;
            for (int i = 0; i < lvObjects.Items.Count; i++)
            {
                lvi = lvObjects.Items[i].Text.ToString(); //Get the current Object's Name
                if (objectCheckMemory.Contains(lvi) == false) //See if the memory does not have our current object
                {
                    bool checkStatus = lvObjects.Items[i].Checked; //Grab the Value of the Checkbox for that Object
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
                lvi = lvObjects.Items[i].Text.ToString(); //Get the current Object's Name
                if (objectCheckMemory.Contains(lvi) == true) //See if the memory has our object
                {
                    bool checkStatus = lvObjects.Items[i].Checked; //Grab the Value of the Checkbox for that Object
                    if (checkStatus == false) { //If it returns false, grab it's index and remove the range
                        int index = objectCheckMemory.IndexOf(lvi);
                        objectCheckMemory.RemoveRange(index, 1);
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
                var lvi = new ListViewItem(io.Name.ToString())
                {
                    Checked = true
                };

                bool alreadyChecked = false;
                foreach (string str in objectCheckMemory)
                {
                    if (objectCheckMemory.Contains(lvi.Text.ToString()) == true)
                    {
                        lvi.Checked = true;
                        lvObjects.Items.Add(lvi);
                        
                        alreadyChecked = true;
                        break;
                    }
                }
                if (alreadyChecked == false)
                {
                    lvi.Checked = false;
                    lvObjects.Items.Add(lvi);

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
                var lvi = new ListViewItem(io.Name.ToString())
                {
                    Checked = false
                };

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

        private void lvObjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // this method is not being called for some reason
            // TODO: call this properly and update selected object count
            Console.WriteLine("TEST");
            updateSelectedText();
        }

        private void updateSelectedText()
        {
            label1.Text = "Amount of Objects Selected (Memory): " + objectCheckMemory.Count + " (Current): " + lvObjects.CheckedItems.Count;
        }

        private void lvObjects_CheckChanges(object sender, EventArgs e)
        {

        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            
            foreach (var lvci in lvObjects.CheckedItems)
            {
                var item = lvci as ListViewItem;
                Debug.Print(item.Text.ToString());
                SceneObject objectsToRemove = _targetSceneObjects.FirstOrDefault(sso => sso.Name.ToString().Equals(item.Text));
                objectsToRemove.Entities.Clear(); // ditch instances of the object from the imported level
                _targetSceneObjects.Remove(_targetSceneObjects.FirstOrDefault(sso => sso.Name.ToString().Equals(item.Text)));

                /*if (_stageConfig != null
                    && !_stageConfig.ObjectsNames.Contains(item.Text))
                {
                    _stageConfig.ObjectsNames.Add(item.Text);
                }*/

                ReloadList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lvObjects_CheckChanges(sender, e);
        }

        private void ObjectRemover_FormClosed(object sender, FormClosedEventArgs e)
        {
            objectCheckMemory.Clear();
        }

        private void importObjectsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Scene sourceScene = Editor.Instance.GetSceneSelection();
                if (null == sourceScene) return;

                using (var objectImporter = new ObjectImporter(sourceScene.Objects, Editor.Instance.EditorScene.Objects, Editor.Instance.StageConfig))
                {
                    /*if (objectImporter.ShowDialog() != DialogResult.OK)
                        return; // nothing to do*/
                    //Does Not Work Correctly

                    // user clicked Import, get to it!
                    Editor.Instance.objectRemover.RefreshList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to import Objects. " + ex.Message);
            }
        }

        private void lvObjects_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            updateSelectedText();
            if (lvObjects.FocusedItem != null)
            {
                Debug.Print(lvObjects.FocusedItem.Text);
                SceneObject obj = _targetSceneObjects.First(sso => sso.Name.ToString().Equals(lvObjects.FocusedItem.Text));

                attributesTable.Items.Clear();

                foreach (AttributeInfo att in obj.Attributes)
                {
                    string[] row = { att.Name.ToString(), att.Type.ToString() };
                    attributesTable.Items.Add(new ListViewItem(row));
                }
            }

        }

        private void addAttributeBtn_Click(object sender, EventArgs e)
        {
            string targetName = (string)lvObjects.FocusedItem.Name;
            SceneObject obj = _targetSceneObjects.First(sso => sso.Name.ToString().Equals(targetName));
            using (var dialog = new AddAttributeBox(obj, attributesTable.Items))
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return; // nothing to do

                // added, now refresh
                lvObjects_SelectedIndexChanged_1(null, null);
            }
        }

        private void removeAttributeBtn_Click(object sender, EventArgs e)
        {
            if (attributesTable.SelectedIndices.Count > 0)
            {
                string attName = attributesTable.FocusedItem.Text;
                string targetName = (string)lvObjects.FocusedItem.Name;
                SceneObject obj = _targetSceneObjects.Single(sso => sso.Name.ToString().Equals(targetName));
                var check = MessageBox.Show("Removing an attribute can cause serious problems and cannot be undone.\nI highly recommend making a backup first.\nAre you sure you want to remove the attribute \"" + attName + "\" from the object \"" + obj.Name.Name + "\" and all entities of it?",
                            "Caution! This way lies madness!",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);

                if (check == DialogResult.Yes)
                {
                    obj.RemoveAttribute(attName);
                    lvObjects_SelectedIndexChanged_1(null, null);
                }
            }
        }

        private void backupStageConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void restoreStageConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optimizeObjectIDPlacementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addAttributeToAllObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lvObjects_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            updateSelectedText();
        }
    }
}
