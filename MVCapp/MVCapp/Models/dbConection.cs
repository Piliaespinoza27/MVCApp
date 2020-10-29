using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using para trabajar con sql
using System.Data;
using System.Data.SqlClient;

namespace MVCapp.Models
{
    public class dbConection
    {
        const String connectionString = @"Data Source=.;Initial Catalog=ejemploMVC;Integrated Security=True";


        public static IDbConnection Connection()
        {
            IDbConnection conm = null;
            conm = new SqlConnection(connectionString);
            return conm;
        }

        public static IDataParameter Parameters(string name, object objects)
        {
            SqlParameter _parameter = new SqlParameter(name, objects);
            return _parameter;
        }

        public static IDbCommand Sql(string _query)
        {
            SqlCommand comand = new SqlCommand(_query);
            return comand;
        }

        public static int ExecuteQuery(IDbCommand comand)
        {
            int result = 0;
            using (SqlConnection conm = Connection() as SqlConnection)
            {
                try
                {
                    conm.Open();
                    comand.Connection = conm;
                    comand.CommandTimeout = 9000000;
                    result = comand.ExecuteNonQuery();
                    conm.Close();
                }
                catch(Exception ex)
                {
                    result = 0;
                }
            }
            return result;
        }

        public static IDataReader Reader(IDbCommand command)
        {
            IDataReader reader = null;
            try
            {
                command.Connection = Connection();
                command.Connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(Exception ex)
            {
                reader = null;
            }
            return reader;
        }
    }
}