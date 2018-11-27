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
            this.SuspendLayout();
            // 
            // SecurityCodeText
            // 
            this.SecurityCodeText.Location = new System.Drawing.Point(257, 27);
            this.SecurityCodeText.Name = "SecurityCodeText";
            this.SecurityCodeText.Size = new System.Drawing.Size(75, 20);
            this.SecurityCodeText.TabIndex = 35;
            // 
            // CardNumText
            // 
            this.CardNumText.Location = new System.Drawing.Point(12, 27);
            this.CardNumText.Name = "CardNumText";
            this.CardNumText.Size = new System.Drawing.Size(239, 20);
            this.CardNumText.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(231, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "Codigo de seguridad";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Numero de tarjeta";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AddCreditCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 86);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SecurityCodeText);
            this.Controls.Add(this.CardNumText);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Name = "AddCreditCard";
            this.Text = "AddCreditCard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SecurityCodeText;
        private System.Windows.Forms.TextBox CardNumText;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
    }
}