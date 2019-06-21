using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entTrabajador
    {
        public int idTrabajador { get; set; }
        public entPersona idPersona { get; set; }
        public float ingresos { get; set; }
        public String profesion { get; set; }
        public String rol { get; set; }
    }
}
