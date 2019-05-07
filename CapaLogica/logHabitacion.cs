using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logHabitacion
    {
        #region singleton
        private static readonly logHabitacion UnicaInstancia = new logHabitacion();
        public static logHabitacion Instancia
        {
            get
            {
                return logHabitacion.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
 
        public List<entHabitacion> ListarHabitacion()
        {
            try
            {
                List<entHabitacion> lista = datHabitacion.Instancia.ListarHabitacion();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
       public Boolean InsertarHabitacion(entHabitacion a)
       {
           try
           {
               return datHabitacion.Instancia.InsertarHabitacion(a);
           }
           catch (Exception e) { throw e; }


       }*/
       
        #endregion metodos
    }
}
