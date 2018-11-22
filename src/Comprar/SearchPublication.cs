using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class SearchPublication : Form
    {
        DataTable publicaciones = new DataTable();
        public SearchPublication()
        {
            InitializeComponent();
        }

        private void SearchPublication_Load(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ToCheck.Checked = false;
            FromCheck.Checked = false;
            FromPicker.Enabled = false;
            ToPicker.Enabled = false;
            DescriptionBox.Text = "";
            TagBox.SelectedIndex = -1;
            publicaciones.Clear();
        }
    }
}
