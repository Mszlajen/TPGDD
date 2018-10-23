using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Boolean fieldsFilled;
            if (fieldsFilled = String.IsNullOrEmpty(UsernameText.Text))
                MessageBox.Show("El campo usuario no puede estar vacio");
            if (fieldsFilled = String.IsNullOrEmpty(PasswordText.Text))
                MessageBox.Show("El campo contraseña no puede estar vacio");
            if (!fieldsFilled)
            {

            }
        }
    }
}
