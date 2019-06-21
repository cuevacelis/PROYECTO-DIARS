using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logTipoPersona
    {
        #region singleton
        private static readonly logTipoPersona UnicaInstancia = new logTipoPersona();
        public static logTipoPersona Instancia
        {
            get
            {
                return logTipoPersona.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entTipoPersona> ListarTipoPersona()
        {
            try
            {
                List<entTipoPersona> lista = datTipoPersona.Instancia.ListarTipoPersona();
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
