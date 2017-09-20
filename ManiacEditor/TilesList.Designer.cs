namespace ManiacEditor
{
    partial class TilesList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.graphicPanel = new ManiacEditor.DevicePanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(126, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 146);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.graphicPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 146);
            this.panel1.TabIndex = 2;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // graphicPanel
            // 
            this.graphicPanel.AllowDrop = true;
            this.graphicPanel.DeviceBackColor = System.Drawing.Color.White;
            this.graphicPanel.Location = new System.Drawing.Point(0, 0);
            this.graphicPanel.Name = "graphicPanel";
            this.graphicPanel.Size = new System.Drawing.Size(126, 146);
            this.graphicPanel.TabIndex = 2;
            this.graphicPanel.OnRender += new ManiacEditor.RenderEventHandler(this.graphicPanel_OnRender);
            this.graphicPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.graphicPanel_DragEnter);
            this.graphicPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.graphicPanel_MouseDoubleClick);
            this.graphicPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphicPanel_MouseDown);
            this.graphicPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphicPanel_MouseMove);
            this.graphicPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.graphicPanel_MouseUp);
            this.graphicPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.graphicPanel_MouseWheel);
            this.graphicPanel.Resize += new System.EventHandler(this.graphicPanel_Resize);
            // 
            // TilesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vScrollBar1);
            this.Name = "TilesList";
            this.Size = new System.Drawing.Size(146, 146);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private DevicePanel graphicPanel;
    }
}
