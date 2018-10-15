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
            this.DeleteDateButton = new System.Windows.Forms.Button();
            this.DatesList = new System.Windows.Forms.ListBox();
            this.AddDateButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DeleteDateButton
            // 
            this.DeleteDateButton.Location = new System.Drawing.Point(93, 161);
            this.DeleteDateButton.Name = "DeleteDateButton";
            this.DeleteDateButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteDateButton.TabIndex = 19;
            this.DeleteDateButton.Text = "Quitar";
            this.DeleteDateButton.UseVisualStyleBackColor = true;
            // 
            // DatesList
            // 
            this.DatesList.FormattingEnabled = true;
            this.DatesList.Location = new System.Drawing.Point(12, 23);
            this.DatesList.Name = "DatesList";
            this.DatesList.Size = new System.Drawing.Size(288, 134);
            this.DatesList.TabIndex = 18;
            // 
            // AddDateButton
            // 
            this.AddDateButton.Location = new System.Drawing.Point(12, 161);
            this.AddDateButton.Name = "AddDateButton";
            this.AddDateButton.Size = new System.Drawing.Size(75, 23);
            this.AddDateButton.TabIndex = 17;
            this.AddDateButton.Text = "Agregar";
            this.AddDateButton.UseVisualStyleBackColor = true;
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
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(69, 209);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(82, 40);
            this.SaveButton.TabIndex = 21;
            this.SaveButton.Text = "Guardar";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // BatchDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 261);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteDateButton);
            this.Controls.Add(this.DatesList);
            this.Controls.Add(this.AddDateButton);
            this.Controls.Add(this.label5);
            this.Name = "BatchDates";
            this.Text = "BatchDates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteDateButton;
        private System.Windows.Forms.ListBox DatesList;
        private System.Windows.Forms.Button AddDateButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
    }
}