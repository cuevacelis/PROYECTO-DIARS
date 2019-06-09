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
                return RedirectToAction("Index", "Inicio");
            }
            catch (ApplicationException e)
            {
                ViewBag.mensaje = e.Message;
                TempData["Mensaje"] = "Usuario o Contraseña erroneo";
                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
