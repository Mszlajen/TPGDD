using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PalcoNet
{
    public class Cliente : Usuario
    {
        int codCliente, codUsuario;
        string nombre, apellido, tipoDocumento, nroDocumento, CUIL, 
                mail, telefono, domicilio, nroCalle, piso, dept, localidad,
                codPostal;
        DateTime fechaNacimiento, fechaCreacion;

        public Cliente(string _nombre, string _apellido, string _tipoDocumento,
                       string _nroDocumento, string _CUIL, string _mail, string _telefono,
                       string _domicilio, string _nroCalle, string _piso, string _dept,
                       string _localidad, string _codPostal, DateTime _fechaNacimiento, 
                       DateTime _fechaCreacion, int _codUsuario = 0)
        {
            nombre = _nombre;
            apellido = _apellido;
            tipoDocumento = _tipoDocumento;
            nroDocumento = _nroDocumento;
            CUIL = _CUIL;
            mail = _mail;
            telefono = _telefono;
            domicilio = _domicilio;
            nroCalle = _nroCalle;
            piso = _piso;
            dept = _dept;
            localidad = _localidad;
            codPostal = _codPostal;
            fechaCreacion = _fechaCreacion;
            fechaNacimiento = _fechaNacimiento;
            codUsuario = _codUsuario;
        }

        public void guardarClienteEnDB()
        {
            SqlCommand guardar = new SqlCommand("EXEC crearCliente @nombre, @apellido, @tipoDoc, @nroDoc," +
                                                 "@CUIL, @mail, @telefono, @domicilio, @nroCalle," +
                                                 "@piso, @dept, @localidad, @codPostal, @fechaCreacion, @fechaNacimiento, @codUsuario, @codCliente");
            guardar.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar);
            guardar.Parameters["@nombre"].Value = nombre;
            guardar.Parameters.Add("@apellido", System.Data.SqlDbType.NVarChar);
            guardar.Parameters["@apellido"].Value = apellido;
            guardar.Parameters.Add("@tipoDoc", System.Data.SqlDbType.VarChar);
            guardar.Parameters["@tipoDoc"].Value = tipoDocumento;
            guardar.Parameters.Add("@nroDoc", System.Data.SqlDbType.Decimal);
            guardar.Parameters["@nroDoc"].Value = nroDocumento;
            guardar.Parameters.Add("@CUIL", System.Data.SqlDbType.Char);
            guardar.Parameters["@CUIL"].Value = CUIL;
            guardar.Parameters.Add("@mail", System.Data.SqlDbType.NVarChar);
            guardar.Parameters["@mail"].Value = mail;
            guardar.Parameters.Add("@telefono", System.Data.SqlDbType.Char);
            guardar.Parameters["@telefono"].Value = telefono;
            guardar.Parameters.Add("@domicilio", System.Data.SqlDbType.NVarChar);
            guardar.Parameters["@domicilio"].Value = domicilio;
            guardar.Parameters.Add("@nroCalle", System.Data.SqlDbType.Decimal);
            guardar.Parameters["@nroCalle"].Value = nroCalle;
            guardar.Parameters.Add("@piso", System.Data.SqlDbType.Decimal);
            guardar.Parameters["@piso"].Value = piso;
            guardar.Parameters.Add("@dept", System.Data.SqlDbType.NVarChar);
            guardar.Parameters["@dept"].Value = dept;
            guardar.Parameters.Add("@localidad", System.Data.SqlDbType.NVarChar);
            guardar.Parameters["@localidad"].Value = localidad;
            guardar.Parameters.Add("@codPostal", System.Data.SqlDbType.NVarChar);
            guardar.Parameters["@codPostal"].Value = codPostal;
            guardar.Parameters.Add("@fechaCreacion", System.Data.SqlDbType.DateTime);
            guardar.Parameters["@fechaCreacion"].Value = fechaCreacion;
            guardar.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime);
            guardar.Parameters["@fechaNacimiento"].Value = fechaNacimiento;
            guardar.Parameters.Add("@codUsuario", System.Data.SqlDbType.Int);
            guardar.Parameters["@codUsuario"].Value = codUsuario;
            guardar.Parameters.Add("@codCliente", System.Data.SqlDbType.Int);
            
            guardar.Connection = Program.DBconn;
            try
            {
                guardar.ExecuteNonQuery();
            }
            catch
            {
            }
        }
    }
}
