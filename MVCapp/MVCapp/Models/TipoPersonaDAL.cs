using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace MVCapp.Models
{
    public class TipoPersonaDAL
    {
        public List<TipoPersonaEN> ObtenerTipoPersona()
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("CONSULTAR_TIPOPERSONA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<TipoPersonaEN> _lista = new List<TipoPersonaEN>();
            while (_reader.Read())
            {
                TipoPersonaEN pEN = new TipoPersonaEN();
                pEN.Id = _reader.GetInt64(0);
                pEN.Nombre = _reader.GetString(1);
                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }

        public int EliminarTipoPersona(TipoPersonaEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ELIMINAR_TIPOPERSONA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@ID", en.Id));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }

        public int AgregarTipoPersona(TipoPersonaEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("AGREGAR_TIPOPERSONA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@ID", en.Id));
            _comand.Parameters.Add(new SqlParameter("@NOMBRE", en.Nombre));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }

        public int ModificarTipoPersona(TipoPersonaEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("MODIFICAR_TIPOPERSONA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@ID", en.Id));
            _comand.Parameters.Add(new SqlParameter("@NOMBRE", en.Nombre));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }


    }
}