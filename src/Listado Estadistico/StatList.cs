using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class StatList : Form
    {
        public StatList()
        {
            InitializeComponent();
        }

        private void YearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YearBox.SelectedItem != null)
                TrimesterBox.Enabled = true;
        }

        private void TrimesterBox_DropDownClosed(object sender, EventArgs e)
        {
            if (TrimesterBox.SelectedItem != null)
                ListBox.Enabled = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ListBox.SelectedItem = null;
            ListBox.Enabled = false;
            TrimesterBox.SelectedItem = null;
            TrimesterBox.Enabled = false;
            YearBox.SelectedItem = null;
        }
    }
}
