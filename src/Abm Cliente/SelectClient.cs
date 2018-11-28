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

namespace PalcoNet.Abm_Cliente
{
    public partial class SelectClient : Form
    {
        DataTable clientes = new DataTable();

        public SelectClient()
        {
            InitializeComponent();
        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            NameBox.Text = "";
            SurnameBox.Text = "";
            DocumentTypeBox.SelectedIndex = -1;
            DocumentNumberBox.Text = "";
            DocumentNumberBox.Enabled = false;
            MailBox.Text = "";
            clientes.Clear();
        }

        private void SelectClient_Load(object sender, EventArgs e)
        {
            ClientsGrid.DataSource = clientes;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string queryString = "SELECT * FROM cheshire_jack.vw_clientes WHERE 1=1 ";
            if (!String.IsNullOrWhiteSpace(NameBox.Text))
                queryString += "AND Nombre LIKE '%" + NameBox.Text + "%' ";
            if(!String.IsNullOrWhiteSpace(SurnameBox.Text))
                queryString += "AND Apellido LIKE '%" + SurnameBox.Text + "%' ";
            if (!String.IsNullOrWhiteSpace(MailBox.Text))
                queryString += "AND 'E-mail' LIKE '%" + MailBox.Text + "%' ";
            //Condicion de documento
            
            clientes.Clear();
            using (SqlCommand cmd = new SqlCommand(queryString, Program.DBconn))
                clientes.Load(cmd.ExecuteReader());

            ClientsGrid.Columns["cod_cliente"].Visible = false;
            ClientsGrid.Columns["cod_usuario"].Visible = false;
        }

        private void ClientsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = ClientsGrid.Rows[e.RowIndex];
                string fechaCreacion = row.Cells["Fecha de Creacion"].Value.ToString();
                Cliente cliente = new Cliente((int) row.Cells["cod_cliente"].Value, row.Cells["Nombre"].Value.ToString(),
                                              row.Cells["Apellido"].Value.ToString(), row.Cells["Tipo de Documento"].Value.ToString(),
                                              row.Cells["Nro de Documento"].Value.ToString(), row.Cells["CUIL"].Value.ToString(),
                                              row.Cells["E-mail"].Value.ToString(), row.Cells["Telefono"].Value.ToString(),
                                              row.Cells["Domicilio Calle"].Value.ToString(), row.Cells["Altura"].Value.ToString(),
                                              row.Cells["Piso"].Value.ToString(), row.Cells["Departamento"].Value.ToString(),
                                              row.Cells["Localidad"].Value.ToString(), row.Cells["Codigo Postal"].Value.ToString(),
                                              (DateTime)row.Cells["Fecha de Nacimiento"].Value, (bool)row.Cells["Habilitado"].Value);
                if (!String.IsNullOrWhiteSpace(fechaCreacion))
                    cliente.fechaCreacion = (DateTime) row.Cells["Fecha de Creacion"].Value;
                Program.openPopUpWindow(this, new CreateClient(cliente));
                clientes.Clear();
            }
        }

        private void DocumentTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocumentNumberBox.Enabled = true;
        }
    }
}
