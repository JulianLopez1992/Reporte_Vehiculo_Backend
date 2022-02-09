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

        public List<Entidades.EstacionPonderada> GetListReporteVehiculo()
        {
            JLopezContext dbContext = new JLopezContext();

            List<Entidades.ReporteVehiculos> listReporteVehiculos = dbContext.Vehiculos.GroupBy(f => new { f.Estacion, f.Fecha }).Select(group => new Entidades.ReporteVehiculos { estacion = group.Key.Estacion, fecha = group.Key.Fecha, cantidadTotal = (int)group.Sum(f => f.Cantidad), recaudadoTotal = (decimal)group.Sum(f => f.ValorTabulado) }).OrderBy(o => o.fecha).ToList();

            var listReporteVehiculosGrouping = listReporteVehiculos.GroupBy(g => g.estacion);

            List<Entidades.EstacionPonderada> estacionPonderada = new List<Entidades.EstacionPonderada>();

            foreach (var item in listReporteVehiculosGrouping)
            {
                Entidades.EstacionPonderada estacionPond = new Entidades.EstacionPonderada();
                estacionPond.estacion = item.Key;
                estacionPond.informacionEstacion = new List<Entidades.DatosEstacion>();
                foreach (var i in item)
                {
                    estacionPond.informacionEstacion.Add(new Entidades.DatosEstacion
                    {
                        fecha = (DateTime)i.fecha,
                        cantidadTotal = (int)i.cantidadTotal,
                        recaudoTotal = i.recaudadoTotal
                    });
                }

                estacionPonderada.Add(estacionPond);
            }


            return estacionPonderada;
        }

    }
}
