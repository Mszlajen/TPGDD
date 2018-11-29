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
using System.Data.SqlClient;

namespace PalcoNet.Abm_Cliente
{
    public partial class CreateClient : Form
    {
        public bool registroDeUsuario = false;
        bool edicion = false;
        Cliente cliente;
        Card tarjeta = null;

        public CreateClient()
        {
            InitializeComponent();
        }
        
        public CreateClient(Cliente _cliente, bool registro = false)
        {
            InitializeComponent();
            if (registro)
                registroDeUsuario = true;
            else
                edicion = true;
            cliente = _cliente;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SurnameBox.Text = "";
            FirstNameBox.Text = "";
            DocumentTypeBox.SelectedIndex = -1;
            DocumentNroBox.Text = "";
            DocumentNroBox.Enabled = false;
            BirthDatePicker.Value = Settings1.Default.CurrentDate;
            CreationDatePicker.Value = Settings1.Default.CurrentDate;
            CUILBox.Text = "";
            MailBox.Text = "";
            PhoneBox.Text = "";
            AddressBox.Text = "";
            AddressNroBox.Text = "";
            FloorBox.Text = "";
            DeptBox.Text = "";
            LocalityBox.Text = "";
            PostalCodeBox.Text = "";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool todoBien = true;
            int aux;
            if (String.IsNullOrWhiteSpace(SurnameBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El apellido no puede estar vacio");
            }
            if (String.IsNullOrWhiteSpace(FirstNameBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El nombre no puede estar vacio");
            }
            if (String.IsNullOrWhiteSpace(DocumentNroBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El documento no puede estar vacio");
            }
            if (String.IsNullOrWhiteSpace(CUILBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El CUIL no puede estar vacio");
            }
            else if (!Cliente.checkCUIL(CUILBox.Text))
            {
                todoBien = false;
                MessageBox.Show("El CUIL no es valido");
            }
            if (BirthDatePicker.Value >= Settings1.Default.CurrentDate)
            {
                todoBien = false;
                MessageBox.Show("La fecha de nacimiento debe ser anterior a la fecha de hoy");
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
            if(!(String.IsNullOrWhiteSpace(PhoneBox.Text) || Program.checkIfOnlyNumbers(PhoneBox.Text)))
            {
                MessageBox.Show("El numero debe ser unicamente caracteres numericos");
                todoBien = false;
            }

            if (todoBien && (tarjeta != null || 
                MessageBox.Show("No ha cargado datos de la tarjeta, ¿desea continuar?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                if (edicion)
                {
                    byte yaExiste = Cliente.checkIfExistInDataBase(Program.DBconn, DocumentTypeBox.SelectedItem.ToString(), DocumentNroBox.Text, CUILBox.Text);
                    if (EnabledBox.Checked && (!cliente.habilitado || DocumentTypeBox.Text != cliente.tipoDocumento || DocumentNroBox.Text != cliente.nroDocumento) && yaExiste == 2)
                        MessageBox.Show("Ya hay un cliente registrado con ese documento");
                    else if (EnabledBox.Checked && (!cliente.habilitado || CUILBox.Text != cliente.CUIL) && yaExiste == 1)
                        MessageBox.Show("Ya hay un cliente registrado con ese CUIL");
                    else
                        cliente.UpdateValues(FirstNameBox.Text, SurnameBox.Text, DocumentTypeBox.Text, DocumentNroBox.Text, CUILBox.Text, MailBox.Text, PhoneBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text, DeptBox.Text, LocalityBox.Text, PostalCodeBox.Text, BirthDatePicker.Value, CreationDatePicker.Value, EnabledBox.Checked).UpdateToDataBase(Program.DBconn);
                }
                else
                {
                    switch (Cliente.checkIfExistInDataBase(Program.DBconn, DocumentTypeBox.SelectedItem.ToString(), DocumentNroBox.Text, CUILBox.Text))
                    {
                        case 0:
                            if (registroDeUsuario)
                            {
                                cliente.UpdateValues(FirstNameBox.Text, SurnameBox.Text, DocumentTypeBox.Text, DocumentNroBox.Text, CUILBox.Text, MailBox.Text, PhoneBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text, DeptBox.Text, LocalityBox.Text, PostalCodeBox.Text, BirthDatePicker.Value, CreationDatePicker.Value, EnabledBox.Checked);
                                DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                string nombreUsuario = FirstNameBox.Text.Substring(0, Math.Min(4, FirstNameBox.Text.Length)) + SurnameBox.Text.Substring(0, Math.Min(42, SurnameBox.Text.Length));
                                while (Usuario.checkIfExistInDataBase(Program.DBconn, nombreUsuario))
                                    nombreUsuario = FirstNameBox.Text.Substring(0, Math.Min(4, FirstNameBox.Text.Length)) + SurnameBox.Text.Substring(0, Math.Min(42, SurnameBox.Text.Length)) + Program.getRandomPassword(4);
                                string contrasenia = Program.getRandomPassword(5);
                                Cliente.CreateToDataBase(Program.DBconn, FirstNameBox.Text, SurnameBox.Text,
                                    DocumentTypeBox.Text, DocumentNroBox.Text, CUILBox.Text,
                                    MailBox.Text, PhoneBox.Text, AddressBox.Text, AddressNroBox.Text, FloorBox.Text,
                                    DeptBox.Text, LocalityBox.Text, PostalCodeBox.Text, BirthDatePicker.Value,
                                    CreationDatePicker.Value, nombreUsuario, Program.sha256(contrasenia), true, tarjeta);
                                MessageBox.Show("Usuario: " + nombreUsuario + " | Contraseña: " + contrasenia);
                            }
                            break;
                        case 1:
                            MessageBox.Show("Ya existe un cliente con ese CUIL");
                            break;
                        case 2:
                            MessageBox.Show("Ya existe un cliente con ese documento");
                            break;
                    }
                    
                }
            }
        }

        private void DocumentTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocumentNroBox.Enabled = true;
        }

        private void AddCardDataButton_Click(object sender, EventArgs e)
        {
            if (tarjeta == null)
                tarjeta = new Card();

            if (Program.openPopUpWindow(this, new AddCreditCard(tarjeta)) == DialogResult.Cancel)
                tarjeta = null;
        }

        private void CreateClient_Load(object sender, EventArgs e)
        {
            if (edicion)
            {
                SurnameBox.Text = cliente.apellido;
                FirstNameBox.Text = cliente.nombre;
                DocumentTypeBox.Text = cliente.tipoDocumento;
                DocumentNroBox.Enabled = true;
                DocumentNroBox.Text = cliente.nroDocumento;
                BirthDatePicker.Value = cliente.fechaNacimiento;
                if (CreationDatePicker.MinDate < cliente.fechaCreacion)
                    CreationDatePicker.Value = cliente.fechaCreacion;
                CUILBox.Text = cliente.CUIL;
                MailBox.Text = cliente.mail;
                PhoneBox.Text = cliente.telefono;
                AddressBox.Text = cliente.domicilio;
                AddressNroBox.Text = cliente.nroCalle;
                FloorBox.Text = cliente.piso;
                DeptBox.Text = cliente.dept;
                LocalityBox.Text = cliente.localidad;
                PostalCodeBox.Text = cliente.codPostal;
                EnabledBox.Visible = true;
                EnabledBox.Checked = cliente.habilitado;
                AddCardDataButton.Enabled = false;
            }
        }
    }
}
