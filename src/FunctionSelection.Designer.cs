namespace PalcoNet
{
    partial class FunctionSelection
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
            this.FunctionsBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FunctionsBox
            // 
            this.FunctionsBox.FormattingEnabled = true;
            this.FunctionsBox.Location = new System.Drawing.Point(12, 28);
            this.FunctionsBox.Name = "FunctionsBox";
            this.FunctionsBox.Size = new System.Drawing.Size(260, 21);
            this.FunctionsBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Funciones disponibles";
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(61, 55);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 39);
            this.AcceptButton.TabIndex = 2;
            this.AcceptButton.Text = "Ir";
            this.AcceptButton.UseVisualStyleBackColor = true;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(142, 55);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(75, 39);
            this.LogoutButton.TabIndex = 3;
            this.LogoutButton.Text = "Cerrar Sesion";
            this.LogoutButton.UseVisualStyleBackColor = true;
            // 
            // FunctionSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 106);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FunctionsBox);
            this.Name = "FunctionSelection";
            this.Text = "Seleccionar funcionalidad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FunctionsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button LogoutButton;
    }
}