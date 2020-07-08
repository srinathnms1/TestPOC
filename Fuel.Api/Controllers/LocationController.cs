namespace Fuel.Api.Controllers
{
    using Fuel.Api.Infrastructure.Services;
    using Fuel.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Fuel.Api.Infrastructure.Extensions;

    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET api/fuelinfo
        [HttpGet, Route("")]
        public IActionResult Get(string driverId, string fromDate, string toDate)
        {
            if (driverId == null || fromDate == null || toDate == null)
            {
                return BadRequest("Invalid query parameters");
            }
            var dateFormat = "yyyy-MM-dd";
            LocationRequest locationRequest = new LocationRequest() { 
                DriverId = int.Parse(driverId),
                FromDate = fromDate.ToDateTime(dateFormat, CultureInfo.CurrentCulture.Name), 
                ToDate = toDate.ToDateTime(dateFormat, CultureInfo.CurrentCulture.Name)
            };
            var locations = _locationService.GetLocations(locationRequest);
            return Ok(locations);
        }
    }
}