using System.Linq;
using F23.PresentationModelLnL.Domain.Locations;

namespace F23.PresentationModelLnL.Contracts.Repositories
{
    public interface ILocationRepository
    {
        IQueryable<Location> GetLocations();
    }
}
