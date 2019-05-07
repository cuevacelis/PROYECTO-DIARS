using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorHabitacionController : Controller
    {
        //
        // GET: /MantenedorHabitacion/

        public ActionResult Index()
        {
            return RedirectToAction("ListarHabitacion");
        }

        [HttpGet]
        public ActionResult ListarHabitacion()
        {
            List<entHabitacion> lista = logHabitacion.Instancia.ListarHabitacion();
            ViewBag.lista = lista;
            return View(lista);
        }
    }
}
