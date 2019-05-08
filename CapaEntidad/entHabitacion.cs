using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entHabitacion
    {
        public int idHabitacion { get; set; }
        public int numeroHabitacion { get; set; }
        public String descHabitacion { get; set; }
        public Boolean estHabitacion{ get; set; }
        public entTipoHabitacion idTipoHabitacion { get; set; }
    }
}
