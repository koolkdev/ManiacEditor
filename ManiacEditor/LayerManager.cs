using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ManiacEditor.Properties;

namespace ManiacEditor
{
    /// <summary>
    /// A form for managing Editor Layers of a Sonic Mania Scene at a high level.
    /// </summary>
    public partial class LayerManager : Form
    {
        private EditorScene _editorScene;
        private IEnumerable<EditorLayer> Layers => _editorScene?.AllLayers;

        private bool _layerArrangementChanged = false;

        public LayerManager(EditorScene editorScene)
        {
            InitializeComponent();
            rtbWarn.Rtf = Resources.LayerManagerWarning;
            _editorScene = editorScene;
            bsLayers.DataSource = Layers;
            lbLayers.DisplayMember = "Name";

            lblRawWidthValue.DataBindings.Add(CreateTextBinding("Width", FormatBasicNumber));
            lblRawHeightValue.DataBindings.Add(CreateTextBinding("Height", FormatBasicNumber));

            lblEffSizeWidth.DataBindings.Add(CreateTextBinding("Width", FormatEffectiveNumber));
            lblEffSizeHeight.DataBindings.Add(CreateTextBinding("Height", FormatEffectiveNumber));

            nudWidth.DataBindings.Add(new Binding("Value", bsLayers, "Width"));
            nudHeight.DataBindings.Add(new Binding("Value", bsLayers, "Height"));

            tbName.DataBindings.Add(CreateBinding("Text", "Name"));

            nudVerticalScroll.DataBindings.Add(CreateBinding("Value", "ScrollingVertical"));
            nudUnknownByte2.DataBindings.Add(CreateBinding("Value", "UnknownByte2"));
            nudUnknownWord1.DataBindings.Add(CreateBinding("Value", "UnknownWord1"));
            nudUnknownWord2.DataBindings.Add(CreateBinding("Value", "UnknownWord2"));
        }

        private Binding CreateTextBinding(string property, ConvertEventHandler formatHandler)
        {
            var b = new Binding("Text", bsLayers, property, true, DataSourceUpdateMode.OnPropertyChanged, "unknown", property + ": {0:N0}");
            b.Format += formatHandler;
            return b;
        }

        private Binding CreateBinding(string targetControlProperty, string sourceDataProperty)
        {
            return new Binding(targetControlProperty, bsLayers, sourceDataProperty, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FormatBasicNumber(object sender, ConvertEventArgs e)
        {
            e.Value = string.Format(((Binding)sender).FormatString, Convert.ToInt32(e.Value));
        }

        private void FormatEffectiveNumber(object sender, ConvertEventArgs e)
        {
            e.Value = string.Format(((Binding)sender).FormatString, Convert.ToInt32(e.Value) * 16);
        }

        private void DesiredSizeChanged(object sender, EventArgs e)
        {
            lblResizedEffective.Text = $"Effective Width {(nudWidth.Value * 16):N0}, " +
                                       $"Effective Height {(nudHeight.Value * 16):N0}";
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            var check = MessageBox.Show(@"Resizing a layer can not be undone. 
You really should save what you have and take a backup first.
Proceed with the resize?",
                                        "Caution!",
                                        MessageBoxButtons.YesNo, 
                                        MessageBoxIcon.Warning, 
                                        MessageBoxDefaultButton.Button2);
            if (check == DialogResult.Yes)
            {
                var layer = lbLayers.SelectedItem as EditorLayer;
                layer.Resize(Convert.ToUInt16(nudWidth.Value), Convert.ToUInt16(nudHeight.Value));
            }

            bsLayers.ResetCurrentItem();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var current = bsLayers.Current as EditorLayer;
            if (current == null) return;

            int index = bsLayers.Position;
            if (index == 0) return;
            bsLayers.Remove(current);
            bsLayers.Insert(--index, current);
            bsLayers.Position = index;

            _layerArrangementChanged = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var current = bsLayers.Current as EditorLayer;
            if (current == null) return;

            int index = bsLayers.Position;
            if (index == bsLayers.Count - 1) return;
            bsLayers.Remove(current);
            bsLayers.Insert(++index, current);
            bsLayers.Position = index;

            _layerArrangementChanged = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditorLayer newEditorLayer = _editorScene.ProduceLayer();
            int newIndex = bsLayers.Add(newEditorLayer);
            bsLayers.Position = newIndex;

            _layerArrangementChanged = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var current = bsLayers.Current as EditorLayer;
            if (null == current) return;

            var check = MessageBox.Show($@"Deleting a layer can not be undone!
Are you sure you want to delete the [{current.Name}] layer?",
                                        "Confirm Deletion",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button2);
            if (check == DialogResult.Yes)
            {
                bsLayers.Remove(current);

                _layerArrangementChanged = true;
            }
        }

        private void LayerManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_layerArrangementChanged) return;

            MessageBox.Show(@"If you have changed the number, or order of the layers, 
you may need to update any layer switching entities/objects in the scene too.

If you don't, strange things may well happen.
They may well happen anway, this is all experimental!",
                            "Don't forget!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}
