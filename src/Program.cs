using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

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
                DBconn.Close();
            }
        }
        public static string sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
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

        public static DialogResult openNextWindow(Form self, Form next)
        {
            self.Hide();
            DialogResult ret = next.ShowDialog();
            next.Dispose();
            self.Show();
            return ret;
        }
        
        public static DialogResult openPopUpWindow(Form self, Form window)
        {
            self.Enabled = false;
            DialogResult ret = window.ShowDialog();
            window.Dispose();
            self.Enabled = true;
            return ret;
        }

        public static string getRandomPassword(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder("");
            Random random = new Random();

            foreach (int i in Enumerable.Range(1, length))
                builder.Append(chars[random.Next(0, chars.Length)]);

            return builder.ToString();
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
