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
            string queryString = "SELECT cod_funcionalidad, descripcion FROM cheshire_jack.funcionalidades";
            using(SqlCommand cmd = new SqlCommand(queryString, Program.DBconn))
                funcionalidades.Load(cmd.ExecuteReader());

            foreach(DataRow row in funcionalidades.Rows)
                FunctionsList.Items.Add(row["descripcion"]);

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
                            FunctionsList.SetItemChecked(i, true);
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

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            bool todoBien = true;
            if (string.IsNullOrWhiteSpace(RoleNameBox.Text))
            {
                MessageBox.Show("No puede dejarse el nombre vacio.");
                todoBien = false;
            }
            if (todoBien && FunctionsList.CheckedIndices.Count == 0)
            {
                if(MessageBox.Show("Dejo el role sin funcionalidades. ¿Está seguro que quiere continuar?", "confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    todoBien = false;
            }
            if (todoBien && availabilityCheck.Enabled && !availabilityCheck.Checked)
            {
                if (MessageBox.Show("Se le quitara el rol a todos los usuarios. ¿Está seguro que quiere continuar?", "confirmacion", MessageBoxButtons.YesNo) == DialogResult.No)
                    todoBien = false;
            }
            if (todoBien)
            {
                if (havingRole)
                    role.updateValues(RoleNameBox.Text, availabilityCheck.Checked, SignUpCheck.Checked).updateToDataBase(Program.DBconn);
                else
                    role = Role.createInDataBase(Program.DBconn, RoleNameBox.Text, availabilityCheck.Checked, SignUpCheck.Checked);

                List<int> cod_funcionalidades = new List<int>();
                
                DataRow curRow;
                foreach (string nombre in FunctionsList.CheckedItems)
                {
                    string selectString = "'" + nombre + "' = descripcion";
                    curRow = funcionalidades.Select(selectString)[0];
                    cod_funcionalidades.Add((int) curRow["cod_funcionalidad"]);
                }

                role.updateFunctionsToDataBase(Program.DBconn, cod_funcionalidades);

                if (!availabilityCheck.Checked)
                    role.removeFromUsers(Program.DBconn);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
