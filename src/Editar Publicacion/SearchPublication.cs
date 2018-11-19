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

namespace PalcoNet.Editar_Publicacion
{
    public partial class SearchPublication : Form
    {
        DataTable estados = new DataTable(), publicaciones = new DataTable();
        int codUsuario, codEmpresa = 0;
        public SearchPublication(int _codUsuario)
        {
            InitializeComponent();
            codUsuario = _codUsuario;
        }

        private void cambiarEstado(string codPublicacion, int nuevoEstado)
        {
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.modificarEstado", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codPublicacion", codPublicacion));
                cmd.Parameters.Add(new SqlParameter("@estado", nuevoEstado));

                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                switch ((int)publicaciones.Rows[e.RowIndex]["cod_estado"])
                {
                    case 1:
                        break;
                    case 2:
                        if (MessageBox.Show("¿Desea finalizar la publicación?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            cambiarEstado(publicaciones.Rows[e.RowIndex]["cod_publicacion"].ToString(), 3);
                        break;
                    default:
                        MessageBox.Show("Esta publicación no puede ser editada");
                        break;
                }
            }
        }

        private void SearchPublication_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM cheshire_jack.vw_estados", Program.DBconn))
            {
                estados.Load(cmd.ExecuteReader());

                cmd.CommandText = "cheshire_jack.publicacionesDe";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codEmpresa", codEmpresa));
                cmd.Parameters.Add(new SqlParameter("@estado", DBNull.Value));
                publicaciones.Load(cmd.ExecuteReader());
                cmd.Parameters.Clear();

                cmd.CommandText = "SELECT cod_empresa FROM cheshire_jack.empresas WHERE cod_usuario = @codUsuario";
                cmd.Parameters.Add(new SqlParameter("@codUsuario", codUsuario));
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    codEmpresa = reader.GetInt32(0);
                else
                    MessageBox.Show("Este usuario no tiene informacion de empresa y no podra terminar las operaciones");
                reader.Close();
            }
            estados.PrimaryKey = new DataColumn[] { estados.Columns["cod_estado"] };

            PublicationsGrid.DataSource = publicaciones;
            PublicationsGrid.Columns["cod_publicacion"].Visible = false;
            PublicationsGrid.Columns["cod_grado"].Visible = false;
            PublicationsGrid.Columns["cod_rubro"].Visible = false;
            PublicationsGrid.Columns["cod_estado"].Visible = false;

            foreach (DataRow row in estados.Rows)
                StateBox.Items.Add(row["nombre"]);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            publicaciones.Clear();
            StateBox.SelectedIndex = -1;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            publicaciones.Clear();
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.publicacionesDe", Program.DBconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codEmpresa", codEmpresa));
                if(StateBox.SelectedIndex == -1)
                    cmd.Parameters.Add(new SqlParameter("@estado", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@estado", (int)estados.Rows[StateBox.SelectedIndex]["cod_estado"]));

                publicaciones.Load(cmd.ExecuteReader());
            }
        }
    }
}
