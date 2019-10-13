using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRoot.Properties;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TheRoot
{
    class BDConexion
    {
        public static string ObtenerString() {

            return Settings.Default.therootConnectionString;
        }

        public static SqlConnection ObtenerConexion() {

            SqlConnection Conex = new SqlConnection(ObtenerString());
            Conex.Open();
            return Conex;
        }
    }
}
