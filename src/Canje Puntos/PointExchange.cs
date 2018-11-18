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

namespace PalcoNet.Canje_Puntos
{
    public partial class PointExchange : Form
    {
        DataTable premios = new DataTable();
        int codUsuario, codCliente;
        double puntos = 0;
        bool esCliente = true;

        public PointExchange(int _codUsuario)
        {
            InitializeComponent();
            codUsuario = _codUsuario;
        }

        private void PointExchange_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM cheshire_jack.vw_premios", Program.DBconn);
            SqlDataReader resultadoQuery = cmd.ExecuteReader();
            premios.Load(resultadoQuery);
            resultadoQuery.Close();
            ExchangeGrid.DataSource = premios;
            ExchangeGrid.Columns["cod_premio"].Visible = false;

            cmd.CommandText = "SELECT cod_cliente FROM cheshire_jack.clientes WHERE cod_usuario = @cod_usuario";
            cmd.Parameters.Add(new SqlParameter("@cod_usuario", codUsuario));
            resultadoQuery = cmd.ExecuteReader();
            if (!resultadoQuery.Read())
            {
                esCliente = false;
                MessageBox.Show("Este usuario no tiene informacion de cliente y no podra terminar las operaciones");
            }
            else
            {
                codCliente = resultadoQuery.GetInt32(0);
                resultadoQuery.Close();
                string queryString = "SELECT cantidad FROM cheshire_jack.puntos WHERE cod_cliente = @codCliente AND anio_vencimiento = @anio";
                cmd = new SqlCommand(queryString, Program.DBconn);
                cmd.Parameters.Add(new SqlParameter("@codCliente", codCliente));
                cmd.Parameters.Add(new SqlParameter("@anio", Settings1.Default.CurrentDate.Year + 1));
                resultadoQuery = cmd.ExecuteReader();
                if(resultadoQuery.Read())
                    puntos = double.Parse(resultadoQuery.GetValue(0).ToString());
            }
            resultadoQuery.Close();
            cmd.Dispose();

            PointsText.Text = puntos.ToString();
        }

        private void PointExchange_FormClosing(object sender, FormClosingEventArgs e)
        {
            premios.Dispose();
        }

        private void ExchangeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                double costo = double.Parse(ExchangeGrid.Rows[e.RowIndex].Cells["costo"].Value.ToString());
                int stock = (int)ExchangeGrid.Rows[e.RowIndex].Cells["Disponibles"].Value;
                if (stock == 0)
                    MessageBox.Show("No quedan unidades disponibles");
                else if (puntos < costo)
                    MessageBox.Show("No tiene suficientes puntos para este premio");
                else
                {
                    using (SqlCommand cmd = new SqlCommand("cheshire_jack.hacer_canje", Program.DBconn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@cod_cliente", codCliente));
                        cmd.Parameters.Add(new SqlParameter("@cod_premio",
                            (int)ExchangeGrid.Rows[e.RowIndex].Cells["cod_premio"].Value));
                        cmd.Parameters.Add(new SqlParameter("@fecha_actual", Settings1.Default.CurrentDate));

                        cmd.ExecuteNonQuery();
                    }
                    puntos -= (int) costo;
                    PointsText.Text = puntos.ToString();
                    ExchangeGrid.Rows[e.RowIndex].Cells["Disponibles"].Value = stock - 1;
                }
            }
        }
    }
}
