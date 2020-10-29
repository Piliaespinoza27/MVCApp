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
        // GET: Alumno
        public ActionResult Index()
        {
            AlumnoDAL _dal = new AlumnoDAL();
            ViewBag.Alumnos = _dal.ObtenerAlumnos().ToList();
            return View();
        }
    }
}