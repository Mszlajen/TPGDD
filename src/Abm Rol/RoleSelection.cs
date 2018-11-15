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

namespace PalcoNet.Abm_Rol
{
    public partial class RoleSelection : Form
    {
        private DataTable roles = new DataTable();

        public RoleSelection()
        {
            InitializeComponent();
        }

        private void getLastRoles()
        {
            string queryString = "SELECT cod_rol, descripcion nombre, habilitado, registrable FROM cheshire_jack.roles";
            using (SqlCommand cmd = new SqlCommand(queryString, Program.DBconn))
            {
                roles.Clear();
                roles.Load(cmd.ExecuteReader());
            }
            
        }

        private void RoleSelection_Load(object sender, EventArgs e)
        {
            getLastRoles();
            SelectionGrid.DataSource = roles;
            SelectionGrid.Columns["cod_rol"].Visible = false;
        }

        private void SelectionGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView _sender = (DataGridView)sender;
            if (e.ColumnIndex == 0)
            {
                int cod_rol = (int) _sender.Rows[e.RowIndex].Cells["cod_rol"].Value;
                Program.openNextWindow(this, new Abm_Rol.CreateRole(cod_rol));
            }
            getLastRoles();
        }


    }
}
