namespace PalcoNet.Editar_Usuario
{
    partial class list
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
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.UsersGrid = new System.Windows.Forms.DataGridView();
            this.AvabilityCheck = new System.Windows.Forms.CheckBox();
            this.ChangePassword = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario";
            // 
            // UsernameText
            // 
            this.UsernameText.Location = new System.Drawing.Point(16, 30);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(146, 20);
            this.UsernameText.TabIndex = 1;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(270, 11);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Buscar";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(270, 40);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Limpiar";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // UsersGrid
            // 
            this.UsersGrid.AllowUserToAddRows = false;
            this.UsersGrid.AllowUserToDeleteRows = false;
            this.UsersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChangePassword});
            this.UsersGrid.Location = new System.Drawing.Point(16, 69);
            this.UsersGrid.Name = "UsersGrid";
            this.UsersGrid.ReadOnly = true;
            this.UsersGrid.Size = new System.Drawing.Size(488, 150);
            this.UsersGrid.TabIndex = 4;
            this.UsersGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersGrid_CellContentClick);
            // 
            // AvabilityCheck
            // 
            this.AvabilityCheck.AutoSize = true;
            this.AvabilityCheck.Checked = true;
            this.AvabilityCheck.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.AvabilityCheck.Location = new System.Drawing.Point(168, 35);
            this.AvabilityCheck.Name = "AvabilityCheck";
            this.AvabilityCheck.Size = new System.Drawing.Size(73, 17);
            this.AvabilityCheck.TabIndex = 5;
            this.AvabilityCheck.Text = "Habilitado";
            this.AvabilityCheck.ThreeState = true;
            this.AvabilityCheck.UseVisualStyleBackColor = true;
            // 
            // ChangePassword
            // 
            this.ChangePassword.HeaderText = "Cambiar Contraseña";
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.ReadOnly = true;
            // 
            // list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 232);
            this.Controls.Add(this.AvabilityCheck);
            this.Controls.Add(this.UsersGrid);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.UsernameText);
            this.Controls.Add(this.label1);
            this.Name = "list";
            this.Text = "list";
            this.Load += new System.EventHandler(this.list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataGridView UsersGrid;
        private System.Windows.Forms.CheckBox AvabilityCheck;
        private System.Windows.Forms.DataGridViewButtonColumn ChangePassword;
    }
}