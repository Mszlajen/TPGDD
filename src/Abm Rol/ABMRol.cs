using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class ABMRol : Form
    {
        public ABMRol()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Program.openNextWindow(this, new Abm_Rol.CreateRole());
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Program.openNextWindow(this, new Abm_Rol.RoleSelection());
        }
    }
}
