using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;

namespace Maldonado.Controllers
{
    public class MenuIntranetController : Controller
    {
        //
        // GET: /MenuIntranet/

        public ActionResult Index()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u != null)//VERIFICA QUE INICIO SESION
                {
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

    }
}
