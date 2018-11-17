namespace PalcoNet.Abm_Cliente
{
    partial class SelectClient
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
            this.label2 = new System.Windows.Forms.Label();
            this.SurnameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DocumentNumberBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MailBox = new System.Windows.Forms.TextBox();
            this.ClientsGrid = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CleanButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DocumentTypeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(12, 30);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(156, 20);
            this.NameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido";
            // 
            // SurnameBox
            // 
            this.SurnameBox.Location = new System.Drawing.Point(197, 30);
            this.SurnameBox.Name = "SurnameBox";
            this.SurnameBox.Size = new System.Drawing.Size(174, 20);
            this.SurnameBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nro Documento";
            // 
            // DocumentNumberBox
            // 
            this.DocumentNumberBox.Enabled = false;
            this.DocumentNumberBox.Location = new System.Drawing.Point(103, 81);
            this.DocumentNumberBox.Name = "DocumentNumberBox";
            this.DocumentNumberBox.Size = new System.Drawing.Size(100, 20);
            this.DocumentNumberBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "E-Mail";
            // 
            // MailBox
            // 
            this.MailBox.Location = new System.Drawing.Point(225, 81);
            this.MailBox.Name = "MailBox";
            this.MailBox.Size = new System.Drawing.Size(301, 20);
            this.MailBox.TabIndex = 6;
            // 
            // ClientsGrid
            // 
            this.ClientsGrid.AllowUserToAddRows = false;
            this.ClientsGrid.AllowUserToDeleteRows = false;
            this.ClientsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});
            this.ClientsGrid.Location = new System.Drawing.Point(15, 119);
            this.ClientsGrid.Name = "ClientsGrid";
            this.ClientsGrid.ReadOnly = true;
            this.ClientsGrid.Size = new System.Drawing.Size(626, 181);
            this.ClientsGrid.TabIndex = 8;
            this.ClientsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientsGrid_CellContentClick);
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Editar.HeaderText = "Editar";
            this.Editar.Name = "Editar";
            this.Editar.Width = 40;
            // 
            // CleanButton
            // 
            this.CleanButton.Location = new System.Drawing.Point(554, 11);
            this.CleanButton.Name = "CleanButton";
            this.CleanButton.Size = new System.Drawing.Size(87, 45);
            this.CleanButton.TabIndex = 9;
            this.CleanButton.Text = "Limpiar";
            this.CleanButton.UseVisualStyleBackColor = true;
            this.CleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(554, 68);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(87, 45);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "Buscar";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DocumentTypeBox
            // 
            this.DocumentTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DocumentTypeBox.FormattingEnabled = true;
            this.DocumentTypeBox.Items.AddRange(new object[] {
            "DNI"});
            this.DocumentTypeBox.Location = new System.Drawing.Point(12, 81);
            this.DocumentTypeBox.Name = "DocumentTypeBox";
            this.DocumentTypeBox.Size = new System.Drawing.Size(85, 21);
            this.DocumentTypeBox.TabIndex = 11;
            this.DocumentTypeBox.SelectedIndexChanged += new System.EventHandler(this.DocumentTypeBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tipo Documento";
            // 
            // SelectClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 312);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DocumentTypeBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.CleanButton);
            this.Controls.Add(this.ClientsGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MailBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DocumentNumberBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SurnameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameBox);
            this.Name = "SelectClient";
            this.Text = "Seleccionar Cliente";
            this.Load += new System.EventHandler(this.SelectClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SurnameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DocumentNumberBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MailBox;
        private System.Windows.Forms.DataGridView ClientsGrid;
        private System.Windows.Forms.Button CleanButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.ComboBox DocumentTypeBox;
        private System.Windows.Forms.Label label5;
    }
}