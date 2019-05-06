using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logTipoProducto
    {
        #region singleton
        private static readonly logTipoProducto UnicaInstancia = new logTipoProducto();
        public static logTipoProducto Instancia
        {
            get
            {
                return logTipoProducto.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entTipoProducto> ListarTipoProducto()
        {
            try
            {
                List<entTipoProducto> lista = datTipoProducto.Instancia.ListarTipoProducto();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public Boolean InsertarTipoProducto(entTipoProducto a)
        {
            try
            {
                return datTipoProducto.Instancia.InsertarTipoProducto(a);
            }
            catch (Exception e) { throw e; }


        }

        public entTipoProducto BuscarTipoProducto(int idTipoProducto)
        {
            try
            {
            
                return datTipoProducto.Instancia.BuscarTipoProducto(idTipoProducto);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarTipoProducto(entTipoProducto tp)
        {
            try
            {
                return datTipoProducto.Instancia.EditarTipoProducto(tp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
               public Boolean EliminarTipoProducto(entTipoProducto tp)
        {
            try
            {
                return datTipoProducto.Instancia.EliminarTipoProducto(tp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion metodos
    }
}
