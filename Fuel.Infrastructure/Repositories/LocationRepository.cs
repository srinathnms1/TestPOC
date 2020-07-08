namespace Fuel.Infrastructure.Repositories
{
    using Fuel.Domain;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using System.Globalization;

    public class LocationRepository : GenericRepository<DcsLocation>, ILocationRepository
    {
        public LocationRepository(PostgresContext postgresContext)
        : base(postgresContext)
        {
        }

        public List<DcsLocation> GetLocations(LocationRequest locationRequest)
        {
            var locations = GetAll().Include(i => i.VehicleRealTimeInfo)
                .Where(c => c.VehicleRealTimeInfo.DriverVehicle.Driver.DriverId == locationRequest.DriverId
                && (c.VehicleRealTimeInfo.PacketTime >= locationRequest.FromDate
                && c.VehicleRealTimeInfo.PacketTime <= locationRequest.ToDate))
                .Include(i => i.VehicleRealTimeInfo.DriverVehicle.Driver)
                .Include(i => i.VehicleRealTimeInfo.DriverVehicle.Vehicle).ToList();
            return locations;
        }
    }
}
