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
                //entUsuario u = (entUsuario)Session["usuario"];
                ////ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                //if (u.tipo == true)
                //{
                List<entTrabajador> lista = logTrabajador.Instancia.ListarTrabajador();
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
        public ActionResult InsertarTrabajador()
        {
            try
            {
                //entUsuario u = (entUsuario)Session["usuario"];
                ////ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                //if (u.tipo == true)
                //{
                List<entTrabajador> listarTrabajador = logTrabajador.Instancia.ListarTrabajador();
                var lsTrabajador = new SelectList(listarTrabajador, "idTrabajador", "ingresos");

                ViewBag.ListaTrabajador = lsTrabajador;
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
        public ActionResult InsertarTrabajador(entTrabajador T, FormCollection frm)
        {
            try
            {
                //entUsuario u = (entUsuario)Session["usuario"];
                ////ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                //if (u.tipo == true)
                //{                
                Boolean inserta = logTrabajador.Instancia.InsertarTrabajador(T);

                if (inserta)
                {
                    return RedirectToAction("ListarTrabajador");
                }
                else
                {
                    return View(T);
                }
            //}
            //    else
            //    {
            //    return RedirectToAction("Index", "Login");
            //}

        }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarTrabajador", new { mesjExceptio = ex.Message });
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
