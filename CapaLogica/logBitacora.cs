using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logBitacora
    {
        #region singleton
        private static readonly logBitacora _instancia = new logBitacora();
        public static logBitacora Instancia
        {
            get { return logBitacora._instancia; }
        }
        #endregion

        #region metodos
        public List<entBitacora> ListarBitacora(entUsuario a)
        {
            try
            {
                List<entBitacora> lista = datBitacora.Instancia.ListarBitacora(a);
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    #endregion
}
}
