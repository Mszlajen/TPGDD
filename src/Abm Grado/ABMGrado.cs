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

namespace PalcoNet.Abm_Grado
{
    public partial class ABMGrado : Form
    {
        DataTable grados = new DataTable();
        public ABMGrado()
        {
            InitializeComponent();
        }

        private void getLastGrades()
        {
            string queryString = "SELECT cod_grado, nombre, comision, peso FROM cheshire_jack.vw_grados";
            using (SqlCommand cmd = new SqlCommand(queryString, Program.DBconn))
            {
                grados.Clear();
                grados.Load(cmd.ExecuteReader());
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Program.openPopUpWindow(this, new Abm_Grado.CreateGrade());
            getLastGrades();
        }

        private void ABMGrado_FormClosing(object sender, FormClosingEventArgs e)
        {
            grados.Dispose();
        }

        private void ABMGrado_Load(object sender, EventArgs e)
        {
            getLastGrades();
            SelectionGrid.DataSource = grados;
            SelectionGrid.Columns["cod_grado"].Visible = false;
        }

        private void SelectionGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView _sender = (DataGridView)sender;
            if (e.ColumnIndex == 0)
            {
                int cod_grado = (int)_sender.Rows[e.RowIndex].Cells["cod_grado"].Value;
                string nombre = _sender.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                byte comision = (byte)_sender.Rows[e.RowIndex].Cells["comision"].Value;
                byte peso = (byte)_sender.Rows[e.RowIndex].Cells["peso"].Value;
                Program.openPopUpWindow(this, new Abm_Grado.CreateGrade(new Grado(cod_grado, nombre, comision, peso)));
            }
            getLastGrades();
        }
    }
}
