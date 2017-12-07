using System.Linq;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Domain;

namespace F23.PresentationModelLnL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppContext _context;

        public LocationRepository(AppContext context)
        {
            _context = context;
        }

        public IQueryable<Location> GetLocations()
        {
            return _context.Locations;
        }
    }
}
