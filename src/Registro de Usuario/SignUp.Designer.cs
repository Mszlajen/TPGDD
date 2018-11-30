namespace PalcoNet.Registro_de_Usuario
{
    partial class SignUp
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
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RoleBox = new System.Windows.Forms.ComboBox();
            this.DataCompletedBox = new System.Windows.Forms.CheckBox();
            this.CompleteDataButton = new System.Windows.Forms.Button();
            this.SignUpButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ShowPasswordBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario(*)";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(16, 30);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(185, 20);
            this.UsernameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña(*)";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(16, 74);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(185, 20);
            this.PasswordBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rol(*)";
            // 
            // RoleBox
            // 
            this.RoleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleBox.FormattingEnabled = true;
            this.RoleBox.Location = new System.Drawing.Point(16, 139);
            this.RoleBox.Name = "RoleBox";
            this.RoleBox.Size = new System.Drawing.Size(185, 21);
            this.RoleBox.TabIndex = 5;
            this.RoleBox.SelectedIndexChanged += new System.EventHandler(this.RoleBox_SelectedIndexChanged);
            this.RoleBox.SelectionChangeCommitted += new System.EventHandler(this.RoleBox_SelectionChangeCommitted);
            // 
            // DataCompletedBox
            // 
            this.DataCompletedBox.AutoCheck = false;
            this.DataCompletedBox.AutoSize = true;
            this.DataCompletedBox.Enabled = false;
            this.DataCompletedBox.Location = new System.Drawing.Point(53, 168);
            this.DataCompletedBox.Name = "DataCompletedBox";
            this.DataCompletedBox.Size = new System.Drawing.Size(117, 17);
            this.DataCompletedBox.TabIndex = 6;
            this.DataCompletedBox.Text = "Datos completados";
            this.DataCompletedBox.UseVisualStyleBackColor = true;
            // 
            // CompleteDataButton
            // 
            this.CompleteDataButton.Enabled = false;
            this.CompleteDataButton.Location = new System.Drawing.Point(15, 191);
            this.CompleteDataButton.Name = "CompleteDataButton";
            this.CompleteDataButton.Size = new System.Drawing.Size(186, 38);
            this.CompleteDataButton.TabIndex = 7;
            this.CompleteDataButton.Text = "Completar datos(*)";
            this.CompleteDataButton.UseVisualStyleBackColor = true;
            this.CompleteDataButton.Click += new System.EventHandler(this.CompleteDataButton_Click);
            // 
            // SignUpButton
            // 
            this.SignUpButton.Location = new System.Drawing.Point(125, 247);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(76, 23);
            this.SignUpButton.TabIndex = 8;
            this.SignUpButton.Text = "Registrarse";
            this.SignUpButton.UseVisualStyleBackColor = true;
            this.SignUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(16, 247);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(76, 23);
            this.ClearButton.TabIndex = 8;
            this.ClearButton.Text = "Limpiar";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Los campos con (*) son obligatorios";
            // 
            // ShowPasswordBox
            // 
            this.ShowPasswordBox.AutoSize = true;
            this.ShowPasswordBox.Location = new System.Drawing.Point(52, 100);
            this.ShowPasswordBox.Name = "ShowPasswordBox";
            this.ShowPasswordBox.Size = new System.Drawing.Size(118, 17);
            this.ShowPasswordBox.TabIndex = 10;
            this.ShowPasswordBox.Text = "Mostrar Contraseña";
            this.ShowPasswordBox.UseVisualStyleBackColor = true;
            this.ShowPasswordBox.CheckedChanged += new System.EventHandler(this.ShowPasswordBox_CheckedChanged);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 316);
            this.Controls.Add(this.ShowPasswordBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SignUpButton);
            this.Controls.Add(this.CompleteDataButton);
            this.Controls.Add(this.DataCompletedBox);
            this.Controls.Add(this.RoleBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.label1);
            this.Name = "SignUp";
            this.Text = "Registrarse";
            this.Load += new System.EventHandler(this.SignUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RoleBox;
        private System.Windows.Forms.CheckBox DataCompletedBox;
        private System.Windows.Forms.Button CompleteDataButton;
        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ShowPasswordBox;
    }
}