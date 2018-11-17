using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class CreateClient : Form
    {
        public bool registroDeUsuario = false;
        public bool edicion = false;
        public Cliente cliente; 

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
        }

        private void DocumentTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocumentNroBox.Enabled = true;
        }


    }
}
