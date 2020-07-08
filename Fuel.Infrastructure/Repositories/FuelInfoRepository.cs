namespace Fuel.Infrastructure.Repositories
{
    using Fuel.Domain;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System.Linq;

    public class FuelInfoRepository : GenericRepository<DcsFuelInfo>, IFuelInfoRepository
    {
        public FuelInfoRepository(PostgresContext postgresContext)
        : base(postgresContext)
        {
        }

        public List<DcsFuelInfo> GetFuelInfo(FuelInfoRequest fuelInfoRequest)
        {
            var fuelInfo = GetAll()
                .Where(c => c.DriverVehicle.Driver.DriverId == fuelInfoRequest.DriverId
                && (c.PacketTime >= fuelInfoRequest.FromDate
                && c.PacketTime <= fuelInfoRequest.ToDate))
                .Include(i => i.DriverVehicle).ToList();

            return fuelInfo;
        }
    }
}
