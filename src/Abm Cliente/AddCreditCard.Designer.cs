namespace PalcoNet.Abm_Cliente
{
    partial class AddCreditCard
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
            this.SecurityCodeText = new System.Windows.Forms.TextBox();
            this.CardNumText = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.MonthBox = new System.Windows.Forms.ComboBox();
            this.YearBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SecurityCodeText
            // 
            this.SecurityCodeText.Location = new System.Drawing.Point(230, 25);
            this.SecurityCodeText.Name = "SecurityCodeText";
            this.SecurityCodeText.Size = new System.Drawing.Size(75, 20);
            this.SecurityCodeText.TabIndex = 35;
            // 
            // CardNumText
            // 
            this.CardNumText.Location = new System.Drawing.Point(12, 27);
            this.CardNumText.Name = "CardNumText";
            this.CardNumText.Size = new System.Drawing.Size(203, 20);
            this.CardNumText.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(208, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Codigo de seguridad(*)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(59, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Numero de tarjeta(*)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MonthBox
            // 
            this.MonthBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthBox.FormattingEnabled = true;
            this.MonthBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.MonthBox.Location = new System.Drawing.Point(322, 25);
            this.MonthBox.Name = "MonthBox";
            this.MonthBox.Size = new System.Drawing.Size(40, 21);
            this.MonthBox.TabIndex = 37;
            // 
            // YearBox
            // 
            this.YearBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearBox.FormattingEnabled = true;
            this.YearBox.Location = new System.Drawing.Point(368, 25);
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(56, 21);
            this.YearBox.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(339, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Vencimiento(*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Los campos con (*) son obligatorios";
            // 
            // AddCreditCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 79);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YearBox);
            this.Controls.Add(this.MonthBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SecurityCodeText);
            this.Controls.Add(this.CardNumText);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Name = "AddCreditCard";
            this.Text = "AddCreditCard";
            this.Load += new System.EventHandler(this.AddCreditCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SecurityCodeText;
        private System.Windows.Forms.TextBox CardNumText;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox MonthBox;
        private System.Windows.Forms.ComboBox YearBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}