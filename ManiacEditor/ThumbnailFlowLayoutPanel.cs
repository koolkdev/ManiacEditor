using System;
using System.Windows.Forms;
using System.Drawing;

namespace ManiacEditor
{
    public class ThumbnailFlowLayoutPanel : FlowLayoutPanel
    {
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
        public ImageViewer Add(Bitmap bitmap, String name, bool Text)
        {
            ImageViewer imageViewer = new ImageViewer();
            imageViewer.Dock = DockStyle.Bottom;
            imageViewer.Image = bitmap;
            imageViewer.IsText = Text;
            imageViewer.Width = bitmap.Width + 8;
            imageViewer.Height = bitmap.Height + 8 + ((Text) ? 12 : 0);
            imageViewer.Name = name;
            imageViewer.IsThumbnail = false;

            Controls.Add(imageViewer);

            return imageViewer;
        }
    }
}