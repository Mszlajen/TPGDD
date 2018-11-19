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

namespace PalcoNet.Generar_Publicacion
{
    public partial class GeneratePublication : Form
    {
        int codUsuario, codEmpresa = 0;
        DataTable rubros = new DataTable(),
                grados = new DataTable(),
                tiposAsientos = new DataTable();
        DataTable fechas = null;
        
        public GeneratePublication(int _codUsuario)
        {
            InitializeComponent();
            codUsuario = _codUsuario;
        }

        private void GeneratePublication_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT cod_empresa FROM cheshire_jack.empresas WHERE cod_usuario = @cod_usuario";
            SqlCommand cmd = new SqlCommand(queryString, Program.DBconn);
            cmd.Parameters.Add(new SqlParameter("@cod_usuario", codUsuario));
            SqlDataReader resultadoQuery = cmd.ExecuteReader();
            if (!resultadoQuery.Read())
                MessageBox.Show("Este usuario no tiene informacion de empresa y no podra terminar las operaciones");
            else
                codEmpresa = resultadoQuery.GetInt32(0);
            resultadoQuery.Close();

            cmd.CommandText = "SELECT cod_grado, Nombre FROM cheshire_jack.vw_grados";
            resultadoQuery = cmd.ExecuteReader();
            grados.Load(resultadoQuery);
            resultadoQuery.Close();
            
            cmd.CommandText = "SELECT cod_rubro, Nombre FROM cheshire_jack.vw_rubros";
            resultadoQuery = cmd.ExecuteReader();
            rubros.Load(resultadoQuery);
            resultadoQuery.Close();

            cmd.CommandText = "SELECT cod_tipo, descripcion FROM cheshire_jack.tipos_de_ubicacion";
            resultadoQuery = cmd.ExecuteReader();
            tiposAsientos.Load(resultadoQuery);
            resultadoQuery.Close();
            
            cmd.Dispose();

            foreach (DataRow row in grados.Rows)
                GradeBox.Items.Add(row["Nombre"]);

            foreach (DataRow row in rubros.Rows)
                CategoryBox.Items.Add(row["Nombre"]);

            DataGridViewComboBoxColumn columnaTipos = (DataGridViewComboBoxColumn)this.SeatsGrid.Columns["SeatType"];
            foreach (DataRow row in tiposAsientos.Rows)
                columnaTipos.Items.Add(row["descripcion"]);
        }

