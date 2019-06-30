using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entHospedaje
    {
        public int idHospedaje { get; set; }
        public entPersona idPersona { get; set; }
        public entReserva idReserva { get; set; }
        public entHabitacion idHabitacion { get; set; }
        public DateTime fechaLlegada { get; set; }
        public DateTime fechaSalida { get; set; }
        public Boolean estHospedaje { get; set; }
    }
}