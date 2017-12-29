namespace ManiacEditor
{
    partial class LayerManager
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
            this.components = new System.ComponentModel.Container();
            this.lbLayers = new System.Windows.Forms.ListBox();
            this.bsLayers = new System.Windows.Forms.BindingSource(this.components);
            this.gbRawSize = new System.Windows.Forms.GroupBox();
            this.flpEffectiveSize = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEffective = new System.Windows.Forms.Label();
            this.lblEffSizeWidth = new System.Windows.Forms.Label();
            this.lblEffSizeHeight = new System.Windows.Forms.Label();
            this.flpCurrentSize = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRaw = new System.Windows.Forms.Label();
            this.lblRawWidthValue = new System.Windows.Forms.Label();
            this.lblRawHeightValue = new System.Windows.Forms.Label();
            this.gbResize = new System.Windows.Forms.GroupBox();
            this.lblResizeWarnInstruct = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lblWidth = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHeight = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.lblResizedEffective = new System.Windows.Forms.Label();
            this.btnResize = new System.Windows.Forms.Button();
            this.gbName = new System.Windows.Forms.GroupBox();
            this.flpAttributes = new System.Windows.Forms.FlowLayoutPanel();
            this.panelName = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nudVerticalScroll = new System.Windows.Forms.NumericUpDown();
            this.lblVertical = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nudUnknownByte2 = new System.Windows.Forms.NumericUpDown();
            this.lblUnknownByte2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nudUnknownWord1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nudUnknownWord2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panelLayers = new System.Windows.Forms.Panel();
            this.flpLayerbuttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.rtbWarn = new System.Windows.Forms.RichTextBox();
            this.toolTipProvider = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsLayers)).BeginInit();
            this.gbRawSize.SuspendLayout();
            this.flpEffectiveSize.SuspendLayout();
            this.flpCurrentSize.SuspendLayout();
            this.gbResize.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.gbName.SuspendLayout();
            this.flpAttributes.SuspendLayout();
            this.panelName.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerticalScroll)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnknownByte2)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnknownWord1)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnknownWord2)).BeginInit();
            this.panelLayers.SuspendLayout();
            this.flpLayerbuttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLayers
            // 
            this.lbLayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLayers.DataSource = this.bsLayers;
            this.lbLayers.FormattingEnabled = true;
            this.lbLayers.Location = new System.Drawing.Point(0, 0);
            this.lbLayers.Name = "lbLayers";
            this.lbLayers.Size = new System.Drawing.Size(124, 355);
            this.lbLayers.TabIndex = 0;
            // 
            // gbRawSize
            // 
            this.gbRawSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRawSize.Controls.Add(this.flpEffectiveSize);
            this.gbRawSize.Controls.Add(this.flpCurrentSize);
            this.gbRawSize.Location = new System.Drawing.Point(129, 173);
            this.gbRawSize.Name = "gbRawSize";
            this.gbRawSize.Size = new System.Drawing.Size(323, 63);
            this.gbRawSize.TabIndex = 11;
            this.gbRawSize.TabStop = false;
            this.gbRawSize.Text = "Current Size";
            // 
            // flpEffectiveSize
            // 
            this.flpEffectiveSize.Controls.Add(this.lblEffective);
            this.flpEffectiveSize.Controls.Add(this.lblEffSizeWidth);
            this.flpEffectiveSize.Controls.Add(this.lblEffSizeHeight);
            this.flpEffectiveSize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpEffectiveSize.Location = new System.Drawing.Point(3, 40);
            this.flpEffectiveSize.Name = "flpEffectiveSize";
            this.flpEffectiveSize.Size = new System.Drawing.Size(317, 20);
            this.flpEffectiveSize.TabIndex = 12;
            // 
            // lblEffective
            // 
            this.lblEffective.AutoSize = true;
            this.lblEffective.Location = new System.Drawing.Point(3, 0);
            this.lblEffective.Name = "lblEffective";
            this.lblEffective.Size = new System.Drawing.Size(55, 13);
            this.lblEffective.TabIndex = 13;
            this.lblEffective.Text = "Effective: ";
            // 
            // lblEffSizeWidth
            // 
            this.lblEffSizeWidth.AutoSize = true;
            this.lblEffSizeWidth.Location = new System.Drawing.Point(64, 0);
            this.lblEffSizeWidth.Name = "lblEffSizeWidth";
            this.lblEffSizeWidth.Size = new System.Drawing.Size(13, 13);
            this.lblEffSizeWidth.TabIndex = 11;
            this.lblEffSizeWidth.Text = "0";
            // 
            // lblEffSizeHeight
            // 
            this.lblEffSizeHeight.AutoSize = true;
            this.lblEffSizeHeight.Location = new System.Drawing.Point(83, 0);
            this.lblEffSizeHeight.Name = "lblEffSizeHeight";
            this.lblEffSizeHeight.Size = new System.Drawing.Size(13, 13);
            this.lblEffSizeHeight.TabIndex = 12;
            this.lblEffSizeHeight.Text = "0";
            // 
            // flpCurrentSize
            // 
            this.flpCurrentSize.Controls.Add(this.lblRaw);
            this.flpCurrentSize.Controls.Add(this.lblRawWidthValue);
            this.flpCurrentSize.Controls.Add(this.lblRawHeightValue);
            this.flpCurrentSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCurrentSize.Location = new System.Drawing.Point(3, 16);
            this.flpCurrentSize.Name = "flpCurrentSize";
            this.flpCurrentSize.Size = new System.Drawing.Size(317, 20);
            this.flpCurrentSize.TabIndex = 6;
            // 
            // lblRaw
            // 
            this.lblRaw.AutoSize = true;
            this.lblRaw.Location = new System.Drawing.Point(3, 0);
            this.lblRaw.Name = "lblRaw";
            this.lblRaw.Size = new System.Drawing.Size(32, 13);
            this.lblRaw.TabIndex = 8;
            this.lblRaw.Text = "Raw:";
            // 
            // lblRawWidthValue
            // 
            this.lblRawWidthValue.AutoSize = true;
            this.lblRawWidthValue.Location = new System.Drawing.Point(41, 0);
            this.lblRawWidthValue.Name = "lblRawWidthValue";
            this.lblRawWidthValue.Size = new System.Drawing.Size(13, 13);
            this.lblRawWidthValue.TabIndex = 6;
            this.lblRawWidthValue.Text = "0";
            // 
            // lblRawHeightValue
            // 
            this.lblRawHeightValue.AutoSize = true;
            this.lblRawHeightValue.Location = new System.Drawing.Point(60, 0);
            this.lblRawHeightValue.Name = "lblRawHeightValue";
            this.lblRawHeightValue.Size = new System.Drawing.Size(13, 13);
            this.lblRawHeightValue.TabIndex = 7;
            this.lblRawHeightValue.Text = "0";
            // 
            // gbResize
            // 
            this.gbResize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResize.Controls.Add(this.lblResizeWarnInstruct);
            this.gbResize.Controls.Add(this.panel1);
            this.gbResize.Controls.Add(this.panel2);
            this.gbResize.Controls.Add(this.lblResizedEffective);
            this.gbResize.Controls.Add(this.btnResize);
            this.gbResize.Location = new System.Drawing.Point(129, 239);
            this.gbResize.Name = "gbResize";
            this.gbResize.Size = new System.Drawing.Size(323, 141);
            this.gbResize.TabIndex = 1;
            this.gbResize.TabStop = false;
            this.gbResize.Text = "Resize";
            // 
            // lblResizeWarnInstruct
            // 
            this.lblResizeWarnInstruct.Location = new System.Drawing.Point(6, 84);
            this.lblResizeWarnInstruct.Name = "lblResizeWarnInstruct";
            this.lblResizeWarnInstruct.Size = new System.Drawing.Size(309, 29);
            this.lblResizeWarnInstruct.TabIndex = 15;
            this.lblResizeWarnInstruct.Text = "It is recommended to keep any Foreground layers (normally named FG Low and FG Hig" +
    "h) the same size.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudWidth);
            this.panel1.Controls.Add(this.lblWidth);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 28);
            this.panel1.TabIndex = 0;
            // 
            // nudWidth
            // 
            this.nudWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWidth.Location = new System.Drawing.Point(47, 3);
            this.nudWidth.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(104, 20);
            this.nudWidth.TabIndex = 1;
            this.nudWidth.ThousandsSeparator = true;
            this.nudWidth.ValueChanged += new System.EventHandler(this.DesiredSizeChanged);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(3, 5);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblHeight);
            this.panel2.Controls.Add(this.nudHeight);
            this.panel2.Location = new System.Drawing.Point(163, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 27);
            this.panel2.TabIndex = 0;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(2, 5);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "Height:";
            // 
            // nudHeight
            // 
            this.nudHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudHeight.Location = new System.Drawing.Point(47, 3);
            this.nudHeight.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(104, 20);
            this.nudHeight.TabIndex = 2;
            this.nudHeight.ThousandsSeparator = true;
            this.nudHeight.ValueChanged += new System.EventHandler(this.DesiredSizeChanged);
            // 
            // lblResizedEffective
            // 
            this.lblResizedEffective.AutoSize = true;
            this.lblResizedEffective.Location = new System.Drawing.Point(6, 50);
            this.lblResizedEffective.Name = "lblResizedEffective";
            this.lblResizedEffective.Size = new System.Drawing.Size(72, 13);
            this.lblResizedEffective.TabIndex = 4;
            this.lblResizedEffective.Text = "Effective Size";
            // 
            // btnResize
            // 
            this.btnResize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnResize.Location = new System.Drawing.Point(3, 115);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(317, 23);
            this.btnResize.TabIndex = 3;
            this.btnResize.Text = "Resize Layer";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // gbName
            // 
            this.gbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbName.Controls.Add(this.flpAttributes);
            this.gbName.Location = new System.Drawing.Point(129, 54);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(323, 116);
            this.gbName.TabIndex = 14;
            this.gbName.TabStop = false;
            this.gbName.Text = "Attributes";
            this.toolTipProvider.SetToolTip(this.gbName, "If you figure out what any of the \"Unknown\" values actually do. \r\nLet me know!");
            // 
            // flpAttributes
            // 
            this.flpAttributes.Controls.Add(this.panelName);
            this.flpAttributes.Controls.Add(this.panel3);
            this.flpAttributes.Controls.Add(this.panel4);
            this.flpAttributes.Controls.Add(this.panel5);
            this.flpAttributes.Controls.Add(this.panel6);
            this.flpAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAttributes.Location = new System.Drawing.Point(3, 16);
            this.flpAttributes.Name = "flpAttributes";
            this.flpAttributes.Size = new System.Drawing.Size(317, 97);
            this.flpAttributes.TabIndex = 0;
            // 
            // panelName
            // 
            this.panelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelName.Controls.Add(this.lblName);
            this.panelName.Controls.Add(this.tbName);
            this.flpAttributes.SetFlowBreak(this.panelName, true);
            this.panelName.Location = new System.Drawing.Point(3, 3);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(309, 29);
            this.panelName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(0, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(41, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(265, 20);
            this.tbName.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.nudVerticalScroll);
            this.panel3.Controls.Add(this.lblVertical);
            this.panel3.Location = new System.Drawing.Point(3, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(151, 26);
            this.panel3.TabIndex = 3;
            // 
            // nudVerticalScroll
            // 
            this.nudVerticalScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudVerticalScroll.Location = new System.Drawing.Point(95, 3);
            this.nudVerticalScroll.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudVerticalScroll.Name = "nudVerticalScroll";
            this.nudVerticalScroll.Size = new System.Drawing.Size(53, 20);
            this.nudVerticalScroll.TabIndex = 1;
            // 
            // lblVertical
            // 
            this.lblVertical.AutoSize = true;
            this.lblVertical.Location = new System.Drawing.Point(1, 5);
            this.lblVertical.Name = "lblVertical";
            this.lblVertical.Size = new System.Drawing.Size(88, 13);
            this.lblVertical.TabIndex = 0;
            this.lblVertical.Text = "Vertical Scrolling:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.nudUnknownByte2);
            this.panel4.Controls.Add(this.lblUnknownByte2);
            this.flpAttributes.SetFlowBreak(this.panel4, true);
            this.panel4.Location = new System.Drawing.Point(160, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(151, 26);
            this.panel4.TabIndex = 4;
            // 
            // nudUnknownByte2
            // 
            this.nudUnknownByte2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudUnknownByte2.Location = new System.Drawing.Point(95, 3);
            this.nudUnknownByte2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudUnknownByte2.Name = "nudUnknownByte2";
            this.nudUnknownByte2.Size = new System.Drawing.Size(53, 20);
            this.nudUnknownByte2.TabIndex = 1;
            // 
            // lblUnknownByte2
            // 
            this.lblUnknownByte2.AutoSize = true;
            this.lblUnknownByte2.Location = new System.Drawing.Point(1, 5);
            this.lblUnknownByte2.Name = "lblUnknownByte2";
            this.lblUnknownByte2.Size = new System.Drawing.Size(89, 13);
            this.lblUnknownByte2.TabIndex = 0;
            this.lblUnknownByte2.Text = "Unknown Byte 2:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.nudUnknownWord1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(3, 70);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(151, 26);
            this.panel5.TabIndex = 5;
            // 
            // nudUnknownWord1
            // 
            this.nudUnknownWord1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudUnknownWord1.Location = new System.Drawing.Point(95, 3);
            this.nudUnknownWord1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudUnknownWord1.Name = "nudUnknownWord1";
            this.nudUnknownWord1.Size = new System.Drawing.Size(53, 20);
            this.nudUnknownWord1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unknown Value 1:";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.nudUnknownWord2);
            this.panel6.Controls.Add(this.label2);
            this.flpAttributes.SetFlowBreak(this.panel6, true);
            this.panel6.Location = new System.Drawing.Point(160, 70);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(151, 26);
            this.panel6.TabIndex = 6;
            // 
            // nudUnknownWord2
            // 
            this.nudUnknownWord2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudUnknownWord2.Location = new System.Drawing.Point(95, 3);
            this.nudUnknownWord2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudUnknownWord2.Name = "nudUnknownWord2";
            this.nudUnknownWord2.Size = new System.Drawing.Size(53, 20);
            this.nudUnknownWord2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Unknown Value 2:";
            // 
            // panelLayers
            // 
            this.panelLayers.Controls.Add(this.flpLayerbuttons);
            this.panelLayers.Controls.Add(this.lbLayers);
            this.panelLayers.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLayers.Location = new System.Drawing.Point(0, 0);
            this.panelLayers.Name = "panelLayers";
            this.panelLayers.Size = new System.Drawing.Size(124, 387);
            this.panelLayers.TabIndex = 1;
            // 
            // flpLayerbuttons
            // 
            this.flpLayerbuttons.Controls.Add(this.btnUp);
            this.flpLayerbuttons.Controls.Add(this.btnDown);
            this.flpLayerbuttons.Controls.Add(this.btnAdd);
            this.flpLayerbuttons.Controls.Add(this.btnDelete);
            this.flpLayerbuttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpLayerbuttons.Location = new System.Drawing.Point(0, 358);
            this.flpLayerbuttons.Name = "flpLayerbuttons";
            this.flpLayerbuttons.Size = new System.Drawing.Size(124, 29);
            this.flpLayerbuttons.TabIndex = 4;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(3, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 23);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "↑";
            this.toolTipProvider.SetToolTip(this.btnUp, "Move layer further into background.");
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(32, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(23, 23);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "↓";
            this.toolTipProvider.SetToolTip(this.btnDown, "Move layer further into foreground.");
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAdd.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.Location = new System.Drawing.Point(61, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+";
            this.toolTipProvider.SetToolTip(this.btnAdd, "Add new layer.");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(90, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "-";
            this.toolTipProvider.SetToolTip(this.btnDelete, "Delete selected layer.");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // rtbWarn
            // 
            this.rtbWarn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbWarn.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbWarn.Location = new System.Drawing.Point(124, 0);
            this.rtbWarn.Name = "rtbWarn";
            this.rtbWarn.ReadOnly = true;
            this.rtbWarn.Size = new System.Drawing.Size(340, 48);
            this.rtbWarn.TabIndex = 15;
            this.rtbWarn.Text = "The feature is highly experimental! Any changes made will be reflected when this " +
    "window is closed. Don\'t forget to save after! You did take that backup, didn\'t y" +
    "ou?";
            // 
            // LayerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 387);
            this.Controls.Add(this.rtbWarn);
            this.Controls.Add(this.panelLayers);
            this.Controls.Add(this.gbName);
            this.Controls.Add(this.gbResize);
            this.Controls.Add(this.gbRawSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 425);
            this.Name = "LayerManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layer Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LayerManager_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.bsLayers)).EndInit();
            this.gbRawSize.ResumeLayout(false);
            this.flpEffectiveSize.ResumeLayout(false);
            this.flpEffectiveSize.PerformLayout();
            this.flpCurrentSize.ResumeLayout(false);
            this.flpCurrentSize.PerformLayout();
            this.gbResize.ResumeLayout(false);
            this.gbResize.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.gbName.ResumeLayout(false);
            this.flpAttributes.ResumeLayout(false);
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVerticalScroll)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnknownByte2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnknownWord1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnknownWord2)).EndInit();
            this.panelLayers.ResumeLayout(false);
            this.flpLayerbuttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLayers;
        private System.Windows.Forms.BindingSource bsLayers;
        private System.Windows.Forms.GroupBox gbRawSize;
        private System.Windows.Forms.FlowLayoutPanel flpCurrentSize;
        private System.Windows.Forms.Label lblRawWidthValue;
        private System.Windows.Forms.Label lblRawHeightValue;
        private System.Windows.Forms.GroupBox gbResize;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label lblResizedEffective;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblResizeWarnInstruct;
        private System.Windows.Forms.FlowLayoutPanel flpEffectiveSize;
        private System.Windows.Forms.Label lblEffSizeWidth;
        private System.Windows.Forms.Label lblEffSizeHeight;
        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.Label lblEffective;
        private System.Windows.Forms.Label lblRaw;
        private System.Windows.Forms.FlowLayoutPanel flpAttributes;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown nudVerticalScroll;
        private System.Windows.Forms.Label lblVertical;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nudUnknownByte2;
        private System.Windows.Forms.Label lblUnknownByte2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown nudUnknownWord1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.NumericUpDown nudUnknownWord2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelLayers;
        private System.Windows.Forms.FlowLayoutPanel flpLayerbuttons;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.RichTextBox rtbWarn;
        private System.Windows.Forms.ToolTip toolTipProvider;
    }
}