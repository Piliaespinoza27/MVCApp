using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCapp.Models;


namespace MVCapp.Controllers
{
    public class TipoPersonaController : Controller
    {
        TipoPersonaDAL _dal = new TipoPersonaDAL();

        // GET: Materia
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarTipoPersona()
        {
            return View();
        }


        public ActionResult Tipo_Persona()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ObtenerTipoPersona()
        {
            return Json(_dal.ObtenerTipoPersona().ToList());
        }

        [HttpPost]
        public ActionResult EliminarTipoPersona(TipoPersonaEN en)
        {
            return Content(Convert.ToString(_dal.EliminarTipoPersona(en)));
        }

        [HttpPost]
        public ActionResult AgregarTipoPersona(TipoPersonaEN en)
        {
            return Content(Convert.ToString(_dal.AgregarTipoPersona(en)));
        }


        [HttpPost]
        public ActionResult ModificarTipoPersona(TipoPersonaEN en)
        {
            return Content(Convert.ToString(_dal.ModificarTipoPersona(en)));
        }
    }
}