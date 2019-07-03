using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorTrabajadorController : Controller
    {
        // GET: MantenedorTrabajador
        public ActionResult Index()
        {
            return RedirectToAction("ListarTrabajador");
        }

        [HttpGet]
        public ActionResult ListarTrabajador()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.idPersona.idTipoPersona.Privilegio == 1)
                {
                    List<entTrabajador> lista = logTrabajador.Instancia.ListarTrabajador();
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
                return RedirectToAction("Error", "Error");
            }
        }

        [HttpGet]
        public ActionResult InsertarTrabajador()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.idPersona.idTipoPersona.Privilegio == 1)
                {
                    List<entTipoPersona> listarTipoPersona = logTipoPersona.Instancia.ListarTipoPersona();
                    var lsTipoPersona = new SelectList(listarTipoPersona, "idTipoPersona", "DesTipoPersona");

                    ViewBag.listaTipoCliente = lsTipoPersona;
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error");
            }
        }

        [HttpPost]
        public ActionResult InsertarTrabajador(entTrabajador T, FormCollection frm)
        {
            try
            {
                T.idPersona.idTipoPersona = new entTipoPersona();

                T.idPersona.idTipoPersona.idTipoPersona = Convert.ToInt32(frm["cboTipoPersona"]);
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.idPersona.idTipoPersona.Privilegio == 1)
                {
                    Boolean inserta = logTrabajador.Instancia.InsertarTrabajador(T);

                    if (inserta)
                    {
                        return RedirectToAction("ListarTrabajador");
                    }
                    else
                    {
                        return View(T);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarTrabajador", new { mesjExceptio = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditarTrabajador(int idTrabajador)
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.idPersona.idTipoPersona.Privilegio == 1)
                {
                    entTrabajador T = new entTrabajador();
                    T = logTrabajador.Instancia.BuscarTrabajador(idTrabajador);

                    List<entTipoPersona> listarTipoPersona = logTipoPersona.Instancia.ListarTipoPersona();
                    var lsTipoPersona = new SelectList(listarTipoPersona, "idTipoPersona", "DesTipoPersona");

                    ViewBag.listaTipoPersona = lsTipoPersona;

                    return View(T);
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            catch(ApplicationException ex)
            {
                return RedirectToAction("EditarTrabajador", new { mesjExceptio = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult EditarTrabajador(entTrabajador T, FormCollection frm)
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.idPersona.idTipoPersona.Privilegio == 1)
                {
                    T.idPersona.idTipoPersona = new entTipoPersona();
                    T.idPersona.idTipoPersona.idTipoPersona = Convert.ToInt32(frm["cboTipoPersona"]);

                    Boolean edita = logTrabajador.Instancia.EditarTrabajador(T);
                    if (edita)
                    {
                        return RedirectToAction("ListarTrabajador");

                    }
                    else
                    {
                        return View(T);
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarTrabajador", new { mesjExceptio = ex.Message });
            }

        }

        public ActionResult EliminarTrabajador(int idTrabajador)
        {
            try
            {

                Boolean elimina = logTrabajador.Instancia.EliminarTrabajador(idTrabajador);

                if (elimina)
                {
                    return RedirectToAction("ListarTrabajador");

                }
                else
                {
                    return View();
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarTrabajador", new { mesjExceptio = ex.Message });
            }

        }
    }
}
