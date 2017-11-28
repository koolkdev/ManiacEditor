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
        IList<EditorLayer> _layers;
        private IList<EditorLayer> Layers
        {
            get { return _layers; }
            set { _layers = value; }
        }

        public LayerManager(IList<EditorLayer> layers)
        {
            InitializeComponent();
            rtbWarn.Rtf = Resources.LayerManagerWarning;
            _layers = layers;
            bsLayers.DataSource = _layers;
            lbLayers.DisplayMember = "Name";

            lblRawWidthValue.DataBindings.Add(CreateTextBinding("Width", FormatBasicNumber));
            lblRawHeightValue.DataBindings.Add(CreateTextBinding("Height", FormatBasicNumber));

            lblEffSizeWidth.DataBindings.Add(CreateTextBinding("Width", FormatEffectiveNumber));
            lblEffSizeHeight.DataBindings.Add(CreateTextBinding("Height", FormatEffectiveNumber));

            nudWidth.DataBindings.Add(new Binding("Value", bsLayers, "Width"));
            nudHeight.DataBindings.Add(new Binding("Value", bsLayers, "Height"));

        }

        private Binding CreateTextBinding(string property, ConvertEventHandler formatHandler)
        {
            var b = new Binding("Text", bsLayers, property, true, DataSourceUpdateMode.OnPropertyChanged, "unknown", property + ": {0:N0}");
            b.Format += formatHandler;
            return b;
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
    }
}
