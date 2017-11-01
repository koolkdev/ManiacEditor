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
            this.btnSpawn = new System.Windows.Forms.Button();
            this.cbSpawn = new System.Windows.Forms.ComboBox();
            this.gbEditor = new System.Windows.Forms.GroupBox();
            this.gbSpawn.SuspendLayout();
            this.gbEditor.SuspendLayout();
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
            this.entityProperties.Size = new System.Drawing.Size(234, 374);
            this.entityProperties.TabIndex = 1;
            this.entityProperties.ToolbarVisible = false;
            this.entityProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.entityProperties_PropertyValueChanged);
            // 
            // gbSpawn
            // 
            this.gbSpawn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSpawn.Controls.Add(this.btnSpawn);
            this.gbSpawn.Controls.Add(this.cbSpawn);
            this.gbSpawn.Location = new System.Drawing.Point(6, 3);
            this.gbSpawn.Name = "gbSpawn";
            this.gbSpawn.Size = new System.Drawing.Size(247, 49);
            this.gbSpawn.TabIndex = 2;
            this.gbSpawn.TabStop = false;
            this.gbSpawn.Text = "Entity Spawner";
            // 
            // btnSpawn
            // 
            this.btnSpawn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpawn.Location = new System.Drawing.Point(191, 20);
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
            this.cbSpawn.Size = new System.Drawing.Size(177, 21);
            this.cbSpawn.TabIndex = 0;
            // 
            // gbEditor
            // 
            this.gbEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEditor.Controls.Add(this.entitiesList);
            this.gbEditor.Controls.Add(this.entityProperties);
            this.gbEditor.Location = new System.Drawing.Point(6, 58);
            this.gbEditor.Name = "gbEditor";
            this.gbEditor.Size = new System.Drawing.Size(247, 426);
            this.gbEditor.TabIndex = 3;
            this.gbEditor.TabStop = false;
            this.gbEditor.Text = "Entity Editor";
            // 
            // EntitiesToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbEditor);
            this.Controls.Add(this.gbSpawn);
            this.Name = "EntitiesToolbar";
            this.Size = new System.Drawing.Size(256, 487);
            this.gbSpawn.ResumeLayout(false);
            this.gbEditor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox entitiesList;
        private System.Windows.Forms.PropertyGrid entityProperties;
        private System.Windows.Forms.GroupBox gbSpawn;
        private System.Windows.Forms.Button btnSpawn;
        private System.Windows.Forms.ComboBox cbSpawn;
        private System.Windows.Forms.GroupBox gbEditor;
    }
}
