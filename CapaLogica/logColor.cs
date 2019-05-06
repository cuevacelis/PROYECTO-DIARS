using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidad;

namespace CapaLogica
{
    public class logColor
    {
            #region singleton
            private static readonly logColor UnicaInstancia = new logColor();
            public static logColor Instancia
            {
                get
                {
                    return logColor.UnicaInstancia;
                }

            }
            #endregion singleton

            public List<entColor> ListarColor()
            {
                try
                {
                List<entColor> listac = datColor.Instancia.ListarColor();
                    return listac;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
}