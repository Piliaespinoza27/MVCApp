using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models
{
    public class AlumnoEN
    {
        public Int64 Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Int64 Edad { get; set; }
        public Int64 Fk_Materia { get; set; }
        public string NombreMateria { get; set; }
    }
}