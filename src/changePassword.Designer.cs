namespace PalcoNet
{
    partial class changePassword
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
            this.NewPasswordText = new System.Windows.Forms.TextBox();
            this.ShowPasswordBox = new System.Windows.Forms.CheckBox();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Su contraseña ha expirado. \r\nPor favor ingrese una nueva contraseña";
            // 
            // NewPasswordText
            // 
            this.NewPasswordText.Location = new System.Drawing.Point(16, 43);
            this.NewPasswordText.Name = "NewPasswordText";
            this.NewPasswordText.PasswordChar = '*';
            this.NewPasswordText.Size = new System.Drawing.Size(194, 20);
            this.NewPasswordText.TabIndex = 1;
            // 
            // ShowPasswordBox
            // 
            this.ShowPasswordBox.AutoSize = true;
            this.ShowPasswordBox.Location = new System.Drawing.Point(16, 70);
            this.ShowPasswordBox.Name = "ShowPasswordBox";
            this.ShowPasswordBox.Size = new System.Drawing.Size(118, 17);
            this.ShowPasswordBox.TabIndex = 2;
            this.ShowPasswordBox.Text = "Mostrar Contraseña";
            this.ShowPasswordBox.UseVisualStyleBackColor = true;
            this.ShowPasswordBox.CheckStateChanged += new System.EventHandler(this.ShowPasswordBox_CheckStateChanged);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(16, 94);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(193, 23);
            this.ContinueButton.TabIndex = 3;
            this.ContinueButton.Text = "Continuar";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // changePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 131);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.ShowPasswordBox);
            this.Controls.Add(this.NewPasswordText);
            this.Controls.Add(this.label1);
            this.Name = "changePassword";
            this.Text = "changePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewPasswordText;
        private System.Windows.Forms.CheckBox ShowPasswordBox;
        private System.Windows.Forms.Button ContinueButton;
    }
}