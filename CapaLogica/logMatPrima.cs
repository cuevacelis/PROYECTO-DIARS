using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;
namespace CapaLogica
{
    public class logMatPrima
    {
        #region singleton
        private static readonly logMatPrima UnicaInstancia = new logMatPrima();
        public static logMatPrima Instancia
        {
            get
            {
                return logMatPrima.UnicaInstancia; 
            }

        }
        #endregion singleton

        public List<entMatPrima> ListarMatPrima()
        {
            try
            {
                List<entMatPrima> listam = datMatPrima.Instancia.ListarMatPrima();
                return listam;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
