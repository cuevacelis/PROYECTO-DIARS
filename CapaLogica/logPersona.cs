using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logPersona
    {
        #region singleton
        private static readonly logPersona UnicaInstancia = new logPersona();
        public static logPersona Instancia
        {
            get
            {
                return logPersona.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entPersona> ListarPersona()
        {
            //try
            //{
                List<entPersona> lista = datPersona.Instancia.ListarPersona();
                return lista;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }
        
        public Boolean InsertarPersona(entPersona a)
        {
            //try
            //{
                return datPersona.Instancia.InsertarPersona(a);
            //}
            //catch (Exception e) { throw e; }


        }
        public Boolean EditarPersona(entPersona c)
        {
            //try
            //{
                return datPersona.Instancia.EditarPersona(c);
            //}
            //catch (Exception e){ throw e; }
        }
        public entPersona BuscarPersona(int idPersona)
        {
            //try
            //{
                return datPersona.Instancia.BuscarPersona(idPersona);
            //}
            //catch (Exception e){ throw e; }
        }
        public Boolean EliminarPersona(int idPersona)
        {
            //try
            //{
                return datPersona.Instancia.EliminarPersona(idPersona);
            //}
            //catch (Exception e)
            //{ throw e; }
        }
        #endregion metodos
    }
}
