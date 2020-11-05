using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    public class MateriaController : Controller
    {
        MateriaDAL _dalM = new MateriaDAL();

        // GET: Materia
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarMateria()
        {
            return View();
        }


        public ActionResult Materia()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ObtenerMaterias()
        {
            return Json(_dalM.ObtenerMaterias());
        }

        [HttpPost]
        public ActionResult EliminarMateria(MateriaEN en)
        {
            return Content(Convert.ToString(_dalM.EliminarMateria(en)));
        }

        [HttpPost]
        public ActionResult AgregarMateria(MateriaEN en)
        {
            return Content(Convert.ToString(_dalM.AgregarMateria(en)));
        }

        [HttpPost]
        public ActionResult ModificarMateria(MateriaEN en)
        {
            return Content(Convert.ToString(_dalM.ModificarMateria(en)));
        }
    }
}