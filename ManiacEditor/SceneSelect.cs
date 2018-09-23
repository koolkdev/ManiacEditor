using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSDKv5;

namespace ManiacEditor
{
    public partial class SceneSelect : Form
    {
        public List<Tuple<string, List<Tuple<string, string>>>> Categories = new List<Tuple<string, List<Tuple<string, string>>>>();
        public Dictionary<string, List<string>> Directories = new Dictionary<string, List<string>>();
        public GameConfig _GameConfig;

        public string Result = null;


        public SceneSelect(GameConfig config)
        {
            InitializeComponent();
            LoadFromGameConfig(config);
            _GameConfig = config;
        }

        public void LoadFromGameConfig(GameConfig config)
        {
            Categories.Clear();
            Directories.Clear();
            foreach (GameConfig.Category category in config.Categories)
            {
                List<Tuple<string, string>> scenes = new List<Tuple<string, string>>();
                foreach (GameConfig.SceneInfo scene in category.Scenes)
                {
                    scenes.Add(new Tuple<string, string>(scene.Name, scene.Zone + "/Scene" + scene.SceneID + ".bin"));

                    List<string> files;
                    if (!Directories.TryGetValue(scene.Zone, out files))
                    {
                        files = new List<string>();
                        Directories[scene.Zone] = files;
                    }
                    files.Add("Scene" + scene.SceneID + ".bin");
                }
                Categories.Add(new Tuple<string, List<Tuple<string, string>>>(category.Name, scenes));
            }

            // Sort
            Directories = Directories.OrderBy(key => key.Key).ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
            foreach (KeyValuePair<string, List<String>> dir in Directories)
                dir.Value.Sort();

            this.scenesTree.ImageList = new ImageList();
            this.scenesTree.ImageList.Images.Add("Folder", Properties.Resources.folder);
            this.scenesTree.ImageList.Images.Add("File", Properties.Resources.file);

            UpdateTree();
            if (Properties.Settings.Default.IsFilesViewDefault)
            {
                this.isFilesView.Checked = true;
            }
            else
            {
                this.isFilesView.Checked = false;
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            Result = scenesTree.SelectedNode.Tag as string;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateTree()
        {
            Show(FilterText.Text);
        }

        private void Show(string filter)
        {
            scenesTree.Nodes.Clear();
            if (isFilesView.Checked)
            {
                foreach (KeyValuePair<string, List<string>> directory in Directories)
                {
                    TreeNode dir_node = new TreeNode(directory.Key);
                    dir_node.ImageKey = "Folder";
                    dir_node.SelectedImageKey = "Folder";
                    dir_node.ContextMenuStrip = contextMenuStrip1;
                    foreach (string file in directory.Value) {
                        TreeNode file_node = new TreeNode(file);
                        file_node.Tag = directory.Key + "/" + file;
                        file_node.ImageKey = "File";
                        file_node.ImageKey = "File";
                        file_node.SelectedImageKey = "File";
                        if (filter == "" || (directory.Key + "/" + file).ToLower().Contains(filter.ToLower()))
                            dir_node.Nodes.Add(file_node);
                    }
                    if (dir_node.Nodes.Count > 0)
                        scenesTree.Nodes.Add(dir_node);
                }
            }
            else
            {
                foreach (Tuple<string, List<Tuple<string, string>>> category in Categories)
                {
                    TreeNode dir_node = new TreeNode(category.Item1);
                    dir_node.ImageKey = "Folder";
                    dir_node.SelectedImageKey = "Folder";
                    string last = "";
                    foreach (Tuple<string, string> scene in category.Item2)
                    {
                        string scene_name = scene.Item1;
                        if (char.IsDigit(scene.Item1[0]))
                            scene_name = last + scene.Item1;

                        TreeNode file_node = new TreeNode(scene_name + " (" + scene.Item2 + ")");
                        file_node.Tag = scene.Item2;
                        file_node.ImageKey = "File";
                        file_node.SelectedImageKey = "File";
                        if (filter == "" || scene.Item2.ToLower().Contains(filter.ToLower()) || scene_name.ToLower().Contains(filter.ToLower()))
                            dir_node.Nodes.Add(file_node);

                        // Only the first act specify the full name, so lets save it
                        int i = scene_name.Length;
                        while (char.IsDigit(scene_name[i - 1]) || (i >= 2 && char.IsDigit(scene_name[i - 2])))
                            --i;
                        last = scene_name.Substring(0, i);
                    }
                    if (dir_node.Nodes.Count > 0)
                        scenesTree.Nodes.Add(dir_node);
                }
            }
            if (filter != "")
            {
                scenesTree.ExpandAll();
            }
        }

        private void isFilesView_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTree();
        }

        private void FilterText_TextChanged(object sender, EventArgs e)
        {
            UpdateTree();
        }

        private void scenesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectButton.Enabled = scenesTree.SelectedNode.Tag != null;
        }

