using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    public class AlumnoController : Controller
    {
        AlumnoDAL _dal = new AlumnoDAL();
        MateriaDAL _dalM = new MateriaDAL();
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarAlumno()
        {
            return View();
        }


        public ActionResult Materia()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ObtenerAlumnos()
        {
            return Json(_dal.ObtenerAlumnos().ToList());
        }

        [HttpPost]
        public ActionResult EliminarAlumnos(AlumnoEN en)
        {
            return Content(Convert.ToString(_dal.EliminarAlumno(en)));
        }

        [HttpPost]
        public ActionResult AgregarAlumnos(AlumnoEN en)
        {
            return Content(Convert.ToString(_dal.AgregarAlumno(en)));
        }

        [HttpPost]
        public JsonResult ObtenerMaterias()
        {
            return Json(_dalM.ObtenerMaterias().ToList());
        }

        [HttpPost]
        public ActionResult Modificar_Alumno (AlumnoEN en)
        {
            return Content(Convert.ToString(_dal.Modificar_Alumno(en)));
        }
    }
}