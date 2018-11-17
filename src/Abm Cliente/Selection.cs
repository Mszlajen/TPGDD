using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Program.openPopUpWindow(this, new CreateClient());
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            Program.openPopUpWindow(this, new SelectClient());
        }
    }
}
