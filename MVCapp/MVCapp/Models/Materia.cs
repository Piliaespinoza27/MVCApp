using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class Materia
    {
        public int Id { get; set; }

        public string nombre { get; set; }

        //Metodo para guardar

        public static int Create(Materia materia)
        {
            string sql = @"insert into materi(nombre) values(@nombre)";
            var executeSql = dbConection.Sql(sql);
            executeSql.Parameters.Add(dbConection.Parameters("nombre", materia.nombre));
            return dbConection.ExecuteQuery(executeSql);
        }

        public static List<Materia> mostrarMateria()
        {
            List<Materia> lista = new List<Materia>();
            string sql = @"select id, nombre from materia";
            var executeSql = dbConection.Sql(sql);
            using (var reader = dbConection.Reader(executeSql))
            {
                if(reader !=null)
                {
                    while(reader.Read())
                    {
                        lista.Add(new Materia
                        {
                            Id = reader.GetInt32(0),
                            nombre = reader.GetString(1)
                        });
                    }
                }
            }
            return lista;
        }

        public static int Delete(Materia materia)
        {
            string sql = @"delete from materia where id=@id";
            var executeSql = dbConection.Sql(sql);
            executeSql.Parameters.Add(dbConection.Parameters("id", materia.Id));
            return dbConection.ExecuteQuery(executeSql);
        }

        public static int Update(Materia materia)
        {
            string sql = @"Update materia set nombre=@nombre where id=@id";
            var executeSql = dbConection.Sql(sql);
            executeSql.Parameters.Add(dbConection.Parameters("id", materia.Id));
            executeSql.Parameters.Add(dbConection.Parameters("nombre", materia.nombre));
            return dbConection.ExecuteQuery(executeSql);
        }

        public static Materia obtenerMateriaPorId(Materia materia)
        {
            string sql = @"select id, nombre from materia where id=@id";
            var executeSql = dbConection.Sql(sql);
            executeSql.Parameters.Add(dbConection.Parameters("id", materia.Id));
            Materia datosmateria = new Materia();

            using (var reader = dbConection.Reader(executeSql))
            {
                if(reader !=null)
                {
                    while(reader.Read())
                    {
                        datosmateria = new Materia
                        {
                            Id = reader.GetInt32(0),
                            nombre = reader.GetString(1)
                        };
                    }
                }
            }
            return datosmateria;
        }
    }
}