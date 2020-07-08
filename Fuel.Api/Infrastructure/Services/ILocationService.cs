namespace Fuel.Api.Infrastructure.Services
{
    using Fuel.Domain;
    using Fuel.Domain.ViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationService
    {
        List<LocationViewModel> GetLocations(LocationRequest locationRequest);
    }
}
