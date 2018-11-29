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
    public partial class SearchPublication : Form
    {
        DataTable pagina = new DataTable(), rubros = new DataTable();
        bool usarDesde = false, usarHasta = false;
        DateTime desde, hasta;
        int codRubro = 0;
        string descripcion = "";

        int paginaActual, cantidadPaginas;

        int codUsuario, codCliente = 0;
        public SearchPublication(int _codUsuario)
        {
            InitializeComponent();
            codUsuario = _codUsuario;
        }

        private void SearchPublication_Load(object sender, EventArgs e)
        {

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM cheshire_jack.vw_rubros", Program.DBconn))
            {
                rubros.Load(cmd.ExecuteReader());

                foreach (DataRow row in rubros.Rows)
                    TagBox.Items.Add(row["Nombre"]);

                cmd.CommandText = "SELECT cod_cliente FROM cheshire_jack.clientes WHERE cod_usuario = @cod_usuario AND habilitado = 1";
             
                cmd.Parameters.Add(new SqlParameter("@cod_usuario", codUsuario));
                cmd.Parameters.Add(new SqlParameter("@tamPagina", Settings1.Default.PageSize));
                SqlDataReader resultadoQuery = cmd.ExecuteReader();
                if (!resultadoQuery.Read())
                    MessageBox.Show("Este usuario no tiene informacion de cliente y no podra terminar las operaciones");
                else
                    codCliente = resultadoQuery.GetInt32(0);
                resultadoQuery.Dispose();

                cargarPagina(0);
                PageGrid.DataSource = pagina;
                PageGrid.Columns["cod_publicacion"].Visible = false;
                PageGrid.Columns["cod_grado"].Visible = false;
                PageGrid.Columns["peso"].Visible = false;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ToCheck.Checked = false;
            FromCheck.Checked = false;
            FromPicker.Enabled = false;
            ToPicker.Enabled = false;
            DescriptionBox.Text = "";
            TagBox.SelectedIndex = -1;
            pagina.Clear();
            NumLabel.Text = "0";
            FirstButton.Enabled = false;
            PreviousButton.Enabled = false;
            NextButton.Enabled = false;
            LastButton.Enabled = false;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            usarDesde = FromCheck.Checked;
            desde = FromPicker.Value;
            usarHasta = ToCheck.Checked;
            hasta = ToPicker.Value;
            descripcion = DescriptionBox.Text;
            FirstButton.Enabled = true;
            PreviousButton.Enabled = true;
            NextButton.Enabled = true;
            LastButton.Enabled = true;
            codRubro = TagBox.SelectedIndex != -1 ? (int)rubros.Rows[TagBox.SelectedIndex]["cod_rubro"] : 0;
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.obtenerTotalDePaginasCompras", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cargarParametros(cmd);
                SqlParameter ret = new SqlParameter("@ret", DbType.Int64);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.ExecuteNonQuery();

                cantidadPaginas = (int)ret.Value;
            }
            paginaActual = 1;
            cargarPagina(1);
        }
        private void cargarParametros(SqlCommand cmd)
        {
            cmd.Parameters.Add(new SqlParameter("@fechaHoy", Settings1.Default.CurrentDate));
            cmd.Parameters.Add(new SqlParameter("@tamPagina", Settings1.Default.PageSize));
            if (codRubro == 0)
                cmd.Parameters.Add(new SqlParameter("@cod_rubro", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@cod_rubro", codRubro));
            if (String.IsNullOrWhiteSpace(descripcion))
                cmd.Parameters.Add(new SqlParameter("@descripcion", DBNull.Value));
            else
                cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
            if (usarDesde)
                cmd.Parameters.Add(new SqlParameter("@desde", desde));
            else
                cmd.Parameters.Add(new SqlParameter("@desde", DBNull.Value));
            if (usarHasta)
                cmd.Parameters.Add(new SqlParameter("@hasta", hasta));
            else
                cmd.Parameters.Add(new SqlParameter("@hasta", DBNull.Value));
        }

        private void cargarPagina(int numeroPagina)
        {
            pagina.Clear();
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.obtenerPaginaDeCompras", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nroPagina", numeroPagina));
                cargarParametros(cmd);
                
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(pagina);
                adapter.Dispose();
            }
            NumLabel.Text = numeroPagina.ToString();
            paginaActual = numeroPagina;
        }

        private void cargarUltimaPagina()
        {
            pagina.Clear();
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.obtenerUltimaPaginaDeCompras", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cargarParametros(cmd);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(pagina);
                adapter.Dispose();
            }
            NumLabel.Text = cantidadPaginas.ToString();
            paginaActual = cantidadPaginas;
        }

        private void FromCheck_CheckedChanged(object sender, EventArgs e)
        {
            FromPicker.Enabled = FromCheck.Checked;
        }

        private void ToCheck_CheckedChanged(object sender, EventArgs e)
        {
            ToPicker.Enabled = ToCheck.Checked;
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

        private void PageGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                Program.openPopUpWindow(this, new Buy(codCliente, (decimal)pagina.Rows[e.RowIndex]["cod_publicacion"]));
            }
        }
    }
}
