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
        public string nombre, apellido, tipoDocumento, nroDocumento, CUIL, 
                mail, telefono, domicilio, nroCalle, piso, dept, localidad,
                codPostal;
        public DateTime fechaNacimiento; 
        public DateTime fechaCreacion;
        public bool habilitado;
        public Card tarjeta;

        public Cliente(int _codCliente, string _nombre, string _apellido, string _tipoDocumento,
                       string _nroDocumento, string _CUIL, string _mail, string _telefono,
                       string _domicilio, string _nroCalle, string _piso, string _dept,
                       string _localidad, string _codPostal, DateTime _fechaNacimiento, 
                       bool _habilitado)
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
            habilitado = _habilitado;
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
                       DateTime fechaCreacion, string nombreUsuario, string contrasenia, 
                       bool automatico, Card tarjeta)
        {
            Cliente nuevo;
            using (SqlCommand guardar = new SqlCommand("cheshire_jack.crearCliente", DB))
            {
                guardar.CommandType = CommandType.StoredProcedure;
                guardar.Parameters.Add(new SqlParameter("@nombre", nombre));
                guardar.Parameters.Add(new SqlParameter("@apellido", apellido));
                guardar.Parameters.Add(new SqlParameter("@tipoDocumento", tipoDocumento));
                guardar.Parameters.Add(new SqlParameter("@nroDocumento", nroDocumento));
                guardar.Parameters.Add(new SqlParameter("@CUIL", CUIL));
                guardar.Parameters.Add(new SqlParameter("@mail", mail));
                if (String.IsNullOrWhiteSpace(telefono))
                    guardar.Parameters.Add(new SqlParameter("@telefono", DBNull.Value));
                else
                    guardar.Parameters.Add(new SqlParameter("@telefono", telefono));
                guardar.Parameters.Add(new SqlParameter("@domicilio", domicilio));
                guardar.Parameters.Add(new SqlParameter("@nroCalle", nroCalle));
                if (String.IsNullOrWhiteSpace(piso))
                    guardar.Parameters.Add(new SqlParameter("@piso", DBNull.Value));
                else
                    guardar.Parameters.Add(new SqlParameter("@piso", piso));
                if (String.IsNullOrWhiteSpace(dept))
                    guardar.Parameters.Add(new SqlParameter("@dept", DBNull.Value));
                else
                    guardar.Parameters.Add(new SqlParameter("@dept", dept));
                guardar.Parameters.Add(new SqlParameter("@localidad", localidad));
                guardar.Parameters.Add(new SqlParameter("@codPostal", codPostal));
                guardar.Parameters.Add(new SqlParameter("@fechaCreacion", fechaCreacion));
                guardar.Parameters.Add(new SqlParameter("@fechaNacimiento", fechaNacimiento));
                guardar.Parameters.Add(new SqlParameter("@nombreUsuario", nombreUsuario));
                guardar.Parameters.Add(new SqlParameter("@contrasenia", contrasenia));
                guardar.Parameters.Add(new SqlParameter("@automatico", automatico));
                if (tarjeta != null)
                {
                    guardar.Parameters.Add(new SqlParameter("@nroTarjeta", Program.sha256(tarjeta.nro)));
                    guardar.Parameters.Add(new SqlParameter("@ultimosDigitos", tarjeta.nro.Substring(tarjeta.nro.Length - 4, 4)));
                    guardar.Parameters.Add(new SqlParameter("@codSeguridad", tarjeta.codSeguridad));
                    guardar.Parameters.Add(new SqlParameter("@mesVencimiento", tarjeta.month));
                    guardar.Parameters.Add(new SqlParameter("@anioVencimiento", tarjeta.year));
                }
                else
                {
                    guardar.Parameters.Add(new SqlParameter("@nroTarjeta", DBNull.Value));
                    guardar.Parameters.Add(new SqlParameter("@ultimosDigitos", DBNull.Value));
                    guardar.Parameters.Add(new SqlParameter("@codSeguridad", DBNull.Value));
                    guardar.Parameters.Add(new SqlParameter("@mesVencimiento", DBNull.Value));
                    guardar.Parameters.Add(new SqlParameter("@anioVencimiento", DBNull.Value));
                }
                SqlParameter ret = new SqlParameter("@ret", DbType.Int32);
                ret.Direction = ParameterDirection.ReturnValue;
                guardar.Parameters.Add(ret);

                guardar.ExecuteNonQuery();
                nuevo = new Cliente((int)ret.Value, nombre, apellido, tipoDocumento, nroDocumento, CUIL, mail, telefono, domicilio, nroCalle, piso, dept, localidad, codPostal, fechaNacimiento, true);
                nuevo.fechaCreacion = fechaCreacion;
            }
            return nuevo;
        }

        override public Cliente UpdateToDataBase(SqlConnection DB)
        {
            string queryString = "UPDATE cheshire_jack.clientes " +
                                 "SET nombre = @nombre, apellido = @apellido, tipo_documento = @tipoDoc, nro_documento = @nroDoc, " +
                                 "CUIL = @CUIL, mail = @mail, telefono = @telefono, domicilio_calle = @domicilio, nro_calle = @nroCalle, " +
                                 "piso = @piso, dept = @dept, localidad = @localidad, codigo_postal = @codPostal, " +
                                 "fecha_creacion = @fechaCreacion, fecha_nacimiento = @fechaNacimiento, habilitado = @habilitado " +
                                 "WHERE cod_cliente = @codCliente";
            using (SqlCommand guardar = new SqlCommand(queryString, DB))
            {
                guardar.Parameters.Add(new SqlParameter("@nombre", nombre));
                guardar.Parameters.Add(new SqlParameter("@apellido", apellido));
                guardar.Parameters.Add(new SqlParameter("@tipoDoc", tipoDocumento));
                guardar.Parameters.Add(new SqlParameter("@nroDoc", nroDocumento));
                guardar.Parameters.Add(new SqlParameter("@CUIL", CUIL));
                guardar.Parameters.Add(new SqlParameter("@mail", mail));
                if(String.IsNullOrWhiteSpace(telefono))
                    guardar.Parameters.Add(new SqlParameter("@telefono", DBNull.Value));
                else
                    guardar.Parameters.Add(new SqlParameter("@telefono", telefono));
                guardar.Parameters.Add(new SqlParameter("@domicilio", domicilio));
                guardar.Parameters.Add(new SqlParameter("@nroCalle", nroCalle));
                if(String.IsNullOrWhiteSpace(piso))
                    guardar.Parameters.Add(new SqlParameter("@piso", DBNull.Value));
                else
                    guardar.Parameters.Add(new SqlParameter("@piso", piso));
                if(String.IsNullOrWhiteSpace(dept))
                    guardar.Parameters.Add(new SqlParameter("@dept", DBNull.Value));
                else
                    guardar.Parameters.Add(new SqlParameter("@dept", dept));
                guardar.Parameters.Add(new SqlParameter("@localidad", localidad));
                guardar.Parameters.Add(new SqlParameter("@codPostal", codPostal));
                guardar.Parameters.Add(new SqlParameter("@fechaCreacion", fechaCreacion));
                guardar.Parameters.Add(new SqlParameter("@fechaNacimiento", fechaNacimiento));
                guardar.Parameters.Add(new SqlParameter("@habilitado", habilitado));
                guardar.Parameters.Add(new SqlParameter("@codCliente", codCliente));

                guardar.ExecuteNonQuery();
            }
            return this;
        }

        public Cliente UpdateValues(string _nombre, string _apellido, string _tipoDocumento,
                       string _nroDocumento, string _CUIL, string _mail, string _telefono,
                       string _domicilio, string _nroCalle, string _piso, string _dept,
                       string _localidad, string _codPostal, DateTime _fechaNacimiento, 
                       DateTime _fechaCreacion, bool _habilitado)
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
            habilitado = _habilitado;
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

        public static byte checkIfExistInDataBase(SqlConnection DB, string tipoDocumento, string nroDocumento, string CUIL)
        {
            byte retorno;
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.existeCliente", Program.DBconn))
            {
                cmd.Parameters.Add(new SqlParameter("@tipoDocumento", tipoDocumento));
                cmd.Parameters.Add(new SqlParameter("@nroDocumento", nroDocumento));
                cmd.Parameters.Add(new SqlParameter("@CUIL", CUIL));
                SqlParameter ret = new SqlParameter("@ret", DbType.Byte);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                retorno = (byte)ret.Value;
            }
            return retorno;
        }
    }
}
