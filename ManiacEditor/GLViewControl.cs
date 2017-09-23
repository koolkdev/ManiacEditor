using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ManiacEditor
{
    public partial class GLViewControl : GLControl
    {
        public delegate void RenderEventHandler(object sender, EventArgs e);

        [Description("Called on OpenGL render"), Category("OpenGL")]
        public event RenderEventHandler Render;

        [Description("X offset of the screen"), Category("OpenGL")]
        public int ScreenX
        {
            get
            {
                return screenX;
            }
            set
            {
                screenX = value;
                //UpdateProjection(true);
            }
        }

        [Description("Y offset of the screen"), Category("OpenGL")]
        public int ScreenY
        {
            get
            {
                return screenY;
            }
            set
            {
                screenY = value;
                //UpdateProjection(true);
            }
        }

        [Description("Zoom"), Category("OpenGL")]
        public double Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value;
                //UpdateProjection(true);
            }
        }

        public int ScreenWidth
        {
            get
            {
                return (int)(ClientSize.Width / Zoom);
            }
        }

        public int ScreenHeight
        {
            get
            {
                return (int)(ClientSize.Height / Zoom);
            }
        }


        private int screenX = 0;
        private int screenY = 0;
        private double zoom = 1;

        private Timer timer;

        private int frames;

        private int lastMeasureFPS;

        public int MeasuredFPS { get { return lastMeasureFPS; } }


        private bool design_mode;

        private DateTime lastMeasureTime;

        public GLViewControl()
        {
            design_mode =
                DesignMode ||
                LicenseManager.UsageMode == LicenseUsageMode.Designtime;

            InitializeComponent();

            if (design_mode) return;

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += timer_Tick;

            Load += UserControl1_Load;
            Resize += GLViewControl_Resize;
            Paint += GLViewControl_Paint;

            //string a = GL.GetString(StringName.Version);
        }

        private void GLViewControl_Paint(object sender, PaintEventArgs e)
        {
            MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Render?.Invoke(sender, EventArgs.Empty);
            
            UpdateProjection();

            SwapBuffers();

            frames++;
        }

        private void GLViewControl_Resize(object sender, EventArgs e)
        {
            MakeCurrent();
            if (ClientSize.Height == 0)
                ClientSize = new Size(ClientSize.Width, 1);

            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);

            UpdateProjection();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(BackColor);

            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Subtract(this.lastMeasureTime) > TimeSpan.FromSeconds(1))
            {
                this.lastMeasureFPS = this.frames;
                this.frames = 0;
                this.lastMeasureTime = DateTime.Now;
            }
            Invalidate();
        }

        private void UpdateProjection(bool make_current = false)
        {
            if (design_mode) return;

            if (make_current) MakeCurrent();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            int[] m_viewport = new int[4];
            GL.GetInteger(GetPName.Viewport, m_viewport);
            GL.Ortho(ScreenX, (double)m_viewport[2] / Zoom + ScreenX, (double)m_viewport[3] / Zoom + ScreenY, ScreenY, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void OnMouseMoveEventCreate()
        {
            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y);
        }

        #region Overrides

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: return true;
                case Keys.Down: return true;
                case Keys.Right: return true;
                case Keys.Left: return true;
                //case Keys.PageUp: return true;
                //case Keys.PageDown: return true;
            }
            return base.IsInputKey(keyData);
        }

        private DragEventArgs fixDragEventArgs(DragEventArgs e)
        {
            return new DragEventArgs(e.Data, e.KeyState, (int)(e.X / Zoom + ScreenX), (int)(e.Y / Zoom + ScreenY), e.AllowedEffect, e.Effect);
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(fixDragEventArgs(e));
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(fixDragEventArgs(e));
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(fixDragEventArgs(e));
        }

        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }

        private MouseEventArgs fixMouseEventArgs(MouseEventArgs e)
        {
            return new MouseEventArgs(e.Button, e.Clicks, (int)(e.X / Zoom + ScreenX), (int)(e.Y / Zoom + ScreenY), e.Delta);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(fixMouseEventArgs(e));
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(fixMouseEventArgs(e));
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(fixMouseEventArgs(e));
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(fixMouseEventArgs(e));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(fixMouseEventArgs(e));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(fixMouseEventArgs(e));
        }

        #endregion

    }
}
