using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class CreateCompany : Form
    {
        public bool registroDeUsuario = false;
        bool edicion = false;
        EmpresaEspectaculo empresa;

        public CreateCompany()
        {
            InitializeComponent();
        }

        public CreateCompany(EmpresaEspectaculo _empresa)
        {
            InitializeComponent();
            edicion = true;
            empresa = _empresa;
            SaveButton.Text = "Guardar";
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SocialReasonBox.Text = "";
            PhoneBox.Text = "";
            MailBox.Text = "";
            AddressBox.Text = "";
            AddressNroBox.Text = "";
            FloorBox.Text = "";
            DeptBox.Text = "";
            CityBox.Text = "";
            PostalCodeBox.Text = "";
            CUITBox.Text = "";
        }

        private void CreateCompany_Load(object sender, EventArgs e)
        {
            if (edicion)
            {
                SocialReasonBox.Text = empresa.nombre;
                PhoneBox.Text = empresa.telefono;
                MailBox.Text = empresa.mail;
                AddressBox.Text = empresa.domicilio;
                AddressNroBox.Text = empresa.altura;
                FloorBox.Text = empresa.piso;
                DeptBox.Text = empresa.departamento;
                CityBox.Text = empresa.ciudad;
                PostalCodeBox.Text = empresa.codigoPostal;
                CUITBox.Text = empresa.CUIT;
                EnabledBox.Enabled = true;
                EnabledBox.Checked = empresa.habilitado;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool todoBien = true;
            if(String.IsNullOrWhiteSpace(SocialReasonBox.Text))
            {
                todoBien = false;
                MessageBox.Show("La razon social no puede estar vacia");
            }
            if (String.IsNullOrWhiteSpace(AddressBox.Text) || String.IsNullOrWhiteSpace(AddressNroBox.Text))
            {
                todoBien = false;
                MessageBox.Show("La direccion no puede estar vacia");
            }
            if (String.IsNullOrWhiteSpace(PostalCodeBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El codigo postal no puede estar vacio");
            }
            if (String.IsNullOrWhiteSpace(CUITBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El CUIT es un campo obligatorio");
            }
            else if (!EmpresaEspectaculo.CheckCUIT(CUITBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El CUIT ingresado no es valido");
            }

            if (todoBien)
            {
                if (edicion)
                    empresa.updateValues(SocialReasonBox.Text, PhoneBox.Text, MailBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text, DeptBox.Text, CityBox.Text, PostalCodeBox.Text, CUITBox.Text, EnabledBox.Checked).UpdateToDataBase(Program.DBconn);
                else if (registroDeUsuario)
                { }
                else
                {
                    //Falta comprobacion de unicidad
                    Usuario nuevoUsuario = Usuario.CreateToDataBase(Program.DBconn, SocialReasonBox.Text.Substring(0, 50), Program.getRandomPassword(10));
                    EmpresaEspectaculo.CreateToDataBase(Program.DBconn, SocialReasonBox.Text, PhoneBox.Text, MailBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text, DeptBox.Text, CityBox.Text, PostalCodeBox.Text, CUITBox.Text, nuevoUsuario.codUsuario);
                    MessageBox.Show("Usuario: " + nuevoUsuario.usuario + " | Contraseña: " + nuevoUsuario.contrasenia);
                }
            }
        }
    }
}
