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

namespace PalcoNet.Editar_Publicacion
{
    public partial class EditPublication : Form
    {
        DataRow publicacion;
        DataTable rubros = new DataTable(), grados = new DataTable(), 
            tiposAsientos = new DataTable(), ubicaciones = new DataTable();
        int codEmpresa = 0;
        bool cambiaronUbicaciones;
        public EditPublication(int _codEmpresa, DataRow row)
        {
            InitializeComponent();
            publicacion = row;
            codEmpresa = _codEmpresa;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void EditPublication_Load(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = Program.DBconn;
                cmd.CommandText = "SELECT cod_grado, Nombre FROM cheshire_jack.vw_grados";
                SqlDataReader resultadoQuery = cmd.ExecuteReader();
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

                cmd.CommandText = "cheshire_jack.ubicacionesDe";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codPublicacion", publicacion["cod_publicacion"].ToString()));
                resultadoQuery = cmd.ExecuteReader();
                ubicaciones.Load(resultadoQuery);
                resultadoQuery.Close();
            }

            foreach (DataRow row in grados.Rows)
                GradeBox.Items.Add(row["Nombre"]);
            foreach (DataRow row in rubros.Rows)
                CategoryBox.Items.Add(row["Nombre"]);
            DataGridViewComboBoxColumn columnaTipos = (DataGridViewComboBoxColumn)this.SeatsGrid.Columns["SeatType"];
            foreach (DataRow row in tiposAsientos.Rows)
                columnaTipos.Items.Add(row["descripcion"]);

            DescriptionBox.Text = publicacion["Descripcion"].ToString();
            AddressText.Text = publicacion["Direccion"].ToString();
            AddressNroText.Text = publicacion["Altura"].ToString();
            GradeBox.SelectedItem = publicacion["Grado de Publicacion"];
            CategoryBox.SelectedItem = publicacion["Rubro"];

            foreach (DataRow row in ubicaciones.Rows)
            {
                SeatsGrid.Rows.Add(new object[] { null, row["Sin Numerar"], row["Fila"], row["Asiento"], 
                                                  row["Precio"], row["Tipo de Asiento"] });
            }

            cambiaronUbicaciones = false;
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
                if (!masDeTres && (row.Cells[2].Value == null || row.Cells[2].Value.ToString().Length > 3))
                    masDeTres = true;
                if (!noNumeroAsiento && (String.IsNullOrWhiteSpace(row.Cells[3].Value.ToString()) || !long.TryParse(row.Cells[3].Value.ToString(), out aux)))
                    noNumeroAsiento = true;
                if (!noNumeroPrecio && (String.IsNullOrWhiteSpace(row.Cells[4].Value.ToString()) || !long.TryParse(row.Cells[4].Value.ToString(), out aux)))
                    noNumeroPrecio = true;
                if (!noTipo && String.IsNullOrWhiteSpace(row.Cells[5].Value.ToString()))
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
            else if (!long.TryParse(AddressNroText.Text, out altura))
            {
                todoBien = false;
                MessageBox.Show("La altura debe ser un numero");
            }
            if (SeatsGrid.Rows.Count == 1)
            {
                todoBien = false;
                MessageBox.Show("Debe ingresar al menos una ubicacion");
            }
            else
            {
                todoBien = checkSeats();
            }
            if (EventDatePicker.Value < Settings1.Default.CurrentDate)
            {
                todoBien = false;
                MessageBox.Show("La fecha del evento no puede ser anterior a la fecha de hoy");
            }
            if (todoBien)
            {
                bool modificoEspectaculo = DescriptionBox.Text != publicacion["Descripcion"].ToString() || AddressText.Text != publicacion["Direccion"].ToString() ||
                    AddressNroText.Text != publicacion["Altura"].ToString() || CategoryBox.SelectedItem.ToString() != publicacion["Rubro"].ToString();

                modificoEspectaculo = modificoEspectaculo && MessageBox.Show("Se modifico la información del espectaculo, ¿desea crear uno nuevo? (En caso negativo se modificaran todas las publicaciones)", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes;
                    

                bool modificarPublicaciones = cambiaronUbicaciones || GradeBox.SelectedItem.ToString() != publicacion["Grado de Publicacion"].ToString() || estado == 2;
                modificarPublicaciones = modificarPublicaciones && (modificoEspectaculo || MessageBox.Show("Se modificaron las ubicaciones, el grado y/o el estado de la publicación ¿Desea modificar todas las publicaciones?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes);

                using(SqlCommand cmd = new SqlCommand("cheshire_jack.actualizarPublicacion", Program.DBconn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter ret = new SqlParameter("@ret", DbType.Int64);
                    ret.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.AddRange(new SqlParameter[] { new SqlParameter("@codPublicacion", publicacion["cod_publicacion"].ToString()),
                        new SqlParameter("@descripcion", DescriptionBox.Text), 
                        new SqlParameter("@direccion", AddressText.Text),
                        new SqlParameter("@altura", AddressNroText.Text),
                        new SqlParameter("@codRubro", rubros.Rows[CategoryBox.SelectedIndex]["cod_rubro"]),
                        new SqlParameter("@codGrado", grados.Rows[GradeBox.SelectedIndex]["cod_grado"]),
                        new SqlParameter("@ubicaciones", getSeats()),
                        new SqlParameter("@fecha", EventDatePicker.Value.ToString("yyyy/MM/dd HH:mm")),
                        new SqlParameter("@codEstado", estado),
                        new SqlParameter("@modificarEspectaculo", modificoEspectaculo),
                        new SqlParameter("@modificarPublicaciones", modificarPublicaciones),
                        ret});
                    if (fechaPublicacion.HasValue)
                        cmd.Parameters.Add(new SqlParameter("@fechaPublicacion", fechaPublicacion.Value.ToString("yyyy/MM/dd HH:mm")));
                    else
                        cmd.Parameters.Add(new SqlParameter("@fechaPublicacion", DBNull.Value));

                    cmd.ExecuteNonQuery();
                    codEspectaculo = (int) ret.Value;
                }
            }
            return codEspectaculo;
        }
        
        private string getSeats()
        {
            StringBuilder result = new StringBuilder();
            DataGridViewComboBoxCell tipo;
            foreach (DataGridViewRow row in SeatsGrid.Rows)
            {
                if (row.IsNewRow)
                    break;

                foreach (DataGridViewColumn column in SeatsGrid.Columns)
                {
                    switch(column.Index)
                    {
                        case 0:                  
                            continue;
                        case 5:
                            tipo = (DataGridViewComboBoxCell)SeatsGrid.Rows[row.Index].Cells[column.Index];
                            result.AppendFormat("{0} ", tiposAsientos.Rows[tipo.Items.IndexOf(tipo.Value)]["cod_tipo"].ToString());
                            break;
                        case 1:
                            result.AppendFormat("{0} ", row.Cells[column.Index].Value == null? "0" : row.Cells[column.Index].Value.ToString());
                            break;
                        default:
                            result.AppendFormat("{0} ", row.Cells[column.Index].Value.ToString().Trim());
                            break;
                    }   
                }
                result.Append("@");
            }
            return result.ToString();
        }

        private void SeatsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && !SeatsGrid.Rows[e.RowIndex].IsNewRow)
            {
                SeatsGrid.Rows.RemoveAt(e.RowIndex);
                cambiaronUbicaciones = true;
            }
        }

        private void SeatsGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            cambiaronUbicaciones = true;
        }

        private void SeatsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            cambiaronUbicaciones = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            savePublication(1, null);
        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            savePublication(2, Settings1.Default.CurrentDate);
            DialogResult = DialogResult.OK;
        }
    }
}
