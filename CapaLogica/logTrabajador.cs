using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logTrabajador
    {
        #region singleton
        private static readonly logTrabajador UnicaInstancia = new logTrabajador();
        public static logTrabajador Instancia
        {
            get
            {
                return logTrabajador.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entTrabajador> ListarTrabajador()
        {
            try
            {
                List<entTrabajador> lista = datTrabajador.Instancia.ListarTrabajador();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarTrabajador(entTrabajador T)
        {
            try
            {
                return datTrabajador.Instancia.InsertarTrabajador(T);
            }
            catch (Exception e) { throw e; }


        }
        public Boolean EditarTrabajador(entTrabajador T)
        {
            try
            {
                return datTrabajador.Instancia.EditarTrabajador(T);
            }
            catch (Exception e) { throw e; }
        }
        public entTrabajador BuscarTrabajador(int idTrabajador)
        {
            try
            {
                return datTrabajador.Instancia.BuscarTrabajador(idTrabajador);
            }
            catch (Exception e) { throw e; }
        }
        public Boolean EliminarTrabajador(int idTrabajador)
        {
            try
            {
                return datTrabajador.Instancia.EliminarTrabajador(idTrabajador);
            }
            catch (Exception e)
            { throw e; }
        }
        #endregion metodos
    }
}
