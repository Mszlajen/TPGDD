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
                PercentNumeric.Value = grado.comision;
                WeightNumeric.Value = grado.peso;
                SaveButton.Text = "Guardar";
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool todoBien = true;
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

            if (todoBien)
            {
                if (havingGrade)
                    grado.updateValues(NameText.Text, (byte)PercentNumeric.Value, (byte)WeightNumeric.Value).updateToDataBase(Program.DBconn);
                else
                    Grado.createInDataBase(Program.DBconn, NameText.Text, (byte)PercentNumeric.Value, (byte)WeightNumeric.Value);

                MessageBox.Show("Se guardo el grado.");
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
