using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorClienteController : Controller
    {
        //
        // GET: /MantenedorCliente/

        public ActionResult Index()
        {
            return RedirectToAction("ListarCliente");
        }

        [HttpGet]
        public ActionResult ListarCliente()
        {
            List<entCliente> lista = logCliente.Instancia.ListarCliente();
            ViewBag.lista = lista;
            return View(lista);
        }
    }
}
