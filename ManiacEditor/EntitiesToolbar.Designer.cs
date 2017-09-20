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
            this.SuspendLayout();
            // 
            // entitiesList
            // 
            this.entitiesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entitiesList.FormattingEnabled = true;
            this.entitiesList.Location = new System.Drawing.Point(6, 3);
            this.entitiesList.Name = "entitiesList";
            this.entitiesList.Size = new System.Drawing.Size(247, 21);
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
            this.entityProperties.Location = new System.Drawing.Point(6, 30);
            this.entityProperties.Name = "entityProperties";
            this.entityProperties.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.entityProperties.Size = new System.Drawing.Size(247, 454);
            this.entityProperties.TabIndex = 1;
            this.entityProperties.ToolbarVisible = false;
            this.entityProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.entityProperties_PropertyValueChanged);
            // 
            // EntitiesToolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.entityProperties);
            this.Controls.Add(this.entitiesList);
            this.Name = "EntitiesToolbar";
            this.Size = new System.Drawing.Size(256, 487);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox entitiesList;
        private System.Windows.Forms.PropertyGrid entityProperties;
    }
}
