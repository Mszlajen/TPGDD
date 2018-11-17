using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Program.openPopUpWindow(this, new CreateCompany());
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            Program.openPopUpWindow(this, new SelectCompany());
        }
    }
}
