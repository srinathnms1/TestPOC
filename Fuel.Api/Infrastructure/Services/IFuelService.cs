namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain;

    public interface IFuelService
    {
        FuelInfoViewModel GetFuelInfo(FuelInfoRequest fuelInfoRequest);
    }
}
