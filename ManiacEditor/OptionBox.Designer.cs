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
            this.neverLoadEntityTextures = new System.Windows.Forms.CheckBox();
            this.copyUnlock = new System.Windows.Forms.CheckBox();
            this.layerHide = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // neverLoadEntityTextures
            // 
            this.neverLoadEntityTextures.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.neverLoadEntityTextures.Checked = global::ManiacEditor.Properties.Settings.Default.NeverLoadEntityTextures;
            this.neverLoadEntityTextures.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "NeverLoadEntityTextures", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.neverLoadEntityTextures.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.neverLoadEntityTextures.Location = new System.Drawing.Point(14, 138);
            this.neverLoadEntityTextures.Margin = new System.Windows.Forms.Padding(5);
            this.neverLoadEntityTextures.Name = "neverLoadEntityTextures";
            this.neverLoadEntityTextures.Size = new System.Drawing.Size(137, 89);
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
            this.copyUnlock.Location = new System.Drawing.Point(14, 67);
            this.copyUnlock.Name = "copyUnlock";
            this.copyUnlock.Size = new System.Drawing.Size(120, 63);
            this.copyUnlock.TabIndex = 29;
            this.copyUnlock.Text = "Enable Copy between Scenes (WARNING: Use at your own risk)";
            this.copyUnlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.copyUnlock.UseVisualStyleBackColor = true;
            // 
            // layerHide
            // 
            this.layerHide.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.layerHide.Checked = global::ManiacEditor.Properties.Settings.Default.KeepLayersVisible;
            this.layerHide.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "keepLayersVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.layerHide.Location = new System.Drawing.Point(14, 14);
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
            this.ClientSize = new System.Drawing.Size(284, 261);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox layerHide;
        private System.Windows.Forms.CheckBox copyUnlock;
        private System.Windows.Forms.CheckBox neverLoadEntityTextures;
    }
}