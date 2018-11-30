namespace PalcoNet.Comprar
{
    partial class Buy
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
            this.SeatsGrid = new System.Windows.Forms.DataGridView();
            this.Comprar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.BuyButton = new System.Windows.Forms.Button();
            this.SelectedOnlyCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SeatsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ubicaciones disponibles";
            // 
            // SeatsGrid
            // 
            this.SeatsGrid.AllowUserToAddRows = false;
            this.SeatsGrid.AllowUserToDeleteRows = false;
            this.SeatsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SeatsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Comprar});
            this.SeatsGrid.Location = new System.Drawing.Point(16, 71);
            this.SeatsGrid.Name = "SeatsGrid";
            this.SeatsGrid.Size = new System.Drawing.Size(666, 191);
            this.SeatsGrid.TabIndex = 1;
            this.SeatsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SeatsGrid_CellContentClick);
            // 
            // Comprar
            // 
            this.Comprar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Comprar.HeaderText = "Comprar";
            this.Comprar.Name = "Comprar";
            this.Comprar.Width = 52;
            // 
            // TypeBox
            // 
            this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Location = new System.Drawing.Point(16, 31);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(121, 21);
            this.TypeBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(518, 29);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(79, 23);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Limpiar";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(603, 29);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(79, 23);
            this.SearchButton.TabIndex = 9;
            this.SearchButton.Text = "Buscar";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // BuyButton
            // 
            this.BuyButton.Location = new System.Drawing.Point(603, 269);
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Size = new System.Drawing.Size(79, 41);
            this.BuyButton.TabIndex = 10;
            this.BuyButton.Text = "Comprar";
            this.BuyButton.UseVisualStyleBackColor = true;
            this.BuyButton.Click += new System.EventHandler(this.BuyButton_Click);
            // 
            // SelectedOnlyCheck
            // 
            this.SelectedOnlyCheck.AutoSize = true;
            this.SelectedOnlyCheck.Location = new System.Drawing.Point(19, 282);
            this.SelectedOnlyCheck.Name = "SelectedOnlyCheck";
            this.SelectedOnlyCheck.Size = new System.Drawing.Size(157, 17);
            this.SelectedOnlyCheck.TabIndex = 11;
            this.SelectedOnlyCheck.Text = "Ver entradas seleccionadas";
            this.SelectedOnlyCheck.UseVisualStyleBackColor = true;
            this.SelectedOnlyCheck.CheckedChanged += new System.EventHandler(this.SelectedOnlyCheck_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "El precio se encuentra detallado en pesos argentinos";
            // 
            // Buy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 321);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SelectedOnlyCheck);
            this.Controls.Add(this.BuyButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.SeatsGrid);
            this.Controls.Add(this.label1);
            this.Name = "Buy";
            this.Text = "Buy";
            this.Load += new System.EventHandler(this.Buy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SeatsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SeatsGrid;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button BuyButton;
        private System.Windows.Forms.CheckBox SelectedOnlyCheck;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Comprar;
        private System.Windows.Forms.Label label3;
    }
}