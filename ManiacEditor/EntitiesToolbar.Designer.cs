namespace ManiacEditor
{
    partial class EntitiesToolbar
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
            this.entitiesList = new System.Windows.Forms.ComboBox();
            this.entityProperties = new System.Windows.Forms.PropertyGrid();
            this.gbSpawn = new System.Windows.Forms.GroupBox();
            this.defaultFilter = new System.Windows.Forms.ComboBox();
            this.btnSpawn = new System.Windows.Forms.Button();
            this.cbSpawn = new System.Windows.Forms.ComboBox();
            this.gbEditor = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.otherFilterCheck = new System.Windows.Forms.CheckBox();
            this.bothFilterCheck = new System.Windows.Forms.CheckBox();
            this.encoreFilterCheck = new System.Windows.Forms.CheckBox();
            this.maniaFilterCheck = new System.Windows.Forms.CheckBox();
            this.gbSpawn.SuspendLayout();
            this.gbEditor.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // entitiesList
            // 
            this.entitiesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entitiesList.FormattingEnabled = true;
            this.entitiesList.Location = new System.Drawing.Point(7, 19);
            this.entitiesList.Name = "entitiesList";
            this.entitiesList.Size = new System.Drawing.Size(234, 21);
            this.entitiesList.TabIndex = 0;
            this.entitiesList.DropDown += new System.EventHandler(this.entitiesList_DropDown);
            this.entitiesList.SelectedIndexChanged += new System.EventHandler(this.entitiesList_SelectedIndexChanged);
            // 
            // entityProperties
            // 
            this.entityProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entityProperties.HelpVisible = false;
            this.entityProperties.LineColor = System.Drawing.SystemColors.ControlDark;
            this.entityProperties.Location = new System.Drawing.Point(7, 46);
            this.entityProperties.Name = "entityProperties";
            this.entityProperties.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.entityProperties.Size = new System.Drawing.Size(234, 291);
            this.entityProperties.TabIndex = 1;
            this.entityProperties.ToolbarVisible = false;
            this.entityProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.entityProperties_PropertyValueChanged);
            // 
            // gbSpawn
            // 
            this.gbSpawn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSpawn.Controls.Add(this.defaultFilter);
            this.gbSpawn.Controls.Add(this.btnSpawn);
            this.gbSpawn.Controls.Add(this.cbSpawn);
            this.gbSpawn.Location = new System.Drawing.Point(6, 6);
            this.gbSpawn.Name = "gbSpawn";
            this.gbSpawn.Size = new System.Drawing.Size(247, 49);
            this.gbSpawn.TabIndex = 2;
            this.gbSpawn.TabStop = false;
            this.gbSpawn.Text = "Entity Spawner";
            // 
            // defaultFilter
            // 
            this.defaultFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultFilter.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ManiacEditor.Properties.Settings.Default, "DefaultFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.defaultFilter.DisplayMember = "Name";
            this.defaultFilter.FormattingEnabled = true;
            this.defaultFilter.Location = new System.Drawing.Point(168, 20);
            this.defaultFilter.MaxDropDownItems = 3;
            this.defaultFilter.Name = "defaultFilter";
            this.defaultFilter.Size = new System.Drawing.Size(73, 21);
            this.defaultFilter.TabIndex = 2;
            this.defaultFilter.Text = global::ManiacEditor.Properties.Settings.Default.DefaultFilter;
            // 
            // btnSpawn
            // 
            this.btnSpawn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpawn.Location = new System.Drawing.Point(112, 19);
            this.btnSpawn.Name = "btnSpawn";
            this.btnSpawn.Size = new System.Drawing.Size(50, 23);
            this.btnSpawn.TabIndex = 1;
            this.btnSpawn.Text = "Spawn";
            this.btnSpawn.UseVisualStyleBackColor = true;
            this.btnSpawn.Click += new System.EventHandler(this.btnSpawn_Click);
            // 
            // cbSpawn
            // 
            this.cbSpawn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSpawn.DisplayMember = "Name";
            this.cbSpawn.FormattingEnabled = true;
            this.cbSpawn.Location = new System.Drawing.Point(7, 20);
            this.cbSpawn.Name = "cbSpawn";
            this.cbSpawn.Size = new System.Drawing.Size(99, 21);
            this.cbSpawn.TabIndex = 0;
            // 
            // gbEditor
            // 
            this.gbEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEditor.Controls.Add(this.entitiesList);
            this.gbEditor.Controls.Add(this.entityProperties);
            this.gbEditor.Location = new System.Drawing.Point(6, 61);
            this.gbEditor.Name = "gbEditor";
            this.gbEditor.Size = new System.Drawing.Size(247, 343);
            this.gbEditor.TabIndex = 3;
            this.gbEditor.TabStop = false;
            this.gbEditor.Text = "Entity Editor";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.otherFilterCheck);
            this.groupBox1.Controls.Add(this.bothFilterCheck);
            this.groupBox1.Controls.Add(this.encoreFilterCheck);
            this.groupBox1.Controls.Add(this.maniaFilterCheck);
            this.groupBox1.Location = new System.Drawing.Point(6, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(247, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Entity View";
            // 
            // otherFilterCheck
            // 
            this.otherFilterCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.otherFilterCheck.Checked = global::ManiacEditor.Properties.Settings.Default.showOtherEntities;
            this.otherFilterCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.otherFilterCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "showOtherEntities", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.otherFilterCheck.Location = new System.Drawing.Point(131, 45);
            this.otherFilterCheck.Margin = new System.Windows.Forms.Padding(5);
            this.otherFilterCheck.Name = "otherFilterCheck";
            this.otherFilterCheck.Size = new System.Drawing.Size(108, 18);
            this.otherFilterCheck.TabIndex = 33;
            this.otherFilterCheck.Text = "Others";
            this.otherFilterCheck.UseVisualStyleBackColor = true;
            this.otherFilterCheck.CheckedChanged += new System.EventHandler(this.otherFilterCheck_CheckedChanged);
            // 
            // bothFilterCheck
            // 
            this.bothFilterCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bothFilterCheck.Checked = global::ManiacEditor.Properties.Settings.Default.showBothEntities;
            this.bothFilterCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bothFilterCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "showBothEntities", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.bothFilterCheck.Location = new System.Drawing.Point(8, 45);
            this.bothFilterCheck.Margin = new System.Windows.Forms.Padding(5);
            this.bothFilterCheck.Name = "bothFilterCheck";
            this.bothFilterCheck.Size = new System.Drawing.Size(108, 18);
            this.bothFilterCheck.TabIndex = 32;
            this.bothFilterCheck.Text = "Both (1 or 5)";
            this.bothFilterCheck.UseVisualStyleBackColor = true;
            this.bothFilterCheck.CheckedChanged += new System.EventHandler(this.bothFilterCheck_CheckedChanged);
            // 
            // encoreFilterCheck
            // 
            this.encoreFilterCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.encoreFilterCheck.Checked = global::ManiacEditor.Properties.Settings.Default.showEncoreEntities;
            this.encoreFilterCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.encoreFilterCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "showEncoreEntities", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.encoreFilterCheck.Location = new System.Drawing.Point(131, 21);
            this.encoreFilterCheck.Margin = new System.Windows.Forms.Padding(5);
            this.encoreFilterCheck.Name = "encoreFilterCheck";
            this.encoreFilterCheck.Size = new System.Drawing.Size(108, 18);
            this.encoreFilterCheck.TabIndex = 31;
            this.encoreFilterCheck.Text = "Encore (4)";
            this.encoreFilterCheck.UseVisualStyleBackColor = true;
            this.encoreFilterCheck.CheckedChanged += new System.EventHandler(this.encoreFilterCheck_CheckedChanged);
            // 
            // maniaFilterCheck
            // 
            this.maniaFilterCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maniaFilterCheck.Checked = global::ManiacEditor.Properties.Settings.Default.showManiaEntities;
            this.maniaFilterCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.maniaFilterCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ManiacEditor.Properties.Settings.Default, "showManiaEntities", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maniaFilterCheck.Location = new System.Drawing.Point(8, 21);
            this.maniaFilterCheck.Margin = new System.Windows.Forms.Padding(5);
            this.maniaFilterCheck.Name = "maniaFilterCheck";
            this.maniaFilterCheck.Size = new System.Drawing.Size(108, 18);
            this.maniaFilterCheck.TabIndex = 30;
            this.maniaFilterCheck.Text = "Mania (2)";
            this.maniaFilterCheck.UseVisualStyleBackColor = true;
            this.maniaFilterCheck.CheckedChanged += new System.EventHandler(this.maniaFilterCheck_CheckedChanged);
            // 
            // EntitiesToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbEditor);
            this.Controls.Add(this.gbSpawn);
            this.Name = "EntitiesToolbar";
            this.Size = new System.Drawing.Size(256, 487);
            this.gbSpawn.ResumeLayout(false);
            this.gbEditor.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox entitiesList;
        private System.Windows.Forms.PropertyGrid entityProperties;
        private System.Windows.Forms.GroupBox gbSpawn;
        private System.Windows.Forms.Button btnSpawn;
        private System.Windows.Forms.ComboBox cbSpawn;
        private System.Windows.Forms.GroupBox gbEditor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox otherFilterCheck;
        private System.Windows.Forms.CheckBox bothFilterCheck;
        private System.Windows.Forms.CheckBox encoreFilterCheck;
        private System.Windows.Forms.CheckBox maniaFilterCheck;
        private System.Windows.Forms.ComboBox defaultFilter;
    }
}
