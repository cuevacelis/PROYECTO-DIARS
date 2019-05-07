using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public String nombreCliente { get; set; }
        public String apellidoCliente { get; set; }
        public int DNI { get; set; }
        public Boolean estCliente { get; set; }
    }
}
