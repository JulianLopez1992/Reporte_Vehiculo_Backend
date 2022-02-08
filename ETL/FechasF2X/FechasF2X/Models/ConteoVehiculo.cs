using System;
using System.Collections.Generic;

namespace FechasF2X.Models
{
    public partial class ConteoVehiculo
    {
        public int Id { get; set; }
        public string? Estacion { get; set; }
        public string? Sentido { get; set; }
        public decimal? Hora { get; set; }
        public string? Categoria { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
