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
    }
}