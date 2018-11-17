namespace PalcoNet.Abm_Grado
{
    partial class ABMGrado
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
            this.CreateButton = new System.Windows.Forms.Button();
            this.SelectionGrid = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SelectionGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(12, 191);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(78, 23);
            this.CreateButton.TabIndex = 5;
            this.CreateButton.Text = "Crear Rol";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // SelectionGrid
            // 
            this.SelectionGrid.AllowUserToAddRows = false;
            this.SelectionGrid.AllowUserToDeleteRows = false;
            this.SelectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectionGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});
            this.SelectionGrid.Location = new System.Drawing.Point(12, 26);
            this.SelectionGrid.Name = "SelectionGrid";
            this.SelectionGrid.ReadOnly = true;
            this.SelectionGrid.Size = new System.Drawing.Size(410, 150);
            this.SelectionGrid.TabIndex = 4;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Roles disponibles";
            // 
            // ABMGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 231);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.SelectionGrid);
            this.Controls.Add(this.label1);
            this.Name = "ABMGrado";
            this.Text = "ABM de Grado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ABMGrado_FormClosing);
            this.Load += new System.EventHandler(this.ABMGrado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SelectionGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.DataGridView SelectionGrid;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.Label label1;

    }
}