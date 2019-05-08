using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;


namespace CapaLogica
{
    public class logReserva
    {
        #region singleton
        private static readonly logReserva UnicaInstancia = new logReserva();
        public static logReserva Instancia
        {
            get
            {
                return logReserva.UnicaInstancia;
            }

        }
        #endregion singleton

        public List<entReserva> ListarReservas()
        {
            try
            {
                List<entReserva> lista = datReserva.Instancia.ListarReservas();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
