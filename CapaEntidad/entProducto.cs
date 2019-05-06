using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProducto
    {
        public int idProducto { get; set; }
        public String desProducto { get; set; }
        public entTipoProducto idTipoProducto { get; set; }
        public entMatPrima idMaterial { get; set; }
        public double preProducto  { get; set; }
        public String imgProducto { get; set; }
        public entColor idColor { get; set; }
        public int stkProducto { get; set; }
        public DateTime fcrProducto { get; set; }
        public Boolean estProducto { get; set; }
    }
}
