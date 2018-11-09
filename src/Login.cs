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
using System.Security.Cryptography;

namespace PalcoNet
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registro_de_Usuario.SignUp().ShowDialog();
            this.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Boolean fieldsEmpty = false;
            if (fieldsEmpty = String.IsNullOrEmpty(UsernameText.Text))
                MessageBox.Show("El campo usuario no puede estar vacio");
            if (fieldsEmpty = String.IsNullOrEmpty(PasswordText.Text))
                MessageBox.Show("El campo contraseña no puede estar vacio");
            if (!fieldsEmpty)
            {
                using (SqlCommand sp_login = new SqlCommand("cheshire_jack.IniciarSesion", Program.DBconn))
                {
                    sp_login.CommandType = CommandType.StoredProcedure;
                    sp_login.Parameters.Add(new SqlParameter("@usuario", UsernameText.Text));
                    sp_login.Parameters.Add(new SqlParameter("@contrasenia", sha256(PasswordText.Text)));
                    SqlParameter parCodUsuario = new SqlParameter("@codUsuario", DbType.Int32);
                    parCodUsuario.Direction = ParameterDirection.Output;
                    sp_login.Parameters.Add(parCodUsuario);
                    SqlParameter retorno = new SqlParameter("@returnVal", DbType.Int16);
                    retorno.Direction = ParameterDirection.ReturnValue;
                    sp_login.Parameters.Add(retorno);

                    sp_login.ExecuteNonQuery();

                    switch ((int) retorno.Value)
                    {
                        case 0:
                            MessageBox.Show("El usuario ingresado no existe");
                            break;
                        case 1:
                            MessageBox.Show("La contraseña ingresada es invalida");
                            break;
                        case 2:
                            MessageBox.Show("Su usuario se encuentra deshabilitado");
                            break;
                        case 3:
                            MessageBox.Show("Su usuario fue bloqueado por exceso de intentos fallidos");
                            break;
                        case 4:
                            MessageBox.Show("La contraseña automatica ya no tiene validez");
                            break;
                        case 5:
                            MessageBox.Show("Se inicio sesion correctamente. Usuario:" + parCodUsuario.Value.ToString());
                            break;
                        case 6:
                            MessageBox.Show("Hay que cambiar la contraseña");
                            break;
                    }

                }

            }
        }

        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                if(theByte != 0)
                    hash.Append(theByte.ToString());
            }
            return hash.ToString();
        }
    }
}
