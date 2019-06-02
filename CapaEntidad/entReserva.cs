using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entReserva
    {
        public int idReserva { get; set; }
        public entCliente idCliente { get; set; }
        public entHabitacion idHabitacion { get; set; }
        public DateTime fechaIncioReserva { get; set; }
        public DateTime fechaFinReserva { get; set; }
    }
}
