using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorPagoController : Controller
    {
        // GET: MantenedorPago
        public ActionResult Index()
        {
            return RedirectToAction("ListarPago");
        }

        [HttpGet]
        public ActionResult ListarPago()
        {
            try
            {
                //entUsuario u = (entUsuario)Session["usuario"];
                ////ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                //if (u.tipo == true)
                //{
                List<entPago> lista = logPago.Instancia.ListarPago();
                ViewBag.lista = lista;
                return View(lista);
                //}
                //else
                //{
                //    return RedirectToAction("Index", "Login");
                //}
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult InsertarPago()
        {
            try
            {
                //entUsuario u = (entUsuario)Session["usuario"];
                ////ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                //if (u.tipo == true)
                //{
                return View();
                //}
                //else
                //{
                //    return RedirectToAction("Index", "Login");
                //}
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult InsertarPago(entPago P, FormCollection frm)
        {
            try
            {
                //entUsuario u = (entUsuario)Session["usuario"];
                ////ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                //if (u.tipo == true)
                //{                
                Boolean inserta = logPago.Instancia.InsertarPago(P);

                if (inserta)
                {
                    return RedirectToAction("ListarPago");
                }
                else
                {
                    return View(P);
                }
                //}
                //    else
                //    {
                //    return RedirectToAction("Index", "Login");
                //}

            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarPago", new { mesjExceptio = ex.Message });
            }
        }
    }
}