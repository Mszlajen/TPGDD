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

        public CreateCompany(EmpresaEspectaculo _empresa, bool registro = false)
        {
            InitializeComponent();
            if (registro)
                registroDeUsuario = true;
            else
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
            if (String.IsNullOrWhiteSpace(AddressBox.Text) || String.IsNullOrWhiteSpace(AddressNroBox.Text))
            {
                todoBien = false;
                MessageBox.Show("La direccion no puede estar vacia");
            }
            else if (!int.TryParse(AddressNroBox.Text, out aux))
            {
                todoBien = false;
                MessageBox.Show("La altura debe ser un numero");
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
            if (String.IsNullOrWhiteSpace(MailBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El mail es un campo obligatorio");
            }
            else if (!Regex.IsMatch(MailBox.Text, @"^.+@.+\.\w+"))
            {
                todoBien = false;
                MessageBox.Show("El mail no es valido");
            }
            if(!(String.IsNullOrWhiteSpace(PhoneBox.Text) || Program.checkIfOnlyNumbers(PhoneBox.Text)))
            {
                todoBien = false;
                MessageBox.Show("El telefono solo pueden ser numeros");
            }

            if (todoBien)
            {
                if (edicion)
                {
                    byte yaExiste = EmpresaEspectaculo.checkIfExistInDataBase(Program.DBconn, SocialReasonBox.Text, CUITBox.Text);
                    if (EnabledBox.Checked && (!empresa.habilitado || empresa.nombre != SocialReasonBox.Text) && yaExiste == 2)
                        MessageBox.Show("Ya hay una empresa registrada con esa razon social");
                    else if (EnabledBox.Checked && (!empresa.habilitado || empresa.CUIT != CUITBox.Text) && yaExiste == 1)
                        MessageBox.Show("Ya hay una empresa registrada con ese CUIT");
                    else
                        empresa.updateValues(SocialReasonBox.Text, PhoneBox.Text, MailBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text, DeptBox.Text, CityBox.Text, PostalCodeBox.Text, CUITBox.Text, EnabledBox.Checked).UpdateToDataBase(Program.DBconn);
                }
                else
                {
                    switch(EmpresaEspectaculo.checkIfExistInDataBase(Program.DBconn, SocialReasonBox.Text, CUITBox.Text))
                    {
                        case 0:
                            if (registroDeUsuario)
                            {
                                empresa.updateValues(SocialReasonBox.Text, PhoneBox.Text, MailBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text, DeptBox.Text, CityBox.Text, PostalCodeBox.Text, CUITBox.Text, EnabledBox.Checked);
                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                string usuario = SocialReasonBox.Text.Substring(0, Math.Min(SocialReasonBox.Text.Length, 30)) + Program.getRandomPassword(10), contrasenia = Program.getRandomPassword(5);
                                EmpresaEspectaculo.CreateToDataBase(Program.DBconn, SocialReasonBox.Text, PhoneBox.Text, MailBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text, DeptBox.Text, CityBox.Text, PostalCodeBox.Text, CUITBox.Text, usuario, Program.sha256(contrasenia), true);
                                MessageBox.Show("Usuario: " + usuario + " | Contraseña: " + contrasenia);
                            }
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
