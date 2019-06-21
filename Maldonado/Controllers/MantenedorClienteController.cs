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

            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.tipo == true)
                {
                    List<entPersona> lista = logCliente.Instancia.ListarCliente();
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
        public ActionResult InsertarCliente()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.tipo == true)
                {
                    List<entTipoPersona> listarTipoCliente = logTipoCliente.Instancia.ListarTipoCliente();
                    var lsTipoCliente = new SelectList(listarTipoCliente, "idTipoCliente", "DesTipoCliente");


                    ViewBag.listaTipoCliente = lsTipoCliente;
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
        public ActionResult InsertarCliente(entPersona C, FormCollection frm)
        {
            try
            {
                C.idTipoCliente = new entTipoPersona();

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

        [HttpGet]
        public ActionResult EditarCliente(int idCliente)
        {
            entPersona c = new entPersona();
            c = logCliente.Instancia.BuscarCliente(idCliente);

            List<entTipoPersona> listarTipoCliente = logTipoCliente.Instancia.ListarTipoCliente();
            var lsTipoCliente = new SelectList(listarTipoCliente, "idTipoCliente", "DesTipoCliente");

            ViewBag.listaTipoCliente = lsTipoCliente;

            return View(c);
        }
        [HttpPost]
        public ActionResult EditarCliente(entPersona c, FormCollection frm)
        {
            try
            {
                c.idTipoCliente = new entTipoPersona();
                c.idTipoCliente.idTipoCliente = Convert.ToInt32(frm["cboTipoCliente"]);

                Boolean edita = logCliente.Instancia.EditarCliente(c);
                if (edita)
                {
                    return RedirectToAction("listarCliente");

                }
                else
                {
                    return View(c);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarCliente", new { mesjExceptio = ex.Message });
            }

        }

        public ActionResult EliminarCliente(int idCliente)
        {
            try
            {
                Boolean elimina = logCliente.Instancia.EliminarCliente(idCliente);
                

                if (elimina)
                {
                    return RedirectToAction("listarCliente");

                }
                else
                {
                    return View();
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarCliente", new { mesjExceptio = ex.Message });
            }

        }
    }
}
