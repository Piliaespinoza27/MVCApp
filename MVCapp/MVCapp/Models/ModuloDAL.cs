using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace MVCapp.Models
{
    public class ModuloDAL
    {
        public List<ModuloEN> ObtenerModulo()
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("CONSULTAR_MODULO", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<ModuloEN> _lista = new List<ModuloEN>();
            while (_reader.Read())
            {
                ModuloEN pEN = new ModuloEN();
                pEN.Id = _reader.GetInt64(0);
                pEN.Nombre = _reader.GetString(1);
                pEN.Id_Persona = _reader.GetInt64(2);
                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }

        public int EliminarModulo(ModuloEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ELIMINAR_MODULOS", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@ID", en.Id));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }

        public int AgregarModulo(ModuloEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("AGREGAR_MODULOS", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@NOMBRE", en.Nombre));
            _comand.Parameters.Add(new SqlParameter("@IDPERSONA", en.Id_Persona));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }

        public int ModificarModulo(ModuloEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("MODIFICAR_MODULOS", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@ID", en.Id));
            _comand.Parameters.Add(new SqlParameter("@NOMBRE", en.Nombre));
            _comand.Parameters.Add(new SqlParameter("@IDPERSONA", en.Id_Persona));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }
    }
}