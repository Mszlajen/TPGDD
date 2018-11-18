using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                EnabledBox.Visible = true;
                EnabledBox.Checked = empresa.habilitado;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool todoBien = true;
            int aux;
            if(String.IsNullOrWhiteSpace(SocialReasonBox.Text))
            {
                todoBien = false;
                MessageBox.Show("La razon social no puede estar vacia");
            }
            if (todoBien && (String.IsNullOrWhiteSpace(AddressBox.Text) || String.IsNullOrWhiteSpace(AddressNroBox.Text)))
            {
                todoBien = false;
                MessageBox.Show("La direccion no puede estar vacia");
            }
            else if (todoBien && !int.TryParse(AddressNroBox.Text, out aux))
            {
                todoBien = false;
                MessageBox.Show("La altura debe ser un numero");
            }
            if (todoBien && String.IsNullOrWhiteSpace(PostalCodeBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El codigo postal no puede estar vacio");
            }
            if (todoBien && String.IsNullOrWhiteSpace(CUITBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El CUIT es un campo obligatorio");
            }
            else if (todoBien && !EmpresaEspectaculo.CheckCUIT(CUITBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El CUIT ingresado no es valido");
            }
            if (todoBien && String.IsNullOrWhiteSpace(MailBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El mail es un campo obligatorio");
            }
            else if (todoBien && !Regex.IsMatch(MailBox.Text, @"^.+@.+\.\w+"))
            {
                todoBien = false;
                MessageBox.Show("El mail no es valido");
            }

            if (todoBien)
            {
                if (edicion)
                {
                    if (empresa.nombre != SocialReasonBox.Text && EmpresaEspectaculo.checkIfExistInDataBase(Program.DBconn, SocialReasonBox.Text, CUITBox.Text) == 2)
                        MessageBox.Show("Ya hay una empresa registrada con esa razon social");
                    else if (empresa.CUIT != CUITBox.Text && EmpresaEspectaculo.checkIfExistInDataBase(Program.DBconn, SocialReasonBox.Text, CUITBox.Text) == 1)
                        MessageBox.Show("Ya hay una empresa registrada con ese CUIT");
                    else
                        empresa.updateValues(SocialReasonBox.Text, PhoneBox.Text, MailBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text, DeptBox.Text, CityBox.Text, PostalCodeBox.Text, CUITBox.Text, EnabledBox.Checked).UpdateToDataBase(Program.DBconn);
                }
                else if (registroDeUsuario)
                { }
                else
                {
                    switch(EmpresaEspectaculo.checkIfExistInDataBase(Program.DBconn, SocialReasonBox.Text, CUITBox.Text))
                    {
                        case 0:
                            Usuario nuevoUsuario = Usuario.CreateToDataBase(Program.DBconn, SocialReasonBox.Text.Substring(0, Math.Min(SocialReasonBox.Text.Length, 50)), Program.getRandomPassword(5));
                            EmpresaEspectaculo.CreateToDataBase(Program.DBconn, SocialReasonBox.Text, PhoneBox.Text, MailBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text, DeptBox.Text, CityBox.Text, PostalCodeBox.Text, CUITBox.Text, nuevoUsuario.codUsuario);
                            MessageBox.Show("Usuario: " + nuevoUsuario.usuario + " | Contraseña: " + nuevoUsuario.contrasenia);
                            break;
                        case 1:
                            MessageBox.Show("Ya existe una empresa con ese CUIT");
                            break;
                        case 2:
                            MessageBox.Show("Ya existe una empresa con esa razon social");
                            break;
                    }
                }
            }
        }
    }
}
