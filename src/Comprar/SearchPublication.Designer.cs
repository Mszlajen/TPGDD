﻿namespace PalcoNet.Comprar
{
    partial class SearchPublication
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
            this.PageGrid = new System.Windows.Forms.DataGridView();
            this.BuyButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.TagBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FromPicker = new System.Windows.Forms.DateTimePicker();
            this.ToPicker = new System.Windows.Forms.DateTimePicker();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.FirstButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.LastButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PageNumText = new System.Windows.Forms.Label();
            this.FromCheck = new System.Windows.Forms.CheckBox();
            this.ToCheck = new System.Windows.Forms.CheckBox();
            this.NumLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PageGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // PageGrid
            // 
            this.PageGrid.AllowUserToAddRows = false;
            this.PageGrid.AllowUserToDeleteRows = false;
            this.PageGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PageGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuyButton});
            this.PageGrid.Location = new System.Drawing.Point(12, 146);
            this.PageGrid.Name = "PageGrid";
            this.PageGrid.Size = new System.Drawing.Size(667, 209);
            this.PageGrid.TabIndex = 0;
            this.PageGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PageGrid_CellContentClick);
            // 
            // BuyButton
            // 
            this.BuyButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BuyButton.HeaderText = "Comprar";
            this.BuyButton.Name = "BuyButton";
            this.BuyButton.Width = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rubro";
            // 
            // TagBox
            // 
            this.TagBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TagBox.FormattingEnabled = true;
            this.TagBox.Location = new System.Drawing.Point(15, 30);
            this.TagBox.Name = "TagBox";
            this.TagBox.Size = new System.Drawing.Size(121, 21);
            this.TagBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(228, 34);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(266, 97);
            this.DescriptionBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Desde";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hasta";
            // 
            // FromPicker
            // 
            this.FromPicker.CustomFormat = " ";
            this.FromPicker.Enabled = false;
            this.FromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromPicker.Location = new System.Drawing.Point(15, 71);
            this.FromPicker.Name = "FromPicker";
            this.FromPicker.Size = new System.Drawing.Size(156, 20);
            this.FromPicker.TabIndex = 7;
            // 
            // ToPicker
            // 
            this.ToPicker.CustomFormat = " ";
            this.ToPicker.Enabled = false;
            this.ToPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToPicker.Location = new System.Drawing.Point(13, 111);
            this.ToPicker.Name = "ToPicker";
            this.ToPicker.Size = new System.Drawing.Size(158, 20);
            this.ToPicker.TabIndex = 8;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(527, 34);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(137, 38);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Limpiar";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(527, 92);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(137, 38);
            this.SearchButton.TabIndex = 9;
            this.SearchButton.Text = "Buscar";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // FirstButton
            // 
            this.FirstButton.Enabled = false;
            this.FirstButton.Location = new System.Drawing.Point(15, 362);
            this.FirstButton.Name = "FirstButton";
            this.FirstButton.Size = new System.Drawing.Size(75, 49);
            this.FirstButton.TabIndex = 10;
            this.FirstButton.Text = "Primera";
            this.FirstButton.UseVisualStyleBackColor = true;
            this.FirstButton.Click += new System.EventHandler(this.FirstButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Enabled = false;
            this.PreviousButton.Location = new System.Drawing.Point(96, 361);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(75, 49);
            this.PreviousButton.TabIndex = 10;
            this.PreviousButton.Text = "Anterior";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // LastButton
            // 
            this.LastButton.Enabled = false;
            this.LastButton.Location = new System.Drawing.Point(604, 361);
            this.LastButton.Name = "LastButton";
            this.LastButton.Size = new System.Drawing.Size(75, 49);
            this.LastButton.TabIndex = 10;
            this.LastButton.Text = "Ultima";
            this.LastButton.UseVisualStyleBackColor = true;
            this.LastButton.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Enabled = false;
            this.NextButton.Location = new System.Drawing.Point(523, 362);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 49);
            this.NextButton.TabIndex = 10;
            this.NextButton.Text = "Siguiente";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PageNumText
            // 
            this.PageNumText.AutoSize = true;
            this.PageNumText.Location = new System.Drawing.Point(280, 362);
            this.PageNumText.Name = "PageNumText";
            this.PageNumText.Size = new System.Drawing.Size(50, 13);
            this.PageNumText.TabIndex = 11;
            this.PageNumText.Text = "Pagina #";
            // 
            // FromCheck
            // 
            this.FromCheck.AutoSize = true;
            this.FromCheck.Location = new System.Drawing.Point(178, 73);
            this.FromCheck.Name = "FromCheck";
            this.FromCheck.Size = new System.Drawing.Size(15, 14);
            this.FromCheck.TabIndex = 12;
            this.FromCheck.UseVisualStyleBackColor = true;
            this.FromCheck.CheckedChanged += new System.EventHandler(this.FromCheck_CheckedChanged);
            // 
            // ToCheck
            // 
            this.ToCheck.AutoSize = true;
            this.ToCheck.Location = new System.Drawing.Point(178, 116);
            this.ToCheck.Name = "ToCheck";
            this.ToCheck.Size = new System.Drawing.Size(15, 14);
            this.ToCheck.TabIndex = 13;
            this.ToCheck.UseVisualStyleBackColor = true;
            this.ToCheck.CheckedChanged += new System.EventHandler(this.ToCheck_CheckedChanged);
            // 
            // NumLabel
            // 
            this.NumLabel.AutoSize = true;
            this.NumLabel.Location = new System.Drawing.Point(336, 362);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(44, 13);
            this.NumLabel.TabIndex = 14;
            this.NumLabel.Text = "Numero";
            // 
            // SearchPublication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 444);
            this.Controls.Add(this.NumLabel);
            this.Controls.Add(this.ToCheck);
            this.Controls.Add(this.FromCheck);
            this.Controls.Add(this.PageNumText);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.LastButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.FirstButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ToPicker);
            this.Controls.Add(this.FromPicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TagBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PageGrid);
            this.Name = "SearchPublication";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SearchPublication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PageGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PageGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TagBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker FromPicker;
        private System.Windows.Forms.DateTimePicker ToPicker;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button FirstButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button LastButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label PageNumText;
        private System.Windows.Forms.DataGridViewButtonColumn BuyButton;
        private System.Windows.Forms.CheckBox FromCheck;
        private System.Windows.Forms.CheckBox ToCheck;
        private System.Windows.Forms.Label NumLabel;
    }
}