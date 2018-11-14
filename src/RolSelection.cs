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

namespace PalcoNet
{
    public partial class RolSelection : Form
    {
        private int codUsuario;
        private DataTable roles = new DataTable();
        public RolSelection(int _codUsuario)
        {
            InitializeComponent();
            
            codUsuario = _codUsuario;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (RolesBox.SelectedIndex != -1)
            {
                FunctionSelection nextWindow = new FunctionSelection(codUsuario, (int) roles.Rows[RolesBox.SelectedIndex]["cod_rol"]);
                this.Hide();
                nextWindow.ShowDialog();
            }
        }

        private void RolSelection_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT cod_rol, descripcion FROM cheshire_jack.roles WHERE cod_rol IN (SELECT cod_rol FROM cheshire_jack.usuariosXRoles WHERE cod_usuario = @codUsuario)";
            using (SqlCommand getRoles = new SqlCommand(queryString, Program.DBconn))
            {
                getRoles.Parameters.Add(new SqlParameter("@codUsuario", codUsuario));

                roles.Load(getRoles.ExecuteReader());

                foreach (DataRow row in roles.Rows)
                {
                    RolesBox.Items.Add(row["descripcion"]);
                }
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RolSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                Program.closeProgram();
        }

        private void RolSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
                Program.closeProgram();
        }
    }
}
