using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet
{
    public class Cliente : TipoDeUsuario<Cliente>
    {
        int codCliente;
        string nombre, apellido, tipoDocumento, nroDocumento, CUIL, 
                mail, telefono, domicilio, nroCalle, piso, dept, localidad,
                codPostal;
        DateTime fechaNacimiento; 
        public DateTime fechaCreacion;
        Card tarjeta;

        public Cliente(int _codCliente, string _nombre, string _apellido, string _tipoDocumento,
                       string _nroDocumento, string _CUIL, string _mail, string _telefono,
                       string _domicilio, string _nroCalle, string _piso, string _dept,
                       string _localidad, string _codPostal, DateTime _fechaNacimiento, DateTime _fechaCreacion)
        {
            codCliente = _codCliente;
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
        }

        public Cliente(int _codCliente, string _nombre, string _apellido, string _tipoDocumento,
                       string _nroDocumento, string _CUIL, string _mail, string _telefono,
                       string _domicilio, string _nroCalle, string _piso, string _dept,
                       string _localidad, string _codPostal, DateTime _fechaNacimiento)
        {
            codCliente = _codCliente;
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
            fechaNacimiento = _fechaNacimiento;
        }

        public static Cliente CreateToDataBase(SqlConnection DB, string nombre, string apellido, string tipoDocumento,
                       string nroDocumento, string CUIL, string mail, string telefono,
                       string domicilio, string nroCalle, string piso, string dept,
                       string localidad, string codPostal, DateTime fechaNacimiento,
                       DateTime fechaCreacion, int codUsuario)
        {
            Cliente nuevo;
            using (SqlCommand guardar = new SqlCommand("crearCliente", DB))
            {
                guardar.CommandType = CommandType.StoredProcedure;
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
                guardar.Parameters.Add(new SqlParameter("@codUsuario", codUsuario));
                SqlParameter ret = new SqlParameter("@ret", DbType.Int32);
                ret.Direction = ParameterDirection.ReturnValue;
                guardar.Parameters.Add(ret);

                nuevo = new Cliente((int)ret.Value, nombre, apellido, tipoDocumento, nroDocumento, CUIL, mail, telefono, domicilio, nroCalle, piso, dept, localidad, codPostal, fechaNacimiento, fechaCreacion);
            }
            return nuevo;
        }

        override public Cliente UpdateToDataBase(SqlConnection DB)
        {
            string queryString = "UPDATE cheshire_jack.clientes " +
                                 "SET nombre = @nombre, apellido = @apellido, tipo_documento = @tipoDoc, nro_documento = @nroDoc, " +
                                 "CUIL = @CUIL, mail = @mail, telefono = @telefono, domicilio_calle = @domicilio, nro_calle = @nroCalle, " +
                                 "piso = @piso, dept = @dept, localidad = @localidad, codigo_postal = @codPostal, " +
                                 "fecha_creacion = @fechaCreacion, fecha_nacimiento = @fechaNacimiento " +
                                 "WHERE cod_cliente = @codCliente";
            using (SqlCommand guardar = new SqlCommand(queryString, DB))
            {
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
                guardar.Parameters.Add(new SqlParameter("@codCliente", codCliente));
            }
            return this;
        }

        public Cliente UpdateValues(string _nombre, string _apellido, string _tipoDocumento,
                       string _nroDocumento, string _CUIL, string _mail, string _telefono,
                       string _domicilio, string _nroCalle, string _piso, string _dept,
                       string _localidad, string _codPostal, DateTime _fechaNacimiento, 
                       DateTime _fechaCreacion)
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
            return this;
        }

        public static bool checkCUIL(string CUIL)
        {
            char[] separador = { '-' };
            string[] partesDeCUIL = CUIL.Split(separador);

            string[] tipos = { "20", "23", "24", "27" };
            if (!tipos.Contains(partesDeCUIL[0]))
                return false;

            int digitoVerificador = 0, i = 0;
            int[] secuencia = { 2, 3, 4, 5, 6, 7, 2, 3, 4, 5 };
            foreach (char digito in (partesDeCUIL[0] + partesDeCUIL[1]).Reverse())
            {
                digitoVerificador += int.Parse(digito.ToString()) * secuencia[i];
                i++;
            }

            digitoVerificador %= 11;
            digitoVerificador = 11 - digitoVerificador;
            digitoVerificador = digitoVerificador == 11 ? 0 : digitoVerificador;

            return digitoVerificador.ToString() == partesDeCUIL[2];
        }
    }
}
