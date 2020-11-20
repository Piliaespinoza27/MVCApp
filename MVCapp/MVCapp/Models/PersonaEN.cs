using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCapp.Models
{
    public class PersonaEN
    {
        public long Id { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public long Id_Tipo_Persona { get; set; }

    }
}