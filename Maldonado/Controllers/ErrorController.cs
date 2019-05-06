using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maldonado.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(String mensajerror)
        {
            ViewBag.mensaje = mensajerror;
            return View();
        }

    }
}
