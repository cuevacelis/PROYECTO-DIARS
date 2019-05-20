using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorReservaController : Controller
    {
        //
        // GET: /MantenedorReserva/

        public ActionResult Index()
        {
            return RedirectToAction("ListarReservas");
        }

        [HttpGet]
        public ActionResult ListarReservas()
        {
            List<entReserva> lista = logReserva.Instancia.ListarReservas();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult InsertarReserva()
        {
            List<entCliente> listarCliente = logCliente.Instancia.ListarCliente();
            var lsCliente = new SelectList(listarCliente, "idCliente", "nombreCliente");

            List<entHabitacion> listarHabitacion = logHabitacion.Instancia.ListarHabitacion();
            var lsHabitacion = new SelectList(listarHabitacion, "idHabitacion", "numeroHabitacion");

            ViewBag.ListaCliente = lsCliente;
            ViewBag.listaHabitacion = lsHabitacion;
            return View();
        }

        [HttpPost]
        public ActionResult InsertarReserva(entReserva R, FormCollection frm)
        {
            try
            {
                R.idCliente = new entCliente();
                R.idHabitacion = new entHabitacion();

                R.idCliente.idCliente = Convert.ToInt32(frm["cboCliente"]);
                R.idHabitacion.idHabitacion = Convert.ToInt32(frm["cboHabitacion"]);

                Boolean inserta = logReserva.Instancia.InsertarReserva(R);

                if (inserta)
                {
                    return RedirectToAction("ListarReservas");
                }
                else
                {
                    return View(R);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarReserva", new { mesjExceptio = ex.Message });
            }
        }
    }
}
