using System.Collections.Generic;
using System.Linq;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Domain.Locations;
using Microsoft.AspNetCore.Mvc;

namespace F23.PresentationModelLnL.Web.VendorPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/Locations")]
    public class LocationsController : Controller
    {
        private readonly ILocationRepository _locationRepository;

        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public IEnumerable<Location> GetAll(string searchTerm)
        {
            var query = _locationRepository.GetLocations();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Name.Contains(searchTerm));
            }

            return query;
        }
    }
}