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
            try
            {
                String txtUsuario = frm["txtUsuario"];
                String txtPassword = frm["txtPassword"];

                entUsuario u = logUsuario.Instancia.VerificarAcceso(txtUsuario, txtPassword);

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

            }
            catch (ApplicationException e)
            {
                ViewBag.mensaje = e.Message;
                TempData["MensajeDeValidacion"] = "error";

                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                TempData["MensajeDeValidacion"] = "errorCodigo";

                return ViewBag(e);
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Inicio");
        }
    }
}
