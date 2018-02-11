namespace ManiacEditor
{
    partial class Editor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAspngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportEachLayerAspngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.flipHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.GraphicPanel = new ManiacEditor.DevicePanel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.New = new System.Windows.Forms.ToolStripButton();
            this.Open = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RunScene = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MagnetMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ShowFGLow = new System.Windows.Forms.ToolStripButton();
            this.ShowFGHigh = new System.Windows.Forms.ToolStripButton();
            this.ShowEntities = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.EditFGLow = new System.Windows.Forms.ToolStripButton();
            this.EditFGHigh = new System.Windows.Forms.ToolStripButton();
            this.EditEntities = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.zoomInButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOutButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.pointerButton = new System.Windows.Forms.ToolStripButton();
            this.selectTool = new System.Windows.Forms.ToolStripButton();
            this.placeTilesButton = new System.Windows.Forms.ToolStripButton();
            this.ShowAnimations = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.viewPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.sceneToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Enabled = false;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "New..";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "Open..";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.sToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAspngToolStripMenuItem,
            this.exportEachLayerAspngToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // saveAspngToolStripMenuItem
            // 
            this.saveAspngToolStripMenuItem.Name = "saveAspngToolStripMenuItem";
            this.saveAspngToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.saveAspngToolStripMenuItem.Text = "Export as .png..";
            this.saveAspngToolStripMenuItem.Click += new System.EventHandler(this.saveAspngToolStripMenuItem_Click);
            // 
            // exportEachLayerAspngToolStripMenuItem
            // 
            this.exportEachLayerAspngToolStripMenuItem.Name = "exportEachLayerAspngToolStripMenuItem";
            this.exportEachLayerAspngToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.exportEachLayerAspngToolStripMenuItem.Text = "Export Each Layer as .png";
            this.exportEachLayerAspngToolStripMenuItem.Click += new System.EventHandler(this.exportEachLayerAspngToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator7,
            this.flipHorizontalToolStripMenuItem,
            this.flipVerticalToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(170, 6);
            // 
            // flipHorizontalToolStripMenuItem
            // 
            this.flipHorizontalToolStripMenuItem.Name = "flipHorizontalToolStripMenuItem";
            this.flipHorizontalToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.flipHorizontalToolStripMenuItem.Text = "Flip Horizontal (M)";
            this.flipHorizontalToolStripMenuItem.Click += new System.EventHandler(this.flipHorizontalToolStripMenuItem_Click);
            // 
            // flipVerticalToolStripMenuItem
            // 
            this.flipVerticalToolStripMenuItem.Name = "flipVerticalToolStripMenuItem";
            this.flipVerticalToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.flipVerticalToolStripMenuItem.Text = "Flip Vertical (F)";
            this.flipVerticalToolStripMenuItem.Click += new System.EventHandler(this.flipVerticalToolStripMenuItem_Click);
            // 
            // sceneToolStripMenuItem
            // 
            this.sceneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importObjectsToolStripMenuItem,
            this.importSoundsToolStripMenuItem,
            this.layerManagerToolStripMenuItem});
            this.sceneToolStripMenuItem.Name = "sceneToolStripMenuItem";
            this.sceneToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.sceneToolStripMenuItem.Text = "Scene";
            // 
            // importObjectsToolStripMenuItem
            // 
            this.importObjectsToolStripMenuItem.Enabled = false;
            this.importObjectsToolStripMenuItem.Name = "importObjectsToolStripMenuItem";
            this.importObjectsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.importObjectsToolStripMenuItem.Text = "Import Objects";
            this.importObjectsToolStripMenuItem.Click += new System.EventHandler(this.importObjectsToolStripMenuItem_Click);
            // 
            // importSoundsToolStripMenuItem
            // 
            this.importSoundsToolStripMenuItem.Enabled = false;
            this.importSoundsToolStripMenuItem.Name = "importSoundsToolStripMenuItem";
            this.importSoundsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.importSoundsToolStripMenuItem.Text = "Import Sounds";
            this.importSoundsToolStripMenuItem.Click += new System.EventHandler(this.importSoundsToolStripMenuItem_Click);
            // 
            // layerManagerToolStripMenuItem
            // 
            this.layerManagerToolStripMenuItem.Enabled = false;
            this.layerManagerToolStripMenuItem.Name = "layerManagerToolStripMenuItem";
            this.layerManagerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.layerManagerToolStripMenuItem.Text = "Layer Manager";
            this.layerManagerToolStripMenuItem.Click += new System.EventHandler(this.layerManagerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.viewPanel);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1159, 680);
            this.splitContainer1.SplitterDistance = 870;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // viewPanel
            // 
            this.viewPanel.Controls.Add(this.panel3);
            this.viewPanel.Controls.Add(this.hScrollBar1);
            this.viewPanel.Controls.Add(this.vScrollBar1);
            this.viewPanel.Controls.Add(this.GraphicPanel);
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 0);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(868, 678);
            this.viewPanel.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Location = new System.Drawing.Point(850, 660);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 18);
            this.panel3.TabIndex = 8;
            this.panel3.Visible = false;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.LargeChange = 20;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 660);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(850, 18);
            this.hScrollBar1.SmallChange = 20;
            this.hScrollBar1.TabIndex = 2;
            this.hScrollBar1.Visible = false;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.LargeChange = 20;
            this.vScrollBar1.Location = new System.Drawing.Point(850, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 660);
            this.vScrollBar1.SmallChange = 20;
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Visible = false;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // GraphicPanel
            // 
            this.GraphicPanel.AllowDrop = true;
            this.GraphicPanel.DeviceBackColor = System.Drawing.Color.White;
            this.GraphicPanel.Location = new System.Drawing.Point(0, 0);
            this.GraphicPanel.Margin = new System.Windows.Forms.Padding(0);
            this.GraphicPanel.Name = "GraphicPanel";
            this.GraphicPanel.Size = new System.Drawing.Size(882, 482);
            this.GraphicPanel.TabIndex = 0;
            this.GraphicPanel.OnRender += new ManiacEditor.RenderEventHandler(this.GraphicPanel_OnRender);
            this.GraphicPanel.OnCreateDevice += new ManiacEditor.CreateDeviceEventHandler(this.OnResetDevice);
            this.GraphicPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.GraphicPanel_DragDrop);
            this.GraphicPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.GraphicPanel_DragEnter);
            this.GraphicPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.GraphicPanel_DragOver);
            this.GraphicPanel.DragLeave += new System.EventHandler(this.GraphicPanel_DragLeave);
            this.GraphicPanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GraphicPanel_OnKeyDown);
            this.GraphicPanel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GraphicPanel_OnKeyUp);
            this.GraphicPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GraphicPanel_OnMouseDoubleClick);
            this.GraphicPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphicPanel_OnMouseDown);
            this.GraphicPanel.MouseEnter += new System.EventHandler(this.GraphicPanel_MouseEnter);
            this.GraphicPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphicPanel_OnMouseMove);
            this.GraphicPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphicPanel_OnMouseUp);
            this.GraphicPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.GraphicPanel_MouseWheel);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.splitContainer1);
            this.mainPanel.Location = new System.Drawing.Point(12, 53);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1160, 681);
            this.mainPanel.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(9, 737);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(17, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // New
            // 
            this.New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.New.Enabled = false;
            this.New.Image = ((System.Drawing.Image)(resources.GetObject("New.Image")));
            this.New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(23, 22);
            this.New.Text = "toolStripButton2";
            this.New.ToolTipText = "Create new map";
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // Open
            // 
            this.Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Open.Image = ((System.Drawing.Image)(resources.GetObject("Open.Image")));
            this.Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(23, 22);
            this.Open.Text = "Open Map.wz";
            this.Open.ToolTipText = "Open Map.wz";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Save
            // 
            this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(23, 22);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // RunScene
            // 
            this.RunScene.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RunScene.Enabled = false;
            this.RunScene.Image = ((System.Drawing.Image)(resources.GetObject("RunScene.Image")));
            this.RunScene.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RunScene.Name = "RunScene";
            this.RunScene.Size = new System.Drawing.Size(23, 22);
            this.RunScene.Text = "Run Scene";
            this.RunScene.ToolTipText = "Run Scene";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // MagnetMode
            // 
            this.MagnetMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MagnetMode.Enabled = false;
            this.MagnetMode.Image = ((System.Drawing.Image)(resources.GetObject("MagnetMode.Image")));
            this.MagnetMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MagnetMode.Name = "MagnetMode";
            this.MagnetMode.Size = new System.Drawing.Size(23, 22);
            this.MagnetMode.Text = "toolStripButton9";
            this.MagnetMode.ToolTipText = "MagnetMode";
            this.MagnetMode.Click += new System.EventHandler(this.MagnetMode_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ShowFGLow
            // 
            this.ShowFGLow.Checked = true;
            this.ShowFGLow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowFGLow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ShowFGLow.Image = ((System.Drawing.Image)(resources.GetObject("ShowFGLow.Image")));
            this.ShowFGLow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowFGLow.Name = "ShowFGLow";
            this.ShowFGLow.Size = new System.Drawing.Size(50, 22);
            this.ShowFGLow.Text = "FG Low";
            this.ShowFGLow.ToolTipText = "Hide Layer FG Low";
            this.ShowFGLow.Click += new System.EventHandler(this.ShowFGLow_Click);
            // 
            // ShowFGHigh
            // 
            this.ShowFGHigh.Checked = true;
            this.ShowFGHigh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowFGHigh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ShowFGHigh.Image = ((System.Drawing.Image)(resources.GetObject("ShowFGHigh.Image")));
            this.ShowFGHigh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowFGHigh.Name = "ShowFGHigh";
            this.ShowFGHigh.Size = new System.Drawing.Size(54, 22);
            this.ShowFGHigh.Text = "FG High";
            this.ShowFGHigh.ToolTipText = "Hide Layer FG High";
            this.ShowFGHigh.Click += new System.EventHandler(this.ShowFGHigh_Click);
            // 
            // ShowEntities
            // 
            this.ShowEntities.Checked = true;
            this.ShowEntities.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowEntities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ShowEntities.Image = ((System.Drawing.Image)(resources.GetObject("ShowEntities.Image")));
            this.ShowEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowEntities.Name = "ShowEntities";
            this.ShowEntities.Size = new System.Drawing.Size(49, 22);
            this.ShowEntities.Text = "Entities";
            this.ShowEntities.ToolTipText = "Hide Entities";
            this.ShowEntities.Click += new System.EventHandler(this.ShowEntities_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // EditFGLow
            // 
            this.EditFGLow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditFGLow.Enabled = false;
            this.EditFGLow.ForeColor = System.Drawing.Color.Red;
            this.EditFGLow.Image = ((System.Drawing.Image)(resources.GetObject("EditFGLow.Image")));
            this.EditFGLow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditFGLow.Name = "EditFGLow";
            this.EditFGLow.Size = new System.Drawing.Size(50, 22);
            this.EditFGLow.Text = "FG Low";
            this.EditFGLow.ToolTipText = "Edit Layer FG Low";
            this.EditFGLow.Click += new System.EventHandler(this.EditFGLow_Click);
            // 
            // EditFGHigh
            // 
            this.EditFGHigh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditFGHigh.Enabled = false;
            this.EditFGHigh.ForeColor = System.Drawing.Color.Red;
            this.EditFGHigh.Image = ((System.Drawing.Image)(resources.GetObject("EditFGHigh.Image")));
            this.EditFGHigh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditFGHigh.Name = "EditFGHigh";
            this.EditFGHigh.Size = new System.Drawing.Size(54, 22);
            this.EditFGHigh.Text = "FG High";
            this.EditFGHigh.ToolTipText = "Edit Layer FG High";
            this.EditFGHigh.Click += new System.EventHandler(this.EditFGHigh_Click);
            // 
            // EditEntities
            // 
            this.EditEntities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditEntities.Enabled = false;
            this.EditEntities.ForeColor = System.Drawing.Color.Red;
            this.EditEntities.Image = ((System.Drawing.Image)(resources.GetObject("EditEntities.Image")));
            this.EditEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditEntities.Name = "EditEntities";
            this.EditEntities.Size = new System.Drawing.Size(49, 22);
            this.EditEntities.Text = "Entities";
            this.EditEntities.ToolTipText = "Edit Entities";
            this.EditEntities.Click += new System.EventHandler(this.EditEntities_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New,
            this.Open,
            this.Save,
            this.toolStripSeparator1,
            this.zoomInButton,
            this.zoomOutButton,
            this.toolStripSeparator2,
            this.RunScene,
            this.toolStripSeparator8,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator9,
            this.pointerButton,
            this.selectTool,
            this.placeTilesButton,
            this.MagnetMode,
            this.toolStripSeparator4,
            this.ShowFGLow,
            this.ShowFGHigh,
            this.ShowEntities,
            this.ShowAnimations,
            this.toolStripSeparator5,
            this.EditFGLow,
            this.EditFGHigh,
            this.EditEntities,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // zoomInButton
            // 
            this.zoomInButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomInButton.Image")));
            this.zoomInButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(23, 22);
            this.zoomInButton.Text = "Zoom In (Ctrl + Wheel Up)";
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutButton.Image = ((System.Drawing.Image)(resources.GetObject("zoomOutButton.Image")));
            this.zoomOutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(23, 22);
            this.zoomOutButton.Text = "Zoom In (Ctrl + Wheel Down)";
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 22);
            this.undoButton.Text = "Undo {0} (Ctrl + Z)";
            this.undoButton.ToolTipText = "Undo (Ctrl + Z)";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(23, 22);
            this.redoButton.Text = "Redo {0} (Ctrl + Y)";
            this.redoButton.ToolTipText = "Redo (Ctrl + Y)";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // pointerButton
            // 
            this.pointerButton.Checked = true;
            this.pointerButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointerButton.Image = ((System.Drawing.Image)(resources.GetObject("pointerButton.Image")));
            this.pointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointerButton.Name = "pointerButton";
            this.pointerButton.Size = new System.Drawing.Size(23, 22);
            this.pointerButton.Text = "Select & move";
            this.pointerButton.Click += new System.EventHandler(this.pointerButton_Click);
            // 
            // selectTool
            // 
            this.selectTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectTool.Image = ((System.Drawing.Image)(resources.GetObject("selectTool.Image")));
            this.selectTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectTool.Name = "selectTool";
            this.selectTool.Size = new System.Drawing.Size(23, 22);
            this.selectTool.Text = "Selection Tool (To select groups of tiles and not dragged the clicked tile)";
            this.selectTool.Click += new System.EventHandler(this.selectTool_Click);
            // 
            // placeTilesButton
            // 
            this.placeTilesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.placeTilesButton.Image = ((System.Drawing.Image)(resources.GetObject("placeTilesButton.Image")));
            this.placeTilesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.placeTilesButton.Name = "placeTilesButton";
            this.placeTilesButton.Size = new System.Drawing.Size(23, 22);
            this.placeTilesButton.Text = "Place tiles (Right click [+drag] - place, Left click [+drag] - delete)";
            this.placeTilesButton.Click += new System.EventHandler(this.placeTilesButton_Click);
            // 
            // ShowAnimations
            // 
            this.ShowAnimations.Checked = true;
            this.ShowAnimations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowAnimations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ShowAnimations.Image = ((System.Drawing.Image)(resources.GetObject("ShowAnimations.Image")));
            this.ShowAnimations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowAnimations.Name = "ShowAnimations";
            this.ShowAnimations.Size = new System.Drawing.Size(72, 22);
            this.ShowAnimations.Text = "Animations";
            this.ShowAnimations.ToolTipText = "Hide Animations";
            this.ShowAnimations.Click += new System.EventHandler(this.ShowAnimations_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 759);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Editor";
            this.Text = "Maniac Editor - BETA (OtherworldBob Edition)";
            this.Activated += new System.EventHandler(this.MapEditor_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapEditor_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MapEditor_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.viewPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel mainPanel;
        //private System.Windows.Forms.Panel GraphicPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevicePanel GraphicPanel;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.ToolStripButton New;
        private System.Windows.Forms.ToolStripButton Open;
        private System.Windows.Forms.ToolStripButton Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton RunScene;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton MagnetMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripButton ShowFGLow;
        public System.Windows.Forms.ToolStripButton ShowFGHigh;
        public System.Windows.Forms.ToolStripButton ShowEntities;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripButton EditFGLow;
        public System.Windows.Forms.ToolStripButton EditFGHigh;
        public System.Windows.Forms.ToolStripButton EditEntities;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton zoomInButton;
        private System.Windows.Forms.ToolStripButton zoomOutButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton selectTool;
        private System.Windows.Forms.ToolStripButton pointerButton;
        private System.Windows.Forms.ToolStripButton placeTilesButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem sceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSoundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layerManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAspngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportEachLayerAspngToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton ShowAnimations;
    }
}

