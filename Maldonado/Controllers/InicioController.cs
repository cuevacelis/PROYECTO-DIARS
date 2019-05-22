using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maldonado.Controllers
{
    public class InicioController : Controller
    {
        //
        // GET: /Inicio/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Eventos()
        {
            return View();
        }

        public ActionResult Reservaciones()
        {
            return View();
        }

        public ActionResult Habitaciones()
        {
            return View();
        }
    }
}
