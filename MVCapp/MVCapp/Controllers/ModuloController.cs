using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapp.Models;

namespace MVCapp.Controllers
{
    public class ModuloController : Controller
    {
        ModuloDAL _dal = new ModuloDAL();
        PersonaDAL _dalM = new PersonaDAL();
        // GET: Modulo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarModulo()
        {
            return View();
        }


        public ActionResult Modulo()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ObtenerModulo()
        {
            return Json(_dal.ObtenerModulo().ToList());
        }

        [HttpPost]
        public ActionResult EliminarModulo(ModuloEN en)
        {
            return Content(Convert.ToString(_dal.EliminarModulo(en)));
        }

        [HttpPost]
        public ActionResult AgregarModulo(ModuloEN en)
        {
            return Content(Convert.ToString(_dal.AgregarModulo(en)));
        }

        [HttpPost]
        public JsonResult ObtenerPersona()
        {
            return Json(_dalM.ObtenerPersona().ToList());
        }

        [HttpPost]
        public ActionResult ModificarModulo(ModuloEN en)
        {
            return Content(Convert.ToString(_dal.ModificarModulo(en)));
        }
    }
}