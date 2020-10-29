using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebAPP.Models
{
    public class DBCommon
    {
        private static string Conn = @"Data Source=.;Initial Catalog=ejemploMVC;Integrated Security=True";

        public static IDbConnection Conexion()
        {
            return new SqlConnection(Conn);
        }
        public static IDbCommand ObtenerComando(string pComando, IDbConnection pConn)
        {
            return new SqlCommand(pComando, pConn as SqlConnection);
        }
    }
}