﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logCliente
    {
        #region singleton
        private static readonly logCliente UnicaInstancia = new logCliente();
        public static logCliente Instancia
        {
            get
            {
                return logCliente.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entCliente> ListarCliente()
        {
            try
            {
                List<entCliente> lista = datCliente.Instancia.ListarCliente();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarCliente(entCliente C)
        {
            //try
            //{
                return datCliente.Instancia.InsertarCliente(C);
            //}
            //catch (Exception e) { throw e; }
        }

        public entCliente BuscarCliente(int idCliente)
        {
            try
            {
                return datCliente.Instancia.BuscarCliente(idCliente);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarCliente(entCliente C)
        {
            try
            {
                return datCliente.Instancia.EditarCliente(C);
            }
            catch (Exception e) { throw e; }
        }
        public Boolean EliminarCliente(int idCliente)
        {
            try
            {
                return datCliente.Instancia.EliminarCliente(idCliente);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion metodos
    }
}
