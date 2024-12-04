using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnection()
        {

            string con = System.Configuration.ConfigurationManager.ConnectionStrings["SBecerraProgramacionNCapas"].ConnectionString;
            return con;

        }
    }
}
