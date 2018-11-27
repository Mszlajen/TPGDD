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

namespace PalcoNet.Abm_Cliente
{
    public partial class CreateClient : Form
    {
        bool registroDeUsuario = false;
        bool edicion = false;
        Cliente cliente;
        Card tarjeta;
        bool tengoTarjeta = false;

        public CreateClient()
        {
            InitializeComponent();
        }
        
        public CreateClient(Cliente _cliente)
        {
            InitializeComponent();
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

            if (todoBien)
            {

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

            if (Program.openPopUpWindow(this, new AddCreditCard(tarjeta)) == DialogResult.OK)
                tengoTarjeta = true;
        }


    }
}
