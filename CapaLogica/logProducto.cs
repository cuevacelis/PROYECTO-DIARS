using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logProducto
    {
       
        #region singleton
        private static readonly logProducto UnicaInstancia = new logProducto();
        public static logProducto Instancia
        {
            get
            {
                return logProducto.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entProducto> ListarProducto()
        {
            try
            {
                List<entProducto> lista = datProducto.Instancia.ListarProducto();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Boolean InsertarProducto(entProducto a)
        {
            try
            {
                return datProducto.Instancia.InsertarProducto(a);
            }
            catch (Exception e) { throw e; }


        }
        #endregion metodos

    }
}
