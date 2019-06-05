using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logTipoCliente
    {
        #region singleton
        private static readonly logTipoCliente UnicaInstancia = new logTipoCliente();
        public static logTipoCliente Instancia
        {
            get
            {
                return logTipoCliente.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entTipoCliente> ListarTipoCliente()
        {
            try
            {
                List<entTipoCliente> lista = datTipoCliente.Instancia.ListarTipoCliente();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        #endregion metodos
    }
}
