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
            SqlCommand _comand = new SqlCommand("CONSULTAR_ALUMNO", _conn as SqlConnection);
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
    }
}