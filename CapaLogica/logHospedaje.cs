using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logHospedaje
    {
        #region singleton
        private static readonly logHospedaje UnicaInstancia = new logHospedaje();
        public static logHospedaje Instancia
        {
            get
            {
                return logHospedaje.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entHospedaje> ListarHospedaje()
        {
            try
            {
                List<entHospedaje> lista = datHospedaje.Instancia.ListarHospedaje();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarHospedaje(entHospedaje H)
        {
            try
            {
                return datHospedaje.Instancia.InsertarHospedaje(H);
            }
            catch (Exception e)
            { throw e; }
        }

        public Boolean EliminarHospedaje(int idHospedaje)
        {
            try
            {
                return datHospedaje.Instancia.EliminarHospedaje(idHospedaje);
            }
            catch (Exception e)
            { throw e; }
        }
    }
    #endregion
}