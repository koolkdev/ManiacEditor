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
    public partial class SceneSelect : Form
    {
        List<Tuple<string, List<Tuple<string, string>>>> Categories = new List<Tuple<string, List<Tuple<string, string>>>>();
        Dictionary<string, List<string>> Directories = new Dictionary<string, List<string>>();

        public string Result = null;
        
        public SceneSelect(GameConfig config)
        {
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

            InitializeComponent();
            this.scenesTree.ImageList = new ImageList();
            this.scenesTree.ImageList.Images.Add("Folder", Properties.Resources.folder);
            this.scenesTree.ImageList.Images.Add("File", Properties.Resources.file);

            UpdateTree();
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
    }
}
