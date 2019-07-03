using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logTipoHabitacion
    {
        #region singleton
        private static readonly logTipoHabitacion UnicaInstancia = new logTipoHabitacion();
        public static logTipoHabitacion Instancia
        {
            get
            {
                return logTipoHabitacion.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entTipoHabitacion> ListarTipoHabitacion()
        {
            //try
            //{
            List<entTipoHabitacion> lista = datTipoHabitacion.Instancia.ListarTipoHabitacion();
            return lista;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }
        #endregion metodos
    }
}
