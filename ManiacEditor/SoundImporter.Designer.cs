namespace ManiacEditor
{
    partial class SoundImporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundImporter));
            this.rtbWarning = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvObjects = new System.Windows.Forms.ListView();
            this.btnImport = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbWarning
            // 
            this.rtbWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.rtbWarning, 2);
            this.rtbWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbWarning.Location = new System.Drawing.Point(3, 3);
            this.rtbWarning.Name = "rtbWarning";
            this.rtbWarning.ReadOnly = true;
            this.rtbWarning.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbWarning.Size = new System.Drawing.Size(378, 91);
            this.rtbWarning.TabIndex = 5;
            this.rtbWarning.TabStop = false;
            this.rtbWarning.Text = resources.GetString("rtbWarning.Text");
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(306, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvObjects
            // 
            this.lvObjects.CheckBoxes = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lvObjects, 2);
            this.lvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvObjects.Location = new System.Drawing.Point(3, 100);
            this.lvObjects.Name = "lvObjects";
            this.lvObjects.Size = new System.Drawing.Size(378, 230);
            this.lvObjects.TabIndex = 2;
            this.lvObjects.UseCompatibleStateImageBehavior = false;
            this.lvObjects.View = System.Windows.Forms.View.List;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.Location = new System.Drawing.Point(3, 336);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rtbWarning, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lvObjects, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 362);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // SoundImporter
            // 
            this.AcceptButton = this.btnImport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoundImporter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pick Sounds to Import";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbWarning;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvObjects;
        private System.Windows.Forms.Button btnImport;
    }
}