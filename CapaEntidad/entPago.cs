using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entPago
    {
        public int idPago { get; set; }
        public entHospedaje idHospedaje { get; set; }
        public entPersona idPersona { get; set; }
        public int monto { get; set; }
        public String modoDePago { get; set; }
        public Boolean estPago { get; set; }
    }
}
