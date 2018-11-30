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

        private void BuyButton_Click(object sender, EventArgs e)
        {
            string codTarjeta;
            if (seleccionadas.Rows.Count == 0)
            {
                MessageBox.Show("No ha seleccionado ubicaciones para compras");
            }
            else if (codCliente == 0)
            {
                MessageBox.Show("No tiene información de cliente asociada por lo que no puede terminar la compra");
            }
            else if (!String.IsNullOrWhiteSpace((codTarjeta = checkTarjeta())) &&
            MessageBox.Show("Por favor confirme que desea continuar con la compra", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                registrarCompra(codTarjeta);
                seleccionadas.Clear();
                ubicaciones.Clear();
            }
            else
            {
                MessageBox.Show("Se cancelo la compra");
            }
        }

        private string checkTarjeta()
        {
            string codTarjeta = null;
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.codTarjetaDe", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codCliente", codCliente));
                cmd.Parameters.Add(new SqlParameter("@fechaHoy", Settings1.Default.CurrentDate));
                SqlParameter ret = new SqlParameter();
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                if (ret.Value == DBNull.Value)
                {
                    Card tarjeta = new Card();
                    MessageBox.Show("No tiene una tarjeta de credito asociada, por favor, registre una para continuar la compra");
                    if (Program.openPopUpWindow(this, new Abm_Cliente.AddCreditCard(tarjeta)) == DialogResult.OK)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "cheshire_jack.guardarTarjeta";

                        cmd.Parameters.Add(new SqlParameter("@codCliente", codCliente));
                        cmd.Parameters.Add(new SqlParameter("@nroTarjeta", Program.sha256(tarjeta.nro)));
                        cmd.Parameters.Add(new SqlParameter("@ultimosDigitos", tarjeta.nro.Substring(tarjeta.nro.Length - 4, 4)));
                        cmd.Parameters.Add(new SqlParameter("@codSeguridad", tarjeta.codSeguridad));
                        cmd.Parameters.Add(new SqlParameter("@mesVencimiento", tarjeta.month));
                        cmd.Parameters.Add(new SqlParameter("@anioVencimiento", tarjeta.year));
                        cmd.Parameters.Add(ret);

                        cmd.ExecuteNonQuery();
                        codTarjeta = ret.Value.ToString();
                    }
                }
                else
                {
                    codTarjeta = ret.Value.ToString();
                }
            }
            return codTarjeta;
        }

        private void registrarCompra(string codTarjeta)
        {
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in seleccionadas.Rows)
                builder.AppendFormat("{0} ", row["nro_ubicacion"].ToString());

            using (SqlCommand cmd = new SqlCommand("cheshire_jack.comprar", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(new SqlParameter[] { 
                    new SqlParameter("@codCliente", codCliente),
                    new SqlParameter("@codTarjeta", codTarjeta),
                    new SqlParameter("@codPublicacion", codPublicacion),
                    new SqlParameter("@ubicaciones", builder.ToString()),
                    new SqlParameter("@fecha", Settings1.Default.CurrentDate)
                });
                cmd.ExecuteNonQuery();
            }
        }
    }
}
