namespace Fuel.Api.Controllers
{
    using Fuel.Api.Infrastructure.Services;
    using Fuel.Domain;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;
    using System.Threading.Tasks;
    using Fuel.Api.Infrastructure.Extensions;
    using Fuel.Api.Infrastructure.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class FuelInfoController : ControllerBase
    {
        private readonly IFuelService _fuelService;
        public FuelInfoController(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }

        // GET api/fuelinfo
        [HttpGet, Route("")]
        public IActionResult Get([FromQuery, ModelBinder(Name ="FromDate")] FuelInfoServiceRequest fuelInfoServiceRequest)
        {
            //if (driverId == null || fromDate == null || toDate == null)
            //{
            //    return BadRequest("Invalid query parameters");
            //}
            var dateFormat = "yyyy-MM-dd";
            FuelInfoRequest fuelInfoRequest = new FuelInfoRequest() {
                DriverId = int.Parse(fuelInfoServiceRequest.DriverId),
                FromDate = fuelInfoServiceRequest.FromDate.ToDateTime(dateFormat, CultureInfo.CurrentCulture.Name), 
                ToDate = fuelInfoServiceRequest.ToDate.ToDateTime(dateFormat, CultureInfo.CurrentCulture.Name)
            };
            var locations = _fuelService.GetFuelInfo(fuelInfoRequest);
            return Ok(locations);
        }
    }
}