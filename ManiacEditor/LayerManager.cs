using RSDKv5;
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
    /// <summary>
    /// A form for managing layers of a Sonic Mania Scene at a high level.
    /// </summary>
    public partial class LayerManager : Form
    {
        IList<SceneLayer> _layers;
        private IList<SceneLayer> Layers
        {
            get { return _layers; }
            set { _layers = value; }
        }

        public LayerManager(IList<SceneLayer> layers)
        {
            InitializeComponent();
            _layers = layers;
            bsLayers.DataSource = _layers;
            lbLayers.DisplayMember = "Name";

            lblRawWidthValue.DataBindings.Add(CreateTextBinding("Width", FormatBasicNumber));
            lblRawHeightValue.DataBindings.Add(CreateTextBinding("Height", FormatBasicNumber));

            lblEffSizeWidth.DataBindings.Add(CreateTextBinding("Width", FormatEffectiveNumber));
            lblEffSizeHeight.DataBindings.Add(CreateTextBinding("Height", FormatEffectiveNumber));

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
    }
}
