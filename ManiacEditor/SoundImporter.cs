using ManiacEditor.Properties;
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
    public partial class SoundImporter : Form
    {
        private IList<WAVConfiguration> _sourceSceneSounds;
        private IList<WAVConfiguration> _targetSceneSounds;
        private StageConfig _stageConfig;

        public SoundImporter(StageConfig sourceSceneSounds, StageConfig stageConfig)
        {
            InitializeComponent();
            rtbWarning.Rtf = Resources.SoundWarning;
            _sourceSceneSounds = sourceSceneSounds.WAVs;
            _targetSceneSounds = stageConfig.WAVs;
            _stageConfig = stageConfig;

            var targetSounds = _targetSceneSounds.Select(tso => tso.Name);
            var importableSounds = _sourceSceneSounds.Where(sso => !targetSounds.Contains(sso.Name))
                                                     .OrderBy(sso => sso.Name);

            foreach (var io in importableSounds)
            {
                var lvi = new ListViewItem(io.Name)
                {
                    Checked = false
                };

                lvObjects.Items.Add(lvi);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            foreach (var lvci in lvObjects.CheckedItems)
            {
                var item = lvci as ListViewItem;
                WAVConfiguration soundToImport = _sourceSceneSounds.Single(sso => sso.Name.Equals(item.Text));
                _targetSceneSounds.Add(_sourceSceneSounds.Single(sso => sso.Name.Equals(item.Text)));

                if (_stageConfig != null
                    && !_stageConfig.WAVs.Select(w=>w.Name).Contains(soundToImport.Name))
                {
                    _stageConfig.WAVs.Add(soundToImport);
                }
            }

            Close();
        }
    }
}
