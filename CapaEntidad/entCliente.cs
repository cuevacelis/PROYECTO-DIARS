using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entCliente
    {
        public int idCliente { get; set; }
        public String nombreCliente { get; set; }
        public String apellidoCliente { get; set; }
        public String DNI { get; set; }
        public int telefono { get; set; }
        public Boolean estCliente { get; set; }
        public entTipoCliente idTipoCliente { get; set; }
    }
}