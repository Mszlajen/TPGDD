namespace PalcoNet.Canje_Puntos
{
    partial class PointExchange
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
            this.ExchangeGrid = new System.Windows.Forms.DataGridView();
            this.ExchangeButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.PointsText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ExchangeGrid
            // 
            this.ExchangeGrid.AllowUserToAddRows = false;
            this.ExchangeGrid.AllowUserToDeleteRows = false;
            this.ExchangeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExchangeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExchangeButton});
            this.ExchangeGrid.Location = new System.Drawing.Point(12, 29);
            this.ExchangeGrid.Name = "ExchangeGrid";
            this.ExchangeGrid.ReadOnly = true;
            this.ExchangeGrid.Size = new System.Drawing.Size(673, 194);
            this.ExchangeGrid.TabIndex = 0;
            this.ExchangeGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExchangeGrid_CellContentClick);
            // 
            // ExchangeButton
            // 
            this.ExchangeButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ExchangeButton.HeaderText = "Canjear";
            this.ExchangeButton.Name = "ExchangeButton";
            this.ExchangeButton.ReadOnly = true;
            this.ExchangeButton.Width = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puntos actuales: ";
            // 
            // PointsText
            // 
            this.PointsText.AutoSize = true;
            this.PointsText.Location = new System.Drawing.Point(99, 13);
            this.PointsText.Name = "PointsText";
            this.PointsText.Size = new System.Drawing.Size(0, 13);
            this.PointsText.TabIndex = 2;
            // 
            // PointExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 261);
            this.Controls.Add(this.PointsText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExchangeGrid);
            this.Name = "PointExchange";
            this.Text = "Canje de puntos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PointExchange_FormClosing);
            this.Load += new System.EventHandler(this.PointExchange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExchangeGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ExchangeGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PointsText;
        private System.Windows.Forms.DataGridViewButtonColumn ExchangeButton;
    }
}