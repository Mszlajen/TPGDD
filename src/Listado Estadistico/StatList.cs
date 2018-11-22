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
            resultado.Clear();
            using(SqlCommand cmd = new SqlCommand())
            {
                switch (ListBox.SelectedIndex)
                {
                    case 0:
                        cmd.CommandText = "cheshire_jack.listadoLocalidadesNoVendidas";
                        break;
                    case 1: //Puntos vencidos
                        cmd.CommandText = "cheshire_jack.listadoPuntosVencidos";
                        break;
                    case 2:
                        cmd.CommandText = "cheshire_jack.listadoMayoresCompradores";
                        break;
                }
                cmd.Parameters.Add(new SqlParameter("@anio", YearBox.SelectedItem));
                cmd.Parameters.Add(new SqlParameter("@trimestre", TrimesterBox.SelectedItem));
                cmd.Connection = Program.DBconn;
                cmd.CommandType = CommandType.StoredProcedure;
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
