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

namespace PalcoNet.Abm_Empresa_Espectaculo
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
                if (!String.IsNullOrWhiteSpace(NameBox.Text))
                {
                    queryString += "AND [Razon Social] LIKE @razonSocial ";
                    cmd.Parameters.Add(new SqlParameter("@razonSocial", "%" + NameBox.Text + "%"));
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
                if (AvabilityCheck.CheckState == CheckState.Checked || AvabilityCheck.CheckState == CheckState.Unchecked)
                {
                    cmd.Parameters.AddWithValue("@habilitado", AvabilityCheck.Checked);
                   queryString += "AND habilitado = @habilitado ";
                }
                cmd.CommandText = queryString;
                empresas.Load(cmd.ExecuteReader());
            }

            CompanyGrid.Columns["cod_empresa"].Visible = false;
            CompanyGrid.Columns["cod_usuario"].Visible = false;
        }
        private void CompanyGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = CompanyGrid.Rows[e.RowIndex];
                EmpresaEspectaculo empresa = new EmpresaEspectaculo((int)row.Cells["cod_empresa"].Value, row.Cells["Razon Social"].Value.ToString(),
                    row.Cells["Telefono"].Value.ToString(), row.Cells["E-mail"].Value.ToString(), row.Cells["Domicilio"].Value.ToString(),
                    row.Cells["Altura"].Value.ToString(), row.Cells["Piso"].Value.ToString(), row.Cells["Departamento"].Value.ToString(),
                    row.Cells["Ciudad"].Value.ToString(), row.Cells["Codigo Postal"].Value.ToString(), row.Cells["CUIT"].Value.ToString(),
                    (int)row.Cells["cod_usuario"].Value, (bool)row.Cells["Habilitado"].Value);
                Program.openPopUpWindow(this, new CreateCompany(empresa));
                empresas.Clear();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            updateGrid();
        }

        private void SelectCompany_Load(object sender, EventArgs e)
        {
            using(SqlCommand cmd = new SqlCommand("SELECT * FROM cheshire_jack.vw_empresas WHERE cod_empresa = 0", Program.DBconn))
                empresas.Load(cmd.ExecuteReader());
            CompanyGrid.DataSource = empresas;
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            NameBox.Text = "";
            MailBox.Text = "";
            CUITBox.Text = "";
            empresas.Clear();
        }
    }
}
