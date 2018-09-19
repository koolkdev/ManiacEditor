namespace ManiacEditor
{
    partial class ObjectRemover
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.removeAttributeBtn = new System.Windows.Forms.Button();
            this.addAttributeBtn = new System.Windows.Forms.Button();
            this.attributesTable = new System.Windows.Forms.ListView();
            this.attName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.attType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupStageConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreStageConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimizeObjectIDPlacementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAttributeToAllObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchLabel = new System.Windows.Forms.Label();
            this.FilterText = new System.Windows.Forms.TextBox();
            this.lvObjects = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lvObjects);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.removeAttributeBtn);
            this.panel1.Controls.Add(this.addAttributeBtn);
            this.panel1.Controls.Add(this.attributesTable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 548);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 520);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Remove Selected Entities";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // removeAttributeBtn
            // 
            this.removeAttributeBtn.Location = new System.Drawing.Point(353, 520);
            this.removeAttributeBtn.Name = "removeAttributeBtn";
            this.removeAttributeBtn.Size = new System.Drawing.Size(103, 23);
            this.removeAttributeBtn.TabIndex = 15;
            this.removeAttributeBtn.Text = "Remove";
            this.removeAttributeBtn.UseVisualStyleBackColor = true;
            this.removeAttributeBtn.Click += new System.EventHandler(this.removeAttributeBtn_Click);
            // 
            // addAttributeBtn
            // 
            this.addAttributeBtn.Location = new System.Drawing.Point(206, 520);
            this.addAttributeBtn.Name = "addAttributeBtn";
            this.addAttributeBtn.Size = new System.Drawing.Size(103, 23);
            this.addAttributeBtn.TabIndex = 14;
            this.addAttributeBtn.Text = "Add";
            this.addAttributeBtn.UseVisualStyleBackColor = true;
            this.addAttributeBtn.Click += new System.EventHandler(this.addAttributeBtn_Click);
            // 
            // attributesTable
            // 
            this.attributesTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.attName,
            this.attType});
            this.attributesTable.FullRowSelect = true;
            this.attributesTable.Location = new System.Drawing.Point(206, 3);
            this.attributesTable.MultiSelect = false;
            this.attributesTable.Name = "attributesTable";
            this.attributesTable.Size = new System.Drawing.Size(250, 513);
            this.attributesTable.TabIndex = 13;
            this.attributesTable.UseCompatibleStateImageBehavior = false;
            this.attributesTable.View = System.Windows.Forms.View.Details;
            // 
            // attName
            // 
            this.attName.Text = "Name";
            this.attName.Width = 175;
            // 
            // attType
            // 
            this.attType.Text = "Type";
            this.attType.Width = 75;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(462, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 21);
            this.label1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(552, 607);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.objectsToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(637, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // objectsToolStripMenuItem
            // 
            this.objectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importObjectsToolStripMenuItem,
            this.backupStageConfigToolStripMenuItem,
            this.restoreStageConfigToolStripMenuItem});
            this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
            this.objectsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.objectsToolStripMenuItem.Text = "File";
            this.objectsToolStripMenuItem.Click += new System.EventHandler(this.objectsToolStripMenuItem_Click);
            // 
            // importObjectsToolStripMenuItem
            // 
            this.importObjectsToolStripMenuItem.Name = "importObjectsToolStripMenuItem";
            this.importObjectsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.importObjectsToolStripMenuItem.Text = "Import Objects";
            this.importObjectsToolStripMenuItem.Click += new System.EventHandler(this.importObjectsToolStripMenuItem_Click_1);
            // 
            // backupStageConfigToolStripMenuItem
            // 
            this.backupStageConfigToolStripMenuItem.Enabled = false;
            this.backupStageConfigToolStripMenuItem.Name = "backupStageConfigToolStripMenuItem";
            this.backupStageConfigToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.backupStageConfigToolStripMenuItem.Text = "Backup StageConfig";
            this.backupStageConfigToolStripMenuItem.Click += new System.EventHandler(this.backupStageConfigToolStripMenuItem_Click);
            // 
            // restoreStageConfigToolStripMenuItem
            // 
            this.restoreStageConfigToolStripMenuItem.Enabled = false;
            this.restoreStageConfigToolStripMenuItem.Name = "restoreStageConfigToolStripMenuItem";
            this.restoreStageConfigToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.restoreStageConfigToolStripMenuItem.Text = "Restore StageConfig";
            this.restoreStageConfigToolStripMenuItem.Click += new System.EventHandler(this.restoreStageConfigToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optimizeObjectIDPlacementToolStripMenuItem,
            this.addAttributeToAllObjectsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // optimizeObjectIDPlacementToolStripMenuItem
            // 
            this.optimizeObjectIDPlacementToolStripMenuItem.Enabled = false;
            this.optimizeObjectIDPlacementToolStripMenuItem.Name = "optimizeObjectIDPlacementToolStripMenuItem";
            this.optimizeObjectIDPlacementToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.optimizeObjectIDPlacementToolStripMenuItem.Text = "Optimize Object ID Placement";
            this.optimizeObjectIDPlacementToolStripMenuItem.Click += new System.EventHandler(this.optimizeObjectIDPlacementToolStripMenuItem_Click);
            // 
            // addAttributeToAllObjectsToolStripMenuItem
            // 
            this.addAttributeToAllObjectsToolStripMenuItem.Name = "addAttributeToAllObjectsToolStripMenuItem";
            this.addAttributeToAllObjectsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.addAttributeToAllObjectsToolStripMenuItem.Text = "Add Attribute to All Objects";
            this.addAttributeToAllObjectsToolStripMenuItem.Click += new System.EventHandler(this.addAttributeToAllObjectsToolStripMenuItem_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(9, 30);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(32, 13);
            this.searchLabel.TabIndex = 10;
            this.searchLabel.Text = "Filter:";
            // 
            // FilterText
            // 
            this.FilterText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterText.Location = new System.Drawing.Point(47, 27);
            this.FilterText.Name = "FilterText";
            this.FilterText.Size = new System.Drawing.Size(580, 20);
            this.FilterText.TabIndex = 9;
            this.FilterText.TextChanged += new System.EventHandler(this.filter_textchaged);
            // 
            // lvObjects
            // 
            this.lvObjects.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvObjects.CheckBoxes = true;
            this.lvObjects.Location = new System.Drawing.Point(3, 3);
            this.lvObjects.MultiSelect = false;
            this.lvObjects.Name = "lvObjects";
            this.lvObjects.Size = new System.Drawing.Size(197, 511);
            this.lvObjects.TabIndex = 19;
            this.lvObjects.UseCompatibleStateImageBehavior = false;
            this.lvObjects.View = System.Windows.Forms.View.List;
            // 
            // ObjectRemover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(637, 634);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.FilterText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObjectRemover";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Object Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ObjectRemover_FormClosed);
            this.Load += new System.EventHandler(this.ObjectRemover_Load);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem objectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupStageConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreStageConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optimizeObjectIDPlacementToolStripMenuItem;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox FilterText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView attributesTable;
        private System.Windows.Forms.ColumnHeader attName;
        private System.Windows.Forms.ColumnHeader attType;
        private System.Windows.Forms.ToolStripMenuItem addAttributeToAllObjectsToolStripMenuItem;
        private System.Windows.Forms.Button addAttributeBtn;
        private System.Windows.Forms.Button removeAttributeBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView lvObjects;
    }
}