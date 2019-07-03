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
        public entPersona idPersona { get; set; }
        public Boolean estCliente { get; set; }
    }
}
