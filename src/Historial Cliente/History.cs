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

namespace PalcoNet.Historial_Cliente
{
    public partial class History : Form
    {
        DataTable pagina = new DataTable();
        int codUsuario, codCliente = 0, paginaActual = 1, cantidadPaginas = 1;
        const int tamPagina = 20;
        public History(int _codUsuario)
        {
            InitializeComponent();
            codUsuario = _codUsuario;
        }

        private void cargarPagina(int numeroPagina)
        {
            pagina.Clear();
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.obtenerPaginaDeHistorial", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codCliente", codCliente));
                cmd.Parameters.Add(new SqlParameter("@nroPagina", numeroPagina));
                cmd.Parameters.Add(new SqlParameter("@tamPagina", tamPagina));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(pagina);
                adapter.Dispose();
            }
            PageNumText.Text = numeroPagina.ToString();
            paginaActual = numeroPagina;
        }

        private void cargarUltimaPagina()
        {
            pagina.Clear();
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.obtenerUltimaPaginaDeHistorial", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codCliente", codCliente));
                cmd.Parameters.Add(new SqlParameter("@tamPagina", tamPagina));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(pagina);
                adapter.Dispose();
            }
            PageNumText.Text = cantidadPaginas.ToString();
            paginaActual = cantidadPaginas;
        }

        private void History_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT cod_cliente, cheshire_jack.obtenerTotalDePaginasDeHistorial(cod_cliente, @tamPagina) FROM cheshire_jack.clientes WHERE cod_usuario = @cod_usuario AND habilitado = 1";
            SqlCommand cmd = new SqlCommand(queryString, Program.DBconn);
            cmd.Parameters.Add(new SqlParameter("@cod_usuario", codUsuario));
            cmd.Parameters.Add(new SqlParameter("@tamPagina", tamPagina));
            SqlDataReader resultadoQuery = cmd.ExecuteReader();
            if (!resultadoQuery.Read())
                MessageBox.Show("Este usuario no tiene informacion de cliente y no podra terminar las operaciones");
            else
            {
                codCliente = resultadoQuery.GetInt32(0);
                cantidadPaginas = resultadoQuery.GetInt32(1);
            }
            resultadoQuery.Close();
            cmd.Dispose();

            cargarPagina(paginaActual);
            HistoryGrid.DataSource = pagina;
            HistoryGrid.Sort(HistoryGrid.Columns["Fecha Compra"], ListSortDirection.Ascending);
        }

        private void FirstButton_Click(object sender, EventArgs e)
        {
            cargarPagina(1);
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
                cargarPagina(paginaActual - 1);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (cantidadPaginas - 1 > paginaActual)
                cargarPagina(paginaActual + 1);
            else if (cantidadPaginas - 1 == paginaActual)
                cargarUltimaPagina();
        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            cargarUltimaPagina();
        }
    }
}
