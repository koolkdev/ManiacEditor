﻿namespace ManiacEditor
{
    partial class OptionBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionBox));
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SceneSelectRadio2 = new System.Windows.Forms.RadioButton();
            this.SceneSelectRadio1 = new System.Windows.Forms.RadioButton();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.enableWindowsClipboard = new System.Windows.Forms.CheckBox();
            this.tileToolbarZoomDefault = new System.Windows.Forms.TrackBar();
            this.animationsDefault = new System.Windows.Forms.CheckBox();
            this.entitiesDefault = new System.Windows.Forms.CheckBox();
            this.fgLowerDefault = new System.Windows.Forms.CheckBox();
            this.fgLowDefault = new System.Windows.Forms.CheckBox();
            this.fgHighDefault = new System.Windows.Forms.CheckBox();
            this.fgHigherDefault = new System.Windows.Forms.CheckBox();
            this.highLayerTextbox = new System.Windows.Forms.TextBox();
            this.lowLayerTextbox = new System.Windows.Forms.TextBox();
            this.solidTopDefault = new System.Windows.Forms.CheckBox();
            this.soildAllButTopDefault = new System.Windows.Forms.CheckBox();
            this.unknown1Default = new System.Windows.Forms.CheckBox();
            this.unkown2Default = new System.Windows.Forms.CheckBox();
            this.neverLoadEntityTextures = new System.Windows.Forms.CheckBox();
            this.copyUnlock = new System.Windows.Forms.CheckBox();
            this.layerHide = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tileToolbarZoomDefault)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Tiles Toolbar Defaults:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(215, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Default Visible Layers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(222, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Custom FG Layers:";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Lower Layer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Higher Layer:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(202, 261);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 49);
            this.label7.TabIndex = 44;
            this.label7.Text = "NOTE: You should reload the stage/scene to safely see changes";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 53);
            this.label1.TabIndex = 54;
            this.label1.Text = "Tiles Toolbar Default Zoom Level:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Varrious Settings:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 518);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Scene Select Default Format:";
            // 
            // SceneSelectRadio2
            // 
            this.SceneSelectRadio2.Checked = global::ManiacEditor.Properties.Settings.Default.SceneSelectRadioButton2On;
            this.SceneSelectRadio2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "SceneSelectRadioButton2On", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SceneSelectRadio2.Location = new System.Drawing.Point(68, 563);
            this.SceneSelectRadio2.Name = "SceneSelectRadio2";
            this.SceneSelectRadio2.Size = new System.Drawing.Size(87, 17);
            this.SceneSelectRadio2.TabIndex = 60;
            this.SceneSelectRadio2.Text = "Files View                  ";
            this.SceneSelectRadio2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SceneSelectRadio2.UseVisualStyleBackColor = true;
            this.SceneSelectRadio2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // SceneSelectRadio1
            // 
            this.SceneSelectRadio1.Checked = global::ManiacEditor.Properties.Settings.Default.SceneSelectRadioButton1On;
            this.SceneSelectRadio1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "SceneSelectRadioButton1On", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SceneSelectRadio1.Location = new System.Drawing.Point(68, 541);
            this.SceneSelectRadio1.Name = "SceneSelectRadio1";
            this.SceneSelectRadio1.Size = new System.Drawing.Size(87, 17);
            this.SceneSelectRadio1.TabIndex = 61;
            this.SceneSelectRadio1.TabStop = true;
            this.SceneSelectRadio1.Text = "Sorted View                   ";
            this.SceneSelectRadio1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SceneSelectRadio1.UseVisualStyleBackColor = true;
            this.SceneSelectRadio1.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = global::ManiacEditor.Properties.Settings.Default.RemoveObjectImportLock;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "RemoveObjectImportLock", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.Location = new System.Drawing.Point(28, 430);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(152, 73);
            this.checkBox2.TabIndex = 58;
            this.checkBox2.Text = "Remove Object Import Lock\r\n\r\n(Allows for you to upgrade your entities, etc.)\r\n";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = global::ManiacEditor.Properties.Settings.Default.ReduceZoom;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "ReduceZoom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(28, 362);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 58);
            this.checkBox1.TabIndex = 57;
            this.checkBox1.Text = "Reduce Maximum Zoom Level \r\n(Helps prevent slowdowns and crashes)";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // enableWindowsClipboard
            // 
            this.enableWindowsClipboard.Checked = global::ManiacEditor.Properties.Settings.Default.EnableWindowsClipboard;
            this.enableWindowsClipboard.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "EnableWindowsClipboard", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.enableWindowsClipboard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.enableWindowsClipboard.Location = new System.Drawing.Point(28, 285);
            this.enableWindowsClipboard.Margin = new System.Windows.Forms.Padding(5);
            this.enableWindowsClipboard.Name = "enableWindowsClipboard";
            this.enableWindowsClipboard.Size = new System.Drawing.Size(153, 67);
            this.enableWindowsClipboard.TabIndex = 56;
            this.enableWindowsClipboard.Text = "Enable Windows Clipboard \r\n(NOTE: Use at your own risk)";
            this.enableWindowsClipboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.enableWindowsClipboard.UseVisualStyleBackColor = true;
            // 
            // tileToolbarZoomDefault
            // 
            this.tileToolbarZoomDefault.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::ManiacEditor.Properties.Settings.Default, "tileToolbarDefaultZoomLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tileToolbarZoomDefault.LargeChange = 1;
            this.tileToolbarZoomDefault.Location = new System.Drawing.Point(241, 371);
            this.tileToolbarZoomDefault.Maximum = 3;
            this.tileToolbarZoomDefault.Name = "tileToolbarZoomDefault";
            this.tileToolbarZoomDefault.Size = new System.Drawing.Size(83, 45);
            this.tileToolbarZoomDefault.TabIndex = 53;
            this.tileToolbarZoomDefault.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tileToolbarZoomDefault.Value = global::ManiacEditor.Properties.Settings.Default.tileToolbarDefaultZoomLevel;
            // 
            // animationsDefault
            // 
            this.animationsDefault.AutoSize = true;
            this.animationsDefault.Checked = global::ManiacEditor.Properties.Settings.Default.AnimationsDefault;
            this.animationsDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.animationsDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "AnimationsDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.animationsDefault.Location = new System.Drawing.Point(251, 564);
            this.animationsDefault.Name = "animationsDefault";
            this.animationsDefault.Size = new System.Drawing.Size(77, 17);
            this.animationsDefault.TabIndex = 52;
            this.animationsDefault.Text = "Animations";
            this.animationsDefault.UseVisualStyleBackColor = true;
            this.animationsDefault.CheckedChanged += new System.EventHandler(this.animationsDefault_CheckedChanged);
            // 
            // entitiesDefault
            // 
            this.entitiesDefault.AutoSize = true;
            this.entitiesDefault.Checked = global::ManiacEditor.Properties.Settings.Default.EntitiesDefault;
            this.entitiesDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entitiesDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "EntitiesDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.entitiesDefault.Location = new System.Drawing.Point(251, 541);
            this.entitiesDefault.Name = "entitiesDefault";
            this.entitiesDefault.Size = new System.Drawing.Size(60, 17);
            this.entitiesDefault.TabIndex = 51;
            this.entitiesDefault.Text = "Entities";
            this.entitiesDefault.UseVisualStyleBackColor = true;
            this.entitiesDefault.CheckedChanged += new System.EventHandler(this.entitiesDefault_CheckedChanged);
            // 
            // fgLowerDefault
            // 
            this.fgLowerDefault.AutoSize = true;
            this.fgLowerDefault.Checked = global::ManiacEditor.Properties.Settings.Default.FGLowerDefault;
            this.fgLowerDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fgLowerDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "FGLowerDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fgLowerDefault.Location = new System.Drawing.Point(251, 449);
            this.fgLowerDefault.Name = "fgLowerDefault";
            this.fgLowerDefault.Size = new System.Drawing.Size(72, 17);
            this.fgLowerDefault.TabIndex = 48;
            this.fgLowerDefault.Text = "FG Lower";
            this.fgLowerDefault.UseVisualStyleBackColor = true;
            this.fgLowerDefault.CheckedChanged += new System.EventHandler(this.fgLowerDefault_CheckedChanged);
            // 
            // fgLowDefault
            // 
            this.fgLowDefault.AutoSize = true;
            this.fgLowDefault.Checked = global::ManiacEditor.Properties.Settings.Default.FGLowDefault;
            this.fgLowDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fgLowDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "FGLowDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fgLowDefault.Location = new System.Drawing.Point(251, 472);
            this.fgLowDefault.Name = "fgLowDefault";
            this.fgLowDefault.Size = new System.Drawing.Size(63, 17);
            this.fgLowDefault.TabIndex = 47;
            this.fgLowDefault.Text = "FG Low";
            this.fgLowDefault.UseVisualStyleBackColor = true;
            this.fgLowDefault.CheckedChanged += new System.EventHandler(this.fgLowDefault_CheckedChanged);
            // 
            // fgHighDefault
            // 
            this.fgHighDefault.AutoSize = true;
            this.fgHighDefault.Checked = global::ManiacEditor.Properties.Settings.Default.FGHighDefault;
            this.fgHighDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fgHighDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "FGHighDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fgHighDefault.Location = new System.Drawing.Point(251, 495);
            this.fgHighDefault.Name = "fgHighDefault";
            this.fgHighDefault.Size = new System.Drawing.Size(65, 17);
            this.fgHighDefault.TabIndex = 46;
            this.fgHighDefault.Text = "FG High";
            this.fgHighDefault.UseVisualStyleBackColor = true;
            this.fgHighDefault.CheckedChanged += new System.EventHandler(this.fgHighDefault_CheckedChanged);
            // 
            // fgHigherDefault
            // 
            this.fgHigherDefault.AutoSize = true;
            this.fgHigherDefault.Checked = global::ManiacEditor.Properties.Settings.Default.FGHigherDefault;
            this.fgHigherDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fgHigherDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "FGHigherDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fgHigherDefault.Location = new System.Drawing.Point(251, 518);
            this.fgHigherDefault.Name = "fgHigherDefault";
            this.fgHigherDefault.Size = new System.Drawing.Size(74, 17);
            this.fgHigherDefault.TabIndex = 45;
            this.fgHigherDefault.Text = "FG Higher";
            this.fgHigherDefault.UseVisualStyleBackColor = true;
            this.fgHigherDefault.CheckedChanged += new System.EventHandler(this.fgHigherDefault_CheckedChanged);
            // 
            // highLayerTextbox
            // 
            this.highLayerTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ManiacEditor.Properties.Settings.Default, "CustomLayerHigh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.highLayerTextbox.Location = new System.Drawing.Point(231, 234);
            this.highLayerTextbox.Name = "highLayerTextbox";
            this.highLayerTextbox.Size = new System.Drawing.Size(93, 20);
            this.highLayerTextbox.TabIndex = 41;
            this.highLayerTextbox.Text = global::ManiacEditor.Properties.Settings.Default.CustomLayerHigh;
            // 
            // lowLayerTextbox
            // 
            this.lowLayerTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ManiacEditor.Properties.Settings.Default, "CustomLayerLow", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lowLayerTextbox.Location = new System.Drawing.Point(231, 190);
            this.lowLayerTextbox.Name = "lowLayerTextbox";
            this.lowLayerTextbox.Size = new System.Drawing.Size(93, 20);
            this.lowLayerTextbox.TabIndex = 40;
            this.lowLayerTextbox.Text = global::ManiacEditor.Properties.Settings.Default.CustomLayerLow;
            // 
            // solidTopDefault
            // 
            this.solidTopDefault.AutoSize = true;
            this.solidTopDefault.Checked = global::ManiacEditor.Properties.Settings.Default.SolidTopDefault;
            this.solidTopDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "solidTopDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.solidTopDefault.Location = new System.Drawing.Point(212, 48);
            this.solidTopDefault.Name = "solidTopDefault";
            this.solidTopDefault.Size = new System.Drawing.Size(77, 17);
            this.solidTopDefault.TabIndex = 35;
            this.solidTopDefault.Text = "Solid (Top)";
            this.solidTopDefault.UseVisualStyleBackColor = true;
            this.solidTopDefault.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // soildAllButTopDefault
            // 
            this.soildAllButTopDefault.AutoSize = true;
            this.soildAllButTopDefault.Checked = global::ManiacEditor.Properties.Settings.Default.SolidAllButTopDefault;
            this.soildAllButTopDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "SolidAllButTopDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.soildAllButTopDefault.Location = new System.Drawing.Point(212, 71);
            this.soildAllButTopDefault.Name = "soildAllButTopDefault";
            this.soildAllButTopDefault.Size = new System.Drawing.Size(112, 17);
            this.soildAllButTopDefault.TabIndex = 34;
            this.soildAllButTopDefault.Text = "Solid (All excl. top)";
            this.soildAllButTopDefault.UseVisualStyleBackColor = true;
            this.soildAllButTopDefault.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // unknown1Default
            // 
            this.unknown1Default.AutoSize = true;
            this.unknown1Default.Checked = global::ManiacEditor.Properties.Settings.Default.Unkown1Default;
            this.unknown1Default.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "Unkown1Default", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.unknown1Default.Location = new System.Drawing.Point(212, 94);
            this.unknown1Default.Name = "unknown1Default";
            this.unknown1Default.Size = new System.Drawing.Size(122, 17);
            this.unknown1Default.TabIndex = 33;
            this.unknown1Default.Text = "Soild (Top) (Plane 2)";
            this.unknown1Default.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.unknown1Default.UseVisualStyleBackColor = true;
            this.unknown1Default.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // unkown2Default
            // 
            this.unkown2Default.AutoSize = true;
            this.unkown2Default.Checked = global::ManiacEditor.Properties.Settings.Default.Unkown2Default;
            this.unkown2Default.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "Unkown2Default", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.unkown2Default.Location = new System.Drawing.Point(212, 117);
            this.unkown2Default.Name = "unkown2Default";
            this.unkown2Default.Size = new System.Drawing.Size(157, 17);
            this.unkown2Default.TabIndex = 32;
            this.unkown2Default.Text = "Solid (All excl. top) (Plane 2)";
            this.unkown2Default.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.unkown2Default.UseVisualStyleBackColor = true;
            this.unkown2Default.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // neverLoadEntityTextures
            // 
            this.neverLoadEntityTextures.Checked = global::ManiacEditor.Properties.Settings.Default.NeverLoadEntityTextures;
            this.neverLoadEntityTextures.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "NeverLoadEntityTextures", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.neverLoadEntityTextures.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.neverLoadEntityTextures.Location = new System.Drawing.Point(31, 186);
            this.neverLoadEntityTextures.Margin = new System.Windows.Forms.Padding(5);
            this.neverLoadEntityTextures.Name = "neverLoadEntityTextures";
            this.neverLoadEntityTextures.Size = new System.Drawing.Size(152, 89);
            this.neverLoadEntityTextures.TabIndex = 30;
            this.neverLoadEntityTextures.Text = "Never load Entity Textures/Annimations \r\n\r\n(NOTE: Must reload textures to see cha" +
    "nges)\r\n";
            this.neverLoadEntityTextures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.neverLoadEntityTextures.UseVisualStyleBackColor = true;
            this.neverLoadEntityTextures.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // copyUnlock
            // 
            this.copyUnlock.Checked = global::ManiacEditor.Properties.Settings.Default.ForceCopyUnlock;
            this.copyUnlock.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "forceCopyUnlock", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.copyUnlock.Location = new System.Drawing.Point(31, 43);
            this.copyUnlock.Name = "copyUnlock";
            this.copyUnlock.Size = new System.Drawing.Size(152, 91);
            this.copyUnlock.TabIndex = 29;
            this.copyUnlock.Text = "Enable Copy between Scenes \r\n\r\n(WARNING: Use at your own risk)";
            this.copyUnlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.copyUnlock.UseVisualStyleBackColor = true;
            this.copyUnlock.CheckedChanged += new System.EventHandler(this.copyUnlock_CheckedChanged);
            // 
            // layerHide
            // 
            this.layerHide.Checked = global::ManiacEditor.Properties.Settings.Default.KeepLayersVisible;
            this.layerHide.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "keepLayersVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.layerHide.Location = new System.Drawing.Point(31, 142);
            this.layerHide.Margin = new System.Windows.Forms.Padding(5);
            this.layerHide.Name = "layerHide";
            this.layerHide.Size = new System.Drawing.Size(152, 34);
            this.layerHide.TabIndex = 28;
            this.layerHide.Text = "Keep Main Layers on when Editing Extra Layers";
            this.layerHide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.layerHide.UseVisualStyleBackColor = true;
            this.layerHide.CheckedChanged += new System.EventHandler(this.layerHide_CheckedChanged);
            // 
            // OptionBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 612);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SceneSelectRadio1);
            this.Controls.Add(this.SceneSelectRadio2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.enableWindowsClipboard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tileToolbarZoomDefault);
            this.Controls.Add(this.animationsDefault);
            this.Controls.Add(this.entitiesDefault);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fgLowerDefault);
            this.Controls.Add(this.fgLowDefault);
            this.Controls.Add(this.fgHighDefault);
            this.Controls.Add(this.fgHigherDefault);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.highLayerTextbox);
            this.Controls.Add(this.lowLayerTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.solidTopDefault);
            this.Controls.Add(this.soildAllButTopDefault);
            this.Controls.Add(this.unknown1Default);
            this.Controls.Add(this.unkown2Default);
            this.Controls.Add(this.neverLoadEntityTextures);
            this.Controls.Add(this.copyUnlock);
            this.Controls.Add(this.layerHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.Text = "Maniac Editor Options";
            this.Load += new System.EventHandler(this.OptionBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tileToolbarZoomDefault)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox layerHide;
        private System.Windows.Forms.CheckBox copyUnlock;
        private System.Windows.Forms.CheckBox neverLoadEntityTextures;
        private System.Windows.Forms.CheckBox unkown2Default;
        private System.Windows.Forms.CheckBox unknown1Default;
        private System.Windows.Forms.CheckBox soildAllButTopDefault;
        private System.Windows.Forms.CheckBox solidTopDefault;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox fgLowerDefault;
        private System.Windows.Forms.CheckBox fgLowDefault;
        private System.Windows.Forms.CheckBox fgHighDefault;
        private System.Windows.Forms.CheckBox fgHigherDefault;
        private System.Windows.Forms.CheckBox entitiesDefault;
        private System.Windows.Forms.CheckBox animationsDefault;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lowLayerTextbox;
        private System.Windows.Forms.TextBox highLayerTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tileToolbarZoomDefault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox enableWindowsClipboard;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.RadioButton SceneSelectRadio2;
        private System.Windows.Forms.RadioButton SceneSelectRadio1;
        private System.Windows.Forms.Label label8;
    }
}