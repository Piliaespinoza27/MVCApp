using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace MVCapp.Models
{
    public class PersonaDAL
    {
        public List<PersonaEN> ObtenerPersona()
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("CONSULTAR_PERSONA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            IDataReader _reader = _comand.ExecuteReader();
            List<PersonaEN> _lista = new List<PersonaEN>();
            while (_reader.Read())
            {
                PersonaEN pEN = new PersonaEN();
                pEN.Id = _reader.GetInt64(0);
                pEN.Nombres = _reader.GetString(1);
                pEN.Apellidos = _reader.GetString(2);
                pEN.Id_Tipo_Persona = _reader.GetInt64(3);


                _lista.Add(pEN);
            }
            _conn.Close();
            return _lista;
        }

        public int EliminarPersona(PersonaEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("ELIMINAR_PERSONA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@ID", en.Id));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }

        public int AgregarPersona(PersonaEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("AGREGAR_PERSONA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@NOMBRES", en.Nombres));
            _comand.Parameters.Add(new SqlParameter("@APELLIDOS", en.Apellidos));
            _comand.Parameters.Add(new SqlParameter("@IDTIPOPERSONA", en.Id_Tipo_Persona));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }

        public int ModificarPersona(PersonaEN en)
        {
            IDbConnection _conn = DBCommon.Conexion();
            _conn.Open();
            SqlCommand _comand = new SqlCommand("MODIFICAR_PERSONA", _conn as SqlConnection);
            _comand.CommandType = CommandType.StoredProcedure;
            _comand.Parameters.Add(new SqlParameter("@ID", en.Id));
            _comand.Parameters.Add(new SqlParameter("@NOMBRES", en.Nombres));
            _comand.Parameters.Add(new SqlParameter("@APELLIDOS", en.Apellidos));
            _comand.Parameters.Add(new SqlParameter("@IDTIPOPERSONA", en.Id_Tipo_Persona));
            int r = _comand.ExecuteNonQuery();
            _conn.Close();
            return r;
        }
    }
}