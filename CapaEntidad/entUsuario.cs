using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entUsuario
    {
        public int idUsuario { get; set; }
        public entCliente Cliente { get; set; }
        public String nomUsuario { get; set; }
        public String contrasenia { get; set; }
        public Boolean estUsuario { get; set; }
        public DateTime fecCreacion { get; set; }
    }
}
