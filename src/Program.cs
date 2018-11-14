using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PalcoNet
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static public SqlConnection DBconn { get; private set; }
        [STAThread]
        static void Main()
        {
            using(DBconn = new SqlConnection(ConfigurationFile.connectionString()))
            {
                DBconn.Open();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
            }
        }
        public static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(System.Text.Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                if (theByte != 0)
                    hash.Append(theByte.ToString());
            }
            return hash.ToString();
        }
        public static void closeProgram()
        {
            DBconn.Close();
            Environment.Exit(0);
        }
    }

    static class ConfigurationFile
    {
        static public String connectionString()
        {
            return  "Data Source=LAPTOP-U8FGMPHG\\SQLSERVER2012;" +
                    "Initial Catalog=GD2C2018;" +
                    "User ID=gdEspectaculos2018;" +
                    "Password=gd2018";
        }
    }
}
