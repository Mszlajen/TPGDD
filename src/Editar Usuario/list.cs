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

namespace PalcoNet.Editar_Usuario
{
    public partial class list : Form
    {
        DataTable usuarios = new DataTable();
        public list()
        {
            InitializeComponent();
        }

        private void list_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT cod_usuario, nombre_usuario Usuario, habilitado Habilitado FROM cheshire_jack.usuarios WHERE cod_usuario = 0";
            using (SqlCommand cmd = new SqlCommand(queryString, Program.DBconn))
                usuarios.Load(cmd.ExecuteReader());
            UsersGrid.DataSource = usuarios;
            UsersGrid.Columns["cod_usuario"].Visible = false;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            usuarios.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                StringBuilder queryString = new StringBuilder("SELECT cod_usuario, nombre_usuario Usuario, habilitado Habilitado FROM cheshire_jack.usuarios WHERE 1=1 ");
                if (!String.IsNullOrWhiteSpace(UsernameText.Text))
                {
                    cmd.Parameters.Add(new SqlParameter("@nombreUsuario", "%" + UsernameText.Text+ "%"));
                    queryString.Append("AND nombre_usuario LIKE @nombreUsuario ");
                }
                if (AvabilityCheck.CheckState == CheckState.Checked || AvabilityCheck.CheckState == CheckState.Unchecked)
                {
                    cmd.Parameters.AddWithValue("@habilitado", AvabilityCheck.Checked);
                    queryString.Append("AND habilitado = @habilitado ");
                }

                cmd.CommandText = queryString.ToString();
                cmd.Connection = Program.DBconn;

                usuarios.Load(cmd.ExecuteReader());
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            usuarios.Clear();
            UsernameText.Text = "";
            AvabilityCheck.CheckState = CheckState.Indeterminate;
        }

        private void UsersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                Program.openPopUpWindow(this, new changePassword((int)usuarios.Rows[e.RowIndex]["cod_usuario"], "Ingrese la nueva contraseña"));
            else if (e.ColumnIndex == UsersGrid.Columns["Habilitado"].Index)
            {
                usuarios.Rows[e.RowIndex]["Habilitado"] = !(bool)usuarios.Rows[e.RowIndex]["Habilitado"];
                using (SqlCommand cmd = new SqlCommand("UPDATE cheshire_jack.usuarios SET habilitado = @habilitado WHERE cod_usuario = @codUsuario", Program.DBconn))
                {
                    cmd.Parameters.Add(new SqlParameter("@habilitado", (bool)usuarios.Rows[e.RowIndex]["Habilitado"]));
                    cmd.Parameters.Add(new SqlParameter("@codUsuario", (int)usuarios.Rows[e.RowIndex]["cod_usuario"]));
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
