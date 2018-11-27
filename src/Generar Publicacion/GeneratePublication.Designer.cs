namespace PalcoNet.Generar_Publicacion
{
    partial class GeneratePublication
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
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EventDatePicker = new System.Windows.Forms.DateTimePicker();
            this.BatchDatesCheck = new System.Windows.Forms.CheckBox();
            this.BatchDatesButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CategoryBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GradeBox = new System.Windows.Forms.ComboBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label5 = new System.Windows.Forms.Label();
            this.SketchButton = new System.Windows.Forms.Button();
            this.PostButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SeatsGrid = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NotNumbered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AddressText = new System.Windows.Forms.TextBox();
            this.AddressNroText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SeatsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción(*)";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(16, 30);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(248, 91);
            this.DescriptionBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha(*)";
            // 
            // EventDatePicker
            // 
            this.EventDatePicker.CustomFormat = "";
            this.EventDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EventDatePicker.Location = new System.Drawing.Point(16, 188);
            this.EventDatePicker.Name = "EventDatePicker";
            this.EventDatePicker.Size = new System.Drawing.Size(200, 20);
            this.EventDatePicker.TabIndex = 3;
            // 
            // BatchDatesCheck
            // 
            this.BatchDatesCheck.AutoSize = true;
            this.BatchDatesCheck.Location = new System.Drawing.Point(65, 167);
            this.BatchDatesCheck.Name = "BatchDatesCheck";
            this.BatchDatesCheck.Size = new System.Drawing.Size(119, 17);
            this.BatchDatesCheck.TabIndex = 4;
            this.BatchDatesCheck.Text = "Publicación por lote";
            this.BatchDatesCheck.UseVisualStyleBackColor = true;
            this.BatchDatesCheck.CheckedChanged += new System.EventHandler(this.BatchDatesCheck_CheckedChanged);
            // 
            // BatchDatesButton
            // 
            this.BatchDatesButton.Location = new System.Drawing.Point(226, 185);
            this.BatchDatesButton.Name = "BatchDatesButton";
            this.BatchDatesButton.Size = new System.Drawing.Size(46, 23);
            this.BatchDatesButton.TabIndex = 5;
            this.BatchDatesButton.Text = "Editar";
            this.BatchDatesButton.UseVisualStyleBackColor = true;
            this.BatchDatesButton.Visible = false;
            this.BatchDatesButton.Click += new System.EventHandler(this.BatchDatesButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rubro(*)";
            // 
            // CategoryBox
            // 
            this.CategoryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Location = new System.Drawing.Point(16, 228);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(200, 21);
            this.CategoryBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Grado(*)";
            // 
            // GradeBox
            // 
            this.GradeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GradeBox.FormattingEnabled = true;
            this.GradeBox.Location = new System.Drawing.Point(16, 273);
            this.GradeBox.Name = "GradeBox";
            this.GradeBox.Size = new System.Drawing.Size(121, 21);
            this.GradeBox.TabIndex = 9;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(764, 326);
            this.shapeContainer1.TabIndex = 10;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 282;
            this.lineShape1.X2 = 282;
            this.lineShape1.Y1 = 24;
            this.lineShape1.Y2 = 291;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ubicaciones(*)";
            // 
            // SketchButton
            // 
            this.SketchButton.Location = new System.Drawing.Point(413, 254);
            this.SketchButton.Name = "SketchButton";
            this.SketchButton.Size = new System.Drawing.Size(82, 40);
            this.SketchButton.TabIndex = 16;
            this.SketchButton.Text = "Guardar como borrador";
            this.SketchButton.UseVisualStyleBackColor = true;
            this.SketchButton.Click += new System.EventHandler(this.SketchButton_Click);
            // 
            // PostButton
            // 
            this.PostButton.Location = new System.Drawing.Point(501, 254);
            this.PostButton.Name = "PostButton";
            this.PostButton.Size = new System.Drawing.Size(82, 40);
            this.PostButton.TabIndex = 16;
            this.PostButton.Text = "Publicar";
            this.PostButton.UseVisualStyleBackColor = true;
            this.PostButton.Click += new System.EventHandler(this.PostButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(589, 254);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(82, 40);
            this.CancelButton.TabIndex = 16;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
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
            this.SeatsGrid.Location = new System.Drawing.Point(294, 30);
            this.SeatsGrid.Name = "SeatsGrid";
            this.SeatsGrid.Size = new System.Drawing.Size(450, 206);
            this.SeatsGrid.TabIndex = 35;
            this.SeatsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SeatsGrid_CellContentClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeleteButton.HeaderText = "Borrar";
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Width = 41;
            // 
            // NotNumbered
            // 
            this.NotNumbered.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NotNumbered.FalseValue = "0";
            this.NotNumbered.HeaderText = "Sin Numerar";
            this.NotNumbered.Name = "NotNumbered";
            this.NotNumbered.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NotNumbered.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NotNumbered.TrueValue = "1";
            this.NotNumbered.Width = 83;
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
            this.SeatType.HeaderText = "Tipo de Asiento";
            this.SeatType.Name = "SeatType";
            this.SeatType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeatType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Dirección(*)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Altura(*)";
            // 
            // AddressText
            // 
            this.AddressText.Location = new System.Drawing.Point(16, 145);
            this.AddressText.Name = "AddressText";
            this.AddressText.Size = new System.Drawing.Size(163, 20);
            this.AddressText.TabIndex = 38;
            // 
            // AddressNroText
            // 
            this.AddressNroText.Location = new System.Drawing.Point(186, 145);
            this.AddressNroText.Name = "AddressNroText";
            this.AddressNroText.Size = new System.Drawing.Size(78, 20);
            this.AddressNroText.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 304);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Los campos con (*) son obligatorios";
            // 
            // GeneratePublication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 326);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AddressNroText);
            this.Controls.Add(this.AddressText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SeatsGrid);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PostButton);
            this.Controls.Add(this.SketchButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.GradeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CategoryBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BatchDatesButton);
            this.Controls.Add(this.BatchDatesCheck);
            this.Controls.Add(this.EventDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "GeneratePublication";
            this.Text = "Generar Publicacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeneratePublication_FormClosing);
            this.Load += new System.EventHandler(this.GeneratePublication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SeatsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker EventDatePicker;
        private System.Windows.Forms.CheckBox BatchDatesCheck;
        private System.Windows.Forms.Button BatchDatesButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CategoryBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox GradeBox;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SketchButton;
        private System.Windows.Forms.Button PostButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridView SeatsGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AddressText;
        private System.Windows.Forms.TextBox AddressNroText;
        private System.Windows.Forms.DataGridViewButtonColumn DeleteButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NotNumbered;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewComboBoxColumn SeatType;
        private System.Windows.Forms.Label label8;
    }
}