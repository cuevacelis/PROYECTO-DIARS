using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorPersonaController : Controller
    {
        //
        // GET: /MantenedorCliente/

        public ActionResult Index()
        {
            return RedirectToAction("ListarPersona");
        }

        [HttpGet]
        public ActionResult ListarPersona()
        {

            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.idPersona.idTipoPersona.estTipoPersona == true)
                {
                List<entPersona> lista = logPersona.Instancia.ListarPersona();
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
        public ActionResult InsertarPersona()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.idPersona.idTipoPersona.estTipoPersona == true)
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
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult InsertarPersona(entPersona C, FormCollection frm)
        {
            try
            {
                C.idTipoPersona = new entTipoPersona();

                C.idTipoPersona.idTipoPersona = Convert.ToInt32(frm["cboTipoPersona"]);

                Boolean inserta = logPersona.Instancia.InsertarPersona(C);

                if (inserta)
                {
                    return RedirectToAction("ListarPersona");
                }
                else
                {
                    return View(C);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarPersona", new { mesjExceptio = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditarPersona(int idPersona)
        {
            entPersona c = new entPersona();
            c = logPersona.Instancia.BuscarPersona(idPersona);

            List<entTipoPersona> listarTipoPersona = logTipoPersona.Instancia.ListarTipoPersona();
            var lsTipoPersona = new SelectList(listarTipoPersona, "idTipoPersona", "DesTipoPersona");

            ViewBag.listaTipoPersona = lsTipoPersona;

            return View(c);
        }
        [HttpPost]
        public ActionResult EditarPersona(entPersona P, FormCollection frm)
        {
            try
            {
                P.idTipoPersona = new entTipoPersona();
                P.idTipoPersona.idTipoPersona = Convert.ToInt32(frm["cboTipoPersona"]);

                Boolean edita = logPersona.Instancia.EditarPersona(P);
                if (edita)
                {
                    return RedirectToAction("listarPersona");

                }
                else
                {
                    return View(P);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarPersona", new { mesjExceptio = ex.Message });
            }

        }

        public ActionResult EliminarPersona(int idPersona)
        {
            try
            {
                Boolean elimina = logPersona.Instancia.EliminarPersona(idPersona);
                

                if (elimina)
                {
                    return RedirectToAction("listarPersona");

                }
                else
                {
                    return View();
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarPersona", new { mesjExceptio = ex.Message });
            }

        }
    }
}
