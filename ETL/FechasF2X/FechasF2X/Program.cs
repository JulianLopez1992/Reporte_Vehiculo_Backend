using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using FechasF2X.Models;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//SqlConnection sqlConnection = new SqlConnection(@"Server=20.122.126.220;Database=JLopez; User Id=julianl;Password=AP7ce2$_{\DtNr,a;");
//sqlConnection.Open();




HttpClient httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://190.145.81.67:5200");
httpClient.DefaultRequestHeaders.Accept.Clear();
httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIiLCJqdGkiOiI5MWU1ODdhZi1lZjllLTQ1NmMtOTRmYi1kY2FlZGZjM2JmZDEiLCJleHAiOjE2NDQwNTA0MjN9.4PGq1dSZtlYp4fodoN4d_dbX05_IxbbI2CM2bgglhrA");//("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIiLCJqdGkiOiI5ZDQ0NWQ4ZS1hN2U2LTQ1NWItOGEyMi0zYWQzMjU2YTgyY2YiLCJleHAiOjE2NDQwMzg2MTd9.yrmbJc1_kM5Kj86QajSRivr5Wp02zlbU-1k_17rqwZw");



for (int i = 2020; i <= 2022; i++)
{
    for (int j = 1; j <= 12; j++)
    {
        for (int o = 1; o < 28; o++)
        {
            HttpResponseMessage responseConteo = await httpClient.GetAsync($"http://190.145.81.67:5200/api/ConteoVehiculos/{i}-{j}-{o}");
            HttpResponseMessage responseRecaudo = await httpClient.GetAsync($"http://190.145.81.67:5200/api/RecaudoVehiculos/{i}-{j}-{o}");

            if (responseRecaudo.IsSuccessStatusCode)
            {
                var jsonConteo = await responseConteo.Content.ReadAsStringAsync();
                var vehiculosConteo = JsonConvert.DeserializeObject<List<ConteoVehiculoMinusculas>>(jsonConteo);

                var jsonRecaudo = await responseRecaudo.Content.ReadAsStringAsync();
                var vehiculosRecaudo = JsonConvert.DeserializeObject<List<RecaudoVehiculoMinusculas>>(jsonRecaudo);

                if (vehiculosConteo != null && vehiculosRecaudo != null)
                {
                    using (JLopezContext dbContext = new JLopezContext())
                    {
                        vehiculosConteo.ForEach(x => {
                            ConteoVehiculo conteoVehiculo = new ConteoVehiculo();
                            conteoVehiculo.Categoria = x.categoria;
                            conteoVehiculo.Cantidad = x.cantidad;
                            conteoVehiculo.Hora = x.hora;
                            conteoVehiculo.Estacion = x.estacion;
                            conteoVehiculo.Sentido = x.sentido;
                            conteoVehiculo.Fecha = new DateTime(i,j,o);

                            dbContext.ConteoVehiculos.Add(conteoVehiculo);

                        });

                        vehiculosRecaudo.ForEach(x => {
                            RecaudoVehiculo vehiculosRecaudo = new RecaudoVehiculo();
                            vehiculosRecaudo.Categoria = x.categoria;
                            vehiculosRecaudo.ValorTabulado = x.valortabulado;
                            vehiculosRecaudo.Hora = x.hora;
                            vehiculosRecaudo.Estacion = x.estacion;
                            vehiculosRecaudo.Sentido = x.sentido;
                            vehiculosRecaudo.Fecha = new DateTime(i, j, o);

                            dbContext.RecaudoVehiculos.Add(vehiculosRecaudo);

                        });

                        dbContext.SaveChanges();
                    }

                    Console.WriteLine($"FECHA: {i}-{j}-{o}");
                    Console.WriteLine(vehiculosConteo[0].categoria);
                }
            }
        }
    }
}


public class ConteoVehiculoMinusculas
{
    public string? estacion { get; set; }
    public string? sentido { get; set; }
    public decimal? hora { get; set; }
    public string? categoria { get; set; }
    public int? cantidad { get; set; }
}

public class RecaudoVehiculoMinusculas
{
    public string? estacion { get; set; }
    public string? sentido { get; set; }
    public int? hora { get; set; }
    public string? categoria { get; set; }
    public decimal? valortabulado { get; set; }
}




