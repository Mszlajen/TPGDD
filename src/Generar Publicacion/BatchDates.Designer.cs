namespace PalcoNet.Generar_Publicacion
{
    partial class BatchDates
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
            this.AddDateButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.DatesGrid = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DatesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AddDateButton
            // 
            this.AddDateButton.Location = new System.Drawing.Point(230, 162);
            this.AddDateButton.Name = "AddDateButton";
            this.AddDateButton.Size = new System.Drawing.Size(75, 23);
            this.AddDateButton.TabIndex = 17;
            this.AddDateButton.Text = "Agregar";
            this.AddDateButton.UseVisualStyleBackColor = true;
            this.AddDateButton.Click += new System.EventHandler(this.AddDateButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Fechas";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(157, 209);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(82, 40);
            this.CancelButton.TabIndex = 20;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(69, 209);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(82, 40);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Guardar";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DatePicker
            // 
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePicker.Location = new System.Drawing.Point(15, 164);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(200, 20);
            this.DatePicker.TabIndex = 23;
            // 
            // DatesGrid
            // 
            this.DatesGrid.AllowUserToAddRows = false;
            this.DatesGrid.AllowUserToDeleteRows = false;
            this.DatesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteButton});
            this.DatesGrid.Location = new System.Drawing.Point(15, 21);
            this.DatesGrid.Name = "DatesGrid";
            this.DatesGrid.ReadOnly = true;
            this.DatesGrid.Size = new System.Drawing.Size(290, 135);
            this.DatesGrid.TabIndex = 22;
            this.DatesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatesGrid_CellContentClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.HeaderText = "Quitar";
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.ReadOnly = true;
            // 
            // BatchDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 261);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.DatesGrid);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AddDateButton);
            this.Controls.Add(this.label5);
            this.Name = "BatchDates";
            this.Text = "BatchDates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatchDates_FormClosing);
            this.Load += new System.EventHandler(this.BatchDates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddDateButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.DataGridView DatesGrid;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
    }
}