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

        [HttpGet]
        public ActionResult InsertarCliente()
        {
            List<entTipoCliente> listarTipoCliente = logTipoCliente.Instancia.ListarTipoCliente();
            var lsTipoCliente = new SelectList(listarTipoCliente, "idTipoCliente", "DesTipoCliente");
            

            ViewBag.listaTipoCliente = lsTipoCliente;
            return View();
        }

        [HttpPost]
        public ActionResult InsertarCliente(entCliente C, FormCollection frm)
        {
            try
            {
                C.idTipoCliente = new entTipoCliente();

                C.idTipoCliente.idTipoCliente = Convert.ToInt32(frm["cboTipoCliente"]);

                Boolean inserta = logCliente.Instancia.InsertarCliente(C);

                if (inserta)
                {
                    return RedirectToAction("ListarCliente");
                }
                else
                {
                    return View(C);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarCliente", new { mesjExceptio = ex.Message });
            }
        }
    }
}
