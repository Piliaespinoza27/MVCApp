using MVCapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVCapp.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(int Id)
        {
            ViewBag.Materia = Materia.obtenerMateriaPorId(new Materia { Id = Id });
            return View();
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Materia = Materia.obtenerMateriaPorId(new Materia {Id = id });
            return View();
        }

        public ActionResult View(int id)
        {
            ViewBag.Materia = Materia.obtenerMateriaPorId(new Materia { Id = id });
            return View();
        }


        JavaScriptSerializer json = new JavaScriptSerializer();

       [HttpPost]

        public int Guardar (Materia materia)
        {
            return Materia.Create(materia);
        }
        [HttpPost]

        public int Modificar (Materia materia)
        {
            return Materia.Update(materia);
        }

        public string Lista()
        {
            return json.Serialize(Materia.mostrarMateria());
        }

        public int Eliminar (Materia materia)
        {
            return Materia.Delete(materia);
        }

        public string obtenerMateriaPorId(Materia materia)
        {
            return json.Serialize(Materia.obtenerMateriaPorId(materia));
        }
    }
}