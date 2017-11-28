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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRawWidthValue = new System.Windows.Forms.Label();
            this.lblRawHeightValue = new System.Windows.Forms.Label();
            this.gbEffSize = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEffSizeWidth = new System.Windows.Forms.Label();
            this.lblEffSizeHeight = new System.Windows.Forms.Label();
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
            this.rtbWarn = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsLayers)).BeginInit();
            this.gbRawSize.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbEffSize.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.gbResize.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLayers
            // 
            this.lbLayers.DataSource = this.bsLayers;
            this.lbLayers.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbLayers.FormattingEnabled = true;
            this.lbLayers.Location = new System.Drawing.Point(0, 0);
            this.lbLayers.Name = "lbLayers";
            this.lbLayers.Size = new System.Drawing.Size(120, 337);
            this.lbLayers.TabIndex = 0;
            // 
            // gbRawSize
            // 
            this.gbRawSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRawSize.Controls.Add(this.flowLayoutPanel1);
            this.gbRawSize.Location = new System.Drawing.Point(129, 76);
            this.gbRawSize.Name = "gbRawSize";
            this.gbRawSize.Size = new System.Drawing.Size(243, 39);
            this.gbRawSize.TabIndex = 11;
            this.gbRawSize.TabStop = false;
            this.gbRawSize.Text = "Raw Size";
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
            // gbEffSize
            // 
            this.gbEffSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEffSize.Controls.Add(this.flowLayoutPanel2);
            this.gbEffSize.Location = new System.Drawing.Point(129, 121);
            this.gbEffSize.Name = "gbEffSize";
            this.gbEffSize.Size = new System.Drawing.Size(243, 39);
            this.gbEffSize.TabIndex = 12;
            this.gbEffSize.TabStop = false;
            this.gbEffSize.Text = "Effective Size";
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
            // gbResize
            // 
            this.gbResize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResize.Controls.Add(this.lblResizeWarnInstruct);
            this.gbResize.Controls.Add(this.panel1);
            this.gbResize.Controls.Add(this.panel2);
            this.gbResize.Controls.Add(this.lblResizedEffective);
            this.gbResize.Controls.Add(this.btnResize);
            this.gbResize.Location = new System.Drawing.Point(129, 166);
            this.gbResize.Name = "gbResize";
            this.gbResize.Size = new System.Drawing.Size(243, 159);
            this.gbResize.TabIndex = 1;
            this.gbResize.TabStop = false;
            this.gbResize.Text = "Resize";
            // 
            // lblResizeWarnInstruct
            // 
            this.lblResizeWarnInstruct.Location = new System.Drawing.Point(6, 84);
            this.lblResizeWarnInstruct.Name = "lblResizeWarnInstruct";
            this.lblResizeWarnInstruct.Size = new System.Drawing.Size(231, 43);
            this.lblResizeWarnInstruct.TabIndex = 15;
            this.lblResizeWarnInstruct.Text = "It is recommended to keep any Forground layers (normally named FG Low and FG High" +
    ") the same size.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nudWidth);
            this.panel1.Controls.Add(this.lblWidth);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 28);
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
            this.nudWidth.Size = new System.Drawing.Size(64, 20);
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
            this.panel2.Location = new System.Drawing.Point(123, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(114, 27);
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
            this.nudHeight.Size = new System.Drawing.Size(67, 20);
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
            this.btnResize.Location = new System.Drawing.Point(3, 133);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(237, 23);
            this.btnResize.TabIndex = 3;
            this.btnResize.Text = "Resize This Layer";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // rtbWarn
            // 
            this.rtbWarn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbWarn.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbWarn.Location = new System.Drawing.Point(120, 0);
            this.rtbWarn.Name = "rtbWarn";
            this.rtbWarn.ReadOnly = true;
            this.rtbWarn.Size = new System.Drawing.Size(264, 70);
            this.rtbWarn.TabIndex = 13;
            this.rtbWarn.Text = "The feature is highly experimental! Any changes made will be reflected when this " +
    "window is closed. Don\'t forget to save after! You did take that backup, didn\'t y" +
    "ou?";
            // 
            // LayerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 337);
            this.Controls.Add(this.rtbWarn);
            this.Controls.Add(this.gbResize);
            this.Controls.Add(this.gbRawSize);
            this.Controls.Add(this.gbEffSize);
            this.Controls.Add(this.lbLayers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 375);
            this.Name = "LayerManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layer Manager";
            ((System.ComponentModel.ISupportInitialize)(this.bsLayers)).EndInit();
            this.gbRawSize.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.gbEffSize.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.gbResize.ResumeLayout(false);
            this.gbResize.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
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
        private System.Windows.Forms.RichTextBox rtbWarn;
    }
}