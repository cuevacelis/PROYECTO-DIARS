﻿using System;
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
                if (u.idPersona.idTipoPersona.desTipoPersona.Equals("Gerente") || u.idPersona.idTipoPersona.desTipoPersona.Equals("Recepcionista"))
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
        public ActionResult ListarReservas_Por_Usuario()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.idPersona.idTipoPersona.desTipoPersona.Equals("Gerente") || u.idPersona.idTipoPersona.desTipoPersona.Equals("Recepcionista"))
                {
                    List<entReserva> lista = logReserva.Instancia.ListarReservas_Por_Usuario(u);
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
                if (u.idPersona.idTipoPersona.desTipoPersona.Equals("Gerente") || u.idPersona.idTipoPersona.desTipoPersona.Equals("Recepcionista"))
                {
                    List<entCliente> listarCliente = logCliente.Instancia.ListarCliente();
                    var lsCliente = new SelectList(listarCliente, "idPersona.idPersona", "idPersona.nombreyApellidoPersona");

                    List<entTipoHabitacion> listarTipoHabitacion = logTipoHabitacion.Instancia.ListarTipoHabitacion();
                    var lsTipoHabitacion = new SelectList(listarTipoHabitacion, "idTipoHabitacion", "DesTipoHabitacion");

                    List<entHabitacion> listarHabitacion = logHabitacion.Instancia.ListarHabitacion();
                    var lsHabitacion = new SelectList(listarHabitacion, "idHabitacion", "numeroHabitacion");

                    ViewBag.ListaCliente = lsCliente;
                    ViewBag.listaHabitacion = lsHabitacion;
                    ViewBag.ListaTipoHabitacion = lsTipoHabitacion;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarReservas");
            }
        }

        [HttpPost]
        public ActionResult InsertarReserva(entReserva R, FormCollection frm)
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
            //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if(u.idPersona.idTipoPersona.desTipoPersona.Equals("Gerente") || u.idPersona.idTipoPersona.desTipoPersona.Equals("Recepcionista"))
                {
                    R.idPersona = new entPersona();
                    R.idHabitacion = new entHabitacion();
                    R.idHabitacion.idTipoHabitacion = new entTipoHabitacion();

                    R.idPersona.idPersona = Convert.ToInt32(frm["cboCliente"]);
                    R.idHabitacion.idTipoHabitacion.idTipoHabitacion = Convert.ToInt32(frm["cboTipoHabitacion"]);
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

        //JSON
        [HttpPost]
        public JsonResult TraerDatosTipoHabitacion(int idHabitacion, DateTime fechaIncioReserva, DateTime fechaFinReserva)
        {
            List<entHabitacion> listarHabitacion = logHabitacion.Instancia.ListarHabitacionPorTipo(idHabitacion, fechaIncioReserva, fechaFinReserva);
            var lsHabitacion = new SelectList(listarHabitacion, "idHabitacion", "numeroHabitacion");
            ViewBag.listaHabitacion = lsHabitacion;

            return Json(listarHabitacion, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult InsertarReservaUsuario()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                if (u.idPersona.idTipoPersona.desTipoPersona.Equals("Gerente") || u.idPersona.idTipoPersona.desTipoPersona.Equals("Recepcionista"))
                {
                    List<entTipoHabitacion> listarTipoHabitacion = logTipoHabitacion.Instancia.ListarTipoHabitacion();
                    var lsTipoHabitacion = new SelectList(listarTipoHabitacion, "idTipoHabitacion", "DesTipoHabitacion");

                    List<entHabitacion> listarHabitacion = logHabitacion.Instancia.ListarHabitacion();
                    var lsHabitacion = new SelectList(listarHabitacion, "idHabitacion", "numeroHabitacion");

                    ViewBag.ListaTipoHabitacion = lsTipoHabitacion;
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
        public ActionResult InsertarReservaUsuario(entReserva R, FormCollection frm)
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                if (u.idPersona.idTipoPersona.desTipoPersona.Equals("Gerente") || u.idPersona.idTipoPersona.desTipoPersona.Equals("Recepcionista"))
                {
                    R.idPersona = new entPersona();
                    R.idHabitacion = new entHabitacion();
                    R.idHabitacion.idTipoHabitacion = new entTipoHabitacion();

                    R.idPersona.idPersona = u.idPersona.idPersona;
                    R.idHabitacion.idTipoHabitacion.idTipoHabitacion = Convert.ToInt32(frm["cboTipoHabitacion"]);
                    R.idHabitacion.idHabitacion = Convert.ToInt32(frm["cboHabitacion"]);

                    Boolean inserta = logReserva.Instancia.InsertarReserva(R);

                    if (inserta)
                    {
                        return RedirectToAction("ListarReservas_Por_Usuario");
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
                return RedirectToAction("ListarReservas", new { mesjExceptio = ex.Message });
            }

        }
    }
}
