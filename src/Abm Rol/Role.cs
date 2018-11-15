using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.Abm_Rol
{
    class Role
    {
        public int codigo;
        public string nombre;
        public bool habilitado, registrable;

        public Role(int _codigo, string _nombre, bool _habilitado, bool _registrable)
        {
            codigo = _codigo;
            nombre = _nombre;
            habilitado = _habilitado;
            registrable = _registrable;
        }

        public Role updateValues(string _nombre, bool _habilitado, bool _registrable)
        {
            nombre = _nombre;
            habilitado = _habilitado;
            registrable = _registrable;
            return this;
        }

        public Role saveToDataBaseAsNew(SqlConnection DB)
        {
            return Role.createInDataBase(DB, nombre, habilitado, registrable);
        }

        public static Role createInDataBase(SqlConnection DB, string nombre, bool habilitado, bool registrable)
        {
            Role nuevo;
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.CrearRol", DB))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@descripcion", nombre));
                cmd.Parameters.Add(new SqlParameter("@habilitado", habilitado));
                cmd.Parameters.Add(new SqlParameter("@registrable", registrable));
                SqlParameter newCode = new SqlParameter("@ret", DbType.Int16);
                newCode.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(newCode);

                cmd.ExecuteNonQuery();
                nuevo = new Role((int) newCode.Value, nombre, habilitado, registrable);
            }
            return nuevo;
        }

        public Role updateToDataBase(SqlConnection DB)
        {
            string queryString = "UPDATE cheshire_jack.roles " +
                                 "SET descripcion = @descripcion, habilitado = @habilitado, registrable = @registrable " +
                                 "WHERE cod_rol = @codRol";
            using (SqlCommand cmd = new SqlCommand(queryString, DB))
            {
                cmd.Parameters.Add(new SqlParameter("@codRol", codigo));
                cmd.Parameters.Add(new SqlParameter("@descripcion", nombre));
                cmd.Parameters.Add(new SqlParameter("@habilitado", habilitado));
                cmd.Parameters.Add(new SqlParameter("@registrable", registrable));

                cmd.ExecuteNonQuery();
            }
            return this;
        }

        public void updateFunctionsToDataBase(SqlConnection DB, List<int> codigos_funcionalidades)
        {
            string concat = "";
            foreach (int code in codigos_funcionalidades)
                concat += code.ToString() + " ";
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.UpdateRolesXFuncionalidades", DB))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@cod_rol", codigo));
                cmd.Parameters.Add(new SqlParameter("@funcionalidades", concat));
                cmd.ExecuteNonQuery();
            }
        }

        public void removeFromUsers(SqlConnection DB)
        {
            string queryString = "DELETE FROM cheshire_jack.usuariosXRoles WHERE cod_rol = @cod_rol";
            using (SqlCommand cmd = new SqlCommand(queryString, DB))
            {
                cmd.Parameters.Add(new SqlParameter("@cod_rol", codigo));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
