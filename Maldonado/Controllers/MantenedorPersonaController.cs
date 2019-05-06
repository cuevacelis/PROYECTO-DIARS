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
        // GET: /MantenedorPersona/

        public ActionResult Index()
        {
            return View();
        }
        
        // GET: /MantenedorPersona/

        public ActionResult listarPersona()
        {

            List<entPersona> lista = logPersona.Instancia.ListarPersona();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult InsertarPersona()
        {
            List<entPersona> lista = logPersona.Instancia.ListarPersona();
            var lsTipoProducto = new SelectList(lista, "cdxxx", "descrppTipoProducto", "esTipoProducto");
            ViewBag.Lista = lsTipoProducto;
            return View();
        }
        [HttpPost]
        public ActionResult InsertarPersona(entPersona p)
        {
            try
            {
                Boolean inserta = logPersona.Instancia.InsertarPersona(p);
                if (inserta)
                {
                    return RedirectToAction("listarPersona");
                }
                else
                {
                    return View(p);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarPersona", new { msjException = ex.Message });
            }


        }

        [HttpGet]
        public ActionResult EditarPersona(int idPersona)
        {
            entPersona p = logPersona.Instancia.BuscarPersona(idPersona);

            return View(p);

        }

        [HttpPost]
        public ActionResult EditarPersona(entPersona p)
        {
            //try
            //{
            Boolean edita = logPersona.Instancia.EditarPersona(p);
            if (edita)
            {
                return RedirectToAction("listarPersona");
            }
            else
            {
                return View(p);
            }
        }
        /*catch (ApplicationException ex)
        {
            return RedirectToAction("index", "Error",new { msjException = ex.Message });
        }
    }*/

        [HttpGet]
        public ActionResult EliminarPersona(int idPersona)
        {
            entPersona p = logPersona.Instancia.BuscarPersona(idPersona);
           

            Boolean elimina = logPersona.Instancia.EliminarPersona(p);

            if (elimina)
            {
                return RedirectToAction("listarPersona");
            }
            else
            {
                return View();
            }
        }
    } 
}
