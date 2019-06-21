using System;
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
        public List<entPersona> ListarCliente()
        {
            try
            {
                List<entPersona> lista = datPersona.Instancia.ListarCliente();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public Boolean InsertarCliente(entPersona a)
        {
            try
            {
                return datPersona.Instancia.InsertarCliente(a);
            }
            catch (Exception e) { throw e; }


        }
        public Boolean EditarCliente(entPersona c)
        {
            try
            {
                return datPersona.Instancia.EditarCliente(c);
            }
            catch (Exception e){ throw e; }
        }
        public entPersona BuscarCliente(int idCliente)
        {
            try
            {
                return datPersona.Instancia.BuscarCliente(idCliente);
            }
            catch (Exception e){ throw e; }
        }
        public Boolean EliminarCliente(int idCliente)
        {
            try
            {
                return datPersona.Instancia.EliminarCliente(idCliente);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion metodos
    }
}
