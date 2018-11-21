namespace PalcoNet.Editar_Publicacion
{
    partial class EditPublication
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.PostButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.GradeBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CategoryBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EventDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SeatsGrid = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.AddressNroText = new System.Windows.Forms.TextBox();
            this.AddressText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NotNumbered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SeatsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(553, 255);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(82, 40);
            this.CancelButton.TabIndex = 33;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PostButton
            // 
            this.PostButton.Location = new System.Drawing.Point(465, 255);
            this.PostButton.Name = "PostButton";
            this.PostButton.Size = new System.Drawing.Size(82, 40);
            this.PostButton.TabIndex = 32;
            this.PostButton.Text = "Publicar";
            this.PostButton.UseVisualStyleBackColor = true;
            this.PostButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ubicaciones";
            // 
            // GradeBox
            // 
            this.GradeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GradeBox.FormattingEnabled = true;
            this.GradeBox.Location = new System.Drawing.Point(12, 272);
            this.GradeBox.Name = "GradeBox";
            this.GradeBox.Size = new System.Drawing.Size(121, 21);
            this.GradeBox.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Grado";
            // 
            // CategoryBox
            // 
            this.CategoryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Location = new System.Drawing.Point(12, 227);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(200, 21);
            this.CategoryBox.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Rubro";
            // 
            // EventDatePicker
            // 
            this.EventDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EventDatePicker.Location = new System.Drawing.Point(12, 187);
            this.EventDatePicker.Name = "EventDatePicker";
            this.EventDatePicker.Size = new System.Drawing.Size(200, 20);
            this.EventDatePicker.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(12, 29);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(248, 95);
            this.DescriptionBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Descripción";
            // 
            // SeatsGrid
            // 
            this.SeatsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SeatsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteButton,
            this.NotNumbered,
            this.Row,
            this.Seat,
            this.Price,
            this.SeatType});
            this.SeatsGrid.Location = new System.Drawing.Point(282, 27);
            this.SeatsGrid.Name = "SeatsGrid";
            this.SeatsGrid.Size = new System.Drawing.Size(449, 221);
            this.SeatsGrid.TabIndex = 34;
            this.SeatsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SeatsGrid_CellContentClick);
            this.SeatsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.SeatsGrid_CellEndEdit);
            this.SeatsGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.SeatsGrid_RowsAdded);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(377, 255);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(82, 40);
            this.SaveButton.TabIndex = 35;
            this.SaveButton.Text = "Guardar como borrador";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(746, 308);
            this.shapeContainer1.TabIndex = 36;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 273;
            this.lineShape1.X2 = 273;
            this.lineShape1.Y1 = 13;
            this.lineShape1.Y2 = 296;
            // 
            // AddressNroText
            // 
            this.AddressNroText.Location = new System.Drawing.Point(182, 144);
            this.AddressNroText.Name = "AddressNroText";
            this.AddressNroText.Size = new System.Drawing.Size(78, 20);
            this.AddressNroText.TabIndex = 43;
            // 
            // AddressText
            // 
            this.AddressText.Location = new System.Drawing.Point(12, 144);
            this.AddressText.Name = "AddressText";
            this.AddressText.Size = new System.Drawing.Size(163, 20);
            this.AddressText.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Altura";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Dirección";
            // 
            // DeleteButton
            // 
            this.DeleteButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeleteButton.HeaderText = "Borrar";
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteButton.Width = 60;
            // 
            // NotNumbered
            // 
            this.NotNumbered.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NotNumbered.FalseValue = "0";
            this.NotNumbered.HeaderText = "Sin Numerar";
            this.NotNumbered.IndeterminateValue = "0";
            this.NotNumbered.Name = "NotNumbered";
            this.NotNumbered.TrueValue = "1";
            this.NotNumbered.Width = 71;
            // 
            // Row
            // 
            this.Row.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Row.HeaderText = "Fila";
            this.Row.Name = "Row";
            this.Row.Width = 48;
            // 
            // Seat
            // 
            this.Seat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Seat.HeaderText = "Asiento";
            this.Seat.Name = "Seat";
            this.Seat.Width = 67;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Price.HeaderText = "Precio";
            this.Price.Name = "Price";
            this.Price.Width = 62;
            // 
            // SeatType
            // 
            this.SeatType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SeatType.HeaderText = "Tipo de Asiento";
            this.SeatType.Name = "SeatType";
            this.SeatType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeatType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SeatType.Width = 97;
            // 
            // EditPublication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 308);
            this.Controls.Add(this.AddressNroText);
            this.Controls.Add(this.AddressText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SeatsGrid);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PostButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GradeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CategoryBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EventDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "EditPublication";
            this.Text = "EditPublication";
            this.Load += new System.EventHandler(this.EditPublication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SeatsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button PostButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox GradeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CategoryBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker EventDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SeatsGrid;
        private System.Windows.Forms.Button SaveButton;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox AddressNroText;
        private System.Windows.Forms.TextBox AddressText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NotNumbered;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewComboBoxColumn SeatType;

    }
}