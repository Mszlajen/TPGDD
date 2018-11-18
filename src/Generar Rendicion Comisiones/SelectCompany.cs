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

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class SelectCompany : Form
    {
        DataTable empresas = new DataTable();
        public SelectCompany()
        {
            InitializeComponent();
        }

        private void updateGrid()
        {
            empresas.Clear();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.DBconn;
                string queryString = "SELECT * FROM cheshire_jack.vw_empresas WHERE 1=1 ";
                // Los textos libres no funcionan por alguna razon
                if (!String.IsNullOrWhiteSpace(NameBox.Text))
                {
                    queryString += "AND [Razon Social] LIKE @razonSocial ";
                    cmd.Parameters.Add(new SqlParameter("@razonSocial", "%"+NameBox.Text+"%"));
                }
                if (!String.IsNullOrWhiteSpace(CUITBox.Text))
                {
                    queryString += "AND CUIT = @CUIT ";
                    cmd.Parameters.Add(new SqlParameter("@CUIT", CUITBox.Text));
                }
                if (!String.IsNullOrWhiteSpace(MailBox.Text))
                {
                    queryString += "AND [E-mail] LIKE @mail ";
                    cmd.Parameters.Add(new SqlParameter("@mail", "%" + MailBox.Text + "%"));
                }
                cmd.CommandText = queryString;
                empresas.Load(cmd.ExecuteReader());
            }

            CompanyGrid.Columns["cod_empresa"].Visible = false;
            CompanyGrid.Columns["cod_usuario"].Visible = false;
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            NameBox.Text = "";
            MailBox.Text = "";
            CUITBox.Text = "";
            empresas.Clear();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            updateGrid();
        }

        private void SelectCompany_Load(object sender, EventArgs e)
        {
            CompanyGrid.DataSource = empresas;
        }

        private void CompanyGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int codEmpresa = (int)CompanyGrid.Rows[e.RowIndex].Cells["cod_empresa"].Value;
                string nombre = (string)CompanyGrid.Rows[e.RowIndex].Cells["Razon Social"].Value;
                Program.openPopUpWindow(this, new PayFees(codEmpresa, nombre));
            }
        }
    }
}
