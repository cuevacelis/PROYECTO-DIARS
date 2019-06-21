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
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.tipo == true)
                {
                    List<entReserva> lista = logReserva.Instancia.ListarReservas();
                    ViewBag.lista = lista;
                    return View(lista);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult InsertarReserva()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.tipo == true)
                {
                    List<entPersona> listarCliente = logCliente.Instancia.ListarCliente();
                    var lsCliente = new SelectList(listarCliente, "idCliente", "nombreCliente");

                    List<entHabitacion> listarHabitacion = logHabitacion.Instancia.ListarHabitacion();
                    var lsHabitacion = new SelectList(listarHabitacion, "idHabitacion", "numeroHabitacion");

                    ViewBag.ListaCliente = lsCliente;
                    ViewBag.listaHabitacion = lsHabitacion;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult InsertarReserva(entReserva R, FormCollection frm)
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.tipo == true)
                {
                    R.idCliente = new entPersona();
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
                else
                {
                    return RedirectToAction("Index", "Login");
                }
                
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarReserva", new { mesjExceptio = ex.Message });
            }
        }
        public ActionResult EliminarReserva(int idReserva)
        {
            try
            {

                Boolean elimina = logReserva.Instancia.EliminarReserva(idReserva);

                if (elimina)
                {
                    return RedirectToAction("listarReservas");

                }
                else
                {
                    return View();
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarReserva", new { mesjExceptio = ex.Message });
            }

        }
    }
}
