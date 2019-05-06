using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica;
using CapaEntidad;

namespace Maldonado.Controllers
{
    public class MantenedorProductoController : Controller
    {
        
        public ActionResult listarProducto()
        {

            List<entProducto> lista = logProducto.Instancia.ListarProducto();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult InsertarProducto()
        {
            List<entProducto> lista = logProducto.Instancia.ListarProducto();
            var lsProducto = new SelectList(lista, "idProducto", "desProducto", "estProducto");
            List<entColor> listac = logColor.Instancia.ListarColor();
            List<entMatPrima> listam = logMatPrima.Instancia.ListarMatPrima();
            List<entTipoProducto> listatp = logTipoProducto.Instancia.ListarTipoProducto();
            ViewBag.Lista = lsProducto;
            ViewBag.listac = listac;
            ViewBag.listam = listam;
            ViewBag.listatp = listatp;
            return View();
        }


        [HttpPost]
        public ActionResult InsertarProducto(entProducto tp, FormCollection frm)
        {
            try
            {
                entColor c = new entColor();
                entMatPrima mp = new entMatPrima();
                entTipoProducto tpr = new entTipoProducto();
                mp.idMaterial = Convert.ToInt32(frm["MatPrima"]);
                tp.idMaterial = mp;
                c.idColor = Convert.ToInt32(frm["Color"]);
                tp.idColor = c;
                tpr.idTipoProducto = Convert.ToInt32(frm["TipoProducto"]);
                tp.idTipoProducto = tpr;
                Boolean inserta = logProducto.Instancia.InsertarProducto(tp);
                if (inserta)
                {
                    return RedirectToAction("listarProducto");
                }
                else
                {
                    return View(tp);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarProducto", new { msjException = ex.Message });
            }


        }
    }
}
