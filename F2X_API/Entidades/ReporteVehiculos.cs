using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ReporteVehiculos
    {
        public string estacion { get; set; }
        public DateTime? fecha { get; set; }
        public int cantidadTotal { get; set; }
        public decimal recaudadoTotal { get; set; }
    }

    public class DatosEstacion
    {
        public DateTime fecha { get; set; }
        public int cantidadTotal { get; set; }
        public decimal recaudoTotal { get; set; }
    }

    public class EstacionPonderada
    {
        public string estacion { get; set; }
        public List<DatosEstacion> informacionEstacion { get; set; }
    }
}
