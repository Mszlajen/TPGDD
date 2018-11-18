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

namespace PalcoNet
{
    public partial class FunctionSelection : Form
    {
        private int codUsuario, codRol;
        private DataTable funciones = new DataTable();
        public FunctionSelection(int _codUsuario, int _codRol)
        {
            InitializeComponent();
            codRol = _codRol;
            codUsuario = _codUsuario;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (FunctionsBox.SelectedIndex != -1)
            {
                Program.openNextWindow(this, this.createWindow((string)FunctionsBox.SelectedItem));
            }
        }

        private void FunctionSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.Cancel)
                Program.closeProgram();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FunctionSelection_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT descripcion FROM cheshire_jack.RolesxFuncionalidades RF " +
                                 "JOIN cheshire_jack.funcionalidades f ON RF.cod_funcionalidad = f.cod_funcionalidad " + 
                                 "WHERE RF.cod_rol = @cod_rol";
            using(SqlCommand cmd = new SqlCommand(queryString, Program.DBconn))
            {
                cmd.Parameters.Add(new SqlParameter("@cod_rol", codRol));
                
                funciones.Load(cmd.ExecuteReader());
                foreach(DataRow row in funciones.Rows)
                {
                    FunctionsBox.Items.Add(row["descripcion"]);
                }
            }
        }

        private Form createWindow(string functionName)
        {
            switch (functionName)
            {
                case "ABM Rubro":
                    return new Abm_Rubro.Form1();
                case "ABM Rol":
                    return new Abm_Rol.ABMRol();
                case "ABM Grado":
                    return new Abm_Grado.ABMGrado();
                case "Listado Estadistico":
                    return new Listado_Estadistico.StatList();
                case "ABM Cliente":
                    return new Abm_Cliente.Selection();
                case "ABM Empresa de Espectaculo":
                    return new Abm_Empresa_Espectaculo.Selection();
                case "Canje de Puntos":
                    return new Canje_Puntos.PointExchange(codUsuario);
                case "Historial Cliente":
                    return new Historial_Cliente.History(codUsuario);
                default:
                    return new Form();

            }
        }
    }
}
