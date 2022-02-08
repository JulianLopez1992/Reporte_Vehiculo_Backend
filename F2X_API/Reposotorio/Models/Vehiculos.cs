namespace Reposotorio.Models
{
    public partial class Vehiculos
    {
        public int Id { get; set; }
        public string? Estacion { get; set; }
        public string? Sentido { get; set; }
        public int? Hora { get; set; }
        public string? Categoria { get; set; }
        public int? Cantidad { get; set; }
        public decimal? ValorTabulado { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
