﻿namespace PalcoNet.Abm_Rol
{
    partial class CreateRole
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
            this.RoleNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FunctionsList = new System.Windows.Forms.CheckedListBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.availabilityCheck = new System.Windows.Forms.CheckBox();
            this.SignUpCheck = new System.Windows.Forms.CheckBox();
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
            // RoleNameBox
            // 
            this.RoleNameBox.Location = new System.Drawing.Point(16, 30);
            this.RoleNameBox.Name = "RoleNameBox";
            this.RoleNameBox.Size = new System.Drawing.Size(256, 20);
            this.RoleNameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidades";
            // 
            // FunctionsList
            // 
            this.FunctionsList.FormattingEnabled = true;
            this.FunctionsList.Location = new System.Drawing.Point(16, 83);
            this.FunctionsList.Name = "FunctionsList";
            this.FunctionsList.Size = new System.Drawing.Size(256, 109);
            this.FunctionsList.TabIndex = 3;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(16, 244);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(90, 39);
            this.AcceptButton.TabIndex = 4;
            this.AcceptButton.Text = "Crear";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(182, 244);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(90, 39);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // availabilityCheck
            // 
            this.availabilityCheck.AutoSize = true;
            this.availabilityCheck.Checked = true;
            this.availabilityCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.availabilityCheck.Location = new System.Drawing.Point(180, 209);
            this.availabilityCheck.Name = "availabilityCheck";
            this.availabilityCheck.Size = new System.Drawing.Size(92, 17);
            this.availabilityCheck.TabIndex = 10;
            this.availabilityCheck.Text = "Rol Habilitado";
            this.availabilityCheck.UseVisualStyleBackColor = true;
            this.availabilityCheck.Visible = false;
            // 
            // SignUpCheck
            // 
            this.SignUpCheck.AutoSize = true;
            this.SignUpCheck.Location = new System.Drawing.Point(16, 209);
            this.SignUpCheck.Name = "SignUpCheck";
            this.SignUpCheck.Size = new System.Drawing.Size(79, 17);
            this.SignUpCheck.TabIndex = 11;
            this.SignUpCheck.Text = "Registrable";
            this.SignUpCheck.UseVisualStyleBackColor = true;
            // 
            // CreateRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 295);
            this.Controls.Add(this.SignUpCheck);
            this.Controls.Add(this.availabilityCheck);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.FunctionsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RoleNameBox);
            this.Controls.Add(this.label1);
            this.Name = "CreateRole";
            this.Text = "Crear Rol";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateRole_FormClosing);
            this.Load += new System.EventHandler(this.CreateRole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RoleNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox FunctionsList;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox availabilityCheck;
        private System.Windows.Forms.CheckBox SignUpCheck;
    }
}