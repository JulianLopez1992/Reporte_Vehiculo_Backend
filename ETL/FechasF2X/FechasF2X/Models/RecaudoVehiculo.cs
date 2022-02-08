using System;
using System.Collections.Generic;

namespace FechasF2X.Models
{
    public partial class RecaudoVehiculo
    {
        public int Id { get; set; }
        public string? Estacion { get; set; }
        public string? Sentido { get; set; }
        public int? Hora { get; set; }
        public string? Categoria { get; set; }
        public decimal? ValorTabulado { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
