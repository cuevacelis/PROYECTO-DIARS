using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            Session["usuario"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            //try
            //{
                String txtUsuario = frm["txtUsuario"];
                String txtPassword = frm["txtPassword"];

            //APLICANDO HASH
                String txtHashPassword = txtUsuario[0] + txtPassword + "ab" + "123";

                entUsuario u = logUsuario.Instancia.VerificarAcceso(txtUsuario, txtPassword);
            //logUsuario.Instancia.AgregarBitacora(u);

                logUsuario.Instancia.AgregarBitacora(u);

                Session["usuario"] = u;
                TempData["MensajeDeValidacion"] = "success";

                if (u.idPersona.idTipoPersona.Privilegio == 1)//Adminitradores
                {
                    return RedirectToAction("Index", "MenuIntranet");
                }
                else
                {
                    return RedirectToAction("Index", "Inicio");
                }

            //}
            //catch (ApplicationException e)
            //{
                //ViewBag.mensaje = e.Message;
                //TempData["MensajeDeValidacion"] = "error";

                //return RedirectToAction("Index", "Login");
            //}
        //    catch (Exception e)
        //    {
        //        ViewBag.mensaje = e.Message;
        //        TempData["MensajeDeValidacion"] = "errorCodigo";

        //        return ViewBag(e);
        //    }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Inicio");
        }

        [HttpPost]
        public ActionResult AgregarBitacora(entUsuario U)
        {
            try
            {

                Boolean inserta = logUsuario.Instancia.AgregarBitacora(U);

                if (inserta)
                {
                    return RedirectToAction("ListarPersona");
                }
                else
                {
                    return View(U);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarPersona", new { mesjExceptio = ex.Message });
            }
        }

        public ActionResult ListarBitacora()
        {

            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                List<entBitacora> lista = logBitacora.Instancia.ListarBitacora(u);
                ViewBag.lista = lista;
                return View(lista);

            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}
