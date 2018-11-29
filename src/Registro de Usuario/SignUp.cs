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
        private static SqlCommand getRoles = new SqlCommand("SELECT cod_rol, descripcion FROM cheshire_jack.roles WHERE habilitado = 1 AND registrable = 1", Program.DBconn);
        private DatosUsuario datos;

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
            SqlDataReader roles = getRoles.ExecuteReader();
            while (roles.Read())
                RoleBox.Items.Add(roles[1]);
            roles.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            UsernameBox.Text            = "";
            PasswordBox.Text            = "";
            RoleBox.SelectedItem        = null;
            DataCompletedBox.Checked    = false;
            DataCompletedBox.Enabled    = false;
            CompleteDataButton.Enabled  = false;
        }

        private void RoleBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataCompletedBox.Enabled = true;
            CompleteDataButton.Enabled = true;
        }

        private void CompleteDataButton_Click(object sender, EventArgs e)
        {
            if (RoleBox.Text == "Empresa de Espectaculo")
            {
                EmpresaEspectaculo empr = new EmpresaEspectaculo();
                if (Program.openPopUpWindow(this, new PalcoNet.Abm_Empresa_Espectaculo.CreateCompany(empr, true)) == DialogResult.OK)
                {
                    DataCompletedBox.Checked = true;
                    datos = empr;
                }
            }
            else if(RoleBox.Text == "Cliente")
            {
                Cliente client = new Cliente();
                if (Program.openPopUpWindow(this, new PalcoNet.Abm_Cliente.CreateClient(client, true)) == DialogResult.OK)
                {
                    DataCompletedBox.Checked = true;
                    datos = client;
                }
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            bool todoBien = true;
            if (String.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El nombre de usuario no puede estar vacio");
            }
            else if (UsernameBox.Text.Length > 50)
            {
                todoBien = false;
                MessageBox.Show("El nombre de usuario no puede exceder los 50 caracteres");
            }
            if (String.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                todoBien = false;
                MessageBox.Show("La contraseña no puede estar vacia");
            }
            if (!DataCompletedBox.Checked)
            {
                todoBien = false;
                MessageBox.Show("Debe completar los datos");
            }

            if (todoBien)
            {
                datos.CreateToDataBase(Program.DBconn, UsernameBox.Text, Program.sha256(PasswordBox.Text), false);
                MessageBox.Show("Usuario creado con exito");
                DialogResult = DialogResult.OK;
            }

        }

        private void ShowPasswordBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordBox.PasswordChar = ShowPasswordBox.Checked ? '\0' : '*';
        }
    }
}

public abstract class DatosUsuario
{
    abstract public DatosUsuario CreateToDataBase(SqlConnection DB, string nombreUsuario, string contrasenia, bool automatico);
}