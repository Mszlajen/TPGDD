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
    public partial class changePassword : Form
    {
        private int codUsuario;
        public changePassword(int _codUsuario)
        {
            codUsuario = _codUsuario;
            InitializeComponent();
        }

        private void ShowPasswordBox_CheckStateChanged(object sender, EventArgs e)
        {
            NewPasswordText.PasswordChar = ShowPasswordBox.Checked ? '\0' : '*';
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(NewPasswordText.Text))
                MessageBox.Show("La contraseña no puede estar vacia");
            else
            {
                using (SqlCommand cmd = new SqlCommand("cheshire_jack.cambiarContrasenia", Program.DBconn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@codUsuario", codUsuario));
                    cmd.Parameters.Add(new SqlParameter("@nuevaContrasenia", Program.sha256(NewPasswordText.Text)));

                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Cambio realizado");
                this.Close();
            }
        }
    }
}
