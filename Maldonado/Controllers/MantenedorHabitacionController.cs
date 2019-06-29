using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorHabitacionController : Controller
    {
        //
        // GET: /MantenedorHabitacion/

        public ActionResult Index()
        {
            return RedirectToAction("ListarHabitacion");
        }

        [HttpGet]
        public ActionResult ListarHabitacion()
        {
            try
            {
                entUsuario u = (entUsuario)Session["usuario"];
                //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
                if (u.idPersona.idTipoPersona.Privilegio == 1)
                {
                    List<entHabitacion> lista = logHabitacion.Instancia.ListarHabitacion();
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
    }
}
