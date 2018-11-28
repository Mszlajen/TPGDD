namespace PalcoNet.Abm_Cliente
{
    partial class CreateClient
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
            this.SurnameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FirstNameBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DocumentTypeBox = new System.Windows.Forms.ComboBox();
            this.DocumentNroBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CUILBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MailBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.BirthDatePicker = new System.Windows.Forms.DateTimePicker();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.AddressNroBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DeptBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FloorBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LocalityBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.PostalCodeBox = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.EnabledBox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.CreationDatePicker = new System.Windows.Forms.DateTimePicker();
            this.AddCardDataButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Apellido(*)";
            // 
            // SurnameBox
            // 
            this.SurnameBox.Location = new System.Drawing.Point(16, 30);
            this.SurnameBox.Name = "SurnameBox";
            this.SurnameBox.Size = new System.Drawing.Size(164, 20);
            this.SurnameBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nombre(*)";
            // 
            // FirstNameBox
            // 
            this.FirstNameBox.Location = new System.Drawing.Point(16, 70);
            this.FirstNameBox.Name = "FirstNameBox";
            this.FirstNameBox.Size = new System.Drawing.Size(164, 20);
            this.FirstNameBox.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Tipo y Nro de Documento(*)";
            // 
            // DocumentTypeBox
            // 
            this.DocumentTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DocumentTypeBox.FormattingEnabled = true;
            this.DocumentTypeBox.Items.AddRange(new object[] {
            "DNI"});
            this.DocumentTypeBox.Location = new System.Drawing.Point(18, 109);
            this.DocumentTypeBox.Name = "DocumentTypeBox";
            this.DocumentTypeBox.Size = new System.Drawing.Size(121, 21);
            this.DocumentTypeBox.TabIndex = 5;
            this.DocumentTypeBox.SelectedIndexChanged += new System.EventHandler(this.DocumentTypeBox_SelectedIndexChanged);
            // 
            // DocumentNroBox
            // 
            this.DocumentNroBox.Enabled = false;
            this.DocumentNroBox.Location = new System.Drawing.Point(18, 136);
            this.DocumentNroBox.Name = "DocumentNroBox";
            this.DocumentNroBox.Size = new System.Drawing.Size(121, 20);
            this.DocumentNroBox.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "CUIL(*)";
            // 
            // CUILBox
            // 
            this.CUILBox.Location = new System.Drawing.Point(18, 175);
            this.CUILBox.Name = "CUILBox";
            this.CUILBox.Size = new System.Drawing.Size(121, 20);
            this.CUILBox.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Fecha de Nacimiento(*)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(301, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "E-Mail(*)";
            // 
            // MailBox
            // 
            this.MailBox.Location = new System.Drawing.Point(301, 30);
            this.MailBox.Name = "MailBox";
            this.MailBox.Size = new System.Drawing.Size(254, 20);
            this.MailBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Telefono";
            // 
            // PhoneBox
            // 
            this.PhoneBox.Location = new System.Drawing.Point(302, 70);
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Size = new System.Drawing.Size(152, 20);
            this.PhoneBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Dirección(*)";
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(302, 109);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(190, 20);
            this.AddressBox.TabIndex = 16;
            // 
            // BirthDatePicker
            // 
            this.BirthDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BirthDatePicker.Location = new System.Drawing.Point(18, 215);
            this.BirthDatePicker.Name = "BirthDatePicker";
            this.BirthDatePicker.Size = new System.Drawing.Size(200, 20);
            this.BirthDatePicker.TabIndex = 10;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(638, 293);
            this.shapeContainer1.TabIndex = 17;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 277;
            this.lineShape1.X2 = 277;
            this.lineShape1.Y1 = 275;
            this.lineShape1.Y2 = 15;
            // 
            // AddressNroBox
            // 
            this.AddressNroBox.Location = new System.Drawing.Point(498, 109);
            this.AddressNroBox.Name = "AddressNroBox";
            this.AddressNroBox.Size = new System.Drawing.Size(42, 20);
            this.AddressNroBox.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nro(*)";
            // 
            // DeptBox
            // 
            this.DeptBox.Location = new System.Drawing.Point(588, 109);
            this.DeptBox.Name = "DeptBox";
            this.DeptBox.Size = new System.Drawing.Size(36, 20);
            this.DeptBox.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Depto";
            // 
            // FloorBox
            // 
            this.FloorBox.Location = new System.Drawing.Point(546, 109);
            this.FloorBox.Name = "FloorBox";
            this.FloorBox.Size = new System.Drawing.Size(36, 20);
            this.FloorBox.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(546, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Piso";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(298, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Localidad(*)";
            // 
            // LocalityBox
            // 
            this.LocalityBox.Location = new System.Drawing.Point(302, 150);
            this.LocalityBox.Name = "LocalityBox";
            this.LocalityBox.Size = new System.Drawing.Size(190, 20);
            this.LocalityBox.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(501, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Codigo Postal(*)";
            // 
            // PostalCodeBox
            // 
            this.PostalCodeBox.Location = new System.Drawing.Point(499, 150);
            this.PostalCodeBox.Name = "PostalCodeBox";
            this.PostalCodeBox.Size = new System.Drawing.Size(100, 20);
            this.PostalCodeBox.TabIndex = 25;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(302, 233);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(96, 48);
            this.ClearButton.TabIndex = 26;
            this.ClearButton.Text = "Limpiar";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // EnabledBox
            // 
            this.EnabledBox.AutoSize = true;
            this.EnabledBox.Location = new System.Drawing.Point(549, 249);
            this.EnabledBox.Name = "EnabledBox";
            this.EnabledBox.Size = new System.Drawing.Size(64, 17);
            this.EnabledBox.TabIndex = 27;
            this.EnabledBox.Text = "Habilitar";
            this.EnabledBox.UseVisualStyleBackColor = true;
            this.EnabledBox.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(426, 232);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 48);
            this.SaveButton.TabIndex = 26;
            this.SaveButton.Text = "Guardar";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 243);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Fecha de Creacion";
            // 
            // CreationDatePicker
            // 
            this.CreationDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CreationDatePicker.Location = new System.Drawing.Point(18, 260);
            this.CreationDatePicker.Name = "CreationDatePicker";
            this.CreationDatePicker.Size = new System.Drawing.Size(200, 20);
            this.CreationDatePicker.TabIndex = 10;
            // 
            // AddCardDataButton
            // 
            this.AddCardDataButton.Location = new System.Drawing.Point(301, 180);
            this.AddCardDataButton.Name = "AddCardDataButton";
            this.AddCardDataButton.Size = new System.Drawing.Size(97, 47);
            this.AddCardDataButton.TabIndex = 28;
            this.AddCardDataButton.Text = "Añadir informacion de tarjeta";
            this.AddCardDataButton.UseVisualStyleBackColor = true;
            this.AddCardDataButton.Click += new System.EventHandler(this.AddCardDataButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(425, 198);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(174, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Los campos con (*) son obligatorios";
            // 
            // CreateClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 293);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.AddCardDataButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CreationDatePicker);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.EnabledBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.PostalCodeBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LocalityBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FloorBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DeptBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AddressNroBox);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PhoneBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MailBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BirthDatePicker);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CUILBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DocumentNroBox);
            this.Controls.Add(this.DocumentTypeBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.FirstNameBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SurnameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "CreateClient";
            this.Text = "Crear Cliente";
            this.Load += new System.EventHandler(this.CreateClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SurnameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox FirstNameBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox DocumentTypeBox;
        private System.Windows.Forms.TextBox DocumentNroBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CUILBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox MailBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.DateTimePicker BirthDatePicker;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox AddressNroBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DeptBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FloorBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox LocalityBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox PostalCodeBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.CheckBox EnabledBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker CreationDatePicker;
        private System.Windows.Forms.Button AddCardDataButton;
        private System.Windows.Forms.Label label15;
    }
}