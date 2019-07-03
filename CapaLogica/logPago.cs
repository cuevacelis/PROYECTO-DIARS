using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logPago
    {
        #region singleton
        private static readonly logPago UnicaInstancia = new logPago();
        public static logPago Instancia
        {
            get
            {
                return logPago.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entPago> ListarPago()
        {
            try
            {
                List<entPago> lista = datPago.Instancia.ListarPago();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarPago(entPago P)
        {
            //try
            //{
            return datPago.Instancia.InsertarPago(P);
            //}
            //catch (Exception e) { throw e; }
        }
        #endregion
    }
}
