using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {
            Session["usuario"] = null;
            return View();
        }

        public ActionResult VerificarAcceso(FormCollection frm)
        {
            try
            {
                String txtUsuario = frm["txtUsuario"];
                String txtPassword = frm["txtPassword"];

                entUsuario u = logUsuario.Instancia.VerificarAcceso(txtUsuario, txtPassword);

                Session["usuario"] = u;
                return RedirectToAction("Inicio", "Index");
            }
            catch (ApplicationException e)
            {
                ViewBag.mensaje = e.Message;
                return RedirectToAction("Login", "Login");
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
