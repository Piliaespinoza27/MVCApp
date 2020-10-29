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
        // GET: Materia
        public ActionResult Index()
        {
            MateriaDAL _dal = new MateriaDAL();
            ViewBag.Materia = _dal.ObtenerMaterias().ToList();
            return View();
        }
    }
}