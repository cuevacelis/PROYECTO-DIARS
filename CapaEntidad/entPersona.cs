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
        public String rucPersona { get; set; }
        public String razPersona { get; set; }
        public String dirPersona { get; set; }
        public entCiudad ciuPersona { get; set; }
        public Boolean estPersona { get; set; }
        public entTipoPersona tipPersona { get; set; }
        public DateTime finPersona { get; set; }
    }
}
