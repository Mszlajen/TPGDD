namespace PalcoNet.Generar_Rendicion_Comisiones
{
    partial class SelectCompany
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
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CUITBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MailBox = new System.Windows.Forms.TextBox();
            this.CompanyGrid = new System.Windows.Forms.DataGridView();
            this.MakeButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CleanButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(12, 30);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(359, 20);
            this.NameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Razon social";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CUIT";
            // 
            // CUITBox
            // 
            this.CUITBox.Location = new System.Drawing.Point(12, 81);
            this.CUITBox.Name = "CUITBox";
            this.CUITBox.Size = new System.Drawing.Size(100, 20);
            this.CUITBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "E-Mail";
            // 
            // MailBox
            // 
            this.MailBox.Location = new System.Drawing.Point(137, 81);
            this.MailBox.Name = "MailBox";
            this.MailBox.Size = new System.Drawing.Size(234, 20);
            this.MailBox.TabIndex = 6;
            // 
            // CompanyGrid
            // 
            this.CompanyGrid.AllowUserToAddRows = false;
            this.CompanyGrid.AllowUserToDeleteRows = false;
            this.CompanyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompanyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MakeButton});
            this.CompanyGrid.Location = new System.Drawing.Point(15, 119);
            this.CompanyGrid.Name = "CompanyGrid";
            this.CompanyGrid.ReadOnly = true;
            this.CompanyGrid.Size = new System.Drawing.Size(500, 165);
            this.CompanyGrid.TabIndex = 8;
            this.CompanyGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CompanyGrid_CellContentClick);
            // 
            // MakeButton
            // 
            this.MakeButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MakeButton.HeaderText = "Rendir";
            this.MakeButton.Name = "MakeButton";
            this.MakeButton.ReadOnly = true;
            this.MakeButton.Width = 44;
            // 
            // CleanButton
            // 
            this.CleanButton.Location = new System.Drawing.Point(406, 17);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(87, 45);
            this.CleanButton.TabIndex = 9;
            this.CleanButton.Text = "Limpiar";
            this.CleanButton.UseVisualStyleBackColor = true;
            this.CleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(406, 68);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(87, 45);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "Buscar";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SelectCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 312);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.CompanyGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MailBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CUITBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameBox);
            this.Name = "SelectCompany";
            this.Text = "Seleccionar Empresa";
            this.Load += new System.EventHandler(this.SelectCompany_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CUITBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MailBox;
        private System.Windows.Forms.DataGridView CompanyGrid;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridViewButtonColumn MakeButton;
    }
}