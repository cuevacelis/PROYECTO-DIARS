﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace Maldonado.Controllers
{
    public class MantenedorClienteController : Controller
    {
        // GET: MantenedorCliente
        public ActionResult Index()
        {
            return RedirectToAction("ListarCliente");
        }

        [HttpGet]
        public ActionResult ListarCliente()
        {
            //try
            //{
            //entUsuario u = (entUsuario)Session["usuario"];
            //ViewBag.usuario = u.idCliente.nombreCliente + " " + u.nomUsuario;
            //if (u.idPersona.idTipoPersona.estTipoPersona == true)
            //{
                List<entCliente> lista = logCliente.Instancia.ListarCliente();
                ViewBag.lista = lista;
                return View(lista);
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            //}
            //catch (Exception e)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
        }


    }
}