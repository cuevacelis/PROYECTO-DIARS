using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logDetalle
    {
        #region singleton
        private static readonly logDetalle UnicaInstancia = new logDetalle();
        public static logDetalle Instancia
        {
            get
            {
                return logDetalle.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entDetalle> ListarDetalle()
        {
            try
            {
                List<entDetalle> lista = datDetalle.Instancia.ListarDetalle();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
