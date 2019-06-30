using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorHospedajeController : Controller
    {
        // GET: MantenedorHospedaje
        public ActionResult Index()
        {
            return RedirectToAction("ListarHospedaje");
        }

        [HttpGet]
        public ActionResult ListarHospedaje()
        {
                List<entHospedaje> lista = logHospedaje.Instancia.ListarHospedaje();
                ViewBag.lista = lista;
                return View(lista);
            //catch (Exception e)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }

        [HttpGet]
        public ActionResult InsertarHospedaje()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];

                List<entPersona> listarPersona = logPersona.Instancia.ListarPersona();
                var lsCliente = new SelectList(listarPersona, "idPersona", "nombreyApellidoPersona");

                List<entHabitacion> listarHabitacion = logHabitacion.Instancia.ListarHabitacion();
                var lsHabitacion = new SelectList(listarHabitacion, "idHabitacion", "numeroHabitacion");

                List<entReserva> listarReserva = logReserva.Instancia.ListarReservas();
                var lsReserva = new SelectList(listarReserva, "idReserva", "EstReserva");

                ViewBag.ListaCliente = lsCliente;
                ViewBag.listaHabitacion = lsHabitacion;
                ViewBag.listarReserva = lsReserva;
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult InsertarHospedaje(entHospedaje H, FormCollection frm)
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];

                H.idPersona = new entPersona();
                H.idHabitacion = new entHabitacion();
                H.idReserva = new entReserva();

                H.idPersona.idPersona = Convert.ToInt32(frm["cboPersona"]);
                H.idHabitacion.idHabitacion = Convert.ToInt32(frm["cboHabitacion"]);
                H.idReserva.idReserva = Convert.ToInt32(frm["cboReserva"]);

                Boolean inserta = logHospedaje.Instancia.InsertarHospedaje(H);

                if (inserta)
                {
                    return RedirectToAction("ListarHospedaje");
                }
                else
                {
                    return View(H);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarHospedaje", new { mesjExceptio = ex.Message });
            }
        }

        public ActionResult EliminarHospedaje(int idHospedaje)
        {
            try
            {
                Boolean elimina = logHospedaje.Instancia.EliminarHospedaje(idHospedaje);

                if (elimina)
                {
                    return RedirectToAction("ListarHospedaje");

                }
                else
                {
                    return View();
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("EliminarHospedaje", new { mesjExceptio = ex.Message });
            }
        }
    }
}