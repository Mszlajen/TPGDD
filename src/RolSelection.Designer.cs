namespace PalcoNet
{
    partial class RolSelection
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
            this.RolesBox = new System.Windows.Forms.ComboBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Roles disponibles";
            // 
            // RolesBox
            // 
            this.RolesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RolesBox.FormattingEnabled = true;
            this.RolesBox.Location = new System.Drawing.Point(16, 29);
            this.RolesBox.Name = "RolesBox";
            this.RolesBox.Size = new System.Drawing.Size(256, 21);
            this.RolesBox.TabIndex = 1;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(53, 56);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(81, 34);
            this.AcceptButton.TabIndex = 2;
            this.AcceptButton.Text = "Ingresar";
            this.AcceptButton.UseVisualStyleBackColor = true;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(151, 56);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(75, 34);
            this.LogoutButton.TabIndex = 4;
            this.LogoutButton.Text = "Cerrar Sesion";
            this.LogoutButton.UseVisualStyleBackColor = true;
            // 
            // RolSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 104);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.RolesBox);
            this.Controls.Add(this.label1);
            this.Name = "RolSelection";
            this.Text = "Seleccionar Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox RolesBox;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button LogoutButton;
    }
}