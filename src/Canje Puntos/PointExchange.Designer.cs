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
            this.Exchangerid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.PointsText = new System.Windows.Forms.Label();
            this.PrizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExchangeButton = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Exchangerid)).BeginInit();
            this.SuspendLayout();
            // 
            // Exchangerid
            // 
            this.Exchangerid.AllowUserToAddRows = false;
            this.Exchangerid.AllowUserToDeleteRows = false;
            this.Exchangerid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Exchangerid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrizeName,
            this.Description,
            this.Stock,
            this.Value,
            this.ExchangeButton});
            this.Exchangerid.Location = new System.Drawing.Point(12, 29);
            this.Exchangerid.Name = "Exchangerid";
            this.Exchangerid.ReadOnly = true;
            this.Exchangerid.Size = new System.Drawing.Size(673, 194);
            this.Exchangerid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puntos actuales: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PointsText
            // 
            this.PointsText.AutoSize = true;
            this.PointsText.Location = new System.Drawing.Point(99, 13);
            this.PointsText.Name = "PointsText";
            this.PointsText.Size = new System.Drawing.Size(0, 13);
            this.PointsText.TabIndex = 2;
            // 
            // PrizeName
            // 
            this.PrizeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PrizeName.HeaderText = "Nombre";
            this.PrizeName.Name = "PrizeName";
            this.PrizeName.ReadOnly = true;
            this.PrizeName.Width = 69;
            // 
            // Description
            // 
            this.Description.HeaderText = "Descripción";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Stock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Stock.Width = 41;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Value.HeaderText = "Valor";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 56;
            // 
            // ExchangeButton
            // 
            this.ExchangeButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ExchangeButton.HeaderText = "Canjear";
            this.ExchangeButton.Name = "ExchangeButton";
            this.ExchangeButton.ReadOnly = true;
            this.ExchangeButton.Width = 49;
            // 
            // PointExchange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 261);
            this.Controls.Add(this.PointsText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exchangerid);
            this.Name = "PointExchange";
            this.Text = "Canje de puntos";
            this.Load += new System.EventHandler(this.PointExchange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Exchangerid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Exchangerid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PointsText;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewButtonColumn ExchangeButton;
    }
}