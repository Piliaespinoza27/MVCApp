using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace WebAPP.Models
{
    public class AlumnoDAL
    {
        public List<AlumnoEN> ObtenerAlumnos()
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("CONSULTAR_ALUMNO", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<AlumnoEN> _lista = new List<AlumnoEN>();
            while (_reader.Read())
            {
                AlumnoEN pEN = new AlumnoEN();
                pEN.Id = _reader.GetInt64(0);
                pEN.Nombre = _reader.GetString(1);
                pEN.Apellido = _reader.GetString(2);
                pEN.Edad = _reader.GetInt32(3);
                pEN.Fk_Materia = _reader.GetInt32(4);
                pEN.NombreMateria = _reader.GetString(5);

                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }


        public int EliminarAlumno(AlumnoEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ELIMINAR_ALUMNO", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@ID", en.Id));
            int r = _comand.ExecuteNonQuery();        
            _conn.Close();
            return r;
        }

        public int AgregarAlumno(AlumnoEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("AGREGAR_ALUMNO", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@NOMBRE", en.Nombre));
            _comand.Parameters.Add(new SqlParameter("@APELLIDO", en.Apellido));
            _comand.Parameters.Add(new SqlParameter("@EDAD", en.Edad));
            _comand.Parameters.Add(new SqlParameter("@FK_MATERIA", en.Fk_Materia));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }


        public int Modificar_Alumno(AlumnoEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("Modificar_Alumno", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@id", en.Id));
            _comand.Parameters.Add(new SqlParameter("@nombre", en.Nombre));
            _comand.Parameters.Add(new SqlParameter("@apellido", en.Apellido));
            _comand.Parameters.Add(new SqlParameter("@edad", en.Edad));
            _comand.Parameters.Add(new SqlParameter("@fk_materia", en.Fk_Materia));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }



    }
}