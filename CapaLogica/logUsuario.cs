using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logUsuario
    {
        #region singleton
        private static readonly logUsuario _instancia = new logUsuario();
        public static logUsuario Instancia
        {
            get { return logUsuario._instancia; }
        }
        #endregion

        #region Metodos
        public List<entUsuario> ListarUsuario()
        {
            try
            {
                List<entUsuario> lista = datUsuario.Instancia.ListarUsuario();

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entUsuario VerificarAcceso(String Usuario, String Password)
        {
            try
            {
                /*if (DateTime.Now.Hour > 23)
                {
                    throw new ApplicationException("No puede ingresar a esta hora");
                }*/
                entUsuario u = datUsuario.Instancia.VerificarAcceso(Usuario, Password);
                if (u != null)
                {
                    if (!u.estUsuario)
                    {
                        throw new ApplicationException("Usuario ha sido dado de baja");
                    }
                }
                else
                {
                    throw new ApplicationException("Usuario o Password no Valido");
                }
                return u;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean AgregarBitacora(entUsuario eU)
        {
            try
            {
                return datUsuario.Instancia.AgregarBitacora(eU);
            }
            catch(Exception e)
            { throw e; }
        }
        #endregion
    }
}
