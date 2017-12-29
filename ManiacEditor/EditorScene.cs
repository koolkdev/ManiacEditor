using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSDKv5;

namespace ManiacEditor
{
    public class EditorScene : Scene, IDisposable
    {
        private IList<EditorLayer> _editorLayers;

        public EditorLayer ForegroundLow
        {
            get => _editorLayers.LastOrDefault(el => el.Name.Equals("FG Low") || el.Name.Equals("Playfield"));
        }
        public EditorLayer ForegroundHigh
        {
            get => _editorLayers.LastOrDefault(el => el.Name.Equals("FG High") || el.Name.Equals("Ring Count"));
        }

        public IEnumerable<EditorLayer> AllLayers
        {
            get { return _editorLayers; }
        }

        public IEnumerable<EditorLayer> OtherLayers
        {
            get
            {
                return _editorLayers.Where(el => el != ForegroundLow && el != ForegroundHigh);
            }
        }

        public EditorScene(string filename) : base(filename)
        {
            _editorLayers = new List<EditorLayer>(Layers.Count);
            foreach (SceneLayer layer in Layers)
            {
                _editorLayers.Add(new EditorLayer(layer));
            }
        }

        public EditorLayer ProduceLayer()
        {
            // lets just pick some reasonably safe defaults
            var sceneLayer = new SceneLayer("New Layer", 128, 128);
            var editorLayer = new EditorLayer(sceneLayer);
            return editorLayer;
        }

        public void DeleteLayer(int byIndex)
        {
            _editorLayers.RemoveAt(byIndex);
        }

        public void DeleteLayer(EditorLayer thisLayer)
        {
            _editorLayers.Remove(thisLayer);
        }

        public void Save(string filename)
        {
            Layers = _editorLayers.Select(el => el.Layer).ToList();
            Write(filename);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    foreach (var el in _editorLayers)
                    {
                        el.Dispose();
                    }
                }

                // free unmanaged resources (unmanaged objects) and override a finalizer below if we need to.
                // then set large fields to null.

                disposedValue = true;
            }
        }

        // Override this finalizer only if Dispose(bool disposing) ever gains code to free unmanaged resources.
        // ~EditorScene() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
