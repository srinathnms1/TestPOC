namespace Fuel.Domain
{
    using DcsService.Core;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFuelInfoRepository : IGenericRepository<DcsFuelInfo>
    {
        List<DcsFuelInfo> GetFuelInfo(FuelInfoRequest fuelInfoRequest);
    }
}
