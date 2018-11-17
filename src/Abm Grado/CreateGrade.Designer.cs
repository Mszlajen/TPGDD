namespace PalcoNet.Abm_Grado
{
    partial class CreateGrade
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
            this.NameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PercentNumeric = new System.Windows.Forms.NumericUpDown();
            this.WeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PercentNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(13, 30);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(201, 20);
            this.NameText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Porcentaje de cobro";
            // 
            // PercentNumeric
            // 
            this.PercentNumeric.Location = new System.Drawing.Point(13, 75);
            this.PercentNumeric.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.PercentNumeric.Name = "PercentNumeric";
            this.PercentNumeric.Size = new System.Drawing.Size(55, 20);
            this.PercentNumeric.TabIndex = 4;
            // 
            // WeightNumeric
            // 
            this.WeightNumeric.Location = new System.Drawing.Point(139, 75);
            this.WeightNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.WeightNumeric.Name = "WeightNumeric";
            this.WeightNumeric.Size = new System.Drawing.Size(42, 20);
            this.WeightNumeric.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Peso";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(13, 111);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Crear";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(139, 110);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreateGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 150);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WeightNumeric);
            this.Controls.Add(this.PercentNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.label1);
            this.Name = "CreateGrade";
            this.Text = "CreateGrade";
            this.Load += new System.EventHandler(this.CreateGrade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PercentNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PercentNumeric;
        private System.Windows.Forms.NumericUpDown WeightNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}