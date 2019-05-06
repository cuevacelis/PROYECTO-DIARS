using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

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
            try
            {
                List<entPersona> lista = datPersona.Instancia.ListarPersona();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarPersona(entPersona p)
        {
            try
            {
                return datPersona.Instancia.InsertarPersona(p);
            }
            catch (Exception e) 
            { 
                throw e; 
            }


        }
        public entPersona BuscarPersona(int idPersona)
        {
            try
            {
                return datPersona.Instancia.BuscarPersona(idPersona);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Boolean EditarPersona(entPersona p)
        {
            try
            {
                return datPersona.Instancia.EditarPersona(p);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminarPersona(entPersona p)
        {
            try
            {
                return datPersona.Instancia.EliminarPersona(p);
               
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        #endregion metodos
    }
    
}
