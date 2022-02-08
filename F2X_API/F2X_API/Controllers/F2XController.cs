using Entidades;
using Logica;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace F2X_API.Controllers
{
    //[EnableCors()]
    [Route("api/[controller]")]
    [ApiController]
    public class F2XController : ControllerBase
    {


        /// <summary>
        /// Muestra la información sobre los vehiculos registrados
        /// </summary>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response> 
        [HttpGet("GetInfoVehiculos")]
        public IActionResult GetInfoVehiculos()
        {
            VehiculosF2X vehiculosF2X = new VehiculosF2X();
            List<VehiculosEN> listInfoVehiculo = vehiculosF2X.GetListInfoVehiculos();

            if (listInfoVehiculo != null)
            {
                return Ok(listInfoVehiculo);
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Muestra la información sobre la cantidad de vehículos registrados.
        /// </summary>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response> 
        [HttpGet("GetConteoVehiculos")]
        public IActionResult GetConteoVehiculos()
        {
            VehiculosF2X vehiculosF2X = new VehiculosF2X();
            List<ConteoVehiculo> listConteoVehiculo = vehiculosF2X.GetListConteoVehiculo();

            if (listConteoVehiculo != null)
            {
                return Ok(listConteoVehiculo);
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Muestra la información sobre el valor tabulado
        /// </summary>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response> 
        [HttpGet("GetRecaudoVehiculos")]
        public IActionResult GetRecaudoVehiculos()
        {
            VehiculosF2X vehiculosF2X = new VehiculosF2X();

            List<RecaudoVehiculo> listRecaudoVehiculo = vehiculosF2X.GetListRecaudoVehiculo();

            if (listRecaudoVehiculo != null)
            {
                return Ok(listRecaudoVehiculo);
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Muestra la información de la cantidad de vehiculos y total tabulado por fecha en cada estación.
        /// </summary>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response> 
        [HttpGet("GetReporteVehiculos")]
        public IActionResult GetReporteVehiculos()
        {
            VehiculosF2X vehiculosF2X = new VehiculosF2X();

            List<ReporteVehiculos> listoReporteVehiculos = vehiculosF2X.GetListReporteVehiculo();

            if (listoReporteVehiculos != null)
            {
                return Ok(listoReporteVehiculos);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
