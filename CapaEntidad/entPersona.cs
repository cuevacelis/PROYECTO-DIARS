using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPersona
    {
        public int idPersona { get; set; }
        public String nombreyApellidoPersona { get; set; }
        public String DNI { get; set; }
        public int telefono { get; set; }
        public Boolean estPersona { get; set; }
        public entTipoPersona idTipoPersona { get; set; }
    }
}