namespace ManiacEditor
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Tiles Toolbar Defaults:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(162, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 2);
            this.label1.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Custom FG Layers:";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(162, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 2);
            this.label4.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Lower Layer:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Higher Layer:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(161, 259);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 98);
            this.label7.TabIndex = 44;
            this.label7.Text = "NOTE: You should reload the stage/scene to safely see changes";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(14, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 2);
            this.label8.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Default Visible Layers:";
            // 
            // animationsDefault
            // 
            this.animationsDefault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.animationsDefault.AutoSize = true;
            this.animationsDefault.Checked = global::ManiacEditor.Properties.Settings.Default.AnimationsDefault;
            this.animationsDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.animationsDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "AnimationsDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.animationsDefault.Location = new System.Drawing.Point(14, 392);
            this.animationsDefault.Name = "animationsDefault";
            this.animationsDefault.Size = new System.Drawing.Size(77, 17);
            this.animationsDefault.TabIndex = 52;
            this.animationsDefault.Text = "Animations";
            this.animationsDefault.UseVisualStyleBackColor = true;
            // 
            // entitiesDefault
            // 
            this.entitiesDefault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.entitiesDefault.AutoSize = true;
            this.entitiesDefault.Checked = global::ManiacEditor.Properties.Settings.Default.EntitiesDefault;
            this.entitiesDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entitiesDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "EntitiesDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.entitiesDefault.Location = new System.Drawing.Point(14, 369);
            this.entitiesDefault.Name = "entitiesDefault";
            this.entitiesDefault.Size = new System.Drawing.Size(60, 17);
            this.entitiesDefault.TabIndex = 51;
            this.entitiesDefault.Text = "Entities";
            this.entitiesDefault.UseVisualStyleBackColor = true;
            // 
            // fgLowerDefault
            // 
            this.fgLowerDefault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fgLowerDefault.AutoSize = true;
            this.fgLowerDefault.Checked = global::ManiacEditor.Properties.Settings.Default.FGLowerDefault;
            this.fgLowerDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fgLowerDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "FGLowerDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fgLowerDefault.Location = new System.Drawing.Point(14, 277);
            this.fgLowerDefault.Name = "fgLowerDefault";
            this.fgLowerDefault.Size = new System.Drawing.Size(72, 17);
            this.fgLowerDefault.TabIndex = 48;
            this.fgLowerDefault.Text = "FG Lower";
            this.fgLowerDefault.UseVisualStyleBackColor = true;
            // 
            // fgLowDefault
            // 
            this.fgLowDefault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fgLowDefault.AutoSize = true;
            this.fgLowDefault.Checked = global::ManiacEditor.Properties.Settings.Default.FGLowDefault;
            this.fgLowDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fgLowDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "FGLowDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fgLowDefault.Location = new System.Drawing.Point(14, 300);
            this.fgLowDefault.Name = "fgLowDefault";
            this.fgLowDefault.Size = new System.Drawing.Size(63, 17);
            this.fgLowDefault.TabIndex = 47;
            this.fgLowDefault.Text = "FG Low";
            this.fgLowDefault.UseVisualStyleBackColor = true;
            // 
            // fgHighDefault
            // 
            this.fgHighDefault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fgHighDefault.AutoSize = true;
            this.fgHighDefault.Checked = global::ManiacEditor.Properties.Settings.Default.FGHighDefault;
            this.fgHighDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fgHighDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "FGHighDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fgHighDefault.Location = new System.Drawing.Point(14, 323);
            this.fgHighDefault.Name = "fgHighDefault";
            this.fgHighDefault.Size = new System.Drawing.Size(65, 17);
            this.fgHighDefault.TabIndex = 46;
            this.fgHighDefault.Text = "FG High";
            this.fgHighDefault.UseVisualStyleBackColor = true;
            // 
            // fgHigherDefault
            // 
            this.fgHigherDefault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fgHigherDefault.AutoSize = true;
            this.fgHigherDefault.Checked = global::ManiacEditor.Properties.Settings.Default.FGHigherDefault;
            this.fgHigherDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fgHigherDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "FGHigherDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fgHigherDefault.Location = new System.Drawing.Point(14, 346);
            this.fgHigherDefault.Name = "fgHigherDefault";
            this.fgHigherDefault.Size = new System.Drawing.Size(74, 17);
            this.fgHigherDefault.TabIndex = 45;
            this.fgHigherDefault.Text = "FG Higher";
            this.fgHigherDefault.UseVisualStyleBackColor = true;
            // 
            // highLayerTextbox
            // 
            this.highLayerTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ManiacEditor.Properties.Settings.Default, "CustomLayerHigh", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.highLayerTextbox.Location = new System.Drawing.Point(162, 233);
            this.highLayerTextbox.Name = "highLayerTextbox";
            this.highLayerTextbox.Size = new System.Drawing.Size(100, 20);
            this.highLayerTextbox.TabIndex = 41;
            this.highLayerTextbox.Text = global::ManiacEditor.Properties.Settings.Default.CustomLayerHigh;
            // 
            // lowLayerTextbox
            // 
            this.lowLayerTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ManiacEditor.Properties.Settings.Default, "CustomLayerLow", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lowLayerTextbox.Location = new System.Drawing.Point(162, 194);
            this.lowLayerTextbox.Name = "lowLayerTextbox";
            this.lowLayerTextbox.Size = new System.Drawing.Size(100, 20);
            this.lowLayerTextbox.TabIndex = 40;
            this.lowLayerTextbox.Text = global::ManiacEditor.Properties.Settings.Default.CustomLayerLow;
            // 
            // solidTopDefault
            // 
            this.solidTopDefault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.solidTopDefault.AutoSize = true;
            this.solidTopDefault.Checked = global::ManiacEditor.Properties.Settings.Default.SolidTopDefault;
            this.solidTopDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "solidTopDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.solidTopDefault.Location = new System.Drawing.Point(162, 38);
            this.solidTopDefault.Name = "solidTopDefault";
            this.solidTopDefault.Size = new System.Drawing.Size(77, 17);
            this.solidTopDefault.TabIndex = 35;
            this.solidTopDefault.Text = "Solid (Top)";
            this.solidTopDefault.UseVisualStyleBackColor = true;
            this.solidTopDefault.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // soildAllButTopDefault
            // 
            this.soildAllButTopDefault.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.soildAllButTopDefault.AutoSize = true;
            this.soildAllButTopDefault.Checked = global::ManiacEditor.Properties.Settings.Default.SolidAllButTopDefault;
            this.soildAllButTopDefault.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "SolidAllButTopDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.soildAllButTopDefault.Location = new System.Drawing.Point(162, 61);
            this.soildAllButTopDefault.Name = "soildAllButTopDefault";
            this.soildAllButTopDefault.Size = new System.Drawing.Size(112, 17);
            this.soildAllButTopDefault.TabIndex = 34;
            this.soildAllButTopDefault.Text = "Solid (All excl. top)";
            this.soildAllButTopDefault.UseVisualStyleBackColor = true;
            this.soildAllButTopDefault.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // unknown1Default
            // 
            this.unknown1Default.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.unknown1Default.AutoSize = true;
            this.unknown1Default.Checked = global::ManiacEditor.Properties.Settings.Default.Unkown1Default;
            this.unknown1Default.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "Unkown1Default", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.unknown1Default.Location = new System.Drawing.Point(162, 84);
            this.unknown1Default.Name = "unknown1Default";
            this.unknown1Default.Size = new System.Drawing.Size(75, 17);
            this.unknown1Default.TabIndex = 33;
            this.unknown1Default.Text = "Unkown 1";
            this.unknown1Default.UseVisualStyleBackColor = true;
            this.unknown1Default.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // unkown2Default
            // 
            this.unkown2Default.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.unkown2Default.AutoSize = true;
            this.unkown2Default.Checked = global::ManiacEditor.Properties.Settings.Default.Unkown2Default;
            this.unkown2Default.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "Unkown2Default", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.unkown2Default.Location = new System.Drawing.Point(162, 107);
            this.unkown2Default.Name = "unkown2Default";
            this.unkown2Default.Size = new System.Drawing.Size(75, 17);
            this.unkown2Default.TabIndex = 32;
            this.unkown2Default.Text = "Unkown 2";
            this.unkown2Default.UseVisualStyleBackColor = true;
            this.unkown2Default.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // neverLoadEntityTextures
            // 
            this.neverLoadEntityTextures.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.neverLoadEntityTextures.Checked = global::ManiacEditor.Properties.Settings.Default.NeverLoadEntityTextures;
            this.neverLoadEntityTextures.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "NeverLoadEntityTextures", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.neverLoadEntityTextures.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.neverLoadEntityTextures.Location = new System.Drawing.Point(14, 160);
            this.neverLoadEntityTextures.Margin = new System.Windows.Forms.Padding(5);
            this.neverLoadEntityTextures.Name = "neverLoadEntityTextures";
            this.neverLoadEntityTextures.Size = new System.Drawing.Size(130, 89);
            this.neverLoadEntityTextures.TabIndex = 30;
            this.neverLoadEntityTextures.Text = "Never load Entity Textures/Annimations (NOTE: Must reload textures to see changes" +
    ")\r\n";
            this.neverLoadEntityTextures.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.neverLoadEntityTextures.UseVisualStyleBackColor = true;
            this.neverLoadEntityTextures.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // copyUnlock
            // 
            this.copyUnlock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.copyUnlock.Checked = global::ManiacEditor.Properties.Settings.Default.ForceCopyUnlock;
            this.copyUnlock.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "forceCopyUnlock", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.copyUnlock.Location = new System.Drawing.Point(14, 34);
            this.copyUnlock.Name = "copyUnlock";
            this.copyUnlock.Size = new System.Drawing.Size(120, 63);
            this.copyUnlock.TabIndex = 29;
            this.copyUnlock.Text = "Enable Copy between Scenes (WARNING: Use at your own risk)";
            this.copyUnlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.copyUnlock.UseVisualStyleBackColor = true;
            this.copyUnlock.CheckedChanged += new System.EventHandler(this.copyUnlock_CheckedChanged);
            // 
            // layerHide
            // 
            this.layerHide.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.layerHide.Checked = global::ManiacEditor.Properties.Settings.Default.KeepLayersVisible;
            this.layerHide.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "keepLayersVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.layerHide.Location = new System.Drawing.Point(14, 105);
            this.layerHide.Margin = new System.Windows.Forms.Padding(5);
            this.layerHide.Name = "layerHide";
            this.layerHide.Size = new System.Drawing.Size(116, 45);
            this.layerHide.TabIndex = 28;
            this.layerHide.Text = "Keep Main Layers on when Editing Extra Layers";
            this.layerHide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.layerHide.UseVisualStyleBackColor = true;
            // 
            // OptionBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 443);
            this.Controls.Add(this.animationsDefault);
            this.Controls.Add(this.entitiesDefault);
            this.Controls.Add(this.label8);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.solidTopDefault);
            this.Controls.Add(this.soildAllButTopDefault);
            this.Controls.Add(this.unknown1Default);
            this.Controls.Add(this.unkown2Default);
            this.Controls.Add(this.neverLoadEntityTextures);
            this.Controls.Add(this.copyUnlock);
            this.Controls.Add(this.layerHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Maniac Editor Options";
            this.Load += new System.EventHandler(this.OptionBox_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lowLayerTextbox;
        private System.Windows.Forms.TextBox highLayerTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox fgLowerDefault;
        private System.Windows.Forms.CheckBox fgLowDefault;
        private System.Windows.Forms.CheckBox fgHighDefault;
        private System.Windows.Forms.CheckBox fgHigherDefault;
        private System.Windows.Forms.CheckBox entitiesDefault;
        private System.Windows.Forms.CheckBox animationsDefault;
    }
}