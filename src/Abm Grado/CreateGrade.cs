using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class CreateGrade : Form
    {
        bool havingGrade = false;
        Grado grado;
        const int maximoCaracteresNombre = 5;

        public CreateGrade()
        {
            InitializeComponent();
        }

        public CreateGrade(Grado _grado)
        {
            InitializeComponent();
            havingGrade = true;
            grado = _grado;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CreateGrade_Load(object sender, EventArgs e)
        {
            if (havingGrade)
            {
                NameText.Text = grado.nombre;
                PercentText.Text = grado.comision.ToString();
                WeightText.Text = grado.peso.ToString();
                SaveButton.Text = "Guardar";
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool todoBien = true;
            byte porcentaje = 0, peso = 0;
            if (NameText.Text.Length > maximoCaracteresNombre)
            {
                todoBien = false;
                MessageBox.Show("El nombre no puede superar los " + maximoCaracteresNombre + "caracteres.");
            }
            else if (String.IsNullOrWhiteSpace(NameText.Text))
            {
                todoBien = false;
                MessageBox.Show("El nombre no puede estar vacio.");
            }
            if (String.IsNullOrWhiteSpace(PercentText.Text))
            {
                todoBien = false;
                MessageBox.Show("El porcentaje no puede estar vacio");
            }
            else if (!byte.TryParse(PercentText.Text, out porcentaje) || !(0 <= porcentaje && porcentaje <= 100))
            {
                todoBien = false;
                MessageBox.Show("El porcentaje debe ser un numero entre 0 y 100");
            }
            if (String.IsNullOrWhiteSpace(WeightText.Text))
            {
                todoBien = false;
                MessageBox.Show("El porcentaje no puede estar vacio");
            }
            else if (!byte.TryParse(WeightText.Text, out peso) || !(0 <= peso && peso <= 255))
            {
                todoBien = false;
                MessageBox.Show("El peso debe ser un numero entre 0 y 255");
            }

            if (todoBien)
            {
                if (havingGrade)
                    grado.updateValues(NameText.Text, porcentaje, peso).updateToDataBase(Program.DBconn);
                else
                    Grado.createInDataBase(Program.DBconn, NameText.Text, porcentaje, peso);

                MessageBox.Show("Se guardo el grado.");
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
