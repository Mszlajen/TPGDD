using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public partial class BatchDates : Form
    {
        DataTable fechas;

        public BatchDates(DataTable _fechas)
        {
            InitializeComponent();
            fechas = _fechas;
        }

        private void BatchDates_Load(object sender, EventArgs e)
        {
            DatesGrid.DataSource = fechas;
        }

        private void DatesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && MessageBox.Show("¿Está seguro que desea eliminar está fecha?", "Confirmacion", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                fechas.Rows[e.RowIndex].Delete();
        }

        private void AddDateButton_Click(object sender, EventArgs e)
        {
            if (0 < fechas.Rows.Count && DatePicker.Value < (DateTime)fechas.Rows[fechas.Rows.Count - 1][0])
                MessageBox.Show("No se puede agregar una fecha anterior a la ultima");
            else
                fechas.Rows.Add(new object[] { DatePicker.Value });
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BatchDates_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
                fechas.Clear();
        }


    }
}
