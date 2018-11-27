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
    public partial class CreateRole : Form
    {
        private bool havingRole = false;
        DataTable funcionalidades = new DataTable();
        private Role role;
        public CreateRole()
        {
            InitializeComponent();
        }

        public CreateRole(Role toEdit)
        {
            InitializeComponent();
            havingRole = true;
            role = toEdit;
        }

        private void CreateRole_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT cod_funcionalidad, descripcion Funcionalidad FROM cheshire_jack.funcionalidades";
            using(SqlCommand cmd = new SqlCommand(queryString, Program.DBconn))
                funcionalidades.Load(cmd.ExecuteReader());

            ListGrid.DataSource = funcionalidades;
            ListGrid.Columns["cod_funcionalidad"].Visible = false;
            ListGrid.Columns["Funcionalidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            foreach (DataGridViewRow row in ListGrid.Rows)
                row.Cells[0].Value = false;

            if (havingRole)
            {
                AcceptButton.Text = "Guardar";

                availabilityCheck.Show();

                RoleNameBox.Text = role.nombre;
                availabilityCheck.Checked = role.habilitado;
                SignUpCheck.Checked = role.registrable;

                queryString = "SELECT cod_funcionalidad FROM cheshire_jack.RolesxFuncionalidades WHERE cod_rol = @cod_rol";
                using (SqlCommand cmd = new SqlCommand(queryString, Program.DBconn))
                {
                    cmd.Parameters.Add(new SqlParameter("@cod_rol", role.codigo));
                    DataTable funcXrol = new DataTable();
                    funcXrol.Load(cmd.ExecuteReader());
                    funcXrol.PrimaryKey = new DataColumn[] { funcXrol.Columns[0] };
                    int i = 0;
                    foreach (DataRow func in funcionalidades.Rows)
                    {
                        if (funcXrol.Rows.Contains(func["cod_funcionalidad"]))
                            ListGrid.Rows[i].Cells[0].Value = true;
                        i++;
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CreateRole_FormClosing(object sender, FormClosingEventArgs e)
        {
            funcionalidades.Dispose();
        }

        private byte countChecked()
        {
            byte count = 0;
            foreach (DataGridViewRow row in ListGrid.Rows)
            {
                if ((bool)row.Cells[0].Value)
                    count++;
            }
            return count;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            bool todoBien = true;
            if (string.IsNullOrWhiteSpace(RoleNameBox.Text))
            {
                MessageBox.Show("No puede dejarse el nombre vacio.");
                todoBien = false;
            }
            if (availabilityCheck.Enabled && !availabilityCheck.Checked)
            {
                if (MessageBox.Show("Se le quitara el rol a todos los usuarios. ¿Está seguro que quiere continuar?", "confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    todoBien = false;
            }
            if (todoBien && (countChecked() != 0 || MessageBox.Show("Dejo el role sin funcionalidades. ¿Está seguro que quiere continuar?", "confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                if (havingRole)
                    role.updateValues(RoleNameBox.Text, availabilityCheck.Checked, SignUpCheck.Checked).updateToDataBase(Program.DBconn);
                else
                    role = Role.createInDataBase(Program.DBconn, RoleNameBox.Text, availabilityCheck.Checked, SignUpCheck.Checked);

                List<int> cod_funcionalidades = new List<int>();
                
                foreach (DataGridViewRow row in ListGrid.Rows)
                {
                    if((bool)row.Cells[0].Value)
                        cod_funcionalidades.Add((int) row.Cells["cod_funcionalidad"].Value);
                }

                role.updateFunctionsToDataBase(Program.DBconn, cod_funcionalidades);

                if (!availabilityCheck.Checked)
                    role.removeFromUsers(Program.DBconn);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