        private void scenesTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (selectButton.Enabled)
            {
                selectButton_Click(sender, e);
            }
        }

        private void scenesTree_MouseUp(object sender, MouseEventArgs e)
        {
            if (scenesTree.SelectedNode == null)
            {
                selectButton.Enabled = false;
            }
        }

        private void scenesTree_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Scene File|*.bin";
            if (open.ShowDialog() != DialogResult.Cancel)
            {
                Result = open.FileName;
                Close();
            }
        }

        private void scenesTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                scenesTree.SelectedNode = e.Node;
                if (e.Node.ImageKey == "Folder")
                    contextMenuStrip1.Show(scenesTree, e.Location);
                else if (e.Node.ImageKey == "File")
                    contextMenuStrip2.Show(scenesTree, e.Location);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EditSceneSelectInfoForm();
            if (form.ShowDialog() == DialogResult.Yes)
            {
                var cat = _GameConfig.Categories.Where(t => t.Name == scenesTree.SelectedNode.Text).FirstOrDefault();
                if (cat != null)
                {
                    cat.Scenes.Add(form.Scene);
                    LoadFromGameConfig(_GameConfig);
                    if (MessageBox.Show("Write Changes to File?", "Write to File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        _GameConfig.Write(Path.Combine(Editor.DataDirectory, "Game", "GameConfig.bin"));
                }
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void SceneSelect_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var cat = _GameConfig.Categories.Where(t => t.Name == scenesTree.SelectedNode.Parent.Text).FirstOrDefault();
            if (cat != null)
            {
                var scene = cat.Scenes.Where(t => $"{t.Zone}/Scene{t.SceneID}.bin" == scenesTree.SelectedNode.Tag as string).FirstOrDefault();
                var form = new EditSceneSelectInfoForm(scene);
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    LoadFromGameConfig(_GameConfig);
                    if (MessageBox.Show("Write Changes to File?", "Write to File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        _GameConfig.Write(Path.Combine(Editor.DataDirectory, "Game", "GameConfig.bin"));
                }
            }
        }

        private void deleteSceneInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cat = _GameConfig.Categories.Where(t => t.Name == scenesTree.SelectedNode.Parent.Text).FirstOrDefault();
            if (cat != null)
            {
                var scene = cat.Scenes.FindIndex(t => $"{t.Zone}/Scene{t.SceneID}.bin" == scenesTree.SelectedNode.Tag as string);
                if (scene + 1 < cat.Scenes.Count && !char.IsDigit(cat.Scenes[scene].Name[0]) && char.IsDigit(cat.Scenes[scene + 1].Name[0]))
                {
                    if (MessageBox.Show("This Scene as other acts attached,\n" +
                        "Deleting this scene will set the next scene as the main scene of the stage, \n" +
                        "Are you sure you want to continue?",
                        "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                    cat.Scenes[scene + 1].Name = cat.Scenes[scene].Name.
                        Replace(" " + cat.Scenes[scene].SceneID, " "+cat.Scenes[scene + 1].SceneID);
                }
                cat.Scenes.RemoveAt(scene);
                LoadFromGameConfig(_GameConfig);
                if (MessageBox.Show("Write Changes to File?", "Write to File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _GameConfig.Write(Path.Combine(Editor.DataDirectory, "Game", "GameConfig.bin"));
            }
        }
    }
}
