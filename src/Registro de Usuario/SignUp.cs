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

namespace PalcoNet.Registro_de_Usuario
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            fillRoleBox();
        }

        private void fillRoleBox()
        {
            SqlCommand getRoles = new SqlCommand("SELECT cod_rol, descripcion FROM cheshire_jack.roles WHERE habilitado = 1 AND registrable = 1", Program.DBconn);
            SqlDataReader roles = getRoles.ExecuteReader();
            while (roles.Read())
                RoleBox.Items.Add(roles[1]);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            UsernameBox.Text            = "";
            PasswordBox.Text            = "";
            RoleBox.SelectedItem        = null;
            DataCompletedBox.Checked    = false;
            DataCompletedBox.Enabled    = false;
            CompleteDataButton.Enabled  = false;
            //Limpiar datos del usuario
        }

        private void RoleBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataCompletedBox.Enabled = true;
            CompleteDataButton.Enabled = true;
        }
    }
}
