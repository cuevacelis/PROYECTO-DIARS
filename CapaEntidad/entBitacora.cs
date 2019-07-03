using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entBitacora
    {
        public int idBitacora { get; set; }
        public entUsuario idUsuario { get; set; }
        public DateTime fecha { get; set; }
    }
}
