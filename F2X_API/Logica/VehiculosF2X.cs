using Reposotorio.Models;

namespace Logica
{
    public class VehiculosF2X
    {

        public List<Entidades.VehiculosEN> GetListInfoVehiculos()
        {
            JLopezContext dbContext = new JLopezContext();
            List<Entidades.VehiculosEN> listVehiculos = dbContext.Vehiculos.Select(x => new Entidades.VehiculosEN
            {
                estacion = x.Estacion,
                fecha = x.Fecha,
                hora = x.Hora,
                categoria = x.Categoria,
                sentido = x.Sentido,
                cantidad = x.Cantidad,
                valortabulado = x.ValorTabulado
            }).ToList();

            return listVehiculos;
        }

        public List<Entidades.ConteoVehiculo> GetListConteoVehiculo()
        {
            JLopezContext dbContext = new JLopezContext();
            List<Entidades.ConteoVehiculo> listConteoVehiculo = dbContext.ConteoVehiculos.Select(s => new Entidades.ConteoVehiculo
            {
                cantidad = s.Cantidad,
                categoria = s.Categoria,
                estacion = s.Estacion,
                hora = s.Hora,
                fecha = s.Fecha,
                sentido = s.Sentido,
            }).ToList();

            return listConteoVehiculo;
        }

        public List<Entidades.RecaudoVehiculo> GetListRecaudoVehiculo()
        {
            JLopezContext dbContext = new JLopezContext();

            List<Entidades.RecaudoVehiculo> listConteoVehiculo = dbContext.RecaudoVehiculos.Select(s => new Entidades.RecaudoVehiculo
            {
                valortabulado = s.ValorTabulado,
                categoria = s.Categoria,
                estacion = s.Estacion,
                hora = s.Hora,
                fecha = s.Fecha,
                sentido = s.Sentido,
            }).ToList();

            return listConteoVehiculo;
        }

        public List<Entidades.ReporteVehiculos> GetListReporteVehiculo()
        {
            JLopezContext dbContext = new JLopezContext();

            var listReporteVehiculosVar = dbContext.Vehiculos.GroupBy(f => new { f.Estacion, f.Fecha }).Select(group => new { fee = group.Key, cantidadTotal = group.Sum(f => f.Cantidad), valorTotal = group.Sum(f => f.ValorTabulado) }).OrderBy(o => o.fee.Fecha).ToList();

            List<Entidades.ReporteVehiculos> listReporteVehiculos = dbContext.Vehiculos.GroupBy(f => new { f.Estacion, f.Fecha }).Select(group => new Entidades.ReporteVehiculos { estacion = group.Key.Estacion, fecha = group.Key.Fecha, cantidadTotal = (int)group.Sum(f => f.Cantidad), recaudadoTotal = (decimal)group.Sum(f => f.ValorTabulado) }).OrderBy(o => o.fecha).ToList();

            return listReporteVehiculos;
        }

    }
}
