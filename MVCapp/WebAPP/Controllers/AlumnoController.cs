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
        // GET: Alumno
        public ActionResult Index()
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

    }
}