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
        public ActionResult InsertarCliente(entCliente C, entPersona P, entUsuario U, FormCollection frm)
        {
            try
            {
                Boolean inserta = logCliente.Instancia.InsertarCliente(C, P, U);

                if (inserta)
                {
                    return RedirectToAction("ListarCliente");
                }
                else
                {
                    return View(P);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarCliente", new { mesjExceptio = ex.Message });
            }
        }
    }
}