        private void BatchDatesCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (BatchDatesCheck.Checked)
            {
                BatchDatesButton.Visible = 
                    true;
                EventDatePicker.Enabled = false;
            }
            else
            {
                BatchDatesButton.Visible = false;
                EventDatePicker.Enabled = true;
            }
        }

        private void BatchDatesButton_Click(object sender, EventArgs e)
        {
            if (fechas == null)
            {
                fechas = new DataTable();
                fechas.Columns.Add("Fechas", Type.GetType("System.DateTime"));
            }
            Program.openPopUpWindow(this, new BatchDates(fechas));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private string getDates()
        {
            if (BatchDatesCheck.Checked)
            {
                StringBuilder builder = new StringBuilder();
                foreach (DataRow row in fechas.Rows)
                    builder.Append(((DateTime)row[0]).ToString("yyyy/MM/dd HH:mm") + "@");
                return builder.ToString();
            }
            else
                return EventDatePicker.Value.ToString("yyyy/MM/dd HH:mm") + "@";
        }

        private string getSeats()
        { 
            StringBuilder result = new StringBuilder();
            foreach(DataGridViewRow row in SeatsGrid.Rows)
            {
                if (row.IsNewRow)
                    break;

                foreach (DataGridViewColumn column in SeatsGrid.Columns)
                {
                    if(column.Index != 4)
                        result.AppendFormat("{0} ", row.Cells[column.Index].Value == null ? "0" : row.Cells[column.Index].Value.ToString());
                    else
                        result.AppendFormat("{0} ", tiposAsientos.Rows[row.Index]["cod_tipo"].ToString());
                }
                result.Append("@");
            }
            return result.ToString();
        }

        private bool checkSeats()
        {
            bool masDeTres = false, noNumeroAsiento = false, 
                noNumeroPrecio = false, noTipo = false;
            long aux;
            foreach (DataGridViewRow row in SeatsGrid.Rows)
            {
                if (row.IsNewRow)
                    break;
                if (!masDeTres && (row.Cells[1].Value == null || ((string)row.Cells[1].Value).Length > 3))
                    masDeTres = true;
                if (!noNumeroAsiento && (String.IsNullOrWhiteSpace((string)row.Cells[2].Value) || !long.TryParse((string)row.Cells[2].Value, out aux)))
                    noNumeroAsiento = true;
                if (!noNumeroPrecio && (String.IsNullOrWhiteSpace((string)row.Cells[3].Value) || !long.TryParse((string)row.Cells[3].Value, out aux)))
                    noNumeroPrecio = true;
                if (!noTipo && String.IsNullOrWhiteSpace((string)row.Cells[4].Value))
                    noTipo = true;
            }

            if (masDeTres)
                MessageBox.Show("La fila debe existir y no tener más de tres caracteres");
            if (noNumeroAsiento)
                MessageBox.Show("El asiento debe ser un numero");
            if (noNumeroPrecio)
                MessageBox.Show("El precio debe ser un numero");
            if (noTipo)
                MessageBox.Show("Se debe seleccionar un tipo de ubicacion");

            return !(masDeTres || noNumeroPrecio || noNumeroAsiento || noTipo);
        }

        private int savePublication(int estado, Nullable<DateTime> fechaPublicacion)
        {
            bool todoBien = true;
            long altura;
            int codEspectaculo = 0;
            if (String.IsNullOrWhiteSpace(DescriptionBox.Text))
            {
                todoBien = false;
                MessageBox.Show("La descripcion no puede estar vacia");
            }
            if (String.IsNullOrWhiteSpace(AddressText.Text) || String.IsNullOrWhiteSpace(AddressNroText.Text))
            {
                todoBien = false;
                MessageBox.Show("La direccion no puede estar vacia");
            }
            else if(!long.TryParse(AddressNroText.Text, out altura))
            {
                todoBien = false;
                MessageBox.Show("La altura debe ser un numero");
            }
            if(BatchDatesCheck.Checked && (fechas == null || fechas.Rows.Count == 0))
            {
                todoBien = false;
                MessageBox.Show("Debe cargar al menos una fecha");
            }
            if(CategoryBox.SelectedIndex == -1)
            {
                todoBien = false;
                MessageBox.Show("Debe seleccionar un rubro");
            }
            if(GradeBox.SelectedIndex == -1)
            {
                todoBien = false;
                MessageBox.Show("Debe seleccionar un grado");
            }
            if(SeatsGrid.Rows.Count == 1)
            {
                todoBien = false;
                MessageBox.Show("Debe ingresar al menos una ubicacion");
            }
            else
            {
                todoBien = checkSeats();
            }
            if (todoBien && codEmpresa != 0)
            {
                using (SqlCommand cmd = new SqlCommand("cheshire_jack.crearEvento", Program.DBconn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@codEmpresa", codEmpresa));
                    cmd.Parameters.Add(new SqlParameter("@codRubro", (int)rubros.Rows[CategoryBox.SelectedIndex]["cod_rubro"]));
                    cmd.Parameters.Add(new SqlParameter("@codGrado", (int)grados.Rows[GradeBox.SelectedIndex]["cod_grado"]));
                    cmd.Parameters.Add(new SqlParameter("@descripcion", DescriptionBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@direccion", AddressText.Text));
                    cmd.Parameters.Add(new SqlParameter("@altura", long.Parse(AddressNroText.Text)));
                    cmd.Parameters.Add(new SqlParameter("@fechas", getDates()));
                    cmd.Parameters.Add(new SqlParameter("@ubicaciones", getSeats()));
                    cmd.Parameters.Add(new SqlParameter("@estado", estado));
                    if (fechaPublicacion.HasValue)
                        cmd.Parameters.Add(new SqlParameter("@fechaPublicacion", fechaPublicacion.Value.ToString("yyyy/MM/dd HH:mm")));
                    else
                        cmd.Parameters.Add(new SqlParameter("@fechaPublicacion", DBNull.Value));
                    SqlParameter ret = new SqlParameter("@ret", DbType.Int64);
                    ret.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(ret);
                    cmd.ExecuteNonQuery();

                    codEspectaculo = (int)ret.Value;
                }
            }
            return codEspectaculo;
        }

        private void SketchButton_Click(object sender, EventArgs e)
        {
            if (savePublication(1, null) != 0)
            {
                MessageBox.Show("Espectaculo creado con exito");
                DialogResult = DialogResult.OK;
            }
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            if (savePublication(2, Settings1.Default.CurrentDate) != 0)
            {
                MessageBox.Show("Espectaculo creado con exito");
                DialogResult = DialogResult.OK;
            }
        }

        private void GeneratePublication_FormClosing(object sender, FormClosingEventArgs e)
        {
            rubros.Dispose();
            grados.Dispose();
            tiposAsientos.Dispose();
        }

    }
}
