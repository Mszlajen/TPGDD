using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet
{
    public class EmpresaEspectaculo : DatosUsuario
    {
        public int codEmpresa;
        public string nombre, telefono, mail, domicilio, 
               altura, piso, departamento, ciudad, 
               codigoPostal, CUIT;
        public bool habilitado;
        
        public EmpresaEspectaculo()
        { }
        public EmpresaEspectaculo(int _codEmpresa, string _nombre, string _telefono, string _mail,
                                  string _domicilio, string _altura, string _piso, string _departamento,
                                  string _ciudad, string _codigoPostal, string _CUIT, 
                                  bool _habilitado = true)
        {
            codEmpresa = _codEmpresa;
            nombre = _nombre;
            telefono = _telefono;
            mail = _mail;
            domicilio = _domicilio;
            altura = _altura;
            piso = _piso;
            departamento = _departamento;
            ciudad = _ciudad;
            codigoPostal = _codigoPostal;
            CUIT = _CUIT;
            habilitado = _habilitado;
        }

        public EmpresaEspectaculo updateValues(string _nombre, string _telefono, string _mail,
                                  string _domicilio, string _altura, string _piso, string _departamento,
                                  string _ciudad, string _codigoPostal, string _CUIT, bool _habilitado)
        {
            nombre = _nombre;
            telefono = _telefono;
            mail = _mail;
            domicilio = _domicilio;
            altura = _altura;
            piso = _piso;
            departamento = _departamento;
            ciudad = _ciudad;
            codigoPostal = _codigoPostal;
            CUIT = _CUIT;
            habilitado = _habilitado;
            return this;
        }

        public EmpresaEspectaculo UpdateToDataBase(SqlConnection DB)
        {
            string queryString = "UPDATE cheshire_jack.empresas " +
                "SET ciudad = @ciudad, domicilio_calle = @domicilio, " +
                "nro_calle = @altura, piso = @piso, dept = @dept, " +
                "codigo_postal = @codigoPostal, mail = @mail, CUIT = @CUIT, " +
                "telefono = @telefono, habilitado = @habilitado WHERE cod_empresa = @codEmpresa";

            using (SqlCommand cmd = new SqlCommand(queryString, DB))
            {
                cmd.Parameters.Add(new SqlParameter("@ciudad", ciudad));
                cmd.Parameters.Add(new SqlParameter("@domicilio", domicilio));
                cmd.Parameters.Add(new SqlParameter("@altura", altura));
                if (String.IsNullOrWhiteSpace(piso))
                    cmd.Parameters.Add(new SqlParameter("@piso", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@piso", piso));
                if (String.IsNullOrWhiteSpace(departamento))
                    cmd.Parameters.Add(new SqlParameter("@dept", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@dept", departamento));
                cmd.Parameters.Add(new SqlParameter("@codigoPostal", codigoPostal));
                cmd.Parameters.Add(new SqlParameter("@mail", mail));
                cmd.Parameters.Add(new SqlParameter("@CUIT", CUIT));
                if(String.IsNullOrWhiteSpace(telefono))
                    cmd.Parameters.Add(new SqlParameter("@telefono", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
                cmd.Parameters.Add(new SqlParameter("@habilitado", habilitado));
                cmd.Parameters.Add(new SqlParameter("@codEmpresa", codEmpresa));
                cmd.ExecuteNonQuery();
            }
            return this;
        }

        override public DatosUsuario CreateToDataBase
            (SqlConnection DB, string nombreUsuario, string contrasenia, bool automatico)
        {

            return EmpresaEspectaculo.CreateToDataBase
                (DB, nombre, telefono, mail, domicilio, altura, piso, departamento, 
                ciudad, codigoPostal, CUIT, nombreUsuario, contrasenia, automatico);
        }

        public static EmpresaEspectaculo CreateToDataBase(SqlConnection DB, string nombre, string telefono, string mail,
                                  string domicilio, string altura, string piso, string departamento,
                                  string ciudad, string codigoPostal, string CUIT, string usuario, 
                                  string contrasenia, bool automatico)
        {
            EmpresaEspectaculo nueva;
            using(SqlCommand cmd = new SqlCommand("cheshire_jack.crearEmpresa", DB))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombreUsuario", usuario));
                cmd.Parameters.Add(new SqlParameter("@contrasenia", contrasenia));
                cmd.Parameters.Add(new SqlParameter("@automatico", automatico));
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                if(String.IsNullOrWhiteSpace(telefono))
                    cmd.Parameters.Add(new SqlParameter("@telefono", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
                cmd.Parameters.Add(new SqlParameter("@ciudad", ciudad));
                cmd.Parameters.Add(new SqlParameter("@domicilio", domicilio));
                cmd.Parameters.Add(new SqlParameter("@altura", altura));
                if(String.IsNullOrWhiteSpace(piso))
                    cmd.Parameters.Add(new SqlParameter("@piso", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@piso", piso));
                if(String.IsNullOrWhiteSpace(departamento))
                    cmd.Parameters.Add(new SqlParameter("@dept", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@dept", departamento));
                cmd.Parameters.Add(new SqlParameter("@codigoPostal", codigoPostal));
                cmd.Parameters.Add(new SqlParameter("@mail", mail));
                cmd.Parameters.Add(new SqlParameter("@CUIT", CUIT));
                SqlParameter ret = new SqlParameter("@ret", DbType.Int32);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);

                cmd.ExecuteNonQuery();
                nueva = new EmpresaEspectaculo((int)ret.Value, nombre, telefono, mail, domicilio, altura, piso, departamento, ciudad, codigoPostal, CUIT);
            }
            return nueva;
        }
        public static byte checkIfExistInDataBase(SqlConnection DB, string nombre, string CUIT)
        {
            byte existe;
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.existeEmpresa", DB))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@razonSocial", nombre)); 
                cmd.Parameters.Add(new SqlParameter("@CUIT", CUIT));
                SqlParameter ret = new SqlParameter("@ret", DbType.Boolean);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);

                cmd.ExecuteNonQuery();

                existe = (byte) ret.Value;
            }
            return existe;
        }

        public static bool CheckCUIT(string CUIT)
        {
            char[] separador = { '-' };
            string[] partesDeCUIT = CUIT.Split(separador);
            
            string[] tipos = {"30", "33", "34"};
            if(!tipos.Contains(partesDeCUIT[0]))
                return false;

            int digitoVerificador = 0, i = 0;
            int[] secuencia = { 2, 3, 4, 5, 6, 7, 2, 3, 4, 5 };
            foreach (char digito in (partesDeCUIT[0] + partesDeCUIT[1]).Reverse())
            {
                digitoVerificador += int.Parse(digito.ToString()) * secuencia[i];
                i++;
            }

            digitoVerificador %= 11;
            digitoVerificador = 11 - digitoVerificador;
            digitoVerificador = digitoVerificador == 11 ? 0 : digitoVerificador;

            return digitoVerificador.ToString() == partesDeCUIT[2];
        }
    }
}
