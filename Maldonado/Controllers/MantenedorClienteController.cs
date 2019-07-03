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
        // GET: MantenedorCliente
        public ActionResult Index()
        {
            return RedirectToAction("ListarCliente");
        }

        [HttpGet]
        public ActionResult ListarCliente()
        {
            //try
            //{
            //entUsuario u = (entUsuario)Session["usuario"];
            //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
            //if (u.idPersona.idTipoPersona.estTipoPersona == true)
            //{
                List<entCliente> lista = logCliente.Instancia.ListarCliente();
                ViewBag.lista = lista;
                return View(lista);
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            //}
            //catch (Exception e)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }

        [HttpGet]
        public ActionResult InsertarCliente()
        {
            //try
            //{
             entUsuario u = (entUsuario)Session["usuario"];
            //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
            //if (u.idPersona.idTipoPersona.estTipoPersona == true)
            //{

            return View();
                //}
                //else
                //{
                //    return RedirectToAction("Index", "Login");
                //}
            //}
            //catch (Exception e)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }

        [HttpPost]
        public ActionResult InsertarCliente(entCliente C, FormCollection frm)
        {
            try
            {
                Boolean inserta = logCliente.Instancia.InsertarCliente(C);

                if (inserta)
                {
                    return RedirectToAction("ListarCliente");
                }
                else
                {
                    return View();
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
            entCliente C = new entCliente();
            C = logCliente.Instancia.BuscarCliente(idCliente);

            return View(C);
        }

        [HttpPost]
        public ActionResult EditarCliente(entCliente C, FormCollection frm)
        {
            try
            {
                C.idPersona = new entPersona();

                Boolean edita = logCliente.Instancia.EditarCliente(C);
                if (edita)
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
                    return RedirectToAction("ListarCliente");

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