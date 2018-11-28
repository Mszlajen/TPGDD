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
    public partial class AddCreditCard : Form
    {
        Card tarjeta; 
        public AddCreditCard(Card _tarjeta)
        {
            InitializeComponent();
            tarjeta = _tarjeta;
        }

        private void AddCreditCard_Load(object sender, EventArgs e)
        {
            CardNumText.Text = tarjeta.nro;
            SecurityCodeText.Text = tarjeta.codSeguridad;
            foreach (int year in Enumerable.Range(Settings1.Default.CurrentDate.Year, 12))
                YearBox.Items.Add(year);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool todoBien = true;
            if (MonthBox.SelectedIndex == -1 || YearBox.SelectedIndex == -1)
            {
                MessageBox.Show("La fecha de vencimiento no puede estar vacia");
                todoBien = false;
            }
            else if (Settings1.Default.CurrentDate.Year == int.Parse(YearBox.SelectedItem.ToString()) &&
                Settings1.Default.CurrentDate.Month > byte.Parse(MonthBox.SelectedItem.ToString()))
            {
                MessageBox.Show("La fecha de vencimiento no puede ser anterior a la fecha de hoy");
                todoBien = false;
            }
            if (String.IsNullOrWhiteSpace(CardNumText.Text))
            {
                MessageBox.Show("El numero de tarjeta no puede estar vacio");
                todoBien = false;
            }
            else if (!Program.checkIfOnlyNumbers(CardNumText.Text))
            {
                MessageBox.Show("El numero de tarjeta debe estar compuesto de numeros");
                todoBien = false;
            }
            if (String.IsNullOrWhiteSpace(SecurityCodeText.Text))
            {
                MessageBox.Show("El codigo de seguridad no puede estar vacio");
                todoBien = false;
            }
            else if (!Program.checkIfOnlyNumbers(SecurityCodeText.Text))
            {
                MessageBox.Show("El codigo de seguridad debe estar compuesto de numeros");
                todoBien = false;
            }
            else if (SecurityCodeText.Text.Length > 4)
            {
                MessageBox.Show("El codigo de seguridad no puede tener más de cuatro digitos");
                todoBien = false;
            }
            if (todoBien)
            {
                tarjeta.codSeguridad = SecurityCodeText.Text;
                tarjeta.nro = CardNumText.Text;
                tarjeta.month = byte.Parse(MonthBox.SelectedItem.ToString());
                tarjeta.year = int.Parse(YearBox.SelectedItem.ToString());
                DialogResult = DialogResult.OK;
            }
        }
    }
}
