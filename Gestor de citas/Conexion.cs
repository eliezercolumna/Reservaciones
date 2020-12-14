using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gestor_de_citas
{
    class Conexion
    {
        public static MySqlConnection conectar()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "gestor_cita";
            MySqlConnection cn = new MySqlConnection(builder.ToString());
            return cn;
        }
    }
}

