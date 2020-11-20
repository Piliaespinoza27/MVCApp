using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapp.Models;

namespace MVCapp.Controllers
{
    public class PersonaController : Controller
    {
        PersonaDAL _dal = new PersonaDAL();
        TipoPersonaDAL _dalM = new TipoPersonaDAL();
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarPersona()
        {
            return View();
        }


        public ActionResult Persona()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ObtenerPersona()
        {
            return Json(_dal.ObtenerPersona().ToList());
        }

        [HttpPost]
        public ActionResult EliminarPersona(PersonaEN en)
        {
            return Content(Convert.ToString(_dal.EliminarPersona(en)));
        }

        [HttpPost]
        public ActionResult AgregarPersona(PersonaEN en)
        {
            return Content(Convert.ToString(_dal.AgregarPersona(en)));
        }

        [HttpPost]
        public JsonResult ObtenerTipoPersona()
        {
            return Json(_dalM.ObtenerTipoPersona().ToList());
        }

        [HttpPost]
        public ActionResult ModificarPersona(PersonaEN en)
        {
            return Content(Convert.ToString(_dal.ModificarPersona(en)));
        }
    }
}