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

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class PayFees : Form
    {
        int codEmpresa;
        string razonSocial;
        DataTable compras = new DataTable();
        public PayFees(int _codEmpresa, string _razonSocial)
        {
            InitializeComponent();
            codEmpresa = _codEmpresa;
            razonSocial = _razonSocial;
        }

        private void PayFees_Load(object sender, EventArgs e)
        {
            NameBox.Text = razonSocial;
            PendingsGrid.DataSource = compras;
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.comisionesPendientes", Program.DBconn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codEmpresa", codEmpresa));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(compras);
            }
            if (compras.Rows.Count == 0)
            {
                MessageBox.Show("Esta empresa no tiene ventas pendientes de facturacion");
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                PendingsGrid.Columns["cod_compra"].Visible = false;
                QuantityCounter.Maximum = compras.Rows.Count;
            }
        }

        private void BillButton_Click(object sender, EventArgs e)
        {
            int cantidadAFacturar = (int)QuantityCounter.Value;
            uint nroFactura;
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.facturarComisiones", Program.DBconn))
            {
                cmd.Parameters.Add(new SqlParameter("@compraDesde", compras.Rows[0]["cod_compra"]));
                cmd.Parameters.Add(new SqlParameter("@compraHasta", compras.Rows[cantidadAFacturar - 1]["cod_compra"]));
                cmd.Parameters.Add(new SqlParameter("@fecha", Settings1.Default.CurrentDate));
                SqlParameter ret = new SqlParameter("@ret", DbType.VarNumeric);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);

                cmd.ExecuteNonQuery();

                nroFactura = (uint)ret.Value;
            }
            MessageBox.Show("Numero de Factura: " + nroFactura.ToString());
            DialogResult = DialogResult.OK;
        }

        private void PayFees_FormClosing(object sender, FormClosingEventArgs e)
        {
            compras.Dispose();
        }
    }
}
