using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entDetalle
    {
        public int idDetalle { get; set; }
        public entCliente idCliente { get; set; }
        public int adultos { get; set; }
        public int ninios { get; set; }
    }
}
