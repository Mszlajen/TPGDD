namespace PalcoNet.Generar_Rendicion_Comisiones
{
    partial class PayFees
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
            this.PendingsGrid = new System.Windows.Forms.DataGridView();
            this.QuantityCounter = new System.Windows.Forms.NumericUpDown();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.BillButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PendingsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // PendingsGrid
            // 
            this.PendingsGrid.AllowUserToAddRows = false;
            this.PendingsGrid.AllowUserToDeleteRows = false;
            this.PendingsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PendingsGrid.Location = new System.Drawing.Point(13, 56);
            this.PendingsGrid.Name = "PendingsGrid";
            this.PendingsGrid.ReadOnly = true;
            this.PendingsGrid.Size = new System.Drawing.Size(557, 175);
            this.PendingsGrid.TabIndex = 0;
            // 
            // QuantityCounter
            // 
            this.QuantityCounter.Location = new System.Drawing.Point(236, 21);
            this.QuantityCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuantityCounter.Name = "QuantityCounter";
            this.QuantityCounter.Size = new System.Drawing.Size(120, 20);
            this.QuantityCounter.TabIndex = 1;
            this.QuantityCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(13, 21);
            this.NameBox.Name = "NameBox";
            this.NameBox.ReadOnly = true;
            this.NameBox.Size = new System.Drawing.Size(193, 20);
            this.NameBox.TabIndex = 2;
            // 
            // BillButton
            // 
            this.BillButton.Location = new System.Drawing.Point(403, 21);
            this.BillButton.Name = "BillButton";
            this.BillButton.Size = new System.Drawing.Size(140, 23);
            this.BillButton.TabIndex = 3;
            this.BillButton.Text = "Facturar";
            this.BillButton.UseVisualStyleBackColor = true;
            this.BillButton.Click += new System.EventHandler(this.BillButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cantidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Razon Social";
            // 
            // PayFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 243);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BillButton);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.QuantityCounter);
            this.Controls.Add(this.PendingsGrid);
            this.Name = "PayFees";
            this.Text = "PayFees";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PayFees_FormClosing);
            this.Load += new System.EventHandler(this.PayFees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PendingsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PendingsGrid;
        private System.Windows.Forms.NumericUpDown QuantityCounter;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button BillButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}