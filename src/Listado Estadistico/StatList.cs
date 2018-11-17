using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PalcoNet.Listado_Estadistico
{
    public partial class StatList : Form
    {
        DataTable resultado = new DataTable();
        public StatList()
        {
            InitializeComponent();
        }

        private void YearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YearBox.SelectedIndex != -1)
                TrimesterBox.Enabled = true;
        }

        private void TrimesterBox_DropDownClosed(object sender, EventArgs e)
        {
            if(YearBox.SelectedIndex != -1)
                ListBox.Enabled = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            YearBox.SelectedIndex = -1;
            TrimesterBox.SelectedIndex = -1;
            TrimesterBox.Enabled = false;
            ListBox.SelectedIndex = -1;
            ListBox.Enabled = false;
            ListButton.Enabled = false;
            resultado.Clear();
        }

        private void StatList_Load(object sender, EventArgs e)
        {
            ResultGrid.DataSource = resultado;
            foreach(int year in Enumerable.Range(2005, 15))
                YearBox.Items.Add(year);
        }

        private void ListButton_Click(object sender, EventArgs e)
        {
            string queryString = "SELECT TOP 5 ";
            using(SqlCommand cmd = new SqlCommand())
            {
                switch (ListBox.SelectedIndex)
                {
                    case 1: //Puntos vencidos
                        queryString += "nombre AS Nombre, apellido AS Apellido, " +
                                        "tipo_documento AS 'Tipo de documento', " +
                                        "nro_documento AS 'Nro de Documento', CUIL, " + 
                                        "telefono AS Telefono, mail AS 'E-Mail' " +
                                        "FROM cheshire_jack.puntos p JOIN cheshire_jack.clientes c " +
                                        "ON p.cod_cliente = c.cod_cliente " +
                                        "WHERE p.anio_vencimiento = @anio ORDER BY p.cantidad";
                        cmd.Parameters.Add(new SqlParameter("@anio", YearBox.SelectedItem));
                        break;
                }
                cmd.Connection = Program.DBconn;
                cmd.CommandText = queryString;
                resultado.Clear();
                resultado.Load(cmd.ExecuteReader());
            }
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YearBox.SelectedIndex != -1)
                ListButton.Enabled = true;
        }
    }
}
