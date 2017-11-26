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
            this.gbEffSize = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRawWidthValue = new System.Windows.Forms.Label();
            this.lblRawHeightValue = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEffSizeWidth = new System.Windows.Forms.Label();
            this.lblEffSizeHeight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsLayers)).BeginInit();
            this.gbRawSize.SuspendLayout();
            this.gbEffSize.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLayers
            // 
            this.lbLayers.DataSource = this.bsLayers;
            this.lbLayers.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbLayers.FormattingEnabled = true;
            this.lbLayers.Location = new System.Drawing.Point(0, 0);
            this.lbLayers.Name = "lbLayers";
            this.lbLayers.Size = new System.Drawing.Size(120, 262);
            this.lbLayers.TabIndex = 0;
            // 
            // gbRawSize
            // 
            this.gbRawSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRawSize.Controls.Add(this.flowLayoutPanel1);
            this.gbRawSize.Location = new System.Drawing.Point(129, 0);
            this.gbRawSize.Name = "gbRawSize";
            this.gbRawSize.Size = new System.Drawing.Size(243, 39);
            this.gbRawSize.TabIndex = 11;
            this.gbRawSize.TabStop = false;
            this.gbRawSize.Text = "Raw Size";
            // 
            // gbEffSize
            // 
            this.gbEffSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEffSize.Controls.Add(this.flowLayoutPanel2);
            this.gbEffSize.Location = new System.Drawing.Point(129, 45);
            this.gbEffSize.Name = "gbEffSize";
            this.gbEffSize.Size = new System.Drawing.Size(243, 39);
            this.gbEffSize.TabIndex = 12;
            this.gbEffSize.TabStop = false;
            this.gbEffSize.Text = "Effective Size";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblRawWidthValue);
            this.flowLayoutPanel1.Controls.Add(this.lblRawHeightValue);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(237, 20);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // lblRawWidthValue
            // 
            this.lblRawWidthValue.AutoSize = true;
            this.lblRawWidthValue.Location = new System.Drawing.Point(3, 0);
            this.lblRawWidthValue.Name = "lblRawWidthValue";
            this.lblRawWidthValue.Size = new System.Drawing.Size(13, 13);
            this.lblRawWidthValue.TabIndex = 6;
            this.lblRawWidthValue.Text = "0";
            // 
            // lblRawHeightValue
            // 
            this.lblRawHeightValue.AutoSize = true;
            this.lblRawHeightValue.Location = new System.Drawing.Point(22, 0);
            this.lblRawHeightValue.Name = "lblRawHeightValue";
            this.lblRawHeightValue.Size = new System.Drawing.Size(13, 13);
            this.lblRawHeightValue.TabIndex = 7;
            this.lblRawHeightValue.Text = "0";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblEffSizeWidth);
            this.flowLayoutPanel2.Controls.Add(this.lblEffSizeHeight);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(237, 20);
            this.flowLayoutPanel2.TabIndex = 11;
            // 
            // lblEffSizeWidth
            // 
            this.lblEffSizeWidth.AutoSize = true;
            this.lblEffSizeWidth.Location = new System.Drawing.Point(3, 0);
            this.lblEffSizeWidth.Name = "lblEffSizeWidth";
            this.lblEffSizeWidth.Size = new System.Drawing.Size(13, 13);
            this.lblEffSizeWidth.TabIndex = 11;
            this.lblEffSizeWidth.Text = "0";
            // 
            // lblEffSizeHeight
            // 
            this.lblEffSizeHeight.AutoSize = true;
            this.lblEffSizeHeight.Location = new System.Drawing.Point(22, 0);
            this.lblEffSizeHeight.Name = "lblEffSizeHeight";
            this.lblEffSizeHeight.Size = new System.Drawing.Size(13, 13);
            this.lblEffSizeHeight.TabIndex = 12;
            this.lblEffSizeHeight.Text = "0";
            // 
            // LayerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.gbRawSize);
            this.Controls.Add(this.gbEffSize);
            this.Controls.Add(this.lbLayers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayerManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layer Manager";
            ((System.ComponentModel.ISupportInitialize)(this.bsLayers)).EndInit();
            this.gbRawSize.ResumeLayout(false);
            this.gbEffSize.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLayers;
        private System.Windows.Forms.BindingSource bsLayers;
        private System.Windows.Forms.GroupBox gbRawSize;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblRawWidthValue;
        private System.Windows.Forms.Label lblRawHeightValue;
        private System.Windows.Forms.GroupBox gbEffSize;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblEffSizeWidth;
        private System.Windows.Forms.Label lblEffSizeHeight;
    }
}