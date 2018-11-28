using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet
{
    public class Usuario
    {
        public int codUsuario;
        public string usuario, contrasenia;

        public Usuario(int _codUsuario, string _usuario, string _contrasenia)
        {
            codUsuario = _codUsuario;
            usuario = _usuario;
            contrasenia = _contrasenia;
        }

        public Usuario UpdatePassword(SqlConnection DB)
        {
            using (SqlCommand cmd = new SqlCommand("cambiarContrasenia", DB))
            {
                cmd.Parameters.Add(new SqlParameter("@codUsuario", codUsuario));
                cmd.Parameters.Add(new SqlParameter("@nuevaContrasenia", Program.sha256(contrasenia)));
                cmd.ExecuteNonQuery();
            }
            return this;
        }
        public static Usuario CreateToDataBase(SqlConnection DB, string nombre,string contraseñia, bool automatico = true)
        {
            Usuario nuevo;
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.crearUsuario", DB))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombreUsuario", nombre));
                cmd.Parameters.Add(new SqlParameter("@contrasenia", Program.sha256(contraseñia)));
                cmd.Parameters.Add(new SqlParameter("@automatico", automatico));
                SqlParameter ret = new SqlParameter("@ret", DbType.Int32);
                ret.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ret);

                cmd.ExecuteNonQuery();

                nuevo = new Usuario((int)ret.Value, nombre, contraseñia);
            }
            return nuevo;
        }
    }

    public abstract class TipoDeUsuario<T>
    {
        public abstract T UpdateToDataBase(SqlConnection DB);
    }
}
