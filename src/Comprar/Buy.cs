using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PalcoNet.Comprar
{
    public partial class Buy : Form
    {
        int codCliente;
        decimal codPublicacion;
        DataTable ubicaciones = new DataTable(), tiposUbicacion = new DataTable(), seleccionadas = new DataTable();
        public Buy(int _codCliente, decimal _codPublicacion)
        {
            InitializeComponent();
            codCliente = _codCliente;
            codPublicacion = _codPublicacion;
        }

        private void cargarUbicaciones(Nullable<int> tipoUbicacion)
        {
            ubicaciones.Clear();
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.buscarUbicaciones", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codPublicacion", codPublicacion));
                if(!tipoUbicacion.HasValue)
                    cmd.Parameters.Add(new SqlParameter("@tipoUbicacion", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@tipoUbicacion", tipoUbicacion.Value));
                ubicaciones.Load(cmd.ExecuteReader());
            }
        }

        private void Buy_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.DBconn;
                cmd.CommandText = "SELECT * FROM cheshire_jack.vw_tipos_de_ubicacion";
                tiposUbicacion.Load(cmd.ExecuteReader());
            }

            cargarUbicaciones(null);

            ubicaciones.PrimaryKey = new DataColumn[] { ubicaciones.Columns["nro_ubicacion"] };
            SeatsGrid.DataSource = ubicaciones;
            SeatsGrid.Columns["nro_ubicacion"].Visible = false;
            foreach (DataRow row in tiposUbicacion.Rows)
                TypeBox.Items.Add(row["nombre"].ToString());
            seleccionadas = ubicaciones.Clone();
            seleccionadas.PrimaryKey = new DataColumn[] { seleccionadas.Columns["nro_ubicacion"] };
        }

        private void SeatsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (SeatsGrid[e.ColumnIndex, e.RowIndex].Value == null ? false : (bool)SeatsGrid[e.ColumnIndex, e.RowIndex].Value)
                    seleccionadas.Rows.Remove(seleccionadas.Rows.Find(SeatsGrid["nro_ubicacion", e.RowIndex].Value));
                else
                    seleccionadas.ImportRow(ubicaciones.Rows[e.RowIndex]);
                    
            }
        }

        private void marcarSeleccionadas()
        {
            foreach (DataGridViewRow row in SeatsGrid.Rows)
            {
                if (seleccionadas.Rows.Contains(row.Cells["nro_ubicacion"].Value))
                    row.Cells[0].Value = true;
            }
        }

        private void SelectedOnlyCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedOnlyCheck.Checked)
            {
                SeatsGrid.DataSource = seleccionadas;
                foreach (DataGridViewRow row in SeatsGrid.Rows)
                    row.Cells[0].Value = true;
            }
            else
            {
                SeatsGrid.DataSource = ubicaciones;
                marcarSeleccionadas();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ubicaciones.Clear();
            TypeBox.SelectedIndex = -1;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            cargarUbicaciones(TypeBox.SelectedIndex == -1? null : (Nullable<int>)tiposUbicacion.Rows[TypeBox.SelectedIndex][0]);
            marcarSeleccionadas();
        }
    }
}
