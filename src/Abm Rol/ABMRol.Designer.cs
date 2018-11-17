namespace PalcoNet.Abm_Rol
{
    partial class ABMRol
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
            this.label1 = new System.Windows.Forms.Label();
            this.SelectionGrid = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CreateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Roles disponibles";
            // 
            // SelectionGrid
            // 
            this.SelectionGrid.AllowUserToAddRows = false;
            this.SelectionGrid.AllowUserToDeleteRows = false;
            this.SelectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectionGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});
            this.SelectionGrid.Location = new System.Drawing.Point(16, 30);
            this.SelectionGrid.Name = "SelectionGrid";
            this.SelectionGrid.ReadOnly = true;
            this.SelectionGrid.Size = new System.Drawing.Size(410, 150);
            this.SelectionGrid.TabIndex = 1;
            this.SelectionGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectionGrid_CellContentClick);
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Editar.Width = 59;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(16, 195);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(78, 23);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "Crear Rol";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // RoleSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 240);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.SelectionGrid);
            this.Controls.Add(this.label1);
            this.Name = "RoleSelection";
            this.Text = "ABM de Grado";
            this.Load += new System.EventHandler(this.RoleSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SelectionGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SelectionGrid;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.Button CreateButton;
    }
}