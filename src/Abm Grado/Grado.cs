using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PalcoNet.Abm_Grado
{
    public class Grado
    {
        public int codGrado;
        public string nombre;
        public byte comision, peso;

        public Grado(int _codGrado, string _nombre, byte _comision, byte _peso)
        {
            codGrado = _codGrado;
            nombre = _nombre;
            comision = _comision;
            peso = _peso;
        }

        public static Grado createInDataBase(SqlConnection DB, string nombre, byte comision, byte peso)
        {
            Grado nuevo;
            using (SqlCommand cmd = new SqlCommand("cheshire_jack.CrearGrado", DB))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@comision", comision / 100.0));
                cmd.Parameters.Add(new SqlParameter("@peso", peso));
                SqlParameter newCode = new SqlParameter("@ret", DbType.Int32);
                newCode.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(newCode);

                cmd.ExecuteNonQuery();
                nuevo = new Grado((int)newCode.Value, nombre, comision, peso);
            }
            return nuevo;
        }

        public Grado updateValues(string _nombre, byte _comision, byte _peso)
        {
            nombre = _nombre;
            comision = _comision;
            peso = _peso;
            return this;
        }

        public Grado updateToDataBase(SqlConnection DB)
        {
            string queryString = "UPDATE cheshire_jack.grados_de_publicacion " +
                                 "SET nombre = @nombre, comision = @comision, peso = @peso " +
                                 "WHERE cod_grado = @codGrado";
            using (SqlCommand cmd = new SqlCommand(queryString, DB))
            {
                cmd.Parameters.Add(new SqlParameter("@codGrado", codGrado));
                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                cmd.Parameters.Add(new SqlParameter("@comision", comision / 100.0));
                cmd.Parameters.Add(new SqlParameter("@peso", peso));

                cmd.ExecuteNonQuery();
            }
            return this;
        }


    }
}
