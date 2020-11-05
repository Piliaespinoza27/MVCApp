using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace WebAPP.Models
{
    public class MateriaDAL
    {
        public List<MateriaEN> ObtenerMaterias()
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("CONSULTAR_MATERIA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<MateriaEN> _lista = new List<MateriaEN>();
            while (_reader.Read())
            {
                MateriaEN pEN = new MateriaEN();
                pEN.Id = _reader.GetInt32(0);
                pEN.Nombre = _reader.GetString(1);
                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }

        public int EliminarMateria(MateriaEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ELIMINAR_MATERIA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@id", en.Id));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }

        public int AgregarMateria(MateriaEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("[AGREGAR_MATERIA]", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@id", en.Id));
            _comand.Parameters.Add(new SqlParameter("@nombre", en.Nombre));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }


        public int ModificarMateria(MateriaEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("MODIFICAR_MATERIA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@id", en.Id));
            _comand.Parameters.Add(new SqlParameter("@nombre", en.Nombre));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }
    }
}