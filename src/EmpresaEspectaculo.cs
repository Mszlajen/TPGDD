using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet
{
    public class EmpresaEspectaculo : TipoDeUsuario<EmpresaEspectaculo>
    {
        public int codEmpresa, codUsuario;
        public string nombre, telefono, mail, domicilio, 
               altura, piso, departamento, ciudad, 
               codigoPostal, CUIT;
        public bool habilitado;
        public EmpresaEspectaculo(int _codEmpresa, string _nombre, string _telefono, string _mail,
                                  string _domicilio, string _altura, string _piso, string _departamento,
                                  string _ciudad, string _codigoPostal, string _CUIT, int codUsuario, 
                                  bool _habilitado = true)
        {
            codEmpresa = _codEmpresa;
            nombre = _nombre;
            telefono = checkUndefined(_telefono);
            mail = _mail;
            domicilio = _domicilio;
            altura = _altura;
            piso = _piso;
            departamento = _departamento;
            ciudad = checkUndefined(_ciudad);
            codigoPostal = _codigoPostal;
            CUIT = _CUIT;
            habilitado = _habilitado;
        }

        public EmpresaEspectaculo updateValues(string _nombre, string _telefono, string _mail,
                                  string _domicilio, string _altura, string _piso, string _departamento,
                                  string _ciudad, string _codigoPostal, string _CUIT, bool _habilitado)
        {
            nombre = _nombre;
            telefono = checkUndefined(_telefono);
            mail = _mail;
            domicilio = _domicilio;
            altura = _altura;
            piso = _piso;
            departamento = _departamento;
            ciudad = checkUndefined(_ciudad);
            codigoPostal = _codigoPostal;
            CUIT = _CUIT;
            habilitado = _habilitado;
            return this;
        }

        override public EmpresaEspectaculo UpdateToDataBase(SqlConnection DB)
        {
            string queryString = "UPDATE cheshire_jack.empresas " +
                "SET ciudad = @ciudad, domicilio_calle = @domicilio, " +
                "nro_calle = @altura, piso = @piso, dept = @dept, " +
                "codigo_postal = @codigoPostal, mail = @mail, CUIT = @CUIT " +
                "WHERE cod_empresa = @codEmpresa";

            using (SqlCommand cmd = new SqlCommand(queryString, DB))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ciudad", ciudad));
                cmd.Parameters.Add(new SqlParameter("@domicilio", domicilio));
                cmd.Parameters.Add(new SqlParameter("@altura", altura));
                cmd.Parameters.Add(new SqlParameter("@piso", piso));
                cmd.Parameters.Add(new SqlParameter("@dept", departamento));
                cmd.Parameters.Add(new SqlParameter("@codigoPostal", codigoPostal));
                cmd.Parameters.Add(new SqlParameter("@mail", mail));
                cmd.Parameters.Add(new SqlParameter("@CUIT", CUIT));
                cmd.Parameters.Add(new SqlParameter("@codEmpresa", codEmpresa));
            }
            return this;
        }

        public static EmpresaEspectaculo CreateToDataBase(SqlConnection DB, string nombre, string telefono, string mail,
                                  string domicilio, string altura, string piso, string departamento,
                                  string ciudad, string codigoPostal, string CUIT, int codUsuario)
        {
            EmpresaEspectaculo nueva;
            using(SqlCommand cmd = new SqlCommand("cheshire_jack.CrearEmpresa", DB))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codUsuario", codUsuario));
                cmd.Parameters.Add(new SqlParameter("@ciudad", ciudad));
                cmd.Parameters.Add(new SqlParameter("@domicilio", domicilio));
                cmd.Parameters.Add(new SqlParameter("@altura", altura));
                cmd.Parameters.Add(new SqlParameter("@piso", piso));
                cmd.Parameters.Add(new SqlParameter("@dept", departamento));
                cmd.Parameters.Add(new SqlParameter("@codigoPostal", codigoPostal));
                cmd.Parameters.Add(new SqlParameter("@mail", mail));
                cmd.Parameters.Add(new SqlParameter("@CUIT", CUIT));
                SqlParameter ret = new SqlParameter("@ret", DbType.Int32);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);
                nueva = new EmpresaEspectaculo((int)ret.Value, nombre, telefono, mail, domicilio, altura, piso, departamento, ciudad, codigoPostal, CUIT, codUsuario);
            }
            return nueva;
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

        private string checkUndefined(string toCheck)
        {
            return String.IsNullOrWhiteSpace(toCheck) ? "S. D." : toCheck;
        }
    }
}
