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
        public entPersona idPersona { get; set; }
        public String Username { get; set; }
        public String Correo { get; set; }
        public String Password { get; set; }
        public String Hash { get; set; }
        public Boolean estUsuario { get; set; }
        public DateTime fechCreacion { get; set; }
    }
}
