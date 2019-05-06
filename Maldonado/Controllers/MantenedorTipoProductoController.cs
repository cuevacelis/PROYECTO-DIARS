using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorTipoProductoController : Controller
    {
        
        public ActionResult listarTipoProducto()
        {

            List<entTipoProducto> lista = logTipoProducto.Instancia.ListarTipoProducto();
            ViewBag.lista = lista;
            return View(lista);
        }
        
        [HttpGet]
        public ActionResult InsertarTipoProducto()
        {
            List<entTipoProducto> lista = logTipoProducto.Instancia.ListarTipoProducto();
            var lsTipoProducto = new SelectList(lista, "idTipoProducto", "desTipoProducto", "esTipoProducto");
            ViewBag.Lista = lsTipoProducto;
            return View();
        }


        [HttpPost]
        public ActionResult InsertarTipoProducto(entTipoProducto tp)
        {
           try
            {
                Boolean inserta = logTipoProducto.Instancia.InsertarTipoProducto(tp);
                if (inserta)
                {
                    return RedirectToAction("listarTipoProducto");
                }
                else
                {
                    return View(tp);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarTipoProducto", new { msjException = ex.Message });
            }

                    
    }
        [HttpGet]
        public ActionResult EditarTipoProducto(int idTipoProducto)
        {

            try
            {
                entTipoProducto tp = logTipoProducto.Instancia.BuscarTipoProducto(idTipoProducto);


                return View(tp);
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("listarTipoProducto", new { msjException = ex.Message });
            }

        }
        [HttpPost]
        public ActionResult EditarTipoProducto(entTipoProducto tp)
        {
            try
             {
            Boolean edita = logTipoProducto.Instancia.EditarTipoProducto(tp);
            if (edita)
            {
                return RedirectToAction("listarTipoProducto");
            }
            else
            {
                return View(tp);
            }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarTipoProducto", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EliminarTipoProducto(int idTipoProducto)
        {

            try
            {
                entTipoProducto tp = logTipoProducto.Instancia.BuscarTipoProducto(idTipoProducto);


                return View(tp);
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("listarTipoProducto", new { msjException = ex.Message });
            }

        }
        [HttpPost]
        public ActionResult EliminarTipoProducto(entTipoProducto tp)
        {
            try
            {
                Boolean elimina = logTipoProducto.Instancia.EliminarTipoProducto(tp);
                if (elimina)
                {
                    return RedirectToAction("listarTipoProducto");
                }
                else
                {
                    return View(tp);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("EliminarTipoProducto", new { msjException = ex.Message });
            }
        }

    } 
}
