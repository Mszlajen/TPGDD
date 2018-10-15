namespace PalcoNet.Listado_Estadistico
{
    partial class StatList
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
            this.YearBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TrimesterBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ListBox = new System.Windows.Forms.ComboBox();
            this.ListButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // YearBox
            // 
            this.YearBox.FormattingEnabled = true;
            this.YearBox.Location = new System.Drawing.Point(12, 37);
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(85, 21);
            this.YearBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trimestre";
            // 
            // TrimesterBox
            // 
            this.TrimesterBox.Enabled = false;
            this.TrimesterBox.FormattingEnabled = true;
            this.TrimesterBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.TrimesterBox.Location = new System.Drawing.Point(133, 36);
            this.TrimesterBox.Name = "TrimesterBox";
            this.TrimesterBox.Size = new System.Drawing.Size(47, 21);
            this.TrimesterBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Listado";
            // 
            // ListBox
            // 
            this.ListBox.Enabled = false;
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Items.AddRange(new object[] {
            "Empresas por localidades no vendidas",
            "Clientes por puntos vencidos",
            "Clientes por cantidad de compras"});
            this.ListBox.Location = new System.Drawing.Point(12, 82);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(260, 21);
            this.ListBox.TabIndex = 5;
            // 
            // ListButton
            // 
            this.ListButton.Enabled = false;
            this.ListButton.Location = new System.Drawing.Point(317, 63);
            this.ListButton.Name = "ListButton";
            this.ListButton.Size = new System.Drawing.Size(115, 48);
            this.ListButton.TabIndex = 6;
            this.ListButton.Text = "Listar";
            this.ListButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(317, 9);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(115, 48);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Limpiar";
            this.ClearButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(447, 125);
            this.dataGridView1.TabIndex = 7;
            // 
            // StatList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 264);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ListButton);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TrimesterBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YearBox);
            this.Name = "StatList";
            this.Text = "Seleccionar listado";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox YearBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TrimesterBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ListBox;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